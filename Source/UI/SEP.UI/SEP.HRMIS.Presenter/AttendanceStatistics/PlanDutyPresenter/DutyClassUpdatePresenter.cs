using System;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter;
using InstanceFactory=SEP.HRMIS.IFacede.InstanceFactory;
using IPlanDutyFacade=SEP.HRMIS.IFacede.IPlanDutyFacade;

namespace SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter
{
    public class DutyClassUpdatePresenter
    {
        private readonly IDutyClassView _View;
        private readonly DutyClassUtility _Utility;
        private IPlanDutyFacade _IPlanDutyFacade = InstanceFactory.CreatePlanDutyFacade();

        public DutyClassUpdatePresenter(IDutyClassView view)
        {
            _View = view;
            _Utility = new DutyClassUtility(_View);
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _View.ActionButtonEvent += UpdateEvent;
        }

        public void InitView(string id)
        {
            _Utility.InitTheViewToDefault();
            _View.OperationTitle = "ÐÞ¸Ä°à±ð";
            _View.OperationType = "Update";
            _Utility.DataBind(id);
        }

        public void UpdateEvent()
        {
            if(!_Utility.Validate())
            {
                return;
            }
            DutyClass rule = _IPlanDutyFacade.GetDutyClassByPKID(Convert.ToInt32(_View.DutyClassId));
            _Utility.CompleteTheObject(rule);
            try
            {
                _IPlanDutyFacade.UpdateDutyClass(rule);
                _View.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _View.Message = ae.Message;
            }
        }

        #region use for tests

        public IPlanDutyFacade IPlanDutyFacade
        {
            set { _IPlanDutyFacade = value; }
        }

        #endregion
    }
}
