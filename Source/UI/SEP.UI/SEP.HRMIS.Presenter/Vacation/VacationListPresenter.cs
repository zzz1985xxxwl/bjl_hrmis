//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: VacationListPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-06-18
// 概述: 年假列表
// ----------------------------------------------------------------
using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter
{
    public class VacationListPresenter
    {
        private readonly IVacationFacade _IVacationFacade = InstanceFactory.CreateVacationFacade();

        private readonly IEmployeeAttendanceFacade _IEmployeeAttendanceFacade =
            InstanceFactory.CreateEmployeeAttendanceFacade();
        private readonly IVacationBaseListView _IVacationBaseListView;
        private readonly IVacationBaseView _IVacationBaseView;
        private readonly Account _Operator;
        #region 测试用

        public VacationListPresenter(IVacationBaseListView view, bool isPostBack, Account _operator, 
            IVacationFacade mockGetVacation, IEmployeeAttendanceFacade mockIEmployeeAttendanceFacade)
        {
            _IEmployeeAttendanceFacade = mockIEmployeeAttendanceFacade;
            _IVacationFacade = mockGetVacation;
            _IVacationBaseListView = view;
            _IVacationBaseView = view.IVacationBaseView;
            _Operator = _operator;
            AttachEvents();
            InitVacationList(isPostBack);
        }

        #endregion

        public VacationListPresenter(IVacationBaseListView view, bool isPostBack, Account _operator)
        {
            _IVacationBaseListView = view;
            _IVacationBaseView = view.IVacationBaseView;
            _Operator = _operator;
            AttachEvents();
            InitVacationList(isPostBack);
        }

        private void AttachEvents()
        {
            _IVacationBaseListView.AddEvent += ExecuteAddEvent;
            _IVacationBaseListView.InitAddVacationDetailEvent += InitAddVacationDetailEvent;
            _IVacationBaseListView.Delete += ExecuteDeleteEvent;
            _IVacationBaseListView.UpdateEvent += ExecuteUpdateEvent;
            _IVacationBaseListView.Search += ExecuteSearchEvent;
            _IVacationBaseListView.InitUpdateVacationDetailEvent += InitUpdateVacationDetailEvent;
        }

        #region Add

        public void ExecuteAddEvent(object sender, EventArgs e)
        {
            if (VacationBasePresenter.Validation(_IVacationBaseView))
            {
                Employee employee = new Employee(Convert.ToInt32(_IVacationBaseView.EmployeeID),EmployeeTypeEnum.All);
                employee.Account.Name = _IVacationBaseView.EmployeeName;
                Vacation vacation =
                    new Vacation(0, employee,
                                 Convert.ToDecimal(_IVacationBaseView.VacationDayNum),
                                 Convert.ToDateTime(_IVacationBaseView.VacationStartDate),
                                 Convert.ToDateTime(_IVacationBaseView.VacationEndDate),
                                 Convert.ToDecimal(_IVacationBaseView.UsedDayNum),
                                 Convert.ToDecimal(_IVacationBaseView.SurplusDayNum),
                                 _IVacationBaseView.Remark);
                try
                {
                    _IVacationFacade.AddVacation(vacation);
                }
                catch (ApplicationException ex)
                {
                    _IVacationBaseListView.Message = ex.Message;
                }
            }
        }

        public void InitAddVacationDetailEvent(object sender, CommandEventArgs e)
        {
            Vacation vacation = _IVacationFacade.GetVacationByAccountID(Convert.ToInt32(e.CommandArgument))[0];
            _IVacationBaseView.EmployeeID = vacation.Employee.Account.Id.ToString();
            _IVacationBaseView.EmployeeName = vacation.Employee.Account.Name;
            _IVacationBaseView.Remark = string.Empty;
            _IVacationBaseView.SurplusDayNum = string.Empty;
            _IVacationBaseView.UsedDayNum = string.Empty;
            _IVacationBaseView.VacationDayNum = string.Empty;
            _IVacationBaseView.VacationEndDate = string.Empty;
            _IVacationBaseView.VacationStartDate = string.Empty;
            _IVacationBaseView.AdjustRestRemainedDays =
                _IEmployeeAttendanceFacade.GetAdjustRestRemainedDaysByEmployeeID(Convert.ToInt32(e.CommandArgument)).
                    ToString();
        }

        #endregion

        #region Update

        public void ExecuteUpdateEvent(object sender, EventArgs e)
        {
            if (VacationBasePresenter.Validation(_IVacationBaseView))
            {
                Employee employee = new Employee(Convert.ToInt32(_IVacationBaseView.EmployeeID),new EmployeeTypeEnum());
                employee.Account.Name = _IVacationBaseView.EmployeeName;
                Vacation vacation =
                    new Vacation(Convert.ToInt32(_IVacationBaseView.VacationID), employee,
                                 Convert.ToDecimal(_IVacationBaseView.VacationDayNum),
                                 Convert.ToDateTime(_IVacationBaseView.VacationStartDate),
                                 Convert.ToDateTime(_IVacationBaseView.VacationEndDate),
                                 Convert.ToDecimal(_IVacationBaseView.UsedDayNum),
                                 Convert.ToDecimal(_IVacationBaseView.SurplusDayNum),
                                 _IVacationBaseView.Remark);
                try
                {
                    _IVacationFacade.UpdateVacation(vacation);
                }
                catch (ApplicationException ex)
                {
                    _IVacationBaseListView.Message = ex.Message;
                }
            }
        }

        public void InitUpdateVacationDetailEvent(object sender, CommandEventArgs e)
        {
            Vacation vacation = _IVacationFacade.GetVacationByVacationID(Convert.ToInt32(e.CommandArgument));
            _IVacationBaseView.VacationID = e.CommandArgument.ToString();
            _IVacationBaseView.EmployeeID = vacation.Employee.Account.Id.ToString();
            _IVacationBaseView.EmployeeName = vacation.Employee.Account.Name;
            _IVacationBaseView.Remark = vacation.Remark;
            _IVacationBaseView.SurplusDayNum = vacation.SurplusDayNum.ToString();
            _IVacationBaseView.UsedDayNum = vacation.UsedDayNum.ToString();
            _IVacationBaseView.VacationDayNum = vacation.VacationDayNum.ToString();
            _IVacationBaseView.VacationEndDate = vacation.VacationEndDate.ToShortDateString();
            _IVacationBaseView.VacationStartDate = vacation.VacationStartDate.ToShortDateString();
            _IVacationBaseView.AdjustRestRemainedDays =
                _IEmployeeAttendanceFacade.GetAdjustRestRemainedDaysByEmployeeID(vacation.Employee.Account.Id).
                    ToString();
        }

        #endregion

        #region delete

        public void ExecuteDeleteEvent(object sender, CommandEventArgs e)
        {
            try
            {
                _IVacationFacade.DeleteVacation(Convert.ToInt32(e.CommandArgument));
            }
            catch (ApplicationException ex)
            {
                _IVacationBaseListView.Message = ex.Message;
            }
        }

        #endregion

        #region search

        private void BindVacationList()
        {
            if (Validation())
            {
                _IVacationBaseListView.VacationList =
                    _IVacationFacade.GetVacationByCondition(_IVacationBaseListView.EmployeeNameForSearch,
                                                            _VacationDayNumStart,
                                                            _VacationDayNumEnd,
                                                            _VacationEndDateStart, _VacationEndDateEnd,
                                                            _SurplusDayNumStart,
                                                            _SurplusDayNumEnd, _Operator,
                                                            Convert.ToInt32(_IVacationBaseListView.EmployeeStatusId));
            }
        }

        private void InitVacationList(bool isPostBack)
        {
            _IVacationBaseView.ResultMessage = string.Empty;
            if (!isPostBack)
            {
                BindVacationList();
            }
        }

        public void ExecuteSearchEvent(object sender, EventArgs e)
        {
            BindVacationList();
        }

        private decimal _VacationDayNumStart;
        private decimal _VacationDayNumEnd;
        private decimal _SurplusDayNumStart;
        private decimal _SurplusDayNumEnd;
        private DateTime _VacationEndDateStart;
        private DateTime _VacationEndDateEnd;

        public bool Validation()
        {
            bool vacationDayNumStartIsEmpty = false;
            bool vacationDayNumEndIsEmpty = false;
            bool surplusDayNumStartIsEmpty = false;
            bool surplusDayNumEndIsEmpty = false;
            bool vacationEndDateStartIsEmpty = false;
            bool vacationEndDateEndIsEmpty = false;

            #region 如果为空，decimal型就赋值为-1；DateTime型就赋值最大和最小时间

            if (String.IsNullOrEmpty(_IVacationBaseListView.VacationDayNumStart))
            {
                _VacationDayNumStart = -1;
                vacationDayNumStartIsEmpty = true;
            }
            if (String.IsNullOrEmpty(_IVacationBaseListView.VacationDayNumEnd))
            {
                _VacationDayNumEnd = -1;
                vacationDayNumEndIsEmpty = true;
            }
            if (String.IsNullOrEmpty(_IVacationBaseListView.SurplusDayNumStart))
            {
                _SurplusDayNumStart = -1;
                surplusDayNumStartIsEmpty = true;
            }
            if (String.IsNullOrEmpty(_IVacationBaseListView.SurplusDayNumEnd))
            {
                _SurplusDayNumEnd = -1;
                surplusDayNumEndIsEmpty = true;
            }
            if (String.IsNullOrEmpty(_IVacationBaseListView.VacationEndDateStart))
            {
                _VacationEndDateStart = Convert.ToDateTime("1900-1-1");
                vacationEndDateStartIsEmpty = true;
            }
            if (String.IsNullOrEmpty(_IVacationBaseListView.VacationEndDateEnd))
            {
                _VacationEndDateEnd = Convert.ToDateTime("2900-1-1");
                vacationEndDateEndIsEmpty = true;
            }

            #endregion

            //如果不为空。则判断类型是否正确
            if ((!vacationDayNumStartIsEmpty &&
                 (!decimal.TryParse(_IVacationBaseListView.VacationDayNumStart, out _VacationDayNumStart) ||
                  _VacationDayNumStart < 0)) ||
                (!vacationDayNumEndIsEmpty &&
                 (!decimal.TryParse(_IVacationBaseListView.VacationDayNumEnd, out _VacationDayNumEnd) ||
                  _VacationDayNumEnd < 0)) ||
                (!surplusDayNumStartIsEmpty &&
                 (!decimal.TryParse(_IVacationBaseListView.SurplusDayNumStart, out _SurplusDayNumStart) ||
                  _SurplusDayNumStart < 0)) ||
                (!surplusDayNumEndIsEmpty &&
                 (!decimal.TryParse(_IVacationBaseListView.SurplusDayNumEnd, out _SurplusDayNumEnd) ||
                  _SurplusDayNumEnd < 0)))
            {
                _IVacationBaseListView.Message = "年假天数必须为大于等于0的数字！";
                return false;
            }
            if ((!vacationEndDateStartIsEmpty &&
                 !DateTime.TryParse(_IVacationBaseListView.VacationEndDateStart, out _VacationEndDateStart)) ||
                (!vacationEndDateEndIsEmpty &&
                 !DateTime.TryParse(_IVacationBaseListView.VacationEndDateEnd, out _VacationEndDateEnd)))
            {
                _IVacationBaseListView.Message = "请输入正确的时间格式！";
                return false;
            }
            return true;
        }

        #endregion
    }
}