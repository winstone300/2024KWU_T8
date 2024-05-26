using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        pause pause;
        WindowsMediaPlayer _media;
        Form parent;
        private Timer gameTimer = new Timer();
        private List<Panel> notes = new List<Panel>();
        private Dictionary<Panel, bool> keyHoldStatus = new Dictionary<Panel, bool>();
        private Dictionary<Panel, bool> hitStatus = new Dictionary<Panel, bool>();

        private int combo = 0;
        private int mode;
        private int perfectCount = 0;
        private int goodCount = 0;
        private int badCount = 0;
        private double bpm;
        private double targetTime;
        private int countTarget = 1;
        private long startTime;
        private double totalScore = 0.0; // 총 점수 변수 추가

        private Random random = new Random();
        private Dictionary<Panel, int> skipNext = new Dictionary<Panel, int>();
        // 효과음 재생을 위한 WindowsMediaPlayer
        private WindowsMediaPlayer effectSound; 

        public Form1(WindowsMediaPlayer media, Form parent,double bpm, int mode)
        {
            this.bpm = bpm;  // 추출한 bpm값 설정
            InitializeComponent();
            InitializeGame(); // 게임 초기화 메서드 호출
            InitializeUI(); // UI 초기화 메서드 호출
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.KeyPreview = true; // 키 입력을 폼에서 미리 처리하도록 설정
            _media = media;
            this.parent = parent;

            // Initialize skipNext dictionary for each bar
            skipNext[bar1] = 0;
            skipNext[bar2] = 0;
            skipNext[bar3] = 0;
            skipNext[bar4] = 0;

            // Initialize key hold status and hit status
            keyHoldStatus[bar1] = false;
            keyHoldStatus[bar2] = false;
            keyHoldStatus[bar3] = false;
            keyHoldStatus[bar4] = false;

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
            label1.Text = "Combo: 0";
            label2.Text = "Score: 0.0";
        }

        // 게임 타이머 틱 이벤트 핸들러
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            long curTime = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - startTime; // 현재 시간을 밀리초 단위로 계산
            double getTime = curTime / (targetTime * countTarget); // 목표 시간 대비 현재 시간의 비율 계산

            if ((int)getTime == 1)
            {
                CreateNotes(); // 노트 생성
                countTarget++;
            }

            // 노트 이동 로직
            foreach (Panel note in notes.ToList())
            {
                note.Top += 5; // 노트의 위치를 아래로 이동
                if (note.Top > note.Parent.Height)
                {
                    if (note.Height > 0)
                    {
                        // 패널 끝에 도달한 긴 블록이 서서히 사라지도록
                        note.Height -= 5;
                    }
                    else
                    {
                        // 긴 블록이 사라지면서 점수 판정
                        Panel bar = note.Parent as Panel;
                        if (keyHoldStatus[bar])
                        {
                            double noteTime = curTime - ((this.ClientSize.Height - note.Bottom) / 5.0) * (targetTime / 200.0); // 노트 하단이 패널 끝을 통과할 때의 시간 계산
                            double difference = Math.Abs(curTime - noteTime); // 현재 시간과 노트 통과 시간의 차이 계산

                            if (difference < 100)
                            {
                                perfectCount++;
                                combo++;
                                totalScore += 1.0;
                                label2.Text = "Perfect!"; // Perfect 판정
                                label2.ForeColor = Color.Green;
                            }
                            else if (difference < 200)
                            {
                                goodCount++;
                                combo++;
                                totalScore += 0.5;
                                label2.Text = "Good!"; // Good 판정
                                label2.ForeColor = Color.Blue;
                            }
                            else
                            {
                                badCount++;
                                combo = 0;
                                label2.Text = "Bad!"; // Bad 판정
                                label2.ForeColor = Color.Red;
                            }
                        }
                        else
                        {
                            badCount++;
                            combo = 0;
                            label2.Text = "Miss!"; // Miss 판정
                            label2.ForeColor = Color.Red;
                        }
                        label1.Text = "Combo: " + combo + "\nScore: " + totalScore; // 콤보와 점수 업데이트

                        notes.Remove(note); // 리스트에서 노트 제거
                        note.Dispose(); // 노트 자원 해제
                    }
                }
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

        // 특정 bar에 노트를 생성하는 메서드
        private void CreateNoteInBar(Panel bar,int blockHeight,int blockType)
        {
            Panel note = new Panel
            {
                Size = new Size(152, blockHeight),
                BackColor = Color.Blue,
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
        private void Set_Mode(Panel bar, bool exclude,int mode)
        {
            if(mode == 0)
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

                CreateNoteInBar (bar,blockHeight,blockType);
            }
            else if(mode == 1)
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
                int blockHeight = blockType == 1 ? 20 : blockType == 2 ? 60 : blockType == 3 ? 100 : blockType == 4 ? 20 : 0;

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
                int blockHeight = blockType == 1 ? 20 : blockType == 2 ? 60 : blockType == 3 ? 100 : blockType == 4 ? 120 : 0;

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
            pause = new pause(_media, this, parent);
            pause.TopLevel = true;
            pause.Changed += new EventHandler(Music_Play); // Changed 이벤트 핸들러 추가
            pause.Show();
            pause.BringToFront(); // pause 창을 최상단으로 이동
            pause.TopMost = true; // pause 창을 최상단에 유지
            _media.controls.pause();
            btnStop.Enabled = false;
            btnStop.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnStop.BackgroundImageLayout = ImageLayout.Stretch;
            PlayMusic();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyPress(e.KeyCode, true);
            effectSound.settings.volume = 20;
        }
        private void PlayKeyPressSound()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = "long_effect_g6_10min.wav"; // 상대 경로
            string fullPath = System.IO.Path.Combine(basePath, relativePath);
            effectSound.URL = fullPath;
        }



        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            HandleKeyPress(e.KeyCode, false);
            effectSound.settings.volume = 0;
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

            HandleKeyPress(key, true);
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

            HandleKeyPress(key, false);
        }
        // 키 입력 처리 메서드
        private void HandleKeyPress(Keys key, bool isPressed)
        {
            // 키 누름/해제 시 버튼 색상 변경
            if (key == Keys.Q)
                btnQ.BackColor = isPressed ? Color.Green : Color.White;
            if (key == Keys.W)
                btnW.BackColor = isPressed ? Color.Green : Color.White;
            if (key == Keys.E)
                btnE.BackColor = isPressed ? Color.Green : Color.White;
            if (key == Keys.R)
                btnR.BackColor = isPressed ? Color.Green : Color.White;

            long curTime = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - startTime; // 현재 시간을 밀리초 단위로 계산
            Panel targetBar = null;
            int blockType = 0;

            // 키에 해당하는 타겟 바 설정
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

            keyHoldStatus[targetBar] = isPressed; // 키 상태 업데이트

            if (isPressed)
            {
                foreach (Panel note in notes.ToList())
                {
                    blockType = (int)note.Tag;

                    // 노트가 타겟 바에 있고, 패널 끝에 가까워졌을 때
                    if (note.Parent == targetBar && note.Bottom >= this.ClientSize.Height - 10 && note.Top <= this.ClientSize.Height)
                    {
                        if (blockType > 1)
                        {
                            if (curTime - startTime <= targetTime * blockType)
                            {
                                label2.Text = "Holding..."; // 긴 노트의 경우
                                label2.ForeColor = Color.Orange;
                                return;
                            }
                        }
                        else
                        {
                            double noteTime = curTime - ((this.ClientSize.Height - note.Bottom) / 5.0) * (targetTime / 200.0); // 노트 하단이 패널 끝을 통과할 때의 시간 계산
                            double difference = Math.Abs(curTime - noteTime); // 현재 시간과 노트 통과 시간의 차이 계산

                            if (difference < 100)
                            {
                                hitStatus[targetBar] = true;
                                perfectCount++;
                                combo++;
                                totalScore += 1.0;
                                label2.Text = "Perfect!"; // Perfect 판정
                                label2.ForeColor = Color.Green;
                            }
                            else if (difference < 200)
                            {
                                hitStatus[targetBar] = true;
                                goodCount++;
                                combo++;
                                totalScore += 0.5;
                                label2.Text = "Good!"; // Good 판정
                                label2.ForeColor = Color.Blue;
                            }
                            else
                            {
                                badCount++;
                                combo = 0;
                                label2.Text = "Bad!"; // Bad 판정
                                label2.ForeColor = Color.Red;
                            }

                            label1.Text = "Combo: " + combo + "\nScore: " + totalScore; // 콤보와 점수 업데이트
                            notes.Remove(note); // 리스트에서 노트 제거
                            note.Dispose(); // 노트 자원 해제
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (Panel note in notes.ToList())
                {
                    // 노트가 타겟 바에 있고, 패널 끝에 가까워졌을 때
                    if (note.Parent == targetBar && note.Bottom >= this.ClientSize.Height - 10 && note.Top <= this.ClientSize.Height)
                    {
                        double noteTime = curTime - ((this.ClientSize.Height - note.Bottom) / 5.0) * (targetTime / 200.0); // 노트 하단이 패널 끝을 통과할 때의 시간 계산
                        double difference = Math.Abs(curTime - noteTime); // 현재 시간과 노트 통과 시간의 차이 계산

                        if (difference < 100)
                        {
                            if (!hitStatus[targetBar])
                            {
                                perfectCount++;
                                combo++;
                                totalScore += 1.0;
                                label2.Text = "Perfect!"; // Perfect 판정
                                label2.ForeColor = Color.Green;
                            }
                        }
                        else if (difference < 200)
                        {
                            if (!hitStatus[targetBar])
                            {
                                goodCount++;
                                combo++;
                                totalScore += 0.5;
                                label2.Text = "Good!"; // Good 판정
                                label2.ForeColor = Color.Blue;
                            }
                        }
                        else
                        {
                            badCount++;
                            combo = 0;
                            label2.Text = "Bad!"; // Bad 판정
                            label2.ForeColor = Color.Red;
                        }

                        label1.Text = "Combo: " + combo + "\nScore: " + totalScore; // 콤보와 점수 업데이트
                        notes.Remove(note); // 리스트에서 노트 제거
                        note.Dispose(); // 노트 자원 해제
                        break;
                    }
                }
                hitStatus[targetBar] = false; // 다음 노트를 위해 hit 상태 초기화
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // 아무 것도 하지 않음
        }
    }
}
