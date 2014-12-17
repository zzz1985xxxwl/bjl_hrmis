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
                Assert.AreEqual(@"邮件内容中需要有""#Name#""的标识来替换成用户名与密码", ex.Message);
            }
        }
    }
}
