using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using SEP.Model.CompanyRegulations;
using SEP.Presenter.IPresenter.ICompanyRegulations;

namespace SEP.Performance.Views
{
    public partial class EditCompanyRegulationsView : UserControl, IEditCompanyRegulationView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorMessageFromCompanyRegulations = "";
            CompanyRegulationsTitleErrorMessage = "";
            CompanyReguAppendixListErrorMessage = "";
            message.Visible = false;

            if (!IsPostBack && InitView != null)
            {
                InitView(this, EventArgs.Empty);
            }
        }

        protected void ddlCompanyRegulationsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChangedType != null)
                ChangedType(sender, e);
        }

        protected void btnAddAppendix_Click(object sender, EventArgs e)
        {
            string fileDir = Server.MapPath(ConstParameters.UploadFile);

            if (!Directory.Exists(fileDir))
            {
                Directory.CreateDirectory(fileDir);
            }
            HttpPostedFile hpf = Upload.PostedFile;
            string fileName = Path.GetFileName(hpf.FileName);
            string fileExt = Path.GetExtension(hpf.FileName);
            CompanyReguAppendixListErrorMessage = "";
            if (!string.IsNullOrEmpty(fileName.Trim()))
            {
                if (hpf.ContentLength > 5242880)
                {
                    CompanyReguAppendixListErrorMessage = "附件大小不能大于5M";
                    return;
                }
                if (fileExt == ".exe")
                {
                    CompanyReguAppendixListErrorMessage = "不能上传exe文件";
                    return;
                }
                if (AddAppendix != null)
                {
                    string fileNamePrefix = DateTime.Now.ToString().Replace(" ", "").Replace(":", "").Replace("-", "");
                    string dir = Server.MapPath(ConstParameters.UploadFile) + "\\" + fileNamePrefix + "_" + fileName;
                    CompanyReguAppendix Appendix = new CompanyReguAppendix(ComanyReguId, fileName, dir);
                    //FileName = filename;
                    //string NowDate = DateTime.Now.ToString();
                    //NowDate = NowDate;
                    //NowDate = NowDate;
                    //NowDate = NowDate;
                    //filename = NowDate + "_" + filename;
                    //SelectAppendix = _UploadFileLocation + "\\" + filename;
                    hpf.SaveAs(dir);
                    //Title = filename;

                    AddAppendix(Appendix, EventArgs.Empty);
                }
            }
            RefreshListBoxAppendixList();
        }

        protected void btnDeleteAppendix_Click(object sender, EventArgs e)
        {
            //if (lbAppendixList.SelectedIndex >= 0)
            //{
            //    SelectAppendix = lbAppendixList.SelectedItem.Value;
            //    //Title = lbAppendixList.SelectedItem.Text;
            //    EventHandler DeleteAppendixTemp = DeleteAppendix;
            //    if (DeleteAppendixTemp != null)
            //    {
            //        DeleteAppendixTemp(this, EventArgs.Empty);
            //    }
            //    //DataBindForAppendixList();
            //}
            CompanyReguAppendix selected = CompanyReguAppendixList[SelectedCompanyReguAppendixId];
            //foreach (CompanyReguAppendix item in CompanyReguAppendixList)
            //{
            //    if(item.AppendixID == SelectedCompanyReguAppendixId)
            //    {
            //        selected = item;
            //        break;
            //    }
            //}

            if (selected != null && DeleteAppendix != null)
                DeleteAppendix(selected, null);

            RefreshListBoxAppendixList();
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
            Response.Redirect("CompanyRegulations.aspx");
        }

        private void RefreshListBoxAppendixList()
        {
            lbAppendixList.DataSource = ViewState["CompanyReguAppendixList"];
            lbAppendixList.DataTextField = "FileName";
            lbAppendixList.DataValueField = "AppendixID";
            lbAppendixList.DataBind();
        }

        #region IEditCompanyRegulationsView 成员

        public int ComanyReguId
        {
            get
            {
                if (ViewState["ComanyReguId"] == null)
                    return 0;
                else
                    return (int)ViewState["ComanyReguId"];
            }
            set { ViewState["ComanyReguId"] = value; }
        }

        public string Title
        {
            get { return txtTitle.Text; }
            set { txtTitle.Text = value; }
        }

        public List<KeyValuePair<int, string>> ReguTypeDataSrc
        {
            get
            {
                return (List<KeyValuePair<int, string>>)ddlCompanyRegulationsType.DataSource;
            }
            set
            {
                ddlCompanyRegulationsType.DataSource = value;
                ddlCompanyRegulationsType.DataTextField = "Value";
                ddlCompanyRegulationsType.DataValueField = "Key";
                ddlCompanyRegulationsType.DataBind();
            }
        }

        public int SelectedReguType
        {
            get
            {
                return Convert.ToInt32(ddlCompanyRegulationsType.SelectedValue);
            }
            set
            {
                ddlCompanyRegulationsType.SelectedValue = value.ToString();
            }
        }

        public string Content
        {
            get { return txtContent.Value.Trim(); }
            set { txtContent.Value = value; }
        }

        public List<CompanyReguAppendix> CompanyReguAppendixList
        {
            get
            {
                if (ViewState["CompanyReguAppendixList"] == null)
                    return new List<CompanyReguAppendix>();
                else
                {
                    return ViewState["CompanyReguAppendixList"] as List<CompanyReguAppendix>;
                }
            }
            set
            {
                ViewState["CompanyReguAppendixList"] = value;
                RefreshListBoxAppendixList();
            }
        }

        public int SelectedCompanyReguAppendixId
        {
            get
            {
                return lbAppendixList.SelectedIndex;
            }
        }


        public string ErrorMessageFromCompanyRegulations
        {
            get { return llbErrorMessageForCompanyRegulations.Text; }
            set
            {
                llbErrorMessageForCompanyRegulations.Text = value;
                message.Visible = !string.IsNullOrEmpty(llbErrorMessageForCompanyRegulations.Text.Trim());
            }
        }

        public string CompanyRegulationsTitleErrorMessage
        {
            get { return lblCompanyRegulationsTitleError.Text; }
            set { lblCompanyRegulationsTitleError.Text = value; }
        }

        public string CompanyReguAppendixListErrorMessage
        {
            get { return lblAppendixMessage.Text; }
            set { lblAppendixMessage.Text = value; }
        }



        public event EventHandler InitView;

        public event EventHandler ChangedType;

        public event EventHandler btnOKClicked;

        public event EventHandler AddAppendix;

        public event EventHandler DeleteAppendix;

        #endregion
    }
}