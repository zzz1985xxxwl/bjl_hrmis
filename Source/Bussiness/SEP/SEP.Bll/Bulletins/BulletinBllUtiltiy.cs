//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: BulletinBllUtiltiy.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-18
// Resume: 
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.Model.Bulletins;
using SEP.Model.Departments;

namespace SEP.Bll.Bulletins
{
    public class BulletinBllUtiltiy
    {
        private readonly DepartmentBll _DepartmentBll = new DepartmentBll();
        private List<Department> _Paredepartments;
        private bool _IncludePare = true;

        public List<Bulletin> CleanByDepartment(List<Bulletin> bulletinList, int departmentid)
        {
            if (departmentid <= 0||bulletinList==null)
            {
                return bulletinList;
            }
            List<int> departmentids = GetPareAndChildDpartmentID(departmentid);
            List<Bulletin> retBulletins = new List<Bulletin>();
            foreach (Bulletin bulletin in bulletinList)
            {
                if (departmentids.Contains(bulletin.Dept.Id))
                {
                    retBulletins.Add(bulletin);
                }
            }
            return retBulletins;
        }

        public List<Bulletin> CleanByDepartmentOnlyChild(List<Bulletin> bulletinList, int departmentid)
        {
            _IncludePare = false;
            return CleanByDepartment(bulletinList, departmentid);
        }



        private List<int> GetPareAndChildDpartmentID(int departmentid)
        {
            List<int> departids = new List<int>();
            departids.Add(departmentid); //把自己的id加进去
            if (_IncludePare)
            {
                List<Department> PareDepartment = GetPareDepartmentList(departmentid);
                foreach (Department department in PareDepartment)
                {
                    departids.Add(department.Id); //添加父部门id
                }
            }

            List<Department> childdepartment = _DepartmentBll.GetChildDeptList(departmentid);
            foreach (Department department in childdepartment)
            {
                departids.Add(department.Id); //添加子部门id
            }
            //清理重复id
            List<int> retid = new List<int>();
            foreach (int i in departids)
            {
                if (!retid.Contains(i))
                {
                    retid.Add(i);
                }
            }
            return retid;
        }


        private List<Department> GetPareDepartmentList(int departmentid)
        {
            _Paredepartments = new List<Department>();
            GetPareDepartment(departmentid);
            return _Paredepartments;
        }

        private void GetPareDepartment(int departmentid)
        {
            Department paredept = _DepartmentBll.GetParentDept(departmentid, null);
            if (paredept != null)
            {
                _Paredepartments.Add(paredept);
                GetPareDepartment(paredept.Id);
            }
        }
    }
}