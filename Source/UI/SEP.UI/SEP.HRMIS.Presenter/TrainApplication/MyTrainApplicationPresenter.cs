using System;
using SEP.HRMIS.Presenter.IPresenter.ITrainApplication;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Presenter.TrainApplication
{
    public class MyTrainApplicationPresenter
    {
        private readonly IMyTrainApplicationView _ItsView;
        private readonly ITraineeApplicationFacade _ITrainFacade = InstanceFactory.CreateTraineeApplicationFacade();

        public MyTrainApplicationPresenter(IMyTrainApplicationView itsView)
        {
            _ItsView = itsView;
            AttachEvent();
        }

        private void AttachEvent()
        {
            _ItsView.ApplicationDataBind += SearchEvent;
            _ItsView.DeleteCommand += DeleteEvent;
        }

        public void InitView(bool isPostBack, int employeeID)
        {
            _ItsView.ResultMessage = "";
            _ItsView.EmployeeID = employeeID;

            if (!isPostBack)
            {
                SearchEvent();
            }
        }
        public void DeleteEvent(string id)
        {
            try
            {
                _ItsView.ResultMessage = string.Empty;
                _ITrainFacade.DeleteTraineeApplication(Convert.ToInt32(id));
                SearchEvent();
            }
            catch (Exception ex)
            {
                _ItsView.ResultMessage = ex.Message;
            }

        }
        public void SearchEvent()
        {
            _ItsView.ApplicationSource = _ITrainFacade.GetEmployeeTraineeApplicationByEmployeeID(_ItsView.EmployeeID);
        }
    }
}

