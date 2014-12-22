//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ReadDataFromAccess.cs
// ������: wangyueqi
// ��������: 2008-10-22
// ����: ��ACCESS�����ݹ���
// ----------------------------------------------------------------
using System.Collections.Generic;
using System;
using System.Text;
using SEP.HRMIS.Bll.ReadExternalData;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;
using SEP.IBll;
namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    ///<summary>
    ///</summary>
    public class ReadDataFromAccess
    {
        private static IEmployee _DalEmployee = new EmployeeDal();
        private readonly IAttendanceReadRule _DalReadRule = new AttendanceReadRuleDal();
        private static IAttendanceInAndOutRecord _DalRecord = new AttendanceInAndOutRecordDal();
        private readonly IReadDataHistory _DalHistory = new ReadDataHistoryDal();
        //private static IAttendanceRule _DalAttendanceRule = new AttendanceRule();
        private IBll.Accounts.IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private List<Employee> EmployeeList;
        private List<Employee> NewEmployeeList;
        private List<Employee> AllEmployeeList;
        private static AttendanceSendEmail sendMail;
        private static AttendanceSendMessage sendMessage;
        private static DateTime _SearchFrom;
        private static DateTime _SearchTo;
        private static Account _LoginUser;

        ///<summary>
        ///</summary>
        public ReadDataFromAccess(Account loginUser)
        {
            _LoginUser = loginUser;
        }
        /// <summary>
        /// ������
        /// </summary>
        public ReadDataFromAccess(IAttendanceReadRule ruleMock, IEmployee employeeMock,
            IAttendanceInAndOutRecord recordMock, IReadDataHistory readDataHistoryMock, Account loginUser)
        {
            _LoginUser = loginUser;
            _DalReadRule = ruleMock;
            _DalEmployee=employeeMock;
            _DalRecord = recordMock;
            _DalHistory = readDataHistoryMock;
        }

        /// <summary>
        /// ͳ�ƿ��ڽ��������Ϊ��λ
        /// </summary>
        private void UpdateAttendance()
        {
            //UpdateEmployeeAttendance updateEmployeeAttendance = new UpdateEmployeeAttendance(_LoginUser);
            for (int i = 0; i < AllEmployeeList.Count;i++ )
            {
                //��ǰһ������
                DateTime tempDate = _SearchTo.AddDays(-1);
                while (DateTime.Compare(Convert.ToDateTime(_SearchFrom.ToShortDateString()),
                   Convert.ToDateTime(tempDate.ToShortDateString())) <= 0)
                {
                    AllEmployeeList[i].EmployeeAttendance.AttendanceInAndOutRecordList =
                        _DalRecord.GetAttendanceInAndOutRecordByCondition
                            (AllEmployeeList[i].Account.Id, "", tempDate, tempDate.AddDays(1),
                             InOutStatusEnum.All, OutInRecordOperateStatusEnum.All,
                             Convert.ToDateTime("1900-1-1"), Convert.ToDateTime("2900-12-31"));
                    //updateEmployeeAttendance.
                    //    UpdateEmployeeDayAttendance(AllEmployeeList[i], tempDate);
                    tempDate = tempDate.AddDays(-1);
                }
            }
        }
        
        /// <summary>
        /// ϵͳ�Զ�����
        /// </summary>
        private void SystemSendEmailByCondition(OutInTimeConditionEnum outInTimeCondition)
        {
            sendMail = new AttendanceSendEmail();
            StringBuilder emailContentBuilder = new StringBuilder();
            for (int i = 0; i < AllEmployeeList.Count; i++)
            {
                //��ǰһ������
                DateTime tempDate = _SearchTo.AddDays(-1);
                while (DateTime.Compare(Convert.ToDateTime(_SearchFrom.ToShortDateString()),
                    Convert.ToDateTime(tempDate.ToShortDateString())) <= 0)
                {
                    AllEmployeeList[i].EmployeeAttendance.AttendanceInAndOutRecordList = _DalRecord.
                        GetAttendanceInAndOutRecordByCondition
                        (AllEmployeeList[i].Account.Id, "", tempDate, tempDate.AddDays(1), InOutStatusEnum.All,
                         OutInRecordOperateStatusEnum.All, Convert.ToDateTime("1900-1-1"),
                         Convert.ToDateTime("2900-12-31"));

                    AllEmployeeList[i].EmployeeAttendance.InAndOutStatistics(tempDate);

                    bool isOnDuty = true;
                    PlanDutyDetail dayPlanDutyDetail =
                        PlanDutyDetail.GetPlanDutyDetailByDate(
                            AllEmployeeList[i].EmployeeAttendance.PlanDutyDetailList, tempDate);
                    if(dayPlanDutyDetail == null)
                    {
                        if (tempDate.DayOfWeek == DayOfWeek.Saturday 
                            || tempDate.DayOfWeek == DayOfWeek.Sunday)
                            isOnDuty = false;
                    }
                    else if (dayPlanDutyDetail.PlanDutyClass.DutyClassID == -1)
                        isOnDuty = false;
                    
                    string absentString="";

                    //�����һ������Ϣ���ҽ������� ���� ����Ϣ�������㷢������ ���� ����������
                    if ((!isOnDuty && AllEmployeeList[i].EmployeeAttendance.IsOutInTimeCondition(OutInTimeConditionEnum.InOrOutTimeOnlyOneIsNull)) ||
                        (isOnDuty && AllEmployeeList[i].EmployeeAttendance.IsOutInTimeCondition(outInTimeCondition)) ||
                       !AllEmployeeList[i].EmployeeAttendance.StatisticIsNormal(tempDate, out absentString))
                    {
                        string inTime = AllEmployeeList[i].EmployeeAttendance.AttendanceInAndOutStatistics.InTime.ToString();
                        string outTime = AllEmployeeList[i].EmployeeAttendance.AttendanceInAndOutStatistics.OutTime.ToString();
                        string status = AllEmployeeList[i].EmployeeAttendance.AttendanceInAndOutStatistics.LeaveRequestAndOut;

                        SendEmailForEmployees(AllEmployeeList[i], inTime, outTime, status, tempDate);
                        SendMessageForEmployees(AllEmployeeList[i],tempDate);

                        emailContentBuilder.Append(AllEmployeeList[i].Account.Name);
                        emailContentBuilder.Append(tempDate.ToShortDateString());
                        emailContentBuilder.Append(" ����ʱ�䣺");
                        emailContentBuilder.Append(inTime == "2999-12-31 0:00:00" ? "�޴򿨼�¼" : inTime);
                        emailContentBuilder.Append(" �뿪ʱ�䣺");
                        emailContentBuilder.Append(outTime == "1900-1-1 0:00:00" ? "�޴򿨼�¼" : outTime);
                        emailContentBuilder.Append(" ��ٻ���������");
                        emailContentBuilder.Append(string.IsNullOrEmpty(status) ? "��" : status);
                        if (absentString != "")
                        {
                            emailContentBuilder.Append(absentString);
                        }
                        emailContentBuilder.Append(Environment.NewLine);
                    }
                    tempDate = tempDate.AddDays(-1);
                }
            }
            if (emailContentBuilder.Length > 0)
            {
                emailContentBuilder.Append("��˶Դ���Ϣ������������������Ϣ�������¼ϵͳ�鿴��");
                string subject = _SearchFrom + "--" + _SearchTo + "�ڼ�Ŀ�����Ϣ";
                sendMail.AttendanceSendEmailToHR(subject, emailContentBuilder);
            }
        }

        private static void SendEmailForEmployees(Employee employee, string inTime, string outTime, string status, DateTime theDay)
        {
            try
            {
                string employeeName = employee.Account.Name;
                DateTime fromDateTime = new DateTime(theDay.Year, theDay.Month, theDay.Day, 0, 0, 0);
                DateTime toDateTime = new DateTime(theDay.Year, theDay.Month, theDay.Day, 23, 59, 59);

                List<string> cc = new List<string>();
                List<string> to = new List<string>();
                to.Add(employee.Account.Email1);
                if (!string.IsNullOrEmpty(employee.Account.Email2))
                {
                    to.Add(employee.Account.Email2);
                }
                sendMail.AttendanceSendEmailToEmployee(employeeName, inTime, outTime, status,
                    fromDateTime.ToString(), toDateTime.ToString(), to, cc, _LoginUser);
            }
            catch
            {
                //view.MessageFromBll = ex.Message;
            }
        }

        private void SendMessageForEmployees(Employee employee, DateTime theDay)
        {
            try
            {
                employee.Account = _IAccountBll.GetAccountById(employee.Account.Id);
                string employeeName = employee.Account.Name;
                DateTime fromDateTime = new DateTime(theDay.Year, theDay.Month, theDay.Day, 0, 0, 0);
                sendMessage.AttendanceSendErrorMessage(employeeName, employee.Account.MobileNum,fromDateTime);
            }
            catch
            {
                //view.MessageFromBll = ex.Message;
            }
        }
        /// <summary>
        /// �����ݴ�Assess�ж���
        /// </summary>
        private void ReadRecords(DateTime laseReadTime)
        {
            //ȡԱ����ԭʼ��������
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                EmployeeList[i] = _DalEmployee.GetEmployeeByAccountID(EmployeeList[i].Account.Id);
                EmployeeList[i].EmployeeAttendance = new EmployeeAttendance(_SearchFrom , _SearchTo);
                EmployeeList[i].EmployeeAttendance.DoorCardNo =
                    _DalEmployee.GetEmployeeBasicInfoByAccountID(EmployeeList[i].Account.Id).EmployeeAttendance.
                        DoorCardNo;
                EmployeeList[i].EmployeeAttendance.PlanDutyDetailList =
                    new PlanDutyDal().GetPlanDutyDetailByAccount(EmployeeList[i].Account.Id,
                                                                                         _SearchFrom, _SearchTo);
                EmployeeList[i].EmployeeAttendance.AttendanceInAndOutRecordList =new List<AttendanceInAndOutRecord>();
                    
            }
            //��ACCESS������ 

            ReadAccessData _ReadIODataFromAccess = new ReadAccessData();
            List<DataFromAccess> returnList = _ReadIODataFromAccess.ReadRecords(laseReadTime);

            for (int k = 0; k < returnList.Count; k++)
            {
                for (int i = 0; i < EmployeeList.Count; i++)
                {
                    //������ڿ������Ӧ����������������
                    string cardNo = returnList[k].CardNo;
                    if (!string.IsNullOrEmpty(EmployeeList[i].EmployeeAttendance.DoorCardNo)
                        && EmployeeList[i].EmployeeAttendance.DoorCardNo == cardNo)
                    {
                        //�ж϶�ȡ���Ƿ����ظ���¼ add by liudan 2009-09-19
                        List<AttendanceInAndOutRecord> sqlRecords =
                            _DalRecord.GetAttendanceInAndOutRecordByCondition(EmployeeList[i].Account.Id, cardNo,
                                                                              laseReadTime, Convert.ToDateTime("2999-12-31"),
                                                                              InOutStatusEnum.All,
                                                                              OutInRecordOperateStatusEnum.All, Convert.ToDateTime("1900-12-31"),
                                                                              Convert.ToDateTime("2999-12-31"));
                        bool isFind=false;
                        foreach(AttendanceInAndOutRecord records in sqlRecords)
                        {
                            if(returnList[k].InOrOut.Equals(records.IOStatus)&&returnList[k].IOTime.Equals(records.IOTime))
                            {
                                isFind = true;
                            }
                        }
                        if (!isFind)
                        {
                            AttendanceInAndOutRecord attendanceInAndOutRecord = new AttendanceInAndOutRecord();
                            attendanceInAndOutRecord.DoorCardNo = returnList[k].CardNo;
                            attendanceInAndOutRecord.IOStatus = returnList[k].InOrOut;
                            attendanceInAndOutRecord.IOTime = returnList[k].IOTime;
                            attendanceInAndOutRecord.OperateStatus = OutInRecordOperateStatusEnum.ReadFromDataBase;
                            attendanceInAndOutRecord.OperateTime = DateTime.Now;
                            EmployeeList[i].EmployeeAttendance.AttendanceInAndOutRecordList.Add(attendanceInAndOutRecord);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ������������д��sql
        /// </summary>
        private void WriteSQL()
        {
            bool isRevalueSearchFrom = false;
            if (_SearchFrom.CompareTo(Convert.ToDateTime("1900-1-1 00:00:00")) == 0)
            {
                isRevalueSearchFrom = true;
                _SearchFrom = Convert.ToDateTime("2999-12-31 00:00:00");
            }
            for (int i = 0; i < EmployeeList.Count;i++ )
            {
                List<AttendanceInAndOutRecord> attendanceInAndOutRecordList =
                    EmployeeList[i].EmployeeAttendance.AttendanceInAndOutRecordList;
                if (attendanceInAndOutRecordList.Count >0)
                {
                    NewEmployeeList.Add(EmployeeList[i]);
                    //���֮ǰû�ж������ݣ����ҳ����������������ʱ��
                    if (isRevalueSearchFrom)
                    {
                        for (int k = 0; k < attendanceInAndOutRecordList.Count; k++)
                        {
                            if (DateTime.Compare(_SearchFrom, attendanceInAndOutRecordList[k].IOTime) > 0)
                            {
                                _SearchFrom = attendanceInAndOutRecordList[k].IOTime;
                            }
                        }
                    }
                }
                //���Ա���п��ڹ���
                if (EmployeeList[i].EmployeeAttendance.PlanDutyDetailList != null &&
                    EmployeeList[i].EmployeeAttendance.PlanDutyDetailList.Count != 0)
                {
                    AllEmployeeList.Add(EmployeeList[i]);
                }
            }
            if (NewEmployeeList.Count > 0)
            {
                _DalRecord.InsertAttendanceInAndOutRecordList(NewEmployeeList);
            }
        }

        private int employeeID;
        private List<Employee> ChangeEmployeeList(List<Employee> employeeList, List<Account> accountList)
        {
            List<Employee> returnEmployeeList=new List<Employee>();
            foreach (Employee employee in employeeList)
            {
                employeeID = employee.Account.Id;
                Account account = accountList.Find(FindEmployee);
                if (account != null)
                {
                    employee.Account.Name = account.Name;
                    returnEmployeeList.Add(employee);
                }
            }
            return returnEmployeeList;
        }
        private bool FindEmployee(Account account)
        {
            return account.Id == employeeID;
        }

        /// <summary>
        /// ��Access���ݿ��ж����ݣ�д��SQL���ݿ⣬����ʷ
        /// </summary>
        public void ReadDataFromAccessToSQL(int readDataHistoryID)
        {
            _SearchTo = DateTime.Now;
            EmployeeList = _DalEmployee.GetAllEmployeeBasicInfo();

            List<Account> accountList = _IAccountBll.GetAllAccount();

            EmployeeList = ChangeEmployeeList(EmployeeList, accountList);
            NewEmployeeList = new List<Employee>();
            AllEmployeeList = new List<Employee>();
            ReadDataHistory readHistory;
            try
            {
                //modify by liudan update read time 2009-09-16
                //readHistory = _DalHistory.GetLastSuccessReadDataHistory();
                //if (readHistory == null)
                //{
                //    _SearchFrom = Convert.ToDateTime("1900-1-1 00:00:00");
                //}
                //else
                //{
                //    _SearchFrom = readHistory.ReadTime;
                //}
                _SearchFrom = _DalRecord.GetAssessReadMaxIOTime();
                ReadRecords(_SearchFrom);
                WriteSQL();
                //���¶�ȡ��ʷ����ȡ�ɹ�
                readHistory = new ReadDataHistory(DateTime.Now, ReadDataResultType.ReadSuccess,"");
                readHistory.ReadDataId = readDataHistoryID;
                _DalHistory.UpdateReadDataHistory(readHistory);
            }
            catch(Exception ex)
            {
                //���¶�ȡ��ʷ����ȡʧ��
                readHistory = new ReadDataHistory(DateTime.Now, ReadDataResultType.ReadFail, ex.Message);
                readHistory.ReadDataId = readDataHistoryID;
                _DalHistory.UpdateReadDataHistory(readHistory);
            }
        }

        /// <summary>
        /// ��Access���ݿ��ж����ݣ�д��SQL���ݿ⣬����ʷ���ж�ȡʱ��Σ�2009-09-28,add by liudan
        /// </summary>
        public void ReadDataFromAccessToSQL(int readDataHistoryID, DateTime readFromTime, DateTime readToTime)
        {
            EmployeeList = _DalEmployee.GetAllEmployeeBasicInfo();

            List<Account> accountList = _IAccountBll.GetAllAccount();

            EmployeeList = ChangeEmployeeList(EmployeeList, accountList);
            NewEmployeeList = new List<Employee>();
            AllEmployeeList = new List<Employee>();
            ReadDataHistory readHistory;
            try
            {
                _SearchFrom = readFromTime;
                _SearchTo = readToTime;
                ReadRecordsWithReadTime(readFromTime, readToTime);
                WriteSQL();
                //���¶�ȡ��ʷ����ȡ�ɹ�
                readHistory = new ReadDataHistory(DateTime.Now, ReadDataResultType.ReadSuccess, "");
                readHistory.ReadDataId = readDataHistoryID;
                _DalHistory.UpdateReadDataHistory(readHistory);
            }
            catch (Exception ex)
            {
                //���¶�ȡ��ʷ����ȡʧ��
                readHistory = new ReadDataHistory(DateTime.Now, ReadDataResultType.ReadFail, ex.Message);
                readHistory.ReadDataId = readDataHistoryID;
                _DalHistory.UpdateReadDataHistory(readHistory);
            }
        }

        /// <summary>
        /// ϵͳ�Զ�0������ݣ���ͳ�ƿ��ڽ��������
        /// </summary>
        public void SystemReadDataFromAccessToSQL(ReadDataHistory readNewHistory)
        {
            ReadDataHistory readHistory = _DalHistory.GetLastReadDataHistory();
            if (readHistory != null && readHistory.ReadResult == ReadDataResultType.Reading)
            {
                return;
            }
            int pkid = _DalHistory.InsertReadDataHistory(readNewHistory);
            readNewHistory.ReadDataId = pkid;
            ReadDataFromAccessToSQL(pkid);
            UpdateAttendance();
            SystemSendEmailByCondition(OutInTimeConditionEnum.InOrOutTimeIsNull);
        }

        /// <summary>
        /// ϵͳ�Զ���ָ��ʱ���ȡ��������
        /// </summary>
        public void SystemReadDataFromSetTime()
        {
            AttendanceReadRule attendanceReadRule = _DalReadRule.GetAttendanceReadRuleByPkid(1);
            if (attendanceReadRule.ReadDateTime.ToShortTimeString().Equals(DateTime.Now.ToShortTimeString()))
            {
                ReadDataHistory readHistory = _DalHistory.GetLastReadDataHistory();
                if (readHistory.ReadResult == ReadDataResultType.Reading)
                {
                    return;
                }
                readHistory = new ReadDataHistory(DateTime.Now, ReadDataResultType.Reading,"");
                int pkid = _DalHistory.InsertReadDataHistory(readHistory);
                readHistory.ReadDataId = pkid;
                ReadDataFromAccessToSQL(pkid);

                if (attendanceReadRule.IsSendMail)
                {
                    OutInTimeConditionEnum outInTimeCondition;
                    switch (attendanceReadRule.SendEmailRule)
                    {
                        case SendEmailRuleType.InEmpty:
                            outInTimeCondition = OutInTimeConditionEnum.InTimeIsNull;
                            break;
                        case SendEmailRuleType.OutEmpty:
                            outInTimeCondition = OutInTimeConditionEnum.OutTimeIsNull;
                            break;
                        case SendEmailRuleType.InAndOutEmpty:
                            outInTimeCondition = OutInTimeConditionEnum.InAndOutTimeIsNull;
                            break;
                        case SendEmailRuleType.InOrOutEmpty:
                            outInTimeCondition = OutInTimeConditionEnum.InOrOutTimeIsNull;
                            break;
                        default:
                            outInTimeCondition = OutInTimeConditionEnum.All;
                            break;
                    }
                    SystemSendEmailByCondition(outInTimeCondition);
                }
            }
        }

        /// <summary>
        /// ��Accesss�ж�ȡʱ�䣬�ж�ȡʱ���2009-09-28,add by liudan
        /// </summary>
        private void ReadRecordsWithReadTime(DateTime readFromTime, DateTime readToTime)
        {
            //ȡԱ����ԭʼ��������
            for (int i = 0; i < EmployeeList.Count; i++)
            {
                EmployeeList[i] = _DalEmployee.GetEmployeeByAccountID(EmployeeList[i].Account.Id);
                EmployeeList[i].EmployeeAttendance = new EmployeeAttendance(_SearchFrom, _SearchTo);
                EmployeeList[i].EmployeeAttendance.DoorCardNo =
                    _DalEmployee.GetEmployeeBasicInfoByAccountID(EmployeeList[i].Account.Id).EmployeeAttendance.
                        DoorCardNo;
                EmployeeList[i].EmployeeAttendance.PlanDutyDetailList =
                    new PlanDutyDal().GetPlanDutyDetailByAccount(EmployeeList[i].Account.Id,
                                                                                         _SearchFrom, _SearchTo);
                EmployeeList[i].EmployeeAttendance.AttendanceInAndOutRecordList = new List<AttendanceInAndOutRecord>();

            }
            //��ACCESS������ 

            ReadAccessData _ReadIODataFromAccess = new ReadAccessData();
            List<DataFromAccess> returnList = _ReadIODataFromAccess.ReadRecords(readFromTime, readToTime);

            for (int k = 0; k < returnList.Count; k++)
            {
                for (int i = 0; i < EmployeeList.Count; i++)
                {
                    //������ڿ������Ӧ����������������
                    string cardNo = returnList[k].CardNo;
                    if (!string.IsNullOrEmpty(EmployeeList[i].EmployeeAttendance.DoorCardNo)
                        && EmployeeList[i].EmployeeAttendance.DoorCardNo == cardNo)
                    {
                                                //�ж϶�ȡ���Ƿ����ظ���¼ add by liudan 2009-09-19
                        List<AttendanceInAndOutRecord> sqlRecords =
                            _DalRecord.GetAttendanceInAndOutRecordByCondition(EmployeeList[i].Account.Id, cardNo,
                                                                              readFromTime, readToTime,
                                                                              InOutStatusEnum.All,
                                                                              OutInRecordOperateStatusEnum.All, Convert.ToDateTime("1900-12-31"),
                                                                              Convert.ToDateTime("2999-12-31"));
                        bool isFind=false;
                        foreach(AttendanceInAndOutRecord records in sqlRecords)
                        {
                            if(returnList[k].InOrOut.Equals(records.IOStatus)&&returnList[k].IOTime.Equals(records.IOTime))
                            {
                                isFind = true;
                            }
                        }
                        if (!isFind)
                        {
                            AttendanceInAndOutRecord attendanceInAndOutRecord = new AttendanceInAndOutRecord();
                            attendanceInAndOutRecord.DoorCardNo = returnList[k].CardNo;
                            attendanceInAndOutRecord.IOStatus = returnList[k].InOrOut;
                            attendanceInAndOutRecord.IOTime = returnList[k].IOTime;
                            attendanceInAndOutRecord.OperateStatus = OutInRecordOperateStatusEnum.ReadFromDataBase;
                            attendanceInAndOutRecord.OperateTime = DateTime.Now;
                            EmployeeList[i].EmployeeAttendance.AttendanceInAndOutRecordList.Add(attendanceInAndOutRecord);
                        }
                    }
                }
            }
        }
    }
}
