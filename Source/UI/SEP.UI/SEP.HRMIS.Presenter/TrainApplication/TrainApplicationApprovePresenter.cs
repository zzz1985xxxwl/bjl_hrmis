//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: TrainApplicationApprovePresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-10-16
// Resume:
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.HRMIS.Presenter.IPresenter.ITrainApplication;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.TrainApplication
{
    /// <summary>
    /// </summary>
    public class TrainApplicationApprovePresenter
    {
        private readonly ITrainApplicationView _ItsView;
        public event DelegateNoParameter _CompleteEvent;

        public TraineeApplication _ANewObject;
        private readonly Account _LoginUser;
        private readonly ITraineeApplicationFacade _ITrainFacade = InstanceFactory.CreateTraineeApplicationFacade();

        public TrainApplicationApprovePresenter(ITrainApplicationView itsView, Account loginUser)
        {
            _ItsView = itsView;
            _LoginUser = loginUser;
            AttachViewEvent();
        }

        private void AttachViewEvent()
        {
            _ItsView.PassButtonEvent += PassEvent;
            _ItsView.FailButtonEvent += FailEvent;
        }

        private void PassEvent()
        {
            ApproveEvent(TraineeApplicationStatus.ApprovePass);
        }

        private void ApproveEvent(TraineeApplicationStatus status)
        {
            if (new TrainApplicationUtilityPresenter(_ItsView, _LoginUser).EduSpuCostValidate())
            {
                try
                {
                    TraineeApplication application =
                        _ITrainFacade.GetTraineeApplicationByPkid(Convert.ToInt32(_ItsView.TrainApplicationID));
                    if(string.IsNullOrEmpty(_ItsView.EduSpuCost))
                    {
                        application.EduSpuCost = null;
                    }
                    else
                    {
                        application.EduSpuCost = Convert.ToDecimal(_ItsView.EduSpuCost);
                    }
                    _ITrainFacade.UpdateTraineeApplicationDal(application);
                    _ITrainFacade.ApproveTraineeApplicationWhole(_LoginUser, Convert.ToInt32(_ItsView.TrainApplicationID),
                                                                 status,
                                                                 _ItsView.ApproveRemark);
                    _CompleteEvent();
                }
                catch (ApplicationException ae)
                {
                    _ItsView.Message = ae.Message;
                }
            }
        }

        private void FailEvent()
        {
            ApproveEvent(TraineeApplicationStatus.ApproveFail);
        }

        public void InitView(string id, bool isPostBack)
        {
            _ItsView.Message = string.Empty;
            _ItsView.OperationTitle = TrainApplicationUtilityPresenter.ApprovePageTitle;
            _ItsView.OperationType = TrainApplicationUtilityPresenter.ApproveOperationType;

            new TrainApplicationUtilityPresenter(_ItsView, _LoginUser).Init(id, isPostBack);
        }
    }
}