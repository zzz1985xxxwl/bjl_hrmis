//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: IContractTypeView.cs
// ������: ���޾�
// ��������: 2008-10-07
// ����: ��ͬ����С�����ViewҪʵ�ֵĽӿ�
// ----------------------------------------------------------------
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType
{
    public interface IContractType
    {
        /// <summary>
        /// ��ͬ����ID
        /// </summary>
        string ContractTypeID { get; set; }
        /// <summary>
        /// ��ͬ��������
        /// </summary>
        string ContractTypeName { get; set; }
        /// <summary>
        /// ��ͬģ��
        /// </summary>
        byte[] ContractTypeTemplate{ get;}
        /// <summary>
        /// ��ͬ�������Ƶ���Ϣ
        /// </summary>
        string ResultMessage { get;set; }
        /// <summary>
        /// ��ͬ����ID�Ƿ���Ч
        /// </summary>
        string ValidateID { get; set; }
        /// <summary>
        /// ��ͬ���������Ƿ���Ч
        /// </summary>
        string ValidateName { get; set; }
        /// <summary>
        /// �Ƿ�ֻ��
        /// </summary>
        bool SetReadonly { get; set; }
        /// <summary>
        /// С�������
        /// </summary>
        string Title { get; set;}
        /// <summary>
        /// �����Ƿ�ɹ�
        /// </summary>
        bool ActionSuccess { get; set;}
        /// <summary>
        /// ��������
        /// </summary>
        string OperationType { get; set;}
        /// <summary>
        /// ȷ�ϰ�ť�¼�
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;
        /// <summary>
        /// ȡ����ť�¼�
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;
        /// <summary>
        /// ȷ�ϰ�ť�Ƿ����
        /// </summary>
        bool ActionButtonEnable { get; set;}

         /// <summary>
        /// �ж��ϴ�����
        /// </summary>
        bool CheckFileType{ get; set;}
        //event EventHandler btnOKClick;
        //event EventHandler btnCancelServerClick;
    }
}
