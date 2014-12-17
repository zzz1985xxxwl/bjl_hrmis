using SEP.HRMIS.Model.DiyProcesss;

namespace SEP.HRMIS.IDal
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public interface IDiyProcessDal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="diyProcess"></param>
        /// <returns></returns>
        int InsertDiyProcess(DiyProcess diyProcess);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diyProcess"></param>
        /// <returns></returns>
        int UpdateDiyProcess(DiyProcess diyProcess);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diyProcessID"></param>
        /// <returns></returns>
        int DeleteDiyProcess(int diyProcessID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diyProcessID"></param>
        /// <returns></returns>
        DiyProcess GetDiyProcessByPKID(int diyProcessID);

        ///<summary>
        /// 根据自定义流程类型获取自定义流程
        ///</summary>
        ///<param name="processTypeId"></param>
        ///<returns></returns>
        List<DiyProcess> GetDiyProcessByProcessType(int processTypeId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int CountDiyProcessByName(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        int CountDiyProcessByNameDiffPKID(int id, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processTypeId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        List<DiyProcess> GetDiyProcessByCondition(int processTypeId, string name);
    }
}