//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DimissionBasicInfoVaildater.cs
// 创建者: 倪豪
// 创建日期: 2008-09-04
// 概述: 离职信息的大界面的数据验证类
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews;

namespace SEP.HRMIS.Presenter.EmployInformation.DimissionInformation.DimissionBasicInfo
{
    public class DimissionBasicInfoVaildater : IVaildater
    {
        private readonly IDimissionBasicView _ItsView;

        public DimissionBasicInfoVaildater(IDimissionBasicView itsView)
        {
            _ItsView = itsView;
        }

        public bool Vaildate()
        {
            if (!string.IsNullOrEmpty(_ItsView.DimissionDate))
            {
                bool dimisssionMonth = VaildateDimissionMonth();
                bool dimissionDate = VaildateDimissionDate();

                return dimisssionMonth && dimissionDate;
            }
            else
            {
                _ItsView.DimissionDateMessage = string.Empty;
                _ItsView.DimissionMonthMessage = string.Empty;
                return true;
            }
        }

        private bool VaildateDimissionDate()
        {
            DateTime date;
            if (!DateTime.TryParse(_ItsView.DimissionDate, out date))
            {
                _ItsView.DimissionDateMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                return false;
            }
            _ItsView.DimissionDateMessage = string.Empty;
            return true;
        }

        private bool VaildateDimissionMonth()
        {
            if (!string.IsNullOrEmpty(_ItsView.DimissionMonth))
            {
                decimal Month;
                if (!Decimal.TryParse(_ItsView.DimissionMonth, out Month))
                {
                    _ItsView.DimissionMonthMessage = EmployeePresenterUtilitys._ErrorNumberRequired;
                    return false;
                }
            }

            _ItsView.DimissionMonthMessage = string.Empty;
            return true;
        }
    }
}