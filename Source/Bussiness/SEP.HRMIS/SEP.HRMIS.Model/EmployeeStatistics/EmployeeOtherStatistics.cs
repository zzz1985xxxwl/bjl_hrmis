//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: EmployeeOtherStatistics.cs
// ������: yyb
// ��������: 2008-11-14
// ����: Ա��ͳ��
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class EmployeeOtherStatistics
    {
        #region ˽�б���

        private readonly List<Employee> _EmployeeList;
        private int _VocationCount;
        private int _ResidencePermitCount;
        private List<Employee> _ResidencePermitEmployeeList;
        private List<Employee> _VacationCountEmployeeList;
        private int _CityInsuranceCount;
        private int _TownInsuranceCount;
        private int _ComprehensiveInsuranceCount;
        #endregion

        public EmployeeOtherStatistics(List<Employee> employeeList)
        {
            _EmployeeList = employeeList;
        }

        #region ����

        /// <summary>
        /// ��ٵ���ͳ��
        /// </summary>
        public int VacationCount
        {
            get { return _VocationCount; }
            set { _VocationCount = value; }
        }



        /// <summary>
        /// ��ס֤����ͳ��
        /// </summary>
        public int ResidencePermitCount
        {
            get { return _ResidencePermitCount; }
            set { _ResidencePermitCount = value; }
        }


        /// <summary>
        /// ��ס֤������Ա�б�
        /// </summary>
        public List<Employee> ResidencePermitEmployeeList
        {
            get { return _ResidencePermitEmployeeList; }
            set { _ResidencePermitEmployeeList = value; }
        }

        /// <summary>
        /// ��ٵ�����Ա�б�
        /// </summary>
        public List<Employee> VacationCountEmployeeList
        {
            get { return _VacationCountEmployeeList; }
            set { _VacationCountEmployeeList = value; }
        }
        /// <summary>
        /// ���³��б��սɷ�����
        /// </summary>
        public int CityInsuranceCount
        {
            get { return _CityInsuranceCount; }
            set { _CityInsuranceCount = value; }
        }
        /// <summary>
        /// ���³����սɷ�����
        /// </summary>
        public int TownInsuranceCount
        {
            get { return _TownInsuranceCount; }
            set { _TownInsuranceCount = value; }
        }
        /// <summary>
        /// �����ۺϱ��սɷ�����
        /// </summary>
        public int ComprehensiveInsuranceCount
        {
            get { return _ComprehensiveInsuranceCount; }
            set { _ComprehensiveInsuranceCount = value; }
        }

        #endregion

        #region ����

        public void VocationStatistics()
        {
            VacationCount = 0;
            VacationCountEmployeeList = new List<Employee>();
            for (int i = 0; i < _EmployeeList.Count; i++)
            {
                bool ifVacation = false;

                DateTime monthFirstDay =
                    new DateTime(_EmployeeList[i].EmployeeDetails.StatisticsTime.Date.Year,
                                 _EmployeeList[i].EmployeeDetails.StatisticsTime.Date.Month, 1);
                DateTime nextMonthFirstDay = monthFirstDay.AddMonths(1).AddDays(-1);
                foreach (Vacation vacation in _EmployeeList[i].SocWorkAgeAndVacationList.EmployeeVacations)
                {
                    if ((DateTime.Compare(vacation.VacationEndDate, monthFirstDay) >= 0)
                        && (DateTime.Compare(vacation.VacationEndDate, nextMonthFirstDay) < 0))
                    {
                        ifVacation = true;
                    }
                }

                if (ifVacation)
                {
                    VacationCount++;
                    VacationCountEmployeeList.Add(_EmployeeList[i]);
                }
            }
        }

        /// <summary>
        /// �籣����
        /// </summary>
        public void InsuranceStatistics()
        {
            CityInsuranceCount = 0;
            TownInsuranceCount = 0;
            ComprehensiveInsuranceCount = 0;
            for (int i = 0; i < _EmployeeList.Count; i++)
            {
                DateTime monthFirstDay =
                    new DateTime(_EmployeeList[i].EmployeeDetails.StatisticsTime.Date.Year,
                                 _EmployeeList[i].EmployeeDetails.StatisticsTime.Date.Month, 1);

                EmployeeWelfareHistory history =
                    GetEmployeeWelfareHistory(_EmployeeList[i].EmployeeWelfareHistory, monthFirstDay);

                if (history != null && history.EmployeeWelfare != null)
                {
                    EmployeeSocialSecurity s = history.EmployeeWelfare.SocialSecurity;
                    if (s != null && s.Type.Id != SocialSecurityTypeEnum.Null.Id)
                    {
                        if (s.Type.Id == SocialSecurityTypeEnum.CityInsurance.Id)
                        {
                            CityInsuranceCount++;
                        }
                        else if (s.Type.Id == SocialSecurityTypeEnum.ComprehensiveInsurance.Id)
                        {
                            ComprehensiveInsuranceCount++;
                        }
                        else if (s.Type.Id == SocialSecurityTypeEnum.TownInsurance.Id)
                        {
                            TownInsuranceCount++;
                        }
                    }
                }
            }
        }

        private EmployeeWelfareHistory GetEmployeeWelfareHistory(List<EmployeeWelfareHistory> history, DateTime dt)
        {
            EmployeeWelfareHistory ret = null;
            for (int i = 0; i < history.Count; i++)
            {
                if (new DateTime(history[i].OperationTime.Year, history[i].OperationTime.Month, 1) > dt)
                {
                    break;
                }
                else
                {
                    ret = history[i];
                }
            }
            return ret;
        }

        public void ResidencePermitStatistics()
        {
            ResidencePermitCount = 0;
            ResidencePermitEmployeeList = new List<Employee>();
            for (int i = 0; i < _EmployeeList.Count; i++)
            {
                DateTime monthFirstDay =
                    new DateTime(_EmployeeList[i].EmployeeDetails.StatisticsTime.Date.Year,
                                 _EmployeeList[i].EmployeeDetails.StatisticsTime.Date.Month, 1);
                DateTime nextMonthFirstDay = monthFirstDay.AddMonths(1).AddDays(-1);
                if (_EmployeeList[i].EmployeeDetails.ResidencePermits != null)
                {
                    if (
                        (DateTime.Compare(_EmployeeList[i].EmployeeDetails.ResidencePermits.DueDate, monthFirstDay) >=
                         0)
                        &&
                        (DateTime.Compare(_EmployeeList[i].EmployeeDetails.ResidencePermits.DueDate,
                                          nextMonthFirstDay) < 0))
                    {
                        ResidencePermitCount++;
                        ResidencePermitEmployeeList.Add(_EmployeeList[i]);
                    }
                }
            }
        }

        #endregion

    }
}
