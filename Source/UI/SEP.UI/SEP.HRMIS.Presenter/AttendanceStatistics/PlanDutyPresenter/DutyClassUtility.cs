using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter;

namespace SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter
{
    public class DutyClassUtility
    {
        private readonly IDutyClassView _View;
        private IPlanDutyFacade _IPlanDutyFacade = InstanceFactory.CreatePlanDutyFacade();

        public DutyClassUtility(IDutyClassView view)
        {
            _View = view;
        }
        /// <summary>
        /// 初始化固定的界面信息，将报错信息赋空，绑定下拉列表中的可选时间
        /// </summary>
        public void InitTheViewToDefault()
        {
            _View.AbsentEarlyLeaveMessage = string.Empty;
            _View.AbsentEarlyLeaveTime = string.Empty;
            _View.AbsentLateMessage = string.Empty;
            _View.AbsentLateTime = string.Empty;
            _View.EarlyLeaveMessage = string.Empty;
            _View.EarlyLeaveTime = string.Empty;
            _View.LateMessage = string.Empty;
            _View.LateTime = string.Empty;

            _View.Message = string.Empty;
            _View.DutyClassName = string.Empty;
            _View.DutyClassNameMessage = string.Empty;
            _View.WorkTimeMessage = string.Empty;
            _View.HoursSource = Hours();
            _View.MinutesSource = Minutes();
        }

        /// <summary>
        /// 将界面上的信息赋值给rule
        /// </summary>
        public void CompleteTheObject(DutyClass rule)
        {
            if(rule!=null)
            {
                rule.LateTime = Convert.ToInt32(_View.LateTime);
                rule.EarlyLeaveTime = Convert.ToInt32(_View.EarlyLeaveTime);
                rule.AbsentEarlyLeaveTime = Convert.ToInt32(_View.AbsentEarlyLeaveTime);
                rule.AbsentLateTime = Convert.ToInt32(_View.AbsentLateTime);
                rule.FirstStartFromTime = Convert.ToDateTime(_View.FirstStartFromTime);
                rule.FirstStartToTime = Convert.ToDateTime(_View.FirstStartToTime);
                rule.FirstEndTime = Convert.ToDateTime(_View.FirstEndTime); 
                rule.SecondStartTime = Convert.ToDateTime(_View.SecondStartTime);
                rule.SecondEndTime = Convert.ToDateTime(_View.SecondEndTime);

                rule.DutyClassName = _View.DutyClassName.Trim();
            }
        }
        /// <summary>
        /// 验证信息
        /// </summary>
        public bool Validate()
        {
            _View.EarlyLeaveMessage = string.Empty;
            _View.LateMessage = string.Empty;
            _View.DutyClassNameMessage = string.Empty;
            _View.WorkTimeMessage = string.Empty;
            bool value = true;
            if (string.IsNullOrEmpty(_View.DutyClassName.Trim()))
            {
                _View.DutyClassNameMessage = "班别名称不可为空";
                value= false;
            }

            #region 上班时间
            DateTime temp1, temp2, temp3;
            if(!DateTime.TryParse(_View.FirstStartFromTime,out temp1))
            {
                _View.WorkTimeMessage = "上下班时间设置不正确";
                value= false;
            }
            if (!DateTime.TryParse(_View.FirstStartToTime, out temp2))
            {
                _View.WorkTimeMessage = "上下班时间设置不正确";
                value= false;
            }
            if (!DateTime.TryParse(_View.FirstEndTime, out temp3))
            {
                _View.WorkTimeMessage = "上下班时间设置不正确";
                value = false;
            }
            //判断上午上班时间是不是早于上午下班时间
            if (temp1 > temp2 || temp2 > temp3)
            {
                _View.WorkTimeMessage = "上下班时间设置不正确";
                value= false; 
            }
            if (!DateTime.TryParse(_View.SecondStartTime, out temp1))
            {
                _View.WorkTimeMessage = "上下班时间设置不正确";
                value= false;
            }
            //判断下午上班时间是不是晚于上午下班时间
            if(temp3>temp1)
            {
                _View.WorkTimeMessage = "上下班时间设置不正确";
                value= false;
            }
            if (!DateTime.TryParse(_View.SecondEndTime, out temp2))
            {
                _View.WorkTimeMessage = "上下班时间设置不正确";
                value= false;
            }
            //判断下午上班时间是不是晚于下午下班时间
            if (temp1 > temp2)
            {
                _View.WorkTimeMessage = "上下班时间设置不正确";
                value= false;
            }
            #endregion
            int temp;
            if(!Int32.TryParse(_View.AbsentLateTime,out temp))
            {
                _View.AbsentLateMessage = "格式设置不正确";
                value= false;
            }
            if(temp<=0||temp>=240)
            {
                _View.AbsentLateMessage = "格式设置不正确";
                value= false;
            }
            if (!Int32.TryParse(_View.AbsentEarlyLeaveTime, out temp))
            {
                _View.AbsentEarlyLeaveMessage = "格式设置不正确";
                value= false;
            }
            if (temp <= 0 || temp >= 240)
            {
                _View.AbsentEarlyLeaveMessage = "格式设置不正确";
                value= false;
            }
            if (!Int32.TryParse(_View.LateTime, out temp))
            {
                _View.LateMessage = "格式设置不正确";
                value = false;
            }
            if (temp < 0 || temp >= 240)
            {
                _View.LateMessage = "格式设置不正确";
                value = false;
            }
            if (!Int32.TryParse(_View.EarlyLeaveTime, out temp))
            {
                _View.EarlyLeaveMessage = "格式设置不正确";
                value = false;
            }
            if (temp < 0 || temp >= 240)
            {
                _View.EarlyLeaveMessage = "格式设置不正确";
                value = false;
            }
            return value;
        }
        /// <summary>
        /// 绑定界面上的信息
        /// </summary>
        public bool DataBind(string ruleId)
        {
            int id;
            if (!int.TryParse(ruleId, out id))
            {
                _View.Message = "初始化错误";
                return false;
            }
            DutyClass rule = _IPlanDutyFacade.GetDutyClassByPKID(id);
            if (rule != null)
            {
                _View.DutyClassId = rule.DutyClassID.ToString();
                _View.DutyClassName = rule.DutyClassName;
                _View.FirstStartFromTime = rule.FirstStartFromTime.ToString();
                _View.FirstStartToTime = rule.FirstStartToTime.ToString();
                _View.FirstEndTime = rule.FirstEndTime.ToString();
                _View.SecondStartTime = rule.SecondStartTime.ToString();
                _View.SecondEndTime = rule.SecondEndTime.ToString();

                _View.LateTime = rule.LateTime.ToString();
                _View.EarlyLeaveTime = rule.EarlyLeaveTime.ToString();
                _View.AbsentEarlyLeaveTime = rule.AbsentEarlyLeaveTime.ToString();
                _View.AbsentLateTime = rule.AbsentLateTime.ToString();
                return true;
            }
            _View.Message = "初始化错误";
            return false;
        }

        /// <summary>
        /// 设置选择小时的来源
        /// </summary>
        /// <returns></returns>
        public static List<string> Hours()
        {
            List<string> types = new List<string>();
            types.Add("0");
            types.Add("1");
            types.Add("2");
            types.Add("3");
            types.Add("4");
            types.Add("5");
            types.Add("6");
            types.Add("7");
            types.Add("8");
            types.Add("9");
            types.Add("10");
            types.Add("11");
            types.Add("12");
            types.Add("13");
            types.Add("14");
            types.Add("15");
            types.Add("16");
            types.Add("17");
            types.Add("18");
            types.Add("19");
            types.Add("20");
            types.Add("21");
            types.Add("22");
            types.Add("23");
            return types;
        }

        /// <summary>
        /// 设置选择分的来源
        /// </summary>
        /// <returns></returns>
        public static List<string> Minutes()
        {
            List<string> types = new List<string>();
            types.Add("00");
            types.Add("01");
            types.Add("02");
            types.Add("03");
            types.Add("04");
            types.Add("05");
            types.Add("06");
            types.Add("07");
            types.Add("08");
            types.Add("09");
            types.Add("10");
            types.Add("11");
            types.Add("12");
            types.Add("13");
            types.Add("14");
            types.Add("15");
            types.Add("16");
            types.Add("17");
            types.Add("18");
            types.Add("19");
            types.Add("20");
            types.Add("21");
            types.Add("22");
            types.Add("23");
            types.Add("24");
            types.Add("25");
            types.Add("26");
            types.Add("27");
            types.Add("28");
            types.Add("29");
            types.Add("30");
            types.Add("31");
            types.Add("32");
            types.Add("33");
            types.Add("34");
            types.Add("35");
            types.Add("36");
            types.Add("37");
            types.Add("38");
            types.Add("39");
            types.Add("40");
            types.Add("41");
            types.Add("42");
            types.Add("43");
            types.Add("44");
            types.Add("45");
            types.Add("46");
            types.Add("47");
            types.Add("48");
            types.Add("49");
            types.Add("50");
            types.Add("51");
            types.Add("52");
            types.Add("53");
            types.Add("54");
            types.Add("55");
            types.Add("56");
            types.Add("57");
            types.Add("58");
            types.Add("59");
            return types;
        }

        #region use for tests

        public IPlanDutyFacade IPlanDutyFacade
         {
             set { _IPlanDutyFacade = value; }
         }

        #endregion
    }
}
