using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;

namespace oss_rythm
{
    public partial class Form1 : Form
    {
        pause pause;
        WindowsMediaPlayer _media;
        public Form1()
        {
            InitializeComponent();
            InitializeOpenFileDialog(); 
        }

        private void InitializeOpenFileDialog()
        {
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Filter = "MP3 (*.mp3)|*.mp3|모든파일 (*.*)|*.*";
            ofd.FileName = "";
        }

        private void Music_Play(object sender,EventArgs e)
        {
            _media.controls.play();
            btnStop.Enabled = true;
            btnStop.Visible = true;
            btnLoad.Enabled = true;
            btnLoad.Visible = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            pause = new pause(_media);
            pause.TopLevel = true;
            pause.MdiParent = this;
            pause.Changed += new EventHandler(Music_Play);
            pause.Show();
            _media.controls.pause();
            btnStop.Enabled = false;
            btnStop.Visible = false;
            btnLoad.Enabled = false;
            btnLoad.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnStop.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                if(_media == null)
                {
                    _media = new WindowsMediaPlayer();
                }
                _media.URL = ofd.FileName;
                _media.controls.play();

            }
        }
    }
}
