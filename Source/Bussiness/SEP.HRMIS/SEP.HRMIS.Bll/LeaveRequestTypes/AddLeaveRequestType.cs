//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: AddLeaveRequestType.cs
// Creater:  Xue.wenlong
// Date:  2009-03-24
// Resume:
// ---------------------------------------------------------------

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.LeaveRequestTypes
{
    /// <summary>
    /// 
    /// </summary>
    public class AddLeaveRequestType:Transaction
    {
        private static ILeaveRequestType _LeaveRequestTypeDal = new LeaveRequestTypeDal();
        private readonly Model.Request.LeaveRequestType _LeaveRequestType;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestType"></param>
        public AddLeaveRequestType(Model.Request.LeaveRequestType leaveRequestType)
        {
            _LeaveRequestType = leaveRequestType;
        }
        /// <summary>
        /// for test
        /// </summary>
        /// <param name="leaveRequestType"></param>
        /// <param name="mockILeaveRequestType"></param>
        public AddLeaveRequestType(Model.Request.LeaveRequestType leaveRequestType, ILeaveRequestType mockILeaveRequestType):this(leaveRequestType)
        {
            _LeaveRequestTypeDal = mockILeaveRequestType;
        }
        protected override void ExcuteSelf()
        {
            try
            {
                _LeaveRequestTypeDal.InsertLeaveRequestType(_LeaveRequestType);
            }
            catch
            {
                HrmisUtility.ThrowException(HrmisUtility._DbError);
            }
        }

        protected override void Validation()
        {
            if (_LeaveRequestTypeDal.GetLeaveRequestTypeByName(_LeaveRequestType.Name) != null)
            {
                HrmisUtility.ThrowException(HrmisUtility._LeaveRequestType_Name_Repeat);
            }
        }
    }
}