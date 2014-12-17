//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: UpdateLeaveRequestType.cs
// Creater:  Xue.wenlong
// Date:  2009-03-24
// Resume:
// ---------------------------------------------------------------

using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Bll.LeaveRequestTypes
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateLeaveRequestType : Transaction
    {
        private static ILeaveRequestType _LeaveRequestTypeDal = DalFactory.DataAccess.CreateLeaveRequestType();
        private readonly LeaveRequestType _LeaveRequestType;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestType"></param>
        public UpdateLeaveRequestType(LeaveRequestType leaveRequestType)
        {
            _LeaveRequestType = leaveRequestType;
        }

        /// <summary>
        /// test
        /// </summary>
        /// <param name="leaveRequestType"></param>
        /// <param name="iLeaveRequestType"></param>
        public UpdateLeaveRequestType(LeaveRequestType leaveRequestType, ILeaveRequestType iLeaveRequestType)
            : this(leaveRequestType)
        {
            _LeaveRequestTypeDal = iLeaveRequestType;
        }

        protected override void Validation()
        {
            if (_LeaveRequestTypeDal.GetLeaveRequestTypeByPkid(_LeaveRequestType.LeaveRequestTypeID) == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._LeaveRequestType_Name_NotExist);
            }
            LeaveRequestType leaveRequestType = _LeaveRequestTypeDal.GetLeaveRequestTypeByName(_LeaveRequestType.Name);
            if (leaveRequestType != null && leaveRequestType.LeaveRequestTypeID != _LeaveRequestType.LeaveRequestTypeID)
            {
                HrmisUtility.ThrowException(HrmisUtility._LeaveRequestType_Name_Repeat);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _LeaveRequestTypeDal.UpdateLeaveRequestType(_LeaveRequestType);
            }
            catch
            {
                HrmisUtility.ThrowException(HrmisUtility._DbError);
            }
        }
    }
}