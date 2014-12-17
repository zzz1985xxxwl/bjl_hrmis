//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: CompanyLinkManDetailPresenter.cs
// ������: ����
// ��������: 2009-06-30
// ����: ��˾��ϵ������
// ----------------------------------------------------------------

using System;
using PresenterCore=SEP.Presenter.Core;
using SEP.Model.Accounts;
using SEP.HRMIS.Presenter.IPresenter.ICompanyLinkMan;

namespace SEP.HRMIS.Presenter
{
    public class CompanyLinkManDetailPresenter : PresenterCore.BasePresenter
    {
        private readonly ICompnayLinkManView _View;
        private readonly CompanyLinkManUtilityPresenter _Utility;

        public CompanyLinkManDetailPresenter(ICompnayLinkManView view, Account loginUser)
            : base(loginUser)
        {
            _View = view;
            _Utility = new CompanyLinkManUtilityPresenter(_View, loginUser);
            AttachViewEvent();
        }

        public void InitView(Guid id)
        {
            _Utility.InitTheViewToDefault();
            _View.OperationTitle = "������ϵ������";
            _View.OperationType = "Detail";
            _View.SetReadonly = true;
            _Utility.DataBind(id);
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
           
        }
    }
}
