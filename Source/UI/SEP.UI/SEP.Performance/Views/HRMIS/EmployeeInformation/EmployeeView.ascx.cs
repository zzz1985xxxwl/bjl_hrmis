using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.EmployeeSkillView;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;
using SEP.Model.Utility;
using SEP.Presenter.Core;
using ShiXin.Security;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FileCargoViews;

namespace SEP.Performance.Views.EmployeeInformation
{
    public partial class EmployeeView1 : UserControl, IEmployeeInfoView
    {
        private bool showVocation;
        private bool ShowDimission;
        public event DelegateNoParameter BtnActionEvent;
        public event DelegateNoParameter BtnExportEvent;
        protected string companyMailTo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitImage();
                if (showVocation == false)
                {
                    Menu1.Items[3].ImageUrl = "";
                }
                if (ShowDimission == false)
                {
                    Menu1.Items[6].ImageUrl = "";
                    //Menu1.Items[8].ImageUrl = "";
                }
                MultiView1.ActiveViewIndex = 0;
                Menu1.Items[0].ImageUrl = _Week1ActiveImage;
                if (Request.QueryString[ConstParameters.EmployeeVacationOperation] != null)
                {
                    ChangeImage(SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.EmployeeVacationOperation]));
                }
            }
            companyMailTo = "mailto:" + CompanyConfig.MailToHR;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            BtnActionEvent();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            BtnExportEvent();
        }

        #region IEmployeeInfoView 成员

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

        public string EmployeeName
        {
            get
            {
                return lblName.Text; 
            }
            set
            {
                lblName.Text = value;
            }
        }

        public string Department
        {
            get
            {
                return lblDepart.Text;
            }
            set
            {
                lblDepart.Text = value;
            }
        }

        public string Position
        {
            get
            {
                return lblPosition.Text;
            }
            set
            {
                lblPosition.Text = value;
            }
        }

        public string PositionID
        {
            get
            {
                return hPositionID.Text;
            }
            set
            {
                hPositionID.Style["display"] = "none";
                hPositionID.Text = value;
            }
        }

        public string ComeDate
        {
            get
            {
               return lblComeDate.Text;
            }
            set
            {
                lblComeDate.Text = value;
            }
        }

        public bool MailToHRVisible
        {
            get
            {
                return lbMailToHR.Visible;
            }
            set
            {
                lbMailToHR.Visible = value;
            }
        }

        public string AccountNo
        {
            get { return lblNo.Text; }
            set { lblNo.Text = value; }
        }

        public IBasicInfoView BasicInfoView
        {
            get
            {
                return EmployeeBasicView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public IWelfareInfoView WelfareInfoView
        {
            get
            {
                return EmployeeWelfareView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public IWorkInfoView WorkInfoView
        {
            get
            {
                return EmployeeWorkView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public IFamilyInfoView FamilyInfoView
        {
            get
            {
                return EmployeeFamilyView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public IResumeInfoView ResumeInfoView
        {
            get
            {
                return EmployeeResumeView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public IDimissionBasicView DimissionInfoView
        {
            get { return DimissionBasicView1; }
            set { throw new System.NotImplementedException(); }
        }

        public IFileCargoInfoView FileCargoInfoView
        {
            get { return FileCargosInfoView1; }
            set { throw new System.NotImplementedException(); }
        }

        public bool DimissionInfoVisible
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                ShowDimission = value;
            }
        }

        public bool BtnActionVisible
        {
            get
            {
                return btnConfirm.Visible;
            }
            set
            {
                btnConfirm.Visible = value;
            }
        }

        public bool ActionSuccess
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                if(value)
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

        public bool BtnExportVisible
        {
            get
            {
                return Button1.Visible;
            }
            set
            {
                Button1.Visible = value;
            }
        }

        public string Message
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

        public bool VocationInfoVisible
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                showVocation = value;
            }
        }

        public IVacationView VocationView
        {
            get
            {
                return VacationView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        private string _BackAccountsID;
        public string BackAccountsID
        {
            get
            {
                return _BackAccountsID;
            }
            set
            {
                _BackAccountsID = value;
            }
        }

#endregion

        #region 图片相关

        private const string _Week1ActiveImage = "../../../Pages/image/EmployeeBasicActive.jpg";
        private const string _Week1NotActiveImage = "../../../Pages/image/EmployeeBasicNotActive.jpg";
        private const string _Week2ActiveImage = "../../../Pages/image/EmployeeWorkActive.jpg";
        private const string _Week2NotActiveImage = "../../../Pages/image/EmployeeWorkNotActive.jpg";
        private const string _Week3ActiveImage = "../../../Pages/image/EmployeeWelfareActive.jpg";
        private const string _Week3NotActiveImage = "../../../Pages/image/EmployeeWelfareNotActive.jpg";
        private const string _Week4ActiveImage = "../../../Pages/image/EmployeeVacationActive.jpg";
        private const string _Week4NotActiveImage = "../../../Pages/image/EmployeeVacationNotActive.jpg";
        private const string _Week5ActiveImage = "../../../Pages/image/EmployeeExperienceActive.jpg";
        private const string _Week5NotActiveImage = "../../../Pages/image/EmployeeExperienceNotActive.jpg";
        private const string _Week6ActiveImage = "../../../Pages/image/EmployeeFamilyActive.jpg";
        private const string _Week6NotActiveImage = "../../../Pages/image/EmployeeFamilyNotActive.jpg";
        private const string _Week7ActiveImage = "../../../Pages/image/EmployeeDimissionActive.jpg";
        private const string _Week7NotActiveImage = "../../../Pages/image/EmployeeDimissionNotActive.jpg";
        private const string _Week8ActiveImage = "../../../Pages/image/EmployeeSkillActive.jpg";
        private const string _Week8NotActiveImage = "../../../Pages/image/EmployeeSkillNotActive.jpg";

        private const string _Week9ActiveImage = "../../../Pages/image/FileActive.jpg";
        private const string _Week9NotActiveImage = "../../../Pages/image/FileNotActive.jpg";

        private void InitImage()
        {
            Menu1.Items[0].ImageUrl = _Week1NotActiveImage;
            Menu1.Items[1].ImageUrl = _Week2NotActiveImage;
            Menu1.Items[2].ImageUrl = _Week3NotActiveImage;
            Menu1.Items[3].ImageUrl = _Week4NotActiveImage;
            Menu1.Items[4].ImageUrl = _Week5NotActiveImage;
            Menu1.Items[5].ImageUrl = _Week6NotActiveImage;
            Menu1.Items[6].ImageUrl = _Week7NotActiveImage;
            Menu1.Items[7].ImageUrl = _Week8NotActiveImage;
            Menu1.Items[8].ImageUrl = _Week9NotActiveImage;
        }


        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            hfCurrentTab.Value = e.Item.Value;
            ChangeImage(hfCurrentTab.Value);
        }

        private void ChangeImage(string active)
        {
            MultiView1.ActiveViewIndex = Int32.Parse(active) - 1;
            for (int i = 0; i < Menu1.Items.Count; i++)
            {
                if (!String.IsNullOrEmpty(Menu1.Items[i].ImageUrl))
                {
                    if ((i + 1).ToString() == active)
                    {
                        switch (Menu1.Items[i].ToolTip)
                        {
                            case "基本信息":
                                Menu1.Items[i].ImageUrl = _Week1ActiveImage;
                                break;
                            case "工作信息":
                                Menu1.Items[i].ImageUrl = _Week2ActiveImage;
                                break;
                            case "福利":
                                Menu1.Items[i].ImageUrl = _Week3ActiveImage;
                                break;
                            case "假期":
                                Menu1.Items[i].ImageUrl = _Week4ActiveImage;
                                break;
                            case "简历":
                                Menu1.Items[i].ImageUrl = _Week5ActiveImage;
                                break;
                            case "家庭信息":
                                Menu1.Items[i].ImageUrl = _Week6ActiveImage;
                                break;
                            case "离职信息":
                                Menu1.Items[i].ImageUrl = _Week7ActiveImage;
                                break;
                            case "技能信息":
                                Menu1.Items[i].ImageUrl = _Week8ActiveImage;
                                break;
                            case "档案信息":
                                Menu1.Items[i].ImageUrl = _Week9ActiveImage;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (Menu1.Items[i].ToolTip)
                        {
                            case "基本信息":
                                Menu1.Items[i].ImageUrl = _Week1NotActiveImage;
                                break;
                            case "工作信息":
                                Menu1.Items[i].ImageUrl = _Week2NotActiveImage;
                                break;
                            case "福利":
                                Menu1.Items[i].ImageUrl = _Week3NotActiveImage;
                                break;
                            case "假期":
                                Menu1.Items[i].ImageUrl = _Week4NotActiveImage;
                                break;
                            case "简历":
                                Menu1.Items[i].ImageUrl = _Week5NotActiveImage;
                                break;
                            case "家庭信息":
                                Menu1.Items[i].ImageUrl = _Week6NotActiveImage;
                                break;
                            case "离职信息":
                                Menu1.Items[i].ImageUrl = _Week7NotActiveImage;
                                break;
                            case "技能信息":
                                Menu1.Items[i].ImageUrl = _Week8NotActiveImage;
                                break;
                            case "档案信息":
                                Menu1.Items[i].ImageUrl = _Week9NotActiveImage;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        #endregion


        #region IEmployeeInfoView 成员


        public IEmployeeSkillInfoView EmployeeSkillInfoView
        {
            get
            {
                return EmployeeSkillInfoView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion
    }
}