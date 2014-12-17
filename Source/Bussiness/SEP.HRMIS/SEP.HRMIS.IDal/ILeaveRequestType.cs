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
        /// 添加请假类型
        /// </summary>
        /// <param name="leaveRequestType"></param>
        /// <returns></returns>
        int InsertLeaveRequestType(LeaveRequestType leaveRequestType);

        /// <summary>
        /// 修改请假类型
        /// </summary>
        /// <param name="leaveRequestType"></param>
        void UpdateLeaveRequestType(LeaveRequestType leaveRequestType);

        /// <summary>
        /// 删除请假类型
        /// </summary>
        /// <param name="leaveRequestTypeID"></param>
        void DeleteLeaveRequestType(int leaveRequestTypeID);

        /// <summary>
        /// 通过ID取得请假类型
        /// </summary>
        /// <returns></returns>
        List<LeaveRequestType> GetAllLeaveRequestType();

        /// <summary>
        /// 通过ID取得请假类型
        /// </summary>
        /// <param name="leaveTypeID"></param>
        /// <returns></returns>
        LeaveRequestType GetLeaveRequestTypeByPkid(int leaveTypeID);

        /// <summary>
        /// 通过名字找请假
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        LeaveRequestType GetLeaveRequestTypeByName(string name);

        /// <summary>
        /// 通过名字找请假
        /// </summary>
        /// <param name="namelike"></param>
        /// <returns></returns>
        List<LeaveRequestType> GetLeaveRequestTypeByNameLike(string namelike);
    }
}