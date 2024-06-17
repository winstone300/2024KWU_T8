using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static oss_rythm.Custom;

namespace oss_rythm
{
    public partial class ScoreBoard : Form
    {
        double score;
        int combo;
        string username;
        Form parent;
        Form grandParent;
        Start start;
        Custom custom;
        Login login;
        int rank; // Add rank field
        string filePath;
        Song song;
        string title;
        double bpm;

        public ScoreBoard(Form parent,double totalscore, int maxcombo,string username, int rank,string title,double bpm)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.parent = parent;
            this.title = title;
            this.bpm = bpm;
            this.username = username;
            score = totalscore;
            combo = maxcombo;
            this.rank = rank; // Initialize rank
            song = new Song();
            // exe 파일이 있는 디렉토리를 기준으로 파일 경로 설정
            filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dataset.xml");
            LoadDataSetFromFile(filePath);      //기존 경로에 dataset존재시 불러옴
        }

        //dataset불러오기
        private void LoadDataSetFromFile(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                song = new Song();
                song.ReadXml(filePath);
            }
        }

        private void ScoreBoard_Load(object sender, EventArgs e)
        {
            lblCombo.Text = combo.ToString();
            lblScore.Text = score.ToString();
            lblRank.Text = rank.ToString(); // Display the rank
        }
        public void AddOrUpdateSong(string username, string title, double bpm, double score)
        {
            DataTable songTable = song.Tables["Song"];
            DataRow[] foundRows = songTable.Select($"title = '{title}'");

            if (foundRows.Length > 0)
            {
                // 행이 존재하면 업데이트
                foundRows[0]["bpm"] = bpm;
                foundRows[0]["score"] = score;
                song.WriteXml(filePath);
            }
            else
            {
                // 행이 존재하지 않으면 새로 추가
                songTable.Rows.Add(username, title, bpm, score);
                song.WriteXml(filePath);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            AddOrUpdateSong(username,title,bpm,score);
            login = new Login();
            start = new Start(username, login);
            custom = new Custom(username, start);
            custom.Show();
            this.Close();
        }
    }
}
