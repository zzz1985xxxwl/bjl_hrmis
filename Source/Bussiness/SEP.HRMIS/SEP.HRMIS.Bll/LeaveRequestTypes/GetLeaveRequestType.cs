//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: GetLeaveRequestType.cs
// Creater:  Xue.wenlong
// Date:  2009-03-24
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Bll.LeaveRequestTypes
{
    /// <summary>
    /// 
    /// </summary>
    public class GetLeaveRequestType
    {
        private static readonly ILeaveRequestType _LeaveRequestTypeDal = DalFactory.DataAccess.CreateLeaveRequestType();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public LeaveRequestType GetLeaveRequestTypeByPkid(int pkid)
        {
            return _LeaveRequestTypeDal.GetLeaveRequestTypeByPkid(pkid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public LeaveRequestType GetLeaveRequestTypeByName(string name)
        {
            return _LeaveRequestTypeDal.GetLeaveRequestTypeByName(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameLike"></param>
        /// <returns></returns>
        public List<LeaveRequestType> GetLeaveRequestTypeByNameLike(string nameLike)
        {
            return _LeaveRequestTypeDal.GetLeaveRequestTypeByNameLike(nameLike);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<LeaveRequestType> GetAllLeaveRequestType()
        {
            return _LeaveRequestTypeDal.GetAllLeaveRequestType();
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public string GetAllLeaveTypeNames()
        {
            List<LeaveRequestType> temp = _LeaveRequestTypeDal.GetAllLeaveRequestType();
            StringBuilder types = new StringBuilder();
            if (temp != null)
            {
                int count = temp.Count;
                for (int i = 0; i < count; i++)
                {
                    types.Append(temp[i].Name);
                    if (i < count - 1)
                    {
                        types.Append(" ");
                    }
                }
            }
            return types.ToString();
        }
    }
}