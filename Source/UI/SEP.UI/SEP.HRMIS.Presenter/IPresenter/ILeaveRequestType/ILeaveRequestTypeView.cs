//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ILeaveTypeView.cs
// ������: wangshlai
// ��������: 2008-08-04
// ����: ����������ͼ����
// ----------------------------------------------------------------


using SEP.HRMIS.Model.Request;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ILeaveRequestType
{
    public interface ILeaveRequestTypeView
    {

        string Message { get;set;}
        string NameMsg { get;set;}
        string LeastHourMsg { get;set;}
        string LeaveRequestTypeID { get; set; }
        string LeaveRequestTypeName { get; set;}
        string LeaveRequestTypeDescription { get; set;}

        /// <summary>
        /// ȷ�ϰ�ť�¼�
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;
        /// <summary>
        /// ȡ����ť�¼�
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;
        /// <summary>
        /// �������
        /// </summary>
        string OperationTitle { set; get;}
        /// <summary>
        /// ��������
        /// </summary>
        string OperationType { get; set;}
        /// <summary>
        /// ȷ�ϰ�ť��ʾ���ַ�
        /// </summary>
        string ActionButtonTxt { get; set;}
        /// <summary>
        /// �����Ƿ�ɹ�
        /// </summary>
        bool ActionSuccess { get; set;}
        
        bool SetReadonly { set; }
        bool SetIDReadonly { set;}
        // add syy ==modify by wyq
        LegalHoliday IncludeLegalHoliday{ get; set;}

        RestDay IncludeRestDay { get; set;}

        string LeastHour { get; set;}

    }
}
