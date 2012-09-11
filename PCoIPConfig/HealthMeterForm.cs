using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PCoIPConfig
{
    public partial class HealthMeterForm : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public enum Stat { Loss, Latency, Variance, Bandwidth };
        ProgressBar updateBar;

        public HealthMeterForm()
        {
            InitializeComponent();
        }

        private void HealthMeterForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public void UpdateBar(Stat bar, int value) {
            switch (bar)
            {
                case Stat.Loss:
                    updateBar = lossBar;
                    break;
                case Stat.Latency:
                    updateBar = latencyBar;
                    break;
                case Stat.Variance:
                    updateBar = varianceBar;
                    break;
                case Stat.Bandwidth:
                    updateBar = bandwidthBar;
                    break;
            }

            updateBar.Value = value;

            if (value > 75)
            {
                updateBar.ForeColor = Color.Green;
            }
            else if (value < 75 && value >= 50)
            {
                updateBar.ForeColor = Color.Yellow;
            }
            else if (value < 50 && value >= 30)
            {
                updateBar.ForeColor = Color.Orange;
            }
            else if (value < 30)
            {
                updateBar.ForeColor = Color.Red;
            }
        }

        public void SetMaxScore(double max)
        {
            healthMax.Text = string.Format("{0:n}", max);
        }

        public void UpdateScore(double score)
        {
            healthScore.Text = string.Format("{0:n}", score);
        }
    }
}
