namespace SpectrogramCourseWork
{
    partial class MainForm
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
            this.buttonSelectWave = new System.Windows.Forms.Button();
            this.labelPath = new System.Windows.Forms.Label();
            this.labelDuration = new System.Windows.Forms.Label();
            this.boxControl = new System.Windows.Forms.PictureBox();
            this.labelPlayback = new System.Windows.Forms.Label();
            this.boxSpectrogram = new System.Windows.Forms.PictureBox();
            this.barPlayback = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.boxControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxSpectrogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barPlayback)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSelectWave
            // 
            this.buttonSelectWave.Location = new System.Drawing.Point(12, 12);
            this.buttonSelectWave.Name = "buttonSelectWave";
            this.buttonSelectWave.Size = new System.Drawing.Size(95, 42);
            this.buttonSelectWave.TabIndex = 0;
            this.buttonSelectWave.Text = "Select Wav";
            this.buttonSelectWave.UseVisualStyleBackColor = true;
            this.buttonSelectWave.Click += new System.EventHandler(this.ButtonSelectWave_Click);
            // 
            // labelPath
            // 
            this.labelPath.Location = new System.Drawing.Point(114, 24);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(726, 20);
            this.labelPath.TabIndex = 1;
            this.labelPath.Text = "path";
            this.labelPath.Visible = false;
            this.labelPath.VisibleChanged += new System.EventHandler(this.LabelPath_VisibleChanged);
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Location = new System.Drawing.Point(797, 542);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(39, 16);
            this.labelDuration.TabIndex = 2;
            this.labelDuration.Text = "00:00";
            this.labelDuration.Visible = false;
            // 
            // boxControl
            // 
            this.boxControl.InitialImage = global::SpectrogramCourseWork.Properties.Resources.playIdle;
            this.boxControl.Location = new System.Drawing.Point(411, 542);
            this.boxControl.Name = "boxControl";
            this.boxControl.Size = new System.Drawing.Size(32, 32);
            this.boxControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boxControl.TabIndex = 1;
            this.boxControl.TabStop = false;
            this.boxControl.Visible = false;
            this.boxControl.Click += new System.EventHandler(this.BoxControl_Click);
            this.boxControl.MouseEnter += new System.EventHandler(this.BoxControl_MouseEnter);
            this.boxControl.MouseLeave += new System.EventHandler(this.BoxControl_MouseLeave);
            // 
            // labelPlayback
            // 
            this.labelPlayback.AutoSize = true;
            this.labelPlayback.Location = new System.Drawing.Point(14, 542);
            this.labelPlayback.Name = "labelPlayback";
            this.labelPlayback.Size = new System.Drawing.Size(39, 16);
            this.labelPlayback.TabIndex = 0;
            this.labelPlayback.Text = "00:00";
            this.labelPlayback.Visible = false;
            // 
            // boxSpectrogram
            // 
            this.boxSpectrogram.Location = new System.Drawing.Point(17, 60);
            this.boxSpectrogram.Name = "boxSpectrogram";
            this.boxSpectrogram.Size = new System.Drawing.Size(817, 428);
            this.boxSpectrogram.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.boxSpectrogram.TabIndex = 6;
            this.boxSpectrogram.TabStop = false;
            this.boxSpectrogram.Visible = false;
            // 
            // barPlayback
            // 
            this.barPlayback.Enabled = false;
            this.barPlayback.Location = new System.Drawing.Point(4, 494);
            this.barPlayback.Name = "barPlayback";
            this.barPlayback.Size = new System.Drawing.Size(838, 45);
            this.barPlayback.TabIndex = 7;
            this.barPlayback.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barPlayback.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(852, 596);
            this.Controls.Add(this.barPlayback);
            this.Controls.Add(this.boxSpectrogram);
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.labelPlayback);
            this.Controls.Add(this.boxControl);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.buttonSelectWave);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spectogram Course Work";
            ((System.ComponentModel.ISupportInitialize)(this.boxControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxSpectrogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barPlayback)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSelectWave;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.PictureBox boxControl;
        private System.Windows.Forms.Label labelPlayback;
        private System.Windows.Forms.PictureBox boxSpectrogram;
        private System.Windows.Forms.TrackBar barPlayback;
    }
}

