//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: JudgeProbation.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-12
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Bll.LeaveRequests
{
    /// <summary>
    /// 判断是否在试用期，试用期无法申请年假
    /// </summary>
    public class JudgeProbation : Transaction
    {
        private readonly List<LeaveRequestItem> _ItemList = new List<LeaveRequestItem>();
        private readonly Employee _Employee;
        private readonly LeaveRequestType _Type;
        private static IEmployee _DalEmployee;

        /// <summary>
        /// 
        /// </summary>
        public JudgeProbation(List<LeaveRequestItem> itemList, int AccountID, LeaveRequestType type,
                              IEmployee dalEmployee)
        {
            _DalEmployee = dalEmployee;
            _ItemList = itemList;
            _Type = type;
            _Employee = _DalEmployee.GetEmployeeByAccountID(AccountID);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Validation()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ExcuteSelf()
        {
            if (_Type.LeaveRequestTypeID == (int) LeaveRequestTypeEnum.AnnualLeave)
            {
                if (_Employee.EmployeeType == EmployeeTypeEnum.ProbationEmployee ||
                    _Employee.EmployeeType == EmployeeTypeEnum.NormalEmployee)
                {
                    try
                    {
                        foreach (LeaveRequestItem item in _ItemList)
                        {
                            if (item.FromDate < _Employee.EmployeeDetails.ProbationTime.Date.AddDays(1))
                            {
                                throw new Exception();
                            }
                        }
                    }
                    catch
                    {
                        HrmisUtility.ThrowException("试用期期间无法请年假");
                    }
                }
            }
        }

    }
}