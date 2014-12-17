using System;
using NUnit.Framework;
using SEP.IBll;
using SEP.Model.Mail;

namespace SEP.IBllTest
{
    [TestFixture]
    public class WelcomeMailBllTest
    {
        [TearDown]
        public void TearDown()
        {
            CleanUpTestData.CleanUpWelcomeMail();
        }

        [Test]
        public void GetLastestWelcomeMailTest()
        {
            BllInstance.WelcomeMailBllInstance.SaveWelcomeMail("WelcomeMail1 #Name#", false,0);
            BllInstance.WelcomeMailBllInstance.SaveWelcomeMail("WelcomeMail2 #Name#", false,0);
            BllInstance.WelcomeMailBllInstance.SaveWelcomeMail("WelcomeMail3 #Name#", false,0);
            WelcomeMail welcomeMail = BllInstance.WelcomeMailBllInstance.GetLastestWelcomeMail();
            Assert.AreEqual(welcomeMail.Content, "WelcomeMail3 #Name#");
        }

        [Test]
        public void VaildateTheContentTest()
        {
            try
            {
                BllInstance.WelcomeMailBllInstance.SaveWelcomeMail("WelcomeMail", false,0);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(@"�ʼ���������Ҫ��""#Name#""�ı�ʶ���滻���û���������", ex.Message);
            }
        }
    }
}
