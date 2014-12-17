//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IMailSource.cs
// Creater:  Xue.wenlong
// Date:  2009-03-26
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;

namespace SEP.IBll.Mail
{
    public interface IMailSource
    {
        /// <summary>
        /// 获取HR部门的总监的Mail地址
        /// </summary>
        /// <returns></returns>
        string GetHrLeaderMail();

        /// <summary>
        /// 获取HR部门的总监的第二个Mail地址
        /// </summary>
        /// <returns></returns>
        string GetHrLeaderMail2();

        /// <summary>
        /// 获取行政人事助理们的Mail地址
        /// </summary>
        /// <returns></returns>
        List<string> GetHrAssistantMails();

        /// <summary>
        /// 获取行政人事专员们的Mail地址
        /// </summary>
        /// <returns></returns>
        List<string> GetHrCommissionerMails();

        /// <summary>
        /// 获取HR部门主管们的Mail地址
        /// </summary>
        /// <returns></returns>
        List<string> GetHrManagerMails();

        /// <summary>
        /// 获取Ceo的Mail地址
        /// </summary>
        /// <returns></returns>
        string GetCeoMail();

        /// <summary>
        /// 获取Ceo的第二个Mail地址
        /// </summary>
        /// <returns></returns>
        string GetCeoMail2();

        ///// <summary>
        ///// 获取员工所属部门的总监的Mail地址
        ///// </summary>
        ///// <param name="empId"></param>
        ///// <returns></returns>
        //string GetDirectMail(int empId);

        ///// <summary>
        ///// 获取员工所属部门的总监的第二个Mail地址
        ///// </summary>
        ///// <param name="empId"></param>
        ///// <returns></returns>
        //string GetDirectMail2(int empId);

        /// <summary>
        /// 获取员工主管的Mail地址
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        string GetManagerMail(int empId);

        /// <summary>
        /// 获取员工主管的第二个Mail地址
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        string GetManagerMail2(int empId);

        /// <summary>
        /// 获取员工的Mail地址
        /// </summary>
        /// <param name="empName"></param>
        /// <returns></returns>
        string GetEmployeeMailByName(string empName);

        /// <summary>
        /// 获取员工的第二Mail地址s
        /// </summary>
        /// <param name="empName"></param>
        /// <returns></returns>
        string GetEmployeeMailByName2(string empName);
    }
}