//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: EmployeeContractBasePresenter.cs
// ������: wang.shali
// ��������: 2008-8-15
// ����: Ա����ͬ����Presenter
// ----------------------------------------------------------------
using System;

namespace SEP.HRMIS.Presenter
{
    public class EmployeeContractBasePresenter
    {
        public readonly IEmployeeContractView _View;
        public DateTime _StartTime, _EndTime;
        public EmployeeContractBasePresenter(IEmployeeContractView view)
        {
            _View = view;
        }

        public bool Validate()
        {
            _View.ResultMessage = string.Empty;
            _View.TimeErrorMessage = string.Empty;
            if (string.IsNullOrEmpty(_View.ContractStartTime))
            {
                _View.TimeErrorMessage = "��ͬ��ʼʱ�������д";
                return false;
            }
            if (!DateTime.TryParse(_View.ContractStartTime, out _StartTime))
            {
                _View.TimeErrorMessage = "��ͬ��ʼʱ���ʽ���벻��ȷ";
                return false;
            }
            if (string.IsNullOrEmpty(_View.ContractEndTime))
            {
                _View.ContractEndTime = "2999-12-31";
            }
            if (!DateTime.TryParse(_View.ContractEndTime, out _EndTime))
            {
                _View.TimeErrorMessage = "��ͬ����ʱ���ʽ���벻��ȷ";
                return false;
            }

            if (DateTime.Compare(_StartTime, _EndTime) > 0)
            {
                _View.TimeErrorMessage = "��ͬ��ʼʱ�䲻�����ڽ���ʱ��";
                return false;
            }
            return true;
        }


    }
}
