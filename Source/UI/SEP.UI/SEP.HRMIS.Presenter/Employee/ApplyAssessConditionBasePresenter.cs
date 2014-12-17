//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: SalaryWeightDeletePresenter.cs
// ������:wangshali
// ��������: 2008-08-10
// ����: ɾ������ϵ��
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public class ApplyAssessConditionBasePresenter
    {
        public void InitBaseView(IApplyAssessConditionView view, bool isPageValid)
        {
            view.Message = string.Empty;
            view.ApplyDateMsg = string.Empty;
            view.ScopeMsg = string.Empty;
            if (!isPageValid)
            {
                view.AssessCharacterTypes = AssessActivityUtility.GetCharacterTypeEnum();
            }
        }
        public bool Validation(IApplyAssessConditionView view)
        {
            view.ScopeMsg = string.Empty;
            view.Message = string.Empty;
            view.ApplyDateMsg = string.Empty;
            bool ret = true;
            if (String.IsNullOrEmpty(view.ApplyDate.Trim()))
            {
                view.ApplyDateMsg = "����ʱ�䲻��Ϊ��";
                ret = false;
            }
            else
            {
                DateTime dtApplyDate;
                if (!(DateTime.TryParse(view.ApplyDate, out dtApplyDate)))
                {
                    view.ApplyDateMsg = "����ʱ���ʽ����ȷ";
                    ret = false;
                }
            }
            if (String.IsNullOrEmpty(view.ScopeFrom.Trim()) || String.IsNullOrEmpty(view.ScopeTo.Trim()))
            {
                view.ScopeMsg = "��Ч����ʱ�䲻��Ϊ��";
                ret = false;
            }
            else
            {
                DateTime dtScopeFrom;
                DateTime dtScopeTo;
                if (!(DateTime.TryParse(view.ScopeFrom, out dtScopeFrom) && DateTime.TryParse(view.ScopeTo, out dtScopeTo)))
                {
                    view.ScopeMsg = "��Ч����ʱ���ʽ����ȷ";
                    ret = false;
                }
                else
                {
                    if (DateTime.Compare(dtScopeFrom, dtScopeTo) > 0)
                    {
                        view.ScopeMsg = "��ʼʱ�䲻�����ڽ���ʱ��";
                        ret = false;
                    }
                }
            }
            return ret;
        }

    }
}
