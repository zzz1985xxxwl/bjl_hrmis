using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.Bll.Accounts;
using SEP.IDal.Accounts;
using SEP.Model.Accounts;

namespace SEP.IBllTest.AccountTest
{
    [TestFixture]
    public class SavePersonalConfigTest
    {
        private MockRepository mocks;
        //数据
        private Account _CurrentAccount;
        private Account _NewAccount;
        //接口
        private IAccountDal _IAccountDal;
        private SavePersonalConfig _Target;

        [SetUp]
        public void SetUp()
        {
            mocks = new MockRepository();
            //员工
            _IAccountDal = (IAccountDal)mocks.CreateMock(typeof(IAccountDal));
            _CurrentAccount = new Account(1, "", "");
            _NewAccount = new Account(1, "", "");
        }

        [Test, Description("保存员工个人设置成功,正常数据，无usbkey")]
        public void TestSuccess1()
        {
            _NewAccount.IsAcceptEmail = true;
            _NewAccount.IsAcceptSMS = true;
            _NewAccount.IsValidateUsbKey = false;
            Expect.Call(_IAccountDal.GetAccountById(_NewAccount.Id)).Return(_CurrentAccount);
            Expect.Call(delegate { _IAccountDal.UpdateAccount(_CurrentAccount); });
            mocks.ReplayAll();
            _Target = new SavePersonalConfig(_IAccountDal, _NewAccount, null);
            _Target.Excute();
            mocks.ReplayAll();
            Assert.AreEqual(_NewAccount.IsAcceptEmail, _CurrentAccount.IsAcceptEmail);
            Assert.AreEqual(_NewAccount.IsAcceptSMS, _CurrentAccount.IsAcceptSMS);
            Assert.AreEqual(_NewAccount.IsValidateUsbKey, _CurrentAccount.IsValidateUsbKey);
        }

        [Test, Description("保存员工个人设置成功,正常数据，有usbkey")]
        public void TestSuccess2()
        {
            _NewAccount.IsAcceptEmail = true;
            _NewAccount.IsAcceptSMS = true;
            _NewAccount.IsValidateUsbKey = true;
            _CurrentAccount.UsbKey = "ssss";
            Expect.Call(_IAccountDal.GetAccountById(_NewAccount.Id)).Return(_CurrentAccount);
            Expect.Call(delegate { _IAccountDal.UpdateAccount(_CurrentAccount); });

            ////更新电子签名
            byte[] electronIdiograph = new byte[1];
            Expect.Call(delegate { _IAccountDal.DeleteElectronIdiographByAccountID(_NewAccount.Id); });
            Expect.Call(delegate { _IAccountDal.InsertElectronIdiograph(_NewAccount.Id, electronIdiograph); }).
                IgnoreArguments();
            mocks.ReplayAll();
            _Target = new SavePersonalConfig(_IAccountDal, _NewAccount, electronIdiograph);
            _Target.Excute();
            mocks.ReplayAll();
            Assert.AreEqual(_NewAccount.IsAcceptEmail, _CurrentAccount.IsAcceptEmail);
            Assert.AreEqual(_NewAccount.IsAcceptSMS, _CurrentAccount.IsAcceptSMS);
            Assert.AreEqual(_NewAccount.IsValidateUsbKey, _CurrentAccount.IsValidateUsbKey);
        }

        [Test, Description("保存员工个人设置失败,异常数据，无此员工")]
        public void TestFailure1()
        {
            _NewAccount.IsAcceptEmail = true;
            _NewAccount.IsAcceptSMS = true;
            _NewAccount.IsValidateUsbKey = false;
            Expect.Call(_IAccountDal.GetAccountById(_NewAccount.Id)).Return(null);
            mocks.ReplayAll();
            _Target = new SavePersonalConfig(_IAccountDal, _NewAccount, null);
            bool isException = false;
            try
            {
                _Target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "当前帐号不存在！");
                isException = true;
            }
            mocks.ReplayAll();
            Assert.AreEqual(isException, true);
        }

        [Test, Description("保存员工个人设置失败,异常数据，无UsbKey")]
        public void TestFailure2()
        {
            _NewAccount.IsAcceptEmail = true;
            _NewAccount.IsAcceptSMS = true;
            _NewAccount.IsValidateUsbKey = true;
            Expect.Call(_IAccountDal.GetAccountById(_NewAccount.Id)).Return(_CurrentAccount);
            mocks.ReplayAll();
            _Target = new SavePersonalConfig(_IAccountDal, _NewAccount, null);
            bool isException = false;
            try
            {
                _Target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "UsbKey没有生成，请生成UsbKey后，再开启UsbKey身份认证！");
                isException = true;
            }
            mocks.ReplayAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("保存员工个人设置失败,异常数据，无UsbKey")]
        public void TestFailure3()
        {
            _NewAccount.IsAcceptEmail = true;
            _NewAccount.IsAcceptSMS = true;
            _NewAccount.IsValidateUsbKey = false;
            Expect.Call(_IAccountDal.GetAccountById(_NewAccount.Id)).Return(_CurrentAccount);
            mocks.ReplayAll();
            _Target = new SavePersonalConfig(_IAccountDal, _NewAccount, new byte[3]);
            bool isException = false;
            try
            {
                _Target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "增加电子签名请先设置UsbKey！");
                isException = true;
            }
            mocks.ReplayAll();
            Assert.AreEqual(isException, true);
        }
    }
}
