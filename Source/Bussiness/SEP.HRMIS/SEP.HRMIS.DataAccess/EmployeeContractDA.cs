using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Framework.Common.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.DataAccess
{
    public class EmployeeContractDA
    {
        public static List<EmployeeContractEntity> GetEmployeeContractByCondition(string employeeName,DateTime stratTimeFrom, DateTime stratTimeTo, DateTime endTimeFrom,
            DateTime endTimeTo, List<int> canOperateDepartmentList, int contractTypeId,int employeeStatus)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText = string.Format(@"
select a.*,b.EmployeeName,c.CompanyID,d.DepartmentName as CompanyName,e.Name as ContractTypeName from TEmployeeContract as a with(nolock)
inner join {0}.dbo.TAccount as b with(nolock) on a.AccountID=b.PKID
inner join TEmployee as c with(nolock) on b.PKID=c.AccountID
inner join {0}.dbo.TDepartment as d on c.CompanyID=d.PKID
inner join TContractType as e on a.ContractTypeID=e.PKID
where EmployeeName like @EmployeeName and StartDate>=@StratTimeFrom and StartDate<=@StratTimeTo and EndDate>=@EndTimeFrom and EndDate<=@EndTimeTo
", SqlHelper.SEPDBName);

                dataOperator.SetParameter("@EmployeeName", "%" + employeeName + "%", SqlDbType.NVarChar, 50);
                dataOperator.SetParameter("@StratTimeFrom", stratTimeFrom, SqlDbType.DateTime);
                dataOperator.SetParameter("@StratTimeTo", stratTimeTo, SqlDbType.DateTime);
                dataOperator.SetParameter("@EndTimeFrom", endTimeFrom, SqlDbType.DateTime);
                dataOperator.SetParameter("@EndTimeTo", endTimeTo, SqlDbType.DateTime);
                if (canOperateDepartmentList != null && canOperateDepartmentList.Count > 0)
                {
                    dataOperator.CommandText += " and DepartmentId in (" + string.Join(",", canOperateDepartmentList) + ")";
                }
                if (contractTypeId > 0)
                {
                    dataOperator.CommandText += " and ContractTypeId=@ContractTypeId";
                    dataOperator.SetParameter("@ContractTypeId", contractTypeId, SqlDbType.Int);
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
                dataOperator.CommandText += " order by a.PKID desc";
                return dataOperator.ExecuteEntityList<EmployeeContractEntity>();

            }

        }
    }
}


