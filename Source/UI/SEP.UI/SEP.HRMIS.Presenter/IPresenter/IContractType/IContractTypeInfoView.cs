//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: IContractTypeInfoView.cs
// ������: ���޾�
// ��������: 2008-10-07
// ����: ��ͬ�����ܽ����ViewҪʵ�ֵĽӿ�
// ----------------------------------------------------------------
namespace SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType
{
    public interface IContractTypeInfoView
    {
        /// <summary>
        /// �����
        /// </summary>
        IContractTypeList ContractTypeListView { get;set;}
        /// <summary>
        /// С����
        /// </summary>
        IContractType ContractTypeView { get;set;}
        /// <summary>
        /// С����ɼ�
        /// </summary>
        bool ContractTypeViewVisible { get;set;}
    }
}
