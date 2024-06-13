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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



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
        private Form parent;
        private Custom customForm;
        private List<System.Windows.Forms.Button> btnList;
        private Dictionary<string, (string FilePath, double Bpm)> musicFiles; // 음악 파일의 경로를 저장하는 딕셔너리
        private bool isFileLoading = false; // 파일 로딩 여부를 확인하는 플래그
        private string username;
        private Start start;

        public Custom(string username, Form parent)
        {
            InitializeComponent();
            InitializeOpenFileDialog();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.username = username;
            this.parent = parent;
            btnList = new List<System.Windows.Forms.Button>()
            {
                btnEasy,btnNormal,btnHard,btnBack,btnLoad, btnDelete // ++ btnDelete 추가
            };
            btn_UI();
            progressBar1.Value = 0;
            webBrowser1.ProgressChanged += new WebBrowserProgressChangedEventHandler(webBrowser1_ProgressChanged);
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted); // 웹 브라우저 로드 완료 이벤트 핸들러 등록
            musicFiles = new Dictionary<string, (string FilePath, double Bpm)> (); // 딕셔너리 초기화
            listView1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged); // 이벤트 핸들러 등록

            LoadListBoxItems(); // ++ listBox1 항목 복원
            labelSelect.BackColor = Color.Transparent; // ++ 투명 배경 설정
        }

        public Custom(Start start)
        {
            this.start = start;
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
                    listView1.Items.Add(RefileName);
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
            if (listView1.SelectedItems != null)
            {
                string selectedTitle = listView1.SelectedItems.ToString();
                string titleOnly = selectedTitle.Split(new string[] { " (BPM: " }, StringSplitOptions.None)[0]; // ++ BPM 부분을 제외한 제목만 추출
                if (musicFiles.ContainsKey(titleOnly))
                {
                    string filePath = musicFiles[titleOnly].FilePath;
                    lblTitleInfo.Text = titleOnly;  // 타이틀 부분만 바로 추출 ++
                    // 선택된 항목에서 BPM 추출하여 lblBpmInfo에 즉시 설정 ++
                    var bpmMatch = Regex.Match(selectedTitle, @"\(BPM: (\d+(\.\d+)?)\)");
                    if (bpmMatch.Success)
                    {
                        if (_media == null)
                        {
                            _media = new WindowsMediaPlayer();
                        }
                        _media.URL = filePath;
                        _media.controls.stop();
                        lblBpmInfo.Text = bpmMatch.Groups[1].Value;
                        bpm = int.Parse(bpmMatch.Groups[1].Value);
                        progressBar1.Value = 100;
                        progressPercentage = 100; 
                        BpmLoding.Text = "BPM 추출 완료";
                    }
                    else
                    {
                        lblBpmInfo.Text = "0";
                        progressBar1.Value = 0;
                        progressPercentage = 0;
                        BpmLoding.Text = "...";
                    }
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
            foreach(System.Windows.Forms.Button btn in btnList)
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
                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.Text == title)
                    {
                        if (item.SubItems.Count > 1)
                        {
                            item.SubItems[1].Text = bpm.ToString(); // BPM 값 업데이트
                        }
                        else
                        {
                            item.SubItems.Add(bpm.ToString()); // SubItem이 부족한 경우 추가
                        }
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
            form1 = new Form1(_media, this, bpm, mode, this);
            form1.Show();
            SaveListBoxItems(); // ++ listBox1의 항목을 저장
            _media.controls.play();
            this.Hide(); // Hide instead of close
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            parent.Visible = true;
            SaveListBoxItems(); // ++ listBox1의 항목을 저장
            this.Hide(); // Hide instead of close
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
        public void SaveListBoxItems()
        {
            foreach (ListViewItem item in listView1.Items)
            {
                DatabaseManager.AddOrUpdateMusicList(
                    username,
                    item.SubItems[0].Text,
                    item.SubItems[1].Text,
                    item.SubItems[2].Text,
                    item.SubItems[3].Text,
                    item.SubItems[4].Text
                );
            }
        }

        private void LoadListBoxItems()
        {
            listView1.Items.Clear();
            DataTable table = DatabaseManager.GetMusicList(username);

            // If the table is empty, skip adding items
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    ListViewItem item = new ListViewItem(new[] {
                        row["FileName"].ToString(),
                        row["BPM"].ToString(),
                        row["Score"].ToString(),
                        row["Combo"].ToString(),
                        row["Difficulty"].ToString()
                    });
                    listView1.Items.Add(item);
                }
            }
        }

        private void Custom_Load(object sender, EventArgs e)
        {

        }

        // ++
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0]; // 첫 번째 선택된 항목 가져오기
                string selectedTitle = selectedItem.Text; // 항목의 텍스트 (파일명) 가져오기
                listView1.Items.Remove(selectedItem);
                if (musicFiles.ContainsKey(selectedTitle))
                {
                    musicFiles.Remove(selectedTitle);
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
        // 난이도 업데이트 메서드
        private void UpdateDifficulty(string difficulty)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                if (selectedItem.SubItems.Count > 4)
                {
                    selectedItem.SubItems[4].Text = difficulty; // 기존 항목 업데이트
                }
                else
                {
                    while (selectedItem.SubItems.Count <= 4) // 필요한 만큼 SubItem 추가
                    {
                        selectedItem.SubItems.Add("");
                    }
                    selectedItem.SubItems[4].Text = difficulty; // 새 항목 설정
                }
            }
            else
            {
                MessageBox.Show("난이도를 설정할 항목을 선택하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // 최대 콤보와 총 점수를 업데이트하는 메서드 추가
        public void UpdateListViewWithGameResults(int combo, double totalScore)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                selectedItem.SubItems[2].Text = totalScore.ToString();
                selectedItem.SubItems[3].Text = combo.ToString();
            }
            else
            {
                MessageBox.Show("Please select an item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            UpdateDifficulty("Easy");
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            mode = 1;
            UpdateDifficulty("Normal");
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            mode = 2;
            UpdateDifficulty("Hard");
        }
    }
}
