//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddEmployeeInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-10-09
// 概述: 新增员工总界面的Presenter
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
        /// 各个Presenter像积木一样搭建一个完整的员工信息，每个P又都有InitView，Vaildate，CompleteTheObject3个小P组成
        /// </summary>
        /// <param name="itsView"></param>
        /// <param name="operatorAccount"></param>
        public AddEmployeeInfoPresenter(IEmployeeInfoView itsView, Account operatorAccount)
        {
            _OperatorAccount = operatorAccount;
            _ItsView = itsView;
            _ThePresenters = new List<IAddEmployeePresenter>();
            //基本信息
            _ThePresenters.Add(new AddBasicInfoPresenter(itsView.BasicInfoView));
            //离职信息
            _ThePresenters.Add(new AddDimissionBasicInfoPresenter(itsView.DimissionInfoView));      
            //家庭信息
            _ThePresenters.Add(new AddFamilyInfoPresenter(itsView.FamilyInfoView));
            //简历
            _ThePresenters.Add(new AddResumeInfoPresenter(itsView.ResumeInfoView));
            //福利
            _ThePresenters.Add(new AddWelfareInfoPresenter(itsView.WelfareInfoView));
            //工作
            _ThePresenters.Add(new AddWorkInfoPresenter(itsView.WorkInfoView));
            //技能
            _ThePresenters.Add(new AddSkillInfoPresenter(itsView.EmployeeSkillInfoView));
            //档案信息
            new AddFileCargosInfoPresenter(itsView.FileCargoInfoView, 0);
            AttachViewEvent();
        }
    
        public void AttachViewEvent()
        {
            _ItsView.BtnActionEvent += BtnActionEvent;
        }
        /// <summary>
        /// 循环每一个P，初始化
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
                _ItsView.Title = "新增员工";
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
        /// 点击确定按钮后引发的事件
        /// </summary>
        public void BtnActionEvent()
        {
            //验证信息是否填写完全及格式是否正确
            bool vaild = true;
            foreach (IAddEmployeePresenter aPresenter in _ThePresenters)
            {      
                if(!aPresenter.Vaildate())
                {
                    _ItsView.Message = "员工信息填写不完整或填写格式有误!";
                    _ItsView.ActionSuccess = false;
                    vaild = false;
                }
            }
            if (!vaild)
            {
                return;
            }
            //将填写的信息赋值给aNewObject对象
            Employee aNewObject = new Employee();
            foreach (IAddEmployeePresenter aPresenter in _ThePresenters)
            {
                aPresenter.CompleteTheObject(aNewObject);
            }
            try
            {
                _IEmployeeFacade.AddEmployeeProxy(aNewObject, _OperatorAccount);
                _ItsView.Message = "操作成功";
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
