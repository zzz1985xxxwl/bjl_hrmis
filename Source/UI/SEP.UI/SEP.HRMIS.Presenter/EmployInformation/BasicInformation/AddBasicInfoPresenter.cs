//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: EmployeeDetailBasicPresenter.cs
// ������: ����
// ��������: 2008-09-04
// ����: Ա������������Ϣ��
// �޸�: ������룬�����ʾ����� by �ߺ�
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.BasicInformation
{
    public class AddBasicInfoPresenter:IAddEmployeePresenter
    {
        protected readonly IBasicInfoView _ItsView;

        public AddBasicInfoPresenter(IBasicInfoView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            if(!pageIsPostBack)
            {
                //��ʼ��Ա��������
                BasicInfoViewIniter theViewIniter = new BasicInfoViewIniter(_ItsView);
                theViewIniter.InitTheViewToDefault();
                _ItsView.PhotoHref = "javascript:PhotoHiddenBtnClick();";
            }
        }
        public bool Vaildate()
        {
            //��֤
            BasicInfoVaildater theVaildater = new BasicInfoVaildater(_ItsView);
            return theVaildater.Vaildate();
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            BasicInfoDataCollector theDataCollector = new BasicInfoDataCollector(_ItsView);
            //Ա��������Ϣ�����ռ�
            theDataCollector.CompleteTheObject(theObjectToComplete);
            //ΪԱ�����ʺ�����Ĭ������
            //�Ƶ�ҵ���
            //theObjectToComplete.AccountsFront.SetDefaultPassword();
        }
    }
}
