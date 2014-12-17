using System;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using NUnit.Framework;
using ComService.ServiceContracts;
using ComService.ServiceModels;

namespace ConsoleClient
{
    [TestFixture]
    public class ClientTest
    {
        private IContactServices contactServices;

        private ArrayList _LinkMans;

        [TestFixtureSetUp]
        public void SetUpAll()
        {
            contactServices = new ChannelFactory<IContactServices>("BasicHttpBinding_ContactServices").CreateChannel();
        }

        [SetUp]
        public void SetUp()
        {
            _LinkMans = new ArrayList();
        }

        [Test, Description("�������������ϵ�˺�ȡ������ϵ���Ƿ�һ��")]
        public void SaveLinkmanTest()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[0]);

            Guid testLinkmanId = testContact.Linkmans[0].Id;
            Guid testDetailId = testContact.Linkmans[0].Details[0].Id;

            _LinkMans.Add(testContact.Linkmans[0]);

            Contact getContat = contactServices.LoadAllContact(testContact.SysNo, testContact.UserId, true);
            Assert.AreEqual(1, getContat.Linkmans.Count);
            Assert.AreEqual(2, getContat.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual(testContact.Linkmans[0].Id, getContat.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual("linkman1", getContat.GetLinkmanById(testLinkmanId).Name);
            Assert.AreEqual(InfoType.Num_General, getContat.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId).Type);
            Assert.AreEqual("123456", getContat.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId).Value);
        }

        [Test, Description("����û���������ϵ�˺�ȡ������ϵ���Ƿ�һ��")]
        public void SaveLinkmanTest1()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[0]);

            Guid testLinkmanId = testContact.Linkmans[0].Id;

            _LinkMans.Add(testContact.Linkmans[0]);

            Contact getContat = contactServices.LoadAllContact(testContact.SysNo, testContact.UserId, false);
            Assert.AreEqual(1, getContat.Linkmans.Count);
            Assert.AreEqual(0, getContat.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual(testContact.Linkmans[0].Id, getContat.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual("linkman1", getContat.GetLinkmanById(testLinkmanId).Name);
        }

        [Test, Description("�������ж���ϵ�����������ֿ�ͷ��һ����벻Ϊ���ֺͶ���������")]
        public void SaveLinkmanTest2()
        {
            Contact testContact = CreateTestContact();
            try
            {
                testContact.Linkmans[0].Name = "9Angle";

            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "��ϵ�����������Ժ��ֻ�Ӣ����ĸ��ͷ��");
                return;
            }

            testContact.Linkmans[0].GetLinkmanDetailByType(InfoType.Num_General).Value = "45e32dddd";

            try
            {
                contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[0]);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "�绰���벻�Ϸ���\r\n");
                return;
            }

            _LinkMans.Add(testContact.Linkmans[0]);

            Contact getContat = contactServices.LoadAllContact(testContact.SysNo, testContact.UserId, true);

            Guid testLinkmanId = testContact.Linkmans[0].Id;
            Guid testDetailId = testContact.Linkmans[0].Details[0].Id;

            Assert.AreEqual(1, getContat.Linkmans.Count);
            Assert.AreEqual(2, getContat.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual(testContact.Linkmans[0].Id, getContat.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual("linkman1", getContat.GetLinkmanById(testLinkmanId).Name);
            Assert.AreEqual(InfoType.Num_General, getContat.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId).Type);
            Assert.AreEqual("123456", getContat.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId).Value);
        }

        [Test, Description("�������ж���ϵ������Ϊ�����")]
        public void SaveLinkmanTest3()
        {
            Contact testContact = CreateTestContact();
            try
            {
                testContact.Linkmans[0].Name = "";
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "��ϵ�����������Ժ��ֻ�Ӣ����ĸ��ͷ��");
                return;
            }
            Guid testLinkmanId = testContact.Linkmans[0].Id;

            _LinkMans.Add(testContact.Linkmans[0]);

            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[0]);
            Contact getContat = contactServices.LoadAllContact(testContact.SysNo, testContact.UserId, false);
            Assert.AreEqual(1, getContat.Linkmans.Count);
            Assert.AreEqual(0, getContat.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual(testContact.Linkmans[0].Id, getContat.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual("ttt2222", getContat.GetLinkmanById(testLinkmanId).Name);
        }

        [Test, Description("�������ж���ϵ������Ϊ�ո����")]
        public void SaveLinkmanTest4()
        {
            Contact testContact = CreateTestContact();
            try
            {
                testContact.Linkmans[0].Name = "    ";
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "��ϵ�����������Ժ��ֻ�Ӣ����ĸ��ͷ��");
                return;
            }
            Guid testLinkmanId = testContact.Linkmans[0].Id;

            _LinkMans.Add(testContact.Linkmans[0]);

            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[0]);
            Contact getContat = contactServices.LoadAllContact(testContact.SysNo, testContact.UserId, false);
            Assert.AreEqual(1, getContat.Linkmans.Count);
            Assert.AreEqual(0, getContat.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual(testContact.Linkmans[0].Id, getContat.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual("ttt2222", getContat.GetLinkmanById(testLinkmanId).Name);

        }

        [Test, Description("�������ж���ϵ�˴�����������")]
        public void SaveLinkmanTest5()
        {
            Contact testContact = CreateTestContact();

            testContact.Linkmans[0].GetLinkmanDetailByType(InfoType.Num_General).Value = "-858855";
            try
            {
                contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[0]);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "�绰���벻�Ϸ���\r\n");
                return;
            }
            _LinkMans.Add(testContact.Linkmans[0]);
        }

        [Test, Description("�������ж���ϵ�˴�����������")]
        public void SaveLinkmanTest6()
        {
            Contact testContact = CreateTestContact();

            testContact.Linkmans[0].GetLinkmanDetailByType(InfoType.Num_General).Value = "--------";
            try
            {
                contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[0]);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "�绰���벻�Ϸ���\r\n");
                return;
            }
            _LinkMans.Add(testContact.Linkmans[0]);
        }

        [Test, Description("�������ж���ϵ�˴�����������")]
        public void SaveLinkmanTest7()
        {
            Contact testContact = CreateTestContact();

            testContact.Linkmans[0].GetLinkmanDetailByType(InfoType.Num_General).Value = "66dddssss";
            try
            {
                contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[0]);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "�绰���벻�Ϸ���\r\n");
                return;
            }
            _LinkMans.Add(testContact.Linkmans[0]);
        }

        [Test, Description("�������ж���ϵ��Email���Ϸ����")]
        public void SaveLinkmanTest8()
        {
            Contact testContact = CreateTestContact();

            testContact.Linkmans[1].GetLinkmanDetailByType(InfoType.Addr_Email).Value = " @hotmail.com";
            try
            {
                contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Email��ַ���Ϸ���\r\n");
                return;
            }
            _LinkMans.Add(testContact.Linkmans[1]);
        }

        [Test, Description("�������ж���ϵ��Email���Ϸ����")]
        public void SaveLinkmanTest9()
        {
            Contact testContact = CreateTestContact();

            testContact.Linkmans[1].GetLinkmanDetailByType(InfoType.Addr_Email).Value = "@";
            try
            {
                contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Email��ַ���Ϸ���\r\n");
                return;
            }
            _LinkMans.Add(testContact.Linkmans[1]);
        }

        [Test, Description("�������ж���ϵ��Email���Ϸ����")]
        public void SaveLinkmanTest10()
        {
            Contact testContact = CreateTestContact();

            testContact.Linkmans[1].GetLinkmanDetailByType(InfoType.Addr_Email).Value = "maomao hotmail.com";
            try
            {
                contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Email��ַ���Ϸ���\r\n");
                return;
            }
            _LinkMans.Add(testContact.Linkmans[1]);
        }

        [Test, Description("�������ж���ϵ��Email���Ϸ����")]
        public void SaveLinkmanTest11()
        {
            Contact testContact = CreateTestContact();

            testContact.Linkmans[1].GetLinkmanDetailByType(InfoType.Addr_Email).Value = "������@hotmail.com";
            try
            {
                contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Email��ַ���Ϸ���\r\n");
                return;
            }
            _LinkMans.Add(testContact.Linkmans[1]);
        }

        [Test, Description("�������ж���ϵ��Email���Ϸ����")]
        public void SaveLinkmanTest12()
        {
            Contact testContact = CreateTestContact();

            testContact.Linkmans[1].GetLinkmanDetailByType(InfoType.Addr_Email).Value = "cai cai@hotmail.com";
            try
            {
                contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Email��ַ���Ϸ���\r\n");
                return;
            }
            _LinkMans.Add(testContact.Linkmans[1]);
        }

        [Test, Description("�������ж���ϵ��Email���Ϸ����")]
        public void SaveLinkmanTest13()
        {
            Contact testContact = CreateTestContact();

            testContact.Linkmans[1].GetLinkmanDetailByType(InfoType.Addr_Email).Value = "a@a";
            try
            {
                contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Email��ַ���Ϸ���\r\n");
                return;
            }
            _LinkMans.Add(testContact.Linkmans[1]);
        }

        [Test, Description("�������ж���ϵ��Email���Ϸ����")]
        public void SaveLinkmanTest14()
        {
            Contact testContact = CreateTestContact();

            testContact.Linkmans[1].GetLinkmanDetailByType(InfoType.Addr_Email).Value = "caicai@hotmail,com";
            try
            {
                contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Email��ַ���Ϸ���\r\n");
                return;
            }
            _LinkMans.Add(testContact.Linkmans[1]);
        }

        [Test,Description("�������жϸ�����ҳ���Ϸ����")]
        public void SaveLinkmanTest15()
        {
            Contact testContact = CreateTestContact();

            testContact.Linkmans[1].GetLinkmanDetailByType(InfoType.Addr_Web).Value = "http:localhost:8080";
            try
            {
                contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "������ҳ��ַ���Ϸ���\r\n");
                return;
            }
            _LinkMans.Add(testContact.Linkmans[1]);
        }

        [Test, Description("�������жϸ�����ҳ���Ϸ����")]
        public void SaveLinkmanTest16()
        {
            Contact testContact = CreateTestContact();

            testContact.Linkmans[1].GetLinkmanDetailByType(InfoType.Addr_Web).Value = "aaaddggghh4r";
            try
            {
                contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "������ҳ��ַ���Ϸ���\r\n");
                return;
            }
            _LinkMans.Add(testContact.Linkmans[1]);
        }

        [Test, Description("�������жϸ�����ҳ���Ϸ����")]
        public void SaveLinkmanTest17()
        {
            Contact testContact = CreateTestContact();

            testContact.Linkmans[1].GetLinkmanDetailByType(InfoType.Addr_Web).Value = "www.126.com";
            try
            {
                contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "������ҳ��ַ���Ϸ���\r\n");
                return;
            }
            _LinkMans.Add(testContact.Linkmans[1]);
        }

        [Test, Description("����LoadAllContactIsExternal()������ϵͳ��ʶ��ȡ����ϵ������ĸ���ͨѶ¼��")]
        public void LoadAllContactIsExternalTest()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);

            Guid testLinkmanId = testContact.Linkmans[1].Id;
            Guid testDetailId1 = testContact.Linkmans[1].Details[0].Id;
            Guid testDetailId2 = testContact.Linkmans[1].Details[1].Id;

            _LinkMans.Add(testContact.Linkmans[1]);

            Contact getContact = contactServices.LoadAllContact("TestSys", testContact.UserId, true);
            Assert.AreEqual(1,getContact.Linkmans.Count);
            Assert.AreEqual("TestSys",getContact.SysNo);
            Assert.AreEqual(3, getContact.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual(testContact.Linkmans[1].Id, getContact.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual("linkman2", getContact.GetLinkmanById(testLinkmanId).Name);
            Assert.AreEqual(InfoType.Addr_Email, getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId1).Type);
            Assert.AreEqual("maomao@hotmail.com", getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId1).Value);
            Assert.AreEqual(InfoType.Num_Work, getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId2).Type);
            Assert.AreEqual("02176548657", getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId2).Value);

        }

        [Test, Description("����LoadAllContactIsExternal()�������û�ID��ȡ����ϵ������ĸ���ͨѶ¼��")]
        public void LoadAllContactIsExternalTest1()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);

            Guid testLinkmanId = testContact.Linkmans[1].Id;
            Guid testDetailId1 = testContact.Linkmans[1].Details[0].Id;
            Guid testDetailId2 = testContact.Linkmans[1].Details[1].Id;

            _LinkMans.Add(testContact.Linkmans[1]);

            Contact getContact = contactServices.LoadAllContact(testContact.SysNo, 1, true);
            Assert.AreEqual(1, getContact.Linkmans.Count);
            Assert.AreEqual("TestSys", getContact.SysNo);
            Assert.AreEqual(1,getContact.UserId);
            Assert.AreEqual(3, getContact.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual(testContact.Linkmans[1].Id, getContact.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual("linkman2", getContact.GetLinkmanById(testLinkmanId).Name);
            Assert.AreEqual(InfoType.Addr_Email, getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId1).Type);
            Assert.AreEqual("maomao@hotmail.com", getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId1).Value);
            Assert.AreEqual(InfoType.Num_Work, getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId2).Type);
            Assert.AreEqual("02176548657", getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId2).Value);

        }

        [Test, Description("����LoadAllContactIsExternal()������ϵͳ��ʶ���û�ID��ȡ����ϵ������ĸ���ͨѶ¼��")]
        public void LoadAllContactIsExternalTest2()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);

            Guid testLinkmanId = testContact.Linkmans[1].Id;
            Guid testDetailId1 = testContact.Linkmans[1].Details[0].Id;
            Guid testDetailId2 = testContact.Linkmans[1].Details[1].Id;

            _LinkMans.Add(testContact.Linkmans[1]);

            Contact getContact = contactServices.LoadAllContact("TestSys",1, true);
            Assert.AreEqual(1, getContact.Linkmans.Count);
            Assert.AreEqual("TestSys", getContact.SysNo);
            Assert.AreEqual(1, getContact.UserId);
            Assert.AreEqual(3, getContact.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual(testContact.Linkmans[1].Id, getContact.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual("linkman2", getContact.GetLinkmanById(testLinkmanId).Name);
            Assert.AreEqual(InfoType.Addr_Email, getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId1).Type);
            Assert.AreEqual("maomao@hotmail.com", getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId1).Value);
            Assert.AreEqual(InfoType.Num_Work, getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId2).Type);
            Assert.AreEqual("02176548657", getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId2).Value);

        }

        [Test, Description("����LoadAllContactIsExternal()�����벻���ڵ�ϵͳ��ʶ��ȡ����ϵ������ĸ���ͨѶ¼��")]
        public void LoadAllContactIsExternalTest3()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);

            _LinkMans.Add(testContact.Linkmans[1]);

            Contact getContact = contactServices.LoadAllContact("tsys", testContact.UserId, true);
            Assert.AreEqual(0, getContact.Linkmans.Count);

        }

        [Test, Description("����LoadAllContactIsExternal()�����벻���ڵ��û�ID��ȡ����ϵ������ĸ���ͨѶ¼��")]
        public void LoadAllContactIsExternalTest4()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);

            _LinkMans.Add(testContact.Linkmans[1]);

            Contact getContact = contactServices.LoadAllContact(testContact.SysNo, 3, true);
            Assert.AreEqual(0, getContact.Linkmans.Count);

        }

        [Test, Description("����LoadAllContactIsExternal()�����벻���ڵ�ϵͳ��ʶ���û�ID��ȡ����ϵ������ĸ���ͨѶ¼��")]
        public void LoadAllContactIsExternalTest5()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);

            _LinkMans.Add(testContact.Linkmans[1]);

            Contact getContact = contactServices.LoadAllContact("Test Sys",2 , true);
            Assert.AreEqual(0, getContact.Linkmans.Count);

        }

        [Test, Description("����LoadAllContact()����������ϵ���������ϵͳ��ʶ��ȡ����ͨѶ¼�б�")]
         public void LoadAllContactTest()
        {
            //bool b = contactServices.TestConnection();
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);

            Guid testLinkmanId = testContact.Linkmans[1].Id;

            _LinkMans.Add(testContact.Linkmans[1]);

            Contact getContact = contactServices.LoadAllContact("TestSys", testContact.UserId, false);
            Assert.AreEqual(1, getContact.Linkmans.Count);
            Assert.AreEqual(0, getContact.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual("TestSys", getContact.SysNo);
            Assert.AreEqual(1, getContact.UserId);
            Assert.AreEqual(0, getContact.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual(testContact.Linkmans[1].Id, getContact.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual("linkman2", getContact.GetLinkmanById(testLinkmanId).Name);
        }

        [Test, Description("����LoadAllContact()����������ϵ���������ϵͳ��ʶ���û�ID��ȡ����ͨѶ¼�б�")]
        public void LoadAllContactTest1()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);

            Guid testLinkmanId = testContact.Linkmans[1].Id;

            _LinkMans.Add(testContact.Linkmans[1]);

            Contact getContact = contactServices.LoadAllContact("TestSys", 1, false);
            Assert.AreEqual(1, getContact.Linkmans.Count);
            Assert.AreEqual(0, getContact.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual("TestSys", getContact.SysNo);
            Assert.AreEqual(1, getContact.UserId);
            Assert.AreEqual(0, getContact.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual(testContact.Linkmans[1].Id, getContact.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual("linkman2", getContact.GetLinkmanById(testLinkmanId).Name);
        }

        [Test, Description("����LoadAllContact()����������ϵ����������û�ID��ȡ����ͨѶ¼�б�")]
         public void LoadAllContactTest2()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo,testContact.UserId,testContact.Linkmans[0]);

            Guid testLinkmanId = testContact.Linkmans[0].Id;

            _LinkMans.Add(testContact.Linkmans[0]);

            Contact getContact = contactServices.LoadAllContact(testContact.SysNo, 1, false);
            Assert.AreEqual(1,getContact.Linkmans.Count);
            Assert.AreEqual(0, getContact.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual("TestSys", getContact.SysNo);
            Assert.AreEqual(1, getContact.UserId);
            Assert.AreEqual(testContact.Linkmans[0].Id, getContact.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual("linkman1", getContact.GetLinkmanById(testLinkmanId).Name);
        }

        [Test, Description("����LoadAllContact()����������ϵ����������ϵͳ�����ڱ�ʶ���û�ID��ȡ����ͨѶ¼�б�")]
        public void LoadAllContactTest3()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[0]);

            _LinkMans.Add(testContact.Linkmans[0]);

            Contact getContact = contactServices.LoadAllContact("Tes33tSys", 9, false);
            Assert.AreEqual(0, getContact.Linkmans.Count);

        }

        [Test, Description("����LoadAllContact()����������ϵ����������ϵͳ�����ڵ�ϵͳ��ʶ��ȡ����ͨѶ¼�б�")]
        public void LoadAllContactTest4()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[0]);

           _LinkMans.Add(testContact.Linkmans[0]);

            Contact getContact = contactServices.LoadAllContact("testsys1", testContact.UserId,false);
            Assert.AreEqual(0, getContact.Linkmans.Count);

        }

        [Test, Description("����LoadAllContact()����������ϵ����������ϵͳ�����ڵ��û�ID��ȡ����ͨѶ¼�б�")]
        public void LoadAllContactTest5()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[0]);

            _LinkMans.Add(testContact.Linkmans[0]);

            Contact getContact = contactServices.LoadAllContact(testContact.SysNo, 2, false);
            Assert.AreEqual(0, getContact.Linkmans.Count);

        }

        [Test, Description("����LoadSomeContactByName()����������ϵ�����������ϵ������ģ����ѯͨѶ¼�б�")]
        public void LoadSomeContactByNameTest()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo,testContact.UserId,testContact.Linkmans[1]);

            Guid testLinkmanId = testContact.Linkmans[1].Id;

            _LinkMans.Add(testContact.Linkmans[1]);

            Contact getContact = contactServices.LoadSomeContactByName(testContact.SysNo, testContact.UserId, "li",false);
            Assert.AreEqual(1,getContact.Linkmans.Count);
            Assert.AreEqual(0, getContact.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual(testContact.Linkmans[1].Id, getContact.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual("linkman2", getContact.GetLinkmanById(testLinkmanId).Name);

        }

        [Test, Description("����LoadSomeContactByName()����������ϵ���������벻���ڵ���ϵ������ģ����ѯͨѶ¼�б�")]
        public void LoadSomeContactByNameTest1()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);

            _LinkMans.Add(testContact.Linkmans[1]);

            Contact getContact = contactServices.LoadSomeContactByName(testContact.SysNo, testContact.UserId, "n1",false);
            Assert.AreEqual(0, getContact.Linkmans.Count);
        }

        [Test, Description("����LoadSomeContactByName()����������ϵ�����������ϵ������׼ȷ��ѯͨѶ¼�б�")]
        public void LoadSomeContactByNameTest2()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);

            Guid testLinkmanId = testContact.Linkmans[1].Id;

            _LinkMans.Add(testContact.Linkmans[1]);

            Contact getContact = contactServices.LoadSomeContactByName(testContact.SysNo, testContact.UserId, "linkman2",false);
            Assert.AreEqual(1, getContact.Linkmans.Count);
            Assert.AreEqual(0, getContact.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual(testContact.Linkmans[1].Id, getContact.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual("linkman2", getContact.GetLinkmanById(testLinkmanId).Name);

        }

        [Test, Description("����LoadSomeContactByName()����������ϵ���������벻���ڵ���ϵ��������ѯͨѶ¼�б�")]
        public void LoadSomeContactByNameTest3()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);

            _LinkMans.Add(testContact.Linkmans[1]);

            Contact getContact = contactServices.LoadSomeContactByName(testContact.SysNo, testContact.UserId, "LinkMn2",false);
            Assert.AreEqual(0, getContact.Linkmans.Count);
        }

        [Test, Description("����LoadSomeContactByNameIsExternal()��������ϵ������ģ����ѯ����ϵ�������ͨѶ¼�б�")]
        public void LoadSomeContactByNameIsExternalTest()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);

            Guid testLinkmanId = testContact.Linkmans[1].Id;
            Guid testDetailId2 = testContact.Linkmans[1].Details[0].Id;
            Guid testDetailId1 = testContact.Linkmans[1].Details[1].Id;

             _LinkMans.Add(testContact.Linkmans[1]);

            Contact getContact = contactServices.LoadSomeContactByName(testContact.SysNo, testContact.UserId,"link",true);
            Assert.AreEqual(3, getContact.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual(testContact.Linkmans[1].Id, getContact.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual("linkman2", getContact.GetLinkmanById(testLinkmanId).Name);
            Assert.AreEqual(InfoType.Addr_Email, getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId2).Type);
            Assert.AreEqual("maomao@hotmail.com", getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId2).Value);
            Assert.AreEqual(InfoType.Num_Work, getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId1).Type);
            Assert.AreEqual("02176548657", getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId1).Value);

        }

        [Test, Description("����LoadSomeContactByNameIsExternal()����ϲ�������ϵ������ģ����ѯ����ϵ�������ͨѶ¼�б�")]
        public void LoadSomeContactByNameIsExternalTest1()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);

            Guid testLinkmanId = testContact.Linkmans[1].Id;
            Guid testDetailId1 = testContact.Linkmans[1].Details[0].Id;
            Guid testDetailId2 = testContact.Linkmans[1].Details[1].Id;

            _LinkMans.Add(testContact.Linkmans[1]);

            Contact getContact = contactServices.LoadSomeContactByName("TestSys", 1, "linkman", true);
            Assert.AreEqual(3, getContact.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual(testContact.Linkmans[1].Id, getContact.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual("linkman2", getContact.GetLinkmanById(testLinkmanId).Name);
            Assert.AreEqual(InfoType.Addr_Email, getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId1).Type);
            Assert.AreEqual("maomao@hotmail.com", getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId1).Value);
            Assert.AreEqual(InfoType.Num_Work, getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId2).Type);
            Assert.AreEqual("02176548657", getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId2).Value);

        }

        [Test, Description("����LoadSomeContactByNameIsExternal()������ϵͳ�����ڵ���ϵ������ģ����ѯ����ϵ�������ͨѶ¼�б�")]
        public void LoadSomeContactByNameIsExternalTest2()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);

            _LinkMans.Add(testContact.Linkmans[1]);

            Contact getContact = contactServices.LoadSomeContactByName(testContact.SysNo, testContact.UserId, "n1", true);
            Assert.AreEqual(0,getContact.Linkmans.Count);

        }

        [Test, Description("����LoadSomeContactByNameIsExternal()��������ϵ������׼ȷ��ѯ����ϵ�������ͨѶ¼�б�")]
        public void LoadSomeContactByNameIsExternalTest3()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);

            Guid testLinkmanId = testContact.Linkmans[1].Id;
            Guid testDetailId1 = testContact.Linkmans[1].Details[0].Id;
            Guid testDetailId2 = testContact.Linkmans[1].Details[1].Id;

            _LinkMans.Add(testContact.Linkmans[1]);

            Contact getContact = contactServices.LoadSomeContactByName("TestSys", testContact.UserId, "linkman2", true);
            Assert.AreEqual(3, getContact.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual(testContact.Linkmans[1].Id, getContact.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual("linkman2", getContact.GetLinkmanById(testLinkmanId).Name);
            Assert.AreEqual(InfoType.Addr_Email, getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId1).Type);
            Assert.AreEqual("maomao@hotmail.com", getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId1).Value);
            Assert.AreEqual(InfoType.Num_Work, getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId2).Type);
            Assert.AreEqual("02176548657", getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId2).Value);

        }

        [Test, Description("����LoadSomeContactByIndexKey()����������ϵ�����������ϵ��������׼ȷ��ѯͨѶ¼�б�")]
        public void LoadSomeContactByIndexKeyTest()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo,testContact.UserId,testContact.Linkmans[1]);

            Guid testLinkmanId = testContact.Linkmans[1].Id;

           _LinkMans.Add(testContact.Linkmans[1]);

            Contact getContact =contactServices.LoadSomeContactByIndexKey(testContact.SysNo, testContact.UserId, "L", false);
            Assert.AreEqual(testContact.Linkmans[1].Id, getContact.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual(0,getContact.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual("linkman2", getContact.GetLinkmanById(testLinkmanId).Name);
            Assert.AreEqual("L", getContact.GetLinkmanById(testLinkmanId).IndexKey);

        }

        [Test, Description("����LoadSomeContactByIndexKeyIsExternal()������ϵ�����������ϵ��������׼ȷ��ѯͨѶ¼�б�")]
        public void LoadSomeContactByIndexKeyIsExternalTest()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);

            Guid testLinkmanId = testContact.Linkmans[1].Id;
            Guid testDetailId = testContact.Linkmans[1].Details[0].Id;

            _LinkMans.Add(testContact.Linkmans[1]);

            Contact getContact =contactServices.LoadSomeContactByIndexKey(testContact.SysNo, testContact.UserId,"L", true);
            Assert.AreEqual(3, getContact.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual(testContact.Linkmans[1].Id, getContact.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual("linkman2", getContact.GetLinkmanById(testLinkmanId).Name);
            Assert.AreEqual("L", getContact.GetLinkmanById(testLinkmanId).IndexKey);
            Assert.AreEqual(InfoType.Addr_Email, getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId).Type);
            Assert.AreEqual("maomao@hotmail.com", getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId).Value);

        }

        [Test, Description("����UpdateSomeContact()���޸Ĳ�������ϵ���������ϵ����Ϣ��")]
        public void UpdateSomeContactTest()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo,testContact.UserId,testContact.Linkmans[0]);

            Guid testLinkmanId = testContact.Linkmans[0].Id;

            _LinkMans.Add(testContact.Linkmans[0]);

            Contact UpdataMan = contactServices.LoadAllContact(testContact.SysNo, testContact.UserId, false);

            UpdataMan.GetLinkmanById(testLinkmanId).Name = "TestSystem";
            contactServices.SaveLinkman(UpdataMan.SysNo, UpdataMan.UserId, UpdataMan.GetLinkmanById(testLinkmanId));
            Linkman getMan = contactServices.LoadAllContact(UpdataMan.SysNo, UpdataMan.UserId,false).GetLinkmanById(testLinkmanId);
            Assert.AreEqual(0, UpdataMan.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual("TestSystem", getMan.Name);
        }

        [Test, Description("����UpdateSomeContact()���޸�����ϵ���������ϵ����Ϣ��")]
        public void UpdateSomeContactTest1()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[1]);

            Guid testLinkmanId = testContact.Linkmans[1].Id;
            Guid testDetailId1 = testContact.Linkmans[1].Details[0].Id;
            Guid testDetailId2 = testContact.Linkmans[1].Details[1].Id;

            _LinkMans.Add(testContact.Linkmans[1]);

            Contact UpdataMan = contactServices.LoadAllContact(testContact.SysNo, testContact.UserId, true);

            UpdataMan.GetLinkmanById(testLinkmanId).Name = "wwweeewew333";
  
            UpdataMan.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId1).Type = InfoType.Addr_Home;
            UpdataMan.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId1).Value = "����·����·2888��";
            UpdataMan.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId2).Type = InfoType.Addr_Email;
            UpdataMan.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId2).Value ="cai.lili@staples.sh.cn" ;
            contactServices.SaveLinkman(UpdataMan.SysNo, UpdataMan.UserId, UpdataMan.GetLinkmanById(testLinkmanId));
            Linkman getMan = contactServices.LoadAllContact(UpdataMan.SysNo, UpdataMan.UserId,true).GetLinkmanById(testLinkmanId);
            Assert.AreEqual(3, UpdataMan.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual("wwweeewew333", getMan.Name);
            Assert.AreEqual(InfoType.Addr_Home, getMan.GetLinkmanDetailById(testDetailId1).Type);
            Assert.AreEqual("����·����·2888��", getMan.GetLinkmanDetailById(testDetailId1).Value);
            Assert.AreEqual(InfoType.Addr_Email, getMan.GetLinkmanDetailById(testDetailId2).Type);
            Assert.AreEqual("cai.lili@staples.sh.cn", getMan.GetLinkmanDetailById(testDetailId2).Value);
         
        }

        [Test, Description("����DeleteLinkman()")]
        public void DelteLinkmanTest()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[0]);

            Guid testLinkmanId = testContact.Linkmans[0].Id;

            _LinkMans.Add(testContact.Linkmans[0]);

            contactServices.DeleteLinkman(testContact.GetLinkmanById(testLinkmanId).Id);
            Contact GetMan = contactServices.LoadAllContact(testContact.SysNo, testContact.UserId, false);
            Assert.AreEqual(0, GetMan.Linkmans.Count);
        }

        [Test, Description("����DeleteAllLinkman()")]
        public void DeleteAllLinkmanTest()
        {
            Contact testContact = CreateTestContact();
            contactServices.SaveLinkman(testContact.SysNo, testContact.UserId, testContact.Linkmans[0]);

            _LinkMans.Add(testContact.Linkmans[0]);

            contactServices.DeleteAllLinkman(testContact.SysNo,testContact.UserId);
            Contact GetMan = contactServices.LoadAllContact(testContact.SysNo, testContact.UserId,true);
            Assert.AreEqual(0, GetMan.Linkmans.Count);
        }

        private static Contact CreateTestContact()
        {
            Contact testContact = new Contact("TestSys", 1);

            Linkman linkman1 = new Linkman();
            linkman1.Name = "linkman1";
            linkman1.Details.Add(new LinkmanDetail(InfoType.Num_General, "123456"));
            linkman1.Details.Add(new LinkmanDetail(InfoType.Num_Mobile, "13676548657"));

            Linkman linkman2 = new Linkman();
            linkman2.Name = "linkman2";
            linkman2.Details.Add(new LinkmanDetail(InfoType.Addr_Email, "maomao@hotmail.com"));
            linkman2.Details.Add(new LinkmanDetail(InfoType.Num_Work, "02176548657"));
            linkman2.Details.Add(new LinkmanDetail(InfoType.Addr_Web, "http://www.126.blog/login.aspx"));

            testContact.Linkmans.Add(linkman1);
            testContact.Linkmans.Add(linkman2);

            return testContact;
        }

        [TearDown]
        public void TearDown()
        {
            foreach (Linkman ct in _LinkMans)
            {
                contactServices.DeleteLinkman(ct.Id);
            }
        }
    }
}
