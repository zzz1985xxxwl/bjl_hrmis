//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AccountSetValidater.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 界面验证
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet.IAccountSet;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSet
{
    public class AccountSetValidater
    {
        private readonly IAccountSetView _ItsView;

        public AccountSetValidater(IAccountSetView itsView)
        {
            _ItsView = itsView;
        }

        public bool Vaildate()
        {
            _ItsView.AccountSetNameMsg = string.Empty;
            _ItsView.Message = string.Empty;
            bool isValid = true;
            if (string.IsNullOrEmpty(_ItsView.AccountSetName))
            {
                _ItsView.AccountSetNameMsg = AccountSetUtility._NameIsEmpty;
                isValid = false;
            }
            return isValid;
        }
    }
}
