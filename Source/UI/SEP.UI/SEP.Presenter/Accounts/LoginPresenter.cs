using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.AccountAuth;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Presenter.IPresenter.IAccounts;

using SEP.Model.Utility;

namespace SEP.Presenter.Accounts
{
    public class LoginPresenter
    {
        private readonly IAccountAuthFacade _IAccountAuthFacade = InstanceFactory.CreateAccountAuthFacade();
        private IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;

        //private readonly IAccountAuthForEsFacade _IAccountAuthForEsFacade = new AccountAuthForEsFacade();
        private readonly ILoginView _ILoginView;
        private readonly bool _IsPostBack;

        public LoginPresenter(ILoginView view, bool isPostBack)
        {
            _ILoginView = view;
            _IsPostBack = isPostBack;
        }

        public void InitLogin()
        {
            _ILoginView.btnOKClick += ExecuteEvent;

            _ILoginView.Message = String.Empty;
            _ILoginView.ValidateLoginName = String.Empty;
            _ILoginView.ValidatePassword = String.Empty;

            if (!_IsPostBack)
            {
                _ILoginView.LoginName = String.Empty;
                _ILoginView.Password = String.Empty;
            }
        }

        private bool Validation()
        {
            _ILoginView.ValidateLoginName = String.Empty;
            _ILoginView.ValidatePassword = String.Empty;
            _ILoginView.Message = String.Empty; 

            if (String.IsNullOrEmpty(_ILoginView.LoginName))
            {
                _ILoginView.ValidateLoginName = "登录名不可以为空";
                return false;
            }

            if (String.IsNullOrEmpty(_ILoginView.Password))
            {
                _ILoginView.ValidatePassword = "密码不可以为空";
                return false;
            }

            return true;
        }

        public void ExecuteEvent(object sender, EventArgs e)
        {
            //ReadDataHistory readNewHistory = new ReadDataHistory(DateTime.Now, ReadDataResultType.Reading, "");
            //InstanceFactory.ReadExternalDataFacade.SystemReadDataFromAccessToSQL(readNewHistory, new Account());

            if (!Validation())
            {
                return;
            }

            try
            {
                Account loginInfo =
                    BllInstance.AccountBllInstance.LoginVerify(_ILoginView.LoginName, _ILoginView.Password,
                                                               _ILoginView.UsbKey, _ILoginView.UsbKeyCount);
                if (loginInfo != null)
                {
                    //note 获取CRM权限
                    //if (CompanyConfig.HasCRMSystem)
                    //    loginInfo.Auths.AddRange(FacadeInstance.CreateCRMAuthFacade().GetAccountCRMAuth(loginInfo.Id));
                    //todo 获取MyCMMI权限
                    //note 获取HRMIS权限
                    if (CompanyConfig.HasHrmisSystem)
                    {
                        loginInfo.Auths.AddRange(_IAccountAuthFacade.GetAccountAllAuth(loginInfo.Id, null));
                        SetLoginUserExtendAuth(loginInfo);
                    }

                    //note 获取EShopping权限
                    //if (CompanyConfig.HasEShoppingSystem)
                    //    loginInfo.Auths.AddRange(_IAccountAuthForEsFacade.GetAccountAllAuth(loginInfo.Id, null));
                }
                _ILoginView.LoginUser = loginInfo;
            }
            catch (Exception ex)
            {
                _ILoginView.LoginUser = null;
                _ILoginView.Message = ex.Message;
            }
        }

        /// <summary>
        /// 为当前员工增加额外权限，如对于一个主管来说考勤统计可以查看自己部门下所有员工的信息
        /// </summary>
        private void SetLoginUserExtendAuth(Account account)
        {
            List<Department> deptList = _IDepartmentBll.GetDepartmentAndChildrenDeptByLeaderID(account.Id);
            if (deptList.Count > 0)
            {
                Tools.MakeAccountHaveAuth(account,
                                         AuthType.HRMIS, HrmisPowers.A401, deptList);
                Tools.MakeAccountHaveAuth(account,
                                          AuthType.HRMIS, HrmisPowers.A405, deptList);
                Tools.MakeAccountHaveAuth(account,
                                          AuthType.HRMIS, HrmisPowers.A507, deptList);
                Tools.MakeAccountHaveAuth(account,
                                          AuthType.HRMIS, HrmisPowers.A607, deptList);
            }
        }
    }
}
