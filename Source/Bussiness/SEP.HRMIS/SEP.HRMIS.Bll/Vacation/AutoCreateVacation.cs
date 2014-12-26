using System;
using System.Collections.Generic;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    ///<summary>
    /// ϵͳ�Զ����������Ϣ
    ///</summary>
    public class AutoCreateVacation
    {
        private DateTime _Date;
        private static GetEmployee getEmployee;
        private static IVacation _VacationDal = new VacationDal();
        private readonly int _CreateAnnualHolidayDay;
        private readonly int _CreateAnnualHolidayMonth;
        private readonly int _AnnualHolidayLow;
        private readonly int _AnnualHolidayHigh;
        private readonly int _DeferredMonths;
        ///<summary>
        ///</summary>
        ///<param name="date"></param>
        ///<param name="inComanyMonth"></param>
        ///<param name="createAnnualHolidayDay"></param>
        ///<param name="createAnnualHolidayMonth"></param>
        ///<param name="annualHolidayLow"></param>
        ///<param name="annualHolidayHigh"></param>
        ///<param name="deferredMonths"></param>
        public AutoCreateVacation(DateTime date, int createAnnualHolidayMonth, 
            int annualHolidayLow, int annualHolidayHigh, int deferredMonths, 
            int inComanyMonth, int createAnnualHolidayDay)
        {
            _Date = date;
            _CreateAnnualHolidayDay = createAnnualHolidayDay;
            _CreateAnnualHolidayMonth = createAnnualHolidayMonth;
            _AnnualHolidayLow = annualHolidayLow;
            _AnnualHolidayHigh = annualHolidayHigh;
            _DeferredMonths = deferredMonths;
            getEmployee=new GetEmployee();
        }


        ///<summary>
        /// for ��Ԫ����
        ///</summary>
        ///<param name="date"></param>
        ///<param name="inComanyMonth"></param>
        ///<param name="createAnnualHolidayDay"></param>
        ///<param name="createAnnualHolidayMonth"></param>
        ///<param name="annualHolidayLow"></param>
        ///<param name="annualHolidayHigh"></param>
        ///<param name="deferredMonths"></param>
        ///<param name="mockIVacation"></param>
        public AutoCreateVacation(DateTime date, int createAnnualHolidayMonth,
            int annualHolidayLow, int annualHolidayHigh, int deferredMonths,
            int inComanyMonth, int createAnnualHolidayDay,
            IVacation mockIVacation)
        {
            _Date = date;
            _CreateAnnualHolidayDay = createAnnualHolidayDay;
            _CreateAnnualHolidayMonth = createAnnualHolidayMonth;
            _AnnualHolidayLow = annualHolidayLow;
            _AnnualHolidayHigh = annualHolidayHigh;
            _DeferredMonths = deferredMonths;
            _VacationDal = mockIVacation;
        }
        ///<summary>
        /// for unit test
        ///</summary>
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
        }
        ///<summary>
        ///</summary>
        public void Excute()
        {
            //�õ�����Ա��
            List<Employee> allEmployeeList = getEmployee.GetAllEmployeeBasicInfo();
            //�����ÿ��������ٵĹ̶�����
            if (_Date.Month == _CreateAnnualHolidayMonth && _Date.Day == _CreateAnnualHolidayDay)
            {
                CreateAllVacation(allEmployeeList);
            }
            else //�ҳ������ڽ�����Ա�����ɵ�һ�����
            {
                CreatePartVacation(allEmployeeList);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="allEmployeeList"></param>
        public void CreatePartVacation(List<Employee> allEmployeeList)
        {
            string remark = "�����ڽ���ϵͳ�Զ����������Ϣ";
            foreach (Employee employee in allEmployeeList)
            {
                //ֻ����ʽ�������ڵ�Ա������������٣��������������
                if (employee.EmployeeType != EmployeeTypeEnum.NormalEmployee &&
                   employee.EmployeeType != EmployeeTypeEnum.ProbationEmployee )
                {
                    continue;
                }
                if (employee.EmployeeDetails == null ||
                    employee.EmployeeDetails.ProbationTime.Year == 1900 ||
                    employee.EmployeeDetails.ProbationStartTime.Year == 1900)
                {
                    continue;
                }
                DateTime probationStartTime = employee.EmployeeDetails.ProbationStartTime;
                //��������������ڽ�����
                if (employee.EmployeeDetails.ProbationTime.Date.AddDays(1) == _Date.Date)
                {
                    DateTime to;
                    //�����ӳٵ���ʱ��
                    DateTime deferredMonth = new DateTime(_Date.Year , _CreateAnnualHolidayMonth, _CreateAnnualHolidayDay).AddMonths(_DeferredMonths);
                    if (_Date.Date < deferredMonth)
                    {
                        to = deferredMonth;
                    }
                    else
                    {
                        to = deferredMonth.AddYears(1);
                    }
                    //������˾�յ�12/31������*6/12��
                    decimal vacationDayNum = _AnnualHolidayLow *
                        (decimal)(MarginMonth(probationStartTime, new DateTime(probationStartTime.AddYears(1).Year, 1, 1))) / 12;
                    
                    int vacationDayNumTemp = (int) (vacationDayNum*2);
                    vacationDayNum = (decimal) vacationDayNumTemp/2;

                    Model.Vacation vacation = new Model.Vacation(0, employee, vacationDayNum,
                        _Date.Date, to, 0, vacationDayNum, remark);
                    _VacationDal.Insert(vacation);
                }
            }
        }
        ///<summary>
        /// ������ʱ���������£��������12��������
        ///</summary>
        ///<param name="from"></param>
        ///<param name="to"></param>
        ///<returns></returns>
        public int MarginMonth(DateTime from,DateTime to)
        {
            for (int i = 1; i <= 12; i++)
            {
                if (from.AddMonths(i)>to)
                {
                    return i-1;
                }
            }
            return 12;
        }
        ///<summary>
        /// ÿ��̶������������
        ///</summary>
        ///<param name="allEmployeeList"></param>
        public void CreateAllVacation(List<Employee> allEmployeeList)
        {
            DateTime from=_Date.Date;
            DateTime to = from.AddYears(1).AddMonths(_DeferredMonths);
            string remark = "ϵͳÿ���Զ�������ټ�¼";
            foreach (Employee employee in allEmployeeList)
            {
                ////ֻ����ʽ�������ڵ�Ա������������٣��������������
                //if (employee.EmployeeType != EmployeeTypeEnum.NormalEmployee &&
                //    employee.EmployeeType != EmployeeTypeEnum.ProbationEmployee)
                //{
                //    continue;
                //}
                //ֻ����ʽ��Ա����������ÿ��12-21���Զ�������٣�������������� change by xwl 2014-12-26
                if (employee.EmployeeType != EmployeeTypeEnum.NormalEmployee)
                {
                    continue;
                }
                if (employee.EmployeeDetails == null ||
                    employee.EmployeeDetails.ProbationTime.Year == 1900 ||
                    employee.EmployeeDetails.ProbationStartTime.Year == 1900)
                {
                    continue;
                }
                decimal vacationDayNum = GetVacationDayNum(employee.EmployeeDetails.ProbationStartTime,
                    employee.EmployeeDetails.ProbationTime);

                Model.Vacation vacation = new Model.Vacation(0, employee, vacationDayNum, from, to, 0, vacationDayNum, remark);
                _VacationDal.Insert(vacation);
            }
        }
        ///<summary>
        /// �����Ա�����������
        ///</summary>
        ///<param name="comeDate"></param>
        ///<returns></returns>
        ///<param name="exercitationEnd"></param>
        public decimal GetVacationDayNum(DateTime comeDate, DateTime exercitationEnd)
        {
            TimeSpan ts = exercitationEnd - new DateTime(_Date.Year, 12, 31);
            //�����ÿ��̶��������ʱ��֮��Ϊ��һ��
            if (ts.Days >= 0)
            {
                return _AnnualHolidayLow;
            }
            else
            {
                decimal returnValue = _AnnualHolidayLow;
                decimal margin = _AnnualHolidayHigh - _AnnualHolidayLow;
                bool isAdded = false;
                for (int i = 1; i <= margin; i++)
                {
                    DateTime temp = exercitationEnd.AddYears(i);
                    if (DateTime.Compare(temp, new DateTime(_Date.Year, 12, 31)) >= 0)
                    {
                        returnValue = returnValue + i;
                        isAdded = true;
                        break;
                    }
                }
                if (isAdded)
                {
                    return returnValue;
                }
                else
                {
                    return _AnnualHolidayHigh;
                }
            }
        }
    }
}
