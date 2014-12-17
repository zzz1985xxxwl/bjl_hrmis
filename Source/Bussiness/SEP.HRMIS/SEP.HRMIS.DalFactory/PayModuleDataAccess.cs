using System.Text;
using System.Reflection;
using SEP.HRMIS.IDal.PayModule;

namespace SEP.HRMIS.DalFactory
{
    ///<summary>
    ///</summary>
    public class PayModuleDataAccess
    {
        public static string _path = DataAccess._path;

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public static IAccountSet CreateAccountSet()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".PayModule.AccountSetDal");
            return (IAccountSet)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public static IEmployeeAccountSet CreateEmployeeAccountSet()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".PayModule.EmployeeAccountSetDal");
            return (IEmployeeAccountSet)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public static IEmployeeSalary CreateEmployeeSarary()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".PayModule.EmployeeSalaryDal");
            return (IEmployeeSalary)Assembly.Load(_path).CreateInstance(className.ToString());
        }

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public static ITax CreateTax()
        {
            if (string.IsNullOrEmpty(_path))
            {
                return null;
            }
            StringBuilder className = new StringBuilder();
            className.Append(_path).Append(".PayModule.TaxDal");
            return (ITax)Assembly.Load(_path).CreateInstance(className.ToString());
        }
    }
}
