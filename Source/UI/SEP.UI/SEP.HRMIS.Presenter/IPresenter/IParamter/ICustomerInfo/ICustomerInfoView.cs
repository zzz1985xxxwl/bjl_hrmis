//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ICustomerInfoView.cs
// ������: ����
// ��������: 2009-11-06
// ����: �������͵��ܽ����ViewҪʵ�ֵĽӿ�
// ----------------------------------------------------------------
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IParamter.ICustomerInfo
{
    public interface ICustomerInfoView
    {
        string Message { set;}
        string NameMsg { set;}

        string CustomerInfoID { get; set; }
        string CompanyName { get; set;}


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
    }
}
