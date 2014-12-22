using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter;
using SEP.Model.Utility;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class AccountSetBackCode : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Charset = "utf-8";
            Response.Buffer = true;
            EnableViewState = false;
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "text/plain";
            if (Request.QueryString["operation"] != null
                && Request.QueryString["operation"] == "googledownAccountSetParaInfo")
            {
                GoogledownAccountSetParaInfo();
            }
            if (Request.QueryString["operation"] != null
                && Request.QueryString["operation"] == "checkitem")
            {
                CheckItem();
            }
            Response.Flush();
            Response.Close();
            Response.End();
        }

        private void GoogledownAccountSetParaInfo()
        {
            if (Request.QueryString["q"] != null)
            {
                Response.Write(SearchLikeName(Request.QueryString["q"]));
            }
            else
            {
                Response.Write(SearchLikeName(""));
            }

        }

        public string SearchLikeName(string key)
        {
            string result = String.Empty;
            IAccountSetFacade IAccountSetFacade = InstanceFactory.CreateAccountSetFacade();
            List<AccountSetPara> allAccountSetParas =
                IAccountSetFacade.GetAccountSetParaByCondition("", FieldAttributeEnum.AllFieldAttribute,
                                                               MantissaRoundEnum.AllMantissaRound,
                                                               BindItemEnum.AllBindItem);

            foreach (AccountSetPara item in allAccountSetParas)
            {
                bool isSprical = false;
                try
                {
                    CHS2PinYin.FirstCHSCap(item.AccountSetParaName);
                }
                catch
                {
                    isSprical = true;
                }
                if (item.AccountSetParaName.ToLower().Contains(key))
                {
                    result += string.IsNullOrEmpty(result)
                                  ? item.AccountSetParaName
                                  : "\n" + item.AccountSetParaName;
                }
                else if (!isSprical && CHS2PinYin.FirstCHSCap(item.AccountSetParaName).Contains(key.ToUpper()))
                {
                    result += string.IsNullOrEmpty(result)
                                  ? item.AccountSetParaName
                                  : "\n" + item.AccountSetParaName;
                }
            }
            return result;
        }

        private void CheckItem()
        {
            string result = string.Empty;
            if (Request.QueryString["expression"] != null
                && Request.QueryString["imgResult"] != null
                && Request.QueryString["paraID"] != null
                && Request.QueryString["rowindexID"] != null
                && Session["AccountSetItemListForCheck"] != null)
            {
                string rowindexID = Request.QueryString["rowindexID"];
                string paraID = Request.QueryString["paraID"];
                string expression = Request.QueryString["expression"];
                string imgResult = Request.QueryString["imgResult"];
                result = imgResult + "|";
                AccountSetItem accountSetItem =
                    new AccountSetItem(-1, new AccountSetPara(Convert.ToInt32(paraID), ""), expression);
                try
                {
                    List<AccountSetItem> accountSetItemForCheck =
                        Session["AccountSetItemListForCheck"] as List<AccountSetItem>;
                    if (accountSetItemForCheck != null)
                    {
                        accountSetItemForCheck[Convert.ToInt32(rowindexID)].CalculateFormula = expression;
                    }
                    accountSetItem.CheckItemValidation(accountSetItemForCheck);
                }
                catch (Exception ex)
                {
                    result += ex.ToString();
                }
            }
            Response.Write(result + "||end");
        }
    }
}