﻿namespace oss_rythm
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.bar1 = new System.Windows.Forms.Panel();
            this.bar2 = new System.Windows.Forms.Panel();
            this.bar3 = new System.Windows.Forms.Panel();
            this.bar4 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rLabel = new System.Windows.Forms.Label();
            this.btnQ = new System.Windows.Forms.Button();
            this.btnW = new System.Windows.Forms.Button();
            this.btnE = new System.Windows.Forms.Button();
            this.btnR = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "stop.png");
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // bar1
            // 
            this.bar1.Location = new System.Drawing.Point(10, 67);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(130, 558);
            this.bar1.TabIndex = 2;
            // 
            // bar2
            // 
            this.bar2.Location = new System.Drawing.Point(145, 67);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(130, 558);
            this.bar2.TabIndex = 6;
            // 
            // bar3
            // 
            this.bar3.Location = new System.Drawing.Point(281, 67);
            this.bar3.Name = "bar3";
            this.bar3.Size = new System.Drawing.Size(130, 558);
            this.bar3.TabIndex = 7;
            // 
            // bar4
            // 
            this.bar4.Location = new System.Drawing.Point(417, 67);
            this.bar4.Name = "bar4";
            this.bar4.Size = new System.Drawing.Size(130, 558);
            this.bar4.TabIndex = 7;
            // 
            // rLabel
            // 
            this.rLabel.AutoSize = true;
            this.rLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rLabel.Location = new System.Drawing.Point(441, 799);
            this.rLabel.Name = "rLabel";
            this.rLabel.Size = new System.Drawing.Size(63, 29);
            this.rLabel.TabIndex = 9;
            this.rLabel.Text = "Wait";
            // 
            // btnQ
            // 
            this.btnQ.Location = new System.Drawing.Point(10, 631);
            this.btnQ.Name = "btnQ";
            this.btnQ.Size = new System.Drawing.Size(130, 46);
            this.btnQ.TabIndex = 9;
            this.btnQ.Text = "Q";
            this.btnQ.UseVisualStyleBackColor = true;
            // 
            // btnW
            // 
            this.btnW.Location = new System.Drawing.Point(145, 631);
            this.btnW.Name = "btnW";
            this.btnW.Size = new System.Drawing.Size(130, 46);
            this.btnW.TabIndex = 10;
            this.btnW.Text = "W";
            this.btnW.UseVisualStyleBackColor = true;
            // 
            // btnE
            // 
            this.btnE.Location = new System.Drawing.Point(281, 631);
            this.btnE.Name = "btnE";
            this.btnE.Size = new System.Drawing.Size(130, 46);
            this.btnE.TabIndex = 11;
            this.btnE.Text = "E";
            this.btnE.UseVisualStyleBackColor = true;
            // 
            // btnR
            // 
            this.btnR.Location = new System.Drawing.Point(417, 631);
            this.btnR.Name = "btnR";
            this.btnR.Size = new System.Drawing.Size(130, 46);
            this.btnR.TabIndex = 12;
            this.btnR.Text = "R";
            this.btnR.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 23F);
            this.label1.ForeColor = System.Drawing.Color.Azure;
            this.label1.Location = new System.Drawing.Point(561, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 39);
            this.label1.TabIndex = 13;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("굴림", 37F);
            this.label2.Location = new System.Drawing.Point(557, 498);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 62);
            this.label2.TabIndex = 14;
            this.label2.Text = "label2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::oss_rythm.Properties.Resources.backGround_form1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(802, 717);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnStop.BackgroundImage = global::oss_rythm.Properties.Resources.stop;
            this.btnStop.Location = new System.Drawing.Point(732, 25);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(24, 26);
            this.btnStop.TabIndex = 0;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 33F);
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(257, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 55);
            this.label3.TabIndex = 17;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 23F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(561, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 39);
            this.label4.TabIndex = 18;
            this.label4.Text = "label4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 716);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnR);
            this.Controls.Add(this.btnE);
            this.Controls.Add(this.btnW);
            this.Controls.Add(this.btnQ);
            this.Controls.Add(this.bar4);
            this.Controls.Add(this.bar3);
            this.Controls.Add(this.bar2);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Panel bar1;
        private System.Windows.Forms.Panel bar2;
        private System.Windows.Forms.Panel bar3;
        private System.Windows.Forms.Panel bar4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label rLabel;
        private System.Windows.Forms.Button btnQ;
        private System.Windows.Forms.Button btnW;
        private System.Windows.Forms.Button btnE;
        private System.Windows.Forms.Button btnR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

