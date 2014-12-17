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
    /// 高级查询合同
    /// </summary>
    public class ContractDoSearch: DoSearch
    {
        private IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        private readonly List<SearchField> _SearchFieldList;
        private readonly List<Contract> _ContractList;
        /// <summary>
        /// 为测试
        /// </summary>
        public IDepartmentBll MockIDepartmentBll
        {
            set { _IDepartmentBll = value; }
        }
        /// <summary>
        /// 获得检索后的Contract列表
        /// </summary>
        public List<Contract> ContractList
        {
            get { return _ContractList; }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="contractList"></param>
        /// <param name="searchFieldList"></param>
        public ContractDoSearch(List<Contract> contractList, List<SearchField> searchFieldList)
        {
            _ContractList = contractList;
            _SearchFieldList = searchFieldList;
        }

        protected override void DoOrCompare()
        {
            for (int i = 0; i < _ContractList.Count; i++)
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
                    isNeedOne = ContractFieldPara.IsNeedCondition(item, _ContractList[i]);
                    if (isNeedOne)
                    {
                        break;
                    }
                }
                if (isExistOr && !isNeedOne)
                {
                    _ContractList.RemoveAt(i);
                    i--;
                }
            }
        }

        protected override void DoAndCompare()
        {
            for (int i = 0; i < _ContractList.Count; i++)
            {
                foreach (SearchField item in _SearchFieldList)
                {
                    if (item.ConditionField.EnumCollectedType != EnumCollectedType.And)
                    {
                        continue;
                    }
                    bool isNeed = ContractFieldPara.IsNeedCondition(item, _ContractList[i]);
                    if (!isNeed)
                    {
                        _ContractList.RemoveAt(i);
                        i--;
                        break;
                    }
                }
            }
        }

        protected override void DataSourceReady()
        {
            if (ContractFieldPara.DepartmentTreeDataSource == null)
            {
                ContractFieldPara.DepartmentTreeDataSource = _IDepartmentBll.GetAllDepartmentTree();
            }
        }
    }
}
