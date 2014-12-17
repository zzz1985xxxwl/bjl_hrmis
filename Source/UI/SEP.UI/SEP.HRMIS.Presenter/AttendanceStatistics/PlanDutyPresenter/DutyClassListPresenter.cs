using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter;
using InstanceFactory=SEP.HRMIS.IFacede.InstanceFactory;
using IPlanDutyFacade=SEP.HRMIS.IFacede.IPlanDutyFacade;

namespace SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter
{
    public class DutyClassListPresenter
    {
        private readonly IDutyClassListView _View;
        private IPlanDutyFacade _IPlanDutyFacade = InstanceFactory.CreatePlanDutyFacade();

        public DutyClassListPresenter(IDutyClassListView listView)
        {
            _View = listView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _View.BtnSearchEvent += RuleDataBind;
        }

        public void InitView(bool isPostBack)
        {
             if(!isPostBack)
             {
                 RuleDataBind();
             }
        }

        public void RuleDataBind()
        {
            List<DutyClass> rules = _IPlanDutyFacade.GetDutyClassByCondition(-1, _View.DutyClassName);
            _View.DutyClasss = rules;
        }

        #region use for tests

        public IPlanDutyFacade IPlanDutyFacade
        {
            set { _IPlanDutyFacade = value; }
        }

        #endregion
    }
}
