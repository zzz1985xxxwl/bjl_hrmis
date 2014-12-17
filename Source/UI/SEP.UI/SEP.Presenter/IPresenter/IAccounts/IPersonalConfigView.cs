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
        /// ȷ�ϰ�ť�¼�
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;
        /// <summary>
        /// ȡ����ť�¼�
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;

        event DelegateNoParameter ChangeButtonEvent;

        /// <summary>
        /// ��Ƭ
        /// </summary>
        byte[] Photo { get; set;}

        /// <summary>
        /// �޸���Ƭ  
        /// </summary>
        string PhotoHref { get; set;}
    }
}
