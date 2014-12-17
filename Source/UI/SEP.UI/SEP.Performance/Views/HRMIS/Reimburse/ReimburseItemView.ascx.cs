using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.Performance.Views.HRMIS.Reimburse
{
    public partial class ReimburseItemView : UserControl, IReimburseItemView
    {
        protected void btnOK_Click(object sender, EventArgs e)
        {
            btnOKClick(sender, e);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancelClick(sender, e);
        }

        public string Operation
        {
            set
            {
                lblOperation.Text = value;
            }
        }

        public List<ReimburseItem> ReimburseItemSource
        {
            get
            {
                //Session changed to ViewState modify by colbert
                return (List<ReimburseItem>)ViewState["_ReimburseItem"];
            }
            set
            {
                //Session changed to ViewState modify by colbert
                ViewState["_ReimburseItem"] = value;
            }
        }

        private bool _ActionSuccess;
        public bool ActionSuccess
        {
            get
            {
                return _ActionSuccess;
            }
            set
            {
                _ActionSuccess = value;
            }
        }

        //public string ConsumeDateFrom
        //{
        //    get
        //    {
        //        return dtpConsumeDateFrom.Text.Trim();
        //    }
        //    set
        //    {
        //        dtpConsumeDateFrom.Text = value;
        //    }
        //}

        //public string ConsumeDateTo
        //{
        //    get
        //    {
        //        return dtpConsumeDateTo.Text.Trim();
        //    }
        //    set
        //    {
        //        dtpConsumeDateTo.Text = value;
        //    }
        //}

        public string ConsumePlace
        {
            get
            {
                return txtConsumePlace.Text.Trim();
            }
            set
            {
                txtConsumePlace.Text = value;
            }
        }

        //public string PaperCount
        //{
        //    get
        //    {
        //        return txtPaperCount.Text.Trim();
        //    }
        //    set
        //    {
        //        txtPaperCount.Text = value;
        //    }
        //}

        //public string ProjectName
        //{
        //    get
        //    {
        //        return txtProjectName.Text.Trim();
        //    }
        //    set
        //    {
        //        txtProjectName.Text = value;
        //    }
        //}

        public string Reason
        {
            get
            {
                return txtReason.Text.Trim();
            }
            set
            {
                txtReason.Text = value;
            }
        }

        public ReimburseTypeEnum ReimburseType
        {
            get
            {
                return (ReimburseTypeEnum)(Convert.ToInt32(ddlReimburseType.SelectedValue));
            }
            set
            {
                ddlReimburseType.SelectedValue = ((int)value).ToString();
            }
        }

        public string TotalCost
        {
            get
            {
                return txtTotalCost.Text.Trim();
            }
            set
            {
                txtTotalCost.Text = value;
            }
        }

        public string Message
        {
            get { throw new NotImplementedException(); }
            set
            {
                lblMessage.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    tbMessage.Style["display"] = "none";
                }
                else
                {
                    tbMessage.Style["display"] = "block";
                }
            }
        }

        //public string ConsumeDateMsg
        //{
        //    get { throw new NotImplementedException(); }
        //    set { lblConsumeMsg.Text = value; }
        //}

        //public string ProjectNameMsg
        //{
        //    get { throw new NotImplementedException(); }
        //    set { lblProjectNameMsg.Text = value; }
        //}

        //public string PaperCountMsg
        //{
        //    get { throw new NotImplementedException(); }
        //    set { lblPaperCountMsg.Text = value; }
        //}

        public string TotalCostMsg
        {
            get { throw new NotImplementedException(); }
            set { lblTotalCostMsg.Text = value; }
        }

        public string ReasonMsg
        {
            get { throw new NotImplementedException(); }
            set { lblReasonMsg.Text = value; }
        }

        public string OperationType
        {
            get { return hfOperationType.Value; }
            set { hfOperationType.Value = value; }
        }

        public Dictionary<string, string> ReimburseTypeSource
        {
            get { throw new NotImplementedException(); }
            set
            {
                ddlReimburseType.Items.Clear();
                foreach (KeyValuePair<string, string> pair in value)
                {
                    ListItem item = new ListItem(pair.Value, pair.Key, true);
                    ddlReimburseType.Items.Add(item);
                }
            }
        }

        public string ReimburseItemID
        {
            get { return txtID.Text.Trim(); }
            set { txtID.Text = value; }
        }



        public bool SetFormReadonly
        {
            get { throw new NotImplementedException(); }
            set
            {
                txtConsumePlace.ReadOnly = value;
                //txtPaperCount.ReadOnly = value;
                txtReason.ReadOnly = value;
                txtTotalCost.ReadOnly = value;
                //txtProjectName.ReadOnly = value;
                //dtpConsumeDateTo.ReadOnly = value;
                //dtpConsumeDateFrom.ReadOnly = value;
                ddlReimburseType.Enabled = !value;
            }
        }

        private bool isTravelReimburse;
        public bool IsTravelReimburse
        {
            get
            {
                return isTravelReimburse;
            }
            set
            {
                if (!value)
                {
                    tdConsumePlace.Visible = false;
                    tdConsumePlacelb.Visible = false;
                    isTravelReimburse = false;
                }
                else
                {
                    tdConsumePlace.Visible = true;
                    tdConsumePlacelb.Visible = true;
                    isTravelReimburse = true;
                }
            }
        }

        public string CustomerNameCode
        {
            get { return txtCustomerCode.Text; }
            set { txtCustomerCode.Text = value; }
        }

        public string btnCancelOnClientClick
        {
            set { btnCancel.OnClientClick = value; }
        }


        public event EventHandler btnCancelClick;

        public event EventHandler btnOKClick;

        public event EventHandler btnCustomerCodeChange;

        public int? CustomerID
        {
            get
            {
                if (!string.IsNullOrEmpty(txtCustomerID.Value))
                {
                    return Convert.ToInt32(txtCustomerID.Value);
                }
                return null;
            }
            set { txtCustomerID.Value = value == null ? "" : value.ToString(); }
        }

        public string CustomerName
        {
            get { return lblCustomerName.Text; }
            set { lblCustomerName.Text = value; }
        }

        public string CustomerNameError
        {
            get { return lblCustomerNameError.Text; }
            set { lblCustomerNameError.Text = value; }
        }

        protected void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            var code = txtCustomerCode.Text.Trim();
            lblCustomerNameError.Text = "";
            txtCustomerID.Value = "";
            lblCustomerName.Text = "";
            if (!string.IsNullOrEmpty(code))
            {
                var customer = CustomerInfoLogic.GetCustomerInfoByCode(code);
                if (customer != null)
                {
                    lblCustomerName.Text = customer.CompanyName.Replace(code + " ", "");
                    txtCustomerID.Value = customer.PKID.ToString();
                }
                else
                {
                    lblCustomerNameError.Text = "²»´æÔÚ¸Ã±àºÅ";
                    txtCustomerID.Value = "";
                    lblCustomerName.Text = "";
                }
            }
            btnCustomerCodeChange(sender, e);
        }

    }
}