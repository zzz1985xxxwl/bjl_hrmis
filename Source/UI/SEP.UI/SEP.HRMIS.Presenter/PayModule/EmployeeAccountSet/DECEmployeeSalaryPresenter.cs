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
                    _IDECEmployeeSalaryView.Message = "����ʧ��";
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
                _IDECEmployeeSalaryView.EmployeeSalaryCodeMsg = "����Ϊ��";
                ret = false;
            }
            if (_IDECEmployeeSalaryView.UsbKeyCount>1)
            {
                _IDECEmployeeSalaryView.Message = "��ȷ������һ��UsbKey�����֤";
                ret = false;
            }
            if (string.IsNullOrEmpty(_IDECEmployeeSalaryView.UsbKey))
            {
                _IDECEmployeeSalaryView.Message = "�����һ��UsbKey";
                ret = false;
            }
            return ret;
        }
    }
}
