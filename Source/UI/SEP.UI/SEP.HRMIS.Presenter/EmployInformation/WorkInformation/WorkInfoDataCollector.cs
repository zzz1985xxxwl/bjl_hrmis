//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: WorkInfoDataBinder.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 工作信息界面的数据收集类
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Adjusts;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;
using SEP.Model.Departments;
using SEP.Model.Positions;
using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;

namespace SEP.HRMIS.Presenter.EmployInformation.WorkInformation
{
    public class WorkInfoDataCollector : IDataCollector<Employee>
    {
        private Employee _TheEmployeeToComplete;
        private readonly IWorkInfoView _ItsView;

        public WorkInfoDataCollector(IWorkInfoView itsView)
        {
            _ItsView = itsView;
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            _TheEmployeeToComplete = theObjectToComplete;

            if (_TheEmployeeToComplete == null)
            {
                throw new Exception(EmployeePresenterUtilitys._ObjectIsNull);
            }
            HandleEmployeeDetailsInfo();
            HandleAttedanceRuleAndDoorCardNOInfo();
            HandleSocietyWorkAge();
            HandleDiyProcess();
            HandlePositionGradeInfo();
            HandleAdjustRule();
        }
        private void HandleAttedanceRuleAndDoorCardNOInfo()
        {
            if (_TheEmployeeToComplete.EmployeeAttendance == null)
            {
                _TheEmployeeToComplete.EmployeeAttendance = new EmployeeAttendance(DateTime.Now, DateTime.Now);
            }
            if (_TheEmployeeToComplete.EmployeeAttendance.PlanDutyDetailList == null)
            {
                _TheEmployeeToComplete.EmployeeAttendance.PlanDutyDetailList = new List<PlanDutyDetail>();
            }
            CollectAttedanceRuleAndDoorCardNOInfo();
        }
        private void HandleSocietyWorkAge()
        {
            if (_TheEmployeeToComplete.SocWorkAgeAndVacationList == null)
            {
                _TheEmployeeToComplete.SocWorkAgeAndVacationList = new SocWorkAgeAndVacationList();
            }
            CollectSocietyWorkAge();
        }
        private void HandlePositionGradeInfo()
        {
            int gradeId = Convert.ToInt32(_ItsView.PositionGradeId);
            if (_TheEmployeeToComplete.Account.Position == null)
            {
                _TheEmployeeToComplete.Account.Position = new Position(0, null, new PositionGrade(gradeId, "", ""));
            }
            else
            {
                _TheEmployeeToComplete.Account.Position.Grade = new PositionGrade(gradeId, "", "");
            }
        }
        
        //private void HandleDepartmentInfo()
        //{
        //    if (_TheEmployeeToComplete.Department == null)
        //    {
        //        _TheEmployeeToComplete.Department = new Department(0,null);
        //    }
        //    CollectDepartmentInfo();
        //}
        
        private void HandleEmployeeDetailsInfo()
        {
            if (_TheEmployeeToComplete.EmployeeDetails == null)
            {
                _TheEmployeeToComplete.EmployeeDetails = new EmployeeDetails(null, null, null, 0m, 0m, null, null,
                                                                             null, new DateTime(1900, 1, 1), null,
                                                                             new DateTime(1900, 1, 1), null, null);
            }
            CollectEmployeeDetailInfo();
        }
        
        private void HandleWorkInfo()
        {
            if (_TheEmployeeToComplete.EmployeeDetails.Work == null)
            {
                _TheEmployeeToComplete.EmployeeDetails.Work = new Work(null, null, null, new DateTime(1900, 1, 1), null);
            }
            CollectWorkInfo();
        }

        private void CollectEmployeeDetailInfo()
        {
            if (!string.IsNullOrEmpty(_ItsView.ProbationEndDate))
            {
                _TheEmployeeToComplete.EmployeeDetails.ProbationTime = DateTime.Parse(_ItsView.ProbationEndDate);
            }
            else
            {
                _TheEmployeeToComplete.EmployeeDetails.ProbationTime = Convert.ToDateTime("1900-01-01");
            }
            if (!string.IsNullOrEmpty(_ItsView.ProbationStartDate))
            {
                _TheEmployeeToComplete.EmployeeDetails.ProbationStartTime = DateTime.Parse(_ItsView.ProbationStartDate);
            }
            else
            {
                _TheEmployeeToComplete.EmployeeDetails.ProbationStartTime = Convert.ToDateTime("1900-01-01");
            }
            HandleWorkInfo();
        }

        private void CollectAttedanceRuleAndDoorCardNOInfo()
        {
            _TheEmployeeToComplete.EmployeeAttendance.DoorCardNo=_ItsView.DoorCardNO;
        }
        private void CollectSocietyWorkAge()
        {
            int _SocietyWorkAge = 0;
            if (!string.IsNullOrEmpty(_ItsView.SocietyWorkAge))
            {
                _SocietyWorkAge = Convert.ToInt32(_ItsView.SocietyWorkAge);
            }
            _TheEmployeeToComplete.SocWorkAgeAndVacationList.SocietyWorkAge = _SocietyWorkAge;
        }

        private void CollectWorkInfo()
        {
            DateTime comedate;
            if (DateTime.TryParse(_ItsView.ComeDate, out comedate))
            {
                _TheEmployeeToComplete.EmployeeDetails.Work.ComeDate = comedate;
            }
            else
            {
                _TheEmployeeToComplete.EmployeeDetails.Work.ComeDate = Convert.ToDateTime("1900-1-1");
            }
            //_TheEmployeeToComplete.EmployeeDetails.Work.ComeDate = DateTime.Parse(_ItsView.ComeDate);
            _TheEmployeeToComplete.EmployeeDetails.Work.ContractPosition = _ItsView.ContractPosition;
            _TheEmployeeToComplete.EmployeeDetails.Work.Company =
                new Department(Convert.ToInt32(_ItsView.Company), "");
            _TheEmployeeToComplete.EmployeeDetails.Work.Responsibility = _ItsView.Responsibility;
            _TheEmployeeToComplete.EmployeeDetails.Work.WorkPlace = _ItsView.WorkPlace;
            _TheEmployeeToComplete.EmployeeDetails.Work.Principalship =
                PrincipalShip.GetById(Convert.ToInt32(_ItsView.PrincipalShipId));

        }

        /// <summary>
        /// 收集所选的diy流程数据
        /// </summary>
        private void HandleDiyProcess()
        {
            _TheEmployeeToComplete.DiyProcessList = new List<DiyProcess>();
            DiyProcess leaveRequest = new DiyProcess(_ItsView.leaveProcessId, string.Empty, string.Empty,
                                                     ProcessType.LeaveRequest);
            DiyProcess outProcess = new DiyProcess(_ItsView.outProcessId, string.Empty, string.Empty, ProcessType.ApplicationTypeOut);
            DiyProcess overTimeProcess = new DiyProcess(_ItsView.OverTimeProcessId, string.Empty, string.Empty, ProcessType.ApplicationTypeOverTime);
            DiyProcess asseseeProcess = new DiyProcess(_ItsView.AssessProcessId, string.Empty, string.Empty, ProcessType.Assess);
            DiyProcess hrPrincipal = new DiyProcess(_ItsView.HRPrincipalProcessId, string.Empty, string.Empty, ProcessType.HRPrincipal);
            //DiyProcess reimburse = new DiyProcess(_ItsView.ReimburseProcessId, string.Empty, string.Empty, ProcessType.Reimburse);
            DiyProcess traineeApplicationProcess = 
                new DiyProcess(_ItsView.TraineeApplicationProcessId, string.Empty, string.Empty, ProcessType.TraineeApplication);
            _TheEmployeeToComplete.DiyProcessList.Add(leaveRequest);
            _TheEmployeeToComplete.DiyProcessList.Add(outProcess);
            _TheEmployeeToComplete.DiyProcessList.Add(overTimeProcess);
            _TheEmployeeToComplete.DiyProcessList.Add(asseseeProcess);
            _TheEmployeeToComplete.DiyProcessList.Add(hrPrincipal);
            //_TheEmployeeToComplete.DiyProcessList.Add(reimburse);
            _TheEmployeeToComplete.DiyProcessList.Add(traineeApplicationProcess);

        }

        private void HandleAdjustRule()
        {
            _TheEmployeeToComplete.AdjustRule=new AdjustRule(_ItsView.AdjustRuleID,string.Empty);
        }
    }
}