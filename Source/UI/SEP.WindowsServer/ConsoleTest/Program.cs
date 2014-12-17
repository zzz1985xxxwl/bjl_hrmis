using System;
using System.Configuration;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;
using SEP.Model.Accounts;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string _IsAutoSystemRead = ConfigurationManager.AppSettings["IsAutoSystemRead"];
            if (_IsAutoSystemRead == "true")
                AutoSystemRead();
            else
            {
                AutoSystemReadFromSetTime();
            }
        }


        private static void AutoSystemRead()
        {
            try
            {
                ReadDataHistory readNewHistory = new ReadDataHistory(DateTime.Now, ReadDataResultType.Reading,"");
                InstanceFactory.ReadExternalDataFacade.SystemReadDataFromAccessToSQL(readNewHistory, new Account());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void AutoSystemReadFromSetTime()
        {
            try
            {
                InstanceFactory.ReadExternalDataFacade.SystemReadDataFromSetTime(new Account());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
