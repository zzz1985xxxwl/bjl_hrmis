namespace MailTestApplication
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.lbDomainName = new System.Windows.Forms.Label();
            this.lbpassword = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbBody = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtSendTo = new System.Windows.Forms.TextBox();
            this.txtCC = new System.Windows.Forms.TextBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.lbHtml = new System.Windows.Forms.Label();
            this.rbTrue = new System.Windows.Forms.RadioButton();
            this.txtAttriment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.rbFalse = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbDomainName
            // 
            this.lbDomainName.AutoSize = true;
            this.lbDomainName.Location = new System.Drawing.Point(57, 23);
            this.lbDomainName.Name = "lbDomainName";
            this.lbDomainName.Size = new System.Drawing.Size(29, 12);
            this.lbDomainName.TabIndex = 1;
            this.lbDomainName.Text = "域名";
            // 
            // lbpassword
            // 
            this.lbpassword.AutoSize = true;
            this.lbpassword.Location = new System.Drawing.Point(57, 64);
            this.lbpassword.Name = "lbpassword";
            this.lbpassword.Size = new System.Drawing.Size(29, 12);
            this.lbpassword.TabIndex = 2;
            this.lbpassword.Text = "密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "SendTo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "CC";
            // 
            // lbBody
            // 
            this.lbBody.AutoSize = true;
            this.lbBody.Location = new System.Drawing.Point(57, 215);
            this.lbBody.Name = "lbBody";
            this.lbBody.Size = new System.Drawing.Size(29, 12);
            this.lbBody.TabIndex = 2;
            this.lbBody.Text = "Body";
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(122, 14);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(284, 21);
            this.txtDomain.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(122, 55);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(284, 21);
            this.txtPassword.TabIndex = 3;
            // 
            // txtSendTo
            // 
            this.txtSendTo.Location = new System.Drawing.Point(122, 92);
            this.txtSendTo.Name = "txtSendTo";
            this.txtSendTo.Size = new System.Drawing.Size(284, 21);
            this.txtSendTo.TabIndex = 3;
            // 
            // txtCC
            // 
            this.txtCC.Location = new System.Drawing.Point(122, 130);
            this.txtCC.Name = "txtCC";
            this.txtCC.Size = new System.Drawing.Size(284, 21);
            this.txtCC.TabIndex = 3;
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(122, 206);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBody.Size = new System.Drawing.Size(284, 78);
            this.txtBody.TabIndex = 3;
            // 
            // lbHtml
            // 
            this.lbHtml.AutoSize = true;
            this.lbHtml.Location = new System.Drawing.Point(57, 344);
            this.lbHtml.Name = "lbHtml";
            this.lbHtml.Size = new System.Drawing.Size(53, 12);
            this.lbHtml.TabIndex = 4;
            this.lbHtml.Text = "Html格式";
            // 
            // rbTrue
            // 
            this.rbTrue.AutoSize = true;
            this.rbTrue.Location = new System.Drawing.Point(122, 342);
            this.rbTrue.Name = "rbTrue";
            this.rbTrue.Size = new System.Drawing.Size(35, 16);
            this.rbTrue.TabIndex = 5;
            this.rbTrue.TabStop = true;
            this.rbTrue.Text = "是";
            this.rbTrue.UseVisualStyleBackColor = true;
            // 
            // txtAttriment
            // 
            this.txtAttriment.Location = new System.Drawing.Point(122, 304);
            this.txtAttriment.Name = "txtAttriment";
            this.txtAttriment.Size = new System.Drawing.Size(284, 21);
            this.txtAttriment.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "附件地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Subject";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(122, 169);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(284, 21);
            this.txtSubject.TabIndex = 3;
            // 
            // rbFalse
            // 
            this.rbFalse.AutoSize = true;
            this.rbFalse.Location = new System.Drawing.Point(163, 342);
            this.rbFalse.Name = "rbFalse";
            this.rbFalse.Size = new System.Drawing.Size(35, 16);
            this.rbFalse.TabIndex = 5;
            this.rbFalse.TabStop = true;
            this.rbFalse.Text = "否";
            this.rbFalse.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 420);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(287, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "说明：发送和抄送可以多人，用;分开，\r\n如果邮件发送失败，则会在在c盘记录日志，可以查看";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 461);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAttriment);
            this.Controls.Add(this.rbFalse);
            this.Controls.Add(this.rbTrue);
            this.Controls.Add(this.lbHtml);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.txtCC);
            this.Controls.Add(this.txtSendTo);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbBody);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbpassword);
            this.Controls.Add(this.lbDomainName);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "邮件测试";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbDomainName;
        private System.Windows.Forms.Label lbpassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbBody;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtSendTo;
        private System.Windows.Forms.TextBox txtCC;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label lbHtml;
        private System.Windows.Forms.RadioButton rbTrue;
        private System.Windows.Forms.TextBox txtAttriment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.RadioButton rbFalse;
        private System.Windows.Forms.Label label5;
    }
}

