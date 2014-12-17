//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: WorkInfoVaildater.cs
// 创建者: 倪豪
// 创建日期: 2008-09-25
// 概述: 工作信息界面的数据验证类
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.IBll.Positions;
using SEP.Model.Departments;

namespace SEP.HRMIS.Presenter.EmployInformation.WorkInformation
{
    public class WorkInfoVaildater : IVaildater
    {
        private readonly IWorkInfoView _ItsView;
        private IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        

        public WorkInfoVaildater(IWorkInfoView itsView)
        {
            _ItsView = itsView;
        }

        public bool Vaildate()
        {
            bool fartherDepartment = VaildateCompany();
            bool comeDate = VaildateComeDate();
            bool probationEndDate = VaildateProbationEndDate();
            bool societyWorkAge = VaildateSocietyWorkAge();
            bool probationStartDate = VaildateProbationStratDate();
            return fartherDepartment && comeDate && probationEndDate && societyWorkAge && probationStartDate;
        }

        private bool VaildateProbationEndDate()
        {
            if (string.IsNullOrEmpty(_ItsView.ProbationEndDate))
            {
                return true;
            }

            DateTime dt;
            if (!DateTime.TryParse(_ItsView.ProbationEndDate, out dt))
            {
                _ItsView.ProbationEndDateMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                return false;
            }

            _ItsView.ProbationEndDateMessage = string.Empty;
            return true;
        }

        private bool VaildateProbationStratDate()
        {
            if (string.IsNullOrEmpty(_ItsView.ProbationStartDate))
            {
                return true;
            }

            DateTime dt;
            if (!DateTime.TryParse(_ItsView.ProbationStartDate, out dt))
            {
                _ItsView.ProbationStartDateMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                return false;
            }

            _ItsView.ProbationStartDateMessage = string.Empty;
            return true;
        }

        private bool VaildateComeDate()
        {
            if (String.IsNullOrEmpty(_ItsView.ComeDate))
            {
                //_ItsView.ComeDateMessage = EmployeePresenterUtilitys._FieldNotEmpty;
                //return false;
                return true;
            }

            DateTime dt;
            if (!DateTime.TryParse(_ItsView.ComeDate, out dt))
            {
                _ItsView.ComeDateMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                return false;
            }

            _ItsView.ComeDateMessage = string.Empty;
            return true;
        }


        private bool VaildateCompany()
        {
            if (!TheDepartmentIsExist(_ItsView.Company))
            {
                _ItsView.CompanyMessage = EmployeePresenterUtilitys._TypeNotDefined;
                return false;
            }

            _ItsView.CompanyMessage = string.Empty;
            return true;
        }

        private bool VaildateSocietyWorkAge()
        {
            int _SocietyWorkAge;
            if (!string.IsNullOrEmpty(_ItsView.SocietyWorkAge) &&
               !int.TryParse(_ItsView.SocietyWorkAge, out _SocietyWorkAge))
            {
                _ItsView.SocietyWorkAgeMessage = EmployeePresenterUtilitys._FieldWrongFormat;
                return false;
            }
            return true;
        }

        private bool TheDepartmentIsExist(string departmentId)
        {
            List<Department> allDepartments = _IDepartmentBll.GetAllDepartment();
            if(allDepartments == null)
            {
                return false;
            }

            foreach(Department dep in allDepartments)
            {
                if(dep.DepartmentID.ToString().Equals(departmentId))
                {
                    return true;
                }
            }
            return false;
        }

        #region 测试用

        public IDepartmentBll SetDepartment
        {
            set { _IDepartmentBll = value; }
        }

        #endregion 
    }
}