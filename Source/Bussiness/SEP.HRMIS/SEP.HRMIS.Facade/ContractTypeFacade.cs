using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Facade
{
    public class ContractTypeFacade : IContractTypeFacade
    {
        public void AddContractType(ContractType contractType)
        {
            AddContractType AddContractType = new AddContractType(contractType);
            AddContractType.Excute();
        }

        public void UpdateContractType(ContractType contractType)
        {
            UpdateContractType UpdateContractType = new UpdateContractType(contractType);
            UpdateContractType.Excute();
        }

        public void DeleteContractType(int contractTypeId)
        {
            DeleteContractType DeleteContractType = new DeleteContractType(contractTypeId);
            DeleteContractType.Excute();
        }

        public ContractType GetContractTypeByPKID(int pkid)
        {
            GetContractType GetContractType=new GetContractType();
            return GetContractType.GetContractTypeByPKID(pkid);
        }

        public List<ContractType> GetContractTypeByCondition(int pkid, string name)
        {
            GetContractType GetContractType = new GetContractType();
            return GetContractType.GetContractTypeByCondition(pkid, name);
        }

        public ContractType GetContractTypeByContractID(int contractId)
        {
            GetContractType GetContractType = new GetContractType();
            return GetContractType.GetContractTypeByContractID(contractId);
        }
    }
}
