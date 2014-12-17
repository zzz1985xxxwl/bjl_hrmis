using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using Newtonsoft.Json;
using SEP.IBll;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Bulletins;
using SEP.Model.Utility;

namespace SEP.Performance.Views.SEP.Choose
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ChooseAccount : IHttpHandler, IRequiresSessionState
    {
        private HttpContext _Context;
        private string _ResponseString;

        public void ProcessRequest(HttpContext context)
        {
            _Context = context;
            _ResponseString = "{}";
            context.Response.ContentType = "text/plain";
            if (context.Request.Params["type"] != null)
            {
                switch (context.Request.Params["type"])
                {
                    case "SaveAccountGroup":
                        SaveAccountGroup();
                        break;
                    case "DeleteAccountGroup":
                        DeleteAccountGroup();
                        break;
                    case "GetAccountsByAuth":
                        GetAccountsByAuth();
                        break;
                    case "GetAccountsInBulletin":
                        GetAccountsInBulletin();
                        break;
                    case "GetAccountGroupsInBulletin":
                        GetAccountGroupsInBulletin();
                        break;
                    default:
                        break;
                }
            }
            context.Response.Write(_ResponseString);
            context.Response.End();
        }

        private void DeleteAccountGroup()
        {
            List<Error> errors = new List<Error>();
            int accountgroupid;
            if(!int.TryParse(_Context.Request.Params["accountgroupid"].Trim(),out accountgroupid))
            {
                errors.Add(new Error("", "组id无法识别"));
            }
            else
            {
                try
                {
                    BllInstance.AccountGroupBllInstance.DeleteAccountGroup(accountgroupid);
                }
                catch (Exception e)
                {
                    errors.Add(new Error("", e.Message));
                }
            }
            _ResponseString = "{error:" + JsonConvert.SerializeObject(errors) + "}";
        }
        private void GetAccountGroupsInBulletin()
        {
            List<Error> errorList = new List<Error>();
            List<AccountGroup> accountgroupList = new List<AccountGroup>();
            try
            {
                string accountgroupname = _Context.Request.Params["accountgroupname"];
                Account account = HttpContext.Current.Session[SessionKeys.LOGININFO] as Account;
                accountgroupList = BllInstance.AccountGroupBllInstance.GetAccountGroupByCondition(accountgroupname);
                foreach (AccountGroup item in accountgroupList)
                {
                    item.AccountList =
                        BulletinUtility.RemoteUnAuthAccount(item.AccountList, AuthType.SEP, account, Powers.A302);
                }
            }
            catch (Exception ex)
            {
                errorList.Add(new Error("ChooseAccountErrorMessage", ex.Message));
            }
            GetAccountGroups(accountgroupList, errorList);

        }
        private void GetAccountsByAuth()
        {
            List<Error> errorList = new List<Error>();
            List<Account> accountList = new List<Account>();
            try
            {
                string accountname = _Context.Request.Params["accountname"];
                int departmentid = Convert.ToInt32(_Context.Request.Params["departmentid"]);
                int positionid = Convert.ToInt32(_Context.Request.Params["positionid"]);
                int powerID = Convert.ToInt32(_Context.Request.Params["powerID"]);
                Account account = HttpContext.Current.Session[SessionKeys.LOGININFO] as Account;
                accountList =
                    BllInstance.AccountBllInstance.GetAccountByBaseCondition(accountname, departmentid, positionid,null,
                                                                             true,
                                                                             true);
                if (powerID != -1)
                {
                    accountList = Tools.RemoteUnAuthAccount(accountList, AuthType.HRMIS, account, powerID);
                }
            }
            catch (Exception ex)
            {
                errorList.Add(new Error("ChooseAccountErrorMessage", ex.Message));
            }
            GetAccounts(accountList, errorList);
        }
        private void GetAccountsInBulletin()
        {
            List<Error> errorList = new List<Error>();
            List<Account> accountList = new List<Account>();
            try
            {
                string accountname = _Context.Request.Params["accountname"];
                int departmentid = Convert.ToInt32(_Context.Request.Params["departmentid"]);
                int positionid = Convert.ToInt32(_Context.Request.Params["positionid"]);
                Account account = HttpContext.Current.Session[SessionKeys.LOGININFO] as Account;
                accountList =
                    BllInstance.AccountBllInstance.GetAccountByBaseCondition(accountname, departmentid, positionid,null,
                                                                             true,
                                                                             true);
                accountList = BulletinUtility.RemoteUnAuthAccount(accountList, AuthType.SEP, account, Powers.A302);
            }
            catch (Exception ex)
            {
                errorList.Add(new Error("ChooseAccountErrorMessage", ex.Message));
            }
            GetAccounts(accountList, errorList);
        }

        private void SaveAccountGroup()
        {
            List<Error> errors = new List<Error>();
            Valid(errors);
            if (errors.Count == 0)
            {
                //数据收集过程
                int accountgroupid;
                if (!int.TryParse(_Context.Request.Params["accountgroupid"], out accountgroupid))
                {
                    errors.Add(new Error("editlblMessage", "信息错误"));
                }
                string accountname = _Context.Request.Params["accountgroupname"];
                string accountgroupmember = _Context.Request.Params["accountgroupmember"];
                AccountGroup AccountGroup = new AccountGroup();
                AccountGroup.PKID = accountgroupid;
                AccountGroup.GroupName = accountname;
                try
                {
                    if (accountgroupid == 0)
                    {
                        BllInstance.AccountGroupBllInstance.CreateAccountGroup(AccountGroup, accountgroupmember);
                    }
                    else
                    {
                        BllInstance.AccountGroupBllInstance.UpdateAccountGroup(AccountGroup, accountgroupmember);
                    }
                }
                catch (Exception e)
                {
                    errors.Add(new Error("editlblMessage", e.Message));
                }
            }
            _ResponseString = "{error:" + JsonConvert.SerializeObject(errors) + "}";
        }

        private void Valid(List<Error> errors)
        {
            if (string.IsNullOrEmpty(_Context.Request.Params["accountgroupname"].Trim()))
            {
                errors.Add(new Error("txtAccountGroupName", "不可为空"));
            }
            if (string.IsNullOrEmpty(_Context.Request.Params["accountgroupmember"].Trim()))
            {
                errors.Add(new Error("txtAccountGroupMember", "不可为空"));
            }
        }


        public void GetAccounts(List<Account> accountList, List<Error> errorList)
        {
            string si, se;

            si = JsonConvert.SerializeObject(AccountViewModel.Turn(accountList));
            si = si.Replace("null", "\"\"");

            se = "{error:" + JsonConvert.SerializeObject(errorList) + "}";
            _ResponseString = string.Format("{{itemList:{0},error:{1}}}", si, se);
        }

        private void GetAccountGroups(List<AccountGroup> accountgroupList, List<Error> errorList)
        {
            string si, se;

            si = JsonConvert.SerializeObject(AccountGroupViewModel.Turn(accountgroupList));
            si = si.Replace("null", "\"\"");

            se = "{error:" + JsonConvert.SerializeObject(errorList) + "}";
            _ResponseString = string.Format("{{itemList:{0},error:{1}}}", si, se);
            
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }

    public class AccountGroupViewModel
    {
        private readonly AccountGroup _Model;

        public AccountGroupViewModel(AccountGroup model)
        {
            _Model = model;
        }
        public string AccountGroupID
        {
            get
            {
                return _Model.PKID.ToString();
            }
        }
        public string Name
        {
            get
            {
                return _Model.GroupName;
            }
        }
        public string Memebers
        {
            get
            {
                string ret = string.Empty;
                foreach (Account account in _Model.AccountList)
                {
                    ret += string.IsNullOrEmpty(ret) ? account.Name : ";" + account.Name;
                }
                return ret;
            }
        }
        public static List<AccountGroupViewModel> Turn(List<AccountGroup> types)
        {
            List<AccountGroupViewModel> list = new List<AccountGroupViewModel>();
            foreach (AccountGroup t in types)
            {
                list.Add(new AccountGroupViewModel(t));
            }
            return list;
        }
    }

    public class AccountViewModel
    {
        private readonly Account _Model;

        public AccountViewModel(Account model)
        {
            _Model = model;
        }
        public string AccountID
        {
            get
            {
                return _Model.Id.ToString();
            }
        }
        public string Name
        {
            get
            {
                return _Model.Name;
            }
        }
        public string DeptName
        {
            get
            {
                return _Model.Dept != null && _Model.Dept.Name != null ? _Model.Dept.Name : string.Empty;
            }
        }
        public string PositionName
        {
            get
            {
                return _Model.Position != null && _Model.Position.Name != null ? _Model.Position.Name : string.Empty;
            }
        }
        public string Email1
        {
            get
            {
                return _Model.Email1;
            }
        }
        public string Email2
        {
            get
            {
                return _Model.Email2;
            }
        }

        public static List<AccountViewModel> Turn(List<Account> types)
        {
            List<AccountViewModel> list = new List<AccountViewModel>();
            foreach (Account t in types)
            {
                list.Add(new AccountViewModel(t));
            }
            return list;
        }
    }

}
