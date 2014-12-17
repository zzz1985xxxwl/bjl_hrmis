//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: WorkInfoDataBinder.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 工作信息界面的数据绑定类
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation.WorkInformation
{
    public class WorkInfoDataBinder : IDataBinder<Employee>
    {
        private Employee _TheEmployeeToShow;
        private readonly IWorkInfoView _ItsView;
        //private IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();
        private readonly IEmployeeContractFacade _IEmployeeContractFacade =
            InstanceFactory.CreateEmployeeContractFacade();

        private readonly IAssessManagementFacade _IAssessManagementFacade =
            InstanceFactory.CreateAssessManagementFacade();

        private readonly bool _IsFront;

        public WorkInfoDataBinder(IWorkInfoView itsView, bool isFront)
        {
            _ItsView = itsView;
            _IsFront = isFront;
        }

        public bool DataBind(Employee theDataToBind)
        {
            _TheEmployeeToShow = theDataToBind;
            bool retVal = true;
            if (_TheEmployeeToShow != null)
            {
                retVal &= HandleContract();
                retVal &= HandleDepartment();
                retVal &= HandlePosition();
                retVal &= HandleEmployeeDetails();
                retVal &= HandleAttedanceRuleAndDoorCardNO();
                retVal &= HandleSocietyWorkAge();
                retVal &= HandleDiyProcess();
                retVal &= HandleAdjustRule();
                retVal &= HandleAssessTemplate();
            }
            return retVal;
        }

        private bool HandleContract()
        {
            //如果是前台，则绑定最新的员工合同，不是则显示所有
            List<Contract> allContracts;
            if (_IsFront)
            {
                allContracts = _IEmployeeContractFacade.GetLastContractByAccountID(_TheEmployeeToShow.Account.Id);
            }
            else
            {
                allContracts = _IEmployeeContractFacade.GetEmployeeContractByAccountID(_TheEmployeeToShow.Account.Id);
            }

            _ItsView.EmployeeContract = allContracts;
            _ItsView.EmployeeContractDataSource = allContracts;
            //处理合同起始时间，最新合同开始时间
            HandleSomeContractTimes(allContracts);
            return true;
        }

        private void HandleSomeContractTimes(IList<Contract> allContracts)
        {
            DateTime strDate;
            DateTime endDate;
            DateTime newstrDate;
            int icount = allContracts.Count;
            if (icount > 0)
            {
                strDate = allContracts[0].StartDate;
                endDate = allContracts[0].EndDate;
                newstrDate = strDate;

                foreach (Contract con in allContracts)
                {
                    if (con != null && DateTime.Compare(strDate, con.StartDate) > 0)
                    {
                        strDate = con.StartDate;
                    }
                    if (con != null && DateTime.Compare(endDate, con.EndDate) < 0)
                    {
                        endDate = con.EndDate;
                    }
                    if (con != null && DateTime.Compare(newstrDate, con.StartDate) < 0)
                    {
                        newstrDate = con.StartDate;
                    }
                }
                _ItsView.ContractStartDate = strDate.ToString("yyyy-MM-dd");
                _ItsView.ContractEndDate = endDate.ToString("yyyy-MM-dd");
                _ItsView.NewContractStartDate = newstrDate.ToString("yyyy-MM-dd");
            }
            else
            {
                _ItsView.ContractStartDate = string.Empty;
                _ItsView.ContractEndDate = string.Empty;
                _ItsView.NewContractStartDate = string.Empty;
            }
        }

        private bool HandlePosition()
        {
            bool retVal = true;
            if (_TheEmployeeToShow.Account.Position != null || _TheEmployeeToShow.Account.Position.Grade != null)
            {
                try
                {
                    _ItsView.Position = _TheEmployeeToShow.Account.Position.Name;
                }
                catch (ArgumentOutOfRangeException)
                {
                    retVal &= false;
                }
            }
            if (_TheEmployeeToShow.Account.Position.Grade != null)
            {
                try
                {
                    _ItsView.PositionGradeId = _TheEmployeeToShow.Account.Position.Grade.Id.ToString();
                }
                catch (ArgumentOutOfRangeException)
                {
                    retVal &= false;
                }
            }

            return retVal;
        }

        private bool HandleAttedanceRuleAndDoorCardNO()
        {
            bool retVal = true;
            if (_TheEmployeeToShow.EmployeeAttendance != null)
            {
                _ItsView.DoorCardNO = _TheEmployeeToShow.EmployeeAttendance.DoorCardNo;
            }
            return retVal;
        }

        private bool HandleSocietyWorkAge()
        {
            bool retVal = true;
            if (_TheEmployeeToShow.SocWorkAgeAndVacationList != null)
            {
                _ItsView.SocietyWorkAge = _TheEmployeeToShow.SocWorkAgeAndVacationList.SocietyWorkAge.ToString();
            }
            return retVal;
        }

        private bool HandleDepartment()
        {
            bool retVal = true;
            if (_TheEmployeeToShow.Account.Dept != null)
            {
                try
                {
                    _ItsView.Department = _TheEmployeeToShow.Account.Dept.Name;
                    _ItsView.DepartmentID = _TheEmployeeToShow.Account.Dept.Id;
                }
                catch (ArgumentOutOfRangeException)
                {
                    retVal &= false;
                }
            }
            return retVal;
        }

        private bool HandleEmployeeDetails()
        {
            bool retVal = true;

            if (_TheEmployeeToShow.EmployeeDetails != null)
            {
                //需要对非null值的DateTime作转换
                _ItsView.ProbationEndDate = _TheEmployeeToShow.EmployeeDetails.ProbationTime <=
                                            Convert.ToDateTime("1900-01-01")
                                                ? string.Empty
                                                : _TheEmployeeToShow.EmployeeDetails.ProbationTime.ToShortDateString();
                //add by liudan 2009-08-14
                _ItsView.ProbationStartDate = _TheEmployeeToShow.EmployeeDetails.ProbationStartTime <=
                            Convert.ToDateTime("1900-01-01")
                                ? string.Empty
                                : _TheEmployeeToShow.EmployeeDetails.ProbationStartTime.ToShortDateString();
                retVal &= HandleWork();
            }
            return retVal;
        }

        private bool HandleWork()
        {
            bool retVal = true;
            if (_TheEmployeeToShow.EmployeeDetails.Work != null)
            {
                _ItsView.ComeDate = _TheEmployeeToShow.EmployeeDetails.Work.ComeDate <= Convert.ToDateTime("1900-01-01")
            ? string.Empty
            : _TheEmployeeToShow.EmployeeDetails.Work.ComeDate.ToShortDateString();
                _ItsView.WorkAge = _TheEmployeeToShow.EmployeeDetails.Work.ComeDate <= Convert.ToDateTime("1900-01-01")
            ? string.Empty
            : _TheEmployeeToShow.EmployeeDetails.Work.WorkAgeString; 
                //_ItsView.ComeDate = _TheEmployeeToShow.EmployeeDetails.Work.ComeDate.ToShortDateString();
                //客户要求职责直接与其岗位相关
                //_ItsView.Responsibility = _TheEmployeeToShow.EmployeeDetails.Work.Responsibility;
                _ItsView.Responsibility = _TheEmployeeToShow != null &&
                                          _TheEmployeeToShow.Account != null &&
                                          _TheEmployeeToShow.Account.Position != null &&
                                          _TheEmployeeToShow.Account.Position.MainDuties != null
                                              ? _TheEmployeeToShow.Account.Position.MainDuties
                                              : "";
                _ItsView.ContractPosition = _TheEmployeeToShow.EmployeeDetails.Work.ContractPosition;
                _ItsView.WorkPlace = _TheEmployeeToShow.EmployeeDetails.Work.WorkPlace;
                try
                {
                    if (_TheEmployeeToShow.EmployeeDetails.Work.Company != null)
                    {
                        _ItsView.Company =
                            _TheEmployeeToShow.EmployeeDetails.Work.Company.Id.ToString();
                    }
                    //add by liudan 2009-08-13 职务
                    if (_TheEmployeeToShow.EmployeeDetails.Work.Principalship != null)
                    {
                        _ItsView.PrincipalShipId =
                            _TheEmployeeToShow.EmployeeDetails.Work.Principalship.Id.ToString();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    _ItsView.CompanyMessage = EmployeePresenterUtilitys._TypeNotDefined;
                    retVal &= false;
                }
            }
            return retVal;
        }

        /// <summary>
        /// 处理自定义流程绑定
        /// </summary>
        /// <returns></returns>
        private bool HandleDiyProcess()
        {
            bool retVal = true;
            if (_TheEmployeeToShow.DiyProcessList != null)
            {
                foreach (DiyProcess process in _TheEmployeeToShow.DiyProcessList)
                {
                    if (process.Type.Id.Equals(ProcessType.Assess.Id))
                    {
                        _ItsView.AssessProcessId = process.ID;
                    }
                    if (process.Type.Id.Equals(ProcessType.ApplicationTypeOut.Id))
                    {
                        _ItsView.outProcessId = process.ID;
                    }
                    if (process.Type.Id.Equals(ProcessType.ApplicationTypeOverTime.Id))
                    {
                        _ItsView.OverTimeProcessId = process.ID;
                    }
                    if (process.Type.Id.Equals(ProcessType.LeaveRequest.Id))
                    {
                        _ItsView.leaveProcessId = process.ID;
                    }
                    if (process.Type.Id.Equals(ProcessType.HRPrincipal.Id))
                    {
                        _ItsView.HRPrincipalProcessId = process.ID;
                    }
                    //if (process.Type.Id.Equals(ProcessType.Reimburse.Id))
                    //{
                    //    _ItsView.ReimburseProcessId = process.ID;
                    //}
                    if (process.Type.Id.Equals(ProcessType.TraineeApplication.Id))
                    {
                        _ItsView.TraineeApplicationProcessId = process.ID;
                    }
                }
            }
            return retVal;
        }

        /// <summary>
        /// 处理调休规则绑定
        /// </summary>
        /// <returns></returns>
        private bool HandleAdjustRule()
        {
            bool retVal = true;
            try
            {
                if (_TheEmployeeToShow.AdjustRule != null)
                {
                    _ItsView.AdjustRuleID = _TheEmployeeToShow.AdjustRule.AdjustRuleID;
                }
            }
            catch
            {
                retVal &= false;
            }
            return retVal;
        }

        private bool HandleAssessTemplate()
        {
            bool retVal = true;
            try
            {
                if (_TheEmployeeToShow.Account.Position != null)
                {
                    int paperid = _IAssessManagementFacade.GetTempletPaperIDByEmployeePositionID(
                        _TheEmployeeToShow.Account.Position.Id);
                    AssessTemplatePaper paper = _IAssessManagementFacade.GetTempletPaperAndItemById(paperid);
                    if (paper != null && paper.ItsAssessTemplateItems != null)
                    {
                        _ItsView.AssessActivityItemList = paper.ItsAssessTemplateItems;
                    }
                }
            }
            catch
            {
                retVal &= false;
            }
            return retVal;
        }
    }
}