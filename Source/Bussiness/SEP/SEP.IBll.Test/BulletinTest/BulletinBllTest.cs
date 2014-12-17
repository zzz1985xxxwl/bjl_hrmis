//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: BulletinBllTest.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-20
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using SEP.IBll;
using SEP.IBll.Bulletins;
using SEP.Model.Accounts;
using SEP.Model.Bulletins;
using SEP.Model.Departments;

namespace SEP.IBllTest.BulletinTest
{
    [TestFixture]
    public class BulletinBllTest
    {
        private IBulletinBll _BulletinBll = BllInstance.BulletinBllInstance;

        [SetUp]
        public void SetUp()
        {
            CreateTestData.Login();

            CreateTestData.CreateEmployeeData();

            CreateTestData.CreateDeptData();

            CreateTestData.AssignEmployeeToDept();
        }

        [Test]
        public void GetAllBulletinTest()
        {
            List<Bulletin> bulletinlist = GetBulletin();
            Account loginUser = new Account();
            loginUser.Dept = bulletinlist[0].Dept;
            loginUser.Auths = new List<Auth>();
            List<Bulletin> bulletins = _BulletinBll.GetAllBulletin(loginUser);
            Assert.AreEqual(4, bulletins.Count);
            Assert.AreEqual("dept121", bulletins[0].Dept.Name);
            Assert.AreEqual("dept1", bulletins[1].Dept.Name);
            Assert.AreEqual("dept12", bulletins[2].Dept.Name);
            Assert.AreEqual("dept1212", bulletins[3].Dept.Name);
        }

        [Test]
        public void GetAllBulletinTest2()
        {
            List<Bulletin> bulletinlist = GetBulletin();
            Account loginUser = new Account();
            loginUser.Dept = bulletinlist[0].Dept;
            List<Auth> auths = new List<Auth>();
            Auth auth1 = new Auth();
            auth1.Type = AuthType.SEP;
            auth1.Id = 302;
            auths.Add(auth1);
            loginUser.Auths = auths;
            List<Bulletin> bulletins = _BulletinBll.GetAllBulletin(loginUser);
            Assert.AreEqual(6, bulletins.Count);
        }

        [Test]
        public void GetBulletinByCondition()
        {
            List<Bulletin> bulletinlist = GetBulletin();
            Account loginUser = new Account();
            loginUser.Dept = bulletinlist[0].Dept;
            List<Auth> auths = new List<Auth>();
            Auth auth1 = new Auth();
            auth1.Type = AuthType.SEP;
            auth1.Id = 302;
            auths.Add(auth1);
            loginUser.Auths = auths;
            List<Bulletin> bulletins =
                _BulletinBll.GetBulletinByCondition("", Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2010-1-1"),
                                                    bulletinlist[0].Dept.Id, loginUser);
            Assert.AreEqual(1, bulletins.Count);
            Assert.AreEqual("dept1212", bulletins[0].Dept.Name);
        }

        [Test]
        public void GetBulletinByCondition2()
        {
            List<Bulletin> bulletinlist = GetBulletin();
            Account loginUser = new Account();
            loginUser.Dept = bulletinlist[0].Dept;
            List<Auth> auths = new List<Auth>();
            Auth auth1 = new Auth();
            auth1.Type = AuthType.SEP;
            auth1.Id = 302;
            auths.Add(auth1);
            loginUser.Auths = auths;
            List<Bulletin> bulletins =
                _BulletinBll.GetBulletinByCondition("", Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2010-1-1"),
                                                    bulletinlist[3].Dept.Id, loginUser);
            Assert.AreEqual(4, bulletins.Count);
        }

        private List<Bulletin> GetBulletin()
        {
            List<Bulletin> bulletinList = new List<Bulletin>();
            Bulletin bulletin1 = new Bulletin(1, "1", "", Convert.ToDateTime("2009-1-1")); //dept1212 
            Bulletin bulletin2 = new Bulletin(2, "2", "", Convert.ToDateTime("2009-1-2")); //dept1211
            Bulletin bulletin3 = new Bulletin(3, "3", "", Convert.ToDateTime("2009-2-1")); //dept121 
            Bulletin bulletin4 = new Bulletin(4, "4", "", Convert.ToDateTime("2009-1-5")); //dept12 
            Bulletin bulletin5 = new Bulletin(5, "5", "", Convert.ToDateTime("2009-3-1")); //dept11
            Bulletin bulletin6 = new Bulletin(6, "6", "", Convert.ToDateTime("2009-1-6")); //dept1 
            List<Department> actualList = BllInstance.DepartmentBllInstance.GetAllDepartment();
            foreach (Department department in actualList)
            {
                if (department.Name == "dept1212")
                {
                    bulletin1.Dept = department;
                }
                else if (department.Name == "dept1211")
                {
                    bulletin2.Dept = department;
                }
                else if (department.Name == "dept121")
                {
                    bulletin3.Dept = department;
                }
                else if (department.Name == "dept12")
                {
                    bulletin4.Dept = department;
                }
                else if (department.Name == "dept11")
                {
                    bulletin5.Dept = department;
                }
                else if (department.Name == "dept1")
                {
                    bulletin6.Dept = department;
                }
            }
            bulletinList.Add(bulletin1);
            bulletinList.Add(bulletin2);
            bulletinList.Add(bulletin3);
            bulletinList.Add(bulletin4);
            bulletinList.Add(bulletin5);
            bulletinList.Add(bulletin6);
            foreach (Bulletin bulletin in bulletinList)
            {
                _BulletinBll.CreateBulletin(bulletin, null);
            }
            return bulletinList;
        }

        [TearDown]
        public void TearDown()
        {
            CleanUpTestData.CleanUpEmployee();
            CleanUpTestData.CleanUpDepartment();
            CleanUpTestData.CleanUpBulletin();
        }
    }
}