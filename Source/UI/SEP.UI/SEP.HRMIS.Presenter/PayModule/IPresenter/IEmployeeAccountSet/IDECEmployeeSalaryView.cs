using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet
{
    public interface IDECEmployeeSalaryView
    {
        /// <summary>
        /// 解密事件
        /// </summary>
        event DelegateNoParameter DECEmployeeSalaryEvent;
        /// <summary>
        /// 加密字符串
        /// </summary>
        string EmployeeSalaryCode { get;set;}
        string EmployeeSalaryCodeMsg{ set;}
        /// <summary>
        /// 操作信息
        /// </summary>
        string Message { set;}
        /// <summary>
        /// 解密字符串
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
