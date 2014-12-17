//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights ReadIODataFromAccess.
// �ļ���: ReadIODataFromAccess.cs
// ������: ����
// ��������: 2008-12-01
// ����: ��ACCESS�����ݽӿ�ʵ��
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using ReadDataAccessModel;


namespace ReadDataFromAccessService
{         
    public class ReadIODataFromAccess:IReadData
    {
        //private readonly string _Card_No = "Card_No";
        //private readonly string _IO = "Reader";
        //private readonly string _IOTime = "entry_dt";
        private string _OleDbConnection;
        //private static string _IP;
        //private static string _User;
        //private static string _PaseWord;
        private static string strErrorMsg;
        public List<DataFromAccess> ReadRecords(DateTime lastReadTime)
        {
            _OleDbConnection = ConfigurationManager.AppSettings["OleDbConnection"];

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

                #region modify by liudan 2009-08-13
                //OleDbCommand cmd =
                //    new OleDbCommand("Select * FROM entryrec where entry_dt >= #" +
                //    lastReadTime + "# order by Card_No", conn);
                //readerEntryrec = cmd.ExecuteReader();

                //while (readerEntryrec.Read())
                //{
                //    DataFromAccess data=new DataFromAccess();
                //    data.CardNo = Convert.ToString(readerEntryrec[_Card_No]);
                //    string s = (readerEntryrec[_IO]).ToString();

                //    int i = Convert.ToInt32(readerEntryrec[_IO]);
                //    //����״̬ 0Ϊ�� 1Ϊ��
                //    if (i == 1)
                //    {
                //        data.InOrOut = InOutStatusEnum.In;
                //    }
                //    else
                //    {
                //        data.InOrOut = InOutStatusEnum.Out;
                //    }
                //    data.IOTime = Convert.ToDateTime(readerEntryrec[_IOTime]);
                //    returnDataList.Add(data);
                //}
                //return returnDataList;
                #endregion
                string queryString = "Select USERINFO.USERID,USERINFO.CardNo, CHECKINOUT.CHECKTIME, CHECKINOUT.CHECKTYPE FROM USERINFO,CHECKINOUT where CHECKINOUT.CHECKTIME>= #" +
             lastReadTime + "# and USERINFO.USERID=CHECKINOUT.USERID order by CHECKINOUT.USERID";
                OleDbCommand cmd =
                    new OleDbCommand(queryString, conn);
                readerEntryrec = cmd.ExecuteReader();

                while (readerEntryrec.Read())
                {
                    DataFromAccess data = new DataFromAccess();
                    data.CardNo = Convert.ToString(readerEntryrec["CardNo"]);
                    data.IOTime = Convert.ToDateTime(readerEntryrec["CHECKTIME"]);
                    InOutStatusEnum statusEnum = InOutStatusEnum.Out;
                    string ioStatus = Convert.ToString(readerEntryrec["CHECKTYPE"]);
                    //����״̬ 0Ϊ�� 1Ϊ��
                    if (ioStatus.Equals("I"))
                    {
                        statusEnum = InOutStatusEnum.In;
                    }
                    data.InOrOut = statusEnum;
                    returnDataList.Add(data);
                }
                return returnDataList;
            }
            catch (Exception ex)
            {
                // ������Ϣ
                strErrorMsg = "�쳣��\n" + ex.Message;
                //// д��־
                TLineEventLog el = new TLineEventLog();
                el.DoWriteEventLog(strErrorMsg, EventType.Error);
                return returnDataList;
            }
            finally
            {
                if (readerEntryrec != null) readerEntryrec.Close();
                if (conn != null) conn.Close();
            }
        }

        public List<DataFromAccess> ReadRecordsWithReadTime(DateTime readFromTime, DateTime readToTime)
        {
            _OleDbConnection = ConfigurationManager.AppSettings["OleDbConnection"];

            OleDbConnection conn = null;
            OleDbDataReader readerEntryrec = null;
            List<DataFromAccess> returnDataList = new List<DataFromAccess>();
            try
            {
                conn = new OleDbConnection(@_OleDbConnection);
                conn.Open();

                #region modify by liudan 2009-08-13
                #endregion
                string queryString = "Select USERINFO.USERID,USERINFO.CardNo, CHECKINOUT.CHECKTIME, CHECKINOUT.CHECKTYPE FROM USERINFO,CHECKINOUT where CHECKINOUT.CHECKTIME>= #" +
             readFromTime + "# and CHECKINOUT.CHECKTIME<=#" + readToTime + "# and USERINFO.USERID=CHECKINOUT.USERID order by CHECKINOUT.USERID";
                OleDbCommand cmd =
                    new OleDbCommand(queryString, conn);
                readerEntryrec = cmd.ExecuteReader();

                while (readerEntryrec.Read())
                {
                    DataFromAccess data = new DataFromAccess();
                    data.CardNo = Convert.ToString(readerEntryrec["CardNo"]);
                    data.IOTime = Convert.ToDateTime(readerEntryrec["CHECKTIME"]);
                    InOutStatusEnum statusEnum = InOutStatusEnum.Out;
                    string ioStatus = Convert.ToString(readerEntryrec["CHECKTYPE"]);
                    //����״̬ 0Ϊ�� 1Ϊ��
                    if (ioStatus.Equals("I"))
                    {
                        statusEnum = InOutStatusEnum.In;
                    }
                    data.InOrOut = statusEnum;
                    returnDataList.Add(data);
                }
                return returnDataList;
            }
            catch (Exception ex)
            {
                // ������Ϣ
                strErrorMsg = "�쳣��\n" + ex.Message;
                //// д��־
                TLineEventLog el = new TLineEventLog();
                el.DoWriteEventLog(strErrorMsg, EventType.Error);
                return returnDataList;
            }
            finally
            {
                if (readerEntryrec != null) readerEntryrec.Close();
                if (conn != null) conn.Close();
            }
        }

        //private static void ConnectionIP()
        //{
        //    _IP = ConfigurationManager.AppSettings["IP"];
        //    _User = ConfigurationManager.AppSettings["User"];
        //    _PaseWord = ConfigurationManager.AppSettings["PassWord"];

        //    Process p = new Process();
        //    p.StartInfo.FileName = "cmd.exe";
        //    p.StartInfo.UseShellExecute = false; //�ر�Shell��ʹ�� 
        //    p.StartInfo.RedirectStandardInput = true;//�ض����׼���� 
        //    p.StartInfo.RedirectStandardOutput = true;//�ض����׼��� 
        //    p.StartInfo.RedirectStandardError = true; //�ض��������� 
        //    p.StartInfo.CreateNoWindow = true;
        //    try
        //    {
        //        p.Start();
        //        p.StandardInput.WriteLine(@"net use " + _IP + "ipc$ " + _PaseWord + " /user:" + _User);
        //        p.StandardInput.WriteLine("exit");
        //        p.StandardOutput.ReadToEnd();
        //        p.WaitForExit();
        //        p.Close();
        //    }
        //    catch
        //    {
        //    }

        //}
    }
}
