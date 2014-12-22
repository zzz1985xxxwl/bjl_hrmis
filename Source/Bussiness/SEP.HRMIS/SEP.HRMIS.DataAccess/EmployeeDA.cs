using System;
using System.Collections.Generic;
using System.Data;
using Framework.Common.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.DataAccess
{
    public class EmployeeDA
    {
        public static List<EmployeeEntity> GetEmployeeBasicInfoByBasicConditionWithCompanyAge(string employeeName,
            int employeeType,
            int positionID,
            int? gradesID,
            int? companyAgeFrom,
            int? companyAgeTo,
            List<int> departmentID,
            int employeeStatus)
        {
            using (var dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    string.Format(
                        @"
select a.PKID,b.EmployeeName,b.MobileNum as MobileNum,a.CompanyID,d.PKID as DepartmentID,d.DepartmentName as DepartmentName,e.PKID as PositionID,e.PositionName,a.AccountID,a.ComeDate,a.EmployeeType,c.DepartmentName as CompanyName from TEmployee as a with(nolock)
inner join {0}.dbo.TAccount as b with(nolock) on a.AccountID=b.PKID
inner join {0}.dbo.TDepartment as c with(nolock) on a.CompanyID=c.PKID
inner join {0}.dbo.TDepartment as d with(nolock) on b.DepartmentId=d.PKID
inner join {0}.dbo.TPosition as e with(nolock) on e.PKID=b.PositionId
where EmployeeName like @EmployeeName
",
                        SqlHelper.SEPDBName);

                dataOperator.SetParameter("@EmployeeName", "%" + employeeName + "%", SqlDbType.NVarChar, 50);
                if (departmentID != null && departmentID.Count > 0)
                {
                    dataOperator.CommandText += " and DepartmentId in (" + string.Join(",", departmentID) + ")";
                }
                if (positionID != 0 && positionID != -1)
                {
                    dataOperator.CommandText += " and PositionId=@PositionId";
                    dataOperator.SetParameter("@PositionId", positionID, SqlDbType.Int);
                }
                if (employeeType >= 0)
                {
                    dataOperator.CommandText += " and EmployeeType=@EmployeeType";
                    dataOperator.SetParameter("@EmployeeType", employeeType, SqlDbType.Int);
                }
                if (gradesID != null)
                {
                    dataOperator.CommandText += " and GradesID=@GradesID";
                    dataOperator.SetParameter("@GradesID", gradesID, SqlDbType.Int);
                }
                if (companyAgeFrom != null)
                {
                    DateTime from = DateTime.Now.Date.AddDays(-companyAgeFrom.GetValueOrDefault());
                    dataOperator.CommandText += " and ComeDate<=@ComeDateFrom";
                    dataOperator.SetParameter("@ComeDateFrom", from, SqlDbType.DateTime);
                }
                if (companyAgeTo != null)
                {
                    DateTime to = DateTime.Now.Date.AddDays(-companyAgeTo.GetValueOrDefault());
                    dataOperator.CommandText += " and ComeDate>=@ComeDateTo";
                    dataOperator.SetParameter("@ComeDateTo", to, SqlDbType.DateTime);
                }
                //在职
                if (employeeStatus == 0)
                {
                    dataOperator.CommandText +=
                        " and ComeDate<=getdate() and (LeaveDate is null or LeaveDate > getdate())";
                }
                    //离职
                else if (employeeStatus == 1)
                {
                    dataOperator.CommandText += " and LeaveDate<getdate()";
                }
                return dataOperator.ExecuteEntityList<EmployeeEntity>();
            }
        }

        public static List<EmployeeEntity> GetEmployeeBasicInfoByBasicCondition(string employeeName,
            int employeeType,
            int positionID,
            int? gradesID,
            int? companyID,
            List<int> departmentID,
            List<int> canOperateDepartmentList,
            int employeeStatus, List<int> notInEmployeeType, bool? hasPlanDuty)
        {
            using (var dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    string.Format(
                        @"
select a.PKID,b.EmployeeName,b.MobileNum as MobileNum,a.CompanyID,d.PKID as DepartmentID
,d.DepartmentName as DepartmentName,e.PKID as PositionID,e.PositionName,a.AccountID
,a.ComeDate,a.LeaveDate,a.EmployeeType,c.DepartmentName as CompanyName 
,a.CompanyID,a.DoorCardNo
from TEmployee as a with(nolock)
inner join {0}.dbo.TAccount as b with(nolock) on a.AccountID=b.PKID
inner join {0}.dbo.TDepartment as c with(nolock) on a.CompanyID=c.PKID
inner join {0}.dbo.TDepartment as d with(nolock) on b.DepartmentId=d.PKID
inner join {0}.dbo.TPosition as e with(nolock) on e.PKID=b.PositionId
where 1=1 
",
                        SqlHelper.SEPDBName);
                if (!string.IsNullOrEmpty(employeeName))
                {
                    dataOperator.CommandText += " and EmployeeName like @EmployeeName";
                    dataOperator.SetParameter("@EmployeeName", "%" + employeeName + "%", SqlDbType.NVarChar, 50);
                }
                if (canOperateDepartmentList != null && canOperateDepartmentList.Count > 0)
                {
                    dataOperator.CommandText += " and DepartmentId in (" + string.Join(",", canOperateDepartmentList) +
                                                ")";
                }
                if (departmentID != null && departmentID.Count > 0)
                {
                    dataOperator.CommandText += " and DepartmentId in (" + string.Join(",", departmentID) + ")";
                }
                if (positionID > 0)
                {
                    dataOperator.CommandText += " and PositionId=@PositionId";
                    dataOperator.SetParameter("@PositionId", positionID, SqlDbType.Int);
                }
                if (companyID != null && companyID > 0)
                {
                    dataOperator.CommandText += " and a.CompanyId=@CompanyId";
                    dataOperator.SetParameter("@CompanyId", companyID, SqlDbType.Int);
                }
                if (employeeType >= 0)
                {
                    dataOperator.CommandText += " and EmployeeType=@EmployeeType";
                    dataOperator.SetParameter("@EmployeeType", employeeType, SqlDbType.Int);
                }
                if (notInEmployeeType != null && notInEmployeeType.Count > 0)
                {
                    dataOperator.CommandText += " and EmployeeType not in (" + string.Join(",", notInEmployeeType) + ")";
                }
                if (gradesID != null)
                {
                    dataOperator.CommandText += " and GradesID=@GradesID";
                    dataOperator.SetParameter("@GradesID", gradesID, SqlDbType.Int);
                }
                //在职
                if (employeeStatus == 0)
                {
                    dataOperator.CommandText +=
                        " and ComeDate<=getdate() and (LeaveDate is null or LeaveDate > getdate())";
                }
                    //离职
                else if (employeeStatus == 1)
                {
                    dataOperator.CommandText += " and LeaveDate<getdate()";
                }
                if (hasPlanDuty == true)
                {
                    dataOperator.CommandText += " and b.PKID in (select AccountID from TPlanDuty)";
                }
                return dataOperator.ExecuteEntityList<EmployeeEntity>();
            }
        }
    }
}