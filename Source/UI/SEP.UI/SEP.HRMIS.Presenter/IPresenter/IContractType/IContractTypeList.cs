//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: IContractTypeListView.cs
// ������: ���޾�
// ��������: 2008-10-07
// ����: ��ͬ���ʹ�����ViewҪʵ�ֵĽӿ�
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType
{
    public interface IContractTypeList
    {
        /// <summary>
        /// ��ͬ��������Դ
        /// </summary>
        List<ContractType> ContractTypeSource { get;set;}
        ///// <summary>
        ///// ��ͬID
        ///// </summary>
        //string ContractTypeID { get; set;}
        /// <summary>
        /// ��ͬ����
        /// </summary>
        string ContractTypeName { get; set;}
        /// <summary>
        /// ��������Ϣ
        /// </summary>
        string Message { get; set;}
        /// <summary>
        /// ������ť�¼�
        /// </summary>
        event DelegateNoParameter BtnAddEvent;
        /// <summary>
        /// �޸İ�ť�¼�
        /// </summary>
        event DelegateID BtnUpdateEvent;
        /// <summary>
        /// ɾ����ť�¼�
        /// </summary>
        event DelegateID BtnDeleteEvent;        
        /// <summary>
        /// ɾ����ť�¼�
        /// </summary>
        event DelegateID BtnDetialEvent;
        /// <summary>
        /// ��ѯ��ť�¼�
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;

        event DelegateReturnByte BtnDownLordEvent;

    }
}
