
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    public interface IEmployeeContractBookMark
    {
        int InsertEmployeeContractBookMark(EmployeeContractBookMark employeecontractBookMark);
        int DeleteEmployeeContractBookMarkByContractID(int contractID);
        List<EmployeeContractBookMark> GetEmployeeContractBookMarkByContractID(int contractID);
    }
}
