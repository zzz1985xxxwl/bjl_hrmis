using System;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Accounts;
using SEP.HRMIS.IFacede;

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
            _View.Employees =
                InstanceFactory.AssessActivityFacade().GetAssessActivityForHRApply(_View.EmployeeName, employeetype, _View.PositionId, _View.DepartmentId, _View.RecursionDepartment, LoginUser);

        }

    }
}
