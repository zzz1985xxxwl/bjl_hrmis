using System;
using System.Configuration;
using System.Web.UI;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages
{
    public class BasePage : Page
    {
        private Account _LoginUser;
        protected Account LoginUser
        {
            get
            {
                return _LoginUser;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            if (Session[SessionKeys.LOGININFO] == null)
            {
                Response.Redirect("../../Login.aspx");
                return;
            }

            base.OnInit(e);

            _LoginUser = Session[SessionKeys.LOGININFO] as Account;
        }

        //protected void InjectEmployeeId(CrmBasePresenter thePresenter)
        //{
        //    if (LoginUser == null)
        //    {
        //        return;
        //    }
        //    thePresenter.LoginUser = LoginUser;
        //    thePresenter.EmployeeId = LoginUser.Id;
        //}

        //protected void InjectEmployeeId(EShoppingBasePresenter thePresenter)
        //{
        //    if (LoginUser == null)
        //    {
        //        return;
        //    }
        //    thePresenter.LoginUser = LoginUser;
        //    thePresenter.EmployeeId = LoginUser.Id;
        //}

        public static bool HasHrmisSystem
        {
            get
            {
                return GetHasSystem("HasHrmisSystem") ;
            }
        }
        public static bool HasCRMSystem
        {
            get
            {
                return GetHasSystem("HasCRMSystem");
            }
        }
        public static bool HasMyCMMISystem
        {
            get
            {
                return GetHasSystem("HasMyCMMISystem");
            }
        }
        public static bool HasEShoppingSystem
        {
            get
            {
                return GetHasSystem("HasEShoppingSystem");
            }
        }
        private static bool GetHasSystem(string key)
        {
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[key]))
                return Convert.ToBoolean(ConfigurationManager.AppSettings[key]);
            return false;
        }
    }
}