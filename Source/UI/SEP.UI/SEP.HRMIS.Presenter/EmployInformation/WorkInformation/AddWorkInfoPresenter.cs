//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddWorkInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����: ����������Ϣ�����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.WorkInformation
{
    public class AddWorkInfoPresenter:WorkInfoPresenterBase,IAddEmployeePresenter
    {
        public AddWorkInfoPresenter(IWorkInfoView itsView)
            :base(itsView)
        {
            AttachViewEvent();
        }

        public bool Vaildate()
        {
            return new WorkInfoVaildater(_ItsView).Vaildate();
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            new WorkInfoDataCollector(_ItsView).CompleteTheObject(theObjectToComplete);
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            if(!pageIsPostBack)
            {
                _ItsView.ContractManageVisible = false;
                new WorkInfoViewIniter(_ItsView).InitTheViewToDefault();
                FatherSelectChangeEvent();
                DepartmentSelectChangeEvent();
            }
        }
    }
}