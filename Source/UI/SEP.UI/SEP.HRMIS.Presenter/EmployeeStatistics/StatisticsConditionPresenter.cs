using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.AccountAuth;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;


namespace SEP.HRMIS.Presenter
{
    public class StatisticsConditionPresenter
    {
        private readonly Account _Operator;
        private readonly IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        public readonly IStatisticsConditionView _IStatisticsConditionView;
        public StatisticsConditionPresenter(IStatisticsConditionView iStatisticsConditionView, Account _operator)
        {
            _Operator = _operator;
            _IStatisticsConditionView = iStatisticsConditionView;
        }

        public void InitPresent(bool isPostBack)
        {
            if (!isPostBack)
            {
                BindDepartment();
                _IStatisticsConditionView.StatisticsTime = DateTime.Now.ToShortDateString();
            }
        }
        public void BindDepartment()
        {
            List<Department> deptList = _IDepartmentBll.GetAllDepartment();
            deptList = Tools.RemoteUnAuthDeparetment(deptList, AuthType.HRMIS, _Operator, HrmisPowers.A405);
            _IStatisticsConditionView.DepartmentList = _IDepartmentBll.GenerateDeptListWithLittleParentDept(deptList);

        }

        public bool CheckValid()
        {
            _IStatisticsConditionView.StatisticsTimeMsg = string.Empty;
            bool ret = true;
            if (string.IsNullOrEmpty(_IStatisticsConditionView.StatisticsTime))
            {
                _IStatisticsConditionView.StatisticsTimeMsg = "请输入统计时间点";
                ret = false;
            }
            else
            {
                DateTime dtStatisticsTime;
                if (!DateTime.TryParse(_IStatisticsConditionView.StatisticsTime, out dtStatisticsTime))
                {
                    _IStatisticsConditionView.StatisticsTimeMsg = "时间点格式不正确";
                    ret = false;
                }
            }
            return ret;
        }

    }
}
