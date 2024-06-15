using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private string username;
        private Form parent;
        
        public Start(string username, Form parent)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.username = username;
            this.parent = parent;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            custom = new Custom(username, this);
            custom.Show();
            this.Visible = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}
