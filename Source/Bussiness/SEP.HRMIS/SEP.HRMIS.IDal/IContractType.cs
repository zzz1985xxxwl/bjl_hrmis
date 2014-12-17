
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    public interface IContractType
    {
        int InsertContractType(ContractType contractType);
        int UpdateContractType(ContractType contractType);
        int DeleteContractType(int ContractTypeId);
        int CountContractTypeByName(string contractTypeName);
        int CountContractTypeByNameDiffPKID(int PKID, string contractTypeName);
        ContractType GetContractTypeByPkid(int pkid);
        List<ContractType> GetContractTypeByCondition(int pkid, string name);
    }
}
