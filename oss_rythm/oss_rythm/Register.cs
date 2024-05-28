using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oss_rythm
{
    public partial class Register : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private bool isRegistering = false;
        private bool isPasswordPlaceholder = true; // 비밀번호 필드가 placeholder 상태인지 확인

        public Register()
        {
            InitializeComponent();
            InitializeRegisterComponents();
        }

        // 회원가입 폼 초기화하는 메서드
        private void InitializeRegisterComponents()
        {
            // 초기화 코드 (필요한 경우 다른 초기화 코드 추가)
            btnRegister.Click += btnRegister_Click;
            btnExit.Click += btnExit_Click;
            txtPassword.KeyPress += txtPassword_KeyPress;
            isPasswordPlaceholder = true;
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (isRegistering) return; // 이미 회원가입 중이면 실행하지 않음

            isRegistering = true;
            string username = txtID.Text;
            string password = txtPassword.Text;

            Task.Run(() => clientRegister(username, password));

        }

        private void clientRegister(string username, string password)
        {
            try
            {
                client = new TcpClient("127.0.0.1", 13000); // 서버 연결
                stream = client.GetStream();

                string message = $"register:{username}:{password}";  // 회원가입 요청 메시지
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);         // 서버로 메시지 전송

                byte[] responseData = new byte[256];
                int bytesRead = stream.Read(responseData, 0, responseData.Length);
                string response = Encoding.UTF8.GetString(responseData, 0, bytesRead);

                stream.Close();
                client.Close();

                if (response == "Register Success")
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show("회원가입이 성공적으로 완료되었습니다.", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();  // 등록 성공 시 창 닫기
                    });
                }
                else
                {
 
                        MessageBox.Show("회원가입에 실패했습니다. 다시 시도해주세요.", "실패", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (SocketException ex)
            {

                    MessageBox.Show("서버에 연결할 수 없습니다.", "서버 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
  
            }
            catch (Exception ex)
            {

                    MessageBox.Show($"오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {

                    isRegistering = false;

            }
        }



        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
