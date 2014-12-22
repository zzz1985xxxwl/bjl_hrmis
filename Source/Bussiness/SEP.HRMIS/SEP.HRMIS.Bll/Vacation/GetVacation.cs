//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetVacation.cs
// 创建者: 薛文龙
// 创建日期: 2008-05-21
// 概述: 查询年假
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 
    /// </summary>
    public class GetVacation
    {
        private readonly IVacation _dal = new VacationDal();
        private readonly GetEmployee GetEmployee = new GetEmployee();

        /// <summary>
        /// 
        /// </summary>
        public GetVacation()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mockVacation"></param>
        public GetVacation(IVacation mockVacation)
        {
            _dal = mockVacation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Vacation> GetAllVacation()
        {
            return _dal.GetAllVacation();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Vacation> GetVacationByCondition(string employeeName, decimal vacationDayNumStart,
                                                     decimal vacationDayNumEnd,
                                                     DateTime vacationEndDateStart, DateTime vacationEndDateEnd,
                                                     decimal SurplusDayNumStart, decimal surplusDayNumEnd,
                                                     Account Operator, int employeeStatus)
        {
            //List<Vacation> vacationList =
            //    _dal.GetVacationByCondition(employeeName, vacationDayNumStart, vacationDayNumEnd,
            //                                vacationEndDateStart, vacationEndDateEnd,
            //                                SurplusDayNumStart, surplusDayNumEnd);
            //for (int i = 0; i < vacationList.Count; i++)
            //{
            //    vacationList[i].Employee = GetEmployee.GetEmployeeBasicInfoByAccountID(vacationList[i].Employee.Account.Id);

            //    if (vacationList[i].Employee.Account == null
            //        || !vacationList[i].Employee.IsNeedEmployeeStatusCondition(employeeStatus))
            //    {
            //        vacationList.RemoveAt(i);
            //        i--;
            //    }
            //}
            //vacationList = HrmisUtility.RemoteUnAuthVacation(vacationList, AuthType.HRMIS, Operator, HrmisPowers.A403);
            List<Vacation> vacationList = new List<Vacation>();
            var list = VacationLogic.GetVacationByCondition(employeeName, vacationDayNumStart,
                                                     vacationDayNumEnd,
                                                     vacationEndDateStart, vacationEndDateEnd,
                                                     SurplusDayNumStart, surplusDayNumEnd,
                                                     Operator, employeeStatus);
            foreach (var e in list)
            {
                vacationList.Add(new Vacation
                                     {
                                         Employee = new Employee { Account = new Account(e.AccountID, "", e.EmployeeName) },
                                         Remark = e.Remark,
                                         SurplusDayNum = e.SurplusDayNum,
                                         UsedDayNum = e.UsedDayNum,
                                         VacationDayNum = e.VacationDayNum,
                                         VacationEndDate = e.VacationEndDate,
                                         VacationID = e.PKID,
                                         VacationStartDate = e.VacationStartDate
                                     });
            }
            return vacationList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public List<Vacation> GetVacationByAccountID(int employeeID)
        {
            return _dal.GetVacationByAccountID(employeeID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public Vacation GetLastVacationByAccountID(int employeeID)
        {
            Vacation vacation = _dal.GetLastVacationByAccountID(employeeID);
            if (vacation != null)
            {
                vacation.SurplusDayNum = GetAvaliableVacation(employeeID);
            }
            return vacation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        private decimal GetAvaliableVacation(int employeeID)
        {
            decimal ret = 0;
            DateTime dt = DateTime.Now;
            List<Vacation> vacationList = new List<Vacation>();
            List<Vacation> _vacationList = _dal.GetVacationByAccountID(employeeID);
            Vacation _LastVacation = null;
            Vacation _SecondLastVacation = null;
            foreach (Vacation vacation in _vacationList)
            {
                if (vacation.VacationStartDate <= dt)
                {
                    vacationList.Add(vacation);
                }
            }
            if (vacationList.Count > 0)
            {
                Vacation vacation = new Vacation();
                SortList<Vacation> sortList =
                    new SortList<Vacation>(vacation, "VacationEndDate", ReverserInfo.Direction.DESC);
                vacationList.Sort(sortList);
                _LastVacation = vacationList[0];
                if (vacationList.Count > 1)
                {
                    _SecondLastVacation = vacationList[1];
                }
            }
            if (_LastVacation != null)
            {
                ret += _LastVacation.SurplusDayNum;
                if (_SecondLastVacation != null)
                {
                    if (dt.Date <= _SecondLastVacation.VacationEndDate.AddMonths(4).Date)
                    {
                        ret += _SecondLastVacation.SurplusDayNum;
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vacationID"></param>
        /// <returns></returns>
        public Vacation GetVacationByVacationID(int vacationID)
        {
            return _dal.GetVacationByVacationID(vacationID);
        }
    }
}