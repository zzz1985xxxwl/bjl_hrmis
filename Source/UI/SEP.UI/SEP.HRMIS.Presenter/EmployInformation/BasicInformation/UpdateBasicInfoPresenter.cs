//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: EmployeeDetailBasicPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-21
// ����: Ա���޸Ļ�����Ϣ��Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.BasicInformation
{
    public class UpdateBasicInfoPresenter : IUpdateEmployeePresenter
    {
        private readonly IBasicInfoView _ItsView;
       
        public UpdateBasicInfoPresenter(IBasicInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                BasicInfoViewIniter theIniter = new BasicInfoViewIniter(_ItsView);
                theIniter.InitTheViewToDefault();
                _ItsView.PhotoHref = "javascript:PhotoHiddenBtnClick();";
            }
        }

        public bool DataBind(Employee theDataToBind)
        {
            BasicInfoDataBinder theDataBinder = new BasicInfoDataBinder(_ItsView);
            return theDataBinder.DataBind(theDataToBind);
        }

        public bool Vaildate()
        {
            BasicInfoVaildater theVaildater = new BasicInfoVaildater(_ItsView);
            return theVaildater.Vaildate();
        }

        public void AttachViewEvent()
        {
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            BasicInfoDataCollector theDataCollector = new BasicInfoDataCollector(_ItsView);
            theDataCollector.CompleteTheObject(theObjectToComplete);
        }
    }
}