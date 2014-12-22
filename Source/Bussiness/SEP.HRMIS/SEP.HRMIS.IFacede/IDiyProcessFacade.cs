using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;

namespace SEP.HRMIS.IFacede
{
    ///<summary>
    ///</summary>
    public interface IDiyProcessFacade
    {
        ///<summary>
        /// 根据自定义流程类型获取自定义流程
        ///</summary>
        ///<param name="processTypeId"></param>
        ///<returns></returns>
        List<DiyProcess> GetDiyProcessByProcessType(int processTypeId);

        /// <summary>
        /// 获取某人流程中的详细步骤
        /// </summary>
        /// <param name="accountId">员工id</param>
        /// <param name="DiyprocessId">diy流程id</param>
        /// <returns></returns>
        string GetDiyProcessStepString(int accountId, int DiyprocessId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diyProcess"></param>
        void AddDiyProcess(DiyProcess diyProcess);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diyProcess"></param>
        void UpdateDiyProcess(DiyProcess diyProcess);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diyProcessID"></param>
        void DeleteDiyProcess(int diyProcessID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processTypeId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        List<DiyProcess> GetDiyProcessByCondition(int processTypeId, string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DiyProcess GetDiyProcessByPKID(int id);
    }
}
