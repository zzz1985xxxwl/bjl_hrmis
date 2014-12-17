using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter;
using SEP.Performance.Views;

namespace SEP.Performance
{
    public partial class VacationUsedDetailsView : UserControl, IVacationUsedDetailsView
    {
        private Employee _Employee;
        private List<LeaveRequestItem> _LeaveRequestItemList;

        protected void Page_Load(object sender, EventArgs e)
        {
            new VacationUsedDetailsPresenter(this);
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gdUsedDetail.PageIndex = pageindex;
            BindLeaveRequestList();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gdUsedDetail, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void gdUsedDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdUsedDetail.PageIndex = e.NewPageIndex;
            BindLeaveRequestList();
        }

        private void BindLeaveRequestList()
        {
            if (_LeaveRequestItemList == null || _LeaveRequestItemList.Count < 1)
            {
                UsedDetail.Visible = false;
            }
            else
            {
                gdUsedDetail.DataSource = _LeaveRequestItemList;
                gdUsedDetail.DataBind();
            }
        }

        #region 接口

        public Employee Employee
        {
            get
            {
                if (_Employee == null)
                {
                    _Employee = new Employee();
                    _Employee.Account.Id = 0;
                    _Employee.Account.Name = "";
                }
                return _Employee;
            }
            set { _Employee = value; }
        }

      
        public List<LeaveRequestItem> LeaveRequestItemList
        {
            get { throw new NotImplementedException(); }
            set
            {
                _LeaveRequestItemList = value;
                BindLeaveRequestList();
            }
        }

        #endregion

        #region 鼠标在行之间移动时的动态效果

        protected void gdUsedDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        #endregion
    }
}