using NUnit.Framework;
using System.Collections.Generic;

using SEP.IBll;
using SEP.Model.Accounts;
using System;
using ShiXin.Security;

namespace SEP.IBllTest
{
    [TestFixture]
    public class EmployeeBllTest
    {
        [SetUp]
        public void SetUp()
        {
            SecurityUtil.SymmetricDecrypt("iYJ0bwk/nGjPoO1H7m5Wig==", "luantianlin");
            CreateTestData.Login();

            CreateTestData.CreateEmployeeData();

            CreateTestData.CreateDeptData();

            CreateTestData.AssignEmployeeToDept();
        }

        [Test]
        public void GetSubordinatesTest()
        {
            SecurityUtil.SymmetricDecrypt("iYJ0bwk/nGjPoO1H7m5Wig==", "luantianlin");
            List<Account> expected = new List<Account>();

            expected.Add(CreateTestData.employee5);
            expected.Add(CreateTestData.employee8);
            expected.Add(CreateTestData.employee31);
            expected.Add(CreateTestData.employee32);
            expected.Add(CreateTestData.employee13);
            expected.Add(CreateTestData.employee14);
            expected.Add(CreateTestData.employee16);
            expected.Add(CreateTestData.employee33);
            expected.Add(CreateTestData.employee34);
            expected.Add(CreateTestData.employee35);
            expected.Add(CreateTestData.employee40);
            expected.Add(CreateTestData.employee41);

            List<Account> actual1 = BllInstance.AccountBllInstance.GetSubordinates(CreateTestData.employee1.Id);
            Assert.AreEqual(45, actual1.Count);

            List<Account> actual5 = BllInstance.AccountBllInstance.GetSubordinates(CreateTestData.employee5.Id);
            Assert.AreEqual(expected.Count, actual5.Count);

            bool temp = false;
            foreach (Account employee in expected)
            {
                temp = ValidateTools.ContainsAccount(actual5, employee);
                if (!temp)
                    break;
            }
            Assert.IsTrue(temp);
        }

        [Test]
        public void GetAllAccountTest()
        {
            List<Account> account = BllInstance.AccountBllInstance.GetAllAccount();
            Assert.AreEqual(45, account.Count);
        }

        [Test]
        public void GetAccountByNameTest()
        {
            Account account = BllInstance.AccountBllInstance.GetAccountByName(CreateTestData.employee6.Name);

            Assert.AreEqual(account.Id, CreateTestData.employee6.Id);
            Assert.AreEqual(account.Name, CreateTestData.employee6.Name);
        }

        [Test]
        public void GetAccountByBaseConditionTest()
        {
            List<Account> actualList =
                BllInstance.AccountBllInstance.GetAccountByBaseCondition("1", -1, -1, false, null);
            Assert.AreEqual(14, actualList.Count);

            actualList = BllInstance.AccountBllInstance.GetAccountByBaseCondition("1", CreateTestData.dept1.Id, -1, false, null);
            Assert.AreEqual(0, actualList.Count);

            actualList = BllInstance.AccountBllInstance.GetAccountByBaseCondition("1", CreateTestData.dept1.Id, -1, true, null);
            Assert.AreEqual(2, actualList.Count);

            actualList = BllInstance.AccountBllInstance.GetAccountByBaseCondition("3", CreateTestData.dept1.Id, -1, true, null);
            Assert.AreEqual(12, actualList.Count);
        }
        [Test]
        public void GetEmployeeByBasicConditionAndFirstLetterTest()
        {
            //List<Account> accounts = BllInstance.AccountBllInstance.GetEmployeeByBasicConditionAndFirstLetter("", -1, -1, true, "f");
            //int id = BllInstance.AccountBllInstance.GetLeaderByAccountId(55).Id;

            //Account account = new Account();
            //account.AccountType = VisibleType.SEP | VisibleType.HRMis | VisibleType.CRM;

            //VisibleType type = VisibleType.HRMis| VisibleType.CRM;

            //account.AccountType = account.AccountType & type;
            //account.AccountType = ~account.AccountType;

        }

        [TearDown]
        public void TearDown()
        {
            CleanUpTestData.CleanUpEmployee();
            CleanUpTestData.CleanUpDepartment();
        }
    }
}
