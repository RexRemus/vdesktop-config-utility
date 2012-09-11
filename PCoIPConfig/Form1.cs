using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Timers;
using System.Reflection;
using System.Collections;

namespace PCoIPConfig
{
    public partial class ProfileEditorForm : Form
    {
        SessionStatsForm sessionStatsForm;
        HealthMeterForm healthForm;
        ToolStripMenuItem activeProfile;
        bool CloseApp = false;
        WMIStats stats;
        int latencySampleCnt = 5;
        Queue<double> latencySamples = new Queue<double>();
        double healthScore;
        State healthState;
        State currentHealthState;
        double pktLossPercentile, latencyPercentile, variancePercentile, activeBWPercentile;
        int varianceMax = 150;
        int latencyMax = 300;
        double pktLossMax = 5.0;
        int activeBWMax = 1500;
        Icon lastIcon;

        enum State { Green, Yellow, Orange, Red };

        // Polling timer
        System.Timers.Timer WMITimer;     

        public ProfileEditorForm()
        {
            InitializeComponent();
            UpdateProfileMenu();
            loadLastSelectedProfile();

            WMITimer = new System.Timers.Timer();
            WMITimer.Elapsed += new ElapsedEventHandler(pollWMIStats);
            //WMITimer.Disposed += new EventHandler(OurTimerDisposed);
            WMITimer.Interval = 1000;
            stats = new WMIStats(WMITimer.Interval); // create a new WMIstats object before we start
            sessionStatsForm = new SessionStatsForm(stats);
            WMITimer.Start(); // kick off the timer

            healthForm = new HealthMeterForm();
            healthForm.SetMaxScore(4.00d);
        }

        private void pollWMIStats(object source, ElapsedEventArgs e)
        {
            stats.collectWMIStats(); // poll for new stats
            sessionStatsForm.updateStats(); // update the stats window

            // Packet loss
            // We only care about values up to 5% so anything higher than that can be discarded (set to 5)
            double adjPktLoss = (stats.getTxPktLoss() * 100);
            if ( adjPktLoss > pktLossMax ) adjPktLoss = pktLossMax;
            pktLossPercentile = (pktLossMax - adjPktLoss) / pktLossMax;
            healthForm.UpdateBar(PCoIPConfig.HealthMeterForm.Stat.Loss, (int)(pktLossPercentile * 100));

            // Latency
            double adjLatency = stats.getNetLatency();
            if (adjLatency > latencyMax) adjLatency = latencyMax;
            latencyPercentile = (latencyMax - adjLatency) / latencyMax;
            healthForm.UpdateBar(PCoIPConfig.HealthMeterForm.Stat.Latency, (int)(latencyPercentile * 100));

            // Latency Variance
            if (latencySamples.Count == latencySampleCnt) latencySamples.Dequeue(); // remove oldest sample
            latencySamples.Enqueue(stats.getNetLatency()); // add current sample
            double latencyVariance = CalculateVariance(latencySamples);
            if (latencyVariance > varianceMax) latencyVariance = varianceMax; // Anything higher than this is in the red anyway
            variancePercentile = (varianceMax - latencyVariance) / varianceMax;
            healthForm.UpdateBar(PCoIPConfig.HealthMeterForm.Stat.Variance, (int)(variancePercentile * 100));

            // Active bandwidth
            double adjActiveBW = stats.getActiveTxBWLimit();
            if (adjActiveBW > activeBWMax) adjActiveBW = activeBWMax;
            activeBWPercentile = (activeBWMax - (activeBWMax - adjActiveBW)) / activeBWMax;
            healthForm.UpdateBar(PCoIPConfig.HealthMeterForm.Stat.Bandwidth, (int)(activeBWPercentile * 100));

            healthScore = pktLossPercentile + latencyPercentile + variancePercentile + activeBWPercentile;
            healthForm.UpdateScore(healthScore);

            if (healthScore > 3.5)
            {
                systrayIcon.Icon = Properties.Resources.view_client_icon_green;
                healthState = State.Green;
            }
            else if (healthScore >= 3.0 && healthScore <= 3.5)
            {
                systrayIcon.Icon = Properties.Resources.view_client_icon_yellow;
                healthState = State.Yellow;
            }
            else if (healthScore >= 2.1 && healthScore < 3.0)
            {
                systrayIcon.Icon = Properties.Resources.view_client_icon_orange;
                healthState = State.Orange;
            }
            else if (healthScore < 2.1)
            {
                systrayIcon.Icon = Properties.Resources.view_client_icon_red;
                healthState = State.Red;
            }

            if (lastIcon == null)
            {
                lastIcon = systrayIcon.Icon;
            }
            else if (healthState != currentHealthState)
            {
                //systrayIcon.BalloonTipTitle = "Health Score";
                //systrayIcon.BalloonTipText = string.Format("{0:n}", healthScore);
                //systrayIcon.BalloonTipText = lastIcon.GetHashCode() + "\n" + systrayIcon.Icon.GetHashCode();
                //systrayIcon.ShowBalloonTip(250);
            }
            lastIcon = systrayIcon.Icon;
            currentHealthState = healthState;
        }

        private double CalculateVariance(Queue<double> input)
        {
            double sumOfSquares = 0.0;
            double total = 0.0;
            foreach (double d in input)
            {
                total += d;
                sumOfSquares += Math.Pow(d, 2);
            }
            int n = input.Count;
            return ((n * sumOfSquares) - Math.Pow(total, 2)) / (n * (n - 1));
        }

        public string GetProfileTooltipText(string profileName)
        {
            string tooltip = "Profile Settings:\n";

            String[] settings = (String[])Program.Profiles.GetValue(profileName);
            for (int i = 0; i < settings.Length; i++)
            {
                //Lookup a friendly name for each setting
                switch (settings[i])
                {
                    case "pcoip.maximum_frame_rate":
                        tooltip += "  Max FPS:\t" + settings[++i] + "\n";
                    break;
                    case "pcoip.minimum_image_quality":
                    tooltip += "  Min Img Qual:\t" + settings[++i] + "%\n";
                    break;
                    case "pcoip.maximum_initial_image_quality":
                    tooltip += "  Max Init Qual:\t" + settings[++i] + "%\n";
                    break;
                    case "pcoip.enable_build_to_lossless":
                    tooltip += "  BTL:\t\t" + (settings[++i].Equals("0") ? "No" : "Yes") + "\n";
                    break;
                    case "pcoip.audio_bandwidth_limit":
                    tooltip += "  Max Audio B/W:\t" + settings[++i] + "Kb\n";
                    break;
                    case "pcoip.max_link_rate":
                    tooltip += "  Max Sess. B/W:\t" + settings[++i] + "Kb\n";
                    break;
                    case "pcoip.device_bandwidth_floor":
                    tooltip += "  Sess. B/W Floor:\t" + settings[++i] + "Kb\n";
                    break;

                }
            }

            return tooltip;
        }

        public void UpdateProfileMenu()
        {
            activateProfileToolStripMenuItem.DropDownItems.Clear();

            foreach (string profileName in Program.Profiles.GetValueNames())
            {
                System.Windows.Forms.ToolStripMenuItem profile = new System.Windows.Forms.ToolStripMenuItem();
                profile.Name = profileName;
                profile.Text = profileName;
                profile.CheckOnClick = true;
                profile.Click += new EventHandler(profileSelected);
                profile.ToolTipText = GetProfileTooltipText(profileName);
                if ( activeProfile != null && activeProfile.Name.Equals(profileName) ) profile.Checked = true; // Select the profile if it's currently active
                activateProfileToolStripMenuItem.DropDownItems.Add(profile);
            }
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            //MessageBox.Show(contextMenu.Items[0].Name);
            //(contextMenu.Items[0] as ToolStripMenuItem)
            //UpdateProfileMenu();
        }

        private void profileSelected(object sender, EventArgs e)
        {
            if (activeProfile != null)
            {
                activeProfile.Checked = false; // clear previously selected profile menu item
                removeProfile(activeProfile.Name); // Clean up all previous settings
            }
            activeProfile = (sender as ToolStripMenuItem);
            //MessageBox.Show((sender as ToolStripMenuItem).Name);
            applyProfile(activeProfile.Name);
            // Store the new profile as most recently used
            Program.Configuration.SetValue("MRUProfile", activeProfile.Name, Microsoft.Win32.RegistryValueKind.String);

            systrayIcon.Text = "Active Profile: " + activeProfile.Name;

            // Alert the user to disconnect and log on to apply settings
            MessageBox.Show("You must disconnect and re-connect for the new profile to take effect.");
        }

        private void loadLastSelectedProfile()
        {
            String MRUProfile = (String)Program.Configuration.GetValue("MRUProfile");
            if (MRUProfile == null) return;
            // Select the profile in the drop-down menu
            foreach ( ToolStripMenuItem profile in activateProfileToolStripMenuItem.DropDownItems ) {
                if ( profile.Name.Equals(MRUProfile) ) {
                    profile.Checked = true; // Select the profile
                    applyProfile(MRUProfile); // Apply it again, just to be safe
                    activeProfile = profile;
                }
            }
        }

        private void applyProfile(String profile)
        {
            String[] settings = (String[])Program.Profiles.GetValue(profile);
            for (int i = 0; i < settings.Length; i++)
            {
                Program.PCoIPAdmin.SetValue(settings[i], settings[++i], Microsoft.Win32.RegistryValueKind.DWord);
            }

        }

        private void removeProfile(String profile)
        {
            String[] settings = (String[])Program.Profiles.GetValue(profile);
            for (int i = 0; i < settings.Length; i+=2)
            {
                try
                {
                    Program.PCoIPAdmin.DeleteValue(settings[i]);
                } catch (ArgumentException argEx) {
                    // just eat this - we're deleting the value, if it doesn't exist who cares
                }
            }
        }

        private void clearProfileSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeProfile != null)
            {
                activeProfile.Checked = false; // clear previously selected profile menu item
                removeProfile(activeProfile.Name); // Clean up all previous settings
                activeProfile = null;
            }
            try
            {
                Program.Configuration.DeleteValue("MRUProfile"); // purge the most recently used profile data
            }
            catch (ArgumentException argEx)
            {
                // just eat this - we're deleting the value, if it doesn't exist who cares
            }
            
        }

        private void systrayIcon_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(systrayIcon, null);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseApp = true;
            this.Close();
        }

        private void MaxInitImgQualSlider_Scroll(object sender, EventArgs e)
        {
            MaxInitImgQualSlider.Value = (int)((MaxInitImgQualSlider.Value / 10) * 10); // snap to 10's
            // Validate that min img qual is always lower than or equal to this value
            if (MinImgQualSlider.Value > MaxInitImgQualSlider.Value)
            {
                MinImgQualSlider.Value = MaxInitImgQualSlider.Value;
                MinImgQualLabel.Text = MinImgQualSlider.Value.ToString();
            }
            MaxInitImgQualLabel.Text = MaxInitImgQualSlider.Value.ToString();
        }

        private void MinImgQualSlider_Scroll(object sender, EventArgs e)
        {
            MinImgQualSlider.Value = (int)((MinImgQualSlider.Value / 10)*10); // snap to 10's
            // Validate that max init img qual is always greater or equal to this value
            if (MaxInitImgQualSlider.Value < MinImgQualSlider.Value)
            {
                MaxInitImgQualSlider.Value = MinImgQualSlider.Value;
                MaxInitImgQualLabel.Text = MaxInitImgQualSlider.Value.ToString();
            }
            MinImgQualLabel.Text = MinImgQualSlider.Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaxInitImgQualLabel.Text = MaxInitImgQualSlider.Value.ToString();
            MinImgQualLabel.Text = MinImgQualSlider.Value.ToString();
            MaxFPSLabel.Text = MaxFPSSlider.Value.ToString();


        }

        private void MaxFPSSlider_Scroll(object sender, EventArgs e)
        {
            MaxFPSLabel.Text = MaxFPSSlider.Value.ToString();
        }

        private void manageProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            populateProfileSelections();
            setupProfileMgtEditor();
            // Edit the active profile by default if there is one
            String profile = activeProfile != null ? activeProfile.Name : profileDropDown.Items[0].ToString();
            profileDropDown.SelectedItem = profile;

                        
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void setupProfileMgtEditor()
        {
            String profile = activeProfile != null ? activeProfile.Name : profileDropDown.Items[0].ToString();
            setupProfileMgtEditor(profile);
        }

        private void setupProfileMgtEditor(String profileName)
        {
                String[] settings = (String[])Program.Profiles.GetValue(profileName);
                for (int i = 0; i < settings.Length; i++)
                {
                    switch (settings[i])
                    {
                        case "pcoip.enable_build_to_lossless":
                            BTLEnabledCheckBox.Checked = settings[++i].Equals("1") ? true : false;
                            break;
                        case "pcoip.maximum_initial_image_quality":
                            MaxInitImgQualSlider.Value = Convert.ToInt32(settings[++i]);
                            break;
                        case "pcoip.minimum_image_quality":
                            MinImgQualSlider.Value = Convert.ToInt32(settings[++i]);
                            break;
                        case "pcoip.maximum_frame_rate":
                            MaxFPSSlider.Value = Convert.ToInt32(settings[++i]);
                            break;
                        case "pcoip.audio_bandwidth_limit":
                            audioBandwidthLimit.Value = Convert.ToInt32(settings[++i]);
                            break;
                        case "pcoip.max_link_rate":
                            maxSessionBandwidth.Value = Convert.ToInt32(settings[++i]);
                            break;
                        case "pcoip.device_bandwidth_floor":
                            sessionBandwidthFloor.Value = Convert.ToInt32(settings[++i]);
                            break;
                        default:
                            break;
                    }
                }
        }

        private void ProfileEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CloseApp)
            {
                e.Cancel = true;
                this.Hide();
                this.WindowState = FormWindowState.Minimized;
            } 
        }

        private void showSessionStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showSessionStatsToolStripMenuItem.Checked)
            {
                sessionStatsForm.Show();
            }
            else
            {
                sessionStatsForm.Hide();
            }
        }

        private void profileDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update editor configuration for the profile that was selected
            setupProfileMgtEditor(profileDropDown.SelectedItem.ToString());
        }

        private void populateProfileSelections()
        {
            profileDropDown.Items.Clear();
            foreach (string profileName in Program.Profiles.GetValueNames())
            {
                profileDropDown.Items.Add(profileName);
            }
        }

        private void saveProfileBtn_Click(object sender, EventArgs e)
        {
            String profileName = profileDropDown.Text;
            //String profileName = profileDropDown.SelectedItem.ToString();
            String[] profileSettings = { "pcoip.maximum_frame_rate", MaxFPSSlider.Value.ToString(),
                                         "pcoip.minimum_image_quality", MinImgQualSlider.Value.ToString(),
                                         "pcoip.maximum_initial_image_quality", MaxInitImgQualSlider.Value.ToString(),
                                         "pcoip.enable_build_to_lossless", BTLEnabledCheckBox.Checked ? "1" : "0",
                                         "pcoip.audio_bandwidth_limit", audioBandwidthLimit.Value.ToString(),
                                         "pcoip.max_link_rate", maxSessionBandwidth.Value.ToString(),
                                         "pcoip.device_bandwidth_floor", sessionBandwidthFloor.Value.ToString()
                                       };
            // Store or update the profile
            Program.Profiles.SetValue(profileName, profileSettings, RegistryValueKind.MultiString);
            // Update the profile dropdown box and profile menu items
            populateProfileSelections();
            UpdateProfileMenu();
            // Reselect the newly saved profile
            profileDropDown.SelectedItem = profileName;
        }

        private void delProfileBtn_Click(object sender, EventArgs e)
        {
            String profileToDelete = profileDropDown.SelectedItem.ToString();
            // Delete the currently selected profile from the profile editor
            Program.Profiles.DeleteValue(profileToDelete);
            // Update the profile dropdown box and profile menu items
            populateProfileSelections();
            UpdateProfileMenu();
            profileDropDown.SelectedItem = profileDropDown.Items[0];
            if (profileToDelete.Equals(activeProfile.Name))
            {
                activeProfile = null;
            }
        }

        private void restoreDefaultsBtn_Click(object sender, EventArgs e)
        {
            // First delete all existing profiles
            foreach (string profileName in Program.Profiles.GetValueNames())
            {
                Program.Profiles.DeleteValue(profileName);
            }
            // Now recreate the defaults
            Program.populateDefaultProfiles();
            // Update the profile dropdown box and profile menu items
            populateProfileSelections();
            UpdateProfileMenu();
            profileDropDown.SelectedItem = profileDropDown.Items[0];
            activeProfile = null; // I think I should do this here...
        }

        private void showSessionHealthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showSessionHealthToolStripMenuItem.Checked)
            {
                healthForm.Show();
            }
            else
            {
                healthForm.Hide();
            }
        }
    }
}
