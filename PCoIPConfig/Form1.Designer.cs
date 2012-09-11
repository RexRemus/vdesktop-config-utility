using System.Windows.Forms;
namespace PCoIPConfig
{
    partial class ProfileEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileEditorForm));
            this.systrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.activateProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageProfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearProfileSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSessionStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaxInitImgQualSlider = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.MaxInitImgQualLabel = new System.Windows.Forms.Label();
            this.MinImgQualSlider = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.MinImgQualLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BTLEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.audioBandwidthLimit = new System.Windows.Forms.NumericUpDown();
            this.MaxFPSSlider = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.MaxFPSLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sessionBandwidthFloor = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.maxSessionBandwidth = new System.Windows.Forms.NumericUpDown();
            this.profileDropDown = new System.Windows.Forms.ComboBox();
            this.saveProfileBtn = new System.Windows.Forms.Button();
            this.delProfileBtn = new System.Windows.Forms.Button();
            this.restoreDefaultsBtn = new System.Windows.Forms.Button();
            this.showSessionHealthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxInitImgQualSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinImgQualSlider)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.audioBandwidthLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxFPSSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionBandwidthFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSessionBandwidth)).BeginInit();
            this.SuspendLayout();
            // 
            // systrayIcon
            // 
            this.systrayIcon.ContextMenuStrip = this.contextMenu;
            this.systrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("systrayIcon.Icon")));
            this.systrayIcon.Text = "PCoIP Config";
            this.systrayIcon.Visible = true;
            this.systrayIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.systrayIcon_MouseUp);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activateProfileToolStripMenuItem,
            this.manageProfilesToolStripMenuItem,
            this.clearProfileSettingsToolStripMenuItem,
            this.showSessionStatsToolStripMenuItem,
            this.showSessionHealthToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(205, 170);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // activateProfileToolStripMenuItem
            // 
            this.activateProfileToolStripMenuItem.Name = "activateProfileToolStripMenuItem";
            this.activateProfileToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.activateProfileToolStripMenuItem.Text = "Activate Profile";
            // 
            // manageProfilesToolStripMenuItem
            // 
            this.manageProfilesToolStripMenuItem.Name = "manageProfilesToolStripMenuItem";
            this.manageProfilesToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.manageProfilesToolStripMenuItem.Text = "Manage Profiles";
            this.manageProfilesToolStripMenuItem.Click += new System.EventHandler(this.manageProfilesToolStripMenuItem_Click);
            // 
            // clearProfileSettingsToolStripMenuItem
            // 
            this.clearProfileSettingsToolStripMenuItem.Name = "clearProfileSettingsToolStripMenuItem";
            this.clearProfileSettingsToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.clearProfileSettingsToolStripMenuItem.Text = "Clear Profile Settings";
            this.clearProfileSettingsToolStripMenuItem.Click += new System.EventHandler(this.clearProfileSettingsToolStripMenuItem_Click);
            // 
            // showSessionStatsToolStripMenuItem
            // 
            this.showSessionStatsToolStripMenuItem.CheckOnClick = true;
            this.showSessionStatsToolStripMenuItem.Name = "showSessionStatsToolStripMenuItem";
            this.showSessionStatsToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.showSessionStatsToolStripMenuItem.Text = "Show Session Stats";
            this.showSessionStatsToolStripMenuItem.ToolTipText = "Display PCoIP WMI session stats";
            this.showSessionStatsToolStripMenuItem.Click += new System.EventHandler(this.showSessionStatsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MaxInitImgQualSlider
            // 
            this.MaxInitImgQualSlider.LargeChange = 10;
            this.MaxInitImgQualSlider.Location = new System.Drawing.Point(270, 47);
            this.MaxInitImgQualSlider.Maximum = 100;
            this.MaxInitImgQualSlider.Minimum = 30;
            this.MaxInitImgQualSlider.Name = "MaxInitImgQualSlider";
            this.MaxInitImgQualSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.MaxInitImgQualSlider.Size = new System.Drawing.Size(50, 104);
            this.MaxInitImgQualSlider.SmallChange = 10;
            this.MaxInitImgQualSlider.TabIndex = 1;
            this.MaxInitImgQualSlider.TickFrequency = 10;
            this.MaxInitImgQualSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.MaxInitImgQualSlider.Value = 90;
            this.MaxInitImgQualSlider.Scroll += new System.EventHandler(this.MaxInitImgQualSlider_Scroll);
            this.MaxInitImgQualSlider.ValueChanged += new System.EventHandler(this.MaxInitImgQualSlider_Scroll);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(242, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Maximum Initial Image Quality";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MaxInitImgQualLabel
            // 
            this.MaxInitImgQualLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxInitImgQualLabel.Location = new System.Drawing.Point(267, 29);
            this.MaxInitImgQualLabel.Name = "MaxInitImgQualLabel";
            this.MaxInitImgQualLabel.Size = new System.Drawing.Size(50, 23);
            this.MaxInitImgQualLabel.TabIndex = 3;
            this.MaxInitImgQualLabel.Text = "0";
            this.MaxInitImgQualLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MinImgQualSlider
            // 
            this.MinImgQualSlider.LargeChange = 10;
            this.MinImgQualSlider.Location = new System.Drawing.Point(370, 47);
            this.MinImgQualSlider.Maximum = 100;
            this.MinImgQualSlider.Minimum = 30;
            this.MinImgQualSlider.Name = "MinImgQualSlider";
            this.MinImgQualSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.MinImgQualSlider.Size = new System.Drawing.Size(50, 104);
            this.MinImgQualSlider.SmallChange = 10;
            this.MinImgQualSlider.TabIndex = 4;
            this.MinImgQualSlider.TickFrequency = 10;
            this.MinImgQualSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.MinImgQualSlider.Value = 50;
            this.MinImgQualSlider.Scroll += new System.EventHandler(this.MinImgQualSlider_Scroll);
            this.MinImgQualSlider.ValueChanged += new System.EventHandler(this.MinImgQualSlider_Scroll);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(342, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Minimum Image Quality";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MinImgQualLabel
            // 
            this.MinImgQualLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinImgQualLabel.Location = new System.Drawing.Point(367, 29);
            this.MinImgQualLabel.Name = "MinImgQualLabel";
            this.MinImgQualLabel.Size = new System.Drawing.Size(50, 23);
            this.MinImgQualLabel.TabIndex = 6;
            this.MinImgQualLabel.Text = "0";
            this.MinImgQualLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BTLEnabledCheckBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.audioBandwidthLimit);
            this.groupBox1.Controls.Add(this.MaxFPSSlider);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.MaxFPSLabel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.sessionBandwidthFloor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.maxSessionBandwidth);
            this.groupBox1.Controls.Add(this.MinImgQualSlider);
            this.groupBox1.Controls.Add(this.MaxInitImgQualLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.MaxInitImgQualSlider);
            this.groupBox1.Controls.Add(this.MinImgQualLabel);
            this.groupBox1.Location = new System.Drawing.Point(13, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(533, 191);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tuning Parameters";
            // 
            // BTLEnabledCheckBox
            // 
            this.BTLEnabledCheckBox.AutoSize = true;
            this.BTLEnabledCheckBox.Checked = true;
            this.BTLEnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BTLEnabledCheckBox.Location = new System.Drawing.Point(165, 137);
            this.BTLEnabledCheckBox.Name = "BTLEnabledCheckBox";
            this.BTLEnabledCheckBox.Size = new System.Drawing.Size(15, 14);
            this.BTLEnabledCheckBox.TabIndex = 17;
            this.BTLEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Build-to-Lossless Enabled";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Max. Audio B/W (Kbps)";
            // 
            // audioBandwidthLimit
            // 
            this.audioBandwidthLimit.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.audioBandwidthLimit.Location = new System.Drawing.Point(165, 101);
            this.audioBandwidthLimit.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.audioBandwidthLimit.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.audioBandwidthLimit.Name = "audioBandwidthLimit";
            this.audioBandwidthLimit.Size = new System.Drawing.Size(60, 20);
            this.audioBandwidthLimit.TabIndex = 14;
            this.audioBandwidthLimit.ThousandsSeparator = true;
            this.audioBandwidthLimit.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // MaxFPSSlider
            // 
            this.MaxFPSSlider.Location = new System.Drawing.Point(463, 47);
            this.MaxFPSSlider.Maximum = 120;
            this.MaxFPSSlider.Minimum = 1;
            this.MaxFPSSlider.Name = "MaxFPSSlider";
            this.MaxFPSSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.MaxFPSSlider.Size = new System.Drawing.Size(50, 104);
            this.MaxFPSSlider.TabIndex = 11;
            this.MaxFPSSlider.TickFrequency = 10;
            this.MaxFPSSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.MaxFPSSlider.Value = 30;
            this.MaxFPSSlider.Scroll += new System.EventHandler(this.MaxFPSSlider_Scroll);
            this.MaxFPSSlider.ValueChanged += new System.EventHandler(this.MaxFPSSlider_Scroll);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(445, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 29);
            this.label5.TabIndex = 12;
            this.label5.Text = "Maximum FPS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MaxFPSLabel
            // 
            this.MaxFPSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxFPSLabel.Location = new System.Drawing.Point(460, 29);
            this.MaxFPSLabel.Name = "MaxFPSLabel";
            this.MaxFPSLabel.Size = new System.Drawing.Size(50, 23);
            this.MaxFPSLabel.TabIndex = 13;
            this.MaxFPSLabel.Text = "0";
            this.MaxFPSLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Session B/W Floor (Kbps)";
            // 
            // sessionBandwidthFloor
            // 
            this.sessionBandwidthFloor.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.sessionBandwidthFloor.Location = new System.Drawing.Point(165, 66);
            this.sessionBandwidthFloor.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.sessionBandwidthFloor.Name = "sessionBandwidthFloor";
            this.sessionBandwidthFloor.Size = new System.Drawing.Size(60, 20);
            this.sessionBandwidthFloor.TabIndex = 9;
            this.sessionBandwidthFloor.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Max. Session B/W Limit (Kbps)";
            // 
            // maxSessionBandwidth
            // 
            this.maxSessionBandwidth.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.maxSessionBandwidth.Location = new System.Drawing.Point(165, 31);
            this.maxSessionBandwidth.Maximum = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            this.maxSessionBandwidth.Minimum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.maxSessionBandwidth.Name = "maxSessionBandwidth";
            this.maxSessionBandwidth.Size = new System.Drawing.Size(60, 20);
            this.maxSessionBandwidth.TabIndex = 7;
            this.maxSessionBandwidth.ThousandsSeparator = true;
            this.maxSessionBandwidth.Value = new decimal(new int[] {
            90000,
            0,
            0,
            0});
            // 
            // profileDropDown
            // 
            this.profileDropDown.FormattingEnabled = true;
            this.profileDropDown.Location = new System.Drawing.Point(13, 12);
            this.profileDropDown.Name = "profileDropDown";
            this.profileDropDown.Size = new System.Drawing.Size(204, 21);
            this.profileDropDown.TabIndex = 8;
            this.profileDropDown.SelectedIndexChanged += new System.EventHandler(this.profileDropDown_SelectedIndexChanged);
            // 
            // saveProfileBtn
            // 
            this.saveProfileBtn.Location = new System.Drawing.Point(232, 10);
            this.saveProfileBtn.Name = "saveProfileBtn";
            this.saveProfileBtn.Size = new System.Drawing.Size(95, 23);
            this.saveProfileBtn.TabIndex = 9;
            this.saveProfileBtn.Text = "Save Profile";
            this.saveProfileBtn.UseVisualStyleBackColor = true;
            this.saveProfileBtn.Click += new System.EventHandler(this.saveProfileBtn_Click);
            // 
            // delProfileBtn
            // 
            this.delProfileBtn.Location = new System.Drawing.Point(341, 10);
            this.delProfileBtn.Name = "delProfileBtn";
            this.delProfileBtn.Size = new System.Drawing.Size(95, 23);
            this.delProfileBtn.TabIndex = 10;
            this.delProfileBtn.Text = "Delete Profile";
            this.delProfileBtn.UseVisualStyleBackColor = true;
            this.delProfileBtn.Click += new System.EventHandler(this.delProfileBtn_Click);
            // 
            // restoreDefaultsBtn
            // 
            this.restoreDefaultsBtn.Location = new System.Drawing.Point(451, 10);
            this.restoreDefaultsBtn.Name = "restoreDefaultsBtn";
            this.restoreDefaultsBtn.Size = new System.Drawing.Size(95, 23);
            this.restoreDefaultsBtn.TabIndex = 11;
            this.restoreDefaultsBtn.Text = "Restore Defaults";
            this.restoreDefaultsBtn.UseVisualStyleBackColor = true;
            this.restoreDefaultsBtn.Click += new System.EventHandler(this.restoreDefaultsBtn_Click);
            // 
            // showSessionHealthToolStripMenuItem
            // 
            this.showSessionHealthToolStripMenuItem.CheckOnClick = true;
            this.showSessionHealthToolStripMenuItem.Name = "showSessionHealthToolStripMenuItem";
            this.showSessionHealthToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.showSessionHealthToolStripMenuItem.Text = "Show Session Health";
            this.showSessionHealthToolStripMenuItem.ToolTipText = "Display Session health statistics";
            this.showSessionHealthToolStripMenuItem.Click += new System.EventHandler(this.showSessionHealthToolStripMenuItem_Click);
            // 
            // ProfileEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 241);
            this.Controls.Add(this.restoreDefaultsBtn);
            this.Controls.Add(this.delProfileBtn);
            this.Controls.Add(this.profileDropDown);
            this.Controls.Add(this.saveProfileBtn);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfileEditorForm";
            this.ShowInTaskbar = false;
            this.Text = "PCoIP Profile Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProfileEditorForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MaxInitImgQualSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinImgQualSlider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.audioBandwidthLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxFPSSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sessionBandwidthFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSessionBandwidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon systrayIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem activateProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageProfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearProfileSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TrackBar MaxInitImgQualSlider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label MaxInitImgQualLabel;
        private System.Windows.Forms.TrackBar MinImgQualSlider;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label MinImgQualLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown maxSessionBandwidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown sessionBandwidthFloor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar MaxFPSSlider;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label MaxFPSLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown audioBandwidthLimit;
        private System.Windows.Forms.CheckBox BTLEnabledCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem showSessionStatsToolStripMenuItem;
        private System.Windows.Forms.ComboBox profileDropDown;
        private System.Windows.Forms.Button saveProfileBtn;
        private System.Windows.Forms.Button delProfileBtn;
        private System.Windows.Forms.Button restoreDefaultsBtn;
        private ToolStripMenuItem showSessionHealthToolStripMenuItem;
    }
}