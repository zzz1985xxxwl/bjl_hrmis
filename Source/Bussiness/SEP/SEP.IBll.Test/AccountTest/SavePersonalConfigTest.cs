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
        //����
        private Account _CurrentAccount;
        private Account _NewAccount;
        //�ӿ�
        private IAccountDal _IAccountDal;
        private SavePersonalConfig _Target;

        [SetUp]
        public void SetUp()
        {
            mocks = new MockRepository();
            //Ա��
            _IAccountDal = (IAccountDal)mocks.CreateMock(typeof(IAccountDal));
            _CurrentAccount = new Account(1, "", "");
            _NewAccount = new Account(1, "", "");
        }

        [Test, Description("����Ա���������óɹ�,�������ݣ���usbkey")]
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

        [Test, Description("����Ա���������óɹ�,�������ݣ���usbkey")]
        public void TestSuccess2()
        {
            _NewAccount.IsAcceptEmail = true;
            _NewAccount.IsAcceptSMS = true;
            _NewAccount.IsValidateUsbKey = true;
            _CurrentAccount.UsbKey = "ssss";
            Expect.Call(_IAccountDal.GetAccountById(_NewAccount.Id)).Return(_CurrentAccount);
            Expect.Call(delegate { _IAccountDal.UpdateAccount(_CurrentAccount); });

            ////���µ���ǩ��
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

        [Test, Description("����Ա����������ʧ��,�쳣���ݣ��޴�Ա��")]
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
                Assert.AreEqual(ex.Message, "��ǰ�ʺŲ����ڣ�");
                isException = true;
            }
            mocks.ReplayAll();
            Assert.AreEqual(isException, true);
        }

        [Test, Description("����Ա����������ʧ��,�쳣���ݣ���UsbKey")]
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
                Assert.AreEqual(ex.Message, "UsbKeyû�����ɣ�������UsbKey���ٿ���UsbKey�����֤��");
                isException = true;
            }
            mocks.ReplayAll();
            Assert.AreEqual(isException, true);
        }
        [Test, Description("����Ա����������ʧ��,�쳣���ݣ���UsbKey")]
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
                Assert.AreEqual(ex.Message, "���ӵ���ǩ����������UsbKey��");
                isException = true;
            }
            mocks.ReplayAll();
            Assert.AreEqual(isException, true);
        }
    }
}
