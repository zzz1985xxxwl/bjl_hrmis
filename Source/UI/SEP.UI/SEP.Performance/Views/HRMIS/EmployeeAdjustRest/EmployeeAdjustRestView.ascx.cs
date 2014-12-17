using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.HRMIS.Model.Enum;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeAdjustRest;
using ShiXin.Security;

namespace SEP.Performance.Views.HRMIS.EmployeeAdjustRest
{
    public partial class EmployeeAdjustRestView : UserControl, IEmployeeAdjustRestView
    {
        protected void gvAdjustRestHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAdjustRestHistory.PageIndex = e.NewPageIndex;
        }

        protected void gvAdjustRestHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        public string Message
        {
            set 
            {
                lblMessage.Text = value;
                if(string.IsNullOrEmpty(value))
                {
                    tbMessage.Visible = false;
                }
                else
                {
                    tbMessage.Visible = true;
                }
            }
        }

        public string SurplusHours
        {
            set { lblSurplusHours.Text = value; }
        }

        public string EmployeeName
        {
            set { lblOperation.Text = value + "的调休"; }
        }

        public int AccountID
        {
            set { hfAccountID.Value = value.ToString(); }
        }

        private List<AdjustRestHistory> _AdjustRestHistorySource;
        public List<AdjustRestHistory> AdjustRestHistorySource
        {
            get { return _AdjustRestHistorySource; }
            set
            {
                _AdjustRestHistorySource = value;
                gvAdjustRestHistory.DataSource = value;
                gvAdjustRestHistory.DataBind();
                if (value.Count == 0)
                {
                    Result.Visible = false;
                }
                else
                {
                    Result.Visible = true;
                }
            }
        }
        public string UrlDetail(AdjustRestHistoryTypeEnum adjustRestHistoryTypeEnum, int relevantID)
        {
            switch (adjustRestHistoryTypeEnum)
            {
                case AdjustRestHistoryTypeEnum.AdjustRestRequest:
                    return
                        "<a href='../LeaveRequestPages/LeaveRequestDetail.aspx?LeaveRequestID=" +
                        SecurityUtil.DECEncrypt(relevantID.ToString()) + "' target='_blank'>查看调休详情</a>";
                case AdjustRestHistoryTypeEnum.OverWork:
                    return
                        "<a href='../OverWorkPages/OverWorkDetail.aspx?PKID=" +
                        SecurityUtil.DECEncrypt(relevantID.ToString()) + "' target='_blank'>查看加班详情</a>";

                case AdjustRestHistoryTypeEnum.OutCityApplication:
                    return
                        "<a href='../OutApplicationPages/OutApplicationDetail.aspx?PKID=" +
                        SecurityUtil.DECEncrypt(relevantID.ToString()) + "' target='_blank'>查看出差详情</a>";

                default:
                    return string.Empty;
            }
            
        }
    }
}