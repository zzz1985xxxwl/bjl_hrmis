using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter;

namespace SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter
{
    public class DutyClassAddPresenter
    {
        private readonly IDutyClassView _View;
        private readonly DutyClassUtility _Utility;
        private readonly IPlanDutyFacade _IPlanDutyFacade = InstanceFactory.CreatePlanDutyFacade();

        public DutyClassAddPresenter(IDutyClassView view)
        {
            _View = view;
            AttachViewEvent();
            _Utility = new DutyClassUtility(_View);
        }

        public void AttachViewEvent()
        {
            _View.ActionButtonEvent += AddEvent;
        }

        public void InitView()
        {
            _Utility.InitTheViewToDefault();
            _View.OperationTitle = "ÐÂÔö°à±ð";
            _View.OperationType = "Add";
        }

        public void AddEvent()
        {
             if(!_Utility.Validate())
             {
                 return;
             }
             DutyClass rule = new DutyClass();
             _Utility.CompleteTheObject(rule);
             try
             {
                 _IPlanDutyFacade.AddDutyClass(rule);
                 _View.ActionSuccess = true;
             }
             catch (ApplicationException ae)
             {
                 _View.Message = ae.Message;
             }
        }
    }
}
