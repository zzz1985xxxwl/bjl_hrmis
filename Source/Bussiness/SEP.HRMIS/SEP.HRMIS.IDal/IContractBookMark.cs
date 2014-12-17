
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    public interface IContractBookMark
    {
        int InsertContractBookMark(ContractBookMark contractBookMark);
        int DeleteContractBookMarkByContractTypeID(int contractTypeID);
        List<ContractBookMark> GetContractBookMarkByContractTypeID(int contractTypeID);

    }
}
