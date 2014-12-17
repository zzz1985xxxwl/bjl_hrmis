
using System.Collections.Generic;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.IDal.PayModule
{
    ///<summary>
    ///</summary>
    public interface IAccountSet
    {
        #region AccountSetPara
        ///<summary>
        ///</summary>
        ///<param name="id"></param>
        ///<returns></returns>
        AccountSetPara GetAccountSetParaByPKID(int id);

        ///<summary>
        ///</summary>
        ///<param name="para"></param>
        ///<returns></returns>
        int InsertAccountSetPara(AccountSetPara para);

        ///<summary>
        ///</summary>
        ///<param name="para"></param>
        ///<returns></returns>
        int UpdateAccountSetPara(AccountSetPara para);

        ///<summary>
        ///</summary>
        ///<param name="pkid"></param>
        ///<param name="name"></param>
        ///<returns></returns>
        int CountAccountSetParaByNameDiffPKID(int pkid, string name);

        ///<summary>
        ///</summary>
        ///<param name="pkid"></param>
        ///<returns></returns>
        int DeleteAccountSetParaByPKID(int pkid);

        ///<summary>
        ///</summary>
        ///<param name="name"></param>
        ///<param name="fieldAttribute"></param>
        ///<param name="mantissaRound"></param>
        ///<param name="bindItem"></param>
        ///<returns></returns>
        List<AccountSetPara> GetAccountSetParaByCondition(string name,
                                                          FieldAttributeEnum fieldAttribute, MantissaRoundEnum mantissaRound, BindItemEnum bindItem);

        #endregion

        #region AccountSet
        ///<summary>
        ///</summary>
        ///<param name="accountSet"></param>
        ///<returns></returns>
        int InsertWholeAccountSet(AccountSet accountSet);
        ///<summary>
        ///</summary>
        ///<param name="accountSet"></param>
        ///<returns></returns>
        int UpdateWholeAccountSet(AccountSet accountSet);
        ///<summary>
        ///</summary>
        ///<param name="pkid"></param>
        ///<param name="name"></param>
        ///<returns></returns>
        int CountAccountSetByNameDiffPKID(int pkid, string name);
        ///<summary>
        ///</summary>
        ///<param name="pkid"></param>
        ///<returns></returns>
        int DeleteWholeAccountSetByPKID(int pkid);
        ///<summary>
        ///</summary>
        ///<param name="pkid"></param>
        ///<returns></returns>
        AccountSet GetWholeAccountSetByPKID(int pkid);
        ///<summary>
        ///</summary>
        ///<param name="accountSetName"></param>
        ///<returns></returns>
        AccountSet GetAccountSetByName(string accountSetName);

        #endregion

        #region AccountSetItem
        ///<summary>
        ///</summary>
        ///<param name="accountSetParaID"></param>
        ///<returns></returns>
        int CountAccountSetItemByAccountSetParaID(int accountSetParaID);
        #endregion

        ///<summary>
        ///</summary>
        ///<param name="accountSetName"></param>
        ///<returns></returns>
        List<AccountSet> GetAccountSetByCondition(string accountSetName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        AccountSetPara GetAccountSetParaByName(string name);
    }
}