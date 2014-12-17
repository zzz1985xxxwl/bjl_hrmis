//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateEmployeeInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-10-09
// ����: �޸�Ա���ܽ����Presenter
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.EmployInformation.BasicInformation;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.EmployInformation.FamilyInformation;
using SEP.HRMIS.Presenter.EmployInformation.ResumeInformations;
using SEP.HRMIS.Presenter.EmployInformation.SkillInformation;
using SEP.HRMIS.Presenter.EmployInformation.WelfareInformation;
using SEP.HRMIS.Presenter.EmployInformation.WorkInformation;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.HRMIS.Presenter.EmployInformation.DimissionInformation.DimissionBasicInfo;
using SEP.HRMIS.Presenter.EmployInformation.FileCargosInformations;

namespace SEP.HRMIS.Presenter.EmployInformation
{
    public class UpdateEmployeeInfoPresenter : IEmployeeBasePresenter
    {
        private readonly IEmployeeInfoView _ItsView;
        private readonly string _EmployeeId;
        private readonly IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();
        private readonly IEmployeeWelfareFacade _IEmployeeWelfareFacade = InstanceFactory.CreateEmployeeWelfareFacade();
        private readonly Account _OperatorAccount; 

        private readonly List<IUpdateEmployeePresenter> _ThePresenters;
        private readonly VocationBackPresenter _TheVocationPresenter;
        /// <summary>
        /// ����Presenter���ľһ���һ��������Ա����Ϣ��ÿ��P�ֶ���InitView��DataBind,Vaildate��CompleteTheObject3��СP���
        /// </summary>
        /// <param name="itsView"></param>
        /// <param name="employeeId"></param>
        /// <param name="operatorAccount"></param>
        public UpdateEmployeeInfoPresenter(IEmployeeInfoView itsView, string employeeId, Account operatorAccount)
        {
            _OperatorAccount = operatorAccount;
            _ItsView = itsView;
            _EmployeeId = employeeId;

            _ThePresenters = new List<IUpdateEmployeePresenter>();
            _ThePresenters.Add(new UpdateBasicInfoPresenter(itsView.BasicInfoView));
            _ThePresenters.Add(new UpdateDimissionBasicInfoPresenter(itsView.DimissionInfoView));
            _ThePresenters.Add(new UpdateFamilyInfoPresenter(itsView.FamilyInfoView));
            _ThePresenters.Add(new UpdateResumeInfoPresenter(itsView.ResumeInfoView));
            _ThePresenters.Add(new UpdateWelfareInfoPresenter(itsView.WelfareInfoView));
            _ThePresenters.Add(new UpdateWorkInfoPresenter(itsView.WorkInfoView));
            _ThePresenters.Add(new UpdateSkillInfoPresenter(itsView.EmployeeSkillInfoView));
            AttachViewEvent();
            //�����Ϣ
            _TheVocationPresenter = new VocationBackPresenter(itsView);
            //����
            new UpdateFileCargosInfoPresenter(itsView.FileCargoInfoView, Convert.ToInt32(_EmployeeId));
        }

        public void AttachViewEvent()
        {
            _ItsView.BtnActionEvent += BtnActionEvent;
        }
        /// <summary>
        /// ѭ��ÿһ��P����ʼ��
        /// </summary>
        /// <param name="pageIsPostBack"></param>
        public void InitView(bool pageIsPostBack)
        {
            foreach(IUpdateEmployeePresenter aPresenter in _ThePresenters)
            {
                aPresenter.InitView(pageIsPostBack);
            }
            //����Ľ�����Ϣ����
            if (!pageIsPostBack)
            {
                _ItsView.Title = "�޸�Ա��";
                _ItsView.Message = string.Empty;
                _ItsView.MailToHRVisible = false;
                _ItsView.DimissionInfoVisible = true;
                _ItsView.VocationInfoVisible = true;
                _ItsView.BtnExportVisible = true;
            }
            _ItsView.WelfareInfoView.EmployeeWelfareVisible = Powers.HasAuth(_OperatorAccount.Auths, AuthType.HRMIS, HrmisPowers.A605);
            BindInfoToView(pageIsPostBack);
        }

        private void BindInfoToView(bool pageIsPostBack)
        {
            int id;
            if (!int.TryParse(_EmployeeId, out id))
            {
                _ItsView.Message = "��ʼ����Ϣʧ�ܣ�����ϵ����Ա";
                _ItsView.BtnActionVisible = false;
                _ItsView.ActionSuccess = false;
                return;
            }

            Employee theEmployee = _IEmployeeFacade.GetEmployeeByAccountID(id);
            
            //������Ϣ��
            theEmployee.EmployeeWelfare = _IEmployeeWelfareFacade.GetEmployeeWelfareByAccountID(id);
            theEmployee.EmployeeWelfareHistory = _IEmployeeWelfareFacade.GetEmployeeWelfareHistoryByAccountID(id);
           
            //������Ϣ��
            _TheVocationPresenter.InitTheVacation(theEmployee);
            if(!pageIsPostBack)
            {
                //tabҳ�����Ϣ��
                foreach (IUpdateEmployeePresenter aPresenter in _ThePresenters)
                {
                    aPresenter.DataBind(theEmployee);
                }
                //Ա��ҳ�����Ϸ�����Ϣ��
                SetExtraInfoToView(theEmployee);
               
            }
        }
        /// <summary>
        /// ���ȷ����ť���������¼�
        /// </summary>
        public void BtnActionEvent()
        {
            foreach (IUpdateEmployeePresenter aPresenter in _ThePresenters)
            {
                if (!aPresenter.Vaildate())
                {
                    _ItsView.Message = EmployeePresenterUtilitys._ErrorEmployeeNotCompleted;
                    _ItsView.ActionSuccess = false;
                    return;
                }
            }
            Employee theEmployee = _IEmployeeFacade.GetEmployeeByAccountID(int.Parse(_EmployeeId));
            foreach (IUpdateEmployeePresenter aPresenter in _ThePresenters)
            {
                aPresenter.CompleteTheObject(theEmployee);
            }
            if (!ValidateProhibation(theEmployee))
            {
                _ItsView.ActionSuccess = false;
                return;
            }
            try
            {
                _IEmployeeFacade.UpdateEmployeeProxy(theEmployee, _OperatorAccount);
                //���°󶨸�����ʷ
                _ItsView.WelfareInfoView.EmployeeWelfareHistory = theEmployee.EmployeeWelfareHistory = _IEmployeeWelfareFacade.GetEmployeeWelfareHistoryByAccountID(Convert.ToInt32(_EmployeeId)); ;

                _ItsView.Message = "�����ɹ�";
                _ItsView.ActionSuccess = true;

                SetExtraInfoToView(_IEmployeeFacade.GetEmployeeByAccountID(int.Parse(_EmployeeId)));
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
                _ItsView.ActionSuccess = false;
            }
        }

        public string ExportEmployeeEvent(string employeeTemplateLocation)
        {
            return _IEmployeeFacade.ExportEmployeeInfo(int.Parse(_EmployeeId), employeeTemplateLocation);
        }

        //����Ľ�����Ϣ�� 
        private void SetExtraInfoToView(Employee theEmployee)
        {
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

        private bool ValidateProhibation(Employee employee)
        {
            bool isValidate = true;
            if (employee.EmployeeType == EmployeeTypeEnum.ProbationEmployee || employee.EmployeeType == EmployeeTypeEnum.NormalEmployee)
            {
                if (employee.EmployeeDetails.ProbationStartTime <=
                                            Convert.ToDateTime("1900-01-01"))
                {
                    _ItsView.Message = "��ʽԱ������������Ա���������ڿ�ʼʱ�䣬����ʱ�������д";
                    isValidate = false;
                }
                if (employee.EmployeeDetails.ProbationTime <=
                                            Convert.ToDateTime("1900-01-01"))
                {
                    _ItsView.Message = "��ʽԱ������������Ա���������ڿ�ʼʱ�䣬����ʱ�������д";
                    isValidate = false;
                }
            }
            return isValidate;
        }

    }
}
