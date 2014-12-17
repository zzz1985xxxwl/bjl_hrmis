using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.ReadExternalData
{
    /// <summary>
    /// 调用WCF从Access读取考勤机数据
    /// </summary>
    internal class ReadAccessData
    {
        /// <summary>
        /// 调用WCF从Access按时间读取考勤机数据
        /// </summary>
        public List<DataFromAccess> ReadRecords(DateTime laseReadTime)
        {
            List<DataFromAccess> DataFromAccessList = new List<DataFromAccess>();
            using (ReadDataClient proxy = new ReadDataClient("BasicHttpBinding_IReadData"))
            {
                ReadDataAccessModel.DataFromAccess[] obj = proxy.ReadRecords(laseReadTime);
                for (int i = 0; i < obj.Length; i++)
                {
                    InOutStatusEnum inOut;
                    switch (obj[i].InOrOut)
                    {
                        case ReadDataAccessModel.InOutStatusEnum.In:
                            inOut = InOutStatusEnum.In;
                            break;
                        case ReadDataAccessModel.InOutStatusEnum.Out:
                            inOut = InOutStatusEnum.Out;
                            break;
                        default:
                            inOut = InOutStatusEnum.All;
                            break;
                    }
                    DataFromAccess dataFromAccess = new DataFromAccess(obj[i].CardNo, inOut, obj[i].IOTime);
                    DataFromAccessList.Add(dataFromAccess);
                }
            }
            return DataFromAccessList;
        }

        public List<DataFromAccess> ReadRecords(DateTime readFromTime, DateTime readToTime)
        {
            List<DataFromAccess> DataFromAccessList = new List<DataFromAccess>();
            using (ReadDataClient proxy = new ReadDataClient("BasicHttpBinding_IReadData"))
            {
                ReadDataAccessModel.DataFromAccess[] obj = proxy.ReadRecordsWithReadTime(readFromTime, readToTime);
                for (int i = 0; i < obj.Length; i++)
                {
                    InOutStatusEnum inOut;
                    switch (obj[i].InOrOut)
                    {
                        case ReadDataAccessModel.InOutStatusEnum.In:
                            inOut = InOutStatusEnum.In;
                            break;
                        case ReadDataAccessModel.InOutStatusEnum.Out:
                            inOut = InOutStatusEnum.Out;
                            break;
                        default:
                            inOut = InOutStatusEnum.All;
                            break;
                    }
                    DataFromAccess dataFromAccess = new DataFromAccess(obj[i].CardNo, inOut, obj[i].IOTime);
                    DataFromAccessList.Add(dataFromAccess);
                }
            }
            return DataFromAccessList;
        }

        //note colbert for test
        public List<DataFromAccess> ReadRecordsTest(DateTime laseReadTime)
        {
            string _OleDbConnection = ConfigurationManager.AppSettings["OleDbConnection"];

            OleDbConnection conn = null;
            OleDbDataReader readerEntryrec = null;
            List<DataFromAccess> returnDataList = new List<DataFromAccess>();
            try
            {
                //User Id=staples\wang.yueqi;Password=yueqiwang;
                //Jet OLEDB:Database Password=databasepw;
                //ConnectionIP();
                conn = new OleDbConnection(@_OleDbConnection);
                conn.Open();

                OleDbCommand cmd =
                    new OleDbCommand("Select * FROM entryrec where entry_dt >= #" +
                    laseReadTime + "# order by Card_No", conn);
                readerEntryrec = cmd.ExecuteReader();

                while (readerEntryrec.Read())
                {
                    string cardNo = Convert.ToString(readerEntryrec["Card_No"]);
                    DateTime iOTime = Convert.ToDateTime(readerEntryrec["entry_dt"]);
                    InOutStatusEnum statusEnum = InOutStatusEnum.Out;
                    int i = Convert.ToInt32(readerEntryrec["Reader"]);
                    //进出状态 0为进 1为出
                    if (i == 1)
                    {
                        statusEnum = InOutStatusEnum.In;
                    }
                    DataFromAccess data = new DataFromAccess(cardNo, statusEnum, iOTime);
                    
                    returnDataList.Add(data);
                }
                return returnDataList;
            }
            finally
            {
                if (readerEntryrec != null) 
                    readerEntryrec.Close();
                if (conn != null) 
                    conn.Close();
            }
        }
    }
}
