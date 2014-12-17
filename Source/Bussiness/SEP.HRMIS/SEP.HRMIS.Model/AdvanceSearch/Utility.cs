using System;
using System.Collections.Generic;
using AdvancedCondition;
using AdvancedCondition.Enums;
using SEPModel = SEP.Model;

namespace SEP.HRMIS.Model.AdvanceSearch
{
    /// <summary>
    /// 高级查询通用方法
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// 部门转换成Tree格式
        /// </summary>
        /// <param name="departmentTree"></param>
        /// <param name="departmentList"></param>
        public static void ConvertDepartmentToTree(Tree departmentTree, List<SEPModel.Departments.Department> departmentList)
        {
            foreach (SEPModel.Departments.Department item in departmentList)
            {
                Tree treeitem = new Tree(item.Id, item.Name);
                ConvertDepartmentToTree(treeitem, item.ChildDept);
                departmentTree.ChildTrees.Add(treeitem);
            }
        }
        /// <summary>
        /// 用于界面层传来的字符串解释
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        /// <param name="sourceSearchField"></param>
        public static List<SearchField> ConvertStringToSearchFieldList(string conditions, List<SearchField> sourceSearchField)
        {
            List<SearchField> searchFieldList = new List<SearchField>();
            foreach (string condition in conditions.Split('|'))
            {
                if (!string.IsNullOrEmpty(condition) && condition.Split('&').Length == 6)
                {
                    string[] conditionitems = condition.Split('&');
                    SearchField item = SearchField.GetFieldParaByFieldName(sourceSearchField, conditionitems[0]);
                    if (item == null)
                    {
                        continue;
                    }
                    item.ConditionField.EnumCompareType = (EnumCompareType)Convert.ToInt32(conditionitems[1]);
                    item.ConditionField.ConditionExpression = conditionitems[2];
                    item.ConditionField.IsInvert = Convert.ToBoolean(conditionitems[3]);
                    item.ConditionField.EnumCollectedType = (EnumCollectedType)Convert.ToInt32(conditionitems[4]);
                    searchFieldList.Add(item);
                }
            }
            return searchFieldList;
        }

    }
}
