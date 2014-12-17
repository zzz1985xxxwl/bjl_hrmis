using System;
using System.Collections.Generic;
using NUnit.Framework;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.SpecialDates;

namespace SEP.IBllTest
{
    [TestFixture]
    public class SpecialDateBllTest
    {
        [TearDown]
        public void TearDown()
        {
            CleanUpTestData.CleanUpSpecialDate();
        }

        [Test]
        public void GetAllSpecialDateTest()
        {
            SpecialDate SpecialDate1 = new SpecialDate(0, Convert.ToDateTime("2009-1-1"), 0, "", "", "", "");
            SpecialDate SpecialDate2 = new SpecialDate(0, Convert.ToDateTime("2009-2-1"), 0, "", "", "", "");
            SpecialDate SpecialDate3 = new SpecialDate(0, Convert.ToDateTime("2009-3-1"), 0, "", "", "", "");

            Account account1 = new Account();
            account1.Auths = new List<Auth>();
            account1.Auths.Add(new Auth(503, ""));

            Account account2 = new Account();
            account2.Auths = new List<Auth>();

            BllInstance.SpecialDateBllInstance.CreateSpecialDate(SpecialDate1, account1);
            BllInstance.SpecialDateBllInstance.CreateSpecialDate(SpecialDate2, account1);
            BllInstance.SpecialDateBllInstance.CreateSpecialDate(SpecialDate3, account1);
            List<SpecialDate> specialDates = BllInstance.SpecialDateBllInstance.GetAllSpecialDate(new Account());
            Assert.AreEqual(specialDates.Count, 3);
        }

        [Test]
        public void NoAuthTest()
        {
            SpecialDate SpecialDate1 = new SpecialDate(0, Convert.ToDateTime("2009-1-1"), 0, "", "", "", "");

            Account account2 = new Account();
            account2.Auths = new List<Auth>();

            try
            {
                BllInstance.SpecialDateBllInstance.CreateSpecialDate(SpecialDate1, account2);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("无该操作权限！", ex.Message);
            }
        }

        [Test]
        public void GetSpecialDateByFromAndToDateTest()
        {
            SpecialDate SpecialDate1 = new SpecialDate(0, Convert.ToDateTime("2008-9-27"), 0, "", "", "", "");
            SpecialDate SpecialDate2 = new SpecialDate(0, Convert.ToDateTime("2008-9-28"), 0, "", "", "", "");
            SpecialDate SpecialDate3 = new SpecialDate(0, Convert.ToDateTime("2008-9-29"), 0, "", "", "", "");
            SpecialDate SpecialDate4 = new SpecialDate(0, Convert.ToDateTime("2008-9-30"), 0, "", "", "", "");
            SpecialDate SpecialDate5 = new SpecialDate(0, Convert.ToDateTime("2008-10-1"), 0, "", "", "", "");

            Account account1 = new Account();
            account1.Auths = new List<Auth>();
            account1.Auths.Add(new Auth(503, ""));

            BllInstance.SpecialDateBllInstance.CreateSpecialDate(SpecialDate1, account1);
            BllInstance.SpecialDateBllInstance.CreateSpecialDate(SpecialDate2, account1);
            BllInstance.SpecialDateBllInstance.CreateSpecialDate(SpecialDate3, account1);
            BllInstance.SpecialDateBllInstance.CreateSpecialDate(SpecialDate4, account1);
            BllInstance.SpecialDateBllInstance.CreateSpecialDate(SpecialDate5, account1);

            List<SpecialDate> list =
                BllInstance.SpecialDateBllInstance.GetSpecialDateByFromAndToDate(new DateTime(2008, 9, 27),
                                                                                 new DateTime(2008, 9, 30));
            Assert.AreEqual(4,list.Count);
        }
    }
}
