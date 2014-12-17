//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IEmployeeUpdatePasswordView.cs
// ������: ����
// ��������: 2008-06-23
// ����: �޸�����
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployee
{
    public interface IEmployeeUpdatePasswordView
    {
        string Message { set;}
        string OldPasswordMsg { set;}
        string ValidatPasswordMsg { set;}
        string ConfirmPasswordMsg { set;}

        string EmployeeID { get; set;}
        string EmployeeName { get; set;}
        string EmployeeOldPassword { get; set;}
        string EmployeeNewPassword { get; set;}
        string EmployeeConfirmPassword { get; set;}

        int UsbKeyCount { get; }
        string UsbKey { get; set;}
        string OldUsbKey { get; set;}

        bool ResetUsbKey{ set;}

        event EventHandler btnOKClick;
        event EventHandler btnResetUSBClick;
    }
}
