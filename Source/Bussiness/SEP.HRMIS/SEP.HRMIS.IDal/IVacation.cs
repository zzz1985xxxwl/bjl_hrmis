//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IVacation.cs
// 创建者: 薛文龙
// 创建日期: 2008-05-20
// 概述: vacation 接口
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// Interface for the Vacation Dal
    /// </summary>
    public interface IVacation
    {
        /// <summary>
        /// 插入年假信息
        /// </summary>
        /// <param name="vacation"></param>
        /// <returns>PKID</returns>
        int Insert(Vacation vacation);
        /// <summary>
        /// 更新年假
        /// </summary>
        /// <param name="vacation"></param>
        /// <returns></returns>
        int Update(Vacation vacation);
        /// <summary>
        /// 通过员工ID查找年假数量
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        int CountVacationByAccountID(int accountID);
        /// <summary>
        /// 通过员工ID删除年假
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        int DeleteVacationByAccountID(int accountID);
        /// <summary>
        /// 通过年假ID删除年假
        /// </summary>
        /// <param name="vacationID"></param>
        /// <returns></returns>
        int DeleteVacationByVacationID(int vacationID);
        /// <summary>
        /// 通过员工ID查找年假
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<Vacation> GetVacationByAccountID(int accountID);
        /// <summary>
        /// 查找所有年假
        /// </summary>
        /// <returns></returns>
        List<Vacation> GetAllVacation();
        /// <summary>
        /// 通过条件查询年假
        /// </summary>
        /// <param name="employeeName">员工姓名</param>
        /// <param name="vacationDayNumStart">年假总天数上限范围</param>
        /// <param name="vacationDayNumEnd">年假总天数下限范围</param>
        /// <param name="vacationEndDateStart">年假到期时间上限范围</param>
        /// <param name="vacationEndDateEnd">年假到期时间下限范围</param>
        /// <param name="surplusDayNumStart">年假剩余时间上限范围</param>
        /// <param name="surplusDayNumEnd">年假剩余时间下限范围<</param>
        /// <returns></returns>
        List<Vacation> GetVacationByCondition(string employeeName, decimal vacationDayNumStart,
                                              decimal vacationDayNumEnd,
                                              DateTime vacationEndDateStart, DateTime vacationEndDateEnd,
                                              decimal surplusDayNumStart, decimal surplusDayNumEnd);
        /// <summary>
        /// 获得员工最新的年假信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Vacation GetLastVacationByAccountID(int accountID);
        /// <summary>
        /// 通过年假ID查找年假
        /// </summary>
        /// <param name="vacationID"></param>
        /// <returns></returns>
        Vacation GetVacationByVacationID(int vacationID);

        ///<summary>
        /// 获得某个员工，某个时间点以后的最近的一条年假信息
        ///</summary>
        ///<param name="accountID"></param>
        ///<param name="time"></param>
        ///<returns></returns>
        Vacation GetNearVacationByAccountIDAndTime(int accountID, DateTime time);
        /// <summary>
        /// 获得某个员工在一段时期内相关的年假信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="startDt"></param>
        /// <param name="endDt"></param>
        /// <returns></returns>
        List<Vacation> GetVacationByAccountIDAndTimeSpan(int accountID, DateTime startDt, DateTime endDt);
    }
}
