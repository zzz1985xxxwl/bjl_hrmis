using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet;
using ShiXin.Security;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet
{
    public class DECEmployeeSalaryPresenter
    {
        private IDECEmployeeSalaryView _IDECEmployeeSalaryView;
        public DECEmployeeSalaryPresenter(IDECEmployeeSalaryView iDECEmployeeSalaryView)
        {
            _IDECEmployeeSalaryView = iDECEmployeeSalaryView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _IDECEmployeeSalaryView.DECEmployeeSalaryEvent += DECEmployeeSalaryEvent;
        }

        public void InitPresent(bool ispostback)
        {
            if (!ispostback)
            {
                _IDECEmployeeSalaryView.Message = string.Empty;
                _IDECEmployeeSalaryView.DECEmployeeSalaryResult = string.Empty;
            }
        }

        private void DECEmployeeSalaryEvent()
        {
            if (CheckValid())
            {
                try
                {
                    _IDECEmployeeSalaryView.DECEmployeeSalaryResult =
                        SecurityUtil.SymmetricDecrypt(_IDECEmployeeSalaryView.EmployeeSalaryCode,
                                                      SecurityUtil.SymmetricEncrypt(_IDECEmployeeSalaryView.UsbKey,
                                                                                    _IDECEmployeeSalaryView.CurrentUser.LoginName));
                }
                catch
                {
                    _IDECEmployeeSalaryView.Message = "解密失败";
                }
            }
        }

        private bool CheckValid()
        {
            bool ret = true;
            _IDECEmployeeSalaryView.EmployeeSalaryCodeMsg = string.Empty;
            _IDECEmployeeSalaryView.Message = string.Empty;
            if(string.IsNullOrEmpty(_IDECEmployeeSalaryView.EmployeeSalaryCode))
            {
                _IDECEmployeeSalaryView.EmployeeSalaryCodeMsg = "不可为空";
                ret = false;
            }
            if (_IDECEmployeeSalaryView.UsbKeyCount>1)
            {
                _IDECEmployeeSalaryView.Message = "请确保插入一个UsbKey身份认证";
                ret = false;
            }
            if (string.IsNullOrEmpty(_IDECEmployeeSalaryView.UsbKey))
            {
                _IDECEmployeeSalaryView.Message = "请插入一个UsbKey";
                ret = false;
            }
            return ret;
        }
    }
}
