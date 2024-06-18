using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace oss_rythm
{


    public partial class Form1 : Form
    {
        private pause pauseForm;
        WindowsMediaPlayer _media;
        private Form parent;
        private Custom customForm;
        private Timer gameTimer = new Timer();
        private List<Panel> notes = new List<Panel>();
        private Dictionary<Panel, Tuple<long, long>> keyHoldStatus = new Dictionary<Panel, Tuple<long, long>>(); // 키가 눌린 시점과 떼어진 시점을 저장하는 Dictionary
        private Dictionary<Panel, bool> hitStatus = new Dictionary<Panel, bool>();
        private Dictionary<Panel, long> curTimenote = new Dictionary<Panel, long>();
        private ScoreBoard ScoreBoard;
        private string username;
        private long pauseTime;

        private int combo = 0;
        public int maxcombo = 0;
        private int mode;
        private int perfectCount = 0;
        private int goodCount = 0;
        private int badCount = 0;
        private int missCount = 0;
        private int totalBlocks = 0;

        private double bpm;
        private double targetTime;
        private int countTarget = 1;

        private long startTime;
        public double totalScore = 0.0; //총 점수 변수 추가
        private bool press1 = true;
        private bool press2 = true;
        private bool press3 = true;
        private bool press4 = true;
        string title;


        private Random random = new Random();
        private Dictionary<Panel, int> skipNext = new Dictionary<Panel, int>();
        // 효과음 재생을 위한 WindowsMediaPlayer
        private WindowsMediaPlayer effectSound;

        public Form1(WindowsMediaPlayer media, Form parent, double bpm, int mode, Custom customForm, string username, string title) // 변수 검토 예정
        {
            this.bpm = bpm;  // 추출한 bpm값 설정
            InitializeComponent();
            InitializeGame(); // 게임 초기화 메서드 호출
            InitializeUI(); // UI 초기화 메서드 호출
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.KeyPreview = true; // 키 입력을 폼에서 미리 처리하도록 설정
            _media = media;
            _media.PlayStateChange += new _WMPOCXEvents_PlayStateChangeEventHandler(Media_PlayStateChange);
            this.parent = parent;
            this.customForm = customForm; // +++
            this.username = username;
            this.title = title;

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;
            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;

            // Initialize skipNext dictionary for each bar
            skipNext[bar1] = 0;
            skipNext[bar2] = 0;
            skipNext[bar3] = 0;
            skipNext[bar4] = 0;

            curTimenote[bar1] = 0;
            curTimenote[bar2] = 0;
            curTimenote[bar3] = 0;
            curTimenote[bar4] = 0;
            // Initialize key hold status and hit status
            keyHoldStatus[bar1] = new Tuple<long, long>(0, 0);
            keyHoldStatus[bar2] = new Tuple<long, long>(0, 0);
            keyHoldStatus[bar3] = new Tuple<long, long>(0, 0);
            keyHoldStatus[bar4] = new Tuple<long, long>(0, 0);

            hitStatus[bar1] = false;
            hitStatus[bar2] = false;
            hitStatus[bar3] = false;
            hitStatus[bar4] = false;

            // Register KeyDown and KeyUp event handlers
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);
            this.mode = mode;
            //특수 효과음
            effectSound = new WindowsMediaPlayer();
            effectSound.settings.volume = 0;
            PlayKeyPressSound();
        }

        // 게임 초기화 메서드
        private void InitializeGame()
        {
            gameTimer.Interval = 1; // 높은 정밀도를 위해 1ms 간격 설정
            gameTimer.Tick += GameTimer_Tick; // 타이머 틱 이벤트 핸들러 추가
            targetTime = (60.0 / bpm) * 1000; // 목표 시간 계산 (밀리초 단위)
        }

        // UI 초기화 메서드
        private void InitializeUI()
        {
            // Register MouseDown and MouseUp event handlers for buttons
            btnQ.MouseDown += Btn_MouseDown;
            btnW.MouseDown += Btn_MouseDown;
            btnE.MouseDown += Btn_MouseDown;
            btnR.MouseDown += Btn_MouseDown;
            btnQ.MouseUp += Btn_MouseUp;
            btnW.MouseUp += Btn_MouseUp;
            btnE.MouseUp += Btn_MouseUp;
            btnR.MouseUp += Btn_MouseUp;

            // Initialize labels (폼 디자이너에서 이미 추가된 레이블 사용)
            UpdateScore();
            label2.Text = "";
            label4.Text = "MaxCombo:0";



            label3.Text = "0";
        }


        private void GameTimer_Tick(object sender, EventArgs e)
        {

            // 현재 시간(밀리초 단위)을 계산 -> 시작 시간(startTime)에서 현재 시간을 뺀 값을 밀리초 단위로 계산
            long curTime = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - startTime;

            // 목표 시간 대비 현재 시간의 비율을 계산
            double getTime = curTime / (targetTime * countTarget);

            long curTime2 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond; // 현재 시간을 밀리초 단위로 계산(블록과 비교를 위해)
            // 목표 시간에 도달했는지 확인하고 노트를 생성(bpm 단위로 생성)
            if ((int)getTime == 1)
            {
                CreateNotes(); // 노트 생성
                countTarget++; //// 목표 시간을 증가
            }
            // 모든 노트를 순회하며 위치를 업데이트하고 판정을 수행
            foreach (Panel note in notes.ToList())
            {
                note.Top += 5; // 노트의 위치를 아래로 이동
                Panel bar = note.Parent as Panel; // 노트의 부모 패널을 가져오기

                if (note.Parent == null) continue; //// 노트가 부모 패널을 가지고 있지 않다면 건너뜀



                // 노트의 상단이 패널의 하단을 지났고 키가 그 전에 눌러진 경우
                else if (note.Top > note.Parent.Height)
                {

                    long notePassTopTime = curTime; // 노트의 상단이 패널의 하단을 지난 시점
                    long keyDownTime = keyHoldStatus[bar].Item1; // 키가 눌린 시점
                    long keyUpTime = keyHoldStatus[bar].Item2; // 키가 떼어진 시점(0이면 키가 아직 안떼어진 것)

                    // 노트가 패널에 전부 지나가기 전에 키를 누른 경우
                    if (keyDownTime > 0)
                    {
                        double difference = Math.Abs(curTimenote[bar] - keyDownTime);

                        if (difference < 200)
                        {
                            perfectCount++;
                            combo++;
                            if (combo > maxcombo) maxcombo = combo;

                            label2.Text = "Perfect!";
                            label2.ForeColor = Color.Green;
                        }
                        else if (difference < 300)
                        {
                            goodCount++;
                            combo++;
                            if (combo > maxcombo) maxcombo = combo;

                            label2.Text = "Good!";
                            label2.ForeColor = Color.Blue;
                        }
                        else if (difference < 400)
                        {
                            badCount++;
                            combo++;

                            label2.Text = "Bad!";
                            label2.ForeColor = Color.Purple;
                        }
                        else
                        {
                            badCount++;
                            combo = 0;
                            label2.Text = "Miss!";
                            label2.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        missCount++;
                        combo = 0;
                        label2.Text = "Miss!";
                        label2.ForeColor = Color.Red;
                    }

                    // 콤보와 점수를 업데이트합니다.
                    // Label을 맨 앞에 보이게 설정
                    // label3.BringToFront();
                    label3.Text = "" + combo;
                    label4.Text = "MaxCombo:" + maxcombo;
                    UpdateScore();
                    notes.Remove(note);
                    note.Dispose();
                    curTimenote[bar] = 0;
                    // 해당 노트에 대한 판정이 끝났으므로 키 상태 초기화
                    keyHoldStatus[bar] = new Tuple<long, long>(0, 0);
                }


                // 노트의 하단이 패널의 하단을 지난 경우
                else if (note.Bottom > note.Parent.Height)
                {
                    curTimenote[bar] = curTime2; // 노트의 하단이 패널의 하단을 지난 시점
                }


            }
        }
        private void UpdateScore()
        {
            totalBlocks = perfectCount + goodCount + badCount + missCount;

            double perfectScore = perfectCount * 100.0 / totalBlocks;
            double goodScore = goodCount * 90.0 / totalBlocks;
            double badScore = badCount * 80.0 / totalBlocks;
            double missScore = missCount * 0.0 / totalBlocks;

            totalScore = perfectScore + goodScore + badScore + missScore;
            // totalScore를 소수점 둘째 자리까지 반올림하여 출력
            totalScore = Math.Round(totalScore, 2);
            if (totalBlocks == 0)
            {
                totalScore = 0;
            }
            // 소수점 둘째 자리까지 출력하도록 포맷팅
            //string formattedScore = totalScore.ToString("F2");
            label1.Text = $"Perfect: {perfectCount}\nGood: {goodCount}\nBad: {badCount}\nMiss: {missCount}\nScore: {totalScore}%\n";
        }
        private void HandleKeyPress(Keys key, bool isPressed, long curTime)
        {
            if (key == Keys.Q)
                btnQ.BackColor = isPressed ? Color.Green : Color.White;
            if (key == Keys.W)
                btnW.BackColor = isPressed ? Color.Green : Color.White;
            if (key == Keys.E)
                btnE.BackColor = isPressed ? Color.Green : Color.White;
            if (key == Keys.R)
                btnR.BackColor = isPressed ? Color.Green : Color.White;

            Panel targetBar = null;

            switch (key)
            {
                case Keys.Q:
                    targetBar = bar1;
                    break;
                case Keys.W:
                    targetBar = bar2;
                    break;
                case Keys.E:
                    targetBar = bar3;
                    break;
                case Keys.R:
                    targetBar = bar4;
                    break;
                default:
                    return;
            }

            if (isPressed)
            {
                keyHoldStatus[targetBar] = new Tuple<long, long>(curTime, keyHoldStatus[targetBar].Item2); // 키가 눌린 시점 기록
            }
            else
            {
                keyHoldStatus[targetBar] = new Tuple<long, long>(keyHoldStatus[targetBar].Item1, curTime); // 키가 떼어진 시점 기록
            }
        }
        // 각 bar에 노트를 생성하는 메서드
        private void CreateNotes()
        {
            int excludePanel = random.Next(1, 5);
            Set_Mode(bar1, excludePanel == 1, mode);
            Set_Mode(bar2, excludePanel == 2, mode);
            Set_Mode(bar3, excludePanel == 3, mode);
            Set_Mode(bar4, excludePanel == 4, mode);
        }

        private void CreateNoteInBar(Panel bar, int blockHeight, int blockType)
        {


            // 블록의 길이에 따른 색상 설정
            Color blockColor;
            switch (blockHeight)
            {
                case 20:
                    blockColor = Color.SandyBrown;
                    break;
                case 100:
                    blockColor = Color.SkyBlue;
                    break;
                case 200:
                    blockColor = Color.DarkSeaGreen;
                    break;
                case 620:
                    blockColor = Color.Purple;
                    break;
                default:
                    blockColor = Color.SandyBrown;
                    break;
            }

            Panel note = new Panel
            {
                Size = new Size(152, blockHeight),
                BackColor = blockColor, // 색상 설정
                Location = new Point(0, 0),
                Tag = blockType // 블록 타입을 태그로 저장
            };
            bar.Controls.Add(note);
            notes.Add(note);

            skipNext[bar] = blockType - 1;
            if (skipNext[bar] == 0)
                skipNext[bar] = 1;
        }
        //난이도에 맞춰 노드 생성 메서드 호출
        private void Set_Mode(Panel bar, bool exclude, int mode)
        {
            if (mode == 0)
            {
                if (!exclude || skipNext[bar] > 0)
                {
                    if (skipNext[bar] > 0)
                    {
                        skipNext[bar]--;
                    }
                    return;
                }

                int blockType = random.Next(1, 5);
                int blockHeight = blockType == 1 ? 30 : blockType == 2 ? 30 : blockType == 3 ? 30 : blockType == 4 ? 30 : 0;

                CreateNoteInBar(bar, blockHeight, blockType);
            }
            else if (mode == 1)
            {
                if (!exclude || skipNext[bar] > 0)
                {
                    if (skipNext[bar] > 0)
                    {
                        skipNext[bar]--;
                    }
                    return;
                }

                int blockType = random.Next(1, 5);
                int blockHeight = blockType == 1 ? 20 : blockType == 2 ? 100 : blockType == 3 ? 200 : blockType == 4 ? 20 : 0;

                CreateNoteInBar(bar, blockHeight, blockType);
            }
            else
            {
                if (exclude || skipNext[bar] > 0)
                {
                    if (skipNext[bar] > 0)
                    {
                        skipNext[bar]--;
                    }
                    return;
                }

                int blockType = random.Next(1, 5);
                int blockHeight = blockType == 1 ? 20 : blockType == 2 ? 100 : blockType == 3 ? 200 : blockType == 4 ? 620 : 0;

                CreateNoteInBar(bar, blockHeight, blockType);
            }
        }


        // 음악 재생 메서드
        private void PlayMusic()
        {
            _media.controls.play(); // 음악 재생
            startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond; // 시작 시간 기록
            gameTimer.Start(); // 게임 타이머 시작
        }

        private void Music_Play(object sender, EventArgs e)
        {
            startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond; // 시작 시간 재기록
            gameTimer.Start();
            _media.controls.play(); // 음악 재생
            btnStop.Enabled = true; // 스탑 버튼 활성화
            btnStop.Visible = true; // 스탑 버튼 보이기
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            gameTimer.Stop(); // 게임 타이머 중지
            _media.controls.pause(); // 음악 일시정지

            pauseTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond; // 일시정지 시점 기록

            pauseForm = new pause(_media, this, username);
            pauseForm.TopLevel = true;
            pauseForm.Changed += PauseForm_Changed;
            pauseForm.Show();
            pauseForm.BringToFront();
            pauseForm.TopMost = true;

            btnStop.Enabled = false; // Pause 버튼 비활성화
            btnStop.Visible = false; // Pause 버튼 숨기기
        }

        private void PauseForm_Changed(object sender, EventArgs e)
        {
            long resumeTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond; // 재개 시점 기록
            startTime += (resumeTime - pauseTime); // 일시정지된 시간만큼 startTime 조정
            _media.controls.play(); // 음악 재생
            gameTimer.Start(); // 게임 타이머 시작

            btnStop.Enabled = true; // Pause 버튼 다시 활성화
            btnStop.Visible = true; // Pause 버튼 다시 보이기

            if (customForm != null && !customForm.IsDisposed)
            {
                customForm.UpdateTotalScore(totalScore);
                customForm.UpdateCombo(maxcombo);
                customForm.SaveListBoxItems();
            }
        }

        private void UpdateLabels()
        {

            if (customForm != null && !customForm.IsDisposed)
            {
                customForm.UpdateTotalScore(totalScore);
                customForm.UpdateCombo(maxcombo);
                customForm.SaveListBoxItems();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnStop.BackgroundImageLayout = ImageLayout.Stretch;
            PlayMusic();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            effectSound.settings.volume = 50;

            //그라데이션 효과 추가
            if (e.KeyCode == Keys.Q)
            {
                if (press1 == true)
                {
                    ApplyGradientEffect(bar1);
                    press1 = false;
                }
            }
            if (e.KeyCode == Keys.W)
            {
                if (press2 == true)
                {
                    ApplyGradientEffect(bar2);
                    press2 = false;
                }
            }
            if (e.KeyCode == Keys.E)
            {
                if (press3 == true)
                {
                    ApplyGradientEffect(bar3);
                    press3 = false;
                }
            }
            if (e.KeyCode == Keys.R)
            {
                if (press4 == true)
                {
                    ApplyGradientEffect(bar4);
                    press4 = false;
                }
            }
            long curTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond; // 현재 시간을 밀리초 단위로 계산
            HandleKeyPress(e.KeyCode, true, curTime);
        }
        private void PlayKeyPressSound()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = "long_effect_g6_10min.wav"; // 상대 경로
            string fullPath = System.IO.Path.Combine(basePath, relativePath);
            effectSound.URL = fullPath;
            effectSound.controls.play();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            effectSound.settings.volume = 0;

            //그라데이션 효과 제거
            if (e.KeyCode == Keys.Q)
            {
                RemoveGradientEffect(bar1);
                press1 = true;
            }
            if (e.KeyCode == Keys.W)
            {
                RemoveGradientEffect(bar2);
                press2 = true;
            }
            if (e.KeyCode == Keys.E)
            {
                RemoveGradientEffect(bar3);
                press3 = true;
            }
            if (e.KeyCode == Keys.R)
            {
                RemoveGradientEffect(bar4);
                press4 = true;
            }
            long curTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond; // 현재 시간을 밀리초 단위로 계산
            HandleKeyPress(e.KeyCode, false, curTime);
        }

        //효과 추가 및 제거 코드
        private void ApplyGradientEffect(Panel bar)
        {
            bar.Paint += new PaintEventHandler(Bar_Paint);
            bar.Invalidate();
        }

        private void RemoveGradientEffect(Panel bar)
        {
            bar.Paint -= new PaintEventHandler(Bar_Paint);
            bar.BackColor = SystemColors.Control; // 기본 배경색으로 설정
            bar.Invalidate();
        }

        //그라데이션 설정
        private void Bar_Paint(object sender, PaintEventArgs e)
        {
            Panel bar = sender as Panel;
            if (bar != null)
            {
                LinearGradientBrush brush = new LinearGradientBrush(
                    //색칠할 영역 및 속성값 생성
                    new Rectangle(0, (int)(bar.Height * 0.8), bar.Width, (int)(bar.Height * 0.2)),
                    Color.Transparent,
                    Color.Green,
                    LinearGradientMode.Vertical);
                //색칠
                e.Graphics.FillRectangle(brush, new Rectangle(0, (int)(bar.Height * 0.8), bar.Width, (int)(bar.Height * 0.2)));
            }
        }


        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Green;
            Keys key = Keys.None;

            if (btn == btnQ) key = Keys.Q;
            else if (btn == btnW) key = Keys.W;
            else if (btn == btnE) key = Keys.E;
            else if (btn == btnR) key = Keys.R;
            long curTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond; // 현재 시간을 밀리초 단위로 계산
            HandleKeyPress(key, true, curTime);
        }

        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.White;
            Keys key = Keys.None;

            if (btn == btnQ) key = Keys.Q;
            else if (btn == btnW) key = Keys.W;
            else if (btn == btnE) key = Keys.E;
            else if (btn == btnR) key = Keys.R;
            long curTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond; // 현재 시간을 밀리초 단위로 계산
            HandleKeyPress(key, false, curTime);
        }

        private void Media_PlayStateChange(int NewState)
        {
            // 음악 재생 종료시
            if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                DataTable scores = DatabaseManager.GetMusicList(username);
                // Fetch all scores for the current song
                var songScores = scores.AsEnumerable();

                // Filter for the current song and order by score descending
                var scoreList = scores.AsEnumerable()
                    .Where(row => row.Field<string>("FileName") == _media.URL)
                    .OrderByDescending(row => row.Field<double>("Score"))
                    .ToList();

                // Calculate the rank of the current user
                int rank = scoreList.FindIndex(row => row.Field<string>("Username") == username) + 1;
                ScoreBoard = new ScoreBoard(this, totalScore, maxcombo, username, rank, title, bpm);
                ScoreBoard.Show();
                this.Close();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            // 아무 것도 하지 않음
        }


    }
}