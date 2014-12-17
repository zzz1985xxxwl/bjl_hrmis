
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace SEP.IBllTest
{
    internal static class CleanUpTestData
    {
        private static SqlCommand _Cmd;
        private static SqlCommand Cmd
        {
            get
            {
                if(_Cmd == null)
                    InitCmd();
                return _Cmd;
            }
        }

        static CleanUpTestData()
        {
            InitCmd();
        }

        private static void InitCmd()
        {
            _Cmd = new SqlCommand();
            _Cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        }

        public static void CleanUpEmployee()
        {
            Cmd.Connection.Open();
            Cmd.CommandText = "DELETE FROM TAccount Where [PKID]<>-9";
            Cmd.CommandType = CommandType.Text;
            Cmd.ExecuteNonQuery();
            Cmd.Connection.Close();
        }

        public static void CleanUpDepartment()
        {
            Cmd.Connection.Open();
            Cmd.CommandText = "DELETE FROM TDepartment";
            Cmd.CommandType = CommandType.Text;
            Cmd.ExecuteNonQuery();
            Cmd.Connection.Close();
        }

        public static void CleanUpWelcomeMail()
        {
            Cmd.Connection.Open();
            Cmd.CommandText = "DELETE FROM TWelcomeMail";
            Cmd.CommandType = CommandType.Text;
            Cmd.ExecuteNonQuery();
            Cmd.Connection.Close();
        }

        public static void CleanUpSpecialDate()
        {
            Cmd.Connection.Open();
            Cmd.CommandText = "DELETE FROM TSpecialDate";
            Cmd.CommandType = CommandType.Text;
            Cmd.ExecuteNonQuery();
            Cmd.Connection.Close();
        }

        public static void CleanUpBulletin()
        {
            Cmd.Connection.Open();
            Cmd.CommandText = "DELETE FROM TBulletin";
            Cmd.CommandType = CommandType.Text;
            Cmd.ExecuteNonQuery();
            Cmd.Connection.Close();
        }
    }
}
