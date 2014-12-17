using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter;

namespace SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter
{
    public class PlanDudyBinder
    {
        private readonly ISetPlanDutyInfoView _ItsView;
        private readonly IPlanDutyFacade _IPlanDutyFacade;
        public PlanDudyBinder(ISetPlanDutyInfoView itsView, IPlanDutyFacade iPlanDutyFacade)
        {
            _IPlanDutyFacade = iPlanDutyFacade;
            _ItsView = itsView;
        }

        public void DataBind(int planDutyId)
        {
            try
            {
                PlanDutyTable theDataToBind = _IPlanDutyFacade.GetPlanDutyTableByPKID(planDutyId);
                SetPlanDutyView(theDataToBind);
            }
            catch
            {
                _ItsView.SetPlanDutyView.Message = "初始化信息失败";
            }
        }
        private DateTime _Date;
        private void SetPlanDutyView(PlanDutyTable theDataToBind)
        {
            _ItsView.SetPlanDutyView.CurrentDay = theDataToBind.FromTime;
            _ItsView.EmployeeList = theDataToBind.PlanDutyAccountList;
            _ItsView.SetPlanDutyView.EmployeeList = theDataToBind.PlanDutyEmployeeNameList;
            _ItsView.SetPlanDutyView.FromTime = theDataToBind.FromTime.ToShortDateString();
            _ItsView.SetPlanDutyView.ToTime = theDataToBind.ToTime.ToShortDateString();
            _ItsView.SetPlanDutyView.Period = theDataToBind.Period.ToString();
            _ItsView.SetPlanDutyView.PlanDutyTableName = theDataToBind.PlanDutyTableName;
            DateTime temp = theDataToBind.FromTime; 
            DateTime current = _ItsView.SetPlanDutyView.CurrentDay;
            List<PlanDutyDetail> planDutyDetailList=  theDataToBind.PlanDutyDetailList;
                while (DateTime.Compare(new DateTime(temp.Year, temp.Month, 1),
                new DateTime(theDataToBind.ToTime.Year, theDataToBind.ToTime.Month, 1)) <= 0)
                {
                    string yearMonth = temp.Year + ";" + temp.Month;
                    _Date = temp;
                    List<PlanDutyDetail> planDutyDetailListTemp =
                        planDutyDetailList.FindAll(FindPlanDutyDetail);

                    _ItsView.SetPlanDutyView.SavePlanDutyDetailListViewState(planDutyDetailListTemp, yearMonth);
                    if (current.Year == temp.Year && current.Month == temp.Month)
                    {
                        _ItsView.SetPlanDutyView.PlanDutyDateSource = planDutyDetailList;
                    }
                    //找下个月的1号
                    temp = temp.AddDays(1 - temp.Day).AddMonths(1);
                }
        }
        /// <summary>
        /// 查找某一个月的PlanDutyDetail
        /// </summary>
        /// <param name="planDutyDetail"></param>
        /// <returns></returns>
        private bool FindPlanDutyDetail(PlanDutyDetail planDutyDetail)
        {
            if (planDutyDetail.Date.Year == _Date.Year &&
                planDutyDetail.Date.Month == _Date.Month)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DataBind(PlanDutyTable theDataToBind)
        {
            try
            {
                SetPlanDutyView(theDataToBind);
            }
            catch
            {
                _ItsView.SetPlanDutyView.Message = "绑定信息失败";
            }
        }

    }
}
