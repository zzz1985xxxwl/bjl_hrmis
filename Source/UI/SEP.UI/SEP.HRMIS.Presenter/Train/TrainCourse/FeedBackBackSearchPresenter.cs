using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.Train.TrainCourse
{
    public class FeedBackBackSearchPresenter
    {
        private readonly IFeedBackBackSearchView _ItsView;
        private ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();
        private readonly Account _LoginUser;
        private List<TrainEmployeeFB> _TrainEmployeeFBs;

        public FeedBackBackSearchPresenter(IFeedBackBackSearchView itsView, Account loginUser)
        {
            _ItsView = itsView;
            _LoginUser = loginUser;
            AttachView();
        }

        public void SetIfFrontPage(bool value)
        {
            _ItsView.listView.SetIfFrontDetailPage = false;
        }

        public void InitView(bool IsPostBack)
        {
            new CourseFeedBackSearchIniter(_ItsView).Init();
            if (!IsPostBack)
            {
                SearchEvent(null, null);
                _ItsView.SetCourseName = false;
            }
        }

        private void AttachView()
        {
            _ItsView.listView.DataBind += BindSearch;
        }

        private void BindSearch()
        {
            SearchEvent(null, null);
        }

        public void SearchEvent(object sender, EventArgs e)
        {
            CourseFeedBackValidate va = new CourseFeedBackValidate(_ItsView);
            if (!va.Validate())
            {
                return;
            }
            try
            {

                _TrainEmployeeFBs =
                    _ITrainFacade.GetTrainEmployeeFB(-1, -1, _ItsView.TrainCourese, _ItsView.FBEmployee,
                                                       Convert.ToInt32(_ItsView.Status), va._OutStartFrom,
                                                   va._OutStartTo, _LoginUser,false);
                _ItsView.listView.employeeFBs = _TrainEmployeeFBs;
                _ItsView.ResultMessage = _TrainEmployeeFBs.Count.ToString();
            }
            catch (Exception ex)
            {
                _ItsView.ResultMessage = ex.Message;
            }
        }



        /// <summary>
        /// use for test
        /// </summary>
        public ITrainFacade GetTrainCouse
        {
            set { _ITrainFacade = value; }
        }
    }
}
