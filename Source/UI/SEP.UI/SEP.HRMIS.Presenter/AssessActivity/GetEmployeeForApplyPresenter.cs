using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.IBll.Positions;
using SEP.Model.Departments;
using SEP.Model.Utility;
using PresenterCore = SEP.Presenter.Core;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public abstract class GetEmployeeForApplyPresenter : PresenterCore.BasePresenter
    {
        public readonly IGetEmployeeForApplyView _View;
        protected IPositionBll _IPositionBll = BllInstance.PositionBllInstance;
        protected IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;

        protected GetEmployeeForApplyPresenter(IGetEmployeeForApplyView view, Account loginUser)
            : base(loginUser)
        {
            _View = view;

            _View.BindAssessActivity += BindAssessActivity;
        }

        public abstract void InitForSpecial();
        public abstract void BindGridView();

        public void BindAssessActivity(object sender, EventArgs e)
        {
            BindGridView();
        }

        public override void Initialize(bool isPostBack)
        {
            if (!isPostBack)
            {
                GetData();
                BindGridView();
            }

            InitForSpecial();
        }
        private void GetData()
        {
            List<Department> deptList = _IDepartmentBll.GetAllDepartment();
            _View.DepartmentSource =
                Tools.RemoteUnAuthDeparetment(deptList, AuthType.HRMIS, LoginUser, HrmisPowers.A703);
            _View.PositionSource = _IPositionBll.GetAllPosition();
            _View.EmployeeTypeSource = EmployeeTypeUtility.GetAllEmployeeTypeEnum();
            _View.EmployeeType = EmployeeTypeEnum.NormalEmployee;
        }
    }
}