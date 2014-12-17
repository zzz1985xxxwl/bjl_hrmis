using System.Collections.Generic;
using SEP.HRMIS.Bll.PayModule.AccountSet;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.IFacede.PayModule;

namespace SEP.HRMIS.Facade.PayModule
{
    ///<summary>
    ///</summary>
    public class AccountSetFacade : IAccountSetFacade
    {
        public void CreateAccountSetParaFacade(string accountSetParaName, FieldAttributeEnum fieldAttributes,
                                               BindItemEnum bindItem, MantissaRoundEnum mantissaRoundEnum, string description,
                                    bool isVisibleToEmployee, bool isVisibleWhenZero)
        {
            CreateAccountSetPara createAccountSetPara = new CreateAccountSetPara(accountSetParaName, fieldAttributes,
                                                                                 bindItem, mantissaRoundEnum,
                                                                                 description, isVisibleToEmployee, isVisibleWhenZero);
            createAccountSetPara.Excute();
        }

        public void CreateAccountSetFacade(string accountSetName, string description,
                                           List<AccountSetItem> accountSetItems)
        {
            CreateAccountSet createAccountSet = new CreateAccountSet(accountSetName, description, accountSetItems);
            createAccountSet.Excute();
        }

        public void DeleteAccountSetFacade(int accountSetID)
        {
            DeleteAccountSet deleteAccountSet = new DeleteAccountSet(accountSetID);
            deleteAccountSet.Excute();
        }

        public void DeleteAccountSetParaFacade(int accountSetParaID)
        {
            DeleteAccountSetPara deleteAccountSetPara = new DeleteAccountSetPara(accountSetParaID);
            deleteAccountSetPara.Excute();
        }

        public void UpdateAccountSetFacade(int accountSetID, string accountSetName, string description,
                                           List<AccountSetItem> accountSetItems, string operatorName)
        {
            UpdateAccountSet updateAccountSet =
                new UpdateAccountSet(accountSetID, accountSetName, description, accountSetItems, operatorName);
            updateAccountSet.Excute();
        }

        public void UpdateAccountSetParaFacade(int accountSetParaID, string accountSetParaName,
                                               FieldAttributeEnum fieldAttributes, BindItemEnum bindItem,
                                               MantissaRoundEnum mantissaRoundEnum, string description, string operatorName,
                                    bool isVisibleToEmployee, bool isVisibleWhenZero)
        {
            UpdateAccountSetPara updateAccountSetPara =
                new UpdateAccountSetPara(accountSetParaID, accountSetParaName, fieldAttributes, bindItem,
                                         mantissaRoundEnum, description, operatorName, isVisibleToEmployee,
                                         isVisibleWhenZero);
            updateAccountSetPara.Excute();
        }

        public AccountSetPara GetAccountSetParaByPKIDFacade(int id)
        {
            GetAccountSetPara getAccountSetPara = new GetAccountSetPara();
            return getAccountSetPara.GetAccountSetParaByPKID(id);
        }
        public AccountSetPara GetAccountSetParaByNameFacade(string accountSetParaByName)
        {
            GetAccountSetPara getAccountSetPara = new GetAccountSetPara();
            return getAccountSetPara.GetAccountSetParaByName(accountSetParaByName);
        }

        public List<AccountSetPara> GetAccountSetParaByCondition(string name,
                                                                 FieldAttributeEnum fieldAttribute, MantissaRoundEnum mantissaRound, BindItemEnum bindItem)
        {
            GetAccountSetPara getAccountSetPara = new GetAccountSetPara();
            return getAccountSetPara.GetAccountSetParaByCondition(name, fieldAttribute, mantissaRound, bindItem);
        }

        public AccountSet GetWholeAccountSetByPKID(int pkid)
        {
            GetAccountSet getAccountSet = new GetAccountSet();
            return getAccountSet.GetWholeAccountSetByPKID(pkid);
        }

        public List<AccountSet> GetAccountSetByCondition(string accountSetName)
        {
            GetAccountSet getAccountSet = new GetAccountSet();
            return getAccountSet.GetAccountSetByCondition(accountSetName);
        }

        public int CountAccountSetItemByAccountSetParaID(int accountSetParaID)
        {
            GetAccountSetPara getAccountSetPara = new GetAccountSetPara();
            return getAccountSetPara.CountAccountSetItemByAccountSetParaID(accountSetParaID);
        }

        public AccountSet GetAccountSetByName(string accountSetName)
        {
            GetAccountSet getAccountSet = new GetAccountSet();
            return getAccountSet.GetAccountSetByName(accountSetName);
        }
    }
}