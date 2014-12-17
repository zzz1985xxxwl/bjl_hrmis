using System;
using System.Collections.Generic;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.PlanDutyViews
{
    public partial class DutyClassView : UserControl, IDutyClassView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancel.Attributes["onclick"] = "return CloseModalPopupExtender('divMPE');";
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            ActionButtonEvent();
        }

        #region IPlanDutyView

        public event DelegateNoParameter ActionButtonEvent;
        public event DelegateNoParameter CancelButtonEvent;

        public string Message
        {
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

        public string DutyClassId
        {
            get { return dutyClassId.Value; }
            set { dutyClassId.Value = value; }
        }

        public string DutyClassName
        {
            get { return txtDutyClassName.Text.Trim(); }
            set { txtDutyClassName.Text = value; }
        }

        public string DutyClassNameMessage
        {
            set { lblDutyClassMessage.Text = value; }
        }
        /// <summary>
        /// 上午上班时间范围
        /// </summary>
        public string FirstStartFromTime
        {
            get { return string.Format("{0} {1}:{2}", DateTime.Now.ToShortDateString(), listHour1.Text, listMinutes1.Text); }
            set
            {
                DateTime temp = Convert.ToDateTime(value);
                string[] t = temp.ToShortTimeString().Split(':');
                listHour1.Text = t[0];
                listMinutes1.Text = t[1];
            }
        }

        /// <summary>
        /// 上午上班时间范围
        /// </summary>
        public string FirstStartToTime
        {
            get { return string.Format("{0} {1}:{2}", DateTime.Now.ToShortDateString(), listHour2.Text, listMinutes2.Text); }
            set
            {
                DateTime temp = Convert.ToDateTime(value);
                string[] t = temp.ToShortTimeString().Split(':');
                listHour2.Text = t[0];
                listMinutes2.Text = t[1];
            }
        }
        /// <summary>
        /// 上午下班时间
        /// </summary>
        public string FirstEndTime
        {
            get { return string.Format("{0} {1}:{2}", DateTime.Now.ToShortDateString(), listHour3.Text, listMinutes3.Text); }
            set
            {
                DateTime temp = Convert.ToDateTime(value);
                string[] t = temp.ToShortTimeString().Split(':');
                listHour3.Text = t[0];
                listMinutes3.Text = t[1];
            }
        }
        /// <summary>
        /// 下午上班时间
        /// </summary>
        public string SecondStartTime
        {
            get { return string.Format("{0} {1}:{2}", DateTime.Now.ToShortDateString(), listHour4.Text, listMinutes4.Text); }
            set
            {
                DateTime temp = Convert.ToDateTime(value);
                string[] t = temp.ToShortTimeString().Split(':');
                listHour4.Text = t[0];
                listMinutes4.Text = t[1];
            }
        }
        /// <summary>
        /// 下午下班时间
        /// </summary>
        public string SecondEndTime
        {
            get { return string.Format("{0} {1}:{2}", DateTime.Now.ToShortDateString(), listHour5.Text, listMinutes5.Text); }
            set
            {
                DateTime temp = Convert.ToDateTime(value);
                string[] t = temp.ToShortTimeString().Split(':');
                listHour5.Text = t[0];
                listMinutes5.Text = t[1];
            }
        }

        public string WorkAllTime
        {
            get
            {
                return txtAllLimit.Text.Trim();
            }
            set
            {
                txtAllLimit.Text = value;
            }
        }
        public string WorkTimeMessage
        {
            set { lblWorkTimeMessage.Text = value; }
        }

        public string LateTime
        {
            get { return txtLateLimit.Text; }
            set { txtLateLimit.Text = value; }
        }

        public string LateMessage
        {
            set { lblLateLimitMessage.Text = value; }
        }

        public string EarlyLeaveTime
        {
            get { return txtEarlyLeaveLimit.Text; }
            set { txtEarlyLeaveLimit.Text = value; }
        }

        public string EarlyLeaveMessage
        {
            set { lblEarlyLeaveLimitMessage.Text = value; }
        }

        public string AbsentLateTime
        {
            get { return txtLate.Text; }
            set { txtLate.Text = value; }
        }

        public string AbsentLateMessage
        {
            set { lblLateMessage.Text = value; }
        }

        public string AbsentEarlyLeaveTime
        {
            get { return txtEarly.Text; }
            set { txtEarly.Text = value; }
        }

        public string AbsentEarlyLeaveMessage
        {
            set { lblEarlyLeaveMessage.Text = value; }
        }
      
        public string OperationTitle
        {
            get { return lblOperation.Text; }
            set { lblOperation.Text = value; }
        }



        private bool actionSuccess;
        public bool ActionSuccess
        {
            get { return actionSuccess; }
            set { actionSuccess = value; }
        }

        public string OperationType
        {
            get { return Operation.Value; }
            set { Operation.Value = value; }
        }

        public List<string> HoursSource
        {
            set
            {
                listHour1.Items.Clear();
                listHour2.Items.Clear();
                listHour3.Items.Clear();
                listHour4.Items.Clear();
                listHour5.Items.Clear();
                foreach (string s in value)
                {
                    listHour1.Items.Add(s);
                    listHour2.Items.Add(s);
                    listHour3.Items.Add(s);
                    listHour4.Items.Add(s);
                    listHour5.Items.Add(s);
                }
            }
        }

        public List<string> MinutesSource
        {
            set
            {
                listMinutes1.Items.Clear();
                listMinutes2.Items.Clear();
                listMinutes3.Items.Clear();
                listMinutes4.Items.Clear();
                listMinutes5.Items.Clear();

                foreach (string s in value)
                {
                    listMinutes1.Items.Add(s);
                    listMinutes2.Items.Add(s);
                    listMinutes3.Items.Add(s);
                    listMinutes4.Items.Add(s);
                    listMinutes5.Items.Add(s);
                }
            }
        }

        #endregion
    }
}