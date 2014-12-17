using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Bll.DiyProcesses;

namespace SEP.HRMIS.Facade
{
    ///<summary>
    ///</summary>
    public class DiyProcessFacade : IDiyProcessFacade
    {
        ///<summary>
        /// 根据PKID获取自定义流程
        ///</summary>
        ///<param name="id"></param>
        ///<returns></returns>
        public DiyProcess GetDiyProcessByPKID(int id)
        {
            return new GetDiyProcess().GetDiyProcessByPKID(id);
        }

        ///<summary>
        /// 根据自定义流程类型获取自定义流程
        ///</summary>
        ///<param name="processTypeId"></param>
        ///<returns></returns>
        public List<DiyProcess> GetDiyProcessByProcessType(int processTypeId)
        {
           return new GetDiyProcess().GetDiyProcessByProcessType(processTypeId);
        }

        /// <summary>
        /// 获取某人流程中的详细步骤
        /// </summary>
        /// <param name="accountId">员工id</param>
        /// <param name="DiyprocessId">diy流程id</param>
        /// <returns></returns>
        public string GetDiyProcessStepString(int accountId, int DiyprocessId)
        {
            return new GetDiyProcess().GetDiyProcessStepString(accountId, DiyprocessId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diyProcess"></param>
        public void AddDiyProcess(DiyProcess diyProcess)
        {
            new AddDiyProcess(diyProcess).Excute();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diyProcess"></param>
        public void UpdateDiyProcess(DiyProcess diyProcess)
        {
            new UpdateDiyProcess(diyProcess).Excute();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diyProcessID"></param>
        public void DeleteDiyProcess(int diyProcessID)
        {
            new DeleteDiyProcess(diyProcessID).Excute();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processTypeId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<DiyProcess> GetDiyProcessByCondition(int processTypeId, string name)
        {
            return new GetDiyProcess().GetDiyProcessByCondition(processTypeId, name);
        }
    }
}
