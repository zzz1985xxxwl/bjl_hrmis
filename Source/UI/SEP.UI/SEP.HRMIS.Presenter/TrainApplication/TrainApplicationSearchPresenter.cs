using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using SEP.HRMIS.Presenter.IPresenter.ITrainApplication;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.TrainApplication
{
    public class TrainApplicationSearchPresenter
    {
        private readonly ISearchTrainApplicationView _ItsView;
        private readonly ITraineeApplicationFacade _ITrainFacade = InstanceFactory.CreateTraineeApplicationFacade();

        private readonly Account _LoginUser;


        public TrainApplicationSearchPresenter(ISearchTrainApplicationView itsView, Account LoginUser)
        {
            _ItsView = itsView;
            _LoginUser = LoginUser;
            AttachEvent();
        }

        private void AttachEvent()
        {
            _ItsView.ApplicationDataBind += BindData;
        }

        public void Init(bool isPostBack)
        {
            if (isPostBack) return;
            GetDataSource();
            SearchEvent(null, null);
        }


        private void BindData()
        {
            SearchEvent(null, null);
        }

        public void SearchEvent(object sender, EventArgs e)
        {
            if (!Validate())
            {
            }
            else
            {
                try
                {
                    _ItsView.ErrorMessage = string.Empty;

                    int scope = Convert.ToInt32(_ItsView.Scope);
                    int status = Convert.ToInt32(_ItsView.SelectedStatus);

                    List<TraineeApplication> applications =
                        _ITrainFacade.GetTraineeApplicationByCondition(_ItsView.Trainer, _ItsView.Trainee,_ItsView.CourseName, _OutStartFrom,
                                                                       _OutStartTo, _ItsView.HasCertification,
                                                                       TrainScopeType.GetById(scope),
                                                                       TraineeApplicationStatus.
                                                                           FindTraineeApplicationStatus(status));
                    _ItsView.ApplicationSource = applications;

                    _ItsView.ErrorMessage = "<span class='font14b'>共查到 " + "<span class='fontred'>" + applications.Count +
                                            "</span>" + "<span class='font14b'> 条记录</span>";
                }
                catch (Exception ex)
                {
                    _ItsView.ErrorMessage = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

        private void GetDataSource()
        {
            _ItsView.ScopeSource = TrainScopeType.AllTrainScopeTypes;
            _ItsView.StatusSource = TraineeApplicationStatus.AllTraineeApplicationStatuss;
            var start = new DateTime(DateTime.Now.Year, 1, 1);
            _ItsView.DateFrom = start.ToString("yyyy-MM-dd");
            _ItsView.DateTo = start.AddYears(1).AddDays(-1).ToString("yyyy-MM-dd");
        }

        #region Validate
        public bool Validate()
        {
            if (!(VaildateExpectedST() && VaildateExpectedET()))
            {
                return false;
            }
            if (DateTime.Compare(_OutStartFrom, _OutStartTo) > 0)
            {
                _ItsView.TimeErrorMessage = "时间段不正确";
                return false;
            }
            return true;
        }

        private readonly DateTime _DateFrom = Convert.ToDateTime("1999-1-1");
        private readonly DateTime _DateTo = Convert.ToDateTime("2999-12-31");

        private DateTime _OutStartFrom;
        private bool VaildateExpectedST()
        {
            if (string.IsNullOrEmpty(_ItsView.DateFrom))
            {
                _OutStartFrom = _DateFrom;
                return true;
            }
            if (!DateTime.TryParse(_ItsView.DateFrom, out _OutStartFrom))
            {
                _ItsView.TimeErrorMessage = "时间输入不正确";
                return false;
            }
            return true;
        }
        private DateTime _OutStartTo;
        private bool VaildateExpectedET()
        {
            if (string.IsNullOrEmpty(_ItsView.DateTo))
            {
                _OutStartTo = _DateTo;
                return true;
            }
            if (!DateTime.TryParse(_ItsView.DateTo, out _OutStartTo))
            {
                _ItsView.TimeErrorMessage = "时间输入不正确";
                return false;
            }
            return true;
        }
   
        #endregion
    }
}
