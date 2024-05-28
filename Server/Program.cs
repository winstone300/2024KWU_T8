using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Server
{
    internal class Program
    {
        static Dictionary<string, string> users = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            LoadUsersFromCSV("users.csv");
            TcpListener server = null;
            try
            {
                int port = 13000;
                server = new TcpListener(IPAddress.Any, port);
                server.Start();

                while(true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    Thread clientThread = new Thread(HandleClient);
                    clientThread.Start(client);
                }
            }

            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e); ;
            }

            finally
            {
                server.Stop();
            }

            Console.WriteLine("\n Enter를 눌러주세요.");
            Console.Read();
        }
        
        // 서버 로그인 처리 함수
        static void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream(); ;

            byte[] buffer = new byte[256];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received: {0}", data);

            string[] parts = data.Split(':');
            string username = parts[0];
            string password = parts[1];

            string response = ValidateLogin(username, password) ? "Login Success" : "Login Failed";
            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            stream.Write(responseBytes, 0, responseBytes.Length);

            client.Close();
        }

        // csv 파일 읽어내는 함수.
        // ","로 아이디, 비밀번호 구분
        static void LoadUsersFromCSV(string path)
        {
            if(File.Exists(path))
            {
                var lines = File.ReadAllLines(path);
                foreach(var line in lines)
                {
                    var parts = line.Split(',');
                    if(parts.Length == 2)
                    {
                        users[parts[0]] = parts[1];
                    }
                }
            }
        }

        // 아이디, 비밀번호를 찾아내는 함수
        static bool ValidateLogin(string username, string password)
        {
            return users.ContainsKey(username) && users[username] == password;
        }
    }
}
