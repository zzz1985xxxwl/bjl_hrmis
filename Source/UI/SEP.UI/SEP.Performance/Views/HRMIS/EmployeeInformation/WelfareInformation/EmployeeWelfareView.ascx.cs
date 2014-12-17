using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.Performance.Views.EmployeeInformation.WelfareInformation
{
    public partial class EmployeeWelfareView : UserControl, IWelfareInfoView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvWelfareHistory.PageIndex = pageindex;
            BindWelfareHistory();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvWelfareHistory, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        private List<EmployeeWelfareHistory> _EmployeeWelfareHistory;

        #region IWelfareInfoView 成员

        #region 用工类型，居住证

        public string WorkType
        {
            get { return ddlWorkType.SelectedItem.Value; }
            set { ddlWorkType.SelectedValue = value; }
        }

        public string WorkTypeMessage
        {
            get { return MsgWorkType.Text; }
            set { MsgWorkType.Text = value; }
        }

        public string ResidentDate
        {
            get { return txtResidentDate.Text; }
            set { txtResidentDate.Text = value; }
        }

        public string ResidentDateMessage
        {
            get { return lblDateMsg.Text; }
            set { lblDateMsg.Text = value; }
        }

        public string Orgnaization
        {
            get { return txtResidentOrg.Text; }
            set { txtResidentOrg.Text = value; }
        }

        public List<WorkType> WorkTypeSource
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set
            {
                foreach (WorkType wt in value)
                {
                    ddlWorkType.Items.Add(new ListItem(wt.Name, wt.Id.ToString()));
                }
            }
        }

        public string SalaryCardNo
        {
            get { return txtSalaryCardNo.Text.Trim(); }
            set { txtSalaryCardNo.Text = value; }
        }

        public string SalaryCardBank
        {
            get { return txtSalaryCardBank.Text.Trim(); }
            set { txtSalaryCardBank.Text = value; }
        }
        #endregion

        #region EmployeeWelfare 公积金，社保
        /// <summary>
        /// 用于在查看员工历史时，员工福利不可见
        /// </summary>
        public bool EmployeeWelfareVisible
        {
            set
            {
                divWelfare.Visible = value;
                txtAccumulationFundAccount.Enabled = value;
                txtSupplyAccount.Enabled = value;
            }
        }
        public List<SocialSecurityTypeEnum> SocialSecurityTypeSource
        {
            get { return null; }
            set
            {
                foreach (SocialSecurityTypeEnum typeEnum in value)
                {
                    ListItem item = new ListItem(typeEnum.Name, typeEnum.Id.ToString(), true);
                    ddSocialSecurityType.Items.Add(item);
                }
            }
        }

        public string SocialSecurityBase
        {
            get { return txtSocialSecurityBase.Text.Trim(); }
            set { txtSocialSecurityBase.Text = value; }
        }

        public string SocialSecurityBaseMessage
        {
            get { return lbSocialSecurityBase.Text; }
            set
            {
                lbSocialSecurityBase.Text = value;
                lbSocialSecurityBase.Visible = string.IsNullOrEmpty(value) ? false : true;
            }
        }

        public List<string> SocialSecurityYearMonth
        {
            get
            {
                return
                    new List<string>(
                        new string[2] {txtSocialSecurityYear.Text.Trim(), txtSocialSecurityMonth.Text.Trim()});
            }
            set
            {
                if (value != null && value.Count == 2)
                {
                    txtSocialSecurityYear.Text = value[0];
                    txtSocialSecurityMonth.Text = value[1];
                }
                else
                {
                    txtSocialSecurityYear.Text = string.Empty;
                    txtSocialSecurityMonth.Text = string.Empty;
                }
            }
        }

        public string SocialSecurityYearMonthMessage
        {
            get { return lbSocialSecurityYearMonth.Text; }
            set
            {
                lbSocialSecurityYearMonth.Text = value;
                lbSocialSecurityYearMonth.Visible = string.IsNullOrEmpty(value) ? false : true;
            }
        }

        public string AccumulationFundAccount
        {
            get { return txtAccumulationFundAccount.Text.Trim(); }
            set { txtAccumulationFundAccount.Text = value;}
        }

        public string AccumulationFundAccountMessage
        {
            get { return lbAccumulationFundAccount.Text; }
            set { lbAccumulationFundAccount.Text = value; }
        }

        public string AccumulationFundBase
        {
            get { return txtAccumulationFundBase.Text.Trim(); }
            set { txtAccumulationFundBase.Text = value; }
        }

        public string AccumulationFundBaseMessage
        {
            get { return lbAccumulationFundBase.Text; }
            set { lbAccumulationFundBase.Text = value; }
        }

        public List<string> AccumulationFundYearMonth
        {
            get
            {
                return
                    new List<string>(
                        new string[2] {txtAccumulationFundYear.Text.Trim(), txtAccumulationFundMonth.Text.Trim()});
            }
            set
            {
                if (value != null && value.Count == 2)
                {
                    txtAccumulationFundYear.Text = value[0];
                    txtAccumulationFundMonth.Text = value[1];
                }
                else
                {
                    txtAccumulationFundYear.Text = string.Empty;
                    txtAccumulationFundMonth.Text = string.Empty;
                }
            }
        }

        public string AccumulationFundYearMonthMessage
        {
            get { return lbAccumulationFundYearMonth.Text; }
            set
            {
                lbAccumulationFundYearMonth.Text = value;
                lbAccumulationFundYearMonth.Visible = string.IsNullOrEmpty(value) ? false : true;
            }
        }


        public List<EmployeeWelfareHistory> EmployeeWelfareHistory
        {
            get { return _EmployeeWelfareHistory; }
            set
            {
                _EmployeeWelfareHistory = value;
                BindWelfareHistory();
            }
        }

        public string AccumulationFundSupplyAccount
        {
            get { return txtSupplyAccount.Text; }
            set
            {
                txtSupplyAccount.Text = value;
            }
        }

        public string AccumulationFundSupplyBase
        {
            get { return txtSupplyBase.Text; }
            set { txtSupplyBase.Text=value; }
        }

        public string AccumulationFundSupplyBaseMessage
        {
            get { return lblSupplyBase.Text; }
            set { lblSupplyBase.Text = value; }
        }

        public string WelfareDescription
        {
            set { txtWelfareDescription.Text = value; }
        }

        public string YangLaoBase
        {
            get { return txtYangLaoBase.Text.Trim(); }
            set { txtYangLaoBase.Text = value; }
        }

        public string ShiYeBase
        {
            get { return txtShiYeBase.Text.Trim(); }
            set { txtShiYeBase.Text = value; }
        }

        public string YiLiaoBase
        {
            get { return txtYiLiaoBase.Text.Trim(); }
            set { txtYiLiaoBase.Text = value; }
        }

        public string YangLaoBaseMessage
        {
            get { return lblYangLaoBase.Text.Trim(); }
            set { lblYangLaoBase.Text = value; }
        }

        public string ShiYeBaseMessage
        {
            get { return lblShiYeBase.Text.Trim(); }
            set { lblShiYeBase.Text = value; }
        }

        public string YiLiaoBaseMessage
        {
            get { return lblYiLiaoBase.Text.Trim(); }
            set { lblYiLiaoBase.Text = value; }
        }

        public SocialSecurityTypeEnum SocialSecurityType
        {
            get { return SocialSecurityTypeEnum.GetById(ddSocialSecurityType.SelectedIndex); }
            set { ddSocialSecurityType.SelectedIndex = value.Id; }
        }

        #endregion

        #endregion

        private void BindWelfareHistory()
        {
            tbWelfareHistory.Visible = EmployeeWelfareHistory == null || EmployeeWelfareHistory.Count < 1 ? false : true;
            gvWelfareHistory.DataSource = EmployeeWelfareHistory;
            gvWelfareHistory.DataBind();
        }

        protected void gvWelfareHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvWelfareHistory.PageIndex = e.NewPageIndex;
            BindWelfareHistory();
        }

        protected void gvWelfareHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }
    }
}