using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;

namespace oss_rythm
{
    public partial class Form1 : Form
    {
        pause pause;
        WindowsMediaPlayer _media;
        Form parent;
        // 게임 타이머 추가
        private Timer gameTimer = new Timer();
        private List<Panel> notes = new List<Panel>(); // 활성 노트를 추적하는 리스트
        
        private int combo = 0; // 콤보 초기값
        private int perfectCount = 0; // Perfect 카운트
        private int goodCount = 0; // Good 카운트
        private int badCount = 0; // Bad 카운트
        private double bpm = 220; // 예제 BPM 값, 실제로는 크롤링된 값을 사용할 것
        private double targetTime; // 목표 시간
        private int countTarget = 1; // 비트 누적 카운터
        private long startTime; // 곡 시작 시간

        private Random random = new Random(); // 랜덤 함수 추가
        private Dictionary<Panel, int> skipNext = new Dictionary<Panel, int>(); // 다음 비트를 건너뛸 패널과 비울 비트 수 저장
        public Form1(WindowsMediaPlayer media,Form parent)
        {
            InitializeComponent();
            InitializeGame(); // 게임 초기화 메서드 호출
            InitializeUI(); // UI 초기화 메서드 호출
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            _media = media;
            this.parent = parent;

            skipNext[bar1] = 0;
            skipNext[bar2] =0;
            skipNext[bar3] = 0;
            skipNext[bar4] = 0;

            this.KeyDown += new KeyEventHandler(Form1_KeyDown); // 키보드 입력 이벤트 핸들러 추가
            this.KeyUp += new KeyEventHandler(Form1_KeyUp); // 키보드 뗌 이벤트 핸들러 추가
        }
        // 게임 초기화 메서드
        private void InitializeGame()
        {
            gameTimer.Interval = 1; // 높은 정밀도를 위해 1ms 간격 설정
            gameTimer.Tick += GameTimer_Tick; // 타이머 틱 이벤트 핸들러 추가
            targetTime = (60.0 / bpm) * 1000; // 목표 시간 계산 (밀리초 단위)
        }

        private void InitializeUI()
        {



            btnQ.MouseDown += Btn_MouseDown;
            btnW.MouseDown += Btn_MouseDown;
            btnE.MouseDown += Btn_MouseDown;
            btnR.MouseDown += Btn_MouseDown;
            btnQ.MouseUp += Btn_MouseUp;
            btnW.MouseUp += Btn_MouseUp;
            btnE.MouseUp += Btn_MouseUp;
            btnR.MouseUp += Btn_MouseUp;
        }

        // 게임 타이머 틱 이벤트 핸들러
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            long curTime = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - startTime;
            double getTime = curTime / (targetTime * countTarget);

            if ((int)getTime == 1)
            {
                CreateNotes(); // 노트 생성
                countTarget++;
            }

            // 노트 이동 로직
            foreach (Panel note in notes.ToList())
            {
                note.Top += 5;
                if (note.Top > note.Parent.Height - note.Height)
                {
                    notes.Remove(note);
                    note.Dispose();
                }
            }
        }

        // 각 bar에 노트를 생성하는 메서드
        private void CreateNotes()
        {
            // 랜덤으로 특정 패널을 제외하고 블록 생성
            int excludePanel = random.Next(1, 5);
            CreateNoteInBar(bar1, excludePanel == 1);
            CreateNoteInBar(bar2, excludePanel == 2);
            CreateNoteInBar(bar3, excludePanel == 3);
            CreateNoteInBar(bar4, excludePanel == 4);
        }

        // 특정 bar에 노트를 생성하는 메서드
        private void CreateNoteInBar(Panel bar, bool exclude)
        {
            if (exclude || skipNext[bar] > 0)
            {
                if (skipNext[bar] > 0)
                {
                    skipNext[bar]--; // 비워야 할 비트 수 감소
                }
                return;
            }

            int blockType = random.Next(1, 5); // 1은 짧은 블록, 2는 3비트 긴 블록, 3은 5비트 긴 블록, 4는 7비트 블록
            int blockHeight = blockType == 1 ? 20 : blockType == 2 ? 60 : blockType == 3 ? 100 : 140;

            Panel note = new Panel
            {
                Size = new Size(152, blockHeight),
                BackColor = Color.Blue,
                Location = new Point(0, 0),
                Tag = blockType
            };
            bar.Controls.Add(note);
            notes.Add(note);

           //이후 bpm에 따라 이부분의 간격을 조절 -> 항상 동일한 간격으로 두면 bpm이
           //빠를 경우에는 간격이 너무 좁아질 수 있음
                skipNext[bar] = blockType - 1;// 블록 타입에 따라 다음 몇 비트를 건너뛸지 설정
                if (skipNext[bar] == 0) // 짧은 블록인 경우에도 이후 비트를 비울 수 있도록
                    skipNext[bar] = 1;  
            
        }

        // 음악 재생 메서드
        private void PlayMusic()
        {
            _media.controls.play(); // 음악 재생
            startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond; // 시작 시간 기록
            gameTimer.Start(); // 게임 타이머 시작
        }

        private void Music_Play(object sender,EventArgs e)
        {
            PlayMusic();// 음악 재생 및 타이머 시작 메서드 호출로 변경
            btnStop.Enabled = true;
            btnStop.Visible = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            gameTimer.Stop(); // 게임 타이머 중지
            pause = new pause(_media, this, parent);
            pause.TopLevel = true;
           // pause.MdiParent = this;
            pause.Changed += new EventHandler(Music_Play);
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
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            HandleKeyPress(e.KeyCode, false);
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
        private void HandleKeyPress(Keys key, bool isPressed)
        {
            long curTime = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - startTime;
            Panel targetBar = null;
            int blockType = 0;

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
                foreach (Panel note in notes.ToList())
                {
                    blockType = (int)note.Tag;

                    if (note.Parent == targetBar && note.Top > this.ClientSize.Height - note.Height - 10 && note.Top < this.ClientSize.Height)
                    {
                        if (blockType > 1)
                        {
                            if (curTime - startTime <= targetTime * blockType)
                            {
                                label2.Text = "Holding...";
                                label2.ForeColor = Color.Orange;
                                return;
                            }
                        }
                        else
                        {
                            double noteTime = curTime - (note.Top / 5.0) * (targetTime / 200.0);
                            double difference = Math.Abs(curTime - noteTime);

                            if (difference < 100)
                            {
                                perfectCount++;
                                combo++;
                                label2.Text = "Perfect!";
                                label2.ForeColor = Color.Green;
                            }
                            else if (difference < 200)
                            {
                                goodCount++;
                                combo++;
                                label2.Text = "Good!";
                                label2.ForeColor = Color.Blue;
                            }
                            else
                            {
                                badCount++;
                                combo = 0;
                                label2.Text = "Bad!";
                                label2.ForeColor = Color.Red;
                            }

                            label1.Text = "Combo: " + combo;
                            notes.Remove(note);
                            note.Dispose();
                            break;
                        }
                    }
                }
            }
            else if (!isPressed && blockType > 1)
            {
                foreach (Panel note in notes.ToList())
                {
                    if (note.Parent == targetBar && note.Top > this.ClientSize.Height - note.Height - 10 && note.Top < this.ClientSize.Height)
                    {
                        double noteTime = curTime - (note.Top / 5.0) * (targetTime / 200.0);
                        double difference = Math.Abs(curTime - noteTime);

                        if (difference < 100)
                        {
                            perfectCount++;
                            combo++;
                            label2.Text = "Perfect!";
                            label2.ForeColor = Color.Green;
                        }
                        else if (difference < 200)
                        {
                            goodCount++;
                            combo++;
                            label2.Text = "Good!";
                            label2.ForeColor = Color.Blue;
                        }
                        else
                        {
                            badCount++;
                            combo = 0;
                            label2.Text = "Bad!";
                            label2.ForeColor = Color.Red;
                        }

                        label1.Text = "Combo: " + combo;
                        notes.Remove(note);
                        note.Dispose();
                        break;
                    }
                }
            }
        }

            private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
