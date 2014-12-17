//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: RequestFindOperator.cs
// Creater:  Xue.wenlong
// Date:  2009-05-13
// Resume:
// ---------------------------------------------------------------

using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.Bll.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestFindOperator
    {
        private readonly IDepartmentBll _DepartmentBll = BllInstance.DepartmentBllInstance;
        private readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;


        /// <summary>
        /// 
        /// </summary>
        public Account GetNextOperator(DiyProcess diyProcess, int nowStep, int accountId)
        {
            if (nowStep == -1)
            {
                return null;
            }
            Account retAccount;
            if (nowStep >= diyProcess.DiySteps.Count)
            {
                return null;
            }
            DiyStep diystep = diyProcess.DiySteps[nowStep - 1];
            if (diystep.OperatorID > 0)
            {
                retAccount = _AccountBll.GetAccountById(diystep.OperatorID);
            }
            else
            {
                retAccount = GetAccountByOperatorType(diystep.OperatorType, accountId);
            }
            return retAccount;
        }


        /// <summary> 
        /// </summary>
        public int GetNextStep(int step, DiyProcess diyprocess)
        {
            DiyProcess diyProcess = diyprocess;
            if (step >= diyProcess.DiySteps.Count)
            {
                step = -1;
            }
            return step;
        }


        //private Department GetDepartment(int deptID, int deep)
        //{
        //    Department department = _DepartmentBll.GetParentDept(deptID, null);
        //    if (department == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        if (deep == OperatorType.ParentDepartmentLeader.Id)
        //        {
        //            return department;
        //        }
        //        else
        //        {
        //            return GetDepartment(department.Id, --deep);
        //        }
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        private Account GetAccountByOperatorType(ParameterBase operatortype, int accountid)
        {
            if (operatortype.Id == OperatorType.YourSelf.Id)
            {
                return _AccountBll.GetAccountById(accountid);
            }
            else if (operatortype.Id == OperatorType.DepartmentLeader.Id)
            {
                return _AccountBll.GetLeaderByAccountId(accountid);
            }
            else if (operatortype.Id == OperatorType.ParentDepartmentLeader.Id)
            {
                Account account2 = _AccountBll.GetAccountById(accountid);
                return _DepartmentBll.GetParentDept(account2.Dept.Id, null).Leader;
            }
            else if (operatortype.Id == OperatorType.GrandDepartmentLeader.Id)
            {
                Account account3 = _AccountBll.GetAccountById(accountid);
                Department department3 = _DepartmentBll.GetParentDept(account3.Dept.Id, null);
                return _DepartmentBll.GetParentDept(department3.Id, null).Leader;
            }
            else if (operatortype.Id == OperatorType.GrandGrandDepartmentLeader.Id)
            {
                Account account4 = _AccountBll.GetAccountById(accountid);
                Department department4 = _DepartmentBll.GetParentDept(account4.Dept.Id, null);
                department4 = _DepartmentBll.GetParentDept(department4.Id, null);
                return _DepartmentBll.GetParentDept(department4.Id, null).Leader;
            }
            else if (operatortype.Id == OperatorType.GrandGrandGrandDepartmentLeader.Id)
            {
                Account account5 = _AccountBll.GetAccountById(accountid);
                Department department5 = _DepartmentBll.GetParentDept(account5.Dept.Id, null);
                department5 = _DepartmentBll.GetParentDept(department5.Id, null);
                department5 = _DepartmentBll.GetParentDept(department5.Id, null);
                return _DepartmentBll.GetParentDept(department5.Id, null).Leader;
            }
            else
            {
                return null;
            }
        }
    }
}