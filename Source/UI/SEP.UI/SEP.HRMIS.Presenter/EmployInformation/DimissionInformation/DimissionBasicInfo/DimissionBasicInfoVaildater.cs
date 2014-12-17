//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DimissionBasicInfoVaildater.cs
// ������: �ߺ�
// ��������: 2008-09-04
// ����: ��ְ��Ϣ�Ĵ�����������֤��
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