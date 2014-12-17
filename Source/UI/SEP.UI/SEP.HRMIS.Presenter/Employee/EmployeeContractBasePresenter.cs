//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeContractBasePresenter.cs
// 创建者: wang.shali
// 创建日期: 2008-8-15
// 概述: 员工合同更新Presenter
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
                _View.TimeErrorMessage = "合同开始时间必须填写";
                return false;
            }
            if (!DateTime.TryParse(_View.ContractStartTime, out _StartTime))
            {
                _View.TimeErrorMessage = "合同开始时间格式输入不正确";
                return false;
            }
            if (string.IsNullOrEmpty(_View.ContractEndTime))
            {
                _View.ContractEndTime = "2999-12-31";
            }
            if (!DateTime.TryParse(_View.ContractEndTime, out _EndTime))
            {
                _View.TimeErrorMessage = "合同结束时间格式输入不正确";
                return false;
            }

            if (DateTime.Compare(_StartTime, _EndTime) > 0)
            {
                _View.TimeErrorMessage = "合同开始时间不可晚于结束时间";
                return false;
            }
            return true;
        }


    }
}
