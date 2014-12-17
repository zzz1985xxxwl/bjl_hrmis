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
                    _View.Message = "�����޸ĳɹ�";
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
                _View.OldPasswordMsg = "�����������";
                return false;
            }
            if (string.IsNullOrEmpty(_View.EmployeeNewPassword))
            {
                _View.ValidatPasswordMsg = "�����벻��Ϊ��";
                return false;
            }
            if (_View.EmployeeNewPassword.Length < 6)
            {
                _View.ValidatPasswordMsg = "���볤�Ȳ�������6λ";
                return false;
            }
            if (string.IsNullOrEmpty(_View.EmployeeConfirmPassword))
            {
                _View.ConfirmPasswordMsg = "����������������";
                return false;
            }
            if (_View.EmployeeConfirmPassword != _View.EmployeeNewPassword)
            {
                _View.ConfirmPasswordMsg = "�������벻��ȷ,����������";
                return false;
            }
            return true;
        }
    }
}
