//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ICompnayLinkManView.cs
// ������: wangshlai
// ��������: 2009-06-30
// ����: ��˾��ϵ����ͼ����
// ----------------------------------------------------------------

using System;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ICompanyLinkMan
{
    public interface ICompnayLinkManView
    {

        string Message { get; set;}

        Guid LinkManId { get; set;}
        string LinkManName { get; set;}
        string MobileNo { get; set;}
        string HomeNo { get; set;}
        string OfficeNo { get; set;}
        string EmailAddr { get; set;}

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
        /// �����Ƿ�ɹ�
        /// </summary>
        bool ActionSuccess { get; set;}

        bool SetReadonly { set; }


    }
}