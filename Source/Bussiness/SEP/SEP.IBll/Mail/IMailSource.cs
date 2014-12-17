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
        /// ��ȡHR���ŵ��ܼ��Mail��ַ
        /// </summary>
        /// <returns></returns>
        string GetHrLeaderMail();

        /// <summary>
        /// ��ȡHR���ŵ��ܼ�ĵڶ���Mail��ַ
        /// </summary>
        /// <returns></returns>
        string GetHrLeaderMail2();

        /// <summary>
        /// ��ȡ�������������ǵ�Mail��ַ
        /// </summary>
        /// <returns></returns>
        List<string> GetHrAssistantMails();

        /// <summary>
        /// ��ȡ��������רԱ�ǵ�Mail��ַ
        /// </summary>
        /// <returns></returns>
        List<string> GetHrCommissionerMails();

        /// <summary>
        /// ��ȡHR���������ǵ�Mail��ַ
        /// </summary>
        /// <returns></returns>
        List<string> GetHrManagerMails();

        /// <summary>
        /// ��ȡCeo��Mail��ַ
        /// </summary>
        /// <returns></returns>
        string GetCeoMail();

        /// <summary>
        /// ��ȡCeo�ĵڶ���Mail��ַ
        /// </summary>
        /// <returns></returns>
        string GetCeoMail2();

        ///// <summary>
        ///// ��ȡԱ���������ŵ��ܼ��Mail��ַ
        ///// </summary>
        ///// <param name="empId"></param>
        ///// <returns></returns>
        //string GetDirectMail(int empId);

        ///// <summary>
        ///// ��ȡԱ���������ŵ��ܼ�ĵڶ���Mail��ַ
        ///// </summary>
        ///// <param name="empId"></param>
        ///// <returns></returns>
        //string GetDirectMail2(int empId);

        /// <summary>
        /// ��ȡԱ�����ܵ�Mail��ַ
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        string GetManagerMail(int empId);

        /// <summary>
        /// ��ȡԱ�����ܵĵڶ���Mail��ַ
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        string GetManagerMail2(int empId);

        /// <summary>
        /// ��ȡԱ����Mail��ַ
        /// </summary>
        /// <param name="empName"></param>
        /// <returns></returns>
        string GetEmployeeMailByName(string empName);

        /// <summary>
        /// ��ȡԱ���ĵڶ�Mail��ַs
        /// </summary>
        /// <param name="empName"></param>
        /// <returns></returns>
        string GetEmployeeMailByName2(string empName);
    }
}