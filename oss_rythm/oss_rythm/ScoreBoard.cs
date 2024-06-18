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
            song = new Song();
            // exe 파일이 있는 디렉토리를 기준으로 파일 경로 설정
            filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dataset.xml");
            LoadDataSetFromFile(filePath);      //기존 경로에 dataset존재시 불러옴
            AddOrUpdateSong(username, title, bpm, score);
            DataTable songTable = song.Tables["Song"];
            DataRow[] foundRows = songTable.Select($"title = '{title}' AND name = '{username}'");
            this.rank = (int)foundRows[0]["rank"];
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
            DataRow[] foundRows = songTable.Select($"title = '{title}' AND name = '{username}'");

            if (foundRows.Length > 0)
            {
                // 행이 존재하면 기존점수와 비교후 업데이트
                double originScore = (double)foundRows[0]["score"];
                if (originScore < score)
                {
                    foundRows[0]["score"] = score;
                }
            }
            else
            {
                // 행이 존재하지 않으면 새로 추가
                songTable.Rows.Add(username, title, bpm, score);
            }

            UpdateRanksByTitle(title);
        }

        //랭크 매기기
        private void UpdateRanksByTitle(string title)
        {
            DataTable songTable = song.Tables["Song"];

            // 특정 title을 가진 행들만 필터링
            var filteredRows = songTable.AsEnumerable()
                .Where(row => row.Field<string>("title") == title)
                .OrderByDescending(row => row.Field<double>("score"))
                .ToList();

            // 각 행의 순위를 업데이트
            for (int i = 0; i < filteredRows.Count; i++)
            {
                filteredRows[i]["rank"] = i + 1;
            }

            // 데이터셋 파일에 업데이트된 데이터 저장
            song.WriteXml(filePath);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            login = new Login();
            start = new Start(username, login);
            custom = new Custom(username, start);
            custom.Show();
            this.Close();
        }
    }
}
