//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateEmployeeInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-10-09
// 概述: 修改员工总界面的Presenter
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
        /// 各个Presenter像积木一样搭建一个完整的员工信息，每个P又都有InitView，DataBind,Vaildate，CompleteTheObject3个小P组成
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
            //年假信息
            _TheVocationPresenter = new VocationBackPresenter(itsView);
            //档案
            new UpdateFileCargosInfoPresenter(itsView.FileCargoInfoView, Convert.ToInt32(_EmployeeId));
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
            foreach(IUpdateEmployeePresenter aPresenter in _ThePresenters)
            {
                aPresenter.InitView(pageIsPostBack);
            }
            //额外的界面信息设置
            if (!pageIsPostBack)
            {
                _ItsView.Title = "修改员工";
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
                _ItsView.Message = "初始化信息失败，请联系管理员";
                _ItsView.BtnActionVisible = false;
                _ItsView.ActionSuccess = false;
                return;
            }

            Employee theEmployee = _IEmployeeFacade.GetEmployeeByAccountID(id);
            
            //福利信息绑定
            theEmployee.EmployeeWelfare = _IEmployeeWelfareFacade.GetEmployeeWelfareByAccountID(id);
            theEmployee.EmployeeWelfareHistory = _IEmployeeWelfareFacade.GetEmployeeWelfareHistoryByAccountID(id);
           
            //假期信息绑定
            _TheVocationPresenter.InitTheVacation(theEmployee);
            if(!pageIsPostBack)
            {
                //tab页面的信息绑定
                foreach (IUpdateEmployeePresenter aPresenter in _ThePresenters)
                {
                    aPresenter.DataBind(theEmployee);
                }
                //员工页面中上方的信息条
                SetExtraInfoToView(theEmployee);
               
            }
        }
        /// <summary>
        /// 点击确定按钮后引发的事件
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
                //重新绑定福利历史
                _ItsView.WelfareInfoView.EmployeeWelfareHistory = theEmployee.EmployeeWelfareHistory = _IEmployeeWelfareFacade.GetEmployeeWelfareHistoryByAccountID(Convert.ToInt32(_EmployeeId)); ;

                _ItsView.Message = "操作成功";
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

        //额外的界面信息绑定 
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
                    _ItsView.Message = "正式员工或者试用期员工，试用期开始时间，结束时间必须填写";
                    isValidate = false;
                }
                if (employee.EmployeeDetails.ProbationTime <=
                                            Convert.ToDateTime("1900-01-01"))
                {
                    _ItsView.Message = "正式员工或者试用期员工，试用期开始时间，结束时间必须填写";
                    isValidate = false;
                }
            }
            return isValidate;
        }

    }
}
