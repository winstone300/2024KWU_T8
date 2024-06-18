namespace oss_rythm
{
    partial class Custom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoad = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RealBmp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBpmInfo = new System.Windows.Forms.Label();
            this.labelBpm = new System.Windows.Forms.Label();
            this.lblScoreInfo = new System.Windows.Forms.Label();
            this.lblTitleInfo = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnHard = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnEasy = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.BpmLoding = new System.Windows.Forms.Label();
            this.labelSelect = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.SetBlock = new System.Windows.Forms.Button();
            this.SetSpeed = new System.Windows.Forms.Button();
            this.spdValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.diffValue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(970, 46);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(124, 34);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "불러오기";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnPlay.Location = new System.Drawing.Point(975, 578);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(642, 68);
            this.btnPlay.TabIndex = 4;
            this.btnPlay.Text = "PLAY";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnBack.Location = new System.Drawing.Point(40, 38);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(106, 44);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.diffValue);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.spdValue);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.RealBmp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblBpmInfo);
            this.groupBox1.Controls.Add(this.labelBpm);
            this.groupBox1.Controls.Add(this.lblScoreInfo);
            this.groupBox1.Controls.Add(this.lblTitleInfo);
            this.groupBox1.Controls.Add(this.labelScore);
            this.groupBox1.Controls.Add(this.labelTitle);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.groupBox1.Location = new System.Drawing.Point(40, 398);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(863, 248);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INFO";
            // 
            // RealBmp
            // 
            this.RealBmp.AutoSize = true;
            this.RealBmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RealBmp.Location = new System.Drawing.Point(592, 164);
            this.RealBmp.Name = "RealBmp";
            this.RealBmp.Size = new System.Drawing.Size(23, 25);
            this.RealBmp.TabIndex = 7;
            this.RealBmp.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(462, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "REAL BMP";
            // 
            // lblBpmInfo
            // 
            this.lblBpmInfo.AutoSize = true;
            this.lblBpmInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBpmInfo.Location = new System.Drawing.Point(387, 164);
            this.lblBpmInfo.Name = "lblBpmInfo";
            this.lblBpmInfo.Size = new System.Drawing.Size(23, 25);
            this.lblBpmInfo.TabIndex = 5;
            this.lblBpmInfo.Text = "0";
            // 
            // labelBpm
            // 
            this.labelBpm.AutoSize = true;
            this.labelBpm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBpm.Location = new System.Drawing.Point(282, 164);
            this.labelBpm.Name = "labelBpm";
            this.labelBpm.Size = new System.Drawing.Size(58, 25);
            this.labelBpm.TabIndex = 4;
            this.labelBpm.Text = "BPM";
            // 
            // lblScoreInfo
            // 
            this.lblScoreInfo.AutoSize = true;
            this.lblScoreInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreInfo.Location = new System.Drawing.Point(159, 164);
            this.lblScoreInfo.Name = "lblScoreInfo";
            this.lblScoreInfo.Size = new System.Drawing.Size(23, 25);
            this.lblScoreInfo.TabIndex = 3;
            this.lblScoreInfo.Text = "0";
            // 
            // lblTitleInfo
            // 
            this.lblTitleInfo.AutoSize = true;
            this.lblTitleInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleInfo.Location = new System.Drawing.Point(159, 75);
            this.lblTitleInfo.Name = "lblTitleInfo";
            this.lblTitleInfo.Size = new System.Drawing.Size(23, 25);
            this.lblTitleInfo.TabIndex = 2;
            this.lblTitleInfo.Text = "0";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.Location = new System.Drawing.Point(46, 164);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(69, 25);
            this.labelScore.TabIndex = 1;
            this.labelScore.Text = "Score";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(46, 75);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(60, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title ";
            // 
            // btnHard
            // 
            this.btnHard.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnHard.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnHard.Location = new System.Drawing.Point(631, 261);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(271, 81);
            this.btnHard.TabIndex = 11;
            this.btnHard.Text = "HARD";
            this.btnHard.UseVisualStyleBackColor = true;
            this.btnHard.Click += new System.EventHandler(this.btnHard_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnNormal.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnNormal.Location = new System.Drawing.Point(334, 261);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(271, 81);
            this.btnNormal.TabIndex = 10;
            this.btnNormal.Text = "NORMAL";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // btnEasy
            // 
            this.btnEasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEasy.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnEasy.Location = new System.Drawing.Point(41, 261);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(271, 81);
            this.btnEasy.TabIndex = 9;
            this.btnEasy.Text = "EASY";
            this.btnEasy.UseVisualStyleBackColor = true;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(970, 123);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(29, 30);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(357, 375);
            this.webBrowser1.TabIndex = 12;
            this.webBrowser1.Visible = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(970, 446);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(647, 52);
            this.progressBar1.TabIndex = 13;
            // 
            // BpmLoding
            // 
            this.BpmLoding.AutoSize = true;
            this.BpmLoding.Location = new System.Drawing.Point(970, 506);
            this.BpmLoding.Name = "BpmLoding";
            this.BpmLoding.Size = new System.Drawing.Size(14, 18);
            this.BpmLoding.TabIndex = 14;
            this.BpmLoding.Text = ".";
            // 
            // labelSelect
            // 
            this.labelSelect.AutoSize = true;
            this.labelSelect.BackColor = System.Drawing.Color.White;
            this.labelSelect.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelSelect.Location = new System.Drawing.Point(970, 98);
            this.labelSelect.Name = "labelSelect";
            this.labelSelect.Size = new System.Drawing.Size(649, 25);
            this.labelSelect.TabIndex = 16;
            this.labelSelect.Text = "----------------------------------- Select Music --------------------------------" +
    "-------";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1490, 38);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(127, 34);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "아이템 삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(970, 123);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(649, 326);
            this.listView1.TabIndex = 18;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "파일명";
            this.columnHeader1.Width = 211;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "BPM";
            this.columnHeader2.Width = 99;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "점수";
            this.columnHeader3.Width = 88;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "랭킹";
            this.columnHeader4.Width = 105;
            // 
            // SetBlock
            // 
            this.SetBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetBlock.Location = new System.Drawing.Point(142, 160);
            this.SetBlock.Name = "SetBlock";
            this.SetBlock.Size = new System.Drawing.Size(271, 81);
            this.SetBlock.TabIndex = 22;
            this.SetBlock.Text = "BLOCK";
            this.SetBlock.UseVisualStyleBackColor = true;
            this.SetBlock.Click += new System.EventHandler(this.SetBlock_Click);
            // 
            // SetSpeed
            // 
            this.SetSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetSpeed.Location = new System.Drawing.Point(526, 160);
            this.SetSpeed.Name = "SetSpeed";
            this.SetSpeed.Size = new System.Drawing.Size(271, 81);
            this.SetSpeed.TabIndex = 23;
            this.SetSpeed.Text = "SPEED";
            this.SetSpeed.UseVisualStyleBackColor = true;
            this.SetSpeed.Click += new System.EventHandler(this.SetSpeed_Click);
            // 
            // spdValue
            // 
            this.spdValue.AutoSize = true;
            this.spdValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdValue.Location = new System.Drawing.Point(778, 164);
            this.spdValue.Name = "spdValue";
            this.spdValue.Size = new System.Drawing.Size(39, 25);
            this.spdValue.TabIndex = 9;
            this.spdValue.Text = "1.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(653, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "SPEED";
            // 
            // diffValue
            // 
            this.diffValue.AutoSize = true;
            this.diffValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diffValue.Location = new System.Drawing.Point(778, 75);
            this.diffValue.Name = "diffValue";
            this.diffValue.Size = new System.Drawing.Size(74, 25);
            this.diffValue.TabIndex = 11;
            this.diffValue.Text = "Normal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(621, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "DIFFICULTY";
            // 
            // Custom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::oss_rythm.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1690, 690);
            this.Controls.Add(this.SetSpeed);
            this.Controls.Add(this.SetBlock);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.labelSelect);
            this.Controls.Add(this.BpmLoding);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btnHard);
            this.Controls.Add(this.btnNormal);
            this.Controls.Add(this.btnEasy);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnLoad);
            this.Name = "Custom";
            this.Text = "Custom";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Custom_FormClosed);
            this.Load += new System.EventHandler(this.Custom_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label lblScoreInfo;
        private System.Windows.Forms.Label lblTitleInfo;
        private System.Windows.Forms.Button btnHard;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Label lblBpmInfo;
        private System.Windows.Forms.Label labelBpm;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label BpmLoding;
        private System.Windows.Forms.Label labelSelect;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label RealBmp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Button SetBlock;
        private System.Windows.Forms.Button SetSpeed;
        private System.Windows.Forms.Label diffValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label spdValue;
        private System.Windows.Forms.Label label3;
    }
}
