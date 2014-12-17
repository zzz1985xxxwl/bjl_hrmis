using System;
using SEP.Model;
using SEP.Presenter.IPresenter.IAccounts;
using SEP.Model.Accounts;
using SEP.IBll;
using ShiXin.Security;

namespace SEP.Presenter.Accounts
{
    public class PersonalConfigPresenter : Core.BasePresenter
    {
        private readonly IPersonalConfigView _ItsView;

        public PersonalConfigPresenter(IPersonalConfigView itsView, Account loginUser)
            : base(loginUser)
        {
            _ItsView = itsView;
            _ItsView.ActionButtonEvent += DoSaveEvent;
            _ItsView.CancelButtonEvent += DoCancelEvent;
            _ItsView.ChangeButtonEvent += DoChangeUsbKeyEvent;
        }

        public override void Initialize(bool isPostBack)
        {
            ClearMessage();
            if (!isPostBack)
            {
                BindData();
            }
            BindUsbKeyAndElectronIdiograph();
        }

        private void BindUsbKeyAndElectronIdiograph()
        {
            Account account = BllInstance.AccountBllInstance.GetAccountById(LoginUser.Id);
            if (account.UsbKey == null)
            {
                _ItsView.UsbKeyMsg = "你目前尚未生成UsbKey";
            }
            //电子签名
            byte[] photo = BllInstance.AccountBllInstance.GetElectronIdiographByAccountID(LoginUser);
            if (photo != null)
            {
                try
                {
                    _ItsView.Photo = SecurityUtil.SymmetricDecryptStream(photo, account.UsbKey);
                }
                catch
                {
                    _ItsView.ElectricNameMsg = "UsbKey有误，电子签名读取失败！";
                }
            }
        }

        private void ClearMessage()
        {
            _ItsView.Message = String.Empty;
            _ItsView.UsbKeyMsg = String.Empty;
            
        }

        private void BindData()
        {
            _ItsView.AcceptEmail = LoginUser.IsAcceptEmail;
            _ItsView.AcceptSMS = LoginUser.IsAcceptSMS;
            _ItsView.ValidateUsbKey = LoginUser.IsValidateUsbKey;
        }

        private void CollecteData()
        {
            LoginUser.IsAcceptEmail = _ItsView.AcceptEmail;
            LoginUser.IsAcceptSMS = _ItsView.AcceptSMS;
            LoginUser.IsValidateUsbKey = _ItsView.ValidateUsbKey;
        }

        private bool ValidateUsbKeyChange()
        {
            if (_ItsView.UsbKeyCount < 1)
            {
                _ItsView.UsbKeyMsg = MessageKeys._UsbKey_Not_Exist;
                return false;
            }
            if (_ItsView.UsbKeyCount > 1)
            {
                _ItsView.UsbKeyMsg = MessageKeys._UsbKey_Not_Repeat;
                return false;
            }
            return true;
        }

        protected void DoChangeUsbKeyEvent()
        {
            if (!ValidateUsbKeyChange())
                return;
            try
            {
                byte[] photo = BllInstance.AccountBllInstance.GetElectronIdiographByAccountID(LoginUser);
                if (photo != null)
                {
                    //对称加密算法-解密
                    byte[] oldElectronIdiograph = SymmetricDecryptStream(photo, BllInstance.AccountBllInstance.GetAccountById(
                                                         LoginUser.Id).UsbKey);

                    // 对称加密算法-加密
                    byte[] newElectronIdiograph = SymmetricEncryptStream(oldElectronIdiograph, SecurityUtil.SymmetricEncrypt(_ItsView.UsbKey, LoginUser.LoginName));
                    BllInstance.AccountBllInstance.UpdateElectronIdiograph(LoginUser, newElectronIdiograph);
                }
                BllInstance.AccountBllInstance.SetUsbKey(LoginUser.LoginName, _ItsView.UsbKey, LoginUser);
                _ItsView.UsbKeyMsg = "成功更新UsbKey！";
            }
            catch (Exception ex)
            {
                _ItsView.UsbKeyMsg = ex.Message;
            }
        }

        protected void DoSaveEvent()
        {
            try
            {
                CollecteData();
                BllInstance.AccountBllInstance.SavePersonalConfig(LoginUser, _ItsView.Photo);

                _ItsView.Message = "修改成功！";// "&nbsp;&nbsp;&nbsp;<img src='../../image/cg.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;<span class='fontred'>" + "修改成功！" + "</span>";
            }
            catch (Exception ex)
            {
                _ItsView.Message = ex.Message;
            }
        }

        protected void DoCancelEvent()
        {
            BindData();
        }

        protected static byte[] SymmetricDecryptStream(byte[] photo, string usbkey)
        {
            try
            {
                return SecurityUtil.SymmetricDecryptStream(photo, usbkey);
            }
            catch (Exception)
            {

                return null;
            }
        }

        protected static byte[] SymmetricEncryptStream(byte[] photo, string usbkey)
        {
            try
            {
                return SecurityUtil.SymmetricEncryptStream(photo, usbkey);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
