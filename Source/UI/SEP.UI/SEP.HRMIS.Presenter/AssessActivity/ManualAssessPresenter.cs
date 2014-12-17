//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: ManualAssessPresenter.cs
// ������:wang.shali
// ��������: 2008-06-16
// ����: ���뿼���
// ----------------------------------------------------------------
using System;

using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public abstract class ManualAssessPresenter : SEP.Presenter.Core.BasePresenter 
    {
        public IManualAssessView _View;

        protected ManualAssessPresenter(IManualAssessView view, Account loginUser)
            : base(loginUser)
        {
            if (view == null)
            {
                throw new Exception("view may not be null");
            }

            _View = view;
        }

        public bool Validation()
        {
            _View.ScopeMsg = string.Empty;
            _View.ReasonMsg = string.Empty;
            _View.Message = string.Empty;

            bool ret = true;
            if (String.IsNullOrEmpty(_View.ScopeFrom) || String.IsNullOrEmpty(_View.ScopeTo))
            {
                _View.ScopeMsg = "��Ч����ʱ�䲻��Ϊ��";
                ret = false;
            }
            else
            {
                DateTime dtScopeFrom;
                DateTime dtScopeTo;
                if (!(DateTime.TryParse(_View.ScopeFrom, out dtScopeFrom) && DateTime.TryParse(_View.ScopeTo, out dtScopeTo)))
                {
                    _View.ScopeMsg = "��Ч����ʱ���ʽ����ȷ";
                    ret = false;
                }
                else
                {
                    if (DateTime.Compare(dtScopeFrom, dtScopeTo) > 0)
                    {
                        _View.ScopeMsg = "��Ч���˿�ʼʱ�䲻�����ڽ���ʱ��";
                        ret = false;
                    }
                    else
                    {
                        if (DateTime.Compare(dtScopeFrom, _View.Employee.EmployeeDetails.Work.ComeDate) < 0)
                        {
                            _View.ScopeMsg = "��Ч���˿�ʼʱ�䲻������Ա����ְʱ��";
                            ret = false;
                        }
                    }
                }
            }
            if (String.IsNullOrEmpty(_View.Reason))
            {
                _View.ReasonMsg = "����ԭ�򲻿�Ϊ��";
                ret = false;
            }
            return ret;
        }

        public void btnApplyClick(object sender, EventArgs e)
        {
            if (!Validation())
            {
                return;
            }

            try
            {
                hrmisModel.AssessActivity temp = _View.AssessActivityToManual;
                temp.AssessProposerName = LoginUser.Name;

                InstanceFactory.AssessActivityFacade.ManualAssess(temp);
                ToGetEmployeeForApplyPage(this, null);
            }
            catch (ApplicationException ex)
            {
                _View.Message = ex.Message;
            }
        }
        public EventHandler ToGetEmployeeForApplyPage;

        //public void InitView(string strEmployeeID, bool isPageValid)
        //{
        //    _View.Message = string.Empty;
        //    int employeeID;
        //    if (!int.TryParse(strEmployeeID, out employeeID))
        //    {
        //        _View.Message = "Ա����Ϣ�������";
        //        return;
        //    }


        //    _View.Employee = InstanceFactory.CreateEmployeeFacade().GetEmployeeByAccountID(employeeID);
        //    if (!isPageValid)
        //    {
        //        _View.txtEmployeeNameReadOnly = true;
        //    }
        //    InitForSpecial(isPageValid);
        //}

    }
}
