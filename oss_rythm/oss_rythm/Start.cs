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
    public partial class Start : Form
    {

        private WindowsMediaPlayer _media;
        Custom custom;
        Option option;
        public Start()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            custom = new Custom(this);
            custom.Show();
            this.Visible = false;
        }
        private void btnOption_Click(object sender, EventArgs e)
        {
            option = new Option(this);
            option.Show();
            this.Visible = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
