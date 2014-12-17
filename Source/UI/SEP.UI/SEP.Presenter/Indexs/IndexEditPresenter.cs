using System.Collections.Generic;
using SEP.HRMIS.Model.AccountAuth;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Presenter.IPresenter.IIndexs;

namespace SEP.Presenter.Indexs
{
    public class IndexEditPresenter
    {
        private readonly IIndexEditView _View;
        private readonly Account _LoginUser;
        private readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly IDepartmentBll _DepartmentBll = BllInstance.DepartmentBllInstance;

        public IndexEditPresenter(IIndexEditView view, Account loginUser)
        {
            _View = view;
            _LoginUser = _AccountBll.GetAccountById(loginUser.Id);
            _LoginUser.Auths = loginUser.Auths;
            Init();
        }

        private void Init()
        {
            List<IndexItem> sepItems = new List<IndexItem>();
            List<IndexItem> hrmisItems = new List<IndexItem>();
            List<IndexItem> crmItems = new List<IndexItem>();
            List<IndexItem> mycmmiItems = new List<IndexItem>();

            #region sep

            sepItems.Add(new IndexItem("日历", "Calendar",
                                       "SEP/CalendarPages/CalendarIFramePage.aspx", 0));
            sepItems.Add(new IndexItem("公告", "Bulletion",
                                       "SEP/BulletinPages/BulletinIFramePage.aspx", 0));
            sepItems.Add(new IndexItem("目标", "Goal",
                                       "SEP/GoalPages/GoalIFramePage.aspx", 1));
            sepItems.Add(new IndexItem("电话薄", "TelephoneBook",
                                       "SEP/ContactPages/ContactIFramePage.aspx", 1));
            sepItems.Add(new IndexItem("高级日历", "CalendarExt",
                                      "SEP/CalendarExtPages/CalendarExtIFramePage.aspx", 0));

            #endregion

            #region  hrmis

            if (MasterPagePresenter.HasHrmisSystem && _LoginUser.IsHRAccount)
            {
                hrmisItems.Add(new IndexItem("请假管理", "LeaveRequest",
                                             "HRMIS/LeaveRequestPages/LeaveRequestIFramePage.aspx", 1));
                hrmisItems.Add(new IndexItem("加班管理", "OverWork",
                                             "HRMIS/OverWorkPages/OverWorkIFramePage.aspx", 1));
                hrmisItems.Add(new IndexItem("外出管理", "Out",
                                             "HRMIS/OutApplicationPages/OutApplicationIFramePage.aspx", 1));
                hrmisItems.Add(new IndexItem("绩效管理", "AssessActivity",
                                             "HRMIS/AssessPages/AssessActivityIFramePage.aspx", 1));
                hrmisItems.Add(new IndexItem("培训管理", "TrainApplication",
                                            "HRMIS/TrianApplicationPages/TrainApplicationIFramePage.aspx", 1));
                hrmisItems.Add(new IndexItem("考勤统计", "MonthAttendance",
                                             "HRMIS/AttendancePages/MonthAttendanceIFramePage.aspx",
                                             0));
                
                //有查询员工权限才能看自定义流程异常
                if (_LoginUser.FindAuth(AuthType.HRMIS, HrmisPowers.A401) != null)
                {
                    hrmisItems.Add(new IndexItem("自定义流程异常", "DiyProcessErrorListView",
                                                "HRMIS/SystemErrorPages/DiyProcessErrorListIFramePage.aspx",
                                                0));
                    hrmisItems.Add(new IndexItem("门禁卡异常", "DoorCardErrorListAjaxView",
                                                 "HRMIS/SystemErrorPages/DoorCardErrorListIFramePage.aspx",
                                                 0));
                    hrmisItems.Add(new IndexItem("短信数据", "PhoneMessageData",
                                                 "HRMIS/SystemErrorPages/PhoneMessageListIFramePage.aspx",
                                                 0));


                }
                if (_LoginUser.FindAuth(AuthType.HRMIS, HrmisPowers.A502) != null)
                {
                    hrmisItems.Add(new IndexItem("排班表异常", "DutyCalssErrorListView",
                                               "HRMIS/SystemErrorPages/DutyClassErrorListIFramePage.aspx",
                                               0));
                }
                if (_LoginUser.FindAuth(AuthType.HRMIS, HrmisPowers.A504) != null)
                {
                    hrmisItems.Add(new IndexItem("考勤异常", "AttendanceErrorListAjaxView",
                                               "HRMIS/SystemErrorPages/AttendanceErrorListIFramePage.aspx",
                                               0));
                }
                if (_LoginUser.FindAuth(AuthType.HRMIS, HrmisPowers.A402) != null)
                {
                    hrmisItems.Add(new IndexItem("员工合同异常", "EmployeeContractErrorListAjaxView",
                                               "HRMIS/SystemErrorPages/EmployeeContractErrorListIFramePage.aspx",
                                               0));
                }
                #region 主管才有的节点

                if (_DepartmentBll.GetManageDepts(_LoginUser.Id).Count > 0)
                {
                    hrmisItems.Add(new IndexItem("年龄构成图", "AgePieChartIndexView",
                                                "HRMIS/EmployeeStatisticsPages/AgePieChartIFramePage.aspx", 1));
                    hrmisItems.Add(new IndexItem("性别构成图", "GenderPieChartIndexView",
                                                 "HRMIS/EmployeeStatisticsPages/GenderPieChartIFramePage.aspx", 1));
                    hrmisItems.Add(new IndexItem("文化程度构成图", "EduBgPieChartIndexView",
                                                 "HRMIS/EmployeeStatisticsPages/EduBgPieChartIFramePage.aspx", 1));
                    hrmisItems.Add(new IndexItem("司龄构成图", "WorkAgePieChartIndexView",
                                                 "HRMIS/EmployeeStatisticsPages/WorkAgePieChartIFramePage.aspx", 1));
                    hrmisItems.Add(new IndexItem("用工性质构成图", "WorkTypePieChartIndexView",
                                                 "HRMIS/EmployeeStatisticsPages/WorkTypePieChartIFramePage.aspx", 1));
                    hrmisItems.Add(new IndexItem("其他统计", "OtherStatisticsDataIndexView",
                                                 "HRMIS/EmployeeStatisticsPages/OtherStatisticsDataIFramePage.aspx",
                                                 1));
                    hrmisItems.Add(new IndexItem("入职离职统计", "ComeAndLeaveIndexView",
                                                 "HRMIS/EmployeeStatisticsPages/ComeAndLeaveIFramePage.aspx", 0));
                    hrmisItems.Add(new IndexItem("职务层级配置", "PositionGradeTowerTableIndexView",
                                                 "HRMIS/EmployeeStatisticsPages/PositionGradeTowerTableIFramePage.aspx",
                                                 1));
                    hrmisItems.Add(new IndexItem("工资人均统计", "AverageStatisticsIndexView",
                                                 "HRMIS/PayModulePages/AverageStatisticsIFramePage.aspx",
                                                 0));
                    hrmisItems.Add(new IndexItem("按部门统计工资", "DepartmentStatisticsIndexView",
                                                 "HRMIS/PayModulePages/DepartmentStatisticsIFramePage.aspx",
                                                 0));
                    hrmisItems.Add(new IndexItem("按职位统计工资", "PositionStatisticsIndexView",
                                                 "HRMIS/PayModulePages/PositionStatisticsIFramePage.aspx",
                                                 0));
                    hrmisItems.Add(new IndexItem("按月统计帐套参数", "TimeSpanStatisticsGroupByParaIndexView",
                                                 "HRMIS/PayModulePages/TimeSpanStatisticsGroupByParaIFramePage.aspx",
                                                 0));
                    hrmisItems.Add(new IndexItem("按月统计部门工资", "TimeSpanStatisticsGroupByDeptIndexView",
                                                 "HRMIS/PayModulePages/TimeSpanStatisticsGroupByDeptIFramePage.aspx",
                                                 0));

                }

                #endregion
            }

            #endregion

            #region crm

            if (MasterPagePresenter.HasCRMSystem && _LoginUser.IsCRMAccount)
            {
                crmItems.Add(new IndexItem("客户", "Customer",
                                           "CRM/IndexPages/MyCustomerIFramePage.aspx", 1));
                crmItems.Add(new IndexItem("商机", "Opportunity",
                                           "CRM/IndexPages/MyOpportunityIFramePage.aspx", 1));
                crmItems.Add(new IndexItem("订单", "Order",
                                           "CRM/IndexPages/MyOrderIFramePage.aspx", 1));
            }

            #endregion

            _View.SepToolList = sepItems;
            _View.HrmisToolList = hrmisItems;
            _View.CrmToolList = crmItems;
            _View.MyCmmiToolList = mycmmiItems;
        }
    }
}