using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Mail;
using Mail.Model;

namespace MailTestApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                new SendMail().Send(GetMailBody(), GetMailSettings());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtDomain.Text = "cnshan01/shanghai/cn/b&r";
            txtSendTo.Text = "Br-hrmis@br-automation.com";
            txtSubject.Text = "test";
            txtBody.Text = "<a>Œ“</a>";
        }

        private MailBody GetMailBody()
        {
            MailBody mailModel = new MailBody();
            mailModel.MailTo = new List<string>();
            if (!String.IsNullOrEmpty(txtSendTo.Text.Trim()))
            {
                string[] to = txtSendTo.Text.Trim().Split(';');
                foreach (string s in to)
                {
                    mailModel.MailTo.Add(s.Trim());
                }
            }
            mailModel.MailCc = new List<string>();
            if (!String.IsNullOrEmpty(txtCC.Text.Trim()))
            {
                string[] to = txtCC.Text.Trim().Split(';');
                foreach (string s in to)
                {
                    mailModel.MailCc.Add(s.Trim());
                }
            }
            mailModel.Subject = txtSubject.Text.Trim();
            mailModel.MailAttachments = new List<MailAttachment>();
            MailAttachment ma = new MailAttachment();
            ma.Location = txtAttriment.Text.Trim();
            mailModel.MailAttachments.Add(ma);
            mailModel.Body = txtBody.Text;
            mailModel.IsAsync = false;
            mailModel.IsHtmlBody = rbTrue.Checked;
            return mailModel;
        }

        private MailSettings GetMailSettings()
        {
            return
                new MailSettings("true", "hr@shixintech.com", "hr@shixintech.com", txtDomain.Text.Trim(),
                                 "hr@shixintech.com", txtPassword.Text.Trim(), false);
        }
    }
}