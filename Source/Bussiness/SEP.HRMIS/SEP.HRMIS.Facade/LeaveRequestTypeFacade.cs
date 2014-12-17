//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: LeaveRequestType.cs
// Creater:  Xue.wenlong
// Date:  2009-03-24
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Bll.LeaveRequestTypes;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// 
    /// </summary>
    public class LeaveRequestTypeFacade:ILeaveRequestTypeFacade
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestType"></param>
        public void AddLeaveRequestType(LeaveRequestType leaveRequestType)
        {
            new AddLeaveRequestType(leaveRequestType).Excute();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestType"></param>
        public void UpdateLeaveRequestType(LeaveRequestType leaveRequestType)
        {
            new UpdateLeaveRequestType(leaveRequestType).Excute();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestID"></param>
        public void DeleteLeaveRequestType(int leaveRequestID)
        {
            new DeleteLeaveRequestType(leaveRequestID).Excute();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public LeaveRequestType GetLeaveRequestTypeByPkid(int pkid)
        {
            return new GetLeaveRequestType().GetLeaveRequestTypeByPkid(pkid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public LeaveRequestType GetLeaveRequestTypeByName(string name)
        {
            return new GetLeaveRequestType().GetLeaveRequestTypeByName(name);
        }

        public List<LeaveRequestType> GetLeaveRequestTypeByNameLike(string nameLike)
        {
            return new GetLeaveRequestType().GetLeaveRequestTypeByNameLike(nameLike);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<LeaveRequestType> GetAllLeaveRequestType()
        {
            return new GetLeaveRequestType().GetAllLeaveRequestType();
        }
    }
}