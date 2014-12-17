//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AccountBackVaildater.cs
// ������: ���޾�
// ��������: 2008-10-07
// ����: ��ͬ����С�����������֤��
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IContractType;

namespace SEP.HRMIS.Presenter.Parameter.ContractTypePresenter
{
    public class ContractTypeVaildater : IVaildater
    {
        private readonly IContractType _ItsView;

        public ContractTypeVaildater(IContractType itsView)
        {
            _ItsView = itsView;
        }

        public bool Vaildate()
        {
            if (String.IsNullOrEmpty(_ItsView.ContractTypeName.Trim()))
            {
                _ItsView.ValidateName = "��ͬ����������Ϊ��";
                return false;
            }
            if(!_ItsView.CheckFileType)
            {
                _ItsView.ResultMessage = "�ϴ���ʽ�������ϴ��ǿյ�word�ĵ�";
                return false;//Ϊ�ϴ�word����ʽ�ж�
            }
            else
            {
                _ItsView.ValidateName = string.Empty;
                return true;
            }
        }
    }
}
