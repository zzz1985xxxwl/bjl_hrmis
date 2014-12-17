//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ILeaveRequestType.cs
// Creater:  Xue.wenlong
// Date:  2009-03-24
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILeaveRequestType
    {
        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="leaveRequestType"></param>
        /// <returns></returns>
        int InsertLeaveRequestType(LeaveRequestType leaveRequestType);

        /// <summary>
        /// �޸��������
        /// </summary>
        /// <param name="leaveRequestType"></param>
        void UpdateLeaveRequestType(LeaveRequestType leaveRequestType);

        /// <summary>
        /// ɾ���������
        /// </summary>
        /// <param name="leaveRequestTypeID"></param>
        void DeleteLeaveRequestType(int leaveRequestTypeID);

        /// <summary>
        /// ͨ��IDȡ���������
        /// </summary>
        /// <returns></returns>
        List<LeaveRequestType> GetAllLeaveRequestType();

        /// <summary>
        /// ͨ��IDȡ���������
        /// </summary>
        /// <param name="leaveTypeID"></param>
        /// <returns></returns>
        LeaveRequestType GetLeaveRequestTypeByPkid(int leaveTypeID);

        /// <summary>
        /// ͨ�����������
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        LeaveRequestType GetLeaveRequestTypeByName(string name);

        /// <summary>
        /// ͨ�����������
        /// </summary>
        /// <param name="namelike"></param>
        /// <returns></returns>
        List<LeaveRequestType> GetLeaveRequestTypeByNameLike(string namelike);
    }
}