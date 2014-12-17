using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SmsControlContract.ClientAddressModels;
using SqlServerDal.MessageDal;

namespace SqlServerDal.AddressDal
{
    public class SqlServerImplClientInformation : IClientInformationDal
    {
        private SqlConnection _Conn;
        private SqlTransaction _Trans;
        private const string _DbError = "数据库访问错误";
        //数据库参数
        private const string _PKID = "@PKID";
        private const string _HrmisId = "@HrmisId";
        private const string _CompanyDescription = "@CompanyDescription";
        private const string _IsPermitted = "@IsPermitted";
        private const string _ClientInformationId = "@ClientInformationId";
        private const string _ListenAddress = "@ListenAddress";
        private const string _IsActived = "@IsActived";
        private const string _LastTryActivitedTime = "@LastTryActivitedTime";

        //数据库字段
        private const string _DBPKID = "PKID";
        private const string _DBHrmisId = "HrmisId";
        private const string _DBCompanyDescription = "CompanyDescription";
        private const string _DBIsPermitted = "IsPermitted";
        private const string _DBIsActived = "IsActived";
        private const string _DBListenAddress = "ListenAddress";
        private const string _DBLastTryActivitedTime = "LastTryActivitedTime";

        public List<ClientInformationModel> GetAllClientInfomationModel()
        {
            List<ClientInformationModel> retVal = new List<ClientInformationModel>();
            SqlCommand cmd = new SqlCommand();
            //数据库编码当参数取-1时获取所有的的值
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = -1;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetClientInformationByPkid", cmd))
            {
                while (sdr.Read())
                {
                    bool isPermitted = int.Parse(sdr[_DBIsPermitted].ToString()) > 0 ? true : false;
                    ClientInformationModel anObject = new ClientInformationModel(sdr[_DBHrmisId].ToString(), sdr[_DBCompanyDescription].ToString(), isPermitted);
                    anObject.Pkid = int.Parse(sdr[_DBPKID].ToString());
                    LoadListenAddressFor(anObject);

                    retVal.Add(anObject);
                }
            }
            return retVal;
        }

        public void InsertClientInfomationModel(ClientInformationModel aClientAddressModel)
        {
            InitializeTranscation();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
                TheNeedParametersForClientInformationModel(cmd, aClientAddressModel);

                int pkid;
                SqlHelper.TransExecuteNonQueryReturnPKID("ClientInformationInsert", cmd, _Conn, _Trans, out pkid);
                aClientAddressModel.Pkid = pkid;

                InsertToAddressTable(pkid, aClientAddressModel);

                _Trans.Commit();
            }
            catch
            {
                _Trans.Rollback();
                throw new ApplicationException(_DbError);
            }
            finally
            {
                _Conn.Close();
            }
        }

        public void UpdateClientInfomationModel(ClientInformationModel theClientInfomationModel)
        {
            InitializeTranscation();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = theClientInfomationModel.Pkid;
                TheNeedParametersForClientInformationModel(cmd, theClientInfomationModel);
                SqlHelper.TransExecuteNonQuery("ClientInformationUpdate", cmd, _Conn, _Trans);

                DeleteListenAddressModelByClientInformationId(theClientInfomationModel.Pkid);
                InsertToAddressTable(theClientInfomationModel.Pkid, theClientInfomationModel);

                _Trans.Commit();
            }
            catch
            {
                _Trans.Rollback();
                throw new ApplicationException(_DbError);
            }
            finally
            {
                _Conn.Close();
            }
        }

        public void DeleteClientInfomationModelById(int pkid)
        {
            InitializeTranscation();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pkid;
                SqlHelper.TransExecuteNonQuery("DeleteClientInformationByPkid", cmd, _Conn, _Trans);

                DeleteListenAddressModelByClientInformationId(pkid);

                _Trans.Commit();
            }
            catch
            {
                _Trans.Rollback();
                throw new ApplicationException(_DbError);
            }
            finally
            {
                _Conn.Close();
            }
        }

        public ClientInformationModel GetClientInformationById(int pkid)
        {
            ClientInformationModel retVal = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Value = pkid;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetClientInformationByPkid", cmd))
            {
                while (sdr.Read())
                {
                    bool isPermitted = int.Parse(sdr[_DBIsPermitted].ToString()) > 0 ? true : false;
                    retVal = new ClientInformationModel(sdr[_DBHrmisId].ToString(), sdr[_DBCompanyDescription].ToString(), isPermitted);
                    retVal.Pkid = pkid;
                    LoadListenAddressFor(retVal);
                }
            }
            return retVal;
        }

        #region 私有方法

        private void LoadListenAddressFor(ClientInformationModel theObject)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ClientInformationId, SqlDbType.Int).Value = theObject.Pkid;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetListenAddressByClientInformationId", cmd))
            {
                while (sdr.Read())
                {
                    bool isPermitted = int.Parse(sdr[_DBIsPermitted].ToString()) > 0 ? true : false;
                    bool isActived = int.Parse(sdr[_DBIsActived].ToString()) > 0 ? true : false;
                    ListenAddressModel theModel = new ListenAddressModel(sdr[_DBListenAddress].ToString(), isPermitted, isActived, DateTime.Parse(sdr[_DBLastTryActivitedTime].ToString()));
                    theModel.Pkid = int.Parse(sdr[_DBPKID].ToString());

                    theObject.TheAddressModelCollcetion.Add(theModel);
                }
            }
        }

        private void InsertToAddressTable(int clientInformationId, ClientInformationModel theObj)
        {
            foreach (ListenAddressModel lam in theObj.TheAddressModelCollcetion)
            {
                InsertListenAddressModel(clientInformationId, lam);
            }
        }

        private void InsertListenAddressModel(int clientInformationId, ListenAddressModel aClientAddressModel)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_ClientInformationId, SqlDbType.Int).Value = clientInformationId;
            cmd.Parameters.Add(_ListenAddress, SqlDbType.NVarChar, 255).Value = aClientAddressModel.ListenAddress;
            cmd.Parameters.Add(_IsPermitted, SqlDbType.Int).Value = aClientAddressModel.IsPermitted;
            cmd.Parameters.Add(_IsActived, SqlDbType.Int).Value = aClientAddressModel.IsActivited;
            cmd.Parameters.Add(_LastTryActivitedTime, SqlDbType.DateTime).Value = aClientAddressModel.LastTryActivitedTime;
            int pkid;
            SqlHelper.TransExecuteNonQueryReturnPKID("ListenAddressInsert", cmd, _Conn, _Trans, out pkid);
            aClientAddressModel.Pkid = pkid;
        }

        private void DeleteListenAddressModelByClientInformationId(int clientInfomationId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_ClientInformationId, SqlDbType.Int).Value = clientInfomationId;
            SqlHelper.TransExecuteNonQuery("DeleteListenAddressModelByClientInformationId", cmd, _Conn, _Trans);
        }

        private void TheNeedParametersForClientInformationModel(SqlCommand cmd, ClientInformationModel aClientAddressModel)
        {
            cmd.Parameters.Add(_HrmisId, SqlDbType.NVarChar, 255).Value = aClientAddressModel.HrmisId;
            cmd.Parameters.Add(_CompanyDescription, SqlDbType.NVarChar, 255).Value = aClientAddressModel.CompanyDescription;
            cmd.Parameters.Add(_IsPermitted, SqlDbType.Int).Value = aClientAddressModel.IsPermitted;
        }

        private void InitializeTranscation()
        {
            _Conn = new SqlConnection(SqlHelper._ConnectionStringProfile);
            _Conn.Open();
            _Trans = _Conn.BeginTransaction(IsolationLevel.ReadUncommitted);
        }


        #endregion
    }
}