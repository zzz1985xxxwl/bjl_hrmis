using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IFacede
{
    public interface IContractTypeFacade
    {
        /// <summary>
        /// 新增合同类型
        /// </summary>
        /// <param name="contractType"></param>
        void AddContractType(ContractType contractType);
        /// <summary>
        /// 修改合同类型
        /// </summary>
        /// <param name="contractType"></param>
        void UpdateContractType(ContractType contractType);
        /// <summary>
        /// 删除合同类型
        /// </summary>
        /// <param name="pkid"></param>
        void DeleteContractType(int pkid);
        /// <summary>
        /// 根据PKID获得合同类型
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        ContractType GetContractTypeByPKID(int pkid);
        /// <summary>
        /// 根据条件获得合同类型
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        List<ContractType> GetContractTypeByCondition(int pkid, string name);
        /// <summary>
        /// 根据合同获得合同类型
        /// </summary>
        /// <param name="contractID"></param>
        /// <returns></returns>
        ContractType GetContractTypeByContractID(int contractID);
    }
}
