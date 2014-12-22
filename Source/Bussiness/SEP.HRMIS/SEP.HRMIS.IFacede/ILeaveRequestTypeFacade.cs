//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ILeaveRequestTypeFacade.cs
// Creater:  Xue.wenlong
// Date:  2009-03-24
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILeaveRequestTypeFacade
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestType"></param>
        void AddLeaveRequestType(LeaveRequestType leaveRequestType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestType"></param>
        void UpdateLeaveRequestType(LeaveRequestType leaveRequestType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestID"></param>
        void DeleteLeaveRequestType(int leaveRequestID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        LeaveRequestType GetLeaveRequestTypeByPkid(int pkid);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        LeaveRequestType GetLeaveRequestTypeByName(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameLike"></param>
        /// <returns></returns>
        List<LeaveRequestType> GetLeaveRequestTypeByNameLike(string nameLike);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<LeaveRequestType> GetAllLeaveRequestType();
    }
}