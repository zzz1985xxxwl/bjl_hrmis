using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.CompanyInvolve;
using SEP.HRMIS.Bll.DiyProcesses;
using SEP.HRMIS.Bll.Nationalitys;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.AdvanceSearch;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.IBll.Positions;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Model.Utility;

namespace SEP.HRMIS.Bll.AdvanceSearch
{
    /// <summary>
    /// 绑定比较值的googledown数据
    /// </summary>
    public class BindEmployeeSearchExpression
    {
        private readonly string _FieldParaBaseId;
        private Account _OperatorAccount;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldParaBaseId"></param>
        /// <param name="operatorAccount"></param>
        public BindEmployeeSearchExpression(string fieldParaBaseId, Account operatorAccount)
        {
            _FieldParaBaseId = fieldParaBaseId;
            _OperatorAccount = operatorAccount;
        }
        /// <summary>
        /// 绑定
        /// </summary>
        /// <returns></returns>
        public string ToBind()
        {
            string result = String.Empty;
            if (EmployeeFieldPara.Skill.Id.ToString() == _FieldParaBaseId)
            {
                List<Skill> all = new GetSkill().GetSkillByCondition("", -1);
                foreach (Skill item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.SkillName : "\n" + item.SkillName;
                }
            }
            if (EmployeeFieldPara.PositionGrade.Id.ToString() == _FieldParaBaseId)
            {
                List<PositionGrade> all = BllInstance.PositionBllInstance.GetAllPositionGrade();
                foreach (PositionGrade item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (EmployeeFieldPara.EmployeeType.Id.ToString() == _FieldParaBaseId)
            {
                Dictionary<string, string> AllEmployeeType = EmployeeTypeUtility.GetAllEmployeeTypeEnum();
                foreach (KeyValuePair<string, string> item in AllEmployeeType)
                {
                    result += string.IsNullOrEmpty(result) ? item.Value : "\n" + item.Value;
                }
            }
            if (EmployeeFieldPara.Position.Id.ToString() == _FieldParaBaseId)
            {
                IPositionBll _IPositionBll = BllInstance.PositionBllInstance;
                List<Position> all = _IPositionBll.GetAllPosition();
                foreach (Position item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (EmployeeFieldPara.Grades.Id.ToString() == _FieldParaBaseId)
            {
                var all = GradesType.GetAll();
                foreach (var item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (EmployeeFieldPara.Department.Id.ToString() == _FieldParaBaseId)
            {
                IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
                List<Department> all = _IDepartmentBll.GetAllDepartment();
                all = Tools.RemoteUnAuthDeparetment(all, AuthType.HRMIS, _OperatorAccount, HrmisPowers.A401);
                foreach (Department item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (EmployeeFieldPara.Company.Id.ToString() == _FieldParaBaseId)
            {
                GetCompanyInvolve _GetCompanyInvolve = new GetCompanyInvolve();
                List<Department> all = _GetCompanyInvolve.GetAllCompanyHaveEmployee();
                foreach (Department item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (EmployeeFieldPara.Gender.Id.ToString() == _FieldParaBaseId)
            {
                List<Gender> all = Gender.AllGenders;
                foreach (Gender item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (EmployeeFieldPara.DimissionReasonType.Id.ToString() == _FieldParaBaseId)
            {
                List<DimissionReasonType> all = DimissionReasonType.GetAll();
                foreach (DimissionReasonType item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (EmployeeFieldPara.DiyProcessApplicationTypeOut.Id.ToString() == _FieldParaBaseId)
            {
                GetDiyProcess _GetDiyProcess = new GetDiyProcess();
                List<DiyProcess> all =
                    _GetDiyProcess.GetDiyProcessByProcessType(ProcessType.ApplicationTypeOut.Id);
                foreach (DiyProcess item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (EmployeeFieldPara.DiyProcessApplicationTypeOverTime.Id.ToString() == _FieldParaBaseId)
            {
                GetDiyProcess _GetDiyProcess = new GetDiyProcess();
                List<DiyProcess> all =
                    _GetDiyProcess.GetDiyProcessByProcessType(ProcessType.ApplicationTypeOverTime.Id);
                foreach (DiyProcess item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (EmployeeFieldPara.DiyProcessAssess.Id.ToString() == _FieldParaBaseId)
            {
                GetDiyProcess _GetDiyProcess = new GetDiyProcess();
                List<DiyProcess> all =
                    _GetDiyProcess.GetDiyProcessByProcessType(ProcessType.Assess.Id);
                foreach (DiyProcess item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (EmployeeFieldPara.DiyProcessHRPrincipal.Id.ToString() == _FieldParaBaseId)
            {
                GetDiyProcess _GetDiyProcess = new GetDiyProcess();
                List<DiyProcess> all =
                    _GetDiyProcess.GetDiyProcessByProcessType(ProcessType.HRPrincipal.Id);
                foreach (DiyProcess item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (EmployeeFieldPara.DiyProcessLeaveRequest.Id.ToString() == _FieldParaBaseId)
            {
                GetDiyProcess _GetDiyProcess = new GetDiyProcess();
                List<DiyProcess> all =
                    _GetDiyProcess.GetDiyProcessByProcessType(ProcessType.LeaveRequest.Id);
                foreach (DiyProcess item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (EmployeeFieldPara.DiyProcessTraineeApplication.Id.ToString() == _FieldParaBaseId)
            {
                GetDiyProcess _GetDiyProcess = new GetDiyProcess();
                List<DiyProcess> all =
                    _GetDiyProcess.GetDiyProcessByProcessType(ProcessType.TraineeApplication.Id);
                foreach (DiyProcess item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (EmployeeFieldPara.EducationalBackground.Id.ToString() == _FieldParaBaseId)
            {
                List<EducationalBackground> all = EducationalBackground.AllEducationalBackgrounds;
                foreach (EducationalBackground item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (EmployeeFieldPara.MaritalStatus.Id.ToString() == _FieldParaBaseId)
            {
                List<MaritalStatus> all = MaritalStatus.GetAllMaritalStatus();
                foreach (MaritalStatus item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (EmployeeFieldPara.PoliticalAffiliation.Id.ToString() == _FieldParaBaseId)
            {
                List<PoliticalAffiliation> all = PoliticalAffiliation.AllPoliticalAffiliations;
                foreach (PoliticalAffiliation item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (EmployeeFieldPara.WorkType.Id.ToString() == _FieldParaBaseId)
            {
                List<WorkType> all = WorkType.GetAll();
                foreach (WorkType item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (EmployeeFieldPara.CountryNationality.Id.ToString() == _FieldParaBaseId)
            {
                GetNationality _GetNationality = new GetNationality();
                List<Nationality> all = _GetNationality.GetNationalityByCondition(-1, "");
                foreach (Nationality item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            return result;
        }

    }
}