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
    public class TLeaveRequestFilterTest
    {
        private string _ConnectionString;
        private string _TestTempDirectory;
        private const string _MainTableName = "TLeaveRequest";
        private const string _TempDbName = "TestTLeaveRequestTempDb";
        private const string _RestoreDbName = "TestTLeaveRequestRestoreDb";

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
            string theBackUpDb = string.Format(@"{0}\..\..\TestResources\TestTLeaveRequestFilterDb.bak", currentPath);
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

        [Test,Description("�������ݵ�ɸѡ����")]
        public void Test1()
        {
            //����һ����TApplicationΪ����Ǩ�Ʋ��ԣ����Ա�����ִ�У����������е�һ��������ɸѡ���ܽ��в���
            TransferRule aTr = MakeTransferRule();
            ITableFilter theTarget = new TLeaveRequestFilter.TLeaveRequestFilter();
            theTarget.ConfigTheFilter(aTr, _MainTableName, _RestoreDbName, _TempDbName, _TempDbName, _RestoreDbName);
            Assert.AreEqual(2, aTr.DbsToTransfer[0].ProtectTableNames.Count);

            string before = PrintAllTableInfo(aTr);
            Console.WriteLine("ɸѡ֮ǰ�ı���Ϣ");
            Console.WriteLine(before);

            string target = theTarget.FilterTableData(new DateTime(2009, 6, 8), new DateTime(2009, 6, 9));
            Console.WriteLine("����ɸѡ");
            Console.WriteLine(target);

            string after = PrintAllTableInfo(aTr);
            Console.WriteLine();
            Console.WriteLine("ɸѡ֮��ı���Ϣ");
            Console.WriteLine(after);

            Assert.IsTrue(before.Contains("������TLeaveRequest,��СID��1,���ID��2,��������2"));
            Assert.IsTrue(before.Contains("������TLeaveRequestItem,��СID��1,���ID��2,��������2"));
            Assert.IsTrue(before.Contains("������TLeaveRequestFlow,��СID��1,���ID��4,��������4"));

            Assert.IsTrue(target.Contains("��TLeaveRequest����:������2��ɾ��1������"));
            Assert.IsTrue(target.Contains("��TLeaveRequestItem����:������2��ɾ��1������"));
            Assert.IsTrue(target.Contains("��TLeaveRequestFlow����:������4��ɾ��2������"));

            Assert.IsTrue(after.Contains("������TLeaveRequest,��СID��1,���ID��1,��������1"));
            Assert.IsTrue(after.Contains("������TLeaveRequestItem,��СID��1,���ID��1,��������1"));
            Assert.IsTrue(after.Contains("������TLeaveRequestFlow,��СID��1,���ID��2,��������2"));
        }

        [Test, Description("���Զ����ݿ���л�ԭ����")]
        public void Test2()
        {
            TransferRule aTr = MakeTransferRule();
            ITableFilter theTarget = new TLeaveRequestFilter.TLeaveRequestFilter();
            theTarget.ConfigTheFilter(aTr, _MainTableName, _RestoreDbName, _TempDbName, _RestoreDbName, _TempDbName);
            Assert.AreEqual(2, aTr.DbsToTransfer[0].ProtectTableNames.Count);

            //��һ�β��ԣ�����û���κ����ݷ����仯
            Console.WriteLine("��һ�β���");
            Console.WriteLine("ɸѡ����");

            string target11 = theTarget.FilterTableData(new DateTime(2009, 6, 1), new DateTime(2009, 6, 30));
            Console.WriteLine(target11);
            Console.WriteLine("���л�ԭ");
            string target12 = theTarget.RestoreTableData(new DateTime(2009, 6, 1), new DateTime(2009, 6, 30));
            Console.WriteLine(target12);
            //ȫ�����ݻ�ԭû���κ����ݸı�
            Assert.IsTrue(target12.Contains("��TLeaveRequest���ƣ�����0��,����0��,ɾ��0��"));
            Assert.IsTrue(target12.Contains("��TLeaveRequestItem���ƣ�����0��,����0��,ɾ��0��"));
            Assert.IsTrue(target12.Contains("��TLeaveRequestFlow���ƣ�����0��,����0��,ɾ��0��"));
            //�ڶ��β��ԣ��ֱ�ģ�����ݵ�����ɾ����
            Console.WriteLine("�ڶ��β���");
            MockChangment();
            Console.WriteLine("ɸѡ����");
            string target21 = theTarget.FilterTableData(new DateTime(2009, 6, 8), new DateTime(2009, 6, 13));
            Console.WriteLine(target21);
            Console.WriteLine("���л�ԭ");
            string target22 = theTarget.RestoreTableData(new DateTime(2009, 6, 8), new DateTime(2009, 6, 13));
            Console.WriteLine(target22);

            //������Filter��ʱ���Ѿ�������TLeaveRequestFlow��2�����ݣ�����ƥ��֮�󽫴���ԭ���ݿ��2������Ҳɾ����
            Assert.IsTrue(target22.Contains("��TLeaveRequestFlow���ƣ�����1��,����2��,ɾ��2��"));
            Assert.IsTrue(target22.Contains("��TLeaveRequestItem���ƣ�����0��,����0��,ɾ��1��"));
            Assert.IsTrue(target22.Contains("��TLeaveRequest���ƣ�����0��,����2��,ɾ��0��"));
        }

        [Test, Description("bug:������������ݵ�ʱ�򣬻���������ظ��޷���������Ϣ")]
        public void Test3()
        {
            TransferRule aTr = MakeTransferRule();
            ITableFilter theTarget = new TLeaveRequestFilter.TLeaveRequestFilter();
            theTarget.ConfigTheFilter(aTr, _MainTableName, _RestoreDbName, _TempDbName, _RestoreDbName, _TempDbName);
            MockAddLeaveRequest();
            Console.WriteLine("ɸѡ����");
            string target21 = theTarget.FilterTableData(new DateTime(2009, 6, 15), new DateTime(2009, 6, 16));
            Console.WriteLine(target21);
            Console.WriteLine("���л�ԭ");
            string target22 = theTarget.RestoreTableData(new DateTime(2009, 6, 15), new DateTime(2009, 6, 16));
            Console.WriteLine(target22);

            Assert.IsTrue(target22.Contains("��TLeaveRequestFlow���ƣ�����1��,����0��,ɾ��0��"));
            Assert.IsTrue(target22.Contains("��TLeaveRequestItem���ƣ�����1��,����0��,ɾ��0��"));
            Assert.IsTrue(target22.Contains("��TLeaveRequest���ƣ�����1��,����0��,ɾ��0��"));
        }

        private void MockAddLeaveRequest()
        { 
            string sqlCommand = @"
            declare @id int
            insert into tleaverequest(accountid,leaverequesttypeid,reason,submitdate,absentfrom,absentto,absenthours,diyprocess)
            values(3,2,'','2009-6-9','2009-6-15','2009-6-15',8,'')
            select @id = SCOPE_IDENTITY()
            insert into tleaverequestitem(leaverequestid,status,absentfrom,absentto,absenthours,nextprocessid)
            values(@id,3,'2009-6-15','2009-6-15',8,3)
            select @id = SCOPE_IDENTITY()
            insert into tleaverequestflow(leaveRequestItemId,operatorId,operation,operationTime,remark)
            values(@id,88,55,'2009-6-9','hello')";
            SqlCommandRunner.ExecuteNonQuery(new SqlCommand(sqlCommand), _TempDbName);
        }

        private void MockChangment()
        {
            string sqlCommand = @"
            --�޸�tleaverequest��2������
            update tleaverequest set absentHours = 999
            --ɾ��tleaverequestItem��1������
            delete tleaverequestitem where pkid = 2
            --����/�޸�tleaverequestflow��4������
            update tleaverequestflow set operatorId = 99
            insert into tleaverequestflow(leaveRequestItemId,operatorId,operation,operationTime,remark)
            values(1,88,55,'2009-6-19','hello')";
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
            tt.TableName = _MainTableName;
            dt.AddTransferTable(tt);
            aMockRule.DbsToTransfer.Add(dt);

            return aMockRule;
        }
    }
}