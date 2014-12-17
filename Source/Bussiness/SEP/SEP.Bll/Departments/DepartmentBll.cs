
using System;
using System.Collections.Generic;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Bll.Departments;
using SEP.IDal;
using SEP.Model.Utility;
using SEP.IDal.Departments;

namespace SEP.Bll
{
    internal class DepartmentBll : IDepartmentBll
    {
        #region IDepartmentBll ��Ա

        public void CreateDept(Department dept, Account loginUser)
        {
            AddDepartment addDepartment = new AddDepartment(null, dept, loginUser);
            addDepartment.Excute();
        }

        public int CreateDept(int parentId,Department dept, Account loginUser)
        {
            AddDepartment addDepartment = new AddDepartment(parentId, dept, loginUser);
            addDepartment.Excute();
            return addDepartment.DepartmentID;
        }

        public void UpdateDept(Department dept, Account loginUser)
        {
            UpdateDepartment updateDepartment = new UpdateDepartment(null, dept, loginUser);
            updateDepartment.Excute();
        }

        public void UpdateDept(int parentId, Department dept, Account loginUser)
        {
            UpdateDepartment updateDepartment = new UpdateDepartment(parentId, dept, loginUser);
            updateDepartment.Excute();
        }

        public void DeleteDept(int deptId, Account loginUser)
        {
            DeleteDepartment deleteDepartment = new DeleteDepartment(deptId, loginUser);
            deleteDepartment.Excute();
        }

        public List<Department> GetAllDepartmentOrderName()
        {
            return DalInstance.DeptDalInstance.GetAllDepartmentOrderName();
        }
        public List<Department> GetAllDepartment(Account loginUser)
        {
            return DalInstance.DeptDalInstance.GetAllDepartment();
        }

        public List<Department> GetAllDepartmentTree(Account loginUser)
        {
            return DalInstance.DeptDalInstance.GetDepartmentTree();
        }

        public Department GetDepartmentById(int id, Account loginUser)
        {
            Department department = DalInstance.DeptDalInstance.GetDepartmentById(id);
            if (department != null)
            {
                department.Members = DalInstance.AccountDalInstance.GetAccountByCondition(String.Empty, id, null,null, null);
                department.Leader = DalInstance.AccountDalInstance.GetAccountById(department.Leader.Id);
            }
            return department;
        }


        public List<Department> GetDepartmentByNameString(string sendDepartment, out string errorname)
        {
            IDepartmentDal iDepartmentDal = DalInstance.DeptDalInstance;
            errorname = string.Empty;
            List<Department> retDepartments = new List<Department>();

            sendDepartment = sendDepartment.Trim();
            sendDepartment = sendDepartment.TrimStart('��');
            sendDepartment = sendDepartment.TrimEnd('��');
            //sendDepartment = sendDepartment.Replace('��', '(');
            //sendDepartment = sendDepartment.Replace('��', ')');
            sendDepartment = sendDepartment.Replace('��', ';');
            string[] departments = sendDepartment.Split(';');
            for (int i = 0; i < departments.Length; i++)
            {
                departments[i] = departments[i].Trim();

                Department department = iDepartmentDal.GetDepartmentByName(departments[i]);
                if (department == null)
                {
                    errorname += string.IsNullOrEmpty(errorname) ? departments[i] : "��" + departments[i];
                }
                else
                {
                    if (Department.FindDepartment(retDepartments, department.Id) == null)
                    {
                        department = iDepartmentDal.GetDepartmentById(department.Id);
                        retDepartments.Add(department);
                    }
                }
            }
            return retDepartments;
        }
        public List<Department> GetManageDepts(int leaderId, Account loginUser)
        {
            return DalInstance.DeptDalInstance.GetDepartmentByLeaderId(leaderId);
        }

        public Department GetDept(int employeeId, Account loginUser)
        {
            return DalInstance.DeptDalInstance.GetDepartmentByEmployeeId(employeeId);
        }

        public Department GetParentDept(int deptId, Account loginUser)
        {
            return DalInstance.DeptDalInstance.GetParentDepartment(deptId);
        }


        public List<Department> GetManageDepts(int leaderId)
        {
            return DalInstance.DeptDalInstance.GetDepartmentByLeaderId(leaderId);
        }

        /// <summary>
        /// ��ȡEmployeeID�����漰���Ĳ��ţ�����EmployeeID���ڲ��š�����Ĳ����Լ�����Ĳ����µ��Ӳ���
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public List<Department> GetDepartmentEmployeeInvolve(int employeeID)
        {
            List<Department> depts = new List<Department>();

            List<Department> myManageDepts = DalInstance.DeptDalInstance.GetDepartmentByLeaderId(employeeID);
            if (myManageDepts != null && myManageDepts.Count != 0)
            {
                for (int i = 0; i < myManageDepts.Count; i++)
                {
                    myManageDepts[i] = DalInstance.DeptDalInstance.GetDepartmentById(myManageDepts[i].Id);
                }
            }

            depts.AddRange(DeptTreeToList(myManageDepts));

            Department myDept = DalInstance.DeptDalInstance.GetDepartmentByEmployeeId(employeeID);
            if (!ContainsDept(depts, myDept))
                depts.Add(myDept);

            return depts;
        }

        /// <summary>
        /// ��ǰԱ���Ƿ���Department����������Ĳ��ŵ��Ӳ�����Department
        /// </summary>
        /// <param name="departmentid"></param>
        /// <param name="employeeid"></param>
        /// <returns>�ǣ�true����false</returns>
        public bool IsDepartmentManagedByEmployee(int departmentid, int employeeid)
        {
            List<Department> depts = GetDepartmentAndChildrenDeptByLeaderID(employeeid);
            for (int i = 0; i < depts.Count; i++)
            {
                if (departmentid == depts[i].DepartmentID)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// ��ȡ��ǰԱ����������в��ţ���������Ĳ��ŵ�������������Ĳ���
        /// </summary>
        /// <param name="leaderID"></param>
        /// <returns></returns>
        public List<Department> GetDepartmentAndChildrenDeptByLeaderID(int leaderID)
        {
            List<Department> retDepts = new List<Department>();
            List<Department> departmentByLeaderID = DalInstance.DeptDalInstance.GetDepartmentByLeaderId(leaderID);
            retDepts.AddRange(departmentByLeaderID);
            foreach (Department department in departmentByLeaderID)
            {
                retDepts.AddRange(GetChildDeptList(department.DepartmentID));
            }
            Tools.RemoveDuplicatedDeptData(retDepts);
            return retDepts;
        }        
      

        public List<Department> GetAllDepartment()
        {
            return DalInstance.DeptDalInstance.GetAllDepartment();
        }

        public List<Department> GetAllDepartmentTree()
        {
            return DalInstance.DeptDalInstance.GetDepartmentTree();
        }

        /// <summary>
        /// �ݹ��ȡ�����Ӳ���
        /// </summary>
        public List<Department> GetChildDeptList(int deptId)
        {
            Department dept = DalInstance.DeptDalInstance.GetDepartmentById(deptId);
            List<Department> childs = new List<Department>();
            foreach (Department department in dept.ChildDept)
            {
                DeptToList(childs, department);
            }
            return childs;
        }

        /// <summary>
        /// ��ղ���������
        /// </summary>
        public void ClearCache()
        {
            DalInstance.DeptDalInstance.ClearCache();
        }
        //add by wsl
        /// <summary>
        /// ����ɢ��deptList�����Դ���С���ڵ��г�����������ṹ
        /// </summary>
        /// <param name="deptList"></param>
        /// <returns></returns>
        public List<Department> GenerateDeptListWithLittleParentDept(List<Department> deptList)
        {
            List<Department> allDept = GetAllDepartmentTree();
            RemoveNotContainDepartment(allDept, deptList);
            List<Department> retDeptList = TurnDepartmentTreeToListWithLittleParentDept(deptList, allDept, new List<Department>());
            ClearCache();
            return retDeptList;
        }

        private static List<Department> TurnDepartmentTreeToListWithLittleParentDept(List<Department> oldDeptList, List<Department> deptList, List<Department> retdeptList)
        {
            for (int i = 0; i < deptList.Count; i++)
            {
                if (deptList[i].ChildDept.Count > 1 || ContainsDept(oldDeptList, deptList[i]))
                {
                    retdeptList.Add(deptList[i]);
                }
                retdeptList =
                    TurnDepartmentTreeToListWithLittleParentDept(oldDeptList, deptList[i].ChildDept, retdeptList);
            }
            return retdeptList;
        }

        private static void RemoveNotContainDepartment(List<Department> allDept, List<Department> deptList)
        {
            for (int i = 0; i < allDept.Count; i++)
            {
                RemoveNotContainDepartment(allDept[i].ChildDept, deptList);
                bool isContain = false;
                for (int j = 0; j < deptList.Count; j++)
                {
                    if (allDept[i].IsExistDept(deptList[j].Id))
                    {
                        isContain = true;
                    }
                }
                if (!isContain)
                {
                    allDept.RemoveAt(i);
                    i--;
                }
            }
        }

        /// <summary>
        /// ����deptList1,deptList2�Ľ���
        /// </summary>
        /// <param name="deptList1"></param>
        /// <param name="deptList2"></param>
        /// <returns></returns>
        public List<Department> MixDepartmentList(List<Department> deptList1, List<Department> deptList2)
        {
            List<Department> retDeptList = new List<Department>();
            foreach (Department deptInDeptList1 in deptList1)
            {
                if (ContainsDept(deptList2, deptInDeptList1))
                {
                    retDeptList.Add(deptInDeptList1);
                }
            }
            return retDeptList;
        }
        #endregion

        private List<Department> DeptTreeToList(List<Department> deptTree)
        {
            if (deptTree == null)
                throw new ArgumentNullException("deptTree");

            List<Department> depts = new List<Department>();

            foreach (Department department in deptTree)
            {
                DeptToList(depts, department);
            }

            return depts;
        }

        private static void DeptToList(List<Department> list, Department dept)
        {
            if(list == null)
                throw new ArgumentNullException("list");

            if (dept.HasChild)
            {
                foreach (Department department in dept.ChildDept)
                {
                    DeptToList(list, department);
                }
            }

            Department temp = new Department();
            temp.Id = dept.Id;
            temp.Name = dept.Name;
            temp.Leader = dept.Leader;

            if (!ContainsDept(list, temp))
                list.Add(temp);
        }

        private static bool ContainsDept(List<Department> list, Department dept)
        {
            bool temp = false;

            foreach (Department item in list)
            {
                temp = item.Id == dept.Id;
                if (temp)
                    break;
            }

            return temp;
        }
    }
}
