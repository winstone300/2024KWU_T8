using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WMPLib;

namespace oss_rythm
{
    public partial class Custom : Form
    {
        private WindowsMediaPlayer _media; // 음악 재생을 위한 미디어 플레이어
        int progressPercentage; // 진행률 퍼센티지
        int mode = 1; // 게임 모드 (0: Easy, 1: Normal, 2: Hard)
        double bpm; // BPM 값
        Form1 form1; // Form1 객체
        private Form parent; // 부모 폼
        private Custom customForm; // Custom 폼 객체
        private List<System.Windows.Forms.Button> btnList; // 버튼 리스트
        private Dictionary<string, (string FilePath, double Bpm)> musicFiles; // 음악 파일 경로와 BPM을 저장하는 딕셔너리
        private bool isFileLoading = false; // 파일 로딩 중인지 확인하는 플래그
        private string username; // 사용자 이름

        // Custom 생성자
        public Custom(string username, Form parent)
        {
            InitializeComponent();
            InitializeOpenFileDialog();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.username = username;
            this.parent = parent ?? throw new ArgumentNullException(nameof(parent), "Parent form cannot be null");
            btnList = new List<System.Windows.Forms.Button>()
            {
                btnEasy, btnNormal, btnHard, btnBack, btnLoad, btnDelete
            };
            btn_UI(); // 버튼 UI 설정
            progressBar1.Value = 0; // 진행률 초기화
            webBrowser1.ProgressChanged += webBrowser1_ProgressChanged;
            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
            musicFiles = new Dictionary<string, (string FilePath, double Bpm)>();
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;

            LoadListBoxItems(); // 저장된 음악 파일 목록 로드
            labelSelect.BackColor = Color.Transparent; // 레이블 배경 투명 설정
        }

        // OpenFileDialog 초기 설정
        private void InitializeOpenFileDialog()
        {
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Filter = "MP3 (*.mp3)|*.mp3|모든파일 (*.*)|*.*";
            ofd.FileName = "";
        }

        // Load 버튼 클릭 이벤트 핸들러
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

                if (!musicFiles.ContainsKey(RefileName))
                {
                    listView1.Items.Add(RefileName);
                    musicFiles[RefileName] = (ofd.FileName, 0.0);
                }

                isFileLoading = true; // 파일 로딩 플래그 설정
                string url = "https://songdata.io/search?query=" + RefileName;
                webBrowser1.Navigate(url);
            }
        }

        // ListView 항목 선택 변경 이벤트 핸들러
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null && listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                lblTitleInfo.Text = selectedItem.SubItems[0].Text;
                lblScoreInfo.Text = selectedItem.SubItems.Count > 2 && !string.IsNullOrEmpty(selectedItem.SubItems[2].Text) ? selectedItem.SubItems[2].Text : "0";
                lblBpmInfo.Text = selectedItem.SubItems.Count > 1 && !string.IsNullOrEmpty(selectedItem.SubItems[1].Text) ? selectedItem.SubItems[1].Text : "N/A";
                string titleOnly = selectedItem.Text.Split(new string[] { " (BPM: " }, StringSplitOptions.None)[0];
                if (musicFiles.ContainsKey(titleOnly))
                {
                    string filePath = musicFiles[titleOnly].FilePath;
                    if (_media == null)
                    {
                        _media = new WindowsMediaPlayer();
                    }
                    _media.URL = filePath;
                    _media.controls.stop();

                    if (musicFiles[titleOnly].Bpm > 0)
                    {
                        bpm = musicFiles[titleOnly].Bpm;
                        lblBpmInfo.Text = bpm.ToString();
                        progressBar1.Value = 100;
                        progressPercentage = 100;
                        BpmLoding.Text = "BPM 추출 완료";
                    }
                    else
                    {
                        var bpmMatch = Regex.Match(selectedItem.Text, @"\(BPM: (\d+(\.\d+)?)\)");
                        if (bpmMatch.Success)
                        {
                            lblBpmInfo.Text = bpmMatch.Groups[1].Value;
                            bpm = double.Parse(bpmMatch.Groups[1].Value);
                            progressBar1.Value = 100;
                            progressPercentage = 100;
                            BpmLoding.Text = "BPM 추출 완료";
                        }
                        else
                        {
                            BpmLoding.Text = "BPM 추출 중...";
                        }
                    }
                }
            }
            else
            {
                lblTitleInfo.Text = " ";
                lblScoreInfo.Text = " ";
                lblBpmInfo.Text = " ";
            }
        }

        // 음악 파일 목록 저장
        private void SaveMusicFiles()
        {
            string saveFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "musicFiles.txt");
            using (StreamWriter writer = new StreamWriter(saveFilePath))
            {
                foreach (var entry in musicFiles)
                {
                    writer.WriteLine($"{entry.Key}|{entry.Value.FilePath}|{entry.Value.Bpm}");
                }
            }
        }

        // 음악 파일 목록 로드
        private void LoadMusicFiles()
        {
            string loadFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "musicFiles.txt");
            if (File.Exists(loadFilePath))
            {
                using (StreamReader reader = new StreamReader(loadFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('|');
                        if (parts.Length == 3)
                        {
                            string title = parts[0];
                            string filePath = parts[1];
                            double bpm = double.Parse(parts[2]);
                            musicFiles[title] = (filePath, bpm);
                            listView1.Items.Add(new ListViewItem(new[] { title, bpm.ToString() }));
                        }
                    }
                }
            }
        }

        // 버튼 UI 설정
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

        // BPM 값 추출
        private void ExtractBpmValues()
        {
            HtmlElementCollection elements = webBrowser1.Document.GetElementsByTagName("td");
            foreach (HtmlElement element in elements)
            {
                if (element.GetAttribute("className") == "table_bpm")
                {
                    bpm = double.Parse(element.InnerText.Trim());
                    lblBpmInfo.Text = element.InnerText.Trim();
                    UpdateListBoxWithBpm(lblTitleInfo.Text, bpm);
                    return;
                }
            }
        }

        // ListBox의 BPM 업데이트
        private void UpdateListBoxWithBpm(string title, double bpm)
        {
            if (musicFiles.ContainsKey(title))
            {
                musicFiles[title] = (musicFiles[title].FilePath, bpm);

                foreach (ListViewItem item in listView1.Items)
                {
                    if (item.Text == title)
                    {
                        if (item.SubItems.Count > 1)
                        {
                            item.SubItems[1].Text = bpm.ToString();
                        }
                        else
                        {
                            item.SubItems.Add(bpm.ToString());
                        }
                        break;
                    }
                }
            }
        }

        // Play 버튼 클릭 이벤트 핸들러
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (_media == null)
            {
                MessageBox.Show("음악을 선택해 주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (progressPercentage == 0 && bpm == 0)
            {
                MessageBox.Show("BPM 추출 중입니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            form1 = new Form1(_media, this, bpm, mode, this);
            form1.Show();
            SaveListBoxItems();
            _media.controls.play();
            this.Hide();
        }

        // Back 버튼 클릭 이벤트 핸들러
        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                SaveListBoxItems();
                this.Hide();
                if (parent != null && !parent.IsDisposed)
                {
                    parent.Show();
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show($"ArgumentOutOfRangeException: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 웹브라우저 문서 로드 완료 이벤트 핸들러
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (isFileLoading)
            {
                ExtractBpmValues();
                isFileLoading = false;
            }
        }

        // 웹브라우저 진행률 변경 이벤트 핸들러
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

        // ListBox 항목 저장
        public void SaveListBoxItems()
        {
            SaveMusicFiles();
        }

        // ListBox 항목 로드
        private void LoadListBoxItems()
        {
            listView1.Items.Clear();
            LoadMusicFiles();
        }

        // 폼 로드 이벤트 핸들러
        private void Custom_Load(object sender, EventArgs e)
        {
        }

        // Delete 버튼 클릭 이벤트 핸들러
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null && listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string selectedTitle = selectedItem.Text;
                listView1.Items.Remove(selectedItem);

                if (musicFiles.ContainsKey(selectedTitle))
                {
                    musicFiles.Remove(selectedTitle);
                }

                SaveListBoxItems();

                lblTitleInfo.Text = " ";
                lblScoreInfo.Text = " ";
                lblBpmInfo.Text = " ";
            }
            else
            {
                MessageBox.Show("삭제할 항목을 선택하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 난이도 업데이트
        private void UpdateDifficulty(string difficulty)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                if (selectedItem.SubItems.Count > 4)
                {
                    selectedItem.SubItems[4].Text = difficulty;
                }
                else
                {
                    while (selectedItem.SubItems.Count <= 4)
                    {
                        selectedItem.SubItems.Add("");
                    }
                    selectedItem.SubItems[4].Text = difficulty;
                }
            }
            else
            {
                MessageBox.Show("난이도를 설정할 항목을 선택하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 게임 결과 업데이트 메서드 (점수와 콤보를 변경할 때)
        public void UpdateListViewWithGameResults(int combo, double totalScore)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                if (selectedItem.SubItems.Count > 2)
                {
                    selectedItem.SubItems[2].Text = totalScore.ToString();
                }
                else
                {
                    while (selectedItem.SubItems.Count <= 2)
                    {
                        selectedItem.SubItems.Add("");
                    }
                    selectedItem.SubItems[2].Text = totalScore.ToString();
                }

                if (selectedItem.SubItems.Count > 3)
                {
                    selectedItem.SubItems[3].Text = combo.ToString();
                }
                else
                {
                    while (selectedItem.SubItems.Count <= 3)
                    {
                        selectedItem.SubItems.Add("");
                    }
                    selectedItem.SubItems[3].Text = combo.ToString();
                }
            }
            else
            {
                MessageBox.Show("Please select an item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        // Easy 버튼 클릭 이벤트 핸들러
        private void btnEasy_Click(object sender, EventArgs e)
        {
            mode = 0;
            UpdateDifficulty("Easy");
        }

        // Normal 버튼 클릭 이벤트 핸들러
        private void btnNormal_Click(object sender, EventArgs e)
        {
            mode = 1;
            UpdateDifficulty("Normal");
        }

        // Hard 버튼 클릭 이벤트 핸들러
        private void btnHard_Click(object sender, EventArgs e)
        {
            mode = 2;
            UpdateDifficulty("Hard");
        }
    }
}
