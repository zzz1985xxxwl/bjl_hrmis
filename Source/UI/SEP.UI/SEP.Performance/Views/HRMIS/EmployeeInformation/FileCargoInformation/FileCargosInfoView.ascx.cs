using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FileCargoViews;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.EmployeeInformation.FileCargoInformation
{
    public partial class FileCargosInfoView : UserControl, IFileCargoInfoView, IFileCargoView, IFileCargoListView
    {
        public event DelegateNoParameter BtnActionEvent;
        public event DelegateNoParameter BtnCancelEvent;
        private bool _ActionSuccess;
        private string _UploadFileLocation;

        protected void Page_Load(object sender, EventArgs e)
        {
            _UploadFileLocation = Server.MapPath(ConstParameters.FileCargo);
            btnCancel.Attributes["onclick"] = "return CloseModalPopupExtender('" + divMPE.ClientID + "');";
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            FileCargoListGV.PageIndex = pageindex;
                GetFileList();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(FileCargoListGV, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        public IFileCargoListView FileCargoListView
        {
            get { return this; }
            set { throw new NotImplementedException(); }
        }

        public IFileCargoView FileCargoView
        {
            get { return this; }
        }

        public int AccountID
        {
            get { return Convert.ToInt32(ViewState["FileCargosAccountID"]); }
            set { ViewState["FileCargosAccountID"] = value; }
        }

        public bool FileCargoViewVisible
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set
            {
                if (value)
                {
                    ModalPopupExtender1.Show();
                }
                else
                {
                    ModalPopupExtender1.Hide();
                }
            }
        }

        #region IFileCargoView 成员

        protected void btnOK_Click(object sender, EventArgs e)
        {
            File = "";
            if (!Directory.Exists(_UploadFileLocation))
            {
                Directory.CreateDirectory(_UploadFileLocation);
            }
            HttpPostedFile hpf = Upload.PostedFile;
            if (hpf != null)
            {
                string filename = Path.GetFileName(hpf.FileName);
                string fileExt = Path.GetExtension(hpf.FileName);
                lblUpoadFile.Text = "";
                if (!string.IsNullOrEmpty(filename.Trim()))
                {
                    if (hpf.ContentLength > 5242880*2.5)
                    {
                        lblUpoadFile.Text = "附件大小不能大于10M";
                        FileCargoViewVisible = true;
                        return;
                    }
                    if (fileExt == ".exe")
                    {
                        lblUpoadFile.Text = "不能上传exe文件";
                        FileCargoViewVisible = true;
                        return;
                    }
                    else
                    {
                        string NowDate = DateTime.Now.ToString();
                        NowDate = NowDate.Replace(" ", "");
                        NowDate = NowDate.Replace(":", "");
                        NowDate = NowDate.Replace("-", "");
                        NowDate = NowDate.Replace("/", "");
                        filename = string.Format("({1}){0}", filename, NowDate);
                        string directory = _UploadFileLocation + "\\" + filename;
                        hpf.SaveAs(directory);
                        File = directory;
                    }
                }
            }

            BtnActionEvent();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BtnCancelEvent();
        }

        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        public string Id
        {
            get { return lblId.Text; }
            set { lblId.Text = value; }
        }

        public bool ActionSuccess
        {
            get { return _ActionSuccess; }
            set { _ActionSuccess = value; }
        }

        public string FileCargoName
        {
            get { return ddFileCargoType.SelectedItem.Value; }
            set { ddFileCargoType.SelectedValue = value; }
        }

        public string Remark
        {
            get { return txtRemark.Text.Trim(); }
            set { txtRemark.Text = value; }
        }

        public List<FileCargoName> FileCargoNameSource
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set
            {
                ddFileCargoType.Items.Clear();
                foreach (FileCargoName fcn in value)
                {
                    ddFileCargoType.Items.Add(new ListItem(fcn.Name, fcn.Id.ToString()));
                }
            }
        }

        private string fileloacation;

        public string File
        {
            get { return fileloacation; }
            set { fileloacation = value; }
        }

        #endregion

        #region FileCargoListView

        public event DelegateNoParameter BtnAddFileCargoEvent;
        public event DelegateID BtnUpdateFileCargoEvent;
        public event DelegateID BtnDeleteFileCargoEvent;
        public event DelegateNoParameter GetFileList;


        protected void btnAddInfo_Click(object sender, EventArgs e)
        {
            BtnAddFileCargoEvent();
        }

        protected void BtnUpdate_Click(object sender, CommandEventArgs e)
        {
            BtnUpdateFileCargoEvent(e.CommandArgument.ToString());
        }

        protected void BtnDelete_Click(object sender, CommandEventArgs e)
        {
            BtnDeleteFileCargoEvent(e.CommandArgument.ToString());
        }

        protected void DimissionInfoGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FileCargoListGV.PageIndex = e.NewPageIndex;
            if (GetFileList != null)
            {
                GetFileList();
            }
        }

        protected void DimissionInfoGV_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        public List<FileCargo> FileCargoDataView
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set
            {
                FileCargoListGV.DataSource = value;
                FileCargoListGV.DataBind();
                if (value != null && value.Count != 0)
                {
                    tbfileCargo.Visible = true;
                }
                else
                {
                    tbfileCargo.Visible = false;
                }
            }
        }

        public bool BtnAddFileCargoVisible
        {
            get { return btnAddInfo.Visible; }
            set { btnAddInfo.Visible = value; }
        }

        public bool BtnUpdateFileCargoVisible
        {
            get { return FileCargoListGV.Columns[5].Visible; }
            set { FileCargoListGV.Columns[5].Visible = value; }
        }

        public bool BtnDeleteFileCargoVisible
        {
            get { return FileCargoListGV.Columns[6].Visible; }
            set { FileCargoListGV.Columns[6].Visible = value; }
        }

        protected void BtnDownLoad_Click(object sender, CommandEventArgs e)
        {
            if (!System.IO.File.Exists(e.CommandName))
            {
                return;
            }
            FileInfo fileInfo = new FileInfo(e.CommandName);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition",
                               "attachment;filename=" + HttpUtility.UrlEncode(fileInfo.Name));
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            Response.End();
        }

        #endregion
    }
}