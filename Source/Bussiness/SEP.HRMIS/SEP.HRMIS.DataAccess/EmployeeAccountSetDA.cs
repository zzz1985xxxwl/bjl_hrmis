using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Framework.Common.DataAccess;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.DataAccess
{
    /// <summary>
    /// 插入一条记录到EmployeeAccountSet表的数据访问类
    /// </summary>
    public class EmployeeAccountSetDA
    {
        public static List<EmployeeAccountSetEntity> GetEmployeeAccountSetByCondition(string employeeName, List<int> departmentID,
            int positionID, int employeeTypeEnum, List<int> canOperateDepartmentList, int employeeStatus)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText = string.Format(@"
select a.PKID,AccountSetID,AccountSetName,b.PKID as EmployeeID,c.EmployeeName,b.AccountID,DepartmentName,DepartmentId,PositionName,PositionId,EmployeeType  from TEmployee as b with(nolock)
left join TEmployeeAccountSet as a with(nolock) on a.EmployeeID=b.AccountID
inner join {0}.dbo.TAccount as c with(nolock) on b.AccountID=c.PKID
inner join {0}.dbo.TDepartment as d with(nolock) on d.PKID=c.DepartmentId
inner join {0}.dbo.TPosition as e with(nolock) on e.PKID=c.PositionId 
where EmployeeName like @EmployeeName 
", SqlHelper.SEPDBName);

                dataOperator.SetParameter("@EmployeeName", "%" + employeeName + "%", SqlDbType.NVarChar, 50);
                if (canOperateDepartmentList != null && canOperateDepartmentList.Count > 0)
                {
                    dataOperator.CommandText += " and DepartmentId in (" + string.Join(",", canOperateDepartmentList) + ")";
                }
                if (departmentID != null && departmentID.Count > 0)
                {
                    dataOperator.CommandText += " and DepartmentId in (" + string.Join(",", departmentID) + ")";
                }
                if (positionID != 0 && positionID != -1)
                {
                    dataOperator.CommandText += " and PositionId=@PositionId";
                    dataOperator.SetParameter("@PositionId", positionID, SqlDbType.Int);
                }
                if (employeeTypeEnum >= 0)
                {
                    dataOperator.CommandText += " and EmployeeType=@EmployeeType";
                    dataOperator.SetParameter("@EmployeeType", employeeTypeEnum, SqlDbType.Int);
                }
                //在职
                if (employeeStatus == 0)
                {
                    dataOperator.CommandText += " and ComeDate<=getdate() and (LeaveDate is null or LeaveDate > getdate())";
                }
                //离职
                else if (employeeStatus == 1)
                {
                    dataOperator.CommandText += " and LeaveDate<getdate()";
                }
                return dataOperator.ExecuteEntityList<EmployeeAccountSetEntity>();

            }

        }
    }
}


