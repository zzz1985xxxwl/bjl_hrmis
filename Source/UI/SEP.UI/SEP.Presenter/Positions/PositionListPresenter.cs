using System;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IPositions;
using SEP.IBll;
using SEP.Model.Accounts;

namespace SEP.Presenter.Positions
{
    public class PositionListPresenter : BasePresenter
    {
        private IPositionListView _ItsView;

        public PositionListPresenter(IPositionListView itsView, Account loginUser)
            : base(loginUser)
        {
            _ItsView = itsView;
            _ItsView.Message = String.Empty;

            AttachViewEvent();
        }

        internal void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                PositionDataBind();
            }
        }

        private void AttachViewEvent()
        {
            _ItsView.BtnSearchEvent += SearchByPositionName;
        }

        internal void PositionDataBind()
        {
            try
            {
                //_ItsView.positions = BllInstance.PositionBllInstance.GetAllPosition();
                _ItsView.positions = BllInstance.PositionBllInstance.GetPositionByCondition(_ItsView.PositionName,-1);
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
        }

        private void SearchByPositionName()
        {
            try
            {
                _ItsView.positions = BllInstance.PositionBllInstance.GetPositionByCondition(_ItsView.PositionName,-1);
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
        }

        public override void Initialize(bool isPostBack)
        {

        }
    }
}
