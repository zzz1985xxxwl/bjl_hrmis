using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrainApplication;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.TrainApplication
{
    public class TrainApplicationDataCollecter
    {
        private readonly ITrainApplicationView _ItsView;
        private readonly Account _LoginUser;

        public TrainApplicationDataCollecter(ITrainApplicationView itsView, Account loginUser)
        {
            _ItsView = itsView;
            _LoginUser = loginUser;
        }

        public void CompleteTheObject(TraineeApplication theObjectToComplete)
        {
            if (theObjectToComplete != null)
            {
                theObjectToComplete.CourseName = _ItsView.CourseName;
                theObjectToComplete.TrainPlace = _ItsView.Place;
                theObjectToComplete.Applicant= _LoginUser;
                theObjectToComplete.EndTime = Convert.ToDateTime(_ItsView.EndTime);

                theObjectToComplete.Skills = _ItsView.Skills;
                theObjectToComplete.StratTime = Convert.ToDateTime(_ItsView.StartTime);
                theObjectToComplete.StudentList = _ItsView.EmployeeList;
                theObjectToComplete.TrainCost = Convert.ToDecimal(_ItsView.Cost);
                if(!string.IsNullOrEmpty(_ItsView.EduSpuCost))
                {
                    theObjectToComplete.EduSpuCost = Convert.ToDecimal(_ItsView.EduSpuCost);
                }
                

                theObjectToComplete.Trainer = _ItsView.Trainer;

                theObjectToComplete.TrainHour = Convert.ToDecimal(_ItsView.Hour);
                theObjectToComplete.TrainOrgnatiaon = _ItsView.Orgnation;
                theObjectToComplete.TrainPlace = _ItsView.Place;
                theObjectToComplete.TrainType = TrainScopeType.GetById(Convert.ToInt32(_ItsView.TrainScope));

                theObjectToComplete.HasCertifacation = _ItsView.HasCertifaction;
            }
        }

    }
}
