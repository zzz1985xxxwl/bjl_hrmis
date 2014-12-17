using System.Collections.Generic;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.IPresenter.IAuth;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.Auths
{
    public class HrmisAuthTreePresenter : BasePresenter
    {
        private readonly IHrmisAuthTreeView _ItsView;
        public IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;

        public HrmisAuthTreePresenter(IHrmisAuthTreeView itsView, Account loginUser)
            : base(loginUser)
        {
            _ItsView = itsView;
        }

        public override void Initialize(bool isPostBack)
        {
            if (LoginUser == null)
                return;

            if (isPostBack)
                return;

            SetAuthTreeDataSrc();

            SetPersonalManageAuth();
            SetStatisticsAuth();
        }

        private void SetPersonalManageAuth()
        {
            List<Auth> authList = new List<Auth>();
            if (LoginUser.Id != Account.AdminPkid)
            {
                Auth auth;
                auth = new Auth(0, "请假管理");
                auth.NavigateUrl = "../LeaveRequestPages/MyLeaveRequest.aspx";
                authList.Add(auth);
                auth = new Auth(0, "外出管理");
                auth.NavigateUrl = "../OutApplicationPages/OutApplicationList.aspx";
                authList.Add(auth);
                auth = new Auth(0, "加班管理");
                auth.NavigateUrl = "../OverWorkPages/OverWorkList.aspx";
                authList.Add(auth);
                auth = new Auth(0, "报销管理");
                auth.NavigateUrl = "../ReimbursePages/MyReimburse.aspx";
                authList.Add(auth);
                auth = new Auth(0, "申请绩效考核");
                auth.NavigateUrl = "../AssessPages/ManagerApplyEmployeeAssess.aspx";
                authList.Add(auth);
                auth = new Auth(0, "填写绩效考核");
                auth.NavigateUrl = "../AssessPages/GetCurrentAssess.aspx";
                authList.Add(auth);
                auth = new Auth(0, "绩效考核历史");
                auth.NavigateUrl = "../AssessPages/GetAssessActivityHistory.aspx";
                authList.Add(auth);
                auth = new Auth(0, "解密工资单");
                auth.NavigateUrl = "../PayModulePages/DECEmployeeSalary.aspx";
                authList.Add(auth);
                auth = new Auth(0, "我的培训反馈");
                auth.NavigateUrl = "../TrainingPages/MyFeedBack.aspx";
                authList.Add(auth);
                auth = new Auth(0, "我的培训申请");
                auth.NavigateUrl = "../TrianApplicationPages/MyTrainApplication.aspx";
                authList.Add(auth);
            }
            _ItsView.rptPersonalManageDataSrc = authList;
        }

        private void SetStatisticsAuth()
        {
            List<Auth> authList = new List<Auth>();
            if (LoginUser.Id != Account.AdminPkid)
            {
                IDepartmentBll iDepartmentBll = BllInstance.DepartmentBllInstance;
                List<Department> DepartmentList = iDepartmentBll.GetManageDepts(LoginUser.Id);
                Auth auth;
                auth = new Auth(0, "考勤统计");
                auth.NavigateUrl = "../AttendancePages/MonthAttendance.aspx";
                authList.Add(auth);
                if (DepartmentList != null && DepartmentList.Count != 0)
                {
                    auth = new Auth(0, "员工统计");
                    auth.NavigateUrl = "../EmployeeStatisticsPages/EmployeeStatistics.aspx";
                    authList.Add(auth);
                    auth = new Auth(0, "薪资统计");
                    auth.NavigateUrl = "../PayModulePages/EmployeeSalaryStatistics.aspx";
                    authList.Add(auth);
                }
                auth = new Auth(0, "查询员工");
                auth.NavigateUrl = "../EmployeePages/SearchEmployee.aspx";
                authList.Add(auth);
            }
            _ItsView.rptStatisticsDataSrc = authList;
        }

        private void SetAuthTreeDataSrc()
        {
            List<Auth>  AAuths = LoginUser.FindAuthsByType(AuthType.HRMIS);

            if(AAuths == null)
                return;

            _ItsView.rptParameterDataSrc = FindAuthById(AAuths, HrmisPowers.A01);
            _ItsView.rptAccountDataSrc = FindAuthById(AAuths, HrmisPowers.A02);
            _ItsView.rptDepartmentDataSrc = FindAuthById(AAuths, HrmisPowers.A03);
            _ItsView.rptEmployeeDataSrc = FindAuthById(AAuths, HrmisPowers.A04);
            _ItsView.rptApplicationDataSrc = FindAuthById(AAuths, HrmisPowers.A05);
            _ItsView.rptPayDataSrc = FindAuthById(AAuths, HrmisPowers.A06);
            _ItsView.rptPerformanceDataSrc = FindAuthById(AAuths, HrmisPowers.A07);
            _ItsView.rptTrainingDataSrc = FindAuthById(AAuths, HrmisPowers.A08);
            _ItsView.rptReimburseDataSrc = FindAuthById(AAuths, HrmisPowers.A09);
            _ItsView.rptDataTransferDataSrc = FindAuthById(AAuths, HrmisPowers.A10);
        }

        private List<Auth> FindAuthById(List<Auth> auths, int id)
        {
            foreach (Auth auth in auths)
            {
                if (auth.Id == id)
                    return auth.ChildAuths;
            }

            return null;
        }
    }
}
