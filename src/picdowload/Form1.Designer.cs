namespace picdowload
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKeyWords = new System.Windows.Forms.TextBox();
            this.numPageCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDsetDir = new System.Windows.Forms.TextBox();
            this.btnSelectDestDir = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.txtLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPageCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "关键字：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "获取多少页：";
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.Location = new System.Drawing.Point(63, 10);
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.Size = new System.Drawing.Size(148, 21);
            this.txtKeyWords.TabIndex = 2;
            this.txtKeyWords.Text = "美女";
            // 
            // numPageCount
            // 
            this.numPageCount.Location = new System.Drawing.Point(319, 10);
            this.numPageCount.Name = "numPageCount";
            this.numPageCount.Size = new System.Drawing.Size(65, 21);
            this.numPageCount.TabIndex = 3;
            this.numPageCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPageCount.ValueChanged += new System.EventHandler(this.numPageCount_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "保存到：";
            // 
            // txtDsetDir
            // 
            this.txtDsetDir.Location = new System.Drawing.Point(63, 43);
            this.txtDsetDir.Name = "txtDsetDir";
            this.txtDsetDir.Size = new System.Drawing.Size(240, 21);
            this.txtDsetDir.TabIndex = 5;
            this.txtDsetDir.Text = "C:\\";
            // 
            // btnSelectDestDir
            // 
            this.btnSelectDestDir.Location = new System.Drawing.Point(319, 41);
            this.btnSelectDestDir.Name = "btnSelectDestDir";
            this.btnSelectDestDir.Size = new System.Drawing.Size(65, 23);
            this.btnSelectDestDir.TabIndex = 6;
            this.btnSelectDestDir.Text = "选择 ...";
            this.btnSelectDestDir.UseVisualStyleBackColor = true;
            this.btnSelectDestDir.Click += new System.EventHandler(this.btnSelectDestDir_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(14, 90);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(51, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(84, 90);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(53, 23);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(153, 93);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(231, 17);
            this.progressBar.TabIndex = 9;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(14, 130);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(370, 192);
            this.txtLog.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 334);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSelectDestDir);
            this.Controls.Add(this.txtDsetDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numPageCount);
            this.Controls.Add(this.txtKeyWords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numPageCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKeyWords;
        private System.Windows.Forms.NumericUpDown numPageCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDsetDir;
        private System.Windows.Forms.Button btnSelectDestDir;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox txtLog;
    }
}

