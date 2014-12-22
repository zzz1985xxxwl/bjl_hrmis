using System.Collections.Generic;
 using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.IFacede.PayModule
{
    ///<summary>
    ///</summary>
    public interface IAccountSetFacade
    {
        ///<summary>
        ///</summary>
        ///<param name="accountSetParaName"></param>
        ///<param name="fieldAttributes"></param>
        ///<param name="bindItem"></param>
        ///<param name="mantissaRoundEnum"></param>
        ///<param name="description"></param>
        ///<param name="isVisibleToEmployee"></param>
        ///<param name="isVisibleWhenZero"></param>
        void CreateAccountSetParaFacade(string accountSetParaName, FieldAttributeEnum fieldAttributes,
                                        BindItemEnum bindItem, MantissaRoundEnum mantissaRoundEnum, string description,
                                    bool isVisibleToEmployee, bool isVisibleWhenZero);

        ///<summary>
        ///</summary>
        ///<param name="accountSetName"></param>
        ///<param name="description"></param>
        ///<param name="accountSetItems"></param>
        void CreateAccountSetFacade(string accountSetName, string description, List<AccountSetItem> accountSetItems);
        ///<summary>
        ///</summary>
        ///<param name="accountSetID"></param>
        void DeleteAccountSetFacade(int accountSetID);
        ///<summary>
        ///</summary>
        ///<param name="accountSetParaID"></param>
        void DeleteAccountSetParaFacade(int accountSetParaID);

        ///<summary>
        ///</summary>
        ///<param name="accountSetID"></param>
        ///<param name="accountSetName"></param>
        ///<param name="description"></param>
        ///<param name="accountSetItems"></param>
        ///<param name="operatorName"></param>
        void UpdateAccountSetFacade(int accountSetID, string accountSetName, string description,
                                    List<AccountSetItem> accountSetItems, string operatorName);

        ///<summary>
        ///</summary>
        ///<param name="accountSetParaID"></param>
        ///<param name="accountSetParaName"></param>
        ///<param name="fieldAttributes"></param>
        ///<param name="bindItem"></param>
        ///<param name="mantissaRoundEnum"></param>
        ///<param name="description"></param>
        ///<param name="operatorName"></param>
        ///<param name="isVisibleToEmployee"></param>
        ///<param name="isVisibleWhenZero"></param>
        void UpdateAccountSetParaFacade(int accountSetParaID, string accountSetParaName, FieldAttributeEnum fieldAttributes,
                                        BindItemEnum bindItem, MantissaRoundEnum mantissaRoundEnum, string description, string operatorName,
                                    bool isVisibleToEmployee, bool isVisibleWhenZero);

        ///<summary>
        ///</summary>
        ///<param name="id"></param>
        ///<returns></returns>
        AccountSetPara GetAccountSetParaByPKIDFacade(int id);

        ///<summary>
        ///</summary>
        ///<param name="name"></param>
        ///<param name="fieldAttribute"></param>
        ///<param name="mantissaRound"></param>
        ///<param name="bindItem"></param>
        ///<returns></returns>
        List<AccountSetPara> GetAccountSetParaByCondition(string name,FieldAttributeEnum fieldAttribute,
                                                          MantissaRoundEnum mantissaRound, BindItemEnum bindItem);


        ///<summary>
        ///</summary>
        ///<param name="pkid"></param>
        ///<returns></returns>
        AccountSet GetWholeAccountSetByPKID(int pkid);
        ///<summary>
        ///</summary>
        ///<param name="accountSetName"></param>
        ///<returns></returns>
        List<AccountSet> GetAccountSetByCondition(string accountSetName);

        ///<summary>
        ///</summary>
        ///<param name="accountSetParaID"></param>
        ///<returns></returns>
        int CountAccountSetItemByAccountSetParaID(int accountSetParaID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountSetName"></param>
        /// <returns></returns>
        AccountSet GetAccountSetByName(string accountSetName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountSetParaByName"></param>
        /// <returns></returns>
        AccountSetPara GetAccountSetParaByNameFacade(string accountSetParaByName);
    }
}