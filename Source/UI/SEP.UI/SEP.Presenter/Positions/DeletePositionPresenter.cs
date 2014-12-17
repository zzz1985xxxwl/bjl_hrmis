using System;
using System.Collections.Generic;
using System.Text;
using SEP.IBll;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Presenter.IPresenter.IDepartments;
using SEP.Presenter.IPresenter.IPositions;

namespace SEP.Presenter.Positions
{
    internal class DeletePositionPresenter
    {
        private IPositionView _ItsView;
        private readonly Account _LoginUser;

        public DeletePositionPresenter(IPositionView itsView, Account loginUser)
        {
            _LoginUser = loginUser;
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += DeleteEvent;
        }

        public void InitView(string id)
        {
            new PositionIniter(_ItsView).InitTheViewToDefault();
            _ItsView.Title = MessageKeys._Position_DeletePageTitle;
            _ItsView.OperationType = MessageKeys._Position_DeleteOperationType;
            _ItsView.SetReadonly = true;

            new PositionDataBinder(_ItsView, _LoginUser).DataBind(id);
        }

        private void DeleteEvent()
        {
            try
            {
                BllInstance.PositionBllInstance.DeletePosition(Convert.ToInt32(_ItsView.positionID), _LoginUser);
                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
        }
    }
}
