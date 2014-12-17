
using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.SpecialDates;

namespace SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter
{
    public class PlanDutyUtility
    {
        public const string AddPageTitle = "新增排班表";
        public const string UpdatePageTitle = "修改排班表";
        public const string DetailPageTitle = "查看排班表";
        public const string SessionCopyPlanDutyTable = "SessionCopyPlanDutyTable";

        private readonly ISetPlanDutyInfoView _ItsView;
        private readonly IPlanDutyFacade _IPlanDutyFacade;
        private DateTime fromTime;
        private DateTime toTime;
        private int period = 0;
        private readonly Account _Account;

        public PlanDutyUtility(ISetPlanDutyInfoView itsView, IPlanDutyFacade iPlanDutyFacade, Account account)
        {
            _IPlanDutyFacade = iPlanDutyFacade;
            _ItsView = itsView;
            _Account = account;
        }

        private DateTime _Date;
        private int _DutyClassID;

        public List<PlanDutyDetail> InitNewPlanDutyDetailList(DateTime date)
        {
            List<PlanDutyDetail> planDutyDetailList = new List<PlanDutyDetail>();
            DateTime monthFrom = date.AddDays(1 - date.Day);
            DateTime monthTo = date.AddDays(1 - date.Day).AddMonths(1).AddDays(-1);
            DateTime temp = monthFrom;

            #region 如果有周期则找出周期值

            bool isCaculatePeriod = false;
            int[] periodValue = new int[0];
            //如果周期已经设定，且设定为大于0的整数
            if (!string.IsNullOrEmpty(_ItsView.SetPlanDutyView.Period.Trim()) &&
                                     Int32.TryParse(_ItsView.SetPlanDutyView.Period, out period) &&
                                     period > 0)
            {
                List<PlanDutyDetail> lastPlanDutyDetailList =
                    _ItsView.SetPlanDutyView.GetViewState(date.AddMonths(-1).Year + ";" + date.AddMonths(-1).Month);
                //并且可以找到上个月的ViewState,则可以计算周期
                isCaculatePeriod = lastPlanDutyDetailList != null;
                if (isCaculatePeriod)
                {
                    //找出周期值
                    periodValue = new int[period];
                    _Date = monthFrom.AddDays(-period - 1);
                    for (int i = 0; i < period; i++)
                    {
                        _Date = _Date.AddDays(1);
                        PlanDutyDetail planDutyDetail = lastPlanDutyDetailList.Find(FindOnePlanDutyDetail);
                        if (planDutyDetail != null)
                        {
                            periodValue[i] = planDutyDetail.PlanDutyClass.DutyClassID;
                        }
                        else//如果有找不到周期则不计算
                        {
                            isCaculatePeriod = false;
                            break;
                        }
                    }
                }
            }
            #endregion
            while (DateTime.Compare(temp, monthTo) <= 0)
            {
                _Date = temp;
                SpecialDate specialDate = specialDateList.Find(FindSpecialDate);
                PlanDutyDetail planDutyDetail = new PlanDutyDetail();
                planDutyDetail.Date = temp;
                planDutyDetail.PlanDutyClass = new DutyClass();
                if (isCaculatePeriod && periodValue.Length > 0)//如果计算周期
                {
                    planDutyDetail.PlanDutyClass.DutyClassID = periodValue[(temp.Day - monthFrom.Day) % period];
                }
                else//否则绑定公司特殊日期
                {
                    if (specialDate != null && dutyClassList.Count > 0)
                    {
                        planDutyDetail.PlanDutyClass.DutyClassID = specialDate.IsWork == 1 ? 1 : -1;
                    }
                    else
                    {
                        //如果不是周末，且有班别类表
                        if (temp.DayOfWeek != DayOfWeek.Saturday &&
                            temp.DayOfWeek != DayOfWeek.Sunday &&
                            dutyClassList.Count > 0)
                        {
                            planDutyDetail.PlanDutyClass.DutyClassID = 1;
                        }
                        else
                        {
                            planDutyDetail.PlanDutyClass.DutyClassID = -1;
                        }
                    }
                }
                planDutyDetailList.Add(planDutyDetail);
                temp = temp.AddDays(1);
            }
            return planDutyDetailList;
        }
        private List<SpecialDate> specialDateList;
        private List<DutyClass> dutyClassList;
        public void InitView(bool IsPostBack)
        {
            specialDateList = BllInstance.SpecialDateBllInstance.GetAllSpecialDate(_Account);
            dutyClassList = _IPlanDutyFacade.GetDutyClassByCondition(-1, "");
            if (!IsPostBack)
            {
                if (specialDateList.Count > 0)
                {
                    _ItsView.SetPlanDutyView.SpecialDates = specialDateList;
                }
                _ItsView.SetPlanDutyView.DutyClassList = dutyClassList;
            }
            _ItsView.SetPlanDutyView.SetbtnPlasterPlanDuty = _ItsView.SetPlanDutyView.SessionCopyPlanDutyTable != null;
            _ItsView.SetPlanDutyView.Message = string.Empty;
            _ItsView.ReplaceDutyClassView.Message = string.Empty;
            _ItsView.SetPlanDutyView.PlanDutyNameMessage = string.Empty;
            _ItsView.SetPlanDutyView.TimeMessage = string.Empty;
            _ItsView.SetPlanDutyView.PeriodMessage = string.Empty;

        }

        public void GetPlanDutyByID(string id)
        {
            int id_Int;
            if (!int.TryParse(id, out id_Int))
            {
                _ItsView.SetPlanDutyView.Message = "排班表ID需为整数";
                return;
            }
            _ItsView.SetPlanDutyView.PlanDutyID = id;
            PlanDutyTable planDutyTable = _IPlanDutyFacade.GetPlanDutyTableByPKID(id_Int);
            new PlanDudyBinder(_ItsView, _IPlanDutyFacade).DataBind(planDutyTable);
        }

        /// <summary>
        /// 查找在时间范围内PlanDutyDetail
        /// </summary>
        /// <param name="planDutyDetail"></param>
        /// <returns></returns>
        public bool FindPlanDutyDetail(PlanDutyDetail planDutyDetail)
        {
            if (DateTime.Compare(planDutyDetail.Date.Date, _Date) >= 0 &&
                DateTime.Compare(toTime, planDutyDetail.Date.Date) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool FindOnePlanDutyDetail(PlanDutyDetail planDutyDetail)
        {
            if (planDutyDetail.Date.ToShortDateString() == _Date.ToShortDateString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool FindReplaceDutyClass(DutyClassReplace dutyClassReplace)
        {
            if (dutyClassReplace.OldDutyClass.DutyClassID == _DutyClassID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool FindSpecialDate(SpecialDate specialDate)
        {
            if (specialDate.SpecialDateTime.ToShortDateString()== _Date.ToShortDateString() )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateReplaceDutyClass()
        {
            bool value = true;
            if (!DateTime.TryParse(_ItsView.ReplaceDutyClassView.From, out fromTime) ||
                !DateTime.TryParse(_ItsView.ReplaceDutyClassView.To, out toTime))
            {
                _ItsView.ReplaceDutyClassView.Message = "时间范围设置不正确";
                value = false;
            }
            else if (fromTime > toTime)
            {
                _ItsView.ReplaceDutyClassView.Message = "起止时间设置不正确";
                value = false;
            }
            return value;
        }
        public bool Validate()
        {
            bool value = true;
            if (string.IsNullOrEmpty(_ItsView.SetPlanDutyView.PlanDutyTableName.Trim()))
            {
                _ItsView.SetPlanDutyView.PlanDutyNameMessage = "排班表名称不可为空";
                value = false;
            }
            if (!DateTime.TryParse(_ItsView.SetPlanDutyView.FromTime, out fromTime))
            {
                _ItsView.SetPlanDutyView.TimeMessage = "时间范围设置不正确";
                value = false;
            }
            if (!DateTime.TryParse(_ItsView.SetPlanDutyView.ToTime, out toTime))
            {
                _ItsView.SetPlanDutyView.TimeMessage = "时间范围设置不正确";
                value = false;
            }
            //判断上午上班时间是不是早于上午下班时间
            else if (fromTime > toTime)
            {
                _ItsView.SetPlanDutyView.TimeMessage = "起止时间设置不正确";
                value = false;
            }
            if (!string.IsNullOrEmpty(_ItsView.SetPlanDutyView.Period.Trim()) &&
                !Int32.TryParse(_ItsView.SetPlanDutyView.Period, out period))
            {
                _ItsView.SetPlanDutyView.PeriodMessage = "周期格式设置不正确";
                value = false;
            }
            else if (period < 0)
            {
                _ItsView.SetPlanDutyView.PeriodMessage = "周期不能为负数";
                value = false;
            }
            return value;
        }
        /// <summary>
        /// 替换班别
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void ReplaceDutyClassEvent(string from, string to)
        {
            if (!ValidateReplaceDutyClass())
            {
                _ItsView.IReplaceDutyClassViewVisible = true;
                return;
            }
            List<DutyClassReplace> dutyClassReplaceList = _ItsView.ReplaceDutyClassView.DutyClassReplaceList;
            if (dutyClassReplaceList.Count > 0)
            {
                DateTime temp = fromTime;
                DateTime current = _ItsView.SetPlanDutyView.CurrentDay;
                toTime = new DateTime(toTime.Year, toTime.Month, toTime.Day,23,59,59);
                while (DateTime.Compare(new DateTime(temp.Year, temp.Month, 1),
                new DateTime(toTime.Year, toTime.Month, 1)) <= 0)
                {
                    string yearMonth = temp.Year + ";" + temp.Month;
                    List<PlanDutyDetail> planDutyDetailList = _ItsView.SetPlanDutyView.GetViewState(yearMonth);
                    if (planDutyDetailList == null)//如果没有翻过页，没有存ViewState,则直接取值
                    {
                        //如果是当前月，则在界面上取值
                        if (temp.Year == _ItsView.SetPlanDutyView.CurrentDay.Year &&
                            temp.Month == _ItsView.SetPlanDutyView.CurrentDay.Month)
                        {
                            planDutyDetailList = _ItsView.SetPlanDutyView.GetCurrentPlanDutyDetailList(temp);
                        }
                        else//如果没有初始化过
                        {
                            planDutyDetailList = InitNewPlanDutyDetailList(temp);
                        }
                    }
                    for (int i = 0; i < planDutyDetailList.Count; i++)
                    {
                        if (DateTime.Compare(fromTime, Convert.ToDateTime(planDutyDetailList[i].Date.ToShortDateString())) <= 0 &&
                           DateTime.Compare(Convert.ToDateTime(planDutyDetailList[i].Date.ToShortDateString()), toTime) <= 0)
                        {
                            _DutyClassID = planDutyDetailList[i].PlanDutyClass.DutyClassID;
                            DutyClassReplace dutyClassReplace = dutyClassReplaceList.Find(FindReplaceDutyClass);
                            if (dutyClassReplace != null)
                            {
                                planDutyDetailList[i].PlanDutyClass.DutyClassID = dutyClassReplace.NewDutyClassID;
                            }
                        }
                    }
                    _ItsView.SetPlanDutyView.SavePlanDutyDetailListViewState(planDutyDetailList, yearMonth);
                    if (current.Year == temp.Year && current.Month == temp.Month)
                    {
                        _ItsView.SetPlanDutyView.PlanDutyDateSource = planDutyDetailList;
                    }
                    //找下个月的1号
                    temp = temp.AddDays(1 - temp.Day).AddMonths(1);
                }
            }
        }
        /// <summary>
        /// 翻页时储存PlanDutyViewState
        /// </summary>
        /// <param name="date"></param>
        public void SavePlanDutyViewStateForChangeMonthEvent(string date)
        {
            DateTime dt = Convert.ToDateTime(date);
            string yearMonth = dt.Year + ";" + dt.Month;
            //如果没有初始化过
            List<PlanDutyDetail> planDutyDetailList = _ItsView.SetPlanDutyView.GetViewState(yearMonth);
            if (planDutyDetailList == null)
            {
                planDutyDetailList = InitNewPlanDutyDetailList(dt);
            }
            _ItsView.SetPlanDutyView.SavePlanDutyDetailListViewState(planDutyDetailList, yearMonth);
            _ItsView.SetPlanDutyView.SetSomePlanDutyTableViewState();
            _ItsView.SetPlanDutyView.SetPlanDutyTableByViewState(dt);
        }
        /// <summary>
        /// 点击刷新前储存PlanDutyViewState
        /// </summary>
        public void SavePlanDutyViewStateEvent()
        {
            DateTime dt = _ItsView.SetPlanDutyView.CurrentDay;
            _ItsView.SetPlanDutyView.SaveViewState(dt);
            _ItsView.SetPlanDutyView.SetPlanDutyTableByViewState(dt);
        }
        /// <summary>
        /// 生成排班
        /// </summary>
        public void CreatePlanDutyClickEvent()
        {
            SavePlanDutyViewStateEvent();
            if (Validate())
            {
                PlanDutyTable planDutyTable = new PlanDutyTable();
                CompleteTheObject(planDutyTable);
                try
                {
                    _IPlanDutyFacade.AddPlanDuty(planDutyTable);
                    _ItsView.SetPlanDutyView.Message = "新增成功！";

                }
                catch (ApplicationException ae)
                {
                    _ItsView.SetPlanDutyView.Message = ae.Message;
                }
            }
        }
        /// <summary>
        /// 修改排班
        /// </summary>
        public void UpdatePlanDutyClickEvent()
        {
            SavePlanDutyViewStateEvent();
            if (Validate())
            {
                PlanDutyTable planDutyTable = new PlanDutyTable();
                planDutyTable.PlanDutyTableID = Convert.ToInt32(_ItsView.SetPlanDutyView.PlanDutyID);
                CompleteTheObject(planDutyTable);
                try
                {
                    _IPlanDutyFacade.UpdatePlanDuty(planDutyTable);
                    _ItsView.SetPlanDutyView.Message = "修改成功！";

                }
                catch (ApplicationException ae)
                {
                    _ItsView.SetPlanDutyView.Message = ae.Message;
                }
            }
        }
        /// <summary>
        /// 组装数据
        /// </summary>
        /// <param name="planDutyTable"></param>
        public void CompleteTheObject(PlanDutyTable planDutyTable)
        {
            planDutyTable.Period = period;
            DateTime temp = fromTime;
            planDutyTable.PlanDutyDetailList = new List<PlanDutyDetail>();
            while (DateTime.Compare(new DateTime(temp.Year, temp.Month, 1),
                new DateTime(toTime.Year, toTime.Month, 1)) <= 0)
            {
                string yearMonth = temp.Year + ";" + temp.Month;
                List<PlanDutyDetail> planDutyDetailList = _ItsView.SetPlanDutyView.GetViewState(yearMonth);
                if (planDutyDetailList == null)//如果没有翻过页，没有存ViewState,则直接取值
                {
                    //如果是当前月，则在界面上取值
                    if (temp.Year == _ItsView.SetPlanDutyView.CurrentDay.Year &&
                        temp.Month == _ItsView.SetPlanDutyView.CurrentDay.Month)
                    {
                        planDutyDetailList = _ItsView.SetPlanDutyView.GetCurrentPlanDutyDetailList(temp);
                    }
                    else//如果没有初始化过
                    {
                        planDutyDetailList = InitNewPlanDutyDetailList(temp);
                    }
                }
                _Date = temp;
                planDutyTable.PlanDutyDetailList.AddRange(planDutyDetailList.FindAll(FindPlanDutyDetail));
                //找下个月的1号
                temp = temp.AddDays(1 - temp.Day).AddMonths(1);
            }
            planDutyTable.PlanDutyTableName = _ItsView.SetPlanDutyView.PlanDutyTableName;
            planDutyTable.FromTime = fromTime;
            planDutyTable.ToTime = toTime;
            planDutyTable.PlanDutyAccountList = _ItsView.EmployeeList;
            planDutyTable.PlanDutyEmployeeNameList = _ItsView.SetPlanDutyView.EmployeeList;
        }
        /// <summary>
        /// 点击班别替换按钮后弹出小页面
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void DutyClassDisplaceEvent(string from, string to)
        {
            SavePlanDutyViewStateEvent();
            new ReplaceDutyClassPresenter(_ItsView.ReplaceDutyClassView).InitView(from, to);
            _ItsView.IReplaceDutyClassViewVisible = true;
        }
        public void ReplaceDutyClassDateBind()
        {
            new ReplaceDutyClassPresenter(_ItsView.ReplaceDutyClassView).DateBind();
            _ItsView.IReplaceDutyClassViewVisible = true;
        }

        public void CopyEvent()
        {
            SavePlanDutyViewStateEvent();
            if (Validate())
            {
                PlanDutyTable planDutyTable = new PlanDutyTable();
                CompleteTheObject(planDutyTable);
                try
                {
                    _ItsView.SetPlanDutyView.SessionCopyPlanDutyTable = planDutyTable;
                    _ItsView.SetPlanDutyView.Message = "复制成功！";

                }
                catch (ApplicationException ae)
                {
                    _ItsView.SetPlanDutyView.Message = ae.Message;
                }
            }
        }
        public void PasteEvent()
        {
            SavePlanDutyViewStateEvent();
            if (_ItsView.SetPlanDutyView.SessionCopyPlanDutyTable != null)
            {
                new PlanDudyBinder(_ItsView, _IPlanDutyFacade).DataBind(
                    _ItsView.SetPlanDutyView.SessionCopyPlanDutyTable);
            }
        }
        public void ShowReplaceDutyClassView()
        {
            _ItsView.IReplaceDutyClassViewVisible = true;
        }
        public void CancelEvent()
        {

        }
    }
}
