//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IContactDATest.cs
// 创建者: 菜丽丽，张燕
// 创建日期: 2008-12-01
// 概述: 电话本数据库访问类的测试
// ----------------------------------------------------------------

using System;
using System.Collections;
using NUnit.Framework;
using ComService.ServiceModels;

namespace ComService.IDALayer.UnitTest
{
    /// <summary>
    /// 测试接口IContactDA
    /// </summary>
    [TestFixture]
    public class IContactDATest
    {
       
        private static IContactDA _IContactDA;
        private  static ArrayList _LinkMan;
        private static ArrayList _LinkManDetail;

        [TestFixtureSetUp]
        public void SetUpAll()
        {
            _IContactDA = DalFactory.ContactDA;
        }

        [SetUp]
        public void SetUp()
        {
            _LinkMan = new ArrayList();
            _LinkManDetail = new ArrayList();
        }

        [Test, Description("测试GetAllLinkmans()（没有联系人详情）")]
        public void GetAllLinkmansTest()
        {
            Contact testContact = CreateTestContact();
            _IContactDA.AddLinkman(testContact.SysNo, testContact.UserId,0, testContact.Linkmans[0]);

            _LinkMan.Add(testContact.Linkmans[0].Id);

            Guid testLinkmanId = testContact.Linkmans[0].Id;

            Contact getContact = _IContactDA.GetAllLinkmans(testContact.SysNo, 0, testContact.UserId, false);
            Assert.AreEqual(testContact.Linkmans[0].Id, getContact.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual(testContact.Linkmans[0].Name, getContact.GetLinkmanById(testLinkmanId).Name);

        }

        [Test,Description("测试GetAllLinkmans()（有联系人详情）")]
        public void GetAllLinkmansTest1()
        {
            Contact testContact = CreateTestContact();
            _IContactDA.AddLinkman(testContact.SysNo, testContact.UserId, 0, testContact.Linkmans[0]);

            _LinkMan.Add(testContact.Linkmans[0].Id);
            _LinkManDetail.Add(testContact.Linkmans[0].Details[0].Id);
            _LinkManDetail.Add(testContact.Linkmans[0].Details[1].Id);

            Guid testLinkmanId = testContact.Linkmans[0].Id;
            Guid testDetailId = testContact.Linkmans[0].Details[0].Id;

            Contact getContact = _IContactDA.GetAllLinkmans(testContact.SysNo, 0, testContact.UserId, true);
            Assert.AreEqual(testContact.Linkmans[0].Id, getContact.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual(testContact.Linkmans[0].Name, getContact.GetLinkmanById(testLinkmanId).Name);
            Assert.AreEqual(testContact.Linkmans[0].Details[0].Id, getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId).Id);
            Assert.AreEqual(testContact.Linkmans[0].Details[0].Type, getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId).Type);
            Assert.AreEqual(testContact.Linkmans[0].Details[0].Value, getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId).Value);

        }

        [Test,Description("测试GetLinkmansByName()(没有联系人详情)")]
         public void GetLinkmansByNameTest()
         {
             Contact testContact = CreateTestContact();
             _IContactDA.AddLinkman(testContact.SysNo, testContact.UserId, 0, testContact.Linkmans[0]);

            _LinkMan.Add(testContact.Linkmans[0].Id);

            Guid testLinkmanId = testContact.Linkmans[0].Id;

            Contact getContact = _IContactDA.GetLinkmansByName(testContact.SysNo, testContact.UserId, testContact.Linkmans[0].Name,0, false);
            Assert.AreEqual(1, getContact.Linkmans.Count);
            Assert.AreEqual(testContact.Linkmans[0].Id, getContact.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual(testContact.Linkmans[0].Name, getContact.GetLinkmanById(testLinkmanId).Name);

         }

        [Test, Description("测试GetLinkmansByName()(有联系人详情)")]
        public void GetLinkmansByNameTest1()
        {
            Contact testContact = CreateTestContact();
            _IContactDA.AddLinkman(testContact.SysNo, testContact.UserId, 0, testContact.Linkmans[0]);

            _LinkMan.Add(testContact.Linkmans[0].Id);
            _LinkManDetail.Add(testContact.Linkmans[0].Details[0].Id);
            _LinkManDetail.Add(testContact.Linkmans[0].Details[1].Id);

            Guid testLinkmanId = testContact.Linkmans[0].Id;
            Guid testDetailId = testContact.Linkmans[0].Details[0].Id;

            Contact getContact = _IContactDA.GetLinkmansByName(testContact.SysNo, testContact.UserId,testContact.Linkmans[0].Name,0, true);
            Assert.AreEqual(1, getContact.Linkmans.Count);
            Assert.AreEqual(testContact.Linkmans[0].Id, getContact.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual(testContact.Linkmans[0].Name, getContact.GetLinkmanById(testLinkmanId).Name);
            Assert.AreEqual(testContact.Linkmans[0].Details[0].Id,getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId).Id);
            Assert.AreEqual(testContact.Linkmans[0].Details[0].Type,getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId).Type);
            Assert.AreEqual(testContact.Linkmans[0].Details[0].Value,getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId).Value);

        }

        [Test,Description("测试GetAllLinkmansByIndexKey()(没有联系人详情)")]
        public void GetAllLinkmansByIndexKeyTest()
        {
            Contact testContact = CreateTestContact();
            _IContactDA.AddLinkman(testContact.SysNo,testContact.UserId,0,testContact.Linkmans[0]);

            _LinkMan.Add(testContact.Linkmans[0].Id);

            Guid testLinkmanId = testContact.Linkmans[0].Id;

            Contact getContact =
                _IContactDA.GetAllLinkmansByIndexKey(testContact.SysNo,0, testContact.UserId,testContact.Linkmans[0].IndexKey, false);
            Assert.AreEqual(1, getContact.Linkmans.Count);
            Assert.AreEqual(testContact.Linkmans[0].Id, getContact.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual(testContact.Linkmans[0].Name, getContact.GetLinkmanById(testLinkmanId).Name);
            Assert.AreEqual(testContact.Linkmans[0].IndexKey, getContact.GetLinkmanById(testLinkmanId).IndexKey);
        }

        [Test,Description("测试GetAllLinkmansByIndexKey()(有联系人详情)")]
        public void GetAllLinkmansByIndexKeyTest1()
        {
            Contact testContact = CreateTestContact();
            _IContactDA.AddLinkman(testContact.SysNo,testContact.UserId,0,testContact.Linkmans[0]);

            _LinkMan.Add(testContact.Linkmans[0].Id);
            _LinkManDetail.Add(testContact.Linkmans[0].Details[0].Id);
            _LinkManDetail.Add(testContact.Linkmans[0].Details[1].Id);

            Guid testLinkmanId = testContact.Linkmans[0].Id;
            Guid testDetailId = testContact.Linkmans[0].Details[0].Id;

            Contact getContact = _IContactDA.GetAllLinkmansByIndexKey(testContact.SysNo, testContact.UserId, 0, testContact.Linkmans[0].IndexKey, true);
            Assert.AreEqual(1, getContact.Linkmans.Count);
            Assert.AreEqual(testContact.Linkmans[0].Id, getContact.GetLinkmanById(testLinkmanId).Id);
            Assert.AreEqual(testContact.Linkmans[0].Name, getContact.GetLinkmanById(testLinkmanId).Name);
            Assert.AreEqual(testContact.Linkmans[0].Details[0].Id, getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId).Id);
            Assert.AreEqual(testContact.Linkmans[0].Details[0].Type, getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId).Type);
            Assert.AreEqual(testContact.Linkmans[0].Details[0].Value, getContact.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId).Value);
            Assert.AreEqual(testContact.Linkmans[0].IndexKey, getContact.GetLinkmanById(testLinkmanId).IndexKey);
        }

         [Test, Description("测试GetLinkman()")]
         public void GetLinkmanTest()
         {
             Contact testContact = CreateTestContact();
             _IContactDA.AddLinkman(testContact.SysNo, testContact.UserId, 0, testContact.Linkmans[0]);

             _LinkMan.Add(testContact.Linkmans[0].Id);
             _LinkManDetail.Add(testContact.Linkmans[0].Details[0].Id);
             _LinkManDetail.Add(testContact.Linkmans[0].Details[1].Id);

             Contact getContact = _IContactDA.GetLinkman(testContact.SysNo, testContact.UserId,0 ,testContact.Linkmans[0].Id);
             Assert.AreEqual(testContact.Linkmans[0].Name, getContact.Linkmans[0].Name);
             Assert.AreEqual(testContact.Linkmans[0].Id, getContact.Linkmans[0].Id);
         }

        [Test,Description("新增的联系人和取出的联系人是否一致")]
        public void AddLinkmanTest()
        {
            Contact testContact = CreateTestContact();
            _IContactDA.AddLinkman(testContact.SysNo, testContact.UserId,0, testContact.Linkmans[0]);

            _LinkMan.Add(testContact.Linkmans[0].Id);
            _LinkManDetail.Add(testContact.Linkmans[0].Details[0].Id);
            _LinkManDetail.Add(testContact.Linkmans[0].Details[1].Id);

            Contact GetMan = _IContactDA.GetLinkman(testContact.SysNo, testContact.UserId, 0, testContact.Linkmans[0].Id);
            Assert.AreEqual(1, GetMan.Linkmans.Count);
            Assert.AreEqual(testContact.SysNo, GetMan.SysNo);
            Assert.AreEqual(testContact.UserId, GetMan.UserId);
            Assert.AreEqual(testContact.Linkmans[0].Id, GetMan.Linkmans[0].Id);
            Assert.AreEqual(testContact.Linkmans[0].Name, GetMan.Linkmans[0].Name);
        }

        [Test, Description("新增的联系人但不新增详情和取出的联系人是否一致")]
        public void AddLinkmanTest1()

        {
            Linkman linkman = new Linkman();
            linkman.Name = "毛毛";
            string sysNo = "iiuii";
            int userId = 1;

            _IContactDA.AddLinkman(sysNo, userId, 0, linkman);

            _LinkMan.Add(linkman.Id);

            Contact contact = _IContactDA.GetLinkman(sysNo, userId, 0, linkman.Id);
            Assert.AreEqual(1, contact.Linkmans.Count);
            Assert.AreEqual(linkman.Id, contact.Linkmans[0].Id);
            Assert.AreEqual(linkman.Name, contact.Linkmans[0].Name);
            Assert.AreEqual(sysNo,contact.SysNo);
            Assert.AreEqual(userId,contact.UserId);

        }

        [Test, Description("更新的联系人和取出的联系人是否一致")]
        public void UpdateLinkmanTest()
        {
            Contact testContact = CreateTestContact();
            _IContactDA.AddLinkman(testContact.SysNo, testContact.UserId, 0, testContact.Linkmans[0]);

            _LinkMan.Add(testContact.Linkmans[0].Id);
            _LinkManDetail.Add(testContact.Linkmans[0].Details[0].Id);
            _LinkManDetail.Add(testContact.Linkmans[0].Details[1].Id);

            //Contact UpdateMan = _IContactDA.GetLinkman("", 0, testContact.Linkmans[0].Id);
            Contact UpdateMan = _IContactDA.GetLinkman(testContact.SysNo, testContact.UserId, 0, testContact.Linkmans[0].Id);

            UpdateMan.Linkmans[0].Name = "link1";
            UpdateMan.Linkmans[0].Details[0].Type = InfoType.Addr_Email;

            _IContactDA.UpdateLinkman(UpdateMan.Linkmans[0]);
            Contact GetMan = _IContactDA.GetLinkman(testContact.SysNo, testContact.UserId, 0, testContact.Linkmans[0].Id);

            Assert.AreEqual(UpdateMan.SysNo, GetMan.SysNo);
            Assert.AreEqual(UpdateMan.UserId, GetMan.UserId);
            Assert.AreEqual(1, GetMan.Linkmans.Count);
            Assert.AreEqual("link1", GetMan.Linkmans[0].Name);
            Assert.AreEqual(UpdateMan.Linkmans[0].Details[0].Type, GetMan.Linkmans[0].Details[0].Type);
            Assert.AreEqual(UpdateMan.Linkmans[0].Details[0].Value, GetMan.Linkmans[0].Details[0].Value);
        }


        [Test, Description("更新联系人没有详情和取出的联系人是否一致")]
        public void UpdateLinkmanTest1()
        {
            Linkman linkMan = new Linkman( );
            linkMan.Name = "test";
            _IContactDA.AddLinkman("sss", 1, 0, linkMan);
            linkMan.Name = "test1";

            _LinkMan.Add(linkMan.Id);

            _IContactDA.UpdateLinkman(linkMan);
            Contact GetMan = _IContactDA.GetLinkman("", 0, 0, linkMan.Id);

            Assert.AreEqual(1, GetMan.Linkmans.Count);
            Assert.AreEqual("test1", GetMan.Linkmans[0].Name);
  
        }

        [Test, Description(" 删除联系人是否正确")]
        public void DelteLinkmanTest()
        {
            Contact testContact = CreateTestContact();
            _IContactDA.AddLinkman(testContact.SysNo, testContact.UserId, 0, testContact.Linkmans[0]);

            _LinkMan.Add(testContact.Linkmans[0].Id);
            _LinkManDetail.Add(testContact.Linkmans[0].Details[0].Id);
            _LinkManDetail.Add(testContact.Linkmans[0].Details[1].Id);

            _IContactDA.DeleteLinkman(testContact.Linkmans[0].Id);

            Contact GetMan = _IContactDA.GetLinkman("", 1, 0, testContact.Linkmans[0].Id);

            Assert.AreEqual(0, GetMan.Linkmans.Count);
        }

        [Test, Description("删除的联系人没有详情是否正确")]
        public void DelteLinkmanTest1()
        {
            Linkman linkMan = new Linkman();
            linkMan.Name = "test";
            _IContactDA.AddLinkman("sss", 1, 0, linkMan);

            _LinkMan.Add(linkMan.Id);

            _IContactDA.DeleteLinkman(linkMan.Id);
            Contact GetMan = _IContactDA.GetLinkman("", 1, 0, linkMan.Id);

            Assert.AreEqual(0, GetMan.Linkmans.Count);
        }


        [Test, Description("新增联系人详情和取出的是否一致")]
        public void AddLinkmanDetailTest()
        {
            Contact testContact = CreateTestContact();

            _IContactDA.AddLinkman(testContact.SysNo, testContact.UserId, 0, testContact.Linkmans[0]);

            _LinkMan.Add(testContact.Linkmans[0].Id);
            _LinkManDetail.Add(testContact.Linkmans[0].Details[0].Id);
            _LinkManDetail.Add(testContact.Linkmans[0].Details[1].Id);

            Guid testLinkmanId = testContact.Linkmans[0].Id;
            Guid testDetailId = testContact.Linkmans[0].Details[1].Id;

            Contact GetMan = _IContactDA.GetLinkman(testContact.SysNo, testContact.UserId, 0, testLinkmanId);

            Assert.AreEqual(2, GetMan.GetLinkmanById(testLinkmanId).Details.Count);
            Assert.AreEqual(testContact.Linkmans[0].Details[1].Type, GetMan.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId).Type);
            Assert.AreEqual(testContact.Linkmans[0].Details[1].Value, GetMan.GetLinkmanById(testLinkmanId).GetLinkmanDetailById(testDetailId).Value);
        }

        [Test, Description("更新联系人详情和取出的是否一致")]
        public void UpdateLinkmanDetailTest()
        {
            Linkman linkMan = InsertLinkManInfo();

            _LinkMan.Add(linkMan.Id);
            _LinkManDetail.Add(linkMan.Details[0].Id);
            _LinkManDetail.Add(linkMan.Details[1].Id);

            Contact UpdateMan = _IContactDA.GetLinkman("", 0, 0, linkMan.Id);

            Guid testDetailId1 = UpdateMan.Linkmans[0].Details[0].Id;
            Guid testDetailId2 = UpdateMan.Linkmans[0].Details[1].Id;

            UpdateMan.Linkmans[0].GetLinkmanDetailById(testDetailId1).Type = InfoType.Addr_Email;
            UpdateMan.Linkmans[0].GetLinkmanDetailById(testDetailId1).Value = "12@163.com";
            UpdateMan.Linkmans[0].GetLinkmanDetailById(testDetailId2).Type = InfoType.Addr_Home;
            UpdateMan.Linkmans[0].GetLinkmanDetailById(testDetailId2).Value = "34345678";

            _IContactDA.UpdateLinkman(UpdateMan.Linkmans[0]);

            Contact GetMan = _IContactDA.GetLinkman("", 0, 0, linkMan.Id);

            Assert.AreEqual(2, GetMan.Linkmans[0].Details.Count);
            Assert.AreEqual(UpdateMan.Linkmans[0].Details[0].Type,
                             GetMan.Linkmans[0].GetLinkmanDetailById(testDetailId1).Type);
            Assert.AreEqual(UpdateMan.Linkmans[0].Details[0].Value,
                            GetMan.Linkmans[0].GetLinkmanDetailById(testDetailId1).Value);
            Assert.AreEqual(UpdateMan.Linkmans[0].Details[1].Type,
                            GetMan.Linkmans[0].GetLinkmanDetailById(testDetailId2).Type);
            Assert.AreEqual(UpdateMan.Linkmans[0].Details[1].Value,
                            GetMan.Linkmans[0].GetLinkmanDetailById(testDetailId2).Value);
        }


        [Test, Description("删除联系人详情是否正确")]
        public void DeleteLinkmanDetailTest()
        {
            Linkman linkMan = InsertLinkManInfo();

            _LinkMan.Add(linkMan.Id);
            _LinkManDetail.Add(linkMan.Details[0].Id);
            _LinkManDetail.Add(linkMan.Details[1].Id);

            Guid DetailID = linkMan.Details[1].Id;

            _IContactDA.DeleteLinkmanDetail(linkMan.Details[0].Id);

            Contact GetMan = _IContactDA.GetLinkman("sss", 1, 0, linkMan.Id);

            Assert.AreEqual(1, GetMan.Linkmans[0].Details.Count);
            Assert.AreEqual(InfoType.Num_Fax, GetMan.Linkmans[0].GetLinkmanDetailById(DetailID).Type);
            Assert.AreEqual("2", GetMan.Linkmans[0].GetLinkmanDetailById(DetailID).Value);
        }


        public Linkman InsertLinkManInfo()
        {
            Contact contactMan = new Contact("aaa", 1);

            Linkman linkman = new Linkman();
            linkman.Name = "link";

            LinkmanDetail Detail1 = new LinkmanDetail(InfoType.Num_General);
            LinkmanDetail Detail2 = new LinkmanDetail(InfoType.Num_Fax, "2");
            linkman.Details.Add(Detail1);
            linkman.Details.Add(Detail2);

            contactMan.Linkmans.Add(linkman);

            _IContactDA.AddLinkman(contactMan.SysNo, contactMan.UserId, 0, linkman);

            return linkman;
        }

        private Contact CreateTestContact()
        {
            Contact testContact = new Contact("TestSys", 1);

            Linkman linkman1 = new Linkman();
            linkman1.Name = "linkman1";
            linkman1.Details.Add(new LinkmanDetail(InfoType.Num_General, "123456"));
            linkman1.Details.Add(new LinkmanDetail(InfoType.Num_Mobile, "13676548657"));

            Linkman linkman2 = new Linkman();
            linkman2.Name = "linkman2";
            linkman2.Details.Add(new LinkmanDetail(InfoType.Addr_Email, "dsjfad@adf.cn"));
            linkman2.Details.Add(new LinkmanDetail(InfoType.Num_Work, "02176548657"));

            testContact.Linkmans.Add(linkman1);
            testContact.Linkmans.Add(linkman2);

            return testContact;
        }

        [TearDown]
        public void TearDown()
        {
            foreach (Guid ct in _LinkMan)
            {
                _IContactDA.DeleteLinkman(ct);
            }
            foreach (Guid ct in _LinkManDetail)
            {
                _IContactDA.DeleteLinkmanDetail(ct);
            }
        }

    }

}
