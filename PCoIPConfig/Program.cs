using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PCoIPConfig
{
    static class Program
    {
        public static RegistryKey HKCUSoftware;
        public static RegistryKey Configuration;
        public static RegistryKey Profiles;
        public static RegistryKey PCoIPAdmin;
        public static RegistryKey VolatileEnv;
        public static ProfileEditorForm profileEditorForm;
        public static Dictionary<String, String[]> defaultProfiles;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            initializeConfiguration();
            profileEditorForm = new ProfileEditorForm();
            profileEditorForm.Visible = false;
            Application.Run(profileEditorForm);
        }

        static void initializeConfiguration()
        {
            // Setup default profiles data
            String[] View_Default = { "pcoip.maximum_frame_rate", "30", "pcoip.minimum_image_quality", "50", "pcoip.maximum_initial_image_quality", "90", "pcoip.enable_build_to_lossless", "1", "pcoip.audio_bandwidth_limit", "500", "pcoip.max_link_rate", "90000", "pcoip.device_bandwidth_floor", "0"};
            String[] View_WAN = { "pcoip.maximum_frame_rate", "15", "pcoip.minimum_image_quality", "50", "pcoip.maximum_initial_image_quality", "70", "pcoip.enable_build_to_lossless", "0", "pcoip.audio_bandwidth_limit", "100", "pcoip.max_link_rate", "90000", "pcoip.device_bandwidth_floor", "0" };
            String[] View_TaskWkr = { "pcoip.maximum_frame_rate", "8", "pcoip.minimum_image_quality", "50", "pcoip.maximum_initial_image_quality", "70", "pcoip.enable_build_to_lossless", "0", "pcoip.audio_bandwidth_limit", "100", "pcoip.max_link_rate", "90000", "pcoip.device_bandwidth_floor", "0" };
            defaultProfiles = new Dictionary<string, string[]>();
            defaultProfiles.Add("View Default", View_Default);
            defaultProfiles.Add("View for WAN", View_WAN);
            defaultProfiles.Add("View Task Worker", View_TaskWkr);

            // Check to see if our configuration area exists
            HKCUSoftware = Registry.CurrentUser.OpenSubKey("Software", true);
            Configuration = HKCUSoftware.OpenSubKey("PCoIP Config", true);
            if (Configuration == null)
            {
                // The application configuration area does not exist, create it
                //MessageBox.Show("Configuration does not exist!");
                HKCUSoftware.CreateSubKey("PCoIP Config"); // Create our configuration area
                Configuration = HKCUSoftware.OpenSubKey("PCoIP Config", true);
                Configuration.CreateSubKey("Profiles"); // Cerate Profile storage area
                Profiles = Configuration.OpenSubKey("Profiles", true);
                // Auto populate default profiles
                populateDefaultProfiles();
            }
            else
            {
                //MessageBox.Show("Configuration DOES exist!");
                if (HKCUSoftware == null) { MessageBox.Show("Software is null"); }
                Configuration = HKCUSoftware.OpenSubKey("PCoIP Config", true);
                if (Configuration == null) { MessageBox.Show("Config is null"); }
                Profiles = Configuration.OpenSubKey("Profiles", true);
                if (Profiles == null) { MessageBox.Show("Profiles is null"); }
            }

            // Check to see if PCoIP Admin area exists
            PCoIPAdmin = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Teradici\\PCoIP\\pcoip_admin_defaults", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
            if (PCoIPAdmin == null)
            {
                // Create PCoIP Admin settings area
                PCoIPAdmin = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Teradici\\PCoIP\\pcoip_admin_defaults");
            }

            // Get a handle to the volatile registry area so we can detect if a session is connected or not
            VolatileEnv = Registry.CurrentUser.OpenSubKey("Volatile Environment", false);
            if (VolatileEnv == null)
            {
                MessageBox.Show("No Volatile Environment found!\nAre you sure the View Agent is installed?\nThis application will now close!");
                Application.Exit();
            }
        }

        public static void populateDefaultProfiles() {
            /* This could be done in a foreach loop but the results would be unordered, an ordered dictionary
             * could be used but adds extra boxing. This list is small enough currently that the fragility of
             * manually editing this section when a new default is added doesn't seem so bad - for now.
             */
            Profiles.SetValue("View Default", defaultProfiles["View Default"], RegistryValueKind.MultiString);
            Profiles.SetValue("View for WAN", defaultProfiles["View for WAN"], RegistryValueKind.MultiString);
            Profiles.SetValue("View Task Worker", defaultProfiles["View Task Worker"], RegistryValueKind.MultiString);
        }

    }
}
