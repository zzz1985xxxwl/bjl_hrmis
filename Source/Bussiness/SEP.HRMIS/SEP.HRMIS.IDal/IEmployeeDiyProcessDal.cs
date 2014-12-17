using SEP.HRMIS.Model.DiyProcesss;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEmployeeDiyProcessDal
    {

        ///<summary>
        ///</summary>
        ///<param name="accountID"></param>
        ///<param name="diyProcess"></param>
        ///<returns></returns>
        int InsertEmployeeDiyProcess(int accountID,DiyProcess diyProcess);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="accountID"></param>
        /// <returns></returns>
        DiyProcess GetDiyProcessByProcessTypeAndAccountID(ProcessType type, int accountID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        int DeleteEmployeeDiyProcessByAccountID(int employeeID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diyProcessID"></param>
        /// <returns></returns>
        int CountAccountByDiyProcessID(int diyProcessID);
    }
}
