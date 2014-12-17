using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.Presenter.IPresenter.IAccounts
{
    public interface IPersonalConfigView
    {
        string Message { set;}
        bool AcceptEmail { get; set;}
        bool AcceptSMS { get; set;}
        bool ValidateUsbKey { get; set;}

        int UsbKeyCount { get;}
        string UsbKey { get;}
        string UsbKeyMsg { set;}
        string ElectricNameMsg { set;}
        /// <summary>
        /// 确认按钮事件
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;

        event DelegateNoParameter ChangeButtonEvent;

        /// <summary>
        /// 照片
        /// </summary>
        byte[] Photo { get; set;}

        /// <summary>
        /// 修改照片  
        /// </summary>
        string PhotoHref { get; set;}
    }
}
