using System;
using System.Collections.Generic;
using System.Data;
using SEP.HRMIS.Model;
using ShiXin.Security;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseStatistics
{
    public class UtilityPresenter
    {
        public static DataTable TurnToEmployeeReimburseStatisticsDataTable
            (List<EmployeeReimburseStatistics> statistics, StatisticsTableTypeEnum statisticsTableTypeEnum)
        {
            int employeeCount=0;
            DataTable ret_dt = new DataTable();
            if (statistics == null || statistics.Count == 0
                || statistics[0].EmployeeReimburseStatisticsItemList == null
                || statistics[0].EmployeeReimburseStatisticsItemList.Count == 0)
            {
                return ret_dt;
            }
            ret_dt.Columns.Add(".");
            if (statisticsTableTypeEnum == StatisticsTableTypeEnum.Department)
            {
                ret_dt.Columns.Add("人数");
            }
            foreach (EmployeeReimburseStatisticsItem item in statistics[0].EmployeeReimburseStatisticsItemList)
            {
                ret_dt.Columns.Add(item.ItemName);
            }
            foreach (EmployeeReimburseStatistics statistic in statistics)
            {
                DataRow dr = ret_dt.NewRow();
                if (statisticsTableTypeEnum == StatisticsTableTypeEnum.Department)
                {
                    dr[0] = statistic.Department.DepartmentName;
                    dr[1] = statistic.Department.Members.Count;
                    if(dr[0].ToString()=="总计")
                    {
                        dr[1] = employeeCount;
                    }
                    employeeCount += statistic.Department.Members.Count;
                }
                else
                {
                    dr[0] = statistic.Employee.Account.Name;
                }
                foreach (EmployeeReimburseStatisticsItem item in statistic.EmployeeReimburseStatisticsItemList)
                {
                    dr[item.ItemName] = decimal.Round(item.CalculateValue, 2, MidpointRounding.AwayFromZero);
                }
                ret_dt.Rows.Add(dr);
            }
            return ret_dt;
        }
        public static DataTable TurnToSearchReimburseDataTable(List<ReimburseTotal> statistics)
        {
            DataTable ret_dt = new DataTable();
            if (statistics == null || statistics.Count == 0)
            {
                return ret_dt;
            }
            ret_dt.Columns.Add("员工姓名");
            ret_dt.Columns.Add("月份");
            ret_dt.Columns.Add("报销类型");
            ret_dt.Columns.Add("长途");
            ret_dt.Columns.Add("短途");
            ret_dt.Columns.Add("住宿");
            ret_dt.Columns.Add("交际应酬");
            ret_dt.Columns.Add("市内交通费");
            ret_dt.Columns.Add("餐费");
            ret_dt.Columns.Add("其他");
            ret_dt.Columns.Add("出差补贴");
            ret_dt.Columns.Add("小计");
            ret_dt.Columns.Add("客户名称");
            ret_dt.Columns.Add("说明");
            ret_dt.Columns.Add("备注");
            ret_dt.Columns.Add("出差地点");
            ret_dt.Columns.Add("出差天数");
            ret_dt.Columns.Add("出差项目");
            ret_dt.Columns.Add("出差时间");
            ret_dt.Columns.Add("查看详情");
            foreach (ReimburseTotal statistic in statistics)
            {
                DataRow dr = ret_dt.NewRow();
                dr["员工姓名"] = statistic.Name;
                dr["月份"] = statistic.Month;
                dr["报销类型"] = statistic.ReimburseCategories.Name;
                dr["长途"] = statistic.LongTripTotal;
                dr["短途"] = statistic.ShortTripTotal;
                dr["住宿"] = statistic.LodgingTotal;
                dr["交际应酬"] = statistic.EntertainmentTotal;
                dr["市内交通费"] = statistic.CityTrafficTotalCost;
                dr["餐费"] = statistic.MealTotalCost;
                dr["其他"] = statistic.OtherTotal;
                dr["出差补贴"] = statistic.OutCityAllowance;
                dr["小计"] = statistic.Total;
                dr["客户名称"] = statistic.CustomerName;
                dr["说明"] = statistic.Discription;
                dr["备注"] = statistic.Remark;
                dr["出差地点"] = statistic.Place;
                dr["出差天数"] = statistic.OutCityDays;
                dr["出差项目"] = statistic.Projuct;
                dr["出差时间"] = statistic.StartTime + "-" + statistic.EndTime;
                dr["查看详情"] = "<a href='ReimburseIsTravelDetail.aspx?ReimburseID=" +
                          SecurityUtil.DECEncrypt(statistic.ReimburseID.ToString()) + "' target='_blank'>查看详情</a>";
                ret_dt.Rows.Add(dr);
            }
            return ret_dt;
        }


        public enum StatisticsTableTypeEnum
        {
            Department,
            Summary,
            Employee
        }

        public static void RemoveRowsByCondition(DataTable dt, string colname, string value)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][colname].ToString() == value)
                {
                    dt.Rows.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}

