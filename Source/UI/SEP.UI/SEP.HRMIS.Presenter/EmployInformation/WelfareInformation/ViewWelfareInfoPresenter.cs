//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ViewWelfareInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: �鿴���������Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.WelfareInformation
{
    public class ViewWelfareInfoPresenter:IViewEmployeePresenter
    {
         private readonly IWelfareInfoView _ItsView;

        public  ViewWelfareInfoPresenter(IWelfareInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public bool DataBind(Employee theDataToBind)
        {
            return new WelfareInfoDataBinder(_ItsView).DataBind(theDataToBind);
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            WelfareInfoViewIniter welfareInfoViewIniter = new WelfareInfoViewIniter(_ItsView);
            welfareInfoViewIniter.SetFiledAndMessageEmpty();
            if (!pageIsPostBack)
            {
                welfareInfoViewIniter.InitTheViewToDefault();
            }
        }
    }
}