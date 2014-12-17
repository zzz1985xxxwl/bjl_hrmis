//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: EmployeeDetailBasicPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-21
// ����: ��ʾԱ��������Ϣ��Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.BasicInformation
{
    public class ViewBasicInfoPresenter:IViewEmployeePresenter
    {
        private readonly IBasicInfoView _ItsView;

        public ViewBasicInfoPresenter(IBasicInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public bool DataBind(Employee theDataToBind)
        {
            BasicInfoDataBinder theDataBinder = new BasicInfoDataBinder(_ItsView);
            return theDataBinder.DataBind(theDataToBind);
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                BasicInfoViewIniter theIniter = new BasicInfoViewIniter(_ItsView);
                theIniter.InitTheViewToDefault();
            }
        }
    }
}