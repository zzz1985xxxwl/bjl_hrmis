//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: WelfareInfoViewIniter.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: ��������Ľ����ʼ����
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.WelfareInformation
{
    public class WelfareInfoViewIniter : IViewIniter
    {
        private readonly IWelfareInfoView _ItsView;

        public WelfareInfoViewIniter(IWelfareInfoView itsView)
        {
            _ItsView = itsView;
        }

        public void InitTheViewToDefault()
        {
            //�ֶ���ϢΪ��
            //SetFiledAndMessageEmpty();
            //��������Դ��
            BindTypesSource();
        }

        public void SetFiledAndMessageEmpty()
        {
            //_ItsView.Orgnaization = string.Empty;
            //_ItsView.ResidentDate = string.Empty;
            _ItsView.ResidentDateMessage = string.Empty;
            _ItsView.WorkTypeMessage = string.Empty;
            _ItsView.AccumulationFundBaseMessage = string.Empty;
            _ItsView.AccumulationFundYearMonthMessage = string.Empty;
            _ItsView.SocialSecurityBaseMessage = string.Empty;
            _ItsView.SocialSecurityYearMonthMessage = string.Empty;
            _ItsView.AccumulationFundSupplyBaseMessage = string.Empty;
            _ItsView.YangLaoBaseMessage = string.Empty;
            _ItsView.ShiYeBaseMessage = string.Empty;
            _ItsView.YiLiaoBaseMessage = string.Empty;
        }

        private void BindTypesSource()
        {
            _ItsView.WorkTypeSource = WorkType.GetAll();
            _ItsView.WorkType = WorkType.Contract.Id.ToString();
            _ItsView.SocialSecurityTypeSource = SocialSecurityTypeEnum.GetAll();
            _ItsView.SocialSecurityType = SocialSecurityTypeEnum.Null;
        }

    }
}