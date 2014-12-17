//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddResumeBasicInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: �޸ĸ��������Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.WelfareInformation
{
    public class UpdateWelfareInfoPresenter : IUpdateEmployeePresenter
    {
        private readonly IWelfareInfoView _ItsView;

        public UpdateWelfareInfoPresenter(IWelfareInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public bool DataBind(Employee theDataToBind)
        {
            return new WelfareInfoDataBinder(_ItsView).DataBind(theDataToBind);
        }

        public bool Vaildate()
        {
            return new WelfareInfoVaildater(_ItsView).Vaildate();
        }


        public void CompleteTheObject(Employee theObjectToComplete)
        {
            new WelfareInfoDataCollector(_ItsView).CompleteTheObject(theObjectToComplete);
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            WelfareInfoViewIniter welfareInfoViewIniter = new WelfareInfoViewIniter(_ItsView);
            _ItsView.EmployeeWelfareVisible = true;
            welfareInfoViewIniter.SetFiledAndMessageEmpty();
            if (!pageIsPostBack)
            {
                welfareInfoViewIniter.InitTheViewToDefault();
            }
        }
    }
}