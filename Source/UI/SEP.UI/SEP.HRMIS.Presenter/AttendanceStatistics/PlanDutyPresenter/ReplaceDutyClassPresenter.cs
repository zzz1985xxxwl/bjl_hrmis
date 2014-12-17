using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter;


namespace SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter
{
    public class ReplaceDutyClassPresenter
    
    {
        private readonly IReplaceDutyClassView _IReplaceDutyClassView;
        private readonly IPlanDutyFacade _IPlanDutyFacade = InstanceFactory.CreatePlanDutyFacade();

        public ReplaceDutyClassPresenter(IReplaceDutyClassView IReplaceDutyClassView)
        {
            _IReplaceDutyClassView = IReplaceDutyClassView;
        }

        public void InitView(string from, string to)
        {
            _IReplaceDutyClassView.Message = string.Empty;
            _IReplaceDutyClassView.From = from;
            _IReplaceDutyClassView.To = to;
            List<DutyClass> dutyClassList = _IPlanDutyFacade.GetDutyClassByCondition(-1, "");
            dutyClassList.Add(new DutyClass());
            dutyClassList[dutyClassList.Count-1].DutyClassID = -1;
            dutyClassList[dutyClassList.Count - 1].DutyClassName = "ÐÝÏ¢";
            _IReplaceDutyClassView.DutyClassList = dutyClassList;
            List<DutyClassReplace> dutyClassReplaceList = new List<DutyClassReplace>();
            foreach (DutyClass dutyClass in dutyClassList)
            {
                DutyClassReplace dutyClassReplace = new DutyClassReplace();
                dutyClassReplace.OldDutyClass = dutyClass;
                dutyClassReplace.NewDutyClassID = dutyClass.DutyClassID;
                dutyClassReplaceList.Add(dutyClassReplace);
            }
            _IReplaceDutyClassView.DutyClassReplaceList = dutyClassReplaceList;
        }

        public void DateBind()
        {
            List<DutyClass> dutyClassList = _IPlanDutyFacade.GetDutyClassByCondition(-1, "");
            dutyClassList.Add(new DutyClass());
            dutyClassList[dutyClassList.Count - 1].DutyClassID = -1;
            dutyClassList[dutyClassList.Count - 1].DutyClassName = "ÐÝÏ¢";
            _IReplaceDutyClassView.DutyClassList = dutyClassList;
        }
    }
}
