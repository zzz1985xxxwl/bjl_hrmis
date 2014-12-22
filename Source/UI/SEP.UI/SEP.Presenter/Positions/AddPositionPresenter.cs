using System;
using System.Configuration;
using System.Transactions;
using SEP.HRMIS.Facade;
using SEP.HRMIS.IFacede;
using SEP.Model;
using SEP.Model.Utility;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IPositions;
using SEP.Model.Positions;
using SEP.Model.Accounts;
using SEP.IBll;

namespace SEP.Presenter.Positions
{
    public class AddPositionPresenter : BasePresenter
    {
        private IPositionView _ItsView;
        private Position _ANewObject;
        private Account _LoginUser;

        public AddPositionPresenter(IPositionView itsView, Account loginUser)
            : base(loginUser)
        {
            _ItsView = itsView;
            _LoginUser = loginUser;

            AttachViewEvent();
        }

        private void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += AddEvent;
        }

        public void InitView()
        {
            new PositionIniter(_ItsView).InitTheViewToDefault();
            _ItsView.Title = MessageKeys._Position_AddPageTitle;
            _ItsView.OperationType = MessageKeys._Position_AddOperationType;
            _ItsView.SetReadonly = false;
        }

        public void AddEvent()
        {
            //数据验证过程
            if (!new PositionVaildater(_ItsView).Vaildate())
            {
                return;
            }
            //数据收集过程
            _ANewObject = new Position();
            new PositionDataCollector(_ItsView).CompleteTheObject(_ANewObject);
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    BllInstance.PositionBllInstance.CreatePosition(_ANewObject, _LoginUser);
                    if (CompanyConfig.HasHrmisSystem)
                    {
                        IPositionHistoryFacade hrmisPositionHistoryFacade =
                            new PositionHistoryFacade();
                        hrmisPositionHistoryFacade.AddPositionHistoryFacade(_LoginUser);
                    }
                    ts.Complete();
                }
                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
            catch (Exception e)
            {
                _ItsView.Message = e.Message;
            }
        }

        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
