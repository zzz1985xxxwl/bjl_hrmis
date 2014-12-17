//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: BulletinBllUtiltyTest.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-19
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using SEP.Bll.Bulletins;
using SEP.IBll;
using SEP.Model.Bulletins;
using SEP.Model.Departments;

namespace SEP.IBllTest.BulletinTest
{
    [TestFixture]
    public class BulletinBllUtiltyTest
    {
        [SetUp]
        public void SetUp()
        {
            CreateTestData.Login();

            CreateTestData.CreateEmployeeData();

            CreateTestData.CreateDeptData();

            CreateTestData.AssignEmployeeToDept();
        }

        [Test]
        public void CleanByDepartmentTest()
        {
            List<Bulletin> bulletinList = GetBulletin();
            BulletinBllUtiltiy bulletinBllUtility = new BulletinBllUtiltiy();
            Assert.AreEqual(6, bulletinList.Count);
            List<Bulletin> bulletin = bulletinBllUtility.CleanByDepartment(bulletinList, bulletinList[0].Dept.Id);
            Assert.AreEqual(4, bulletin.Count);
            Assert.AreEqual("dept1212", bulletin[0].Dept.Name);
            Assert.AreEqual("dept121", bulletin[1].Dept.Name);
            Assert.AreEqual("dept12", bulletin[2].Dept.Name);
            Assert.AreEqual("dept1", bulletin[3].Dept.Name);
        }

        [Test]
        public void CleanByDepartmentOnlyChildTest()
        {
            List<Bulletin> bulletinList = GetBulletin();
            BulletinBllUtiltiy bulletinBllUtility = new BulletinBllUtiltiy();
            Assert.AreEqual(6, bulletinList.Count);
            List<Bulletin> bulletin = bulletinBllUtility.CleanByDepartmentOnlyChild(bulletinList, bulletinList[3].Dept.Id);
            Assert.AreEqual(4, bulletin.Count);
            Assert.AreEqual("dept1212", bulletin[0].Dept.Name);
            Assert.AreEqual("dept1211", bulletin[1].Dept.Name);
            Assert.AreEqual("dept121", bulletin[2].Dept.Name);
            Assert.AreEqual("dept12", bulletin[3].Dept.Name);
        }

        private static List<Bulletin> GetBulletin()
        {
            List<Bulletin> bulletinList = new List<Bulletin>();
            Bulletin bulletin1 = new Bulletin(1, "", "", DateTime.Now);
            Bulletin bulletin2 = new Bulletin(2, "", "", DateTime.Now);
            Bulletin bulletin3 = new Bulletin(3, "", "", DateTime.Now);
            Bulletin bulletin4 = new Bulletin(4, "", "", DateTime.Now);
            Bulletin bulletin5 = new Bulletin(5, "", "", DateTime.Now);
            Bulletin bulletin6 = new Bulletin(6, "", "", DateTime.Now);
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
            return bulletinList;
        }

        [TearDown]
        public void TearDown()
        {
            CleanUpTestData.CleanUpEmployee();
            CleanUpTestData.CleanUpDepartment();
        }
    }
}