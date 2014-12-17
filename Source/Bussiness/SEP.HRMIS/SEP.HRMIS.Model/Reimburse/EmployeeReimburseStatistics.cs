using System;
using System.Collections.Generic;

using SEP.Model.Departments;

namespace SEP.HRMIS.Model
{
    public class EmployeeReimburseStatistics
    {
        private Department _Department;
        private Employee _Employee;

        private DateTime _ReimburseFromDay;
        private DateTime _ReimburseToDay;

        private List<EmployeeReimburseStatisticsItem> _EmployeeReimburseStatisticsItemList;

        public EmployeeReimburseStatistics()
        {
            _EmployeeReimburseStatisticsItemList = new List<EmployeeReimburseStatisticsItem>();

            //item项为报销中的费用类型项
            List<string> itemList = ReimburseItem.GetReimburseTypeEnumListTravel();
            foreach(string item in itemList)
            {
                _EmployeeReimburseStatisticsItemList.Add(new EmployeeReimburseStatisticsItem(item));
            }
        }

        public Department Department
        {
            get { return _Department; }
            set { _Department = value; }
        }
        public Employee Employee
        {
            get { return _Employee; }
            set { _Employee = value; }
        }
        public List<EmployeeReimburseStatisticsItem> EmployeeReimburseStatisticsItemList
        {
            get { return _EmployeeReimburseStatisticsItemList; }
            set { _EmployeeReimburseStatisticsItemList = value; }
        }

        public DateTime ReimburseFromDay
        {
            get { return _ReimburseFromDay; }
            set { _ReimburseFromDay = value; }
        }
        public DateTime ReimburseToDay
        {
            get { return _ReimburseToDay; }
            set { _ReimburseToDay = value; }
        }
    }
}
