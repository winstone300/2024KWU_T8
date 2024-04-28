using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace oss_rythm
{
    public partial class pause : Form
    {
        public event EventHandler Changed;
        private WindowsMediaPlayer _media;
        public pause(WindowsMediaPlayer media)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; 
            this.FormBorderStyle = FormBorderStyle.None;
            _media = media;
            volume.Value = _media.settings.volume;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Changed(this, new EventArgs());
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
        private void Volume_Scroll(object sender, EventArgs e)
        {
            if (volume.Value == 0)
            {
                _media.settings.volume = 0;
            }
            else
            {
                _media.settings.volume = volume.Value;
            }

        }
        private int VolumeToTrackbar(int Min, int Max, int Per)
        {
            double iRange = Max - Min;
            double iTarget = iRange * Per / 100;
            return (int)(iTarget + Min);
        }
    }
}
