//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ViewEmployeeInfoPresenterBase.cs
// ������: �ߺ�
// ��������: 2008-10-09
// ����: �鿴Ա���ܽ����Presenter�Ļ��࣬�κβ鿴Ա���ļ̳и�����Ϊ
//       ģ��
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.BasicInformation;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.EmployInformation.FamilyInformation;
using SEP.HRMIS.Presenter.EmployInformation.ResumeInformations;
using SEP.HRMIS.Presenter.EmployInformation.SkillInformation;
using SEP.HRMIS.Presenter.EmployInformation.WelfareInformation;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;
using SEP.HRMIS.Presenter.EmployInformation.FileCargosInformations;
using SEP.HRMIS.Presenter.EmployInformation.DimissionInformation.DimissionBasicInfo;

namespace SEP.HRMIS.Presenter.EmployInformation
{
    public abstract class ViewEmployeeInfoPresenterBase : IEmployeeBasePresenter
    {
        protected readonly IEmployeeInfoView _ItsView;
        protected readonly string _EmployeeId;
        protected readonly List<IViewEmployeePresenter> _ThePresenters;
        private readonly IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();
        private readonly IEmployeeWelfareFacade _IEmployeeWelfareFacade = InstanceFactory.CreateEmployeeWelfareFacade();
        protected abstract void InitOthers(bool pageIsPostBack);

        protected ViewEmployeeInfoPresenterBase(IEmployeeInfoView itsView, string employeeId)
        {
            _ItsView = itsView;
            _EmployeeId = employeeId;

            _ThePresenters = new List<IViewEmployeePresenter>();
            _ThePresenters.Add(new ViewBasicInfoPresenter(itsView.BasicInfoView));
            _ThePresenters.Add(new ViewDimissionBasicInfoPresenter(itsView.DimissionInfoView));
            _ThePresenters.Add(new ViewResumeInfoPresenter(itsView.ResumeInfoView));
            _ThePresenters.Add(new ViewFamilyInfoPresenter(itsView.FamilyInfoView));
            _ThePresenters.Add(new ViewResumeInfoPresenter(itsView.ResumeInfoView));
            _ThePresenters.Add(new ViewWelfareInfoPresenter(itsView.WelfareInfoView));
            _ThePresenters.Add(new ViewSkillInfoPresenter(itsView.EmployeeSkillInfoView));
            new ViewFileCargosInfoPresenter(itsView.FileCargoInfoView, Convert.ToInt32(_EmployeeId));
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
        }

        public void InitView(bool pageIsPostBack)
        {
            foreach (IViewEmployeePresenter aPresenter in _ThePresenters)
            {
                aPresenter.InitView(pageIsPostBack);
            }
            //����Ľ�����Ϣ����
            if(!pageIsPostBack)
            {
                _ItsView.BtnActionVisible = false;
                _ItsView.Title = "�鿴Ա��";
                _ItsView.Message = string.Empty;
            }
            BindInfoToView(pageIsPostBack);
            //�ɼ̳������ɶ�����ʾ�����
            InitOthers(pageIsPostBack);
        }

        private void BindInfoToView(bool pageIsPostBack)
        {
            int id;
            if (!int.TryParse(_EmployeeId, out id))
            {
                _ItsView.Message = "��ʼ����Ϣʧ�ܣ�����ϵ����Ա";
                _ItsView.BtnActionVisible = false;
                return;
            }

            if (!pageIsPostBack)
            {
                Employee theEmployee = _IEmployeeFacade.GetEmployeeByAccountID(id);
                theEmployee.EmployeeWelfare = _IEmployeeWelfareFacade.GetEmployeeWelfareByAccountID(id);
                theEmployee.EmployeeWelfareHistory = _IEmployeeWelfareFacade.GetEmployeeWelfareHistoryByAccountID(id);
                foreach (IViewEmployeePresenter aPresenter in _ThePresenters)
                {
                    aPresenter.DataBind(theEmployee);
                }
                //����Ľ�����Ϣ�� 
                if (theEmployee.EmployeeDetails.Work != null)
                {
                    _ItsView.ComeDate = theEmployee.EmployeeDetails.Work.ComeDate <= Convert.ToDateTime("1900-01-01")
                ? string.Empty
                : theEmployee.EmployeeDetails.Work.ComeDate.ToShortDateString(); 
                }
                _ItsView.Department = theEmployee.Account.Dept.Name;
                _ItsView.EmployeeName = theEmployee.Account.Name;
                _ItsView.AccountNo = theEmployee.Account.Id.ToString();
                _ItsView.Position = theEmployee.Account.Position.Name;
                _ItsView.PositionID = theEmployee.Account.Position.Id.ToString();
            }
        }
    }
}