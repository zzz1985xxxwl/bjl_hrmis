using System.Collections.Generic;
using System.Data;
using Framework.Common.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.DataAccess
{
    public class DepartmentDA
    {
        public static List<DepartmentEntity> GetCompanyByAccountAuth(int accountId, int authID)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    @"
if exists (select DepartmentID from TAccountAuth with(nolock) where AccountId=@AccountId and AuthId=@AuthID and DepartmentID>0)
begin 
select PKID,DepartmentName,LeaderId,ParentId
from " +
                    SqlHelper.SEPDBName +
                    @".dbo.TDepartment with(nolock) 
where PKID in(
select DepartmentID from TAccountAuth with(nolock) where AccountId=@AccountId and AuthId=@AuthID
) and PKID in (select CompanyID from TEmployee)
end
else
select PKID,DepartmentName,LeaderId,ParentId
from " +
                    SqlHelper.SEPDBName +
                    @".dbo.TDepartment with(nolock) 
where PKID in (select CompanyID from TEmployee)
";
                dataOperator.SetParameter("@AccountId", accountId, SqlDbType.Int);
                dataOperator.SetParameter("@AuthID", authID, SqlDbType.Int);
                return dataOperator.ExecuteEntityList<DepartmentEntity>();
            }
        }

        public static List<DepartmentEntity> GetDepartmentByCompanyID(int companyID)
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.SEPConnectionString))
            {
                dataOperator.CommandText =
                    @"
select PKID,DepartmentName,LeaderId,ParentId
from TDepartment with(nolock) 
where PKID in (
select DepartmentID from TAccount where
PKID in (select AccountID from " + SqlHelper.HrmisDBName + @".dbo.TEmployee where CompanyID=@CompanyID)
)
";
                dataOperator.SetParameter("@CompanyID", companyID, SqlDbType.Int);
                return dataOperator.ExecuteEntityList<DepartmentEntity>();
            }
        }

        public static List<DepartmentEntity> GetAllDepartment()
        {
            using (DataOperator dataOperator = new DataOperator(SqlHelper.SEPConnectionString))
            {
                dataOperator.CommandText =
                    @"
select PKID,DepartmentName,LeaderId,ParentId
from TDepartment with(nolock) 
";
                return dataOperator.ExecuteEntityList<DepartmentEntity>();
            }
        }

    }
}