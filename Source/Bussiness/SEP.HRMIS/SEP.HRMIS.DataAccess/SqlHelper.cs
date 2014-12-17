using System.Configuration;
using System.Data.SqlClient;

namespace SEP.HRMIS.DataAccess
{
    internal sealed class SqlHelper
    {
        /// <summary>
        ///   读取App.config中的数据库链接
        /// </summary>
        public static string HrmisConnectionString = ConfigurationManager.AppSettings["HRMISConnectionString"];

        public static string SEPConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        private static string _SEPDBName;

        public static string SEPDBName
        {
            get
            {
                if (string.IsNullOrEmpty(_SEPDBName))
                {
                    using (var conn = new SqlConnection(SEPConnectionString))
                    {
                        _SEPDBName = conn.Database;
                    }
                }
                return _SEPDBName;
            }
        }

        private static string _HrmisDBName;

        public static string HrmisDBName
        {
            get
            {
                if (string.IsNullOrEmpty(_HrmisDBName))
                {
                    using (var conn = new SqlConnection(HrmisConnectionString))
                    {
                        _HrmisDBName = conn.Database;
                    }
                }
                return _HrmisDBName;
            }
        }
    }
}