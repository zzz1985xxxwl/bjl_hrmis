//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: FrontViewEmployeeInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-10-09
// ����: ǰ̨�鿴Ա���ܽ����Presenter
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.WorkInformation;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation
{
    public class FrontViewEmployeeInfoPresenter : ViewEmployeeInfoPresenterBase
    {
        private readonly VacationFrontPresenter _TheVacationPresenter;
        private IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();

        public FrontViewEmployeeInfoPresenter(IEmployeeInfoView itsView, string employeeId)
            : base(itsView, employeeId)
        {
            _ThePresenters.Add(new ViewWorkInfoPresenter(itsView.WorkInfoView,true));
            _TheVacationPresenter=new VacationFrontPresenter(itsView);
        }
        /// <summary>
        /// ����ǰ̨��ʾԱ������ʱ����Щ��Ϣ���ɼ�
        /// </summary>
        /// <param name="pageIsPostBack"></param>
        protected override void InitOthers(bool pageIsPostBack)
        {
            _ItsView.DimissionInfoVisible = false;
            _ItsView.VocationInfoVisible = true;
            _ItsView.MailToHRVisible = true;
            _ItsView.BtnExportVisible = false;
            Employee theEmployee = _IEmployeeFacade.GetEmployeeByAccountID(Convert.ToInt32(_EmployeeId));
            _TheVacationPresenter.InitTheVacation(theEmployee);
            _ItsView.WelfareInfoView.EmployeeWelfareVisible = false;
        }
    }
}