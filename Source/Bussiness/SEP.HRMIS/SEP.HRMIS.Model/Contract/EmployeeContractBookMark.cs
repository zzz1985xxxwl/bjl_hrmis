using System;
using System.Collections.Generic;
using AdvancedCondition;
using SEP.HRMIS.Model.AdvanceSearch;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 员工的合同标签
    /// </summary>
    [Serializable]
    public class EmployeeContractBookMark
    {
        private int _PKID;
        private int _EmployeeContractID;
        private string _BookMarkName;
        private string _BookMarkValue;
        /// <summary>
        /// 员工的合同标签构造函数
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="employeeContractID"></param>
        /// <param name="bookMarkName"></param>
        /// <param name="bookMarkValue"></param>
        public EmployeeContractBookMark(int pkid,int employeeContractID,string bookMarkName,string bookMarkValue)
        {
            _PKID = pkid;
            _EmployeeContractID = employeeContractID;
            _BookMarkName = bookMarkName;
            _BookMarkValue = bookMarkValue;
        }

        public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
        }
        /// <summary>
        /// 对应员工合同ID
        /// </summary>
        public int EmployeeContractID
        {
            get { return _EmployeeContractID; }
            set { _EmployeeContractID = value; }
        }
        /// <summary>
        /// 书签名
        /// </summary>
        public string BookMarkName
        {
            get { return _BookMarkName; }
            set { _BookMarkName = value; }
        }
        /// <summary>
        /// 书签值
        /// </summary>
        public string BookMarkValue
        {
            get { return _BookMarkValue; }
            set { _BookMarkValue = value; }
        }

        /// <summary>
        /// 初始化标签
        /// </summary>
        /// <param name="fieldNamecondition"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static string InitBookMarkValue(string fieldNamecondition, Employee employee)
        {
            return
                EmployeeFieldPara.GetSearchFieldValue(employee, ConvertStringToSearchField(fieldNamecondition)) ??
                string.Empty;
        }

        /// <summary>
        /// 比对标签中的字符串返回SearchField
        /// </summary>
        /// <param name="fieldNamecondition"></param>
        /// <returns></returns>
        private static SearchField ConvertStringToSearchField(string fieldNamecondition)
        {
            List<SearchField> searchFieldSource = EmployeeFieldPara.GetAllEmployeeSearchField();
            searchFieldSource.Add(EmployeeFieldPara.InitEmployeeSearchField_Responsibility());
            searchFieldSource.Add(EmployeeFieldPara.InitEmployeeSearchField_EmployeeWelfareDescription());
            if (searchFieldSource == null)
            {
                searchFieldSource = new List<SearchField>();
            }
            if (!string.IsNullOrEmpty(fieldNamecondition))
            {
                foreach (SearchField item in searchFieldSource)
                {
                    if (fieldNamecondition.Contains(item.FieldParaBase.FieldName))
                    {
                        return item;
                    }
                }
            }
            return null;
        }

    }
}
