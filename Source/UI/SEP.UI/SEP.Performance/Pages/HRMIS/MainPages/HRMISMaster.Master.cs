using System;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.MainPages
{
    public partial class HRMISMaster : System.Web.UI.MasterPage
    {
        protected string companyMailTo;

        protected void Page_Load(object sender, EventArgs e)
        {
            //companyMailTo = "mailto:" + CompanyConfig.SYSTEMMAILADDRESS;
            Account _loginUser = Session[SessionKeys.LOGININFO] as Account;
            liHRMIS.Visible = BasePage.HasHrmisSystem && _loginUser.IsHRAccount;
            liCRM.Visible = BasePage.HasCRMSystem && _loginUser.IsCRMAccount;
            liESCALADE.Visible = BasePage.HasEShoppingSystem && _loginUser.IsEShoppingAccount;
            liMyCMMI.Visible = BasePage.HasMyCMMISystem && _loginUser.IsMyCMMIAccount;
        }

        public string LoginUser
        {
            get
            {
                Account _loginUser = Session[SessionKeys.LOGININFO] as Account;
                string nameurl = "";
                if (_loginUser == null)
                {
                    return nameurl;
                }
                else
                {
                    if (BasePage.HasHrmisSystem && _loginUser.IsHRAccount && _loginUser.Id != Account.AdminPkid)
                    {
                        nameurl = "<a href='../employeepages/EmployeeMyDetail.aspx' class='usrname'>" + _loginUser.Name +
                                  "</a>";
                    }
                    else
                    {
                        nameurl = _loginUser.Name;
                    }
                    return nameurl;
                }
            }
        }
    }
}