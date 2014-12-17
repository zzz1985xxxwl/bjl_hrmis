using System;
using System.Collections.Generic;
using System.Text;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Presenter.IPresenter.IPositions;

namespace SEP.Presenter.Positions
{
    internal class DetailPositionPresenter
    {
        private readonly IPositionView _ItsView;
        private readonly Account _LoginUser;
        public DetailPositionPresenter(IPositionView itsView, Account loginUser)
        {
            _LoginUser = loginUser;
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += DetailEvent;
        }

        public void InitView(string id)
        {
            new PositionIniter(_ItsView).InitTheViewToDefault();
            _ItsView.Title = MessageKeys._Position_DetailPageTitle;
            _ItsView.OperationType = MessageKeys._Position_DetailOperationType;
            _ItsView.SetReadonly = true;

            new PositionDataBinder(_ItsView, _LoginUser).DataBind(id);
        }

        public void DetailEvent()
        {
            _ItsView.ActionSuccess = true;
        }
    }
}
