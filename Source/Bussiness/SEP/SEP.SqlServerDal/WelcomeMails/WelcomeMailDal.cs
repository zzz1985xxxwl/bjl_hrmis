using System.Data;
using System.Data.SqlClient;
using SEP.IDal.WelcomeMails;
using SEP.Model.Mail;

namespace SEP.SqlServerDal
{
    class WelcomeMailDal : IWelcomeMailDal
    {
        private const string _PKID = "@PKID";
        private const string _Content = "@Content";
        private const string _EnableAutoSend = "@EnableAutoSend";
        private const string _MailType = "@MailType";

        private const string _DBPKID = "PKID";
        private const string _DBContent = "Content";
        private const string _DBEnableAutoSend = "EnableAutoSend";
        //private const string _DBMailType = "MailType";

        public void AddWelcomeMail(WelcomeMail aNewMail)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_Content, SqlDbType.Text).Value = aNewMail.Content;
            cmd.Parameters.Add(_EnableAutoSend, SqlDbType.Int).Value = aNewMail.EnableAutoSend ? 1 : 0;
            cmd.Parameters.Add(_MailType, SqlDbType.Int).Value = aNewMail.TheMailType.Id;
            int pkidOut;
            SqlHelper.ExecuteNonQueryReturnPKID("WelcomeMailInsert", cmd, out pkidOut);
            aNewMail.Id = pkidOut;
        }

        public WelcomeMail GetLastestWelcomeMail()
        {
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLastestWelcomeMail", new SqlCommand()))
            {
                while (sdr.Read())
                {
                    bool enableAutoSend = int.Parse(sdr[_DBEnableAutoSend].ToString()) > 0 ? true : false;
                    WelcomeMail theObj = new WelcomeMail(sdr[_DBContent].ToString(), enableAutoSend);
                    theObj.Id = int.Parse(sdr[_DBPKID].ToString());
                    return theObj;
                }
                return null;
            }
        }

        public WelcomeMail GetLastestWelcomeMailByTypeID(int mailTypeId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_MailType, SqlDbType.Int).Value = mailTypeId;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLastestWelcomeMailByTypeID", cmd))
            {
                while (sdr.Read())
                {
                    bool enableAutoSend = int.Parse(sdr[_DBEnableAutoSend].ToString()) > 0 ? true : false;
                    WelcomeMail theObj = new WelcomeMail(sdr[_DBContent].ToString(), enableAutoSend);
                    theObj.Id = int.Parse(sdr[_DBPKID].ToString());
                    theObj.TheMailType = MailType.GetById(mailTypeId);
                    return theObj;
                }
                return null;
            }
        }
    }
}