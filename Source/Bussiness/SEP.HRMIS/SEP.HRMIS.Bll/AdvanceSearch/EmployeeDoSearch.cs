using System.Collections.Generic;
using AdvancedCondition;
using AdvancedCondition.Enums;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AdvanceSearch;
using SEP.IBll;
using SEP.IBll.Departments;

namespace SEP.HRMIS.Bll.AdvanceSearch
{
    /// <summary>
    /// 高级查询员工
    /// </summary>
    public class EmployeeDoSearch : DoSearch
    {
        private IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        private readonly List<SearchField> _SearchFieldList;
        private readonly List<Employee> _EmployeeList;
        /// <summary>
        /// 为测试
        /// </summary>
        public IDepartmentBll MockIDepartmentBll
        {
            set { _IDepartmentBll = value; }
        }
        /// <summary>
        /// 获得检索后的Employee列表
        /// </summary>
        public List<Employee> EmployeeList
        {
            get { return _EmployeeList; }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="employeeList"></param>
        /// <param name="searchFieldList"></param>
        public EmployeeDoSearch(List<Employee> employeeList, List<SearchField> searchFieldList)
        {
            _EmployeeList = employeeList;
            _SearchFieldList = searchFieldList;
        }

        protected override void DoOrCompare()
        {
            for (int i = 0; i < _EmployeeList.Count; i++)
            {
                bool isNeedOne = false;
                bool isExistOr = false;
                foreach (SearchField item in _SearchFieldList)
                {
                    if (item.ConditionField.EnumCollectedType != EnumCollectedType.Or)
                    {
                        continue;
                    }
                    isExistOr = true;
                    isNeedOne = EmployeeFieldPara.IsNeedCondition(item, _EmployeeList[i]);
                    if (isNeedOne)
                    {
                        break;
                    }
                }
                if (isExistOr && !isNeedOne)
                {
                    _EmployeeList.RemoveAt(i);
                    i--;
                }
            }
        }

        protected override void DoAndCompare()
        {
            for (int i = 0; i < _EmployeeList.Count; i++)
            {
                foreach (SearchField item in _SearchFieldList)
                {
                    if (item.ConditionField.EnumCollectedType != EnumCollectedType.And)
                    {
                        continue;
                    }
                    bool isNeed = EmployeeFieldPara.IsNeedCondition(item, _EmployeeList[i]);
                    if (!isNeed)
                    {
                        _EmployeeList.RemoveAt(i);
                        i--;
                        break;
                    }
                }
            }
        }

        protected override void DataSourceReady()
        {
            if (EmployeeFieldPara.DepartmentTreeDataSource == null)
            {
                EmployeeFieldPara.DepartmentTreeDataSource = _IDepartmentBll.GetAllDepartmentTree();
            }
        }
    }
}
