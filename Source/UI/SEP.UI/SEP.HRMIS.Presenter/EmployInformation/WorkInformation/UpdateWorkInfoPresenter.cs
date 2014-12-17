//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateWorkInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-09-25
// ����:�޸Ĺ�����Ϣ�����Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.WorkInformation
{
    public class UpdateWorkInfoPresenter:WorkInfoPresenterBase,IUpdateEmployeePresenter
    {
        public UpdateWorkInfoPresenter(IWorkInfoView itsView)
            :base(itsView)
        {
            AttachViewEvent();
        }

        public bool DataBind(Employee theDataToBind)
        {
            _ItsView.AccountIdForProcess = theDataToBind.Account.Id;
            bool retVal = new WorkInfoDataBinder(_ItsView,false).DataBind(theDataToBind);
            FatherSelectChangeEvent();
            DepartmentSelectChangeEvent();
            DiyProcessSelectChangeEvent(string.Empty);
            return retVal;
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
            if (!pageIsPostBack)
            {
                _ItsView.ContractManageVisible = true;
                new WorkInfoViewIniter(_ItsView).InitTheViewToDefault();
            }
        }
    }
}