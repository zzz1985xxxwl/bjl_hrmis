//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ValidateRequestItemRepeat.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.Requests
{
    /// <summary>
    /// </summary>
    public class ValidateRequestItemRepeat
    {
        private static IOverWork _DalOverWork = new OverWorkDal();
        private static IOutApplication _DalOutApplication = new OutApplicationDal();
        private static ILeaveRequestDal _DalLeaveRequest = new LeaveRequestDal();
        private readonly Request _Request;
        private readonly bool _IsAdd;
        private readonly bool _IsOverWorkJoinToCheck;
        private readonly bool _IsOutJoinToCheck;
        private readonly bool _IsLeaveJoinToCheck;

        /// <summary>
        /// </summary>
        /// <param name="overWork"></param>
        /// <param name="isAdd">是新增还是修改</param>
        public ValidateRequestItemRepeat(OverWork overWork, bool isAdd)
        {
            _IsAdd = isAdd;
            _Request = new Request(overWork);
            _IsOverWorkJoinToCheck = true;
            _IsLeaveJoinToCheck = true;
        }

        /// <summary>
        /// </summary>
        public ValidateRequestItemRepeat(OutApplication outApplication, bool isAdd)
        {
            _IsAdd = isAdd;
            _Request = new Request(outApplication);
            _IsOutJoinToCheck = true;
        }

        /// <summary>
        /// </summary>
        public ValidateRequestItemRepeat(LeaveRequest leaveRequest, bool isAdd)
        {
            _IsAdd = isAdd;
            _Request = new Request(leaveRequest);
            _IsOverWorkJoinToCheck = true;
            _IsLeaveJoinToCheck = true;
        }

        /// <summary>
        /// 测试LeaveRequest调用
        /// </summary>
        public ValidateRequestItemRepeat(IOverWork overwork,
                                         ILeaveRequestDal leaveRequestdal, IOutApplication outApplication,
                                         LeaveRequest leaveRequest, bool isAdd)
        {
            _IsAdd = isAdd;
            _Request = new Request(leaveRequest);
            _DalOverWork = overwork;
            _DalOutApplication = outApplication;
            _DalLeaveRequest = leaveRequestdal;
            _IsOverWorkJoinToCheck = true;
            _IsLeaveJoinToCheck = true;
            //_IsOutJoinToCheck = true;
        }

        /// <summary>
        /// </summary>
        public void Excute()
        {
            HasInnerError();
            HasOuterError();
        }

        /// <summary>
        /// 判断自身是否有重复
        /// </summary>
        /// <returns></returns>
        private void HasInnerError()
        {
            if (_Request != null && _Request.Item != null)
            {
                List<RequestItem> RequestItems = _Request.Item;
                for (int i = 0; i < RequestItems.Count - 1; i++)
                {
                    for (int j = i + 1; j < RequestItems.Count; j++)
                    {
                        if (
                            ValifyIsRepeat(RequestItems[i].FromDate, RequestItems[i].ToDate,
                                           RequestItems[j].FromDate, RequestItems[j].ToDate))
                        {
                            HrmisUtility.ThrowException(HrmisUtility._Date_Inner_Repeat);
                        }
                    }
                }
            }
        }

        private void HasOuterError()
        {
            int countRepeatLeaveRequest = 0;
            int countRepeatOverWork = 0;
            int countRepeatOutApplication = 0;
            foreach (RequestItem item in _Request.Item)
            {
                if (_IsLeaveJoinToCheck)
                {
                    countRepeatLeaveRequest +=
                        _DalLeaveRequest.CountLeaveRequestInRepeatDateDiffPKID(_Request.Account.Id,
                                                                               GetPKID(RequestType.Leave),
                                                                               item.FromDate,
                                                                               item.ToDate);

                    if (countRepeatLeaveRequest > 0)
                    {
                        HrmisUtility.ThrowException(HrmisUtility._Date_Repeat);
                        break;
                    }
                }
                if (_IsOverWorkJoinToCheck)
                {
                    countRepeatOverWork +=
                        _DalOverWork.CountOverWorkInRepeatDateDiffPKID(_Request.Account.Id,
                                                                       GetPKID(RequestType.OverWork),
                                                                       item.FromDate,
                                                                       item.ToDate);
                    if (countRepeatOverWork > 0)
                    {
                        HrmisUtility.ThrowException(HrmisUtility._Date_OverWork_Repeat);
                        break;
                    }
                }
                if (_IsOutJoinToCheck)
                {
                    countRepeatOutApplication +=
                        _DalOutApplication.CountOutApplicationInRepeatDateDiffPKID(_Request.Account.Id,
                                                                                   GetPKID(RequestType.Out),
                                                                                   item.FromDate,
                                                                                   item.ToDate);
                    if (countRepeatOutApplication > 0)
                    {
                        HrmisUtility.ThrowException(HrmisUtility._Date_Out_Repeat);
                        break;
                    }
                }
            }
        }

        private int GetPKID(RequestType type)
        {
            if (_Request.RequestType == type)
            {
                return _IsAdd ? 0 : _Request.PKID;
            }
            else
            {
                return 0;
            }
        }

        private static bool ValifyIsRepeat(DateTime from1, DateTime to1, DateTime from2, DateTime to2)
        {
            if (from1 < to2 && from2 < to1)
            {
                return true;
            }
            return false;
        }
    }
}