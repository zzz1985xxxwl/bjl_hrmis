using System;
using System.Collections.Generic;
using System.Web.UI;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.Performance.Views.HRMIS.Reimburse
{
    public partial class EmployeeReimburseView : UserControl, IEmployeeReimburseView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.Page.GetType(), "init", "BinGoogledown();", true);
        } 
              

        public IReimburseView IReimburseView
        {
            get
            {
                return ReimburseView1;
            }
            set { throw new NotImplementedException(); }
        }

        public IReimburseItemView IReimburseItemView
        {
            get
            {
                return ReimburseItemView1;
            }
            set { throw new NotImplementedException(); }
        }

        public bool ReimburseItemVisiable
        {
            get { throw new NotImplementedException(); }
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

        public string divMPEReimburseClientID
        {
            get { return divMPEReimburse.ClientID; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            ReimburseView1.SendReimburseItems = SendReimburseItems;
        }

        private void SendReimburseItems(List<ReimburseItem> reimburseItems)
        {
            ReimburseItemView1.ReimburseItemSource = reimburseItems;
        }
    }
}