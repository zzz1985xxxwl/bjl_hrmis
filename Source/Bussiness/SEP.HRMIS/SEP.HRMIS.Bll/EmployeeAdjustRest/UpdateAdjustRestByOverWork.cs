//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: UpdateAdjustRestByOverWork.cs
// Creater: Xue.wenlong
// CreateDate: 2009-09-04
// Resume: 
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Bll.EmployeeAdjustRules;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Adjusts;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.HRMIS.Model.Enum;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Bll.EmployeeAdjustRest
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAdjustRestByOverWork
    {
        private readonly OverWorkItem _OverWorkItem;
        private readonly int _AccountID;
        private readonly IAdjustRest _IAdjustRest = DalFactory.DataAccess.CreateAdjustRest();
        private readonly IAdjustRestHistory _IAdjustRestHistory = DalFactory.DataAccess.CreateAdjustRestHistory();
        private readonly AdjustRule _AdjustRule;
        private decimal _ChangeHour = 0;

        /// <summary>
        /// 
        /// </summary>
        public UpdateAdjustRestByOverWork(OverWorkItem item, int accountid)
        {
            _OverWorkItem = item;
            _AccountID = accountid;
            _AdjustRule = new GetEmployeeAdjustRule().GetAdjustRuleByAccountID(accountid);
            if (_AdjustRule == null)
            {
                _AdjustRule = new AdjustRule(0, "", 0, 0, 0, 0, 0, 0);
            }
        }


        /// <summary>
        /// 先初始化OperatorType，看是否要更新调休
        /// 然后将加班记录分成一天一天的记录
        /// 将同年的加班记录合并
        /// 更新合并后的调休，以处理跨年现象
        /// 记录历史
        /// </summary>
        public void Excute()
        {
            if(_OverWorkItem.Adjust)
            {
                OperatorType operatorType = InitOperatorType();
                if (operatorType != OperatorType.empty)
                {
                    List<AdjustRest> adjustRestList = InitAdjustRestList();
                    List<AdjustRest> UpdateadjustRestList = UpdateAdjustRestByOut.InitUpdateAdjustRestList(adjustRestList);
                    UpdateAdjustRestDB(operatorType, UpdateadjustRestList);
                    CreateHistory(operatorType);
                }
            }
        }

        /// <summary>
        /// 更新调休
        /// </summary>
        /// <param name="operatorType"></param>
        /// <param name="UpdateadjustRestList"></param>
        private void UpdateAdjustRestDB(OperatorType operatorType, IEnumerable<AdjustRest> UpdateadjustRestList)
        {
            foreach (AdjustRest rest in UpdateadjustRestList)
            {
                AdjustRest adjustRest = _IAdjustRest.GetAdjustRestByAccountIDAndYear(_AccountID, rest.AdjustYear);
                if (operatorType == OperatorType.add)
                {
                    adjustRest.SurplusHours = adjustRest.SurplusHours + rest.SurplusHours; //获得调休
                    _ChangeHour += rest.SurplusHours;
                }
                else if (operatorType == OperatorType.delete)
                {
                    adjustRest.SurplusHours = adjustRest.SurplusHours - rest.SurplusHours; //返还调休
                    _ChangeHour += rest.SurplusHours;
                }
                _IAdjustRest.UpdateAdjustRest(adjustRest);
            }
        }

        /// <summary>
        /// 记录历史
        /// </summary>
        /// <param name="operatorType"></param>
        private void CreateHistory(OperatorType operatorType)
        {
            string remark = "";
            AdjustRestHistory _AdjustRestHistory =
                UpdateAdjustRestByOperator.GetNewAdjustRestHistory(AdjustRestHistoryTypeEnum.OverWork, _AccountID);
            if (operatorType == OperatorType.add)
            {
                remark = _OverWorkItem.FromDate + " - " + _OverWorkItem.ToDate + " 加班" +
                         _OverWorkItem.CostTime +
                         "小时";
                _AdjustRestHistory.ChangeHours = _ChangeHour;
            }
            else if (operatorType == OperatorType.delete)
            {
                remark = _OverWorkItem.FromDate + " - " + _OverWorkItem.ToDate + " 取消加班" +
                         _OverWorkItem.CostTime +
                         "小时";
                _AdjustRestHistory.ChangeHours = -_ChangeHour;
            }
            _AdjustRestHistory.Remark = remark;
            _AdjustRestHistory.RelevantID = _OverWorkItem.OverWorkID;
            _IAdjustRestHistory.InsertAdjustRestHistory(_AccountID, _AdjustRestHistory);
        }


        /// <summary>
        /// 初始化调休，将加班信息变成一条条调休记录
        /// </summary>
        /// <returns></returns>
        private List<AdjustRest> InitAdjustRestList()
        {
            List<AdjustRest> adjustRestList = new List<AdjustRest>();
            AdjustRest ar = new AdjustRest();
            ar.AdjustYear = _OverWorkItem.FromDate;
            ar.SurplusHours = _OverWorkItem.AdjustHour;//_OverWorkItem.CostTime*GetMagnification(_OverWorkItem, _AdjustRule);
            adjustRestList.Add(ar);
            return adjustRestList;
        }

        private enum OperatorType
        {
            empty,
            add,
            delete
        }

        private OperatorType InitOperatorType()
        {
            if (_OverWorkItem.Status.Id == RequestStatus.ApprovePass.Id)
            {
                return OperatorType.add;
            }
            if (OverWorkUtility.IsItemFlowContainStatus(_OverWorkItem, RequestStatus.ApprovePass))
            {
                if (_OverWorkItem.Status.Id == RequestStatus.ApproveCancelPass.Id
                    && !OverWorkUtility.IsItemFlowContainStatus(_OverWorkItem, RequestStatus.ApproveCancelPass))
                {
                    return OperatorType.delete;
                }
            }
            else
            {
                if (_OverWorkItem.Status.Id == RequestStatus.ApproveCancelFail.Id)
                {
                    return OperatorType.add;
                }
                if (_OverWorkItem.Status.Id == RequestStatus.ApproveCancelPass.Id
                    && OverWorkUtility.IsItemFlowContainStatus(_OverWorkItem, RequestStatus.ApproveCancelFail))
                {
                    return OperatorType.delete;
                }
            }
            return OperatorType.empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetItemAdjustHour()
        {
            return _OverWorkItem.CostTime*GetMagnification(_OverWorkItem, _AdjustRule);
        }

        /// <summary>
        /// 
        /// </summary>
        private static decimal GetMagnification(OverWorkItem overWorkItem, AdjustRule adjustRule)
        {
            decimal magnification = 0;
            if (overWorkItem.OverWorkType == OverWorkType.PuTong)
            {
                magnification = adjustRule.OverWorkPuTongRate;
            }
            else if (overWorkItem.OverWorkType == OverWorkType.ShuangXiu)
            {
                magnification = adjustRule.OverWorkShuangXiuRate;
            }
            else if (overWorkItem.OverWorkType == OverWorkType.JieRi)
            {
                magnification = adjustRule.OverWorkJieRiRate;
            }
            return magnification;
        }
    }
}