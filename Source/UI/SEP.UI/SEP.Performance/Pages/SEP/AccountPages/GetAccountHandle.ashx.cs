using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.SessionState;
using Newtonsoft.Json;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Performance.Views.SEP.Choose;

namespace SEP.Performance.Pages.SEP.AccountPages
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetAccountHandle : IHttpHandler, IRequiresSessionState
    {
        private string _ResponseString;
        private HttpContext _Context;
        private Account _Operator;
        public void ProcessRequest(HttpContext context)
        {
            _Context = context;
            _ResponseString = "{}";
            _Operator = _Context.Session[SessionKeys.LOGININFO] as Account;
            context.Response.ContentType = "text/plain";
            if (context.Request.Params["type"] != null)
            {
                switch (context.Request.Params["type"])
                {
                    case "GetChargeAccountByNameAndDeptString":
                        GetChargeAccountByNameAndDeptString();
                        break;
                    default:
                        break;
                }
            }

            context.Response.Write(_ResponseString);
            context.Response.End();
        }

        private void GetChargeAccountByNameAndDeptString()
        {
            List<Performance.Error> errorList = new List<Performance.Error>();
            List<AccountViewModel> accountListViewModel = new List<AccountViewModel>();
            try
            {
                List<Account> accountList =
                    BllInstance.AccountBllInstance.GetChargeAccountByNameAndDeptString(
                        _Context.Request.Params["namelike"],
                        _Context.Request.Params["deptlike"],
                        _Operator);
                accountListViewModel = AccountViewModel.Turn(accountList);
            }

            catch (Exception e)
            {
                errorList.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString =
                string.Format("{{\"itemList\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(accountListViewModel),
                              JsonConvert.SerializeObject(errorList));

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
