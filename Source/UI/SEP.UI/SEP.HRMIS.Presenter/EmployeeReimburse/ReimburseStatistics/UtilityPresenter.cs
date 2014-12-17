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
                ret_dt.Columns.Add("����");
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
                    if(dr[0].ToString()=="�ܼ�")
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
            ret_dt.Columns.Add("Ա������");
            ret_dt.Columns.Add("�·�");
            ret_dt.Columns.Add("��������");
            ret_dt.Columns.Add("��;");
            ret_dt.Columns.Add("��;");
            ret_dt.Columns.Add("ס��");
            ret_dt.Columns.Add("����Ӧ��");
            ret_dt.Columns.Add("���ڽ�ͨ��");
            ret_dt.Columns.Add("�ͷ�");
            ret_dt.Columns.Add("����");
            ret_dt.Columns.Add("�����");
            ret_dt.Columns.Add("С��");
            ret_dt.Columns.Add("�ͻ�����");
            ret_dt.Columns.Add("˵��");
            ret_dt.Columns.Add("��ע");
            ret_dt.Columns.Add("����ص�");
            ret_dt.Columns.Add("��������");
            ret_dt.Columns.Add("������Ŀ");
            ret_dt.Columns.Add("����ʱ��");
            ret_dt.Columns.Add("�鿴����");
            foreach (ReimburseTotal statistic in statistics)
            {
                DataRow dr = ret_dt.NewRow();
                dr["Ա������"] = statistic.Name;
                dr["�·�"] = statistic.Month;
                dr["��������"] = statistic.ReimburseCategories.Name;
                dr["��;"] = statistic.LongTripTotal;
                dr["��;"] = statistic.ShortTripTotal;
                dr["ס��"] = statistic.LodgingTotal;
                dr["����Ӧ��"] = statistic.EntertainmentTotal;
                dr["���ڽ�ͨ��"] = statistic.CityTrafficTotalCost;
                dr["�ͷ�"] = statistic.MealTotalCost;
                dr["����"] = statistic.OtherTotal;
                dr["�����"] = statistic.OutCityAllowance;
                dr["С��"] = statistic.Total;
                dr["�ͻ�����"] = statistic.CustomerName;
                dr["˵��"] = statistic.Discription;
                dr["��ע"] = statistic.Remark;
                dr["����ص�"] = statistic.Place;
                dr["��������"] = statistic.OutCityDays;
                dr["������Ŀ"] = statistic.Projuct;
                dr["����ʱ��"] = statistic.StartTime + "-" + statistic.EndTime;
                dr["�鿴����"] = "<a href='ReimburseIsTravelDetail.aspx?ReimburseID=" +
                          SecurityUtil.DECEncrypt(statistic.ReimburseID.ToString()) + "' target='_blank'>�鿴����</a>";
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

