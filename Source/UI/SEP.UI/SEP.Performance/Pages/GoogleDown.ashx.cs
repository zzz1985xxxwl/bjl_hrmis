
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model.PayModule;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.Performance.Pages
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GoogleDown : IHttpHandler, IRequiresSessionState
    {
        private HttpContext _Context;
        private string _Result;
        private string _Key;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            _Context = context;
            _Result = string.Empty;
            _Key = _Context.Request.QueryString["q"] ?? "";
            if (context.Request.Params["type"] != null)
            {
                switch (context.Request.Params["type"])
                {
                    //职位名称
                    case "Position":
                        InitResult(BllInstance.PositionBllInstance.GetAllPosition(), "Name");
                        break;
                    //所有有效帐号的姓名
                    case "Account":
                        InitResult(BllInstance.AccountBllInstance.GetAccountByCondition("", null, null, true), "Name");
                        break;
                    case "AllAccount":
                        InitResult(BllInstance.AccountBllInstance.GetAccountByCondition("", null, null, null), "Name");
                        break;
                    //得到下属
                    case "Subordinates":
                        InitResult(
                            BllInstance.AccountBllInstance.GetSubordinates(
                                (HttpContext.Current.Session[SessionKeys.LOGININFO] as Account).Id), "Name");
                        break;
                    //所有Hrmis的有效帐号的姓名
                    case "HrmisAccount":
                        InitResult(BllInstance.AccountBllInstance.GetAllHRMisAccount(), "Name");
                        break;
                    //hrmis帐套项参数名称
                    case "AccountSetPara":
                        AccountSetPara();
                        break;
                    case "ProjectInfo":
                        InitResult(ProjectInfoLogic.GetProjectInfoByCondition(""), "ProjectName");
                        break;
                    default:
                        break;
                }
            }
            context.Response.Write(_Result);
            context.Response.End();
        }


        private void AccountSetPara()
        {
            var list = AccountSetParaLogic.GetAllAccountSetParamEntity();
            InitResult(list, "AccountSetParaName");
        }


        private void InitResult<T>(IEnumerable<T> lists, string propertyName)
        {
            foreach (T t in lists)
            {
                string name = t.GetType().GetProperty(propertyName).GetValue(t, null).ToString();
                bool isSprical = false;
                try
                {
                    CHS2PinYin.FirstCHSCap(name);
                }
                catch
                {
                    isSprical = true;
                }
                if (name.Contains(_Key))
                {
                    _Result += name + "\n";
                }
                else if (!isSprical && CHS2PinYin.FirstCHSCap(name).Contains(_Key.ToUpper()))
                {
                    _Result += name + "\n";
                }
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}