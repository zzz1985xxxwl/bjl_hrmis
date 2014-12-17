//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: WorkInfoVaildater.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 工作信息界面的界面初始化类
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Adjusts;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Departments;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.Model.Positions;
using SEP.IBll.Positions;

namespace SEP.HRMIS.Presenter.EmployInformation.WorkInformation
{
    public class WorkInfoViewIniter
    {
        private readonly IWorkInfoView _ItsView;
        private IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        private IPositionBll _IPositionBll = BllInstance.PositionBllInstance;
        private IDiyProcessFacade _IDiyProcessFacade = InstanceFactory.CreateDiyProcessFacade();
        private IAdjustRuleFacade _IAdjustRuleFacade = InstanceFactory.CreateAdjustRuleFacade();
        private IAssessManagementFacade _IAssessManagementFacade = InstanceFactory.CreateAssessManagementFacade();
        public WorkInfoViewIniter(IWorkInfoView itsView)
        {
            _ItsView = itsView;
        }

        public void InitTheViewToDefault()
        {
            //字段消息为空
            SetFiledAndMessageEmpty();
            //类型数据源绑定
            BindTypesSource();

            _ItsView.NewContractStartDateEnable = false;
            _ItsView.ContractEndDateEnable = false;
            _ItsView.ContractStartDateEnable = false;
        }

        private void BindTypesSource()
        {
            List<Department> departmentSource = _IDepartmentBll.GetAllDepartment();
            if (departmentSource != null)
            {
                _ItsView.CompanySource = departmentSource;
            }

            List<DiyProcess> leaveProcess = _IDiyProcessFacade.GetDiyProcessByProcessType(ProcessType.LeaveRequest.Id);
            List<DiyProcess> outProcess = _IDiyProcessFacade.GetDiyProcessByProcessType(ProcessType.ApplicationTypeOut.Id);
            List<DiyProcess> overTimeProcess = _IDiyProcessFacade.GetDiyProcessByProcessType(ProcessType.ApplicationTypeOverTime.Id);
            List<DiyProcess> assessProcess = _IDiyProcessFacade.GetDiyProcessByProcessType(ProcessType.Assess.Id);
            List<DiyProcess> hrPrincipalProcess = _IDiyProcessFacade.GetDiyProcessByProcessType(ProcessType.HRPrincipal.Id);
            //List<DiyProcess> reimburseProcess = _IDiyProcessFacade.GetDiyProcessByProcessType(ProcessType.Reimburse.Id);
            List<DiyProcess> traineeApplicationProcess = _IDiyProcessFacade.GetDiyProcessByProcessType(ProcessType.TraineeApplication.Id);
            if (leaveProcess != null)
            {
                _ItsView.LeaveRequestProcess = leaveProcess;
            }
            if (outProcess != null)
            {
                _ItsView.OutProcess = outProcess;
            }
            if (overTimeProcess != null)
            {
                _ItsView.OverTimeProcess = overTimeProcess;
            }
            if (assessProcess != null)
            {
                _ItsView.AssessProcess = assessProcess;
            }
            if (hrPrincipalProcess != null)
            {
                _ItsView.HRPrincipalProcess = hrPrincipalProcess;
            }
            //if (hrPrincipalProcess != null)
            //{
            //    _ItsView.ReimburseProcess = reimburseProcess;
            //}
            if (traineeApplicationProcess!=null)
            {
                _ItsView.TraineeApplicationProcess = traineeApplicationProcess;
            }

            BindGradeTypesSource();
            BindPrincipalshipSource();
            List<AdjustRule> adjustRules = _IAdjustRuleFacade.GetAdjustRuleByNameLike("");
            if(adjustRules!=null)
            {
                _ItsView.AdjustRuleSource = adjustRules;
            }

        }

        private void SetFiledAndMessageEmpty()
        {
            _ItsView.ComeDate = string.Empty;
            _ItsView.ComeDateMessage = string.Empty;
            _ItsView.ContractEndDate = string.Empty;
            _ItsView.ContractPosition = string.Empty;
            _ItsView.ContractStartDate = string.Empty;
            _ItsView.CompanyMessage = string.Empty;
            _ItsView.NewContractStartDate = string.Empty;
            _ItsView.ProbationEndDateMessage = string.Empty;
            _ItsView.Responsibility = string.Empty;
            _ItsView.ProbationEndDate = string.Empty;
            _ItsView.DoorCardNO = string.Empty;
            _ItsView.SocietyWorkAge= string.Empty;
            _ItsView.SocietyWorkAgeMessage = string.Empty;
            _ItsView.WorkPlace = string.Empty;
            //add by liudan 2009-08-14
            _ItsView.ProbationStartDate = string.Empty;
            _ItsView.ProbationStartDateMessage = string.Empty;
        }

        /// <summary>
        /// 绑定职位等级
        /// </summary>
        private void BindGradeTypesSource()
        {
            List<PositionGrade> positionGradeSource = _IPositionBll.GetAllPositionGrade();
            if (positionGradeSource != null)
            {
                _ItsView.PositionGradeSource = positionGradeSource;
            }
        }

        /// <summary>
        /// 绑定职务
        /// </summary>
        private void BindPrincipalshipSource()
        {
            List<PrincipalShip> principalShipSource = PrincipalShip.GetAllPrincipalShip();
            if (principalShipSource != null)
            {
                _ItsView.PrincipalShipSource = principalShipSource;
            }
        }



        #region user for tests

        public IDepartmentBll SetGetDepartment
        {
            set
            {
                _IDepartmentBll = value;
            }
        }

        public IPositionBll SetGetPosition
        {
            set
            {
                _IPositionBll = value;
            }
        }

        public IDiyProcessFacade SetDiyProcess
        {
            set
            {
                _IDiyProcessFacade = value;
            }
        }

        public IAdjustRuleFacade SetAjustRule
        {
            set
            {
                _IAdjustRuleFacade = value;
            }
        }

        #endregion

    }
}