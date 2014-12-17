//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: PersonalInAndOutDetailPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-10-21
// 概述: 个人考勤详情详情
// ----------------------------------------------------------------

using PresenterCore=SEP.Presenter.Core;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter
{
    public class PersonalInAndOutDetailPresenter : PresenterCore.BasePresenter
    {
        private readonly IPersonalInAndOutView _View;
        private readonly PersonalInAndOutUtilityPresenter _Utility;

        public PersonalInAndOutDetailPresenter(IPersonalInAndOutView view, Account loginUser)
            : base(loginUser)
        {
            _View = view;
            _Utility = new PersonalInAndOutUtilityPresenter(_View, loginUser);
            AttachViewEvent();
        }

        public void InitView(string id)
        {
            _Utility.InitTheViewToDefault();
            _View.OperationTitle = "打卡记录详情";
            _View.OperationType = "Detail";
            _View.SetReadOnly = false;
            _View.SetReasonReadOnly = false;
            _Utility.DataBind(id, _View.EmployeeId);
        }

        public void AttachViewEvent()
        {
            _View.ActionButtonEvent += DetailEvent;
        }

        public void DetailEvent()
        {
           _View.ActionSuccess = true;
        }

        public override void Initialize(bool isPostBack)
        {
            throw new System.Exception("The method or operation is not implemented.");
        }
    }
}
