using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IFacede
{
    public interface IContractTypeFacade
    {
        /// <summary>
        /// ������ͬ����
        /// </summary>
        /// <param name="contractType"></param>
        void AddContractType(ContractType contractType);
        /// <summary>
        /// �޸ĺ�ͬ����
        /// </summary>
        /// <param name="contractType"></param>
        void UpdateContractType(ContractType contractType);
        /// <summary>
        /// ɾ����ͬ����
        /// </summary>
        /// <param name="pkid"></param>
        void DeleteContractType(int pkid);
        /// <summary>
        /// ����PKID��ú�ͬ����
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        ContractType GetContractTypeByPKID(int pkid);
        /// <summary>
        /// ����������ú�ͬ����
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        List<ContractType> GetContractTypeByCondition(int pkid, string name);
        /// <summary>
        /// ���ݺ�ͬ��ú�ͬ����
        /// </summary>
        /// <param name="contractID"></param>
        /// <returns></returns>
        ContractType GetContractTypeByContractID(int contractID);
    }
}
