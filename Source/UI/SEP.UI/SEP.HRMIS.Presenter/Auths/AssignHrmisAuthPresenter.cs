using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IAuth;
using SEP.IBll;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.Auths
{
    public class AssignHrmisAuthPresenter
    {
        private readonly IAccountAuthFacade _IAccountAuthFacade = InstanceFactory.CreateAccountAuthFacade();

        private readonly IAssignHrmisAuthView _IAssignHrmisAuthView;
        public AssignHrmisAuthPresenter(IAssignHrmisAuthView view)
        {
            _IAssignHrmisAuthView = view;
            AttachViewEvent();
        }

        public void InitPresenter(bool isPostBack)
        {
            if (!isPostBack)
            {
                _IAssignHrmisAuthView.ResultMessage = string.Empty;
                _IAssignHrmisAuthView.AuthSource = new List<Auth>();
                //获取账号信息
                //_IAssignHrmisAuthView.AccountsSource = BllInstance.AccountBllInstance.GetAllHRMisAccount();
                if (!Equals(AccountID, -1))
                {
                    List<Auth> authList =
                        _IAccountAuthFacade.GetAccountAllAuthList(AccountID, null);
                    _IAssignHrmisAuthView.AccountsBackAuth = authList;
                    _IAssignHrmisAuthView.AuthSource = authList;
                }
            }
        }

        private int AccountID
        {
            get
            {
                Account account = BllInstance.AccountBllInstance.GetAccountByName(_IAssignHrmisAuthView.AccountBackName);
                if (account == null)
                {
                    return -1;
                }
                return account.Id;
            }
        }
        private void AttachViewEvent()
        {
            _IAssignHrmisAuthView.drdRoleSelectedIndexChanged += drdRoleSelectedIndexChanged;
        }

        public void drdRoleSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            _IAssignHrmisAuthView.ResultMessage = string.Empty;
            List<Auth> authList = _IAccountAuthFacade.GetAccountAllAuthList(AccountID, null);
            _IAssignHrmisAuthView.AccountsBackAuth = authList;
            _IAssignHrmisAuthView.AuthSource = authList;
        }
    }
}