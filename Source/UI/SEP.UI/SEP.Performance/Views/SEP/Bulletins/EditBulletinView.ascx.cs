//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EditBulletinView.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-23
// 概述: 增加EditBulletinView
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.Model.Bulletins;
using SEP.Model.Departments;
using SEP.Presenter.IPresenter.IBulletins;
using ShiXin.Security;

namespace SEP.Performance.Views.SEP.Bulletins
{
    public partial class EditBulletinView : UserControl, IEditBulletinView
    {
        private int _AppendixID;
        private string _ATitle;
        private string _Directory;
        private string _UploadFileLocation;

        protected void Page_Load(object sender, EventArgs e)
        {
            _UploadFileLocation = Server.MapPath(ConstParameters.UploadFile);
            lblAppendixListMessage = "";
            lblBulletinTitleMessage = "";
            ErrorMessageFromBll = "";
            lblPublishTimeMessage = "";
            message.Visible = false;
            if (!IsPostBack)
            {
                if (InitView != null)
                {
                    InitView(this, EventArgs.Empty);
                }
            }
        }


        public List<Appendix> AppendixList
        {
            get { return ViewState["AppendixList"] as List<Appendix>; }
            set
            {
                ViewState["AppendixList"] = value;
                DataBindForAppendixList();
            }
        }

        public int BulletinID
        {
            get
            {
                return
                    Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["BulletinID"]));
            }
            set { }
        }

        public string Content
        {
            get { return txtContent.Value.Trim(); }
            set { txtContent.Value = value; }
        }

        public string Title
        {
            get { return txtTitle.Text.Trim(); }
            set { txtTitle.Text = value; }
        }

        public string OpetaTitle
        {
            set { lblTitle.Text = value; }
        }

        public String PublishTime
        {
            get { return txtPublishTime.Text.Trim(); }
            set { txtPublishTime.Text = value; }
        }

        public int AppendixID
        {
            get { return _AppendixID; }
            set { _AppendixID = value; }
        }

        public string ATitle
        {
            get { return _ATitle; }
            set { _ATitle = value; }
        }

        public string Directory
        {
            get { return _Directory; }
            set { _Directory = value; }
        }

        public string lblBulletinTitleMessage
        {
            get { return lblBulletinTitleError.Text; }
            set { lblBulletinTitleError.Text = value; }
        }


        public string lblPublishTimeMessage
        {
            get { return lblPublishTimeError.Text; }
            set { lblPublishTimeError.Text = value; }
        }

        public string lblAppendixListMessage
        {
            get { return lblAppendixMessage.Text; }
            set { lblAppendixMessage.Text = value; }
        }

        public string ErrorMessageFromBll
        {
            get { return ErrorMessageForBll.Text; }
            set
            {
                ErrorMessageForBll.Text = value;
                message.Visible = !string.IsNullOrEmpty(ErrorMessageForBll.Text.Trim());
            }
        }


        public List<Department> DepartmentSource
        {
            set
            {
                listDepartment.Items.Clear();
                foreach (Department department in value)
                {
                    ListItem item = new ListItem(department.DepartmentName, department.DepartmentID.ToString(), true);
                    listDepartment.Items.Add(item);
                }
            }
        }

        public int DepartmentId
        {
            get { return Convert.ToInt32(listDepartment.SelectedValue); }
            set { listDepartment.SelectedValue = value.ToString(); }
        }

        public event EventHandler btnOKClicked;
        public event EventHandler DeleteAppendix;
        public event EventHandler AddAppendix;
        public event EventHandler InitView;

        private void DataBindForAppendixList()
        {
            lbAppendixList.DataSource = AppendixList;
            lbAppendixList.DataValueField = "Directory";
            lbAppendixList.DataTextField = "Title";
            lbAppendixList.DataBind();
        }

        protected void btnDeleteAppendix_Click(object sender, EventArgs e)
        {
            if (lbAppendixList.SelectedIndex >= 0)
            {
                Directory = lbAppendixList.SelectedItem.Value;
                ATitle = lbAppendixList.SelectedItem.Text;
                EventHandler DeleteAppendixTemp = DeleteAppendix;
                if (DeleteAppendixTemp != null)
                {
                    DeleteAppendixTemp(this, EventArgs.Empty);
                }
                DataBindForAppendixList();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(_UploadFileLocation))
            {
                System.IO.Directory.CreateDirectory(_UploadFileLocation);
            }
            HttpPostedFile hpf = Upload.PostedFile;
            string filename = Path.GetFileName(hpf.FileName);
            string fileExt = Path.GetExtension(hpf.FileName);
            lblAppendixListMessage = "";
            if (!string.IsNullOrEmpty(filename.Trim()))
            {
                if (hpf.ContentLength > 5242880)
                {
                    lblAppendixListMessage = "附件大小不能大于5M";
                    return;
                }
                if (fileExt == ".exe")
                {
                    lblAppendixListMessage = "不能上传exe文件";
                    return;
                }
                if (AddAppendix != null)
                {
                    string NowDate = DateTime.Now.ToString();
                    NowDate = NowDate.Replace(" ", "");
                    NowDate = NowDate.Replace(":", "");
                    NowDate = NowDate.Replace("-", "");
                    NowDate = NowDate.Replace("/", "");
                    filename = NowDate + "_" + filename;
                    Directory = _UploadFileLocation + "\\" + filename;
                    hpf.SaveAs(Directory);
                    ATitle = filename;

                    AddAppendix(this, EventArgs.Empty);
                }
            }
            DataBindForAppendixList();
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (btnOKClicked != null)
            {
                btnOKClicked(this, EventArgs.Empty);
            }
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("BulletinListBack.aspx");
        }
    }
}