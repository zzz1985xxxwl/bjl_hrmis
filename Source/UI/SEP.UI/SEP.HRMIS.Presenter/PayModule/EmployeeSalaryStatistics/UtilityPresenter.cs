using System;
using System.Collections.Generic;
using System.Data;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics
{
    public class UtilityPresenter
    {
        public static DataTable TurnToEmployeeSalaryStatisticsDataTable
            (List<Model.PayModule.EmployeeSalaryStatistics> statistics, StatisticsTableTypeEnum statisticsTableTypeEnum)
        {
            DataTable ret_dt = new DataTable();
            if (statistics == null || statistics.Count == 0
                || statistics[0].EmployeeSalaryStatisticsItemList == null
                || statistics[0].EmployeeSalaryStatisticsItemList.Count == 0)
            {
                return ret_dt;
            }
            ret_dt.Columns.Add(".");
            ret_dt.Columns.Add("人数");
            foreach (EmployeeSalaryStatisticsItem item in statistics[0].EmployeeSalaryStatisticsItemList)
            {
                ret_dt.Columns.Add(item.ItemName);
            }
            foreach (Model.PayModule.EmployeeSalaryStatistics statistic in statistics)
            {
                DataRow dr = ret_dt.NewRow();
                if (statisticsTableTypeEnum == StatisticsTableTypeEnum.Department)
                {
                    dr[0] = statistic.Department.DepartmentName;
                    dr[1] = statistic.Department.AllMembers.Count;
                }
                if (statisticsTableTypeEnum == StatisticsTableTypeEnum.Position)
                {
                    dr[0] = statistic.Position.Name;
                    dr[1] = statistic.Position.Members.Count;
                }
                foreach (EmployeeSalaryStatisticsItem item in statistic.EmployeeSalaryStatisticsItemList)
                {
                    dr[item.ItemName] = decimal.Round(item.CalculateValue, 2, MidpointRounding.AwayFromZero);
                }
                ret_dt.Rows.Add(dr);
            }
            return ret_dt;
        }
        public static DataTable TurnToEmployeeSalaryAverageStatisticsDataTable
            (List<EmployeeSalaryAverageStatistics> statistics)
        {
            DataTable ret_dt = new DataTable();
            if (statistics == null || statistics.Count == 0)
            {
                return ret_dt;
            }
            foreach (EmployeeSalaryAverageStatistics statistic in statistics)
            {
                if (statistic.AverageItem == null
                    || statistic.EmployeeCountItem == null
                    || statistic.SumItem == null)
                {
                    return ret_dt;
                }
            }
            ret_dt.Columns.Add(".");
            ret_dt.Columns.Add(statistics[0].EmployeeCountItem.ItemName);
            ret_dt.Columns.Add(statistics[0].SumItem.ItemName);
            ret_dt.Columns.Add(statistics[0].AverageItem.ItemName);
            foreach (EmployeeSalaryAverageStatistics statistic in statistics)
            {
                DataRow dr = ret_dt.NewRow();
                dr[0] = statistic.Department.DepartmentName;
                dr[statistic.EmployeeCountItem.ItemName] =
                    Convert.ToSingle(decimal.Round(statistic.EmployeeCountItem.CalculateValue, 2, MidpointRounding.AwayFromZero));
                dr[statistic.SumItem.ItemName] =
                    Convert.ToSingle(decimal.Round(statistic.SumItem.CalculateValue, 2, MidpointRounding.AwayFromZero));
                dr[statistic.AverageItem.ItemName] =
                    Convert.ToSingle(decimal.Round(statistic.AverageItem.CalculateValue, 2, MidpointRounding.AwayFromZero));
                ret_dt.Rows.Add(dr);
            }
            return ret_dt;
        }

        public static DataTable TurnToEmployeeSalaryStatisticsDataTableTranspose
            (List<Model.PayModule.EmployeeSalaryStatistics> statistics)
        {
            DataTable ret_dt = new DataTable();
            if (statistics == null || statistics.Count == 0
                || statistics[0].EmployeeSalaryStatisticsItemList == null
                || statistics[0].EmployeeSalaryStatisticsItemList.Count == 0)
            {
                return ret_dt;
            }
            //定义列，首列为空
            ret_dt.Columns.Add(".");
            for (int i = 0; i < statistics.Count; i++)
            {
                //ret_dt.Columns.Add(statistics[i].SalaryDay.Year + "-" + statistics[i].SalaryDay.Month);
                ret_dt.Columns.Add(new HrmisUtility().StartMonthByYearMonth(statistics[i].SalaryDay).ToShortDateString());
            }
            //定义行
            for (int i = 0; i < statistics[0].EmployeeSalaryStatisticsItemList.Count; i++)
            {
                DataRow dr = ret_dt.NewRow();
                dr[0] = statistics[0].EmployeeSalaryStatisticsItemList[i].ItemName;
                ret_dt.Rows.Add(dr[0]);
            }
            //递归行
            for (int i = 0; i < statistics.Count; i++)
            {
                //递归列
                for (int j = 0; j < statistics[i].EmployeeSalaryStatisticsItemList.Count; j++)
                {
                    ret_dt.Rows[j][i + 1] =
                        Convert.ToSingle(
                            decimal.Round(statistics[i].EmployeeSalaryStatisticsItemList[j].CalculateValue, 2,
                                          MidpointRounding.AwayFromZero));
                }
            }
            return ret_dt;
        }

        public static DataTable get()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(" ");
            dt.Columns.Add("基本工资");
            dt.Columns.Add("奖金");
            dt.Columns.Add("税前工资");
            dt.Columns.Add("税后工资");
            DataRow dr = dt.NewRow();
            dr[0] = "实信集团";
            dr["基本工资"] = "3000";
            dr["奖金"] = "3000";
            dr["税前工资"] = "3000";
            dr["税后工资"] = "3000";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "实信集团";
            dr["基本工资"] = "3000";
            dr["奖金"] = "3000";
            dr["税前工资"] = "3000";
            dr["税后工资"] = "3000";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "实信集团";
            dr["基本工资"] = "3000";
            dr["奖金"] = "3000";
            dr["税前工资"] = "3000";
            dr["税后工资"] = "3000";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "实信集团";
            dr["基本工资"] = "3000";
            dr["奖金"] = "3000";
            dr["税前工资"] = "3000";
            dr["税后工资"] = "3000";
            dt.Rows.Add(dr);
            return dt;
        }

        public enum StatisticsTableTypeEnum
        {
            Department,
            Position,
            Summary
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
