using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;
using SEP.Model.Accounts;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Presenter.Train.TrainCourse
{
    public class CourseInfoViewIniter
    {
        private readonly ICourseView _ItsView;
        private readonly IFeedBackPaperFacade _IPaperFacade;

        public CourseInfoViewIniter(ICourseView itsView)
        {
            _ItsView = itsView;
            _IPaperFacade = InstanceFactory.CreateFeedBackPaperFacade();
        }

        public void InitTheViewToDefault()
        {
            _ItsView.CourseNameMsg = string.Empty;
            _ItsView.PlaceMsg = string.Empty;
            _ItsView.CoordinatorMsg = string.Empty;
            _ItsView.TrainersMsg = string.Empty;
            _ItsView.EmployeeMsg = string.Empty;
            _ItsView.SkillsMsg = string.Empty;
            _ItsView.ExpectHourMsg = string.Empty;
            _ItsView.ExpectCostMsg = string.Empty;
            _ItsView.ExpectSTMsg = string.Empty;
            _ItsView.ExpectETMsg = string.Empty;
            _ItsView.ActualSTMsg = string.Empty;
            _ItsView.ActualETMsg = string.Empty;
            _ItsView.ActualCostMsg = string.Empty;
            _ItsView.ActualHourMsg = string.Empty;


            _ItsView.CourseName = string.Empty;
            _ItsView.Place = string.Empty;
            _ItsView.Coordinator = string.Empty;
            _ItsView.Trainer = string.Empty;

            _ItsView.ScopeSource = TrainScopeType.AllTrainScopeTypes;
            _ItsView.StatusSource = TrainStatusType.AllTrainStatusTypes;
            _ItsView.ChoosedEmployees = string.Empty;
            _ItsView.ChoosedSkills = string.Empty;
            _ItsView.EmployeeList = new List<Account>();
            _ItsView.SkillList = new List<Skill>();

            _ItsView.ExpectST = DateTime.Now.ToShortDateString();
            _ItsView.ExpectET = DateTime.Now.ToShortDateString();
            _ItsView.ExpectCost = string.Empty;
            _ItsView.ExpectHour = string.Empty;
            _ItsView.ActualST = string.Empty;
            _ItsView.ActualET = string.Empty;
            _ItsView.ActualCost = string.Empty;
            _ItsView.ActualHour = string.Empty;

            _ItsView.FeedBackPaperSource = _IPaperFacade.GetFeedBackPaperByPaperName(string.Empty);
        }
    }
}
