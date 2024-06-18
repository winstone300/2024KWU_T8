namespace oss_rythm
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
            this.btnStop = new System.Windows.Forms.Button();
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
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "stop.png");
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnStop.BackgroundImage = global::oss_rythm.Properties.Resources.stop;
            this.btnStop.Location = new System.Drawing.Point(566, 24);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(24, 26);
            this.btnStop.TabIndex = 0;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // bar1
            // 
            this.bar1.Location = new System.Drawing.Point(10, 24);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(130, 558);
            this.bar1.TabIndex = 2;
            // 
            // bar2
            // 
            this.bar2.Location = new System.Drawing.Point(146, 24);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(130, 558);
            this.bar2.TabIndex = 6;
            // 
            // bar3
            // 
            this.bar3.Location = new System.Drawing.Point(281, 24);
            this.bar3.Name = "bar3";
            this.bar3.Size = new System.Drawing.Size(130, 558);
            this.bar3.TabIndex = 7;
            // 
            // bar4
            // 
            this.bar4.Location = new System.Drawing.Point(417, 24);
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
            this.btnQ.Location = new System.Drawing.Point(10, 588);
            this.btnQ.Name = "btnQ";
            this.btnQ.Size = new System.Drawing.Size(130, 46);
            this.btnQ.TabIndex = 9;
            this.btnQ.Text = "Q";
            this.btnQ.UseVisualStyleBackColor = true;
            // 
            // btnW
            // 
            this.btnW.Location = new System.Drawing.Point(148, 588);
            this.btnW.Name = "btnW";
            this.btnW.Size = new System.Drawing.Size(130, 46);
            this.btnW.TabIndex = 10;
            this.btnW.Text = "W";
            this.btnW.UseVisualStyleBackColor = true;
            // 
            // btnE
            // 
            this.btnE.Location = new System.Drawing.Point(281, 588);
            this.btnE.Name = "btnE";
            this.btnE.Size = new System.Drawing.Size(130, 46);
            this.btnE.TabIndex = 11;
            this.btnE.Text = "E";
            this.btnE.UseVisualStyleBackColor = true;
            // 
            // btnR
            // 
            this.btnR.Location = new System.Drawing.Point(417, 588);
            this.btnR.Name = "btnR";
            this.btnR.Size = new System.Drawing.Size(130, 46);
            this.btnR.TabIndex = 12;
            this.btnR.Text = "R";
            this.btnR.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(561, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("굴림", 33F);
            this.label2.Location = new System.Drawing.Point(558, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 44);
            this.label2.TabIndex = 14;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 716);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

