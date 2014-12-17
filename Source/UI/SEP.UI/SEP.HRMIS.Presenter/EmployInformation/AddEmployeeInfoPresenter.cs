//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddEmployeeInfoPresenter.cs
// ������: �ߺ�
// ��������: 2008-10-09
// ����: ����Ա���ܽ����Presenter
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
using SEP.HRMIS.Presenter.EmployInformation.WorkInformation;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;
using SEP.Model.Accounts;
using SEP.HRMIS.Presenter.EmployInformation.DimissionInformation.DimissionBasicInfo;
using SEP.HRMIS.Presenter.EmployInformation.FileCargosInformations;

namespace SEP.HRMIS.Presenter.EmployInformation
{
    public class AddEmployeeInfoPresenter : IEmployeeBasePresenter
    {
        private readonly IEmployeeInfoView _ItsView;
        private readonly List<IAddEmployeePresenter> _ThePresenters;
        private IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();
        private Account _OperatorAccount; 
        /// <summary>
        /// ����Presenter���ľһ���һ��������Ա����Ϣ��ÿ��P�ֶ���InitView��Vaildate��CompleteTheObject3��СP���
        /// </summary>
        /// <param name="itsView"></param>
        /// <param name="operatorAccount"></param>
        public AddEmployeeInfoPresenter(IEmployeeInfoView itsView, Account operatorAccount)
        {
            _OperatorAccount = operatorAccount;
            _ItsView = itsView;
            _ThePresenters = new List<IAddEmployeePresenter>();
            //������Ϣ
            _ThePresenters.Add(new AddBasicInfoPresenter(itsView.BasicInfoView));
            //��ְ��Ϣ
            _ThePresenters.Add(new AddDimissionBasicInfoPresenter(itsView.DimissionInfoView));      
            //��ͥ��Ϣ
            _ThePresenters.Add(new AddFamilyInfoPresenter(itsView.FamilyInfoView));
            //����
            _ThePresenters.Add(new AddResumeInfoPresenter(itsView.ResumeInfoView));
            //����
            _ThePresenters.Add(new AddWelfareInfoPresenter(itsView.WelfareInfoView));
            //����
            _ThePresenters.Add(new AddWorkInfoPresenter(itsView.WorkInfoView));
            //����
            _ThePresenters.Add(new AddSkillInfoPresenter(itsView.EmployeeSkillInfoView));
            //������Ϣ
            new AddFileCargosInfoPresenter(itsView.FileCargoInfoView, 0);
            AttachViewEvent();
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
            foreach(IAddEmployeePresenter aPresenter in _ThePresenters)
            {
                aPresenter.InitView(pageIsPostBack);
            }
            if(!pageIsPostBack)
            {
                _ItsView.Title = "����Ա��";
                _ItsView.Message = string.Empty;
                _ItsView.ComeDate = string.Empty;
                _ItsView.Department = string.Empty;
                _ItsView.EmployeeName = string.Empty;
                _ItsView.AccountNo = string.Empty;
                _ItsView.Position = string.Empty;
                _ItsView.MailToHRVisible = false;
                _ItsView.DimissionInfoVisible = true;
                _ItsView.VocationInfoVisible = false;
                _ItsView.BtnExportVisible = false;
            }
        }
        /// <summary>
        /// ���ȷ����ť���������¼�
        /// </summary>
        public void BtnActionEvent()
        {
            //��֤��Ϣ�Ƿ���д��ȫ����ʽ�Ƿ���ȷ
            bool vaild = true;
            foreach (IAddEmployeePresenter aPresenter in _ThePresenters)
            {      
                if(!aPresenter.Vaildate())
                {
                    _ItsView.Message = "Ա����Ϣ��д����������д��ʽ����!";
                    _ItsView.ActionSuccess = false;
                    vaild = false;
                }
            }
            if (!vaild)
            {
                return;
            }
            //����д����Ϣ��ֵ��aNewObject����
            Employee aNewObject = new Employee();
            foreach (IAddEmployeePresenter aPresenter in _ThePresenters)
            {
                aPresenter.CompleteTheObject(aNewObject);
            }
            try
            {
                _IEmployeeFacade.AddEmployeeProxy(aNewObject, _OperatorAccount);
                _ItsView.Message = "�����ɹ�";
                _ItsView.ActionSuccess = true;
            }
            catch(ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
                _ItsView.ActionSuccess = false;
            }
        }
    }
}
