//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AccountSetDataBinder.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: AccountSet对象数据绑定
// ----------------------------------------------------------------
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet.IAccountSet;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSet
{
    public class AccountSetDataBinder
    {
        private readonly IAccountSetView _IAccountSetView;
        private readonly IAccountSetFacade _IAccountSetFacade = InstanceFactory.CreateAccountSetFacade();

        public AccountSetDataBinder(IAccountSetView itsView, IAccountSetFacade iAccountSetFacade)
        {
            _IAccountSetFacade = iAccountSetFacade;
            _IAccountSetView = itsView;
        }

        public void DataBind(int accountSetId)
        {
            try
            {
                Model.PayModule.AccountSet theDataToBind = _IAccountSetFacade.GetWholeAccountSetByPKID(accountSetId);
                _IAccountSetView.AccountSetName = theDataToBind.AccountSetName;
                _IAccountSetView.Description = theDataToBind.Description;
                _IAccountSetView.AccountSetItemList = theDataToBind.Items;
            }
            catch
            {
                _IAccountSetView.Message = "初始化信息失败";
            }
        }
        public void DataBind(Model.PayModule.AccountSet theDataToBind)
        {
            try
            {
                _IAccountSetView.AccountSetName = theDataToBind.AccountSetName;
                _IAccountSetView.Description = theDataToBind.Description;
                _IAccountSetView.AccountSetItemList = theDataToBind.Items;
            }
            catch
            {
                _IAccountSetView.Message = "绑定信息失败";
            }
        }
    }
}
