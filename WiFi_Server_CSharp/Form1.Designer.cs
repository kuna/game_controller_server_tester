namespace WiFi_Server_CSharp
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.lb = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.acclX = new System.Windows.Forms.ProgressBar();
            this.acclY = new System.Windows.Forms.ProgressBar();
            this.acclZ = new System.Windows.Forms.ProgressBar();
            this.accl = new System.Windows.Forms.ProgressBar();
            this.accl_stat = new System.Windows.Forms.Label();
            this.ori_stat = new System.Windows.Forms.Label();
            this.pb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb
            // 
            this.lb.FormattingEnabled = true;
            this.lb.ItemHeight = 12;
            this.lb.Location = new System.Drawing.Point(12, 45);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(437, 244);
            this.lb.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(112, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 27);
            this.button2.TabIndex = 0;
            this.button2.Text = "Close Server";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(212, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 27);
            this.button3.TabIndex = 0;
            this.button3.Text = "Send Data";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // acclX
            // 
            this.acclX.Location = new System.Drawing.Point(12, 295);
            this.acclX.Maximum = 10000;
            this.acclX.Name = "acclX";
            this.acclX.Size = new System.Drawing.Size(169, 18);
            this.acclX.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.acclX.TabIndex = 2;
            // 
            // acclY
            // 
            this.acclY.Location = new System.Drawing.Point(12, 319);
            this.acclY.Maximum = 10000;
            this.acclY.Name = "acclY";
            this.acclY.Size = new System.Drawing.Size(169, 18);
            this.acclY.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.acclY.TabIndex = 3;
            // 
            // acclZ
            // 
            this.acclZ.Location = new System.Drawing.Point(12, 343);
            this.acclZ.Maximum = 10000;
            this.acclZ.Name = "acclZ";
            this.acclZ.Size = new System.Drawing.Size(169, 18);
            this.acclZ.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.acclZ.TabIndex = 4;
            // 
            // accl
            // 
            this.accl.Location = new System.Drawing.Point(12, 382);
            this.accl.Maximum = 10000;
            this.accl.Name = "accl";
            this.accl.Size = new System.Drawing.Size(169, 18);
            this.accl.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.accl.TabIndex = 5;
            // 
            // accl_stat
            // 
            this.accl_stat.AutoSize = true;
            this.accl_stat.Location = new System.Drawing.Point(12, 409);
            this.accl_stat.Name = "accl_stat";
            this.accl_stat.Size = new System.Drawing.Size(38, 12);
            this.accl_stat.TabIndex = 6;
            this.accl_stat.Text = "label1";
            // 
            // ori_stat
            // 
            this.ori_stat.AutoSize = true;
            this.ori_stat.Location = new System.Drawing.Point(227, 295);
            this.ori_stat.Name = "ori_stat";
            this.ori_stat.Size = new System.Drawing.Size(38, 12);
            this.ori_stat.TabIndex = 7;
            this.ori_stat.Text = "label1";
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(229, 319);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(220, 99);
            this.pb.TabIndex = 8;
            this.pb.TabStop = false;
            this.pb.Paint += new System.Windows.Forms.PaintEventHandler(this.pbPaint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 430);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.ori_stat);
            this.Controls.Add(this.accl_stat);
            this.Controls.Add(this.accl);
            this.Controls.Add(this.acclZ);
            this.Controls.Add(this.acclY);
            this.Controls.Add(this.acclX);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lb;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ProgressBar acclX;
        private System.Windows.Forms.ProgressBar acclY;
        private System.Windows.Forms.ProgressBar acclZ;
        private System.Windows.Forms.ProgressBar accl;
        private System.Windows.Forms.Label accl_stat;
        private System.Windows.Forms.Label ori_stat;
        private System.Windows.Forms.PictureBox pb;
    }
}

