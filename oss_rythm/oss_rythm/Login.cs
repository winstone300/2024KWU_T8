using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oss_rythm
{
    public partial class Login : Form
    {
        Start start;

        private TcpClient client;
        private NetworkStream stream;
        private bool isPasswordPlaceholder = true; // 비밀번호 필드가 placeholder 상태인지 확인
        private Timer statusClearTimer;
        private bool isRegisterFormOpen = false;  // Register 폼이 열려 있는지 확인하는 플래그

        public Login()
        {
            InitializeComponent();
            InitializeLoignComponents();
        }

        // 로그인 폼 초기화하는 메서드
        private void InitializeLoignComponents()
        {
            // 아이디 초기화
            txtUsername.Text = "Username";
            txtUsername.ForeColor = Color.Gray;
            txtUsername.GotFocus += removeText;
            txtUsername.LostFocus += addText;

            // 비밀번호 초기화
            txtPassword.Text = "Password";
            txtPassword.ForeColor = Color.Gray;
            txtPassword.GotFocus += removeText;
            txtPassword.LostFocus += addText;
            txtPassword.KeyPress += txtPassword_KeyPress;

            // Login 버튼 클릭 이벤트 핸들러 추가
            btnLogin.Click += btnLogin_Click;
            // Register 버튼 클릭 이벤트 핸들러 추가
            btnRegister.Click += btnRegister_Click;

            statusClearTimer = new Timer();
            statusClearTimer.Interval = 1000; // 2초
            statusClearTimer.Tick += StatusClearTimer_Tick;
        }

        // placeholder 제거
        private void removeText(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == txtUsername && tb.Text == "Username")
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
            else if (tb == txtPassword && isPasswordPlaceholder)
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
                tb.PasswordChar = '*';  // 비밀번호 입력시, *로 마스킹 처리
                isPasswordPlaceholder = false;
            }
        }

        // placeholder 추가
        private void addText(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == txtUsername && string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = "Username";
                tb.ForeColor = Color.Gray;
            }

            else if (tb == txtPassword && string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.PasswordChar = '\0'; // placeholder 마스킹 해제
                tb.Text = "Password";
                tb.ForeColor = Color.Gray;
                isPasswordPlaceholder = true;
            }
        }

        // 비밀번호 키 입력시 처리 함수
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isPasswordPlaceholder)
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = '*';
                txtPassword.ForeColor = Color.Black;
                isPasswordPlaceholder = false;
            }
        }

        // 로그인 버튼 클릭 시
        private void btnLogin_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a user ID.");
                return;
            }
            clientLogin(username, password);
        }

        // 서버와 통신을 처리하는 함수
        private void clientLogin(string username, string password)
        {
            try
            {
                client = new TcpClient("127.0.0.1", 13000); // 서버 연결
                stream = client.GetStream();

                string message = $"login:{username}:{password}";  // 로그인 요청 메시지
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);         // 서버로 메시지 전송

                byte[] responseData = new byte[256];
                int bytesRead = stream.Read(responseData, 0, responseData.Length);
                string response = Encoding.UTF8.GetString(responseData, 0, bytesRead);

                stream.Close();
                client.Close();

                lblStatus.Text = response;

                if (response == "Login Success")
                {
                    Start startForm = new Start(username,this);
                    startForm.Show();
                    this.Hide();
                }

                else
                {
                    lblStatus.Location = new Point(235, 160);
                    lblStatus.Text = "해당하는 ID가 없습니다. 다시 입력해주세요.";
                }
            }
            catch (SocketException ex)
            {
                lblStatus.Location = new Point(280, 160);
                lblStatus.Text = "서버에 연결할 수 없습니다.";
            }

            catch (Exception ex)
            {
                lblStatus.Location = new Point(100, 240);
                lblStatus.Text = $"Exception: {ex.Message}";
            }

            finally
            {
                ClearTextBoxes();
            }
        }

        // 텍스트 필드를 초기 상태로 리셋하는 함수
        private void ClearTextBoxes()
        {
            txtUsername.Text = "Username";
            txtUsername.ForeColor = Color.Gray;
            txtPassword.Text = "Password";
            txtPassword.ForeColor = Color.Gray;
            txtPassword.PasswordChar = '\0'; // placeholder 마스킹 해제
            isPasswordPlaceholder = true;
        }

        // 상태 메시지를 일정 시간 후에 지우기 위한 타이머 핸들러
        private void StatusClearTimer_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            statusClearTimer.Stop();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!isRegisterFormOpen)
            {
                isRegisterFormOpen = true;
                Register registerForm = new Register();
                registerForm.FormClosed += RegisterForm_FormClosed;
                registerForm.Show();
            }
        }
        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isRegisterFormOpen = false;  // Register 폼이 닫히면 플래그를 false로 설정
        }
    }
}
