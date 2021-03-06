using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 员工数据收集
    /// </summary>
    [Serializable]
    public class EmployeeCollection
    {
        private List<Employee> _TheEmployees = new List<Employee>();
        private List<Employee> _DayAttendanceWeek1List = new List<Employee>();
        private List<Employee> _DayAttendanceWeek2List = new List<Employee>();
        private List<Employee> _DayAttendanceWeek3List = new List<Employee>();
        private List<Employee> _DayAttendanceWeek4List = new List<Employee>();
        private List<Employee> _DayAttendanceWeek5List = new List<Employee>();
        private List<Employee> _DayAttendanceWeek6List = new List<Employee>();
        private List<string> _Week1List = new List<string>();
        private List<string> _Week2List = new List<string>();
        private List<string> _Week3List = new List<string>();
        private List<string> _Week4List = new List<string>();
        private List<string> _Week5List = new List<string>();
        private List<string> _Week6List = new List<string>();

        public List<Employee> TheEmployees
        {
            get { return _TheEmployees; }
            set { _TheEmployees = value; }
        }

        public List<Employee> DayAttendanceWeek1List
        {
            get { return _DayAttendanceWeek1List; }
            set { _DayAttendanceWeek1List = value; }

        }
        public List<Employee> DayAttendanceWeek2List
        {
            get { return _DayAttendanceWeek2List; }
            set { _DayAttendanceWeek2List = value; }

        }
        public List<Employee> DayAttendanceWeek3List
        {
            get { return _DayAttendanceWeek3List; }
            set { _DayAttendanceWeek3List = value; }

        }
        public List<Employee> DayAttendanceWeek4List
        {
            get { return _DayAttendanceWeek4List; }
            set { _DayAttendanceWeek4List = value; }

        }
        public List<Employee> DayAttendanceWeek5List
        {
            get { return _DayAttendanceWeek5List; }
            set { _DayAttendanceWeek5List = value; }

        }
        public List<Employee> DayAttendanceWeek6List
        {
            get { return _DayAttendanceWeek6List; }
            set { _DayAttendanceWeek6List = value; }

        }

        public List<string> Week1List
        {
            get { return _Week1List; }
            set { _Week1List = value; }

        }
        public List<string> Week2List
        {
            get { return _Week2List; }
            set { _Week2List = value; }

        }
        public List<string> Week3List
        {
            get { return _Week3List; }
            set { _Week3List = value; }

        }
        public List<string> Week4List
        {
            get { return _Week4List; }
            set { _Week4List = value; }

        }
        public List<string> Week5List
        {
            get { return _Week5List; }
            set { _Week5List = value; }

        }
        public List<string> Week6List
        {
            get { return _Week6List; }
            set { _Week6List = value; }

        }

        private List<Vacation> _TheVacation;
        public List<Vacation> TheVocation
        {
            get { return _TheVacation; }
            set { _TheVacation = value; }

        }

        public StringWriter ExportEmployeeSearchToExcel()
        {
            StringWriter theMemoryWriter = new StringWriter();
            StringBuilder theTitle = new StringBuilder();
            theTitle.Append("员工姓名\t").Append("工号\t").Append("英名名\t").Append("性别\t").Append("联系电话\t").Append("所属公司\t").Append("部门\t").
                Append("职位\t").Append("职务\t").Append("职位等级\t").Append("职系\t")
                .Append("身份证号码\t").Append("身份证有效期\t").Append("出生年月\t").Append("民族\t").Append("政治面貌\t").Append("文化程度\t").
                Append("学校\t").Append("专业\t").Append("婚姻状况\t").Append("户口地址\t").Append("邮编\t").Append("户口所属街道\t").Append("户口所属区域\t")
                .Append("家庭住址\t").Append("家庭电话\t").Append("邮编\t").Append("部门负责人\t").Append("用工性质\t").Append("居住证到期日\t")
                .Append("居住证办理机构\t").Append("入职时间\t").Append("试用期起始日\t").Append("试用期到期日\t").Append("合同起始日\t").Append("新合同起始日\t")
                .Append("合同到期日\t").Append("离职原因\t").Append("离职日期\t").Append("照片\t").Append("孩子姓名\t")
                .Append("出生年月\t").Append("身高\t").Append("体重\t").Append("籍贯\t").Append("健康状况\t").Append("档案所在地\t").Append
                ("外语能力\t").Append("紧急联系人\t").Append("职称\t").Append("证书\t").Append("邮箱地址\t").Append("邮箱地址2\t").Append("工作地点\t").Append("国籍\t")
                .Append("年假起始日\t").Append("年假结束日\t").Append("年假总天数\t").Append("已用天数\t").Append("剩余天数\t").Append("使用详情\t")
                .Append("剩余调休\t");

            theMemoryWriter.WriteLine(theTitle.ToString());
            List<int> ID = new List<int>();
            foreach (Employee e in _TheEmployees)
            {
                foreach (Vacation v in _TheVacation)
                {
                    if (v != null)
                    {
                        if (v.Employee.Account.Id == e.Account.Id)
                        {
                            theMemoryWriter.WriteLine(e.StatEmployeeInfo() + v.StatVacationInfo());
                            ID.Add(v.Employee.Account.Id);
                        }
                    }
                }
                if (!ID.Contains(e.Account.Id))
                {
                    theMemoryWriter.WriteLine(e.StatEmployeeInfo());
                }
            }
            return theMemoryWriter;
        }

        public StringWriter ExportEmployeeDayAttendanceToExcel()
        {
            StringWriter theMemoryWriter = new StringWriter();
            StringBuilder theTitle = new StringBuilder();
            theTitle.Append("员工姓名\t");
            AppendTitle(theTitle,_Week1List);
            AppendTitle(theTitle,_Week2List);
            AppendTitle(theTitle,_Week3List);
            AppendTitle(theTitle,_Week4List);
            AppendTitle(theTitle,_Week5List);
            AppendTitle(theTitle,_Week6List);
            theMemoryWriter.WriteLine(theTitle.ToString());

            for (int i=0;i<_DayAttendanceWeek1List.Count;i++)
            {
                StringBuilder theContent = new StringBuilder();
                theContent.Append(_DayAttendanceWeek1List[i].StatDayAttendance(true))
                .Append(_DayAttendanceWeek2List[i].StatDayAttendance(false))
                .Append(_DayAttendanceWeek3List[i].StatDayAttendance(false))
                .Append(_DayAttendanceWeek4List[i].StatDayAttendance(false));
                if (_DayAttendanceWeek5List.Count > 0)
                {
                    theContent.Append(_DayAttendanceWeek5List[i].StatDayAttendance(false));
                }
                if (_DayAttendanceWeek6List.Count > 0)
                {
                    theContent.Append(_DayAttendanceWeek6List[i].StatDayAttendance(false));
                }
                theMemoryWriter.WriteLine(theContent.ToString());
            }
            return theMemoryWriter;
        }
        private StringBuilder AppendTitle(StringBuilder title,List<string> week)
        {
            if (week.Count > 0)
            {
                title.Append("星期一" + week[0] + "\t")
                .Append("星期二" + week[1] + "\t")
                .Append("星期三" + week[2] + "\t")
                .Append("星期四" + week[3] + "\t")
                .Append("星期五" + week[4] + "\t")
                .Append("星期六" + week[5] + "\t")
                .Append("星期日" + week[6] + "\t");
            }
            return title;
        }
       
    }
}