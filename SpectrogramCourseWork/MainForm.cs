using NAudio.Wave;
using NAudio.Utils;
using System;
using System.IO;
using System.Windows.Forms;
using SpectrogramCourseWork.Properties;

namespace SpectrogramCourseWork
{
    public partial class MainForm : Form
    {
        private WaveOutEvent playback = new WaveOutEvent();
        private Timer playbackTimer = new Timer();
        private TimeSpan totalTime;

        private SampleAggregator sampleAggregator;

        public MainForm()
        {
            InitializeComponent();

            playbackTimer.Interval = 100;
            playbackTimer.Tick += PlaybackTimer_Tick;
        }

        private void PlaybackTimer_Tick(object sender, EventArgs e)
        {
            if (playback.PlaybackState == PlaybackState.Playing)
            {
                labelPlayback.Text = playback.GetPositionTimeSpan().ToString("mm") + ":" + playback.GetPositionTimeSpan().Add(new TimeSpan(0, 0, 1)).ToString("ss");
                barPlayback.Value = Math.Min((int)playback.GetPositionTimeSpan().TotalMilliseconds / 10, barPlayback.Maximum);
            }
            else
            {
                ResetAudio();
            }
        }

        private void ResetAudio()
        {
            playback.Stop();
            playbackTimer.Stop();
            labelPlayback.Text = "00:00";
            barPlayback.Value = 0;
            boxControl.Image = Resources.playIdle;
        }

        private void ButtonSelectWave_Click(object sender, EventArgs e)
        {
            GC.Collect();
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (Settings.Default.LastPath.Length > 1 && (Directory.Exists(Settings.Default.LastPath) || File.Exists(Settings.Default.LastPath)))
                    dialog.InitialDirectory = Settings.Default.LastPath;
                else
                    dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dialog.Filter = ".WAV Files|*.wav";

                if (dialog.ShowDialog() == DialogResult.OK && dialog.CheckFileExists)
                {
                    labelPath.Text = dialog.FileName;
                    Settings.Default.LastPath = dialog.FileName;
                    Settings.Default.Save();
                    sampleAggregator = new SampleAggregator(dialog.FileName);
                    var reader = new WaveFileReader(labelPath.Text);
                    totalTime = reader.TotalTime;
                    labelDuration.Text = reader.TotalTime.ToString("mm") + ":" + reader.TotalTime.ToString("ss");
                    ResetAudio();
                    boxSpectrogram.Image = sampleAggregator.CreateFrequencyBitmap(boxSpectrogram.Width, boxSpectrogram.Height);

                    barPlayback.Minimum = 0;
                    barPlayback.Maximum = (int)totalTime.TotalMilliseconds / 10;
                    
                    labelPath.Visible = true;
                    labelDuration.Visible = true;
                    boxControl.Visible = true;
                    boxSpectrogram.Visible = true;
                    barPlayback.Visible = true;
                    reader.Dispose();
                }
            }
        }

        private void LabelPath_VisibleChanged(object sender, EventArgs e)
        {
            labelDuration.Visible = labelPath.Visible;
            labelPlayback.Visible = labelPath.Visible;
            boxControl.Visible = labelPath.Visible;
        }

        private void BoxControl_Click(object sender, EventArgs e)
        {
            if (playback.PlaybackState == PlaybackState.Stopped)
            {
                if (File.Exists(labelPath.Text))
                {
                    var reader = new WaveFileReader(labelPath.Text);
                    playback.Init(reader);
                    playbackTimer.Start();
                    playback.Play();
                    boxControl.Image = Resources.pauseActive;
                }
            }
            else if (playback.PlaybackState == PlaybackState.Playing)
            {
                ResetAudio();
            }
        }

        private void BoxControl_MouseEnter(object sender, EventArgs e)
        {
            if (playback.PlaybackState == PlaybackState.Stopped)
            {
                boxControl.Image = Resources.playActive;
            }
            else if (playback.PlaybackState == PlaybackState.Playing)
            {
                boxControl.Image = Resources.pauseActive;
            }
        }

        private void BoxControl_MouseLeave(object sender, EventArgs e)
        {
            if (playback.PlaybackState == PlaybackState.Stopped)
            {
                boxControl.Image = Resources.playIdle;
            }
            else if (playback.PlaybackState == PlaybackState.Playing)
            {
                boxControl.Image = Resources.pauseIdle;
            }
        }
    }
}
