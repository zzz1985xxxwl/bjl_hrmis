//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: InAndOutStatisticsPresenter.cs
// 创建者: 王玥琦
// 创建日期: 2008-10-17
// 概述: 
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IAttendanceInAndOutStatistics;
using SEP.IBll;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;

namespace SEP.HRMIS.Presenter.AttendanceStatistics.AttendanceInAndOutStatistics
{
    public class InAndOutStatisticsPresenter 
    {
        private readonly IInAndOutStatisticsView _ItsView;
        private readonly IAttendanceReadDataFacade _IAttendanceReadDataFacade = InstanceFactory.CreateAttendanceReadDataFacade();

        private readonly IAttendanceInOutRecordFacade _IAttendanceInOutRecordFacade = InstanceFactory.AttendanceInOutRecordFacade();

        private readonly IBll.Accounts.IAccountBll _IGetEmployee = BllInstance.AccountBllInstance;
        //public delegate void _SendMail(string employeeID,string employeeName, string inTime ,
        //    string outTime, string status);
        private readonly Account _LoginUser;
        public InAndOutStatisticsPresenter(IInAndOutStatisticsView itsView, Account loginUser)
        {
            _ItsView = itsView;
            _LoginUser = loginUser;
            AttachViewEvent();
        }

        public void InitView(bool pageIsPostBack)
        {
            if (!pageIsPostBack)
            {
                GetBaseData();
                InAndOutStatisticsDataBind();
            }
        }
        public void GetBaseData()
        {
            List<Department> departmentList = BllInstance.DepartmentBllInstance.GetAllDepartment();
            _ItsView.DepartmentList = Tools.RemoteUnAuthDeparetment(departmentList, AuthType.HRMIS, _LoginUser, HrmisPowers.A503);
            _ItsView.GradesSource = GradesType.GetAll();
            _ItsView.OutInTimeConditionSourse = GetOutInTimeCondition();
            _ItsView.HourFromList = Hours();
            _ItsView.HourToList = Hours();
            _ItsView.MinutesFromList = Minutes();
            _ItsView.MinutesToList = Minutes();
            _ItsView.SearchFrom = DateTime.Now.ToShortDateString() + " 0:00:00";
            _ItsView.SearchTo = DateTime.Now.ToShortDateString() + " 23:59:59";
        }

        public static List<OutInTimeConditionEnum> GetOutInTimeCondition()
        {
            List<OutInTimeConditionEnum> outInTimeCondition = new List<OutInTimeConditionEnum>();
            outInTimeCondition.Add(OutInTimeConditionEnum.All);
            outInTimeCondition.Add(OutInTimeConditionEnum.InTimeIsNull);
            outInTimeCondition.Add(OutInTimeConditionEnum.OutTimeIsNull);
            outInTimeCondition.Add(OutInTimeConditionEnum.InAndOutTimeIsNull);
            outInTimeCondition.Add(OutInTimeConditionEnum.InOrOutTimeIsNull);
            return outInTimeCondition;
        }

        /// <summary>
        /// 设置选择小时的来源
        /// </summary>
        /// <returns></returns>
        public static List<string> Hours()
        {
            List<string> types = new List<string>();
            types.Add("0");
            types.Add("1");
            types.Add("2");
            types.Add("3");
            types.Add("4");
            types.Add("5");
            types.Add("6");
            types.Add("7");
            types.Add("8");
            types.Add("9");
            types.Add("10");
            types.Add("11");
            types.Add("12");
            types.Add("13");
            types.Add("14");
            types.Add("15");
            types.Add("16");
            types.Add("17");
            types.Add("18");
            types.Add("19");
            types.Add("20");
            types.Add("21");
            types.Add("22");
            types.Add("23");
            return types;
        }

        /// <summary>
        /// 设置选择分的来源
        /// </summary>
        /// <returns></returns>
        public static List<string> Minutes()
        {
            List<string> types = new List<string>();
            types.Add("00");
            types.Add("01");
            types.Add("02");
            types.Add("03");
            types.Add("04");
            types.Add("05");
            types.Add("06");
            types.Add("07");
            types.Add("08");
            types.Add("09");
            types.Add("10");
            types.Add("11");
            types.Add("12");
            types.Add("13");
            types.Add("14");
            types.Add("15");
            types.Add("16");
            types.Add("17");
            types.Add("18");
            types.Add("19");
            types.Add("20");
            types.Add("21");
            types.Add("22");
            types.Add("23");
            types.Add("24");
            types.Add("25");
            types.Add("26");
            types.Add("27");
            types.Add("28");
            types.Add("29");
            types.Add("30");
            types.Add("31");
            types.Add("32");
            types.Add("33");
            types.Add("34");
            types.Add("35");
            types.Add("36");
            types.Add("37");
            types.Add("38");
            types.Add("39");
            types.Add("40");
            types.Add("41");
            types.Add("42");
            types.Add("43");
            types.Add("44");
            types.Add("45");
            types.Add("46");
            types.Add("47");
            types.Add("48");
            types.Add("49");
            types.Add("50");
            types.Add("51");
            types.Add("52");
            types.Add("53");
            types.Add("54");
            types.Add("55");
            types.Add("56");
            types.Add("57");
            types.Add("58");
            types.Add("59");
            return types;
        }

        public void AttachViewEvent()
        {
            _ItsView.BtnSearchEvent += InAndOutStatisticsDataBind;
            _ItsView.BtnSendEmailEvent += SendEmail;
            _ItsView.BtnSendMessageEvent += SendMessage;
        }
        public void SendEmail(string info)
        {
            string[] temp = info.Split(',');
            string employeeID = temp[0];
            string employeeName = temp[1];
            string inTime = temp[2];
            string outTime = temp[3];
            string status = temp[4];

            //_SendMail sendMailDelegate = SendEmailForEmployees;
            //sendMailDelegate.BeginInvoke(employeeID, employeeName, inTime, outTime, status, null, null);
            SendEmailForEmployees(employeeID, employeeName, inTime, outTime, status);
        }

        public void SendEmailForEmployees(string employeeID, string employeeName, string inTime,
            string outTime, string status)
        {
            try
            {
                List<string> cc = new List<string>();
                int _EmployeeID;
                if (!int.TryParse(employeeID, out _EmployeeID))
                {
                    return;
                }
                Account account = _IGetEmployee.GetAccountById(_EmployeeID);
                if (account == null)
                {
                    return;
                }
                List<string> to = new List<string>();

                to.Add(account.Email1);
                if (!string.IsNullOrEmpty(account.Email2))
                {
                    to.Add(account.Email2);
                }
                _IAttendanceReadDataFacade.AttendanceSendEmailToEmployee(employeeName, inTime, outTime, status,
                                                       _SearchFrom.ToString(), _SearchTo.ToString(), to, cc, _LoginUser);

                _ItsView.ErrorMessage = "邮件已发送";
            }
            catch (Exception ex)
            {
                _ItsView.ErrorMessage = ex.Message;
            }
        }

        public void SendMessage(string info)
        {
            string[] temp = info.Split(',');
            string employeeID = temp[0];
            string employeeName = temp[1];
            string inTime = temp[2];
            string outTime = temp[3];
            string status = temp[4];
            try
            {
                int _EmployeeID;
                if (!int.TryParse(employeeID, out _EmployeeID))
                {
                    return;
                }
                Account account = _IGetEmployee.GetAccountById(_EmployeeID);
                if (account == null)
                {
                    return;
                }
                _IAttendanceReadDataFacade.AttendanceSendMessageToEmployee(employeeName, inTime, outTime, status,account.MobileNum,
                                                       _SearchFrom);

                _ItsView.ErrorMessage = "短信已发送";
            }
            catch (Exception ex)
            {
                _ItsView.ErrorMessage = ex.Message;
            }
        }


        private int _DepartmentID;
        private static DateTime _SearchFrom;
        private static DateTime _SearchTo;
        private OutInTimeConditionEnum _OutInTimeCondition;

        public void InAndOutStatisticsDataBind()
        {
            if (Vaildate())
            {
                List<Employee> itsSource = _IAttendanceInOutRecordFacade.
                    GetAttendanceOutInRecordByCondition(_ItsView.EmployeeName,_ItsView.GradesId, _DepartmentID,
                                                        _SearchFrom, _SearchTo, _OutInTimeCondition, _LoginUser);
                _ItsView.EmployeeList = itsSource;
            }
        }

        public bool Vaildate()
        {
            _ItsView.ErrorMessage = string.Empty;
            if (!int.TryParse(_ItsView.DepartmentID, out _DepartmentID))
            {
                _ItsView.ErrorMessage = "部门ID必须为整数!";
                return false;
            }
            if (!DateTime.TryParse(_ItsView.SearchFrom, out _SearchFrom))
            {
                _ItsView.ErrorMessage = "查询时间格式不正确！";
                return false;
            }
            if (_SearchFrom.Equals(Convert.ToDateTime("0001-1-1 0:00:00")))
            {
                _SearchFrom = Convert.ToDateTime("1900-1-1 0:00:00");
            }
            if (!DateTime.TryParse(_ItsView.SearchTo, out _SearchTo))
            {
                _ItsView.ErrorMessage = "查询时间格式不正确！";
                return false;
            }
            if (_SearchTo.Equals(Convert.ToDateTime("0001-1-1 0:00:00")))
            {
                _SearchTo = Convert.ToDateTime("2900-12-31 0:00:00");
            }
            _OutInTimeCondition = GetOutInTimeConditionEnum(_ItsView.OutInTimeCondition);
            return true;
        }

        public static OutInTimeConditionEnum GetOutInTimeConditionEnum(string name)
        {
            switch (name)
            {
                case "InAndOutTimeIsNull":
                    return OutInTimeConditionEnum.InAndOutTimeIsNull;
                case "InOrOutTimeIsNull":
                    return OutInTimeConditionEnum.InOrOutTimeIsNull;
                case "InTimeIsNull":
                    return OutInTimeConditionEnum.InTimeIsNull;
                case "OutTimeIsNull":
                    return OutInTimeConditionEnum.OutTimeIsNull;
                default:
                    return OutInTimeConditionEnum.All;
            }
        }
    }
}
