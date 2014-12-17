using System;
using SEP.IBll;
using SEP.Model.Mail;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IWelcomeMail;
using SEP.Model.Accounts;

namespace SEP.Presenter.WelcomeMails
{
    public class WelcomeMailPresenter : BasePresenter
    {
        private const string _Title = "设置自动发信内容";
        private const string _SuccessMessage = "操作成功";
        private const string _LackData = "缺少存储的数据，直接编辑即可";

        private readonly IWelcomeMailView _TheView;

        public WelcomeMailPresenter(IWelcomeMailView theView, Account loginUser)
            : base(loginUser)
        {
            _TheView = theView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _TheView.BtnActionEvent += BtnActionEvent;
            _TheView.MailTypeChange += MailTypeChange;
        }

        public void InitView(bool pageIsPostBack)
        {
            _TheView.TheMessage = string.Empty;

            if (!pageIsPostBack)
            {
                _TheView.Title = _Title;
                _TheView.MailTypes = MailType.GetAllMailType();
                _TheView.MailTypeId = MailType.WelcomeMail.Id.ToString();
                MailTypeChange(_TheView.MailTypeId);
            }
        }

        public void BtnActionEvent()
        {
            try
            {
                BllInstance.WelcomeMailBllInstance.SaveWelcomeMail(_TheView.Content, _TheView.AutoSend, Convert.ToInt32(_TheView.MailTypeId));
                _TheView.TheMessage = _SuccessMessage;
                _TheView.IsSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _TheView.TheMessage = ae.Message;
                _TheView.IsSuccess = false;
            }
        }

        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void MailTypeChange(string id)
        {
            _TheView.AutoSend = false;
            _TheView.Content = string.Empty;
            WelcomeMail theWelcomeMail = BllInstance.WelcomeMailBllInstance.GetLastestWelcomeMailByTypeID(Convert.ToInt32(id));
            if (theWelcomeMail == null)
            {
                _TheView.TheMessage = _LackData;
                return;
            }
            _TheView.AutoSend = theWelcomeMail.EnableAutoSend;
            _TheView.Content = theWelcomeMail.Content;
        }
    }
}
