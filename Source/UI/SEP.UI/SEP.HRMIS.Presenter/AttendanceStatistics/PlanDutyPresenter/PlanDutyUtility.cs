
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
        public const string AddPageTitle = "�����Ű��";
        public const string UpdatePageTitle = "�޸��Ű��";
        public const string DetailPageTitle = "�鿴�Ű��";
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

            #region ������������ҳ�����ֵ

            bool isCaculatePeriod = false;
            int[] periodValue = new int[0];
            //��������Ѿ��趨�����趨Ϊ����0������
            if (!string.IsNullOrEmpty(_ItsView.SetPlanDutyView.Period.Trim()) &&
                                     Int32.TryParse(_ItsView.SetPlanDutyView.Period, out period) &&
                                     period > 0)
            {
                List<PlanDutyDetail> lastPlanDutyDetailList =
                    _ItsView.SetPlanDutyView.GetViewState(date.AddMonths(-1).Year + ";" + date.AddMonths(-1).Month);
                //���ҿ����ҵ��ϸ��µ�ViewState,����Լ�������
                isCaculatePeriod = lastPlanDutyDetailList != null;
                if (isCaculatePeriod)
                {
                    //�ҳ�����ֵ
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
                        else//������Ҳ��������򲻼���
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
                if (isCaculatePeriod && periodValue.Length > 0)//�����������
                {
                    planDutyDetail.PlanDutyClass.DutyClassID = periodValue[(temp.Day - monthFrom.Day) % period];
                }
                else//����󶨹�˾��������
                {
                    if (specialDate != null && dutyClassList.Count > 0)
                    {
                        planDutyDetail.PlanDutyClass.DutyClassID = specialDate.IsWork == 1 ? 1 : -1;
                    }
                    else
                    {
                        //���������ĩ�����а�����
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
                _ItsView.SetPlanDutyView.Message = "�Ű��ID��Ϊ����";
                return;
            }
            _ItsView.SetPlanDutyView.PlanDutyID = id;
            PlanDutyTable planDutyTable = _IPlanDutyFacade.GetPlanDutyTableByPKID(id_Int);
            new PlanDudyBinder(_ItsView, _IPlanDutyFacade).DataBind(planDutyTable);
        }

        /// <summary>
        /// ������ʱ�䷶Χ��PlanDutyDetail
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
                _ItsView.ReplaceDutyClassView.Message = "ʱ�䷶Χ���ò���ȷ";
                value = false;
            }
            else if (fromTime > toTime)
            {
                _ItsView.ReplaceDutyClassView.Message = "��ֹʱ�����ò���ȷ";
                value = false;
            }
            return value;
        }
        public bool Validate()
        {
            bool value = true;
            if (string.IsNullOrEmpty(_ItsView.SetPlanDutyView.PlanDutyTableName.Trim()))
            {
                _ItsView.SetPlanDutyView.PlanDutyNameMessage = "�Ű�����Ʋ���Ϊ��";
                value = false;
            }
            if (!DateTime.TryParse(_ItsView.SetPlanDutyView.FromTime, out fromTime))
            {
                _ItsView.SetPlanDutyView.TimeMessage = "ʱ�䷶Χ���ò���ȷ";
                value = false;
            }
            if (!DateTime.TryParse(_ItsView.SetPlanDutyView.ToTime, out toTime))
            {
                _ItsView.SetPlanDutyView.TimeMessage = "ʱ�䷶Χ���ò���ȷ";
                value = false;
            }
            //�ж������ϰ�ʱ���ǲ������������°�ʱ��
            else if (fromTime > toTime)
            {
                _ItsView.SetPlanDutyView.TimeMessage = "��ֹʱ�����ò���ȷ";
                value = false;
            }
            if (!string.IsNullOrEmpty(_ItsView.SetPlanDutyView.Period.Trim()) &&
                !Int32.TryParse(_ItsView.SetPlanDutyView.Period, out period))
            {
                _ItsView.SetPlanDutyView.PeriodMessage = "���ڸ�ʽ���ò���ȷ";
                value = false;
            }
            else if (period < 0)
            {
                _ItsView.SetPlanDutyView.PeriodMessage = "���ڲ���Ϊ����";
                value = false;
            }
            return value;
        }
        /// <summary>
        /// �滻���
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
                    if (planDutyDetailList == null)//���û�з���ҳ��û�д�ViewState,��ֱ��ȡֵ
                    {
                        //����ǵ�ǰ�£����ڽ�����ȡֵ
                        if (temp.Year == _ItsView.SetPlanDutyView.CurrentDay.Year &&
                            temp.Month == _ItsView.SetPlanDutyView.CurrentDay.Month)
                        {
                            planDutyDetailList = _ItsView.SetPlanDutyView.GetCurrentPlanDutyDetailList(temp);
                        }
                        else//���û�г�ʼ����
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
                    //���¸��µ�1��
                    temp = temp.AddDays(1 - temp.Day).AddMonths(1);
                }
            }
        }
        /// <summary>
        /// ��ҳʱ����PlanDutyViewState
        /// </summary>
        /// <param name="date"></param>
        public void SavePlanDutyViewStateForChangeMonthEvent(string date)
        {
            DateTime dt = Convert.ToDateTime(date);
            string yearMonth = dt.Year + ";" + dt.Month;
            //���û�г�ʼ����
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
        /// ���ˢ��ǰ����PlanDutyViewState
        /// </summary>
        public void SavePlanDutyViewStateEvent()
        {
            DateTime dt = _ItsView.SetPlanDutyView.CurrentDay;
            _ItsView.SetPlanDutyView.SaveViewState(dt);
            _ItsView.SetPlanDutyView.SetPlanDutyTableByViewState(dt);
        }
        /// <summary>
        /// �����Ű�
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
                    _ItsView.SetPlanDutyView.Message = "�����ɹ���";

                }
                catch (ApplicationException ae)
                {
                    _ItsView.SetPlanDutyView.Message = ae.Message;
                }
            }
        }
        /// <summary>
        /// �޸��Ű�
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
                    _ItsView.SetPlanDutyView.Message = "�޸ĳɹ���";

                }
                catch (ApplicationException ae)
                {
                    _ItsView.SetPlanDutyView.Message = ae.Message;
                }
            }
        }
        /// <summary>
        /// ��װ����
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
                if (planDutyDetailList == null)//���û�з���ҳ��û�д�ViewState,��ֱ��ȡֵ
                {
                    //����ǵ�ǰ�£����ڽ�����ȡֵ
                    if (temp.Year == _ItsView.SetPlanDutyView.CurrentDay.Year &&
                        temp.Month == _ItsView.SetPlanDutyView.CurrentDay.Month)
                    {
                        planDutyDetailList = _ItsView.SetPlanDutyView.GetCurrentPlanDutyDetailList(temp);
                    }
                    else//���û�г�ʼ����
                    {
                        planDutyDetailList = InitNewPlanDutyDetailList(temp);
                    }
                }
                _Date = temp;
                planDutyTable.PlanDutyDetailList.AddRange(planDutyDetailList.FindAll(FindPlanDutyDetail));
                //���¸��µ�1��
                temp = temp.AddDays(1 - temp.Day).AddMonths(1);
            }
            planDutyTable.PlanDutyTableName = _ItsView.SetPlanDutyView.PlanDutyTableName;
            planDutyTable.FromTime = fromTime;
            planDutyTable.ToTime = toTime;
            planDutyTable.PlanDutyAccountList = _ItsView.EmployeeList;
            planDutyTable.PlanDutyEmployeeNameList = _ItsView.SetPlanDutyView.EmployeeList;
        }
        /// <summary>
        /// �������滻��ť�󵯳�Сҳ��
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
                    _ItsView.SetPlanDutyView.Message = "���Ƴɹ���";

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
