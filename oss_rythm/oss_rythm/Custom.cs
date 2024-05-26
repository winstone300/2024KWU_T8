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
        //Team 8
        private WindowsMediaPlayer _media;
        int progressPercentage;
        int mode = 1;
        double bpm;
        Form1 form1;
        Form parent;
        private List<Button> btnList;
        private Dictionary<string, (string FilePath, double Bpm)> musicFiles; // 음악 파일의 경로를 저장하는 딕셔너리
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
                btnEasy,btnNormal,btnHard,btnBack,btnLoad, btnDelete // ++ btnDelete 추가
            };
            btn_UI();
            progressBar1.Value = 0;
            webBrowser1.ProgressChanged += new WebBrowserProgressChangedEventHandler(webBrowser1_ProgressChanged);
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted); // 웹 브라우저 로드 완료 이벤트 핸들러 등록
            musicFiles = new Dictionary<string, (string FilePath, double Bpm)> (); // 딕셔너리 초기화
            listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged); // 이벤트 핸들러 등록

            LoadListBoxItems(); // ++ listBox1 항목 복원
            labelSelect.BackColor = Color.Transparent; // ++ 투명 배경 설정
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
                    musicFiles[RefileName] = (ofd.FileName, 0.0); // ++ 초기 BPM 값은 0.0으로 설정
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
                string titleOnly = selectedTitle.Split(new string[] { " (BPM: " }, StringSplitOptions.None)[0]; // ++ BPM 부분을 제외한 제목만 추출
                if (musicFiles.ContainsKey(titleOnly))
                {
                    string filePath = musicFiles[titleOnly].FilePath;
                    LoadMusicFile(filePath, titleOnly);
                }
            }
            else // ++
            {
                // ++ 아이템이 선택되지 않았을 때 레이블 텍스트 초기화
                lblTitleInfo.Text = " ";
                lblScoreInfo.Text = " ";
                lblBpmInfo.Text = " ";
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

        //버튼 배경 투명하게 & 마우스 올릴시 클릭 화면
        public void btn_UI()
        {
            foreach(Button btn in btnList)
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
                    UpdateListBoxWithBpm(lblTitleInfo.Text, bpm); // ++ BPM 값을 업데이트
                    return;
                }
            }
        }
        // ++
        private void UpdateListBoxWithBpm(string title, double bpm)
        {
            // 음악 파일 정보 업데이트
            if (musicFiles.ContainsKey(title))
            {
                musicFiles[title] = (musicFiles[title].FilePath, bpm);

                // listBox1 항목 업데이트
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    string item = listBox1.Items[i].ToString();
                    string titleOnly = item.Split(new string[] { " (BPM: " }, StringSplitOptions.None)[0];
                    if (titleOnly == title)
                    {
                        listBox1.Items[i] = $"{title} (BPM: {bpm})";
                        break;
                    }
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
            form1 = new Form1(_media,parent,bpm,mode);
            form1.Show();
            SaveListBoxItems(); // ++ listBox1의 항목을 저장
            _media.controls.play();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            parent.Visible = true;
            SaveListBoxItems(); // ++ listBox1의 항목을 저장
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
        // ++ listBox1의 항목을 저장하는 메서드
        private void SaveListBoxItems()
        {
            var savedItems = new List<string>();
            foreach (var item in listBox1.Items)
            {
                savedItems.Add(item.ToString());
            }

            Properties.Settings.Default.SavedListBoxItems = string.Join(";", savedItems);
            Properties.Settings.Default.SavedMusicFiles = string.Join(";", musicFiles.Select(kvp => $"{kvp.Key}|{kvp.Value.FilePath}|{kvp.Value.Bpm}")); // ++
            Properties.Settings.Default.Save();
        }

        private void LoadListBoxItems()
        {
            var savedItems = Properties.Settings.Default.SavedListBoxItems;
            if (!string.IsNullOrEmpty(savedItems))
            {
                var items = savedItems.Split(';');
                listBox1.Items.AddRange(items);
            }

            var savedMusicFiles = Properties.Settings.Default.SavedMusicFiles;
            if (!string.IsNullOrEmpty(savedMusicFiles))
            {
                var items = savedMusicFiles.Split(';');
                foreach (var item in items)
                {
                    var kvp = item.Split('|');
                    if (kvp.Length == 3 && double.TryParse(kvp[2], out double bpm)) // ++
                    {
                        musicFiles[kvp[0]] = (kvp[1], bpm);
                    }
                }
            }
        }
        private void Custom_Load(object sender, EventArgs e)
        {

        }

        // ++
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedTitle = listBox1.SelectedItem.ToString();
                string titleOnly = selectedTitle.Split(new string[] { " (BPM: " }, StringSplitOptions.None)[0]; // ++ BPM 부분을 제외한 제목만 추출
                listBox1.Items.Remove(selectedTitle);
                if (musicFiles.ContainsKey(titleOnly))
                {
                    musicFiles.Remove(titleOnly);
                }

                // 변경된 항목을 저장
                SaveListBoxItems();

                // 레이블 텍스트 초기화
                lblTitleInfo.Text = " ";
                lblScoreInfo.Text = " ";
                lblBpmInfo.Text = " ";
            }
            else
            {
                MessageBox.Show("삭제할 항목을 선택하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        //난이도 (easy:0 , normal:1 , hard:2)
        private void btnEasy_Click(object sender, EventArgs e)
        {
            mode = 0;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            mode = 1;
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            mode = 2;
        }
    }
}
