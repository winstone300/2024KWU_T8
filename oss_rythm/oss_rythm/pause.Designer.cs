namespace oss_rythm
{
    partial class pause
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pause));
            this.label1 = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.volume = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.volume)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("돋움", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(350, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "PAUSE";
            // 
            // btnContinue
            // 
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnContinue.Location = new System.Drawing.Point(334, 140);
            this.btnContinue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(181, 46);
            this.btnContinue.TabIndex = 1;
            this.btnContinue.Text = "continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExit.Location = new System.Drawing.Point(356, 226);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(131, 46);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // volume
            // 
            this.volume.BackColor = System.Drawing.Color.MidnightBlue;
            this.volume.Location = new System.Drawing.Point(286, 309);
            this.volume.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.volume.Maximum = 100;
            this.volume.Name = "volume";
            this.volume.Size = new System.Drawing.Size(291, 69);
            this.volume.TabIndex = 3;
            this.volume.Value = 50;
            this.volume.Scroll += new System.EventHandler(this.Volume_Scroll);
            // 
            // pause
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(911, 436);
            this.Controls.Add(this.volume);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "pause";
            this.Text = "pause";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.volume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TrackBar volume;
    }
}