using System;
using System.Transactions;
using SEP.HRMIS.Facade;
using SEP.HRMIS.IFacede;
using SEP.IBll;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Positions;
using SEP.Model.Utility;
using SEP.Presenter.IPresenter.IPositions;

namespace SEP.Presenter.Positions
{
    internal class UpdatePositionPresenter
    {
        private readonly IPositionView _ItsView;
        private readonly Account _LoginUser;
        public UpdatePositionPresenter(IPositionView itsView, Account loginUser)
        {
            _LoginUser = loginUser;
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += UpdateEvent;
        }

        public void InitView(string id)
        {
            new PositionIniter(_ItsView).InitTheViewToDefault();
            _ItsView.Title = MessageKeys._Position_UpdatePageTitle;
            _ItsView.OperationType = MessageKeys._Position_UpdateOperationType;
            _ItsView.SetReadonly = false;

            new PositionDataBinder(_ItsView, _LoginUser).DataBind(id);
        }

        public void UpdateEvent()
        {
            //数据验证过程
            if (!new PositionVaildater(_ItsView).Vaildate())
            {
                return;
            }
            //数据收集过程
            Position theObject =
                BllInstance.PositionBllInstance.GetPositionById(Convert.ToInt32(_ItsView.positionID), _LoginUser);
            string oldName = theObject.Name;
            string oldDescription = theObject.Description;
            //int oldGradeId = theObject.Grade.Id;
            new PositionDataCollector(_ItsView).CompleteTheObject(theObject);
            //执行事务过程
            try
            {
                //如果有变化则修改
                if (oldName != theObject.Name ||
                    oldDescription != theObject.Description)
                {
                    using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                    {
                        BllInstance.PositionBllInstance.UpdatePosition(theObject, _LoginUser);
                        if (CompanyConfig.HasHrmisSystem
                            && oldName != theObject.Name)
                        {
                            IPositionHistoryFacade hrmisPositionHistoryFacade =
                                new PositionHistoryFacade();
                            hrmisPositionHistoryFacade.AddPositionHistoryFacade(_LoginUser, theObject);
                        }
                        ts.Complete();
                    }
                }
                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
        }
    }
}
