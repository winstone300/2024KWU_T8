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

                while (true)
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
            string command = parts[0];

            if (command == "login")
            {
                string username = parts[1];
                string password = parts[2];

                string response = ValidateLogin(username, password) ? "Login Success" : "Login Failed";
                Console.WriteLine("Sending response: " + response);
                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                stream.Write(responseBytes, 0, responseBytes.Length);

            }
            else if (command == "register")
            {
                string username = parts[1];
                string password = parts[2];

                string response = AddUserToCSV(username, password) ? "Register Success" : "Register Failed";
                Console.WriteLine("Sending response: " + response);
                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                stream.Write(responseBytes, 0, responseBytes.Length);
            }
            client.Close();

            // csv 파일 읽어내는 함수.
            // ","로 아이디, 비밀번호 구분
        }
            static void LoadUsersFromCSV(string path)
            {
                if (File.Exists(path))
                {
                    Console.WriteLine($"Loading users from {path}...");
                    var lines = File.ReadAllLines(path);
                    foreach (var line in lines)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            string username = parts[0].Trim();
                            string password = parts[1].Trim();
                            users[username] = password;
                            Console.WriteLine($"Loaded user: {username}");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid line format: {line}");
                        }
                    }
                    Console.WriteLine("Users loaded from CSV:");  // 디버그 메시지 추가
                    foreach (var user in users)
                    {
                        Console.WriteLine($"Username: {user.Key}, Password: {user.Value}");
                    }
                }
                else
                {
                    Console.WriteLine($"File not found: {path}");
                }
            }

            // 아이디, 비밀번호를 찾아내는 함수
            static bool ValidateLogin(string username, string password)
            {
                if (users.ContainsKey(username))
                {
                    Console.WriteLine($"Validating user: {username}");
                    return users[username] == password;
                }
                return false;
            }
            static bool AddUserToCSV(string id, string password)
            {
                try
                {
                    string path = "users.csv";
                    if (users.ContainsKey(id))
                    {
                        Console.WriteLine("이미 존재하는 ID입니다.");
                        return false;
                    }

                    using (StreamWriter sw = new StreamWriter(path, true))
                    {
                        sw.WriteLine($"{id},{password}");
                    }

                    users[id] = password;  // 메모리 내 사용자 데이터도 업데이트
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"오류 발생: {ex.Message}");
                    return false;
                }
            }
        }
    }
