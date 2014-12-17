//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeSkillPresenter.cs
// 创建者: 顾艳娟
// 创建日期: 2008-11-06
// 概述: 员工技能的Presenter
// ----------------------------------------------------------------
using SEP.HRMIS.Presenter.EmployInformation.SkillInformation.SkillInfo;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.EmployeeSkillView;

namespace SEP.HRMIS.Presenter.EmployInformation.SkillInformation
{
    public class EmployeeSkillPresenter
    {
        private readonly IEmployeeSkillInfoView _ItsView;

        public EmployeeSkillPresenter(IEmployeeSkillInfoView itsView)
        {
            _ItsView = itsView;
            SwitchLittleViewPresenter();
            AttachViewEvent();
        }

        private void SwitchLittleViewPresenter()
        {
            if (string.IsNullOrEmpty(_ItsView.IEmpSkillView.Id))
            {
                new AddEmpSkillPresenter(_ItsView.IEmpSkillView);
            }
            else
            {
                new UpdateEmpSkillPresenter(_ItsView.IEmpSkillView, _ItsView.IEmpSkillView.Id);
            }
        }


        public void AttachViewEvent()
        {
            //大界面按钮
            _ItsView.IEmployeeSkillView.btnAddClick += ShowAddView;
            _ItsView.IEmployeeSkillView.btnUpdateClick += ShowUpdateView;
            _ItsView.IEmployeeSkillView.btnDeleteClick += ShowDeleteView;


            //小界面按钮
            _ItsView.IEmpSkillView.btnOKClick += ActionEvent;
            _ItsView.IEmpSkillView.btnCancelClick += CancelEvent;
            _ItsView.IEmpSkillView.SkillTypeSelectChangeEvent += SelectEvent;

        }

    

        private void ShowAddView()
        {
            new AddEmpSkillPresenter(_ItsView.IEmpSkillView).Init();
            _ItsView.SkillInfoViewVisiable = true;
        }

        private void ShowUpdateView(string id)
        {
            new UpdateEmpSkillPresenter(_ItsView.IEmpSkillView, id).Init();
            _ItsView.SkillInfoViewVisiable = true;
        }

        private void ShowDeleteView(string id)
        {
            new DeleteEmpSkillPresenter(_ItsView.IEmpSkillView).Delete(id);
            _ItsView.IEmployeeSkillView.EmployeeSkill = _ItsView.IEmployeeSkillView.EmployeeSkillSource;
        }

        private void ActionEvent()
        {
            if (_ItsView.IEmpSkillView.ActionSuccess)
            {
                _ItsView.IEmployeeSkillView.EmployeeSkill = _ItsView.IEmployeeSkillView.EmployeeSkillSource;
                _ItsView.SkillInfoViewVisiable = false;
            }
            else
            {
                _ItsView.SkillInfoViewVisiable = true;
            }
        }

        private void CancelEvent()
        {
            _ItsView.SkillInfoViewVisiable = false;
        }

        private void SelectEvent()
        {
            if (_ItsView.IEmpSkillView.ActionSuccess)
            {
                _ItsView.SkillInfoViewVisiable = false;
            }
            else
            {
                _ItsView.SkillInfoViewVisiable = true;
            }
        }

    }
}
