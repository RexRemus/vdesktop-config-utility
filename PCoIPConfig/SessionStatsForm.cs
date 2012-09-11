using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Timers;
using System.Runtime.InteropServices;

namespace PCoIPConfig
{
    public partial class SessionStatsForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private WMIStats stats;

        public SessionStatsForm(WMIStats stats)
        {
            this.stats = stats;
            InitializeComponent();
        }

        public void updateStats()
        {
            SessionDurationLabel.Text = stats.getSessionDuration();
            totalBandwidthLabel.Text = string.Format("{0:n}/{1:n}", stats.getTotalTxBW(), stats.getTotalTxBWPeak());
            packetLossLabel.Text = string.Format("{0:p}/{1:p}", stats.getTxPktLoss(), stats.getTxPktLossPeak());
            pcoipCPULabel.Text = string.Format("{0:p}/{1:p}", stats.getPCoIPCPUUtil(), stats.getPCoIPCPUUtilPeak());
            imageBandwidthLabel.Text = string.Format("{0:n}/{1:n}", stats.getImageTxBW(), stats.getImageTxBWPeak());
            imgFPSLabel.Text = string.Format("{0:n}/{1:n}", stats.getImageFPS(), stats.getImageFPSPeak());
            netLatencyLabel.Text = string.Format("{0:n}/{1:n}", stats.getNetLatency(), stats.getNetLatencyPeak());
            audioBandwidthLabel.Text = string.Format("{0:n}/{1:n}", stats.getAudioTxBW(), stats.getAudioTxBWPeak());
        }

        public void updateWMIStats()
        {
            //TODO Put formatting operations here - move polling out to Form1.cs with a call to this method
        }

        private void SessionStatsForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }

}
