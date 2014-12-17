using System;
using System.Collections.Generic;
using System.Configuration;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter;

namespace SEP.Presenter
{
    public class MasterPagePresenter:BasePresenter
    {
        private readonly IMasterPage _IMasterPage;
        public MasterPagePresenter(IMasterPage iMasterPage, Account loginUser)
            : base(loginUser)
        {
            _IMasterPage = iMasterPage;
        }

        public void InitPresent(int employeeId)
        {
            //todo colbert
            List<Department> DepartmentList = BllInstance.DepartmentBllInstance.GetManageDepts(employeeId, LoginUser);
            if (DepartmentList == null || DepartmentList.Count == 0)
            {
                _IMasterPage.HasStatisticsAuth = false;
            }
            else
            {
                _IMasterPage.HasStatisticsAuth = true;
            }
        }

        public override void Initialize(bool isPostBack)
        {
            throw new System.Exception("The method or operation is not implemented.");
        }

        public static bool HasHrmisSystem
        {
            get { return GetHasSystem("HasHrmisSystem"); }
        }

        public static bool HasCRMSystem
        {
            get { return GetHasSystem("HasCRMSystem"); }
        }

        public static bool HasMyCMMISystem
        {
            get { return GetHasSystem("HasMyCMMISystem"); }
        }

        public static bool HasEShoppingSystem
        {
            get { return GetHasSystem("HasEShoppingSystem"); }
        }

        private static bool GetHasSystem(string key)
        {
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[key]))
                return Convert.ToBoolean(ConfigurationManager.AppSettings[key]);
            return false;
        }
    }
}
