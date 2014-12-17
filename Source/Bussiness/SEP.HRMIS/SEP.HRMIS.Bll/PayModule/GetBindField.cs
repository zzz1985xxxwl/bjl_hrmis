using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.AssessActivity;
using SEP.HRMIS.Bll.AttendanceStatistics;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics;
using SEP.HRMIS.Model.PayModule;
using SEP.IBll;
using SEP.IBll.SpecialDates;
using SEP.Model.SpecialDates;
using System.Linq;
using ParameterBase=SEP.HRMIS.Model.ParameterBase;

namespace SEP.HRMIS.Bll.PayModule
{
    /// <summary>
    /// ��ֵ��������ѡ��󶨣��Ա��ȡϵͳ���ݣ�
    /// ��٣��¼١����١���ǰ�١�����١����٣���
    /// �Ӱࡢ����ٵ���*�ι�*���ӣ������ˡ�������
    /// �籣������������������ۺϱ��ջ�����
    /// ˾�䡢���¿�������
    /// </summary>
    public class GetBindField
    {
        private readonly BindItemValueCollection _BindItemValueCollection;
        private GetEmployee _GetEmployee = new GetEmployee();
        private GetEmployeeAttendanceStatistics _GetEmployeeAttendanceStatistics = new GetEmployeeAttendanceStatistics();
        private GetEmployeeWelfare _GetEmployeeWelfare = new GetEmployeeWelfare();
        private ISpecialDateBll _ISpecialDateBll = BllInstance.SpecialDateBllInstance;
        private readonly IPlanDutyDal _PlanDutyDal = DalFactory.DataAccess.CreatePlanDutyDal();
        /// <summary>
        /// ���캯��
        /// </summary>
        public GetBindField()
        {
            _BindItemValueCollection = new BindItemValueCollection();
            _BindItemValueCollection.CreateAllBindItemsExceptNull();
        }

        #region ����

        /// <summary>
        /// ����
        /// </summary>
        public GetEmployee MockGetEmployee
        {
            set { _GetEmployee = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public GetEmployeeAttendanceStatistics MockGetEmployeeAttendanceStatistics
        {
            set { _GetEmployeeAttendanceStatistics = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public GetEmployeeWelfare MockGetEmployeeWelfare
        {
            set { _GetEmployeeWelfare = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public ISpecialDateBll MockISpecialDateBll
        {
            set { _ISpecialDateBll = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public BindItemValueCollection BindItemValueCollectionForTest
        {
            get { return _BindItemValueCollection; }
        }

        #endregion

        /// <summary>
        /// ��ð�ֵ��Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="startDt"></param>
        /// <param name="endDt"></param>
        /// <returns></returns>
        public BindItemValueCollection BindItemValueCollection(int accountID, DateTime startDt, DateTime endDt)
        {
            GetEmployeeAttendanceInfo(accountID, startDt, endDt);
            GetEmployeeWelfareforBase(accountID);
            GetEmpoloyeeWorkAge(accountID, endDt);
            GetAnualPerfomanceResultByAccountId(accountID, startDt);
            GetEmployeePassMonth(accountID, endDt);
            return _BindItemValueCollection;
        }

        /// <summary>
        /// ����ȡGetEmployeePassMonth����
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="endDt"></param>
        /// <returns></returns>
        public BindItemValueCollection GetEmployeePassMonthBindField(int accountID, DateTime endDt)
        {
            GetEmployeePassMonth(accountID, endDt);
            return _BindItemValueCollection;
        }

        #region �����������

        /// <summary>
        /// �¼٣����٣���ǰ�٣�����٣������
        /// ��ͨ�Ӱ࣬�ڼ��ռӰ࣬˫�ݼӰ�
        /// �ٵ������ˡ�����
        /// ���³����� ��ְ���� δ��ְ����
        /// </summary>
        public void GetEmployeeAttendanceInfo(int accountID, DateTime startDt, DateTime endDt)
        {
            Employee employee =
                _GetEmployeeAttendanceStatistics.GetEmployeeAttendanceByCondition(accountID, startDt, endDt);
            if (employee != null)
            {
                employee.EmployeeAttendance.MonthAttendance = new MonthAttendance();
                employee.EmployeeAttendance.MonthAttendanceCaculateLeaveInfo();
                employee.EmployeeAttendance.MonthAttendanceCaculateOvertimeInfo();
                employee.EmployeeAttendance.MonthAttendanceCaculateArriveLeaveInfo();
                employee.EmployeeAttendance.MonthAttendanceCaculateOnDutyDays();
                employee.EmployeeAttendance.MonthAttendanceCaculateOutCityInfo();
                
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.ChanJiaOnDuty,
                                                          employee.EmployeeAttendance.MonthAttendance.
                                                              DaysofOnDutyMaternityLeave);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.ShiJia,
                                                          employee.EmployeeAttendance.MonthAttendance.
                                                              DaysofPersonalReasonLeave);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.BingJia,
                                                          employee.EmployeeAttendance.MonthAttendance.DaysofSickLeave);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.ChanQianJia,
                                                          employee.EmployeeAttendance.MonthAttendance.
                                                              DaysofPrenatalLeave);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.ChanJia,
                                                          employee.EmployeeAttendance.MonthAttendance.
                                                              DaysofMaternityLeave);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.BuRuJia,
                                                          employee.EmployeeAttendance.MonthAttendance.
                                                              DaysofBreastFeedLeave);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.PuTongOverTime,
                                                          employee.EmployeeAttendance.MonthAttendance.
                                                              DaysofCommonOvertime);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.ShuangXiuOverTime,
                                                          employee.EmployeeAttendance.MonthAttendance.
                                                              DaysofWeekendOvertime);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.JieRiOverTime,
                                                          employee.EmployeeAttendance.MonthAttendance.
                                                              DaysofHolidayOvertime);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.Absenteeism,
                                                          employee.EmployeeAttendance.MonthAttendance.
                                                              DaysofNoReasonLeave);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.LeaveEarly,
                                                          employee.EmployeeAttendance.MonthAttendance.LeaveEarly.
                                                              TotalData);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.BeLate,
                                                          employee.EmployeeAttendance.MonthAttendance.ArriveLate.
                                                              TotalData);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.OnDutyDays,
                                                          employee.EmployeeAttendance.MonthAttendance.ActualOnDutyDays);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.ExpectedOnDutyDays,
                                                          employee.EmployeeAttendance.MonthAttendance.ExpectedOnDutyDays);

                _BindItemValueCollection.SetBindItemValue(BindItemEnum.PuTongOverTimeNotAdjust,
                                                          employee.EmployeeAttendance.MonthAttendance.
                                                              DaysofCommonOvertimeNotAdjust);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.ShuangXiuOverTimeNotAdjust,
                                                          employee.EmployeeAttendance.MonthAttendance.
                                                              DaysofWeekendOvertimeNotAdjust);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.JieRiOverTimeNotAdjust,
                                                          employee.EmployeeAttendance.MonthAttendance.
                                                              DaysofHolidayOvertimeNotAdjust);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.OutCityDays,
                                                          employee.EmployeeAttendance.MonthAttendance.DaysofOutCity);
                CalcNotOnDutyDays(accountID, startDt, endDt);
            }
        }

        /// <summary>
        /// ��ְ���� δ��ְ����
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="startDt"></param>
        /// <param name="endDt"></param>
        public void CalcNotOnDutyDays(int accountID, DateTime startDt, DateTime endDt)
        {
            decimal _weiRuZhiDay = 0;
            decimal _liZhiDay = 0;
            Employee employee = _GetEmployee.GetEmployeeBasicInfoByAccountID(accountID);

            if (employee != null && employee.EmployeeDetails != null && employee.EmployeeDetails.Work != null)
            {
                var planduty = _PlanDutyDal.GetPlanDutyDetailByAccount(accountID, startDt, endDt);
                List<SpecialDate> specialDateList = _ISpecialDateBll.GetSpecialDateByFromAndToDate(startDt, endDt);
                CalculateDays calculateDays = new CalculateDays(specialDateList);
                DateTime comeDate = employee.EmployeeDetails.Work.ComeDate.AddDays(-1);
                if (comeDate < startDt)
                {
                    _weiRuZhiDay = 0;
                }
                else
                {
                    calculateDays.StartDate = startDt;
                    calculateDays.EndDate = comeDate <= endDt ? comeDate : endDt;
                    _weiRuZhiDay = calculateDays.CountDaySpecial();
                }

                if (employee.EmployeeDetails.Work.DimissionInfo != null)
                {
                    DateTime dimissionDate = employee.EmployeeDetails.Work.DimissionInfo.DimissionDate.AddDays(1);
                    if (dimissionDate > endDt)
                    {
                        _liZhiDay = 0;
                    }
                    else
                    {
                        var startDate = dimissionDate >= startDt ? dimissionDate : startDt;
                        var endDate = endDt;
                        for (DateTime dt = startDate.Date; dt <= endDate.Date; )
                        {
                            var pd=planduty.Where(x => x.Date.Date==dt.Date).FirstOrDefault();
                            if(!pd.PlanDutyClass.IsWeek)
                            {
                                _liZhiDay++;
                            }
                            dt = dt.AddDays(1);
                        }
                    }
                }
            }
            _BindItemValueCollection.SetBindItemValue(BindItemEnum.NotEntryDays, _weiRuZhiDay);
            _BindItemValueCollection.SetBindItemValue(BindItemEnum.DimissionDays, _liZhiDay);
        }

        #endregion

        #region �����ջ��������б��ջ������ۺϱ��ջ�������������������Ͻɷѻ�����ʧҵ�ɷѻ�����ҽ�ƽɷѻ���

        /// <summary>
        /// �����ջ��������б��ջ������ۺϱ��ջ�������������������乫�������
        /// </summary>
        /// <param name="accountID"></param>
        public void GetEmployeeWelfareforBase(int accountID)
        {
            EmployeeWelfare employeeWelfare = _GetEmployeeWelfare.GetEmployeeWelfareByAccountID(accountID);
            if (employeeWelfare != null)
            {
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.TownInsuranceBase,
                                                          GetSocialSecurityBaseByType(employeeWelfare,
                                                                                      SocialSecurityTypeEnum.
                                                                                          TownInsurance));
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.BlanketInsuranceBase,
                                                          GetSocialSecurityBaseByType(employeeWelfare,
                                                                                      SocialSecurityTypeEnum.
                                                                                          ComprehensiveInsurance));
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.CityInsuranceBase,
                                                          GetSocialSecurityBaseByType(employeeWelfare,
                                                                                      SocialSecurityTypeEnum.
                                                                                          CityInsurance));
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.AccumulationFundBase,
                                                          GetAccumulationFundBase(employeeWelfare));
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.AccumulationFundSupplyBase,
                                                          GetAccumulationFundSupplyBase(employeeWelfare));
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.YangLaoBase,
                                                          employeeWelfare.SocialSecurity.YangLaoBase.HasValue
                                                              ? Convert.ToDecimal(
                                                                    employeeWelfare.SocialSecurity.YangLaoBase)
                                                              : 0);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.ShiYeBase,
                                                          employeeWelfare.SocialSecurity.ShiYeBase.HasValue
                                                              ? Convert.ToDecimal(
                                                                    employeeWelfare.SocialSecurity.ShiYeBase)
                                                              : 0);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.YiLiaoBase,
                                                          employeeWelfare.SocialSecurity.YiLiaoBase.HasValue
                                                              ? Convert.ToDecimal(
                                                                    employeeWelfare.SocialSecurity.YiLiaoBase)
                                                              : 0);
            }
        }

        /// <summary>
        /// ���������
        /// </summary>
        private static decimal GetAccumulationFundBase(EmployeeWelfare employeeWelfare)
        {
            if (employeeWelfare != null)
            {
                if (employeeWelfare.AccumulationFund != null)
                {
                    if (employeeWelfare.AccumulationFund.Base != null)
                    {
                        return Convert.ToDecimal(employeeWelfare.AccumulationFund.Base);
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// ���乫�������
        /// </summary>
        private static decimal GetAccumulationFundSupplyBase(EmployeeWelfare employeeWelfare)
        {
            if (employeeWelfare != null)
            {
                if (employeeWelfare.AccumulationFund != null)
                {
                    if (employeeWelfare.AccumulationFund.SupplyBase != null)
                    {
                        return Convert.ToDecimal(employeeWelfare.AccumulationFund.SupplyBase);
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// �����ջ��������б��ջ������ۺϱ��ջ���
        /// </summary>
        /// <param name="employeeWelfare"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static decimal GetSocialSecurityBaseByType(EmployeeWelfare employeeWelfare, ParameterBase type)
        {
            if (employeeWelfare != null)
            {
                if (employeeWelfare.SocialSecurity != null)
                {
                    if (employeeWelfare.SocialSecurity.Base != null)
                    {
                        if (employeeWelfare.SocialSecurity.Type.Name == type.Name)
                        {
                            return Convert.ToDecimal(employeeWelfare.SocialSecurity.Base);
                        }
                    }
                }
            }
            return 0;
        }

        #endregion

        #region ˾��

        /// <summary>
        /// ��ȡԱ��˾��
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="endTime"></param>
        /// <returns>����</returns>
        public void GetEmpoloyeeWorkAge(int accountID, DateTime endTime)
        {
            Employee temp = _GetEmployee.GetEmployeeBasicInfoByAccountID(accountID);
            if (temp != null && temp.EmployeeDetails != null && temp.EmployeeDetails.Work != null)
            {
                TimeSpan ts = endTime.Subtract(temp.EmployeeDetails.Work.ComeDate);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.WorkAge, ts.Days);
            }
        }

        #endregion

        #region ���������·� ȥ��������������·�

        /// <summary>
        /// ���������·� ��������Ա�������·ݶ��壺����������ĵ�һ����Ȼ�µ���ǰ�·ݵ�����
        /// ȥ��������������·� ��������Ա�������·ݶ��壺����������ĵ�һ����Ȼ�µ�ȥ����׵�����
        /// ���������·��û�����
        /// �����ڵ�����	��ǰ�·�	����������ĵ�һ����Ȼ��	���������·�    ȥ��������������·�
        /// 2008-7-1	    2008-12-20	2008-8-1	                5               0
        /// 2008-7-31	    2008-12-20	2008-8-1	                5               0
        /// 2008-7-5	    2008-12-20	2008-8-1	                5               0
        /// 2007-7-5	    2008-12-20	2007-8-1	                17              5
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public void GetEmployeePassMonth(int accountID, DateTime endTime)
        {
            Employee temp = _GetEmployee.GetEmployeeBasicInfoByAccountID(accountID);
            if (temp != null && temp.EmployeeDetails != null)
            {
                DateTime dt1 =
                    new DateTime(temp.EmployeeDetails.ProbationTime.Year, temp.EmployeeDetails.ProbationTime.Month, 1).
                        AddMonths(1);
                DateTime dt2 = new DateTime(endTime.Year, endTime.Month, 1).AddMonths(1);
                //���������·�
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.ProbationPassMonth,
                                                          CalculatePassMonthData(dt1, dt2));
                //ȥ��������������·�
                dt2 = new DateTime(endTime.Year, 1, 1);
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.LastYearProbationPassMonth,
                                                          CalculatePassMonthData(dt1, dt2));
                //��ְ������
                if (temp.EmployeeDetails.Work != null)
                {
                    dt1 =
                        new DateTime(temp.EmployeeDetails.Work.ComeDate.Year,
                                     temp.EmployeeDetails.Work.ComeDate.Month,
                                     1).AddMonths(1);
                    dt2 = new DateTime(endTime.Year, endTime.Month, 1).AddMonths(1);
                    _BindItemValueCollection.SetBindItemValue(BindItemEnum.ComeDatePassMonth,
                                                              CalculatePassMonthData(dt1, dt2));
                }
            }
        }

        private static int CalculatePassMonthData(DateTime startDate, DateTime endDate)
        {
            int result = endDate.Year*12 + endDate.Month - startDate.Year*12 - startDate.Month;
            if (result < 0 || result > 1000) //����1900-1-1�����
            {
                return 0;
            }
            return result;
        }

        #endregion

        #region ���ռ�Ч���˽��

        ///<summary>
        /// ��ȡ���տ�������
        ///</summary>
        ///<param name="accountID"></param>
        ///<param name="salaryTime"></param>
        public void GetAnualPerfomanceResultByAccountId(int accountID, DateTime salaryTime)
        {
            Model.AssessActivity activity =
                new GetAssessActivity().GetAnualPerfomanceResultByAccountId(accountID, salaryTime);
            if (activity != null && activity.ItsAssessActivityPaper != null)
            {
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.AnnualPerfomanceResult,
                                                          activity.ItsAssessActivityPaper.Score);
            }
            else
            {
                _BindItemValueCollection.SetBindItemValue(BindItemEnum.AnnualPerfomanceResult, 0);
            }
        }

        #endregion
    }
}