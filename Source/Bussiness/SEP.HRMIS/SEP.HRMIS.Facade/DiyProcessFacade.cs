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
        /// ����PKID��ȡ�Զ�������
        ///</summary>
        ///<param name="id"></param>
        ///<returns></returns>
        public DiyProcess GetDiyProcessByPKID(int id)
        {
            return new GetDiyProcess().GetDiyProcessByPKID(id);
        }

        ///<summary>
        /// �����Զ����������ͻ�ȡ�Զ�������
        ///</summary>
        ///<param name="processTypeId"></param>
        ///<returns></returns>
        public List<DiyProcess> GetDiyProcessByProcessType(int processTypeId)
        {
           return new GetDiyProcess().GetDiyProcessByProcessType(processTypeId);
        }

        /// <summary>
        /// ��ȡĳ�������е���ϸ����
        /// </summary>
        /// <param name="accountId">Ա��id</param>
        /// <param name="DiyprocessId">diy����id</param>
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
