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
        Form grandParent;
        Form parent;
        public pause(WindowsMediaPlayer media,Form parent, Form grandParent)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; 
            this.FormBorderStyle = FormBorderStyle.None;
            _media = media;
            this.parent = parent;
            this.grandParent = grandParent;
            volume.Value = _media.settings.volume;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            _media.controls.play(); // 음악 재생
            Changed?.Invoke(this, EventArgs.Empty); // 이벤트 발생
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            parent.Close();
            this.Close();
            grandParent.Visible = true;
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
    }
}
