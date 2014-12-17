using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.CompanyInvolve;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.AdvanceSearch;
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
    public class BindContractSearchExpression
    {
        private readonly string _FieldParaBaseId;
        private Account _OperatorAccount;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldParaBaseId"></param>
        /// <param name="operatorAccount"></param>
        public BindContractSearchExpression(string fieldParaBaseId, Account operatorAccount)
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
            if (ContractFieldPara.ContractType.Id.ToString() == _FieldParaBaseId)
            {
                List<ContractType> all = new GetContractType().GetContractTypeByCondition(-1, "");
                foreach (ContractType item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.ContractTypeName : "\n" + item.ContractTypeName;
                }
            }
            if (ContractFieldPara.PositionGrade.Id.ToString() == _FieldParaBaseId)
            {
                List<PositionGrade> all = BllInstance.PositionBllInstance.GetAllPositionGrade();
                foreach (PositionGrade item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (ContractFieldPara.EmployeeType.Id.ToString() == _FieldParaBaseId)
            {
                Dictionary<string, string> AllEmployeeType = EmployeeTypeUtility.GetAllEmployeeTypeEnum();
                foreach (KeyValuePair<string, string> item in AllEmployeeType)
                {
                    result += string.IsNullOrEmpty(result) ? item.Value : "\n" + item.Value;
                }
            }
            if (ContractFieldPara.Position.Id.ToString() == _FieldParaBaseId)
            {
                IPositionBll _IPositionBll = BllInstance.PositionBllInstance;
                List<Position> all = _IPositionBll.GetAllPosition();
                foreach (Position item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (ContractFieldPara.Department.Id.ToString() == _FieldParaBaseId)
            {
                IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
                List<Department> all = _IDepartmentBll.GetAllDepartment();
                all = Tools.RemoteUnAuthDeparetment(all, AuthType.HRMIS, _OperatorAccount, HrmisPowers.A402);
                foreach (Department item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (ContractFieldPara.Company.Id.ToString() == _FieldParaBaseId)
            {
                GetCompanyInvolve _GetCompanyInvolve = new GetCompanyInvolve();
                List<Department> all = _GetCompanyInvolve.GetAllCompanyHaveEmployee();
                foreach (Department item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            if (ContractFieldPara.WorkType.Id.ToString() == _FieldParaBaseId)
            {
                List<WorkType> all = WorkType.GetAll();
                foreach (WorkType item in all)
                {
                    result += string.IsNullOrEmpty(result) ? item.Name : "\n" + item.Name;
                }
            }
            return result;
        }

    }


}
