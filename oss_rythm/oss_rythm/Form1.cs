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
        Form parent;
        public Form1(WindowsMediaPlayer media,Form parent)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            _media = media;
            this.parent = parent;
        }


        private void Music_Play(object sender,EventArgs e)
        {
            _media.controls.play();
            btnStop.Enabled = true;
            btnStop.Visible = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            pause = new pause(_media,this,parent);
            pause.TopLevel = true;
            pause.MdiParent = this;
            pause.Changed += new EventHandler(Music_Play);
            pause.Show();
            _media.controls.pause();
            btnStop.Enabled = false;
            btnStop.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnStop.BackgroundImageLayout = ImageLayout.Stretch;
            int mash;
        }

    }
}
