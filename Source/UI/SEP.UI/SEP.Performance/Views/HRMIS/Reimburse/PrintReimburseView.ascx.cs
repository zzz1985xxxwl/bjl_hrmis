using System;
using System.Collections.Generic;
using System.Web.UI;
using SEP.HRMIS.Model;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.Performance.Views.HRMIS.Reimburse
{

    public partial class PrintReimburseView : UserControl, IPrintReimburseView
    {
        public hrmisModel.Employee Employee
        {
            get { throw new NotImplementedException(); }
            set { lblApplier.Text = value.Account.Name; }
        }

        public hrmisModel.Reimburse Reimburse
        {
            get { throw new NotImplementedException(); }
            set
            {
                lblApplyDate.Text = value.ApplyDate.ToShortDateString();
                lblTotalCost.Text = value.TotalCost.ToString();
                lblTotalCostCH.Text = value.TotalCostCH;
                lblExchangeSymbol.Text = value.ExchangeSymbol;
                lblExchangeRateName.Text = value.ExchangeRateName;
                lblDiscription.Text = value.Discription;
            }
        }

        public string Title
        {
            get { throw new NotImplementedException(); }
            set { lblTitle.Text = value; }
        }

        public string DepartmentName
        {
            get { throw new NotImplementedException(); }
            set { lblDepartment.Text = value; }
        }

        //public string CompanyName
        //{
        //    get { throw new NotImplementedException(); }
        //    set { lblCompany.Text = value; }
        //}
        //public bool IsTravelReimburse
        //{
        //    get { throw new NotImplementedException(); }
        //    set
        //    {
        //        if (!value)
        //        {
        //            isHidden1.Style["display"] = "none";
        //            isHidden2.Style["display"] = "none";
        //            isHidden3.Style["display"] = "none";

        //        }
        //        else
        //        {
        //            isHidden1.Style["display"] = "block";
        //            isHidden2.Style["display"] = "block";
        //            isHidden3.Style["display"] = "block";
        //        }
        //    }
        //}

        public string Destinations
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public string CustomerName
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public string ProjectName
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public string PaperCount
        {
            get { throw new NotImplementedException(); }
            set { lblPaperCount.Text = value; }
        }

        public string ConsumeDate
        {
            get { throw new NotImplementedException(); }
            set { lblConsumeDate.Text = value; }
        }



        public List<ReimburseItem> ReimburseItemSource
        {
            get { throw new NotImplementedException(); }
            set
            {
                gvReimburseItem.DataSource = value;
                gvReimburseItem.DataBind();
                if (value == null || value.Count == 0)
                {
                    tbReimburseItem.Style["display"] = "none";
                }
                else
                {
                    tbReimburseItem.Style["display"] = "block";
                }
            }
        }

        #region CEO电子签名

        public byte[] CEOElectricName
        {
            get
            {
                return CEOElectricNameArray;
            }
            set
            {
                CEOElectricNameArray = value;
                if (value != null)
                {
                    imgCEO.Visible = true;
                    imgCEO.ImageUrl = "../../../Pages/HRMIS/ReimbursePages/CEOElectricNameResponse.aspx?CEOElectricNameSessionName=" + CEOElectricNameSessionName;
                }
            }
        }

        /// <summary>
        /// SessionName
        /// </summary>
        private string CEOElectricNameSessionName
        {
            get
            {
                if (ViewState["CEOElectricNameViewStateName"] == null)
                {
                    Guid guid = Guid.NewGuid();
                    ViewState["CEOElectricNameViewStateName"] = guid.ToString();
                }
                return ViewState["CEOElectricNameViewStateName"].ToString();
            }
        }
        private byte[] CEOElectricNameArray
        {
            get { return Session[CEOElectricNameSessionName] as byte[]; }
            set { Session[CEOElectricNameSessionName] = value; }
        }

        #endregion

        #region 财务电子签名
        public byte[] FinanceElectricName
        {
            get
            {
                return FinanceElectricNameArray;
            }
            set
            {
                FinanceElectricNameArray = value;
                if (value != null)
                {
                    imgFinance.Visible = true;
                    imgFinance.ImageUrl = "../../../Pages/HRMIS/ReimbursePages/FinanceElectricNameResponse.aspx?FinanceElectricNameSessionName=" + FinanceElectricNameSessionName;
                }
            }
        }

        /// <summary>
        /// SessionName
        /// </summary>
        private string FinanceElectricNameSessionName
        {
            get
            {
                if (ViewState["FinanceElectricNameViewStateName"] == null)
                {
                    Guid guid = Guid.NewGuid();
                    ViewState["FinanceElectricNameViewStateName"] = guid.ToString();
                }
                return ViewState["FinanceElectricNameViewStateName"].ToString();
            }
        }
        private byte[] FinanceElectricNameArray
        {
            get { return Session[FinanceElectricNameSessionName] as byte[]; }
            set { Session[FinanceElectricNameSessionName] = value; }
        }
        #endregion

        #region 部门经理电子签名
        public byte[] DepartmentLeaderElectricName
        {
            get
            {
                return DepartmentLeaderElectricNameArray;
            }
            set
            {
                DepartmentLeaderElectricNameArray = value;
                if (value != null)
                {
                    imgDepartmentLeader.Visible = true;
                    imgDepartmentLeader.ImageUrl = "../../../Pages/HRMIS/ReimbursePages/DepartmentLeaderElectricNameResponse.aspx?DepartmentLeaderElectricNameSessionName=" + DepartmentLeaderElectricNameSessionName;
                }
            }
        }

        /// <summary>
        /// SessionName
        /// </summary>
        private string DepartmentLeaderElectricNameSessionName
        {
            get
            {
                if (ViewState["DepartmentLeaderElectricNameViewStateName"] == null)
                {
                    Guid guid = Guid.NewGuid();
                    ViewState["DepartmentLeaderElectricNameViewStateName"] = guid.ToString();
                }
                return ViewState["DepartmentLeaderElectricNameViewStateName"].ToString();
            }
        }
        private byte[] DepartmentLeaderElectricNameArray
        {
            get { return Session[DepartmentLeaderElectricNameSessionName] as byte[]; }
            set { Session[DepartmentLeaderElectricNameSessionName] = value; }
        }
        #endregion

        #region 领款人电子签名
        //public byte[] RecipientsElectricName
        //{
        //    get
        //    {
        //        return RecipientsElectricNameArray;
        //    }
        //    set
        //    {
        //        RecipientsElectricNameArray = value;
        //        if (value != null)
        //        {
        //            imgRecipients.Visible = true;
        //            imgRecipients.ImageUrl = "/../../Pages/HRMIS/ReimbursePages/RecipientsElectricNameResponse.aspx?RecipientsElectricNameSessionName=" + RecipientsElectricNameSessionName;
        //        }
        //    }
        //}

        ///// <summary>
        ///// SessionName
        ///// </summary>
        //private string RecipientsElectricNameSessionName
        //{
        //    get
        //    {
        //        if (ViewState["RecipientsElectricNameViewStateName"] == null)
        //        {
        //            Guid guid = Guid.NewGuid();
        //            ViewState["RecipientsElectricNameViewStateName"] = guid.ToString();
        //        }
        //        return ViewState["RecipientsElectricNameViewStateName"].ToString();
        //    }
        //}
        //private byte[] RecipientsElectricNameArray
        //{
        //    get { return Session[RecipientsElectricNameSessionName] as byte[]; }
        //    set { Session[RecipientsElectricNameSessionName] = value; }
        //}

        #endregion


    }
}