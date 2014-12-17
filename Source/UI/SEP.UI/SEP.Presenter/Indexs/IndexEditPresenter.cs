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

            sepItems.Add(new IndexItem("����", "Calendar",
                                       "SEP/CalendarPages/CalendarIFramePage.aspx", 0));
            sepItems.Add(new IndexItem("����", "Bulletion",
                                       "SEP/BulletinPages/BulletinIFramePage.aspx", 0));
            sepItems.Add(new IndexItem("Ŀ��", "Goal",
                                       "SEP/GoalPages/GoalIFramePage.aspx", 1));
            sepItems.Add(new IndexItem("�绰��", "TelephoneBook",
                                       "SEP/ContactPages/ContactIFramePage.aspx", 1));
            sepItems.Add(new IndexItem("�߼�����", "CalendarExt",
                                      "SEP/CalendarExtPages/CalendarExtIFramePage.aspx", 0));

            #endregion

            #region  hrmis

            if (MasterPagePresenter.HasHrmisSystem && _LoginUser.IsHRAccount)
            {
                hrmisItems.Add(new IndexItem("��ٹ���", "LeaveRequest",
                                             "HRMIS/LeaveRequestPages/LeaveRequestIFramePage.aspx", 1));
                hrmisItems.Add(new IndexItem("�Ӱ����", "OverWork",
                                             "HRMIS/OverWorkPages/OverWorkIFramePage.aspx", 1));
                hrmisItems.Add(new IndexItem("�������", "Out",
                                             "HRMIS/OutApplicationPages/OutApplicationIFramePage.aspx", 1));
                hrmisItems.Add(new IndexItem("��Ч����", "AssessActivity",
                                             "HRMIS/AssessPages/AssessActivityIFramePage.aspx", 1));
                hrmisItems.Add(new IndexItem("��ѵ����", "TrainApplication",
                                            "HRMIS/TrianApplicationPages/TrainApplicationIFramePage.aspx", 1));
                hrmisItems.Add(new IndexItem("����ͳ��", "MonthAttendance",
                                             "HRMIS/AttendancePages/MonthAttendanceIFramePage.aspx",
                                             0));
                
                //�в�ѯԱ��Ȩ�޲��ܿ��Զ��������쳣
                if (_LoginUser.FindAuth(AuthType.HRMIS, HrmisPowers.A401) != null)
                {
                    hrmisItems.Add(new IndexItem("�Զ��������쳣", "DiyProcessErrorListView",
                                                "HRMIS/SystemErrorPages/DiyProcessErrorListIFramePage.aspx",
                                                0));
                    hrmisItems.Add(new IndexItem("�Ž����쳣", "DoorCardErrorListAjaxView",
                                                 "HRMIS/SystemErrorPages/DoorCardErrorListIFramePage.aspx",
                                                 0));
                    hrmisItems.Add(new IndexItem("��������", "PhoneMessageData",
                                                 "HRMIS/SystemErrorPages/PhoneMessageListIFramePage.aspx",
                                                 0));


                }
                if (_LoginUser.FindAuth(AuthType.HRMIS, HrmisPowers.A502) != null)
                {
                    hrmisItems.Add(new IndexItem("�Ű���쳣", "DutyCalssErrorListView",
                                               "HRMIS/SystemErrorPages/DutyClassErrorListIFramePage.aspx",
                                               0));
                }
                if (_LoginUser.FindAuth(AuthType.HRMIS, HrmisPowers.A504) != null)
                {
                    hrmisItems.Add(new IndexItem("�����쳣", "AttendanceErrorListAjaxView",
                                               "HRMIS/SystemErrorPages/AttendanceErrorListIFramePage.aspx",
                                               0));
                }
                if (_LoginUser.FindAuth(AuthType.HRMIS, HrmisPowers.A402) != null)
                {
                    hrmisItems.Add(new IndexItem("Ա����ͬ�쳣", "EmployeeContractErrorListAjaxView",
                                               "HRMIS/SystemErrorPages/EmployeeContractErrorListIFramePage.aspx",
                                               0));
                }
                #region ���ܲ��еĽڵ�

                if (_DepartmentBll.GetManageDepts(_LoginUser.Id).Count > 0)
                {
                    hrmisItems.Add(new IndexItem("���乹��ͼ", "AgePieChartIndexView",
                                                "HRMIS/EmployeeStatisticsPages/AgePieChartIFramePage.aspx", 1));
                    hrmisItems.Add(new IndexItem("�Ա𹹳�ͼ", "GenderPieChartIndexView",
                                                 "HRMIS/EmployeeStatisticsPages/GenderPieChartIFramePage.aspx", 1));
                    hrmisItems.Add(new IndexItem("�Ļ��̶ȹ���ͼ", "EduBgPieChartIndexView",
                                                 "HRMIS/EmployeeStatisticsPages/EduBgPieChartIFramePage.aspx", 1));
                    hrmisItems.Add(new IndexItem("˾�乹��ͼ", "WorkAgePieChartIndexView",
                                                 "HRMIS/EmployeeStatisticsPages/WorkAgePieChartIFramePage.aspx", 1));
                    hrmisItems.Add(new IndexItem("�ù����ʹ���ͼ", "WorkTypePieChartIndexView",
                                                 "HRMIS/EmployeeStatisticsPages/WorkTypePieChartIFramePage.aspx", 1));
                    hrmisItems.Add(new IndexItem("����ͳ��", "OtherStatisticsDataIndexView",
                                                 "HRMIS/EmployeeStatisticsPages/OtherStatisticsDataIFramePage.aspx",
                                                 1));
                    hrmisItems.Add(new IndexItem("��ְ��ְͳ��", "ComeAndLeaveIndexView",
                                                 "HRMIS/EmployeeStatisticsPages/ComeAndLeaveIFramePage.aspx", 0));
                    hrmisItems.Add(new IndexItem("ְ��㼶����", "PositionGradeTowerTableIndexView",
                                                 "HRMIS/EmployeeStatisticsPages/PositionGradeTowerTableIFramePage.aspx",
                                                 1));
                    hrmisItems.Add(new IndexItem("�����˾�ͳ��", "AverageStatisticsIndexView",
                                                 "HRMIS/PayModulePages/AverageStatisticsIFramePage.aspx",
                                                 0));
                    hrmisItems.Add(new IndexItem("������ͳ�ƹ���", "DepartmentStatisticsIndexView",
                                                 "HRMIS/PayModulePages/DepartmentStatisticsIFramePage.aspx",
                                                 0));
                    hrmisItems.Add(new IndexItem("��ְλͳ�ƹ���", "PositionStatisticsIndexView",
                                                 "HRMIS/PayModulePages/PositionStatisticsIFramePage.aspx",
                                                 0));
                    hrmisItems.Add(new IndexItem("����ͳ�����ײ���", "TimeSpanStatisticsGroupByParaIndexView",
                                                 "HRMIS/PayModulePages/TimeSpanStatisticsGroupByParaIFramePage.aspx",
                                                 0));
                    hrmisItems.Add(new IndexItem("����ͳ�Ʋ��Ź���", "TimeSpanStatisticsGroupByDeptIndexView",
                                                 "HRMIS/PayModulePages/TimeSpanStatisticsGroupByDeptIFramePage.aspx",
                                                 0));

                }

                #endregion
            }

            #endregion

            #region crm

            if (MasterPagePresenter.HasCRMSystem && _LoginUser.IsCRMAccount)
            {
                crmItems.Add(new IndexItem("�ͻ�", "Customer",
                                           "CRM/IndexPages/MyCustomerIFramePage.aspx", 1));
                crmItems.Add(new IndexItem("�̻�", "Opportunity",
                                           "CRM/IndexPages/MyOpportunityIFramePage.aspx", 1));
                crmItems.Add(new IndexItem("����", "Order",
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