using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Framework.Common.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.DataAccess
{
    public class AdjustRestDA
    {
        public static void InsertAdjustRest(AdjustRestEntity adjustRestEntity)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText = @"
INSERT INTO [dbo].[TAdjustRest](
	[AccountId],
	[Hours],
	[AdjustYear]
	) VALUES(
	@AccountId,
	@Hours,
	@AdjustYear)
    SELECT @@IDENTITY
";
                dataOperator.SetParameter("@AccountId", adjustRestEntity.AccountId, SqlDbType.Int);
                dataOperator.SetParameter("@Hours", adjustRestEntity.Hours, SqlDbType.Decimal, 25, 2);
                dataOperator.SetParameter("@AdjustYear", adjustRestEntity.AdjustYear, SqlDbType.DateTime);
                object obj = dataOperator.ExecuteScalar();
                int returnValue;
                int.TryParse(obj.ToString(), out returnValue);
                adjustRestEntity.PKID = returnValue;
            }
        }

        public static List<AdjustRestEntity> GetAdjustRestByCondition(string employeeName, List<int> departmentID,
            int positionID, int employeeTypeEnum, List<int> canOperateDepartmentList, int employeeStatus,int year)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText = string.Format(@"
select a.*,b.PKID as EmployeeID,b.ComeDate,c.EmployeeName,DepartmentName,DepartmentId,PositionName,PositionId,EmployeeType  from TEmployee as b with(nolock)
left join TAdjustRest as a with(nolock) on a.AccountID=b.AccountID
inner join {0}.dbo.TAccount as c with(nolock) on b.AccountID=c.PKID
inner join {0}.dbo.TDepartment as d with(nolock) on d.PKID=c.DepartmentId
inner join {0}.dbo.TPosition as e with(nolock) on e.PKID=c.PositionId 
where EmployeeName like @EmployeeName and a.AdjustYear>=@Year
", SqlHelper.SEPDBName);
                dataOperator.SetParameter("@Year", new DateTime(year,1,1), SqlDbType.DateTime);
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
                dataOperator.CommandText += "  order by b.AccountID,AdjustYear desc";
                return dataOperator.ExecuteEntityList<AdjustRestEntity>();

            }

        }
    }
}
