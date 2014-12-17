//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: TransferService.cs
// ������: �ߺ�
// ��������: 2009-05-6
// ����: �����ⲿ�ӿڵ�һ��ʵ��,TApplicationFilter�Ƿ���������
//       ���������ݿ⺬��3�ű�TApplication,TApplicationEmployee,
//       TApplicationFlow,����Ĳ��Խ�����һ����Ϊ��ʱ���ɵ����ݿ�
//       һ����ϵͳ�����ݿ⣬��Ȼ��鿴����Ǩ�������Ƿ�����
// ----------------------------------------------------------------
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using NUnit.Framework;
using TransferDatas;

namespace TransferDatasTest
{
    [TestFixture]
    public class ApplicationFilterTest
    {
        private string _ConnectionString;
        private string _TestTempDirectory;
        private const string _MainTableName = "TApplication";
        private const string _TempDbName = "TestApplicationFilterTempDb";
        private const string _RestoreDbName = "TestApplicationFilterRestoreDb";

        #region SeUp&TearDown

        [SetUp]
        public void SetUp()
        {
            //�����ļ���ȡ
            _ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            _TestTempDirectory = ConfigurationManager.AppSettings["TestTempDirectory"];
            Assert.IsNotNull(_ConnectionString);
            Assert.IsNotNull(_TestTempDirectory);
            StaticConfigTable.ConnectionString = _ConnectionString;
            DiskOperations.CheckAndCreateDirectory(DiskOperations.CorrectDirectory(_TestTempDirectory));
            //���ݿ���Դ·��
            string currentPath = Environment.CurrentDirectory;
            string theBackUpDb = string.Format(@"{0}\..\..\TestResources\TestApplicationFilterDb.bak", currentPath);
            Assert.IsTrue(File.Exists(theBackUpDb));
            //��ʼ����2�����ݿ�
            SqlCommandRunner.RestoreDbFromFile(_TempDbName, DiskOperations.CorrectDirectory(_TestTempDirectory), theBackUpDb);
            SqlCommandRunner.RestoreDbFromFile(_RestoreDbName, DiskOperations.CorrectDirectory(_TestTempDirectory), theBackUpDb);
        }

        [TearDown]
        public void TearDown()
        {
            SqlCommandRunner.DeleteDb(_TempDbName);
            SqlCommandRunner.DeleteDb(_RestoreDbName);
        }

        #endregion

        [Test, Description("���Զ���ʱ���ݿ������ɸѡ����")]
        public void Test1()
        {
            //����һ����TApplicationΪ����Ǩ�Ʋ��ԣ����Ա�����ִ�У����������е�һ��������ɸѡ���ܽ��в���
            TransferRule aTr = MakeTransferRule();
            ITableFilter theTarget = new TApplicationFilter.TApplicationFilter();
            theTarget.ConfigTheFilter(aTr,_MainTableName, _RestoreDbName, _TempDbName, _RestoreDbName,_TempDbName);
            Assert.AreEqual(2, aTr.DbsToTransfer[0].ProtectTableNames.Count);

            string before = PrintAllTableInfo(aTr);
            Console.WriteLine("ɸѡ֮ǰ�ı���Ϣ");
            Console.WriteLine(before);

            string target = theTarget.FilterTableData(new DateTime(2008, 10, 1), new DateTime(2008, 11, 1));
            Console.WriteLine("����ɸѡ");
            Console.WriteLine(target);

            string after = PrintAllTableInfo(aTr);
            Console.WriteLine();
            Console.WriteLine("ɸѡ֮��ı���Ϣ");
            Console.WriteLine(after);

            Assert.IsTrue(before.Contains("������TApplication,��СID��9,���ID��670,��������615"));
            Assert.IsTrue(before.Contains("������TApplicationEmployee,��СID��8,���ID��1363,��������842"));
            Assert.IsTrue(before.Contains("������TApplicationFlow,��СID��1,���ID��1297,��������1252"));

            Assert.IsTrue(target.Contains("��TApplication����:������615��ɾ��535������"));
            Assert.IsTrue(target.Contains("��TApplicationEmployee����:������842��ɾ��749������"));
            Assert.IsTrue(target.Contains("��TApplicationFlow����:������1252��ɾ��1086������"));

            Assert.IsTrue(after.Contains("������TApplication,��СID��258,���ID��342,��������80"));
            Assert.IsTrue(after.Contains("������TApplicationEmployee,��СID��778,���ID��891,��������93"));
            Assert.IsTrue(after.Contains("������TApplicationFlow,��СID��463,���ID��666,��������166"));
        }

        [Test, Description("���Զ����ݿ���л�ԭ����")]
        public void Test2()
        {
            TransferRule aTr = MakeTransferRule();
            ITableFilter theTarget = new TApplicationFilter.TApplicationFilter();
            theTarget.ConfigTheFilter(aTr, _MainTableName,_RestoreDbName, _TempDbName, _RestoreDbName, _TempDbName);
            Assert.AreEqual(2, aTr.DbsToTransfer[0].ProtectTableNames.Count);

            //��һ�β��ԣ�����û���κ����ݷ����仯
            Console.WriteLine("��һ�β���");
            Console.WriteLine("ɸѡ����");

            string target11 = theTarget.FilterTableData(new DateTime(2008, 10, 1), new DateTime(2008, 11, 1));
            Console.WriteLine(target11);
            Console.WriteLine("���л�ԭ");
            string target12 = theTarget.RestoreTableData(new DateTime(2008, 10, 1), new DateTime(2008, 11, 1));
            Console.WriteLine(target12);
            //ȫ�����ݻ�ԭû���κ����ݸı�
            Assert.IsTrue(target12.Contains("��TApplication���ƣ�����0��,����0��,ɾ��0��"));
            Assert.IsTrue(target12.Contains("��TApplicationEmployee���ƣ�����0��,����0��,ɾ��0��"));
            Assert.IsTrue(target12.Contains("��TApplicationFlow���ƣ�����0��,����0��,ɾ��0��"));

            //�ڶ��β��ԣ��ֱ�ģ�����ݵ�����ɾ����
            Console.WriteLine("�ڶ��β���");
            MockChangment();
            Console.WriteLine("ɸѡ����");
            string target21 = theTarget.FilterTableData(new DateTime(2008, 10, 1), new DateTime(2008, 11, 1));
            Console.WriteLine(target21);
            Console.WriteLine("���л�ԭ");
            string target22 = theTarget.RestoreTableData(new DateTime(2008, 10, 1), new DateTime(2008, 11, 1));
            Console.WriteLine(target22);

            Assert.IsTrue(target22.Contains("��TApplication���ƣ�����1��,����1��,ɾ��1��"));
            Assert.IsTrue(target22.Contains("��TApplicationEmployee���ƣ�����0��,����0��,ɾ��1��"));
            Assert.IsTrue(target22.Contains("��TApplicationFlow���ƣ�����0��,����0��,ɾ��2��"));
        }

        #region ˽�з���

        private void MockChangment()
        {
            //��������һ�м�¼���޸�һ�м�¼��ɾ��һ�м�¼
            //����1ɾ��һ�м�¼������2ɾ��2�м�¼
            string sqlCommand = @"insert into tapplication(applicantid,applicantName,applicationDate,applicationFrom,ApplicationTo,CostTime,Status,Reason,Type,OvertimeType)
                                values(1,'','2008-10-2','2008-10-2','2008-10-2',4,1,'',1,1)
                                update tapplication
                                set applicantName = 'modifyByTester'
                                where pkid =278
                                delete tapplication 
                                where pkid = 279
                                delete tapplicationEmployee
                                where applicationId = 279
                                delete tapplicationFlow
                                where applicationId = 279";

            SqlCommandRunner.ExecuteNonQuery(new SqlCommand(sqlCommand), _TempDbName);
        }


        private string PrintAllTableInfo(TransferRule aTr)
        {
            StringBuilder retVal = new StringBuilder();
            retVal.AppendLine(SqlCommandRunner.GetTableInfo(aTr.DbsToTransfer[0].TablesToTransfer[0].TableName, _TempDbName));
            retVal.AppendLine(SqlCommandRunner.GetTableInfo(aTr.DbsToTransfer[0].ProtectTableNames[0], _TempDbName));
            retVal.AppendLine(SqlCommandRunner.GetTableInfo(aTr.DbsToTransfer[0].ProtectTableNames[1], _TempDbName));
            return retVal.ToString();
        }

        public static TransferRule MakeTransferRule()
        {
      
            TransferRule aMockRule = new TransferRule();
            aMockRule.RuleName = "�½�����Ǩ�Ʋ���";
            DbTransfer dt = new DbTransfer();
            dt.DbName = _RestoreDbName;
            TableTransfer tt = new TableTransfer();
            tt.TableName = "TApplication";
            dt.AddTransferTable(tt);
            aMockRule.DbsToTransfer.Add(dt);

            return aMockRule;
        }

        #endregion

    }
}