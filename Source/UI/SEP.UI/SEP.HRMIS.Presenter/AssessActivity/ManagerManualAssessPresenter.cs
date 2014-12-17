//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: ManagerManualAssessPresenter.cs
// ������:wang.shali
// ��������: 2008-06-16
// ����: �������뿼��
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class ManagerManualAssessPresenter : ManualAssessPresenter
    {
        private string _StrEmployeeId;

        public ManagerManualAssessPresenter(string employeeId, IManualAssessView view, Account loginUser)
            : base(view, loginUser)
        {
            _StrEmployeeId = employeeId;
        }

        public override void Initialize(bool isPostBack)
        {
            _View.Message = string.Empty;
            int employeeID;
            if (!int.TryParse(_StrEmployeeId, out employeeID))
            {
                _View.Message = "Ա����Ϣ�������";
                return;
            }

            _View.Employee = InstanceFactory.CreateEmployeeFacade().GetEmployeeByAccountID(employeeID);

            if (!isPostBack)
            {
                _View.txtEmployeeNameReadOnly = true;
                _View.AssessCharacterTypes = GetCharacterTypeEnum();
                _View.ddlCharacterEnabled = false;
                //GetAssessActivity dd = new GetAssessActivity();
                //_View.AssessActivityToManual = dd.GetAssessActivityByAssessActivityID(9);
                //_View.FormReadonly = true;
            }
        }

        private static Dictionary<string, string> GetCharacterTypeEnum()
        {
            Dictionary<string, string> characterType = new Dictionary<string, string>();
            AssessActivityUtility.AddCharacterValueAndNameIntoDictionary(characterType, AssessCharacterType.Abnormal);
            return characterType;
        }
    }
}
