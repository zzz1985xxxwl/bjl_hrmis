// All rights reserved.
// 文件名: InAndOutStatisticsBuildPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-10-17
// 概述: 
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;
using SEP.HRMIS.Presenter.AttendanceStatistics.AttendanceReadData;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IAttendanceInAndOutStatistics;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.AttendanceStatistics.AttendanceInAndOutStatistics
{
    public class InAndOutStatisticsBuildPresenter : SEP.Presenter.Core.BasePresenter
    {
        private readonly IInAndOutStatisticsBuildView _ItsView;
        private readonly InAndOutStatisticsPresenter _TheBasicPresenter;
        private readonly IAttendanceReadDataFacade _IAttendanceReadDataFacade = InstanceFactory.CreateAttendanceReadDataFacade();

        public InAndOutStatisticsBuildPresenter(IInAndOutStatisticsBuildView itsView, Account loginUser)
            : base(loginUser)
        {
            _ItsView = itsView;
            _TheBasicPresenter = new InAndOutStatisticsPresenter(itsView.InAndOutStatisticsView, LoginUser);
            SwitchLittleViewPresenter();
            AttachViewEvent();
            _ItsView.Message = "";
        }
        #region CreateAttendanceForOperatorPresenter
        public string CreateAttendancelEvent()
        {
            if (_ItsView.EmployeeList.Count == 0)
            {
                return "";
            }
            if (VaildateTime())
            {
                _IAttendanceReadDataFacade.UpdateAttendanceForOperator(_SearchFrom, _SearchTo, _ItsView.EmployeeList, LoginUser);
                return "生成" + _ItsView.EmployeeList.Count + "个员工，从" + _ItsView.SearchFrom + "至" + _ItsView.SearchTo + "的考勤统计！";
            }

            return "因为时间设置格式不正确，生成考勤统计失败！";
        }
        private static DateTime _SearchFrom;
        private static DateTime _SearchTo;

        private bool VaildateTime()
        {
            if (!DateTime.TryParse(_ItsView.SearchFrom, out _SearchFrom))
            {
                return false;
            }
            if (_SearchFrom.Equals(Convert.ToDateTime("0001-1-1 0:00:00")))
            {
                _SearchFrom = Convert.ToDateTime("1900-1-1 0:00:00");
            }
            if (!DateTime.TryParse(_ItsView.SearchTo, out _SearchTo))
            {
                return false;
            }
            if (_SearchTo.Equals(Convert.ToDateTime("0001-1-1 0:00:00")))
            {
                _SearchTo = Convert.ToDateTime("2900-12-31 0:00:00");
            }
            return true;
        }
        #endregion

        private void SwitchLittleViewPresenter()
        {
            new SetReadRulePresenter(_ItsView.ReadAttendanceRuleView, LoginUser);
            new ReadHistoryListPresenter(_ItsView.ReadHistoryListView, LoginUser);
        }

        public void AttachViewEvent()
        {
            //大界面按钮
            _ItsView.InAndOutStatisticsView.BtnReadAccessDataEvent += ShowReadHistoryListView;
            _ItsView.InAndOutStatisticsView.BtnSetReadTimeEvent += ShowReadAttendanceRuleView;
            _ItsView.InAndOutStatisticsView.BtnReadExcelDataEvent += ShowCreateAttendanceForOperatorView;
            //小界面按钮
            _ItsView.ReadAttendanceRuleView.BtnConfrimEvent += ActionEvent;
            _ItsView.ReadHistoryListView.BtnReadEvent += ReadDataEvent;
            _ItsView.ReadHistoryListView.BindDataEvent += ShowReadHistoryListViewForPageChanging;
            _ItsView.ReadHistoryListView.BtnCancelEvent += CancelEvent;
            _ItsView.ReadAttendanceRuleView.BtnCancelEvent += CancelEvent;
            _ItsView.ShowCreateAttendanceForOperator
                += ShowCreateAttendanceForOperatorViewForPageChanging;
            _ItsView.BtnReadFromXLSEvent += ReadFromXLSEvent;
            _ItsView.BtnCancelEvent += CancelEvent;

            _ItsView.ChoseEmployeeView.SearchAccountEvent
                += ShowCreateAttendanceForOperatorViewForPageChanging;
            _ItsView.ChoseEmployeeView.ToLeftEvent
                += ShowCreateAttendanceForOperatorViewForPageChanging;
            _ItsView.ChoseEmployeeView.ToRightEvent
                += ShowCreateAttendanceForOperatorViewForPageChanging;
            _ItsView.ChoseEmployeeView.CloseEvent
                += ShowCreateAttendanceForOperatorViewForPageChanging;
        }
        public void CancelEvent()
        {
            _ItsView.ReadHistoryListViewVisible = false;
            _ItsView.ReadAttendanceRuleViewVisible = false;
        }
        private void ShowReadHistoryListViewForPageChanging()
        {
            _ItsView.ReadHistoryListViewVisible = true;
        }
        private void ShowCreateAttendanceForOperatorViewForPageChanging()
        {
            _ItsView.CreateAttendanceForOperatorViewVisible = true;
        }
        private void ShowCreateAttendanceForOperatorViewForPageChanging(object sender, EventArgs e)
        {
            _ItsView.CreateAttendanceForOperatorViewVisible = true;
        }
        private void ShowReadHistoryListView()
        {
            new ReadHistoryListPresenter(_ItsView.ReadHistoryListView, LoginUser).InitView(false);
            _ItsView.ReadHistoryListViewVisible = true;
        }

        private void ShowCreateAttendanceForOperatorView()
        {
            _ItsView.CreateAttendanceForOperatorViewVisible = true;
        }
        private void ShowReadAttendanceRuleView()
        {
            new SetReadRulePresenter(_ItsView.ReadAttendanceRuleView, LoginUser).InitView(false);
            _ItsView.ReadAttendanceRuleViewVisible = true;
        }
        public void ReadDataEvent()
        {
            if (_ItsView.ReadHistoryListView.IsReadSuccess)
            {
                _TheBasicPresenter.InAndOutStatisticsDataBind();
                _ItsView.ReadHistoryListViewVisible = false;
            }
            else
            {
                _ItsView.ReadHistoryListViewVisible = true;
            }
        }

        public void ReadFromXLSEvent(string filePath)
        {
            //ShowCreateAttendanceForOperatorView();
            _ItsView.Message = "";
            ReadDataHistory readHistory = _IAttendanceReadDataFacade.GetLastReadDataHistory( LoginUser);
            if (readHistory != null && readHistory.ReadResult == ReadDataResultType.Reading)
            {
                _ItsView.Message = "<span class='fontred'>正在读取数据中请稍候再试！</span>";
                return;
            }
            try
            {
                int employeeCount;
                int Count;
                _IAttendanceReadDataFacade.ImportFromXLS(filePath, out employeeCount, out Count, LoginUser);
                string resultMessage = "共导入系统" + employeeCount + "个员工；" + Count + "条考勤数据！";
                string result=CreateAttendancelEvent();
                if(result!="")
                {
                    resultMessage = resultMessage + result;
                }
                _ItsView.Message = "<span class='fontred'>" + resultMessage + "</span>";
            }
            catch (Exception ex)
            {
                _ItsView.Message = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        public void ActionEvent()
        {
            if (_ItsView.ReadAttendanceRuleView.IsActionSuccess)
            {
                _TheBasicPresenter.InAndOutStatisticsDataBind();
                _ItsView.ReadAttendanceRuleViewVisible = false;
            }
            else
            {
                _ItsView.ReadAttendanceRuleViewVisible = true;
            }
        }

        public void InitView(bool pageIsPostBack)
        {
            _TheBasicPresenter.InitView(pageIsPostBack);
        }

        public override void Initialize(bool isPostBack)
        {
            throw new NotImplementedException();
        }
    }
}
