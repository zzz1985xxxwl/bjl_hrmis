//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: DeleteLeaveRequestType.cs
// Creater:  Xue.wenlong
// Date:  2009-03-24
// Resume:
// ---------------------------------------------------------------

using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.LeaveRequestTypes
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteLeaveRequestType : Transaction
    {
        private static ILeaveRequestType _LeaveRequestTypeDal = DalFactory.DataAccess.CreateLeaveRequestType();
        private static ILeaveRequestDal _LeaveRequestDal = DalFactory.DataAccess.CreateLeaveRequest();
        private readonly int _LeaveRequestTypeID;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaveRequestTypeId"></param>
        public DeleteLeaveRequestType(int leaveRequestTypeId)
        {
            _LeaveRequestTypeID = leaveRequestTypeId;
        }

        /// <summary>
        ///  test
        /// </summary>
        /// <param name="leaveRequestTypeId"></param>
        /// <param name="mockILeaveRequestType"></param>
        /// <param name="mockILeaveRequestDal"></param>
        public DeleteLeaveRequestType(int leaveRequestTypeId, ILeaveRequestType mockILeaveRequestType,
                                      ILeaveRequestDal mockILeaveRequestDal) : this(leaveRequestTypeId)
        {
            _LeaveRequestTypeDal = mockILeaveRequestType;
            _LeaveRequestDal = mockILeaveRequestDal;
        }

        protected override void Validation()
        {
            if (_LeaveRequestTypeDal.GetLeaveRequestTypeByPkid(_LeaveRequestTypeID) == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._LeaveRequestType_Name_NotExist);
            }
            if (_LeaveRequestDal.CountLeaveRequestByLeaveRequestTypeID(_LeaveRequestTypeID) > 0)
            {
                HrmisUtility.ThrowException(HrmisUtility._LeaveRequestType_HasLeaveRequest);
            }
            if (_LeaveRequestTypeID == (int)LeaveRequestTypeEnum.AnnualLeave || _LeaveRequestTypeID == (int)LeaveRequestTypeEnum.AdjustRest)
            {
                HrmisUtility.ThrowException(HrmisUtility._LeaveRequestType_CanNotDelete);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _LeaveRequestTypeDal.DeleteLeaveRequestType(_LeaveRequestTypeID);
            }
            catch
            {
                HrmisUtility.ThrowException(HrmisUtility._DbError);
            }
        }
    }
}