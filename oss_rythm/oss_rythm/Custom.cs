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
        double bpm;
        Form1 form1;
        Form parent;
        private List<Button> btnList;
        private Dictionary<string, string> musicFiles; // 음악 파일의 경로를 저장하는 딕셔너리
        private bool isFileLoading = false; // 파일 로딩 여부를 확인하는 플래그
        public Custom(Form parent)
        {
            InitializeComponent();
            InitializeOpenFileDialog();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.parent = parent;
            btnList = new List<Button>()
            {
                btnEasy,btnNormal,btnHard,btnBack,btnLoad,
            };
            btn_UI();
            progressBar1.Value = 0;
            webBrowser1.ProgressChanged += new WebBrowserProgressChangedEventHandler(webBrowser1_ProgressChanged);
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted); // 웹 브라우저 로드 완료 이벤트 핸들러 등록
            musicFiles = new Dictionary<string, string>(); // 딕셔너리 초기화
            listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged); // 이벤트 핸들러 등록
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
            progressBar1.Value = 0;
            lblBpmInfo.Text = "Loading ...";
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
                
                // 제목을 listBox1에 추가하고 경로를 딕셔너리에 저장
                if (!musicFiles.ContainsKey(RefileName))
                {
                    listBox1.Items.Add(RefileName);
                    musicFiles[RefileName] = ofd.FileName;
                }

                isFileLoading = true; // 음악 파일 로딩 플래그 설정
                string url = "https://songdata.io/search?query=" + RefileName ;
                webBrowser1.Navigate(url);
            }
        }

        // listBox1에서 아이템을 선택했을 때
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedTitle = listBox1.SelectedItem.ToString();
                if (musicFiles.ContainsKey(selectedTitle))
                {
                    string filePath = musicFiles[selectedTitle];
                    LoadMusicFile(filePath, selectedTitle);
                }
            }
        }

        private void LoadMusicFile(string filePath, string title)
        {
           if (_media == null)
           {
               _media = new WindowsMediaPlayer();
           }
           _media.URL = filePath;
           _media.controls.stop();
           lblTitleInfo.Text = title;

           // 음악 파일 로딩 플래그 설정
           isFileLoading = true;
           string url = "https://songdata.io/search?query=" + title;
           webBrowser1.Navigate(url);

           BpmLoding.Text = "Loading ...";
           progressBar1.Value = 0;
            lblBpmInfo.Text = "Loading ...";
       }

        public void btn_UI()
        {
            foreach(Button btn in btnList)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
                btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
                btn.BackColor = Color.Transparent;
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
                    bpm = int.Parse(element.InnerText.Trim());
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
            form1 = new Form1(_media,parent,bpm);
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
            if (isFileLoading)
            {
                ExtractBpmValues();
                isFileLoading = false; // 로딩 플래그 리셋
            }
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
