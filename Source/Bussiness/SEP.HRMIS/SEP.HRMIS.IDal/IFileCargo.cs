using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFileCargo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileCargo"></param>
        /// <returns></returns>
        int Insert(FileCargo fileCargo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileCargo"></param>
        /// <returns></returns>
        int Update(FileCargo fileCargo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pKID"></param>
        /// <returns></returns>
        int Delete(int pKID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pKID"></param>
        /// <returns></returns>
        FileCargo GetFileCargoByFileCargoID(int pKID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<FileCargo> GetFileCargoByAccountID(int accountID);
    }
}