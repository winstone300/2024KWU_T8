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
        Custom custom;
        Start start;
        Login login;
        Form parent;
        string username;
        private List<System.Windows.Forms.Button> btnList; // 버튼 리스트

        public pause(WindowsMediaPlayer media,Form parent,string username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; 
            this.FormBorderStyle = FormBorderStyle.None;
            _media = media;
            this.parent = parent;
            volume.Value = _media.settings.volume;
            this.username = username;
            btnList = new List<System.Windows.Forms.Button>()
            {
                btnContinue, btnExit
            };
            btn_UI(); // 버튼 UI 설정
        }

        public void btn_UI()
        {
            foreach (System.Windows.Forms.Button btn in btnList)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
                btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
                btn.BackColor = Color.Transparent;
                btn.MouseEnter += Button_MouseEnter;
                btn.MouseLeave += Button_MouseLeave;
            }
        }
        // 버튼 마우스 오버 이벤트 핸들러
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        // 버튼 마우스 리브 이벤트 핸들러
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        private void btnContinue_Click(object sender, EventArgs e)
        {
            btnContinue.BackColor = Color.Transparent;
            _media.controls.play(); // 음악 재생
            Changed?.Invoke(this, EventArgs.Empty); // 이벤트 발생
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Transparent;
            parent.Close();
            this.Close();
            login = new Login();
            start = new Start(username,login);
            custom = new Custom(username,start);
            custom.Show();
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
