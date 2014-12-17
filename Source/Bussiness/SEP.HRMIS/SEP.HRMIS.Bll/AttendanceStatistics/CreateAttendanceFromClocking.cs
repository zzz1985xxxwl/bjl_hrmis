using System;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    ///<summary>
    ///</summary>
    public class CreateAttendanceFromClocking
    {
        private static readonly IEmployee _DalEmployee = DalFactory.DataAccess.CreateEmployee();
        private static readonly IAttendanceInAndOutRecord _DalRecord = DalFactory.DataAccess.CreateAttendanceInAndOutRecord();
        
        ///<summary>
        ///</summary>
        ///<param name="from"></param>
        ///<param name="to"></param>
        ///<param name="accountList"></param>
        ///<param name="loginUser"></param>
        public void UpdateAttendanceForOperator(DateTime from, DateTime to, 
            List<Account> accountList, Account loginUser)
        {
            //UpdateEmployeeAttendance updateEmployeeAttendance = new UpdateEmployeeAttendance(loginUser);
            
            List<Employee> AllEmployeeList = new List<Employee>();
            GetEmployee getEmployee = new GetEmployee();
            foreach (Account account in accountList)
            {
                AllEmployeeList.Add(getEmployee.GetEmployeeBasicInfoByAccountID(account.Id));
            }
            for (int i = 0; i < AllEmployeeList.Count; i++)
            {
                //找前一天数据
                DateTime tempDate = to;
                while (DateTime.Compare(Convert.ToDateTime(from.ToShortDateString()),
                   Convert.ToDateTime(tempDate.ToShortDateString())) <= 0)
                {
                    AllEmployeeList[i] = _DalEmployee.GetEmployeeByAccountID(AllEmployeeList[i].Account.Id);
                    AllEmployeeList[i].EmployeeAttendance = new Model.EmployeeAttendance.AttendanceStatistics.EmployeeAttendance
                        (tempDate.AddDays(-1), tempDate);
                    AllEmployeeList[i].EmployeeAttendance.AttendanceInAndOutRecordList =
                        _DalRecord.GetAttendanceInAndOutRecordByCondition
                            (AllEmployeeList[i].Account.Id, "",
                             Convert.ToDateTime(tempDate.ToShortDateString() + " 00:00:00"),
                             Convert.ToDateTime(tempDate.ToShortDateString() + " 23:59:59"),
                             InOutStatusEnum.All, OutInRecordOperateStatusEnum.All,
                             Convert.ToDateTime("1900-1-1"), Convert.ToDateTime("2900-12-31"));
                    AllEmployeeList[i].EmployeeAttendance.DoorCardNo =
                        _DalEmployee.GetEmployeeBasicInfoByAccountID(AllEmployeeList[i].Account.Id).EmployeeAttendance.
                            DoorCardNo;
                    AllEmployeeList[i].EmployeeAttendance.PlanDutyDetailList =
                        DalFactory.DataAccess.CreatePlanDutyDal().GetPlanDutyDetailByAccount(
                            AllEmployeeList[i].Account.Id,
                            Convert.ToDateTime(tempDate.ToShortDateString() + " 00:00:00"),
                            Convert.ToDateTime(tempDate.ToShortDateString() + " 23:59:59"));

                    //updateEmployeeAttendance.
                    //    UpdateEmployeeDayAttendance(AllEmployeeList[i], tempDate);
                    tempDate = tempDate.AddDays(-1);
                }
            }
        }
    }
}
