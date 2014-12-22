using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFileCargoFacade
    {
        /// <summary>
        /// 
        /// </summary>
        void AddFileCargo(FileCargo fileCargo);
        /// <summary>
        /// 
        /// </summary>
        void UpdateFileCargo(FileCargo fileCargo);
        /// <summary>
        /// 
        /// </summary>
        void DeleteFileCargo(int fileCargoID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<FileCargo> GetFileCargoByAccountID(int accountID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileCargoID"></param>
        /// <returns></returns>
        FileCargo GetFileCargoByFileCargoID(int FileCargoID);
    }
}