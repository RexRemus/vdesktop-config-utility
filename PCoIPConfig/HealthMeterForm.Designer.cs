namespace PCoIPConfig
{
    partial class HealthMeterForm
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
            this.latencyBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lossBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.varianceBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.bandwidthBar = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.healthScore = new System.Windows.Forms.Label();
            this.healthMax = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // latencyBar
            // 
            this.latencyBar.ForeColor = System.Drawing.Color.Red;
            this.latencyBar.Location = new System.Drawing.Point(75, 66);
            this.latencyBar.Name = "latencyBar";
            this.latencyBar.Size = new System.Drawing.Size(184, 23);
            this.latencyBar.Step = 1;
            this.latencyBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.latencyBar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Latency";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Loss";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lossBar
            // 
            this.lossBar.ForeColor = System.Drawing.Color.Red;
            this.lossBar.Location = new System.Drawing.Point(75, 37);
            this.lossBar.Name = "lossBar";
            this.lossBar.Size = new System.Drawing.Size(184, 23);
            this.lossBar.Step = 1;
            this.lossBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.lossBar.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Variance";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // varianceBar
            // 
            this.varianceBar.ForeColor = System.Drawing.Color.Red;
            this.varianceBar.Location = new System.Drawing.Point(75, 95);
            this.varianceBar.Name = "varianceBar";
            this.varianceBar.Size = new System.Drawing.Size(184, 23);
            this.varianceBar.Step = 1;
            this.varianceBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.varianceBar.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Bandwidth";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bandwidthBar
            // 
            this.bandwidthBar.ForeColor = System.Drawing.Color.Red;
            this.bandwidthBar.Location = new System.Drawing.Point(75, 124);
            this.bandwidthBar.Name = "bandwidthBar";
            this.bandwidthBar.Size = new System.Drawing.Size(184, 23);
            this.bandwidthBar.Step = 1;
            this.bandwidthBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.bandwidthBar.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "Health Score:";
            // 
            // healthScore
            // 
            this.healthScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthScore.Location = new System.Drawing.Point(135, 9);
            this.healthScore.Name = "healthScore";
            this.healthScore.Size = new System.Drawing.Size(58, 23);
            this.healthScore.TabIndex = 9;
            this.healthScore.Text = "0.0";
            this.healthScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // healthMax
            // 
            this.healthMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthMax.Location = new System.Drawing.Point(210, 10);
            this.healthMax.Name = "healthMax";
            this.healthMax.Size = new System.Drawing.Size(55, 20);
            this.healthMax.TabIndex = 10;
            this.healthMax.Text = "0.0";
            this.healthMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(198, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "/";
            // 
            // HealthMeterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 161);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.healthMax);
            this.Controls.Add(this.healthScore);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bandwidthBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.varianceBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lossBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.latencyBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HealthMeterForm_MouseDown);
            this.Name = "HealthMeterForm";
            this.Text = "HealthMeterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar latencyBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar lossBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar varianceBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar bandwidthBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label healthScore;
        private System.Windows.Forms.Label healthMax;
        private System.Windows.Forms.Label label6;

    }
}