using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Web.SessionState;
using Framework.Common;
using Newtonsoft.Json;
using sLogic=SEP.HRMIS.Logic;
using SEP.HRMIS.Model.AccountAuth;
using SEP.IBll;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    /// <summary>
    ///   Handler1 的摘要说明
    /// </summary>
    public class EmployeeSalaryHistoryStatisticsHandler : IHttpHandler, IRequiresSessionState
    {
        private HttpContext _Context;
        private string _ResponseString;

        public void ProcessRequest(HttpContext context)
        {
            _Context = context;
            _ResponseString = "{}";
            context.Response.ContentType = "text/plain";

            var loginUser = context.Session[SessionKeys.LOGININFO] as Account;
            if (_Context.Request.Params["type"] != null && Powers.HasAuth(loginUser.Auths, AuthType.HRMIS, HrmisPowers.A608))
            {
                switch (_Context.Request.Params["type"])
                {
                    case "Search":
                        Search();
                        break;
                    default:
                        break;
                }
            }
            context.Response.Write(_ResponseString);
            context.Response.End();
        }

        private void Search()
        {
            var employeeName = _Context.Request.Params["EmployeeName"];
            var dateTimeFrom = _Context.Request.Params["DateTimeFrom"];
            var dateTimeTo = _Context.Request.Params["DateTimeTo"];
            var accountParam = _Context.Request.Params["AccountParam"];
            var model = new List<SalaryStaticsModel>();
            if (string.IsNullOrEmpty(employeeName))
            {
                _ResponseString = JsonConvert.SerializeObject(new ErrorModel { Error = "员工姓名不可为空" });
                return;
            }
            if (string.IsNullOrEmpty(accountParam))
            {
                _ResponseString = JsonConvert.SerializeObject(new ErrorModel { Error = "帐套项不可为空" });
                return;
            }
            var employee = BllInstance.AccountBllInstance.GetAccountByName(employeeName);
            if (employee == null)
            {
                _ResponseString = JsonConvert.SerializeObject(new ErrorModel { Error = "员工姓名不存在" });
                return;
            }
            var accountParams = accountParam.Split(new[] { ';', '；' }, StringSplitOptions.RemoveEmptyEntries);
            var list = sLogic.EmployeeSalaryHistoryLogic.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(employee.Id,
                                                                                       dateTimeFrom.SafeToDateTime(),
                                                                                       dateTimeTo.SafeToDateTime());
            foreach (var employeeSalaryHistoryEntity in list)
            {
                var salaryStaticsModel = new SalaryStaticsModel
                {
                    AccountSetName = employeeSalaryHistoryEntity.AccountSetName,
                    SalaryDate = employeeSalaryHistoryEntity.SalaryDateTime.AddMonths(1).ToString("yyyy-MM"),
                    AccountSetItem = new List<NameValueModel>()
                };
                foreach (var param in accountParams)
                {
                    var accountsetItem = employeeSalaryHistoryEntity.AccountSetItem.Where(x => x.AccountSetPara.AccountSetParaName == param).FirstOrDefault();
                    salaryStaticsModel.AccountSetItem.Add(new NameValueModel()
                    {
                        Name = param,
                        Value = accountsetItem == null ? "" : accountsetItem.CalculateResult.ToString()
                    });
                }
                model.Add(salaryStaticsModel);
            }
            var total = new SalaryStaticsModel()
                            {
                                AccountSetName = "总计",
                                AccountSetItem = new List<NameValueModel>()
                            };
            foreach (var salaryStaticsModel in model)
            {
                foreach (var item in salaryStaticsModel.AccountSetItem)
                {
                    var totalItem = total.AccountSetItem.Where(x => x.Name.Equals(item.Name)).FirstOrDefault();
                    if (totalItem == null)
                    {
                        total.AccountSetItem.Add(new NameValueModel()
                        {
                            Name = item.Name,
                            Value = item.Value
                        });
                    }
                    else
                    {
                        totalItem.Value = (totalItem.Value.SafeToDecimal() + item.Value.SafeToDecimal()).ToString();
                    }
                }
            }
            model.Add(total);
            _ResponseString = JsonConvert.SerializeObject(model);
        }
        protected class ErrorModel
        {
            public string Error { get; set; }
        }

        protected class SalaryStaticsModel
        {
            public string SalaryDate { get; set; }
            public string AccountSetName { get; set; }
            public List<NameValueModel> AccountSetItem { get; set; }
        }

        protected class NameValueModel
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
        public bool IsReusable
        {
            get { return false; }
        }
    }
}