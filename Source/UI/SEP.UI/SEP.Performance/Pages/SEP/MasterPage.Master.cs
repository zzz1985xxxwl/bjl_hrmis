using System;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Performance.Pages;

namespace SEP.Performance
{
    public partial class MasterPage : System.Web.UI.MasterPage
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
        public bool DisplayAuthTree
        {
           set { tdAuthTree.Style["display"] = value ? "block" : "none"; }
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
                if (BasePage.HasHrmisSystem && _loginUser.IsHRAccount && _loginUser.Id != Account.AdminPkid)
                {
                    nameurl = "<a href='../../hrmis/employeepages/EmployeeMyDetail.aspx' class='usrname'>" +
                              _loginUser.Name + "</a>";
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