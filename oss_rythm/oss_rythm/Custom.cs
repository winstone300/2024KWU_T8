using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Text.RegularExpressions;
using System.Xml;

namespace oss_rythm
{
    public partial class Custom : Form
    {
        private WindowsMediaPlayer _media;
        int progressPercentage;
        Form1 form1;
        Form parent;
        public Custom(Form parent)
        {
            InitializeComponent();
            InitializeOpenFileDialog();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.parent = parent;
            progressBar1.Value = 0;
            webBrowser1.ProgressChanged += new WebBrowserProgressChangedEventHandler(webBrowser1_ProgressChanged);
        }
        private void InitializeOpenFileDialog()
        {
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Filter = "MP3 (*.mp3)|*.mp3|모든파일 (*.*)|*.*";
            ofd.FileName = "";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            BpmLoding.Text = "Loading ...";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (_media == null)
                {
                    _media = new WindowsMediaPlayer();
                }
                _media.URL = ofd.FileName;
                _media.controls.stop();
                string fileName = Path.GetFileName(ofd.FileName);
                string pattern = @"^(.+)\.[^.]+$";
                string RefileName = Regex.Replace(fileName, pattern, "$1");
                lblTitleInfo.Text = RefileName;
                string url = "https://songdata.io/search?query=" + RefileName ;
                webBrowser1.Navigate(url);
            }
        }

        //bpm 태그 추출
        private void ExtractBpmValues()
        {
            HtmlElementCollection elements = webBrowser1.Document.GetElementsByTagName("td");
            foreach (HtmlElement element in elements)
            {
                if (element.GetAttribute("className") == "table_bpm")
                {
                    lblBpmInfo.Text = element.InnerText.Trim();
                    return;
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if(_media == null)
            {
                MessageBox.Show("음악을 선택해 주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (progressPercentage == 0)
            {
                MessageBox.Show("BPM 추출 중입니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            form1 = new Form1(_media,parent);
            form1.Show();
            _media.controls.play();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            parent.Visible = true;
            this.Close();
        }

        //웹브라우저 로딩 완료시 실행
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ExtractBpmValues();
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.MaximumProgress > 0 && e.CurrentProgress > 0)
            {
                progressPercentage = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
                progressBar1.Value = progressPercentage;
                if (progressPercentage == 100)
                {
                    BpmLoding.Text = "BPM 추출 완료";
                }
            }
        }

        private void Custom_Load(object sender, EventArgs e)
        {

        }
    }
}
