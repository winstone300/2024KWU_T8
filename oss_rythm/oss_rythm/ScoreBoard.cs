using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oss_rythm
{
    public partial class ScoreBoard : Form
    {
        double score;
        int combo;
        string username;
        Form parent;
        Start start;
        Custom custom;
        int rank; // Add rank field

        public ScoreBoard(Form parent,double totalscore, int maxcombo,string username, int rank)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.parent = parent;
            this.username = username;
            score = totalscore;
            combo = maxcombo;
            this.rank = rank; // Initialize rank
        }

        private void ScoreBoard_Load(object sender, EventArgs e)
        {
            lblCombo.Text = combo.ToString();
            lblScore.Text = score.ToString();
            lblRank.Text = rank.ToString(); // Display the rank
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            start = new Start(username, parent);
            custom = new Custom(username, start);
            custom.Show();
            this.Close();
        }
    }
}
