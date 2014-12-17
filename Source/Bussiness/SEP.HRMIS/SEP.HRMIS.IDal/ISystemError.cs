using System.Collections.Generic;
using SEP.HRMIS.Model.SystemError;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISystemError
    {
        /// <summary>
        /// </summary>
        int SystemErrorInsert(SystemError systemError);
        /// <summary>
        /// </summary>
        int DeleteSystemErrorByTypeAndMarkID(ErrorType errorType, int markID);
        /// <summary>
        /// </summary>
        SystemError GetSystemErrorByTypeAndMarkID(ErrorType errorType, int markID);
        /// <summary>
        /// </summary>
        List<SystemError> GetAllIgnoreSystemError();
        /// <summary>
        /// </summary>
        List<SystemError> GetAcBaseSystemError();

    }
}