//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddUpdateGoalPresenter.cs
// ������: ���h��
// ��������: 2008-06-16
// ����: ����Ŀ�����
// ----------------------------------------------------------------
using System;
using SEP.IBll;
using SEP.IBll.Goals;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IGoals;
using SEP.Model.Accounts;

namespace SEP.Presenter.Goals
{
    public class AddUpdateGoalPresenter : BasePresenter
    {
        public IGoalBaseView _IGoalBaseView;

        public AddUpdateGoalPresenter(IGoalBaseView view, Account loginUser)
            : base(loginUser)
        {
            _IGoalBaseView = view;
        }

        public bool Validation()
        {
            DateTime _SetTime;

            _IGoalBaseView.ResultMessage = String.Empty;
            _IGoalBaseView.ValidateTitle = String.Empty;
            _IGoalBaseView.ValidateSetTime = String.Empty;

            if (String.IsNullOrEmpty(_IGoalBaseView.Title))
            {
                _IGoalBaseView.ValidateTitle = "Ŀ����ⲻ��Ϊ�գ�";
                return false;
            }
            if (_IGoalBaseView.Title.Length > 50)
            {
                _IGoalBaseView.ValidateTitle = "Ŀ����ⲻ�ܳ���50���ַ���";
                return false;
            }
            if (String.IsNullOrEmpty(_IGoalBaseView.SetTime))
            {
                _IGoalBaseView.ValidateSetTime = "Ŀ������ʱ�䲻��Ϊ�գ�";
                return false;
            }
            if (!DateTime.TryParse(_IGoalBaseView.SetTime, out _SetTime))
            {
                _IGoalBaseView.ValidateSetTime = "Ŀ������ʱ���ʽ����ȷ��";
                return false;
            }
            return true;
        }


        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
