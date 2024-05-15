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
            this.resultLabel = new System.Windows.Forms.Label();
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
            this.btnStop.Location = new System.Drawing.Point(733, 22);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(28, 24);
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
            this.bar1.Location = new System.Drawing.Point(12, 22);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(152, 492);
            this.bar1.TabIndex = 2;
            // 
            // bar2
            // 
            this.bar2.Location = new System.Drawing.Point(170, 22);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(152, 492);
            this.bar2.TabIndex = 6;
            // 
            // bar3
            // 
            this.bar3.Location = new System.Drawing.Point(328, 22);
            this.bar3.Name = "bar3";
            this.bar3.Size = new System.Drawing.Size(152, 492);
            this.bar3.TabIndex = 7;
            // 
            // bar4
            // 
            this.bar4.Location = new System.Drawing.Point(486, 22);
            this.bar4.Name = "bar4";
            this.bar4.Size = new System.Drawing.Size(152, 492);
            this.bar4.TabIndex = 7;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.Location = new System.Drawing.Point(441, 799);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(63, 29);
            this.resultLabel.TabIndex = 9;
            this.resultLabel.Text = "Wait";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 661);
            this.Controls.Add(this.bar4);
            this.Controls.Add(this.bar3);
            this.Controls.Add(this.bar2);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.btnStop);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label resultLabel;
    }
}

