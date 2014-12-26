using System;
using System.Collections.Generic;
using System.Linq;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Accounts;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model.AccountAuth;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class HRApplyEmployeeAssessPresenter : GetEmployeeForApplyPresenter
    {
        public HRApplyEmployeeAssessPresenter(IGetEmployeeForApplyView view, Account loginUser)
            : base(view, loginUser)
        {
        }

        public override void InitForSpecial()
        {
            _View.RedirectPage = "HRManualAssess.aspx";

        }
        public override void BindGridView()
        {
            EmployeeTypeEnum employeetype = EmployeeTypeUtility.GetEmployeeTypeByID(Convert.ToInt32(_View.EmployeeType));
            var employees = EmployeeLogic.GetEmployeeBasicInfoByBasicConditionRetModel(_View.EmployeeName,
                employeetype, _View.PositionId, null, _View.DepartmentId, null, _View.RecursionDepartment, HrmisPowers.A703,LoginUser.Id,
                -1, null, null);
            _View.Employees = employees.Select(x => x.Account).ToList();
           
               // InstanceFactory.AssessActivityFacade().GetAssessActivityForHRApply(_View.EmployeeName, employeetype, _View.PositionId, _View.DepartmentId, _View.RecursionDepartment, LoginUser);

        }

    }
}
