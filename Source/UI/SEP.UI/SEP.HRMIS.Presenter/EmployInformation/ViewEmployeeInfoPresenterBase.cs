//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ViewEmployeeInfoPresenterBase.cs
// 创建者: 倪豪
// 创建日期: 2008-10-09
// 概述: 查看员工总界面的Presenter的基类，任何查看员工的继承该类作为
//       模板
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
            //额外的界面信息设置
            if(!pageIsPostBack)
            {
                _ItsView.BtnActionVisible = false;
                _ItsView.Title = "查看员工";
                _ItsView.Message = string.Empty;
            }
            BindInfoToView(pageIsPostBack);
            //由继承人自由定义显示的外观
            InitOthers(pageIsPostBack);
        }

        private void BindInfoToView(bool pageIsPostBack)
        {
            int id;
            if (!int.TryParse(_EmployeeId, out id))
            {
                _ItsView.Message = "初始化信息失败，请联系管理员";
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
                //额外的界面信息绑定 
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