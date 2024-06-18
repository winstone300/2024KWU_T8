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
            this.diffValue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.spdValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(776, 38);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(99, 28);
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
            this.btnPlay.Location = new System.Drawing.Point(780, 482);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(514, 57);
            this.btnPlay.TabIndex = 4;
            this.btnPlay.Text = "PLAY";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnBack.Location = new System.Drawing.Point(32, 32);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(85, 37);
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
            this.groupBox1.Location = new System.Drawing.Point(32, 332);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(690, 207);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INFO";
            // 
            // diffValue
            // 
            this.diffValue.AutoSize = true;
            this.diffValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diffValue.Location = new System.Drawing.Point(622, 62);
            this.diffValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.diffValue.Name = "diffValue";
            this.diffValue.Size = new System.Drawing.Size(63, 20);
            this.diffValue.TabIndex = 11;
            this.diffValue.Text = "Normal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(497, 62);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "DIFFICULTY";
            // 
            // spdValue
            // 
            this.spdValue.AutoSize = true;
            this.spdValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdValue.Location = new System.Drawing.Point(622, 137);
            this.spdValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.spdValue.Name = "spdValue";
            this.spdValue.Size = new System.Drawing.Size(31, 20);
            this.spdValue.TabIndex = 9;
            this.spdValue.Text = "1.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(522, 137);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "SPEED";
            // 
            // RealBmp
            // 
            this.RealBmp.AutoSize = true;
            this.RealBmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RealBmp.Location = new System.Drawing.Point(474, 137);
            this.RealBmp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RealBmp.Name = "RealBmp";
            this.RealBmp.Size = new System.Drawing.Size(18, 20);
            this.RealBmp.TabIndex = 7;
            this.RealBmp.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(370, 137);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "REAL BMP";
            // 
            // lblBpmInfo
            // 
            this.lblBpmInfo.AutoSize = true;
            this.lblBpmInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBpmInfo.Location = new System.Drawing.Point(310, 137);
            this.lblBpmInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBpmInfo.Name = "lblBpmInfo";
            this.lblBpmInfo.Size = new System.Drawing.Size(18, 20);
            this.lblBpmInfo.TabIndex = 5;
            this.lblBpmInfo.Text = "0";
            // 
            // labelBpm
            // 
            this.labelBpm.AutoSize = true;
            this.labelBpm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBpm.Location = new System.Drawing.Point(226, 137);
            this.labelBpm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBpm.Name = "labelBpm";
            this.labelBpm.Size = new System.Drawing.Size(49, 20);
            this.labelBpm.TabIndex = 4;
            this.labelBpm.Text = "BPM";
            // 
            // lblScoreInfo
            // 
            this.lblScoreInfo.AutoSize = true;
            this.lblScoreInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreInfo.Location = new System.Drawing.Point(127, 137);
            this.lblScoreInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblScoreInfo.Name = "lblScoreInfo";
            this.lblScoreInfo.Size = new System.Drawing.Size(18, 20);
            this.lblScoreInfo.TabIndex = 3;
            this.lblScoreInfo.Text = "0";
            // 
            // lblTitleInfo
            // 
            this.lblTitleInfo.AutoSize = true;
            this.lblTitleInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleInfo.Location = new System.Drawing.Point(127, 62);
            this.lblTitleInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitleInfo.Name = "lblTitleInfo";
            this.lblTitleInfo.Size = new System.Drawing.Size(18, 20);
            this.lblTitleInfo.TabIndex = 2;
            this.lblTitleInfo.Text = "0";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.Location = new System.Drawing.Point(37, 137);
            this.labelScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(58, 20);
            this.labelScore.TabIndex = 1;
            this.labelScore.Text = "Score";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(37, 62);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(52, 20);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title ";
            // 
            // btnHard
            // 
            this.btnHard.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnHard.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnHard.Location = new System.Drawing.Point(505, 218);
            this.btnHard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(217, 68);
            this.btnHard.TabIndex = 11;
            this.btnHard.Text = "HARD";
            this.btnHard.UseVisualStyleBackColor = true;
            this.btnHard.Click += new System.EventHandler(this.btnHard_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnNormal.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnNormal.Location = new System.Drawing.Point(267, 218);
            this.btnNormal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(217, 68);
            this.btnNormal.TabIndex = 10;
            this.btnNormal.Text = "NORMAL";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // btnEasy
            // 
            this.btnEasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEasy.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnEasy.Location = new System.Drawing.Point(33, 218);
            this.btnEasy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(217, 68);
            this.btnEasy.TabIndex = 9;
            this.btnEasy.Text = "EASY";
            this.btnEasy.UseVisualStyleBackColor = true;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(776, 102);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(23, 25);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(286, 312);
            this.webBrowser1.TabIndex = 12;
            this.webBrowser1.Visible = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(776, 372);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(503, 43);
            this.progressBar1.TabIndex = 13;
            // 
            // BpmLoding
            // 
            this.BpmLoding.AutoSize = true;
            this.BpmLoding.Location = new System.Drawing.Point(776, 422);
            this.BpmLoding.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BpmLoding.Name = "BpmLoding";
            this.BpmLoding.Size = new System.Drawing.Size(12, 15);
            this.BpmLoding.TabIndex = 14;
            this.BpmLoding.Text = ".";
            // 
            // labelSelect
            // 
            this.labelSelect.AutoSize = true;
            this.labelSelect.BackColor = System.Drawing.Color.White;
            this.labelSelect.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelSelect.Location = new System.Drawing.Point(776, 82);
            this.labelSelect.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSelect.Name = "labelSelect";
            this.labelSelect.Size = new System.Drawing.Size(550, 20);
            this.labelSelect.TabIndex = 16;
            this.labelSelect.Text = "----------------------------------- Select Music --------------------------------" +
    "-------";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1192, 32);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(102, 28);
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
            this.listView1.Location = new System.Drawing.Point(776, 102);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(503, 272);
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
            this.SetBlock.Location = new System.Drawing.Point(114, 133);
            this.SetBlock.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SetBlock.Name = "SetBlock";
            this.SetBlock.Size = new System.Drawing.Size(217, 68);
            this.SetBlock.TabIndex = 22;
            this.SetBlock.Text = "BLOCK";
            this.SetBlock.UseVisualStyleBackColor = true;
            this.SetBlock.Click += new System.EventHandler(this.SetBlock_Click);
            // 
            // SetSpeed
            // 
            this.SetSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetSpeed.Location = new System.Drawing.Point(421, 133);
            this.SetSpeed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SetSpeed.Name = "SetSpeed";
            this.SetSpeed.Size = new System.Drawing.Size(217, 68);
            this.SetSpeed.TabIndex = 23;
            this.SetSpeed.Text = "SPEED";
            this.SetSpeed.UseVisualStyleBackColor = true;
            this.SetSpeed.Click += new System.EventHandler(this.SetSpeed_Click);
            // 
            // Custom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::oss_rythm.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1352, 575);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
