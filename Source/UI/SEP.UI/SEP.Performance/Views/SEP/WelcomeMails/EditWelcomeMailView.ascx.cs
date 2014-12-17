using System;
using System.Web.UI;
using SEP.Presenter;
using SEP.Presenter.IPresenter.IWelcomeMail;
using System.Collections.Generic;
using SEP.Model.Mail;

namespace SEP.Performance.Views.SEP.WelcomeMails
{
    using System.Web.UI.WebControls;

    public partial class EditWelcomeMailView : UserControl,IWelcomeMailView
    {
        public List<MailType> MailTypes
        {
            set
            {
                ddlMailType.Items.Clear();
                foreach (MailType type in value)
                {
                    ListItem item = new ListItem(type.Name, type.Id.ToString(), true);
                    ddlMailType.Items.Add(item);
                }
            }
        }

        public event DelegateNoParameter BtnActionEvent;
        public event DelegateID MailTypeChange;

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (BtnActionEvent != null)
            {
                BtnActionEvent();
            }
        }

        public string Title
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                lblTitle.Text = value;
            }
        }

        public string Content
        {
            get
            {
                return ReplaceToFullpath(FCKeditor1.Value);
            }
            set
            {
                FCKeditor1.Value = ReplaceToRelativePath(value);
            }
        }

        public bool AutoSend
        {
            get
            {
                return cbAutoSend.Checked;
            }
            set
            {
                cbAutoSend.Checked = value;
            }
        }

        public string TheMessage
        {
            get
            {
                return MsgMessage.Text;
            }
            set
            {
                MsgMessage.Text = value;
                tbMessage.Style["display"] = String.IsNullOrEmpty(value) ? "none" : "block";
            }
        }

        public bool IsSuccess
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                if (value)
                {
                    MsgMessage.Text =
                        MsgMessage.Text;
                }
                else
                {
                    MsgMessage.Text =
                        MsgMessage.Text;
                }
            }
        }

        public string MailTypeId
        {
            get { return ddlMailType.SelectedValue; }
            set
            {
                ddlMailType.SelectedValue = value;
                SetMessageDisplay();
            }
        }

        private void SetMessageDisplay()
        {
            trWelcome.Style["display"] = ddlMailType.SelectedValue.Equals("0") ? "" : "none";
        }

        #region 私有方法

        /// <summary>
        /// 以下2个方法是为了解决FCK控件的一个问题：获取的图片的值为相对路径，但是邮件需要的是绝对路径
        /// </summary>
        private static string ReplaceToFullpath(string value)
        {
            return ReplacePath(value, true);
        }

        private static string ReplaceToRelativePath(string value)
        {
            return ReplacePath(value, false);
        }

        private static string ReplacePath(string value, bool fromViewToDb)
        {
            string sUserFilesPath = System.Configuration.ConfigurationManager.AppSettings["FCKeditor:UserFilesPath"];

            if (!string.IsNullOrEmpty(sUserFilesPath))
            {
                string sComplete = System.Configuration.ConfigurationManager.AppSettings["FCKeditor:AutoCompleteAlsoluteURL"];
                if (sComplete == "1")
                {
                    string fullPath = System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + sUserFilesPath;
                    // + System.Web.HttpContext.Current.Request.ApplicationPath + sUserFilesPath;
                    //如果是从界面到数据库，则需要将相对路径替换为绝对路径，反之则相反
                    return fromViewToDb ? value.Replace(sUserFilesPath, fullPath) : value.Replace(fullPath, sUserFilesPath);
                }
            }

            return value;
        }

        #endregion

        protected void ddlMailType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetMessageDisplay();
            MailTypeChange(ddlMailType.SelectedValue);
        }
    }
}