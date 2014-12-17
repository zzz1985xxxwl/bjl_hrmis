//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: HrmisUtility.cs.cs
// Creater:  Xue.wenlong
// Date:  2009-03-24
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using SEP.HRMIS.Model.PayModule;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class HrmisUtility
    {
        /// <summary>
        /// 
        /// </summary>
        public const string _DbError = "���ݿ���ʴ���";

        #region �������

        public const string _LeaveRequestType_Name_Repeat = "��������ظ�";
        public const string _LeaveRequestType_Name_NotExist = "������Ͳ�����";
        public const string _LeaveRequestType_HasLeaveRequest = "����������Ѿ���ʹ�ã����ɱ��޸Ļ�ɾ��";
        public const string _LeaveRequestType_CanNotDelete = "��Ҫ����������ɾ��";
        #endregion

        #region ���
        public const string _Date_Repeat = "��ʱ����ڣ�������ټ�¼";
        public const string _Date_Inner_Repeat = "������¼�����ص�ʱ���";
        public const string _Over_Vacation = "���ʱ�䳬��ʣ�����";
        public const string _Over_AdjustRest = "���ʱ�䳬��ʣ�����";

        public const string _LeaveRequestItem_CanNot_Zero = "������У�������0Сʱ��";
        public const string _OutApplicationItem_CanNot_Zero = "������У�������0Сʱ��";
        public const string _OverWorkItem_CanNot_Zero = "�Ӱ����У�������0Сʱ��";
        /// <summary>
        /// ����ٵ����ܱ�ȡ��
        /// </summary>
        public const string _LeaveRequest_CanNot_BeCancled = "����ٵ����ܱ�ȡ��";
        /// <summary>
        /// ����ٵ����ֲ��ܱ�ȡ��
        /// </summary>
        public const string _LeaveRequest_Partial_CanNot_BeCancled = "����ٵ����ֲ��ܱ�ȡ��";
        /// <summary>
        /// ����ٵ����ֲ��ܱ����
        /// </summary>
        public const string _LeaveRequest_Partial_CanNot_BeApproved = "����ٵ����ֲ��ܱ����";
        /// <summary>
        /// ����ٵ�������
        /// </summary>
        public const string _LeaveRequest_Not_Exist = "����ٵ�������";
        ///// <summary>
        ///// ����������ٵ�����
        ///// </summary>
        //public const string _LeaveRequest_Not_Whole_Action = "����������ٵ�����";
        /// <summary>
        /// ���˺�û���������
        /// </summary>
        public const string _No_LeaveRequest_DiyProcess = "���˺�û���������";
        /// <summary>
        /// ���˺�û�п�������
        /// </summary>
        public const string _No_Assess_DiyProcess = "���˺�û�м�Ч��������";
        /// <summary>
        /// û��Ȩ����˸���ٵ�
        /// </summary>
        public const string _No_Auth_To_Approve = "û��Ȩ����˸���ٵ�";
        /// <summary>
        /// ���޴��ˣ������жϣ�����������ϵ
        /// </summary>
        public const string _No_Account = "���޴��ˣ������жϣ�����������Դ����ϵ";

        #endregion

        #region ���

        public const string _Date_Out_Repeat = "��ʱ����ڣ����������¼";
        public const string _From_Bigger_To = "��ʼʱ����ڽ���ʱ��";
        public const string _OutApplication_Not_Exit = "��������벻����";
        public const string _OutApplication_CanNot_BeCancled = "��������벻�ܱ�ȡ��";
        public const string _OutApplicationItem_Not_Exit = "��������������";
        public const string _NextOperator_Not_Exit = "��һ�������˲�����";
        public const string _No_OutApplication_DiyProcess = "���˺�û���������";
        #endregion

        #region �Ӱ�

        public const string _Date_OverWork_Repeat = "��ʱ����ڣ����мӰ��¼";
        public const string _OverWork_Not_Exit = "�üӰ����벻����";
        public const string _OverWork_CanNot_BeCancled = "�üӰ����벻�ܱ�ȡ��";
        public const string _OverWorkItem_Not_Exit = "�üӰ����������";
        public const string _OverWorkType_Not_OneDay = "���ܿ���";
        public const string _PlanDutyDetail_NULL = "û���Ű��";
        public const string _No_OverWork_DiyProcess = "���˺�û�мӰ�����";
        #endregion

        #region �Զ�������

        public const string _DiyProcess_Name_Repeat = "�Զ������̵����Ʋ����ظ�";
        public const string _DiyProcess_Used = "����������ʹ���У����ܱ�ɾ��";

        #endregion

        #region ����

        public const string _Nationality_Name_Repeat = "���������ظ�";
        public const string _Nationality_NotExist = "�ù���������";
        public const string _Nationality_HasBeenUsed = "�˹����Ѿ���ʹ�ã����ɱ��޸Ļ�ɾ��";

        #endregion

        #region ְλ����
        public const string _PositionApplication_Not_Exit = "��ְλ���벻����";
        public const string _PositionApplication_CanNot_BeCancled = "��ְλ���벻�ܱ�ȡ��";
        public const string _No_PositionApplication_DiyProcess = "���˺�û��ְλ��������";
        public const string _PositionApplication_CanNot_BeApproved = "��ְλ���벻�ܱ����";
        #endregion

        #region ���ݹ���

        public const string _AdjustRule_Name_Repeat = "���ݹ��������ظ�";
        public const string _AdjustRule_Not_Exit = "���ݹ��򲻴���";
        public const string _AdjustRule_Used = "���ݹ�������ʹ�ã��޷�ɾ��";
        public const string _Employee_NotHave_AdjustRule = "û�е��ݹ���";

        #endregion

        #region �ͻ���Ϣ

        public const string _CustomerInfo_Name_Repeat = "�ͻ������ظ�";
        public const string _CustomerInfo_Not_Exit = "�ͻ���Ϣ������";
        public const string _CustomerInfo_Used = "�ͻ���Ϣ����ʹ�ã��޷�ɾ��";


        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static ApplicationException ThrowException(string constString)
        {
            throw new ApplicationException(constString);
        }

        /// <summary>
        /// ���ݵ�ǰ�����ˣ�����û��Ȩ�޲�����Ա��
        /// </summary>
        /// <param name="oldEmployeeList"></param>
        /// <param name="authType"></param>
        /// <param name="loginUser"></param>
        /// <param name="powersID"></param>
        /// <returns></returns>
        public static List<Employee> RemoteUnAuthEmployee(List<Employee> oldEmployeeList,
            AuthType authType, Account loginUser, int powersID)
        {
            Auth myAuth = loginUser.FindAuth(authType, powersID);

            if (myAuth == null)
            {
                return new List<Employee>();
                //throw new ApplicationException("û��Ȩ�޷���");
            }
            if (myAuth.Departments.Count == 0)
                return oldEmployeeList;

            List<Employee> newEmployeeList = new List<Employee>();
            for (int i = 0; i < oldEmployeeList.Count; i++)
            {
                if (SEP.Model.Utility.Tools.IsDeptListContainsDept(myAuth.Departments, oldEmployeeList[i].Account.Dept))
                {
                    newEmployeeList.Add(oldEmployeeList[i]);
                }
            }
            return newEmployeeList;
        }
        /// <summary>
        /// ���ݵ�ǰ�����ˣ�����û��Ȩ�޲�����Ա�����
        /// </summary>
        /// <param name="oldVacationList"></param>
        /// <param name="authType"></param>
        /// <param name="loginUser"></param>
        /// <param name="powersID"></param>
        /// <returns></returns>
        public static List<Vacation> RemoteUnAuthVacation(List<Vacation> oldVacationList,
            AuthType authType, Account loginUser, int powersID)
        {
            Auth myAuth = loginUser.FindAuth(authType, powersID);

            if (myAuth == null)
            {
                return new List<Vacation>();
                //throw new ApplicationException("û��Ȩ�޷���");
            }
            if (myAuth.Departments.Count == 0)
                return oldVacationList;

            List<Vacation> newVacationList = new List<Vacation>();
            for (int i = 0; i < oldVacationList.Count; i++)
            {
                if (oldVacationList[i].Employee.Account != null &&
                    SEP.Model.Utility.Tools.IsDeptListContainsDept(myAuth.Departments,
                                                                   oldVacationList[i].Employee.Account.Dept))
                {
                    newVacationList.Add(oldVacationList[i]);
                }
            }
            return newVacationList;
        }
        /// <summary>
        /// ���ݵ�ǰ�����ˣ�����û��Ȩ�޲����ĺ�ͬ
        /// </summary>
        /// <param name="oldContractList"></param>
        /// <param name="authType"></param>
        /// <param name="loginUser"></param>
        /// <param name="powersID"></param>
        /// <returns></returns>
        public static List<Contract> RemoteUnAuthContract(List<Contract> oldContractList,
            AuthType authType, Account loginUser, int powersID)
        {
            Auth myAuth = loginUser.FindAuth(authType, powersID);

            if (myAuth == null)
            {
                return new List<Contract>();
                //throw new ApplicationException("û��Ȩ�޷���");
            }
            if (myAuth.Departments.Count == 0)
                return oldContractList;

            List<Contract> newContractList = new List<Contract>();
            for (int i = 0; i < oldContractList.Count; i++)
            {
                if (oldContractList[i].Employee != null && oldContractList[i].Employee.Account != null &&
                    oldContractList[i].Employee.Account.Dept != null &&
                    SEP.Model.Utility.Tools.IsDeptListContainsDept(myAuth.Departments,
                                                                   oldContractList[i].Employee.Account.Dept))
                {
                    newContractList.Add(oldContractList[i]);
                }
            }
            return newContractList;
        }
        /// <summary>
        /// ���ݵ�ǰ�����ˣ�����û��Ȩ�޲�����Ա��н��
        /// </summary>
        /// <param name="oldEmployeeSalaryList"></param>
        /// <param name="authType"></param>
        /// <param name="loginUser"></param>
        /// <param name="powersID"></param>
        /// <returns></returns>
        public static List<EmployeeSalary> RemoteUnAuthEmployeeSalary(List<EmployeeSalary> oldEmployeeSalaryList,
            AuthType authType, Account loginUser, int powersID)
        {
            Auth myAuth = loginUser.FindAuth(authType, powersID);

            if (myAuth == null)
            {
                return new List<EmployeeSalary>();
                //throw new ApplicationException("û��Ȩ�޷���");
            }
            if (myAuth.Departments.Count == 0)
                return oldEmployeeSalaryList;

            List<EmployeeSalary> newEmployeeSalaryList = new List<EmployeeSalary>();
            for (int i = 0; i < oldEmployeeSalaryList.Count; i++)
            {
                if (oldEmployeeSalaryList[i].Employee.Account != null &&
                    SEP.Model.Utility.Tools.IsDeptListContainsDept(myAuth.Departments,
                                                                   oldEmployeeSalaryList[i].Employee.Account.Dept))
                {
                    newEmployeeSalaryList.Add(oldEmployeeSalaryList[i]);
                }
            }
            return newEmployeeSalaryList;
        }

        private readonly string _AttendanceStartDay = ConfigurationManager.AppSettings["AttendanceStartDay"];
        ///<summary>
        /// ���ڿ�ʼʱ��
        ///</summary>
        public string AttendanceStratDay
        {
            get
            {
                if (string.IsNullOrEmpty(_AttendanceStartDay))
                {
                    return "1";
                    //throw new ApplicationException("���ڿ�ʼ�մ���");
                }
                return _AttendanceStartDay;
            }
        }

        /////<summary>
        ///// ���ڻ�׼��,true Ϊ���㵱�¹��ʣ�falseΪ�����¸��¹���
        /////</summary>
        /////<exception cref="ApplicationException"></exception>
        //public static bool AttendanceBaseMonth
        //{
        //    get
        //    {
        //        string _AttendanceBaseMonth = ConfigurationManager.AppSettings["AttendanceBaseMonth"];
        //        if (string.IsNullOrEmpty(_AttendanceBaseMonth))
        //        {
        //            throw new ApplicationException("���ڻ�׼�´���");
        //        }
        //        return _AttendanceBaseMonth.Equals("true");
        //    }
        //}

        /// <summary>
        /// ��ȡ���¿�ʼʱ��
        /// </summary>
        public DateTime CurrenMonthStartTime()
        {

            DateTime now = DateTime.Today;
            DateTime currentStartTime = Convert.ToDateTime(now.Year + "-" + now.Month + "-" + AttendanceStratDay);
            return now.Day >= Convert.ToInt32(AttendanceStratDay) ? Convert.ToDateTime(now.Year + "-" + now.Month + "-" + AttendanceStratDay) : currentStartTime.AddMonths(-1);
        }

        /// <summary>
        /// ��ȡ���¿�ʼʱ��
        /// </summary>
        public DateTime CurrenMonthEndTime()
        {
            return CurrenMonthStartTime().AddMonths(1).AddDays(-1);
        }

        ///<summary>
        /// ��ȡĳ��ʱ���Ŀ�ʼʱ��
        ///</summary>
        ///<param name="time"></param>
        ///<returns></returns>
        public DateTime StartMonthByYearMonth(DateTime time)
        {
            DateTime temp = Convert.ToDateTime(time.Year + "-" + time.Month + "-" + AttendanceStratDay);
            return time.Day >= Convert.ToInt32(AttendanceStratDay)
                       ? temp
                       : temp.AddMonths(-1);
        }
        /// <summary>
        /// employeelist���Ƿ����employee
        /// </summary>
        /// <param name="list"></param>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static bool IsEmployeeListContainEmployee(List<Employee> list, int employeeID)
        {
            if (list == null || list.Count == 0)
                return false;
            foreach (Employee eachEmployee in list)
            {
                if (employeeID == eachEmployee.Account.Id)
                    return true;
            }
            return false;
        }

        ///<summary>
        /// ��ȡĳ��ʱ���Ľ���ʱ��
        ///</summary>
        ///<param name="time"></param>
        ///<returns></returns>
        public DateTime EndMonthByYearMonth(DateTime time)
        {
            return StartMonthByYearMonth(time).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// 
        /// </summary>
        public static decimal? ConvertToDecimal(object obj)
        {
            if (obj == null || obj == DBNull.Value || string.IsNullOrEmpty(obj.ToString()))
            {
                return null;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static List<string> GetMail(Account account)
        {
            List<string> mails = new List<string>();
            string mailto1 = account.Email1;
            string mailto2 = account.Email2;
            mails.Add(mailto1);
            if (!string.IsNullOrEmpty(mailto2))
            {
                mails.Add(mailto2);
            }
            return mails;
        }
    }
}