//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: UpdateVacationByLeaveReuqest.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-12
// Resume: 
// ----------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Calendar;

namespace SEP.HRMIS.Bll.LeaveRequests
{
    /// <summary>
    /// 扣除年假
    /// </summary>
    public class DeleteVacationByLeaveReuqest
    {
        private static IVacation _VacationDal = new VacationDal();
        private static readonly ILeaveRequestDal _LeaveRequestDal = new LeaveRequestDal();
        private Vacation _LastVacation;
        private Vacation _SecondLastVacation;
        private int _AccountID;
        private List<LeaveRequestItem> _LeaveRequestItems;
        private LeaveRequestType _Type;
        private List<DayAttendance> _DayAttendanceList = new List<DayAttendance>();
        private decimal _SecondDeleteHour;
        private decimal _LastDeleteHour;
        private List<Vacation> _VacationList;
        private bool _IsUpdateVacation = true;

        private bool _IsTest = false; //是否测试

        /// <summary>
        /// for test
        /// </summary>
        public DeleteVacationByLeaveReuqest()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public DeleteVacationByLeaveReuqest(int accountid, List<LeaveRequestItem> leaveRequestitems,
                                            LeaveRequestType type)
        {
            _AccountID = accountid;
            _LeaveRequestItems = leaveRequestitems;
            _Type = type;
            _VacationList = _VacationDal.GetVacationByAccountID(_AccountID);
        }

        /// <summary>
        /// 初始化信息
        /// </summary>
        /// <param name="item"></param>
        private void Init(LeaveRequestItem item)
        {
            InitVacation(item);
            InitDayAttandanceList(item);
        }

        private void InitDayAttandanceList(LeaveRequestItem item)
        {
            //当测试时，不调用这个方法
            if (_IsTest)
            {
                return;
            }
            _DayAttendanceList = new List<DayAttendance>();
            CalculateCostHour cal =
                new CalculateCostHour(item.FromDate, item.ToDate, _AccountID,
                                      _Type.LeaveRequestTypeID);
            cal.Excute();
            _DayAttendanceList.AddRange(cal.DayAttendanceList);
        }

        private void InitVacation(LeaveRequestItem item)
        {
            _SecondDeleteHour = 0;
            _LastDeleteHour = 0;
            _LastVacation = null;
            _SecondLastVacation = null;
            List<Vacation> vacationList = new List<Vacation>();
            foreach (Vacation vacation in _VacationList)
            {
                if (vacation.VacationStartDate <= item.ToDate && vacation.SurplusDayNum > 0)
                {
                    vacationList.Add(vacation);
                }
            }
            if (vacationList.Count > 0)
            {
                vacationList = vacationList.OrderByDescending(x => x.VacationEndDate).ToList();
                _LastVacation = vacationList[0];
                if (vacationList.Count > 1)
                {
                    _SecondLastVacation = vacationList[1];
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Excute()
        {
            Validation();
            if (_Type.LeaveRequestTypeID == (int)LeaveRequestTypeEnum.AnnualLeave)
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    foreach (LeaveRequestItem item in _LeaveRequestItems)
                    {
                        Init(item);
                        InitCostHour(item);
                        if (_SecondLastVacation == null && _LastVacation == null)
                        {
                            HrmisUtility.ThrowException("没有年假");
                        }
                        item.UseList = "";
                        DeleteVacationHour(_SecondLastVacation, _SecondDeleteHour, item);
                        DeleteVacationHour(_LastVacation, _LastDeleteHour, item);
                    }
                    ts.Complete();
                }
            }
        }

        private void Validation()
        {
            if (_VacationList == null || _VacationList.Count <= 0)
            {
                HrmisUtility.ThrowException("没有年假");
            }
        }

        /// <summary>
        /// 计算要扣除的小时数
        /// </summary>
        /// <param name="item"></param>
        private void InitCostHour(LeaveRequestItem item)
        {
            if (_LastVacation != null)
            {
                if (_SecondLastVacation != null)
                {
                    foreach (DayAttendance attendance in _DayAttendanceList)
                    {
                        if (attendance.Date.Date <= _SecondLastVacation.VacationEndDate.Date)
                        {
                            _SecondDeleteHour += attendance.Hours;
                        }
                        else
                        {
                            _LastDeleteHour += attendance.Hours;
                        }
                    }
                    if (_SecondLastVacation.SurplusDayNum * 8 < _SecondDeleteHour)
                    {
                        _LastDeleteHour += _SecondDeleteHour - _SecondLastVacation.SurplusDayNum * 8;
                        _SecondDeleteHour = _SecondLastVacation.SurplusDayNum * 8;
                    }
                }
                else
                {
                    _LastDeleteHour += item.CostTime;
                }
            }
        }

        /// <summary>
        /// 扣除，如果不够，则报错
        /// </summary>
        private void DeleteVacationHour(Vacation vacation, decimal deletehour, LeaveRequestItem item)
        {
            if (vacation != null)
            {
                vacation.UsedDayNum += (deletehour / 8);
                vacation.SurplusDayNum -= (deletehour / 8);
                if (vacation.SurplusDayNum < 0)
                {
                    HrmisUtility.ThrowException("剩余年假不足");
                }
                else if (_IsUpdateVacation)
                {
                    _VacationDal.Update(vacation);
                    item.UseList = string.Format("{0},{1}/{2}", vacation.VacationID, deletehour, item.UseList);
                    _LeaveRequestDal.UpdateLeaveRequestItemUseDetail(item);
                }
            }
        }

        /// <summary>
        /// 是否真的更新数据库
        /// </summary>
        public bool IsUpdateVacation
        {
            set { _IsUpdateVacation = value; }
            get { return _IsUpdateVacation; }
        }


        /// <summary>
        /// 用于测试
        /// </summary>
        public void TestExcute(int accountid, List<LeaveRequestItem> leaveRequestitems, LeaveRequestType type,
                               List<Vacation> VacationList, List<DayAttendance> dayAttendanceList,
                               IVacation mockvacation)
        {
            _AccountID = accountid;
            _LeaveRequestItems = leaveRequestitems;
            _Type = type;
            _VacationList = VacationList;
            _DayAttendanceList = dayAttendanceList;
            _IsTest = true;
            _VacationDal = mockvacation;
            Excute();
        }
    }
}