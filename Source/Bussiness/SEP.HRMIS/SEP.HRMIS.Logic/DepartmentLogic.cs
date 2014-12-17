using System.Collections.Generic;
using System.Linq;
using Framework.Common;
using SEP.HRMIS.DataAccess;
using SEP.HRMIS.Entity;
using SEP.Model.Departments;

namespace SEP.HRMIS.Logic
{
    public class DepartmentLogic
    {
        public static List<Department> GetCompanyByAccountAuth(int accountId, int authID)
        {
            return DepartmentDA.GetCompanyByAccountAuth(accountId, authID).Select(DepartmentEntity.Convert).ToList();
        }

        public static List<Department> GetDepartmentByCompanyID(int companyID)
        {
            return DepartmentDA.GetDepartmentByCompanyID(companyID).Select(DepartmentEntity.Convert).ToList();
        }

        public static List<DepartmentEntity> GetAllDepartment()
        {
            var key = "GetAllDepartmentEntity";
            var all = MemoryCacheUtils.Get(key) as List<DepartmentEntity>;
            if (all == null)
            {
                all = DepartmentDA.GetAllDepartment();
                MemoryCacheUtils.Set(key, all);
            }
            return all;
        }

        public static List<DepartmentEntity> GetChildDepartment(int parentID)
        {
            var all = GetAllDepartment();
            var list = new List<DepartmentEntity>();
            GetChildDepartment(all, list, parentID);
            return list;
        }

        public static List<int> GetDepartmentids(int departmentID, bool recursionDepartment)
        {
            var departmentids = new List<int>();
            if (departmentID > 0)
            {
                departmentids.Add(departmentID);
                if (recursionDepartment)
                {
                    departmentids.AddRange(GetChildDepartment(departmentID).Select(x => x.PKID));
                }
            }
            return departmentids;
        }

        private static void GetChildDepartment(List<DepartmentEntity> all, List<DepartmentEntity> child, int parentID)
        {
            foreach (var departmentEntity in all)
            {
                if (departmentEntity.ParentId == parentID)
                {
                    child.Add(departmentEntity);
                    GetChildDepartment(all, child, departmentEntity.PKID);
                }
            }
        }
    }
}