using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeAttendance;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.EmployeeAttendance
{
    public partial class RecordAttendanceView : UserControl, IRecordAttendanceView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancle.Attributes["onclick"] = "return CloseModalPopupExtender('divMPERecordAttendanceView');";
        }
        //新增按钮事件
        public event DelegateNoParameter ActionButtonEvent;
        //选择的类型改变事件
        public event DelegateNoParameter OnSelectTypeChange;
        //删除的按钮事件
        public event DelegateNoParameter CancelButtonEvent;
        //新增是否成功
        private bool _IfAddSuccess;

        protected void btnAction_Click(object sender, EventArgs e)
        {
            ActionButtonEvent();
        }

        protected void ddlTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnSelectTypeChange == null)
            {
                throw new Exception("按钮未绑定事件");
            }
            OnSelectTypeChange();
        }

        public string Message
        {
            get
            {
                return msgMessage.Text;
            }
            set
            {
                msgMessage.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    tbResultMessage.Style["display"] = "none";
                }
                else
                {
                    tbResultMessage.Style["display"] = "block";
                }
            }

        }

        public string EmployeeName
        {
            get
            {
                return Request["txtEmployeeName"];
            }
            set
            {
                lblEmployeeName.Text = value;
            }
        }

        public string EmployeeNameMessage
        {
            get
            {
                return msgEmployeeName.Text;
            }
            set
            {
                msgEmployeeName.Text = value;
            }
        }

        public string TheDay
        {
            get
            {
                return txtTheDay.Text;
            }
            set
            {
                txtTheDay.Text = value;
            }
        }

        public string TheDayMessage
        {
            get
            {
                return msgTheDay.Text;
            }
            set
            {
                msgTheDay.Text = value;
            }
        }

        public string InfluenceTime
        {
            get
            {
                return txtMinutes.Text;
            }
            set
            {
                txtMinutes.Text = value;
            }
        }

        public bool MinutesVisable
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                lblMinutes.Text = value ? "分&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;钟" : "天&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;数";
            }
        }

        public string InfluenceTimeMessage
        {
            get
            {
                return msgMinutes.Text;
            }
            set
            {
                msgMinutes.Text = value;
            }
        }

        public System.Collections.Generic.List<string> AttendanceTypes
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                ddlTypes.DataSource = value;
                ddlTypes.DataBind();
            }
        }

        public string SelectedType
        {
            get
            {
                return ddlTypes.SelectedValue;
            }
            set
            {
                ddlTypes.SelectedValue = value;
            }
        }

        public string AttendanceTypeMessage
        {
            get
            {
                return msgTypes.Text;
            }
            set
            {
                msgTypes.Text = value;
            }
        }

        public string OperationType
        {
            get { return Operation.Value; }
            set { Operation.Value = value; }
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            CancelButtonEvent();
        }

        public void Clear()
        {
            ddlTypes.Items.Clear();
        }

        public bool IsAddSuccess
        {
            get
            {
                return _IfAddSuccess;
            }
            set
            {
                _IfAddSuccess = value;
            }
        }
    }
}