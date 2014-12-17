using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.Performance.Pages.HRMIS.AuthPages
{
    public partial class AssignAuthGooldownPage : Page
    {
        private List<Account> accountList = new List<Account>();

        protected void Page_Load(object sender, EventArgs e)
        {
            accountList = BllInstance.AccountBllInstance.GetAllHRMisAccount(); 

            Response.Clear();
            Response.Charset = "utf-8";
            Response.Buffer = true;
            EnableViewState = false;
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "text/html";
            var searchparam = Request.QueryString["q"] != null && Request.QueryString["q"] != ""
                ? Request.QueryString["q"]
                : "";
            byte[] b = Response.ContentEncoding.GetBytes(SearchLikeName(searchparam));
            Response.AddHeader("Content-Length", b.Length.ToString());
            Response.BinaryWrite(b);
            Response.Flush();
            Response.Close();
        }

        private string SearchLikeName(string key)
        {
            string result = String.Empty;

            foreach (Account account in accountList)
            {
                bool isSprical = false;
                try
                {
                    CHS2PinYin.FirstCHSCap(account.Name);
                }
                catch
                {
                    isSprical = true;
                }
                if (account.Name.Contains(key))
                {
                    result += account.Name + "\n";
                }
                else if (!isSprical && CHS2PinYin.FirstCHSCap(account.Name).Contains(key.ToUpper()))
                {
                    result += account.Name + "\n";
                }
            }
            return result;
        }
    }
}