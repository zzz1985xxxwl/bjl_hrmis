//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateSkillInfoPresenter.cs
// 创建者: 顾艳娟
// 创建日期: 2008-11-06
// 概述: 修改员工技能总界面的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.EmployInformation.SkillInformation.SkillBasicInfo;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.EmployeeSkillView;

namespace SEP.HRMIS.Presenter.EmployInformation.SkillInformation
{
    public class UpdateSkillInfoPresenter : EmployeeSkillPresenter, IUpdateEmployeePresenter
    {
        private readonly UpdateSkillBasicInfoPresenter _BasicPresenter;

        public UpdateSkillInfoPresenter(IEmployeeSkillInfoView itsView) 
            : base(itsView)
        {
            _BasicPresenter = new UpdateSkillBasicInfoPresenter(itsView.IEmployeeSkillView);
        }

        public bool DataBind(Model.Employee theDataToBind)
        {
            return _BasicPresenter.DataBind(theDataToBind);
        }

      
        public bool Vaildate()
        {
            return _BasicPresenter.Vaildate();
        }

       

        public void CompleteTheObject(Model.Employee theObjectToComplete)
        {
            _BasicPresenter.CompleteTheObject(theObjectToComplete);
        }

        

        public void InitView(bool pageIsPostBack)
        {
            _BasicPresenter.InitView(pageIsPostBack);
        }

    }
}
