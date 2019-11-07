namespace MegalabClient
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.lbtest = new System.Windows.Forms.Label();
            this.btnDoDeleGate = new System.Windows.Forms.Button();
            this.tbDataSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCommSet = new System.Windows.Forms.Button();
            this.tbCommInfo = new System.Windows.Forms.TextBox();
            this.btnCommInfoClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTest);
            this.groupBox1.Controls.Add(this.lbtest);
            this.groupBox1.Controls.Add(this.btnDoDeleGate);
            this.groupBox1.Controls.Add(this.tbDataSend);
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Controls.Add(this.btnCommSet);
            this.groupBox1.Location = new System.Drawing.Point(49, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 239);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通信";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(241, 174);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 5;
            this.btnTest.Text = "测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lbtest
            // 
            this.lbtest.AutoSize = true;
            this.lbtest.Location = new System.Drawing.Point(139, 179);
            this.lbtest.Name = "lbtest";
            this.lbtest.Size = new System.Drawing.Size(41, 12);
            this.lbtest.TabIndex = 4;
            this.lbtest.Text = "label1";
            // 
            // btnDoDeleGate
            // 
            this.btnDoDeleGate.Location = new System.Drawing.Point(38, 117);
            this.btnDoDeleGate.Name = "btnDoDeleGate";
            this.btnDoDeleGate.Size = new System.Drawing.Size(75, 23);
            this.btnDoDeleGate.TabIndex = 3;
            this.btnDoDeleGate.Text = "执行";
            this.btnDoDeleGate.UseVisualStyleBackColor = true;
            this.btnDoDeleGate.Click += new System.EventHandler(this.btnDoDeleGate_Click);
            // 
            // tbDataSend
            // 
            this.tbDataSend.Location = new System.Drawing.Point(263, 44);
            this.tbDataSend.Name = "tbDataSend";
            this.tbDataSend.Size = new System.Drawing.Size(100, 21);
            this.tbDataSend.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(141, 44);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCommSet
            // 
            this.btnCommSet.Location = new System.Drawing.Point(38, 44);
            this.btnCommSet.Name = "btnCommSet";
            this.btnCommSet.Size = new System.Drawing.Size(75, 23);
            this.btnCommSet.TabIndex = 0;
            this.btnCommSet.Text = "建立";
            this.btnCommSet.UseVisualStyleBackColor = true;
            this.btnCommSet.Click += new System.EventHandler(this.btnCommSet_Click);
            // 
            // tbCommInfo
            // 
            this.tbCommInfo.Location = new System.Drawing.Point(574, 31);
            this.tbCommInfo.MinimumSize = new System.Drawing.Size(200, 300);
            this.tbCommInfo.Multiline = true;
            this.tbCommInfo.Name = "tbCommInfo";
            this.tbCommInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCommInfo.Size = new System.Drawing.Size(200, 333);
            this.tbCommInfo.TabIndex = 1;
            // 
            // btnCommInfoClear
            // 
            this.btnCommInfoClear.Location = new System.Drawing.Point(699, 390);
            this.btnCommInfoClear.Name = "btnCommInfoClear";
            this.btnCommInfoClear.Size = new System.Drawing.Size(75, 23);
            this.btnCommInfoClear.TabIndex = 2;
            this.btnCommInfoClear.Text = "清空";
            this.btnCommInfoClear.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCommInfoClear);
            this.Controls.Add(this.tbCommInfo);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCommSet;
        private System.Windows.Forms.TextBox tbCommInfo;
        private System.Windows.Forms.Button btnCommInfoClear;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbDataSend;
        private System.Windows.Forms.Button btnDoDeleGate;
        private System.Windows.Forms.Label lbtest;
        private System.Windows.Forms.Button btnTest;
    }
}

