using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet
{
    public interface IDECEmployeeSalaryView
    {
        /// <summary>
        /// �����¼�
        /// </summary>
        event DelegateNoParameter DECEmployeeSalaryEvent;
        /// <summary>
        /// �����ַ���
        /// </summary>
        string EmployeeSalaryCode { get;set;}
        string EmployeeSalaryCodeMsg{ set;}
        /// <summary>
        /// ������Ϣ
        /// </summary>
        string Message { set;}
        /// <summary>
        /// �����ַ���
        /// </summary>
        string DECEmployeeSalaryResult { set;}
        /// <summary>
        /// USBKEY
        /// </summary>
        string UsbKey { set; get;}
        int UsbKeyCount { get;}
        Account CurrentUser { get; }
    }
}
