using System;
using SEP.IBll;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IAccounts;
using SEP.Model.Accounts;

namespace SEP.Presenter.Accounts
{
    public class ChangePasswordPresenter : BasePresenter
    {
        //public const string _SuccessImage =
        //   "&nbsp;&nbsp;&nbsp;<img src='../../image/cg.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;";
        //public const string _ErrorImage =
        //    "&nbsp;&nbsp;&nbsp;<img src='../../image/icon03.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;";

        private readonly IEmployeeUpdatePasswordView _View;

        public ChangePasswordPresenter(IEmployeeUpdatePasswordView view, Account loginUser)
            : base(loginUser)
        {
            _View = view;
        }

        public override void Initialize(bool isPostBack)
        {
            _View.Message = "";
            AttachViewEvent();
            if (!isPostBack)
            {
                _View.EmployeeName = LoginUser.LoginName;
            }
        }

        private void AttachViewEvent()
        {
            _View.btnOKClick += ExecuteEvent;
        }

        protected void ExecuteEvent(object sender, EventArgs e)
        {
            if (Vaildate())
            {
                try
                {
                    BllInstance.AccountBllInstance.ChangePassword(_View.EmployeeName, _View.EmployeeOldPassword,
                                                                  _View.EmployeeNewPassword, LoginUser);
                    _View.Message = "密码修改成功";
                }
                catch (Exception ex)
                {
                    _View.Message =  ex.Message;
                }
            }
        }

        protected bool Vaildate()
        {
            _View.OldPasswordMsg = "";
            _View.ValidatPasswordMsg = "";
            _View.ConfirmPasswordMsg = "";

            if (string.IsNullOrEmpty(_View.EmployeeOldPassword))
            {
                _View.OldPasswordMsg = "请输入旧密码";
                return false;
            }
            if (string.IsNullOrEmpty(_View.EmployeeNewPassword))
            {
                _View.ValidatPasswordMsg = "新密码不可为空";
                return false;
            }
            if (_View.EmployeeNewPassword.Length < 6)
            {
                _View.ValidatPasswordMsg = "密码长度不能少于6位";
                return false;
            }
            if (string.IsNullOrEmpty(_View.EmployeeConfirmPassword))
            {
                _View.ConfirmPasswordMsg = "请重新输入新密码";
                return false;
            }
            if (_View.EmployeeConfirmPassword != _View.EmployeeNewPassword)
            {
                _View.ConfirmPasswordMsg = "两次密码不正确,请重新输入";
                return false;
            }
            return true;
        }
    }
}
