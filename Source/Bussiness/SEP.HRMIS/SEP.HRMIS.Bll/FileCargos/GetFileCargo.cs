using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.FileCargos
{
    /// <summary>
    /// 
    /// </summary>
    public class GetFileCargo
    {
        private static readonly IFileCargo _FileCargoDal = DalFactory.DataAccess.CreateFileCargo();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<FileCargo> GetFileCargoByAccountID(int accountID)
        {
           return _FileCargoDal.GetFileCargoByAccountID(accountID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileCargoID"></param>
        /// <returns></returns>
        public FileCargo GetFileCargoByFileCargoID(int FileCargoID)
        {
            return _FileCargoDal.GetFileCargoByFileCargoID(FileCargoID);
        }
    }
}