using System;
using System.Collections.Generic;
using System.Web.UI;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Logic;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.Performance.Views.HRMIS.Auths
{
    public partial class HrmisAuthTree : UserControl
    {
        protected List<AuthEntity> AllAuth { get; set; }
        protected List<AccountAuthEntity> AllAccountAuth { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var account = Session[SessionKeys.LOGININFO] as Account;
            AllAuth = new List<AuthEntity>();
            AllAccountAuth = new List<AccountAuthEntity>();
            AllAuth.Add(new AuthEntity()
                            {AuthName = "��������", AuthParentId = 0, IfHasDepartment = 0, NavigateUrl = "", PKID = 80});
            AllAuth.Add(new AuthEntity()
                            {
                                AuthName = "��ٹ���",
                                AuthParentId = 80,
                                NavigateUrl = "../LeaveRequestPages/MyLeaveRequest.aspx",
                                PKID = 81
                            });
            AllAuth.Add(new AuthEntity()
                            {
                                AuthName = "�������",
                                AuthParentId = 80,
                                IfHasDepartment = 0,
                                NavigateUrl = "../OutApplicationPages/OutApplicationList.aspx",
                                PKID = 82
                            });
            AllAuth.Add(new AuthEntity()
                            {
                                AuthName = "�Ӱ����",
                                AuthParentId = 80,
                                NavigateUrl = "../OverWorkPages/OverWorkList.aspx",
                                PKID = 83
                            });
            AllAuth.Add(new AuthEntity()
                            {
                                AuthName = "��������",
                                AuthParentId = 80,
                                NavigateUrl = "../ReimbursePages/MyReimburse.aspx",
                                PKID = 84
                            });
            AllAuth.Add(new AuthEntity()
                            {
                                AuthName = "���뼨Ч����",
                                AuthParentId = 80,
                                IfHasDepartment = 0,
                                NavigateUrl = "../AssessPages/ManagerApplyEmployeeAssess.aspx",
                                PKID = 85
                            });
            AllAuth.Add(new AuthEntity()
                            {
                                AuthName = "��д��Ч����",
                                AuthParentId = 80,
                                NavigateUrl = "../AssessPages/GetCurrentAssess.aspx",
                                PKID = 86
                            });
            AllAuth.Add(new AuthEntity()
                            {
                                AuthName = "��Ч������ʷ",
                                AuthParentId = 80,
                                NavigateUrl = "../AssessPages/GetAssessActivityHistory.aspx",
                                PKID = 87
                            });
            AllAuth.Add(new AuthEntity()
                            {
                                AuthName = "���ܹ��ʵ�",
                                AuthParentId = 80,
                                NavigateUrl = "../PayModulePages/DECEmployeeSalary.aspx",
                                PKID = 88
                            });
            AllAuth.Add(new AuthEntity()
                            {
                                AuthName = "�ҵ���ѵ����",
                                AuthParentId = 80,
                                NavigateUrl = "../TrainingPages/MyFeedBack.aspx",
                                PKID = 89
                            });
            AllAuth.Add(new AuthEntity()
                            {
                                AuthName = "�ҵ���ѵ����",
                                AuthParentId = 80,
                                NavigateUrl = "../TrianApplicationPages/MyTrainApplication.aspx",
                                PKID = 89
                            });

            AllAuth.Add(new AuthEntity()
                            {
                                AuthName = "ͳ�ƹ���",
                                AuthParentId = 0,
                                IfHasDepartment = 0,
                                NavigateUrl = "",
                                PKID = 8801
                            });
            AllAuth.Add(new AuthEntity()
                            {
                                AuthName = "����ͳ��",
                                AuthParentId = 8801,
                                NavigateUrl = "../AttendancePages/MonthAttendance.aspx",
                                PKID = 8802
                            });
            IDepartmentBll iDepartmentBll = BllInstance.DepartmentBllInstance;
            List<Department> DepartmentList = iDepartmentBll.GetManageDepts(account.Id);
            if (DepartmentList != null && DepartmentList.Count != 0)
            {
                AllAuth.Add(new AuthEntity()
                                {
                                    AuthName = "Ա��ͳ��",
                                    AuthParentId = 8801,
                                    NavigateUrl = "../EmployeeStatisticsPages/EmployeeStatistics.aspx",
                                    PKID = 8803
                                });
                AllAuth.Add(new AuthEntity()
                                {
                                    AuthName = "н��ͳ��",
                                    AuthParentId = 8801,
                                    NavigateUrl = "../PayModulePages/EmployeeSalaryStatistics.aspx",
                                    PKID = 8804
                                });
            }
            AllAuth.Add(new AuthEntity()
            {
                AuthName = "��ѯԱ��",
                AuthParentId = 8801,
                NavigateUrl = "../EmployeePages/SearchEmployee.aspx",
                PKID = 8805
            });
            foreach (var authEntity in AllAuth)
            {
                AllAccountAuth.Add(new AccountAuthEntity {AccountId = account.Id, AuthId = authEntity.PKID});
            }
            AllAuth.AddRange(AuthLogic.GetAllAuth());
            AllAccountAuth.AddRange(AccountAuthLogic.GetAccountAuthByAccountId(account.Id));
        }

        protected bool MenuOn(List<AuthEntity> childAuth)
        {
            foreach (var authEntity in childAuth)
            {
                if (Request.RawUrl.Contains(authEntity.NavigateUrl.Replace("..", "")))
                {
                    return true;
                }
            }
            return false;
        }

        //IDepartmentBll iDepartmentBll = BllInstance.DepartmentBllInstance;
        //        List<Department> DepartmentList = iDepartmentBll.GetManageDepts(LoginUser.Id);
        //        Auth auth;
        //        auth = new Auth(0, "����ͳ��");
        //        auth.NavigateUrl = "../AttendancePages/MonthAttendance.aspx";
        //        authList.Add(auth);
        //        if (DepartmentList != null && DepartmentList.Count != 0)
        //        {
        //            auth = new Auth(0, "Ա��ͳ��");
        //            auth.NavigateUrl = "../EmployeeStatisticsPages/EmployeeStatistics.aspx";
        //            authList.Add(auth);
        //            auth = new Auth(0, "н��ͳ��");
        //            auth.NavigateUrl = "../PayModulePages/EmployeeSalaryStatistics.aspx";
        //            authList.Add(auth);
        //        }


        //auth = new Auth(0, "���뼨Ч����");
        //auth.NavigateUrl = "../AssessPages/ManagerApplyEmployeeAssess.aspx";
        //authList.Add(auth);
        //auth = new Auth(0, "��д��Ч����");
        //auth.NavigateUrl = "../AssessPages/GetCurrentAssess.aspx";
        //authList.Add(auth);
        //auth = new Auth(0, "��Ч������ʷ");
        //auth.NavigateUrl = "../AssessPages/GetAssessActivityHistory.aspx";
        //authList.Add(auth);
        //auth = new Auth(0, "���ܹ��ʵ�");
        //auth.NavigateUrl = "../PayModulePages/DECEmployeeSalary.aspx";
        //authList.Add(auth);
        //auth = new Auth(0, "�ҵ���ѵ����");
        //auth.NavigateUrl = "../TrainingPages/MyFeedBack.aspx";
        //authList.Add(auth);
        //auth = new Auth(0, "�ҵ���ѵ����");
        //auth.NavigateUrl = "../TrianApplicationPages/MyTrainApplication.aspx";
        //authList.Add(auth);
    }
}