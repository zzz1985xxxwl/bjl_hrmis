
using System.Collections.Generic;
using SEP.Model.Mail;

namespace SEP.Presenter.IPresenter.IWelcomeMail
{
    public interface IWelcomeMailView
    {
        string Title{ get; set;}

        string Content { get; set;}

        bool AutoSend { get; set;}

        string TheMessage { get; set;}

        bool IsSuccess { get; set;}

        string MailTypeId { get; set;}

        List<MailType> MailTypes { set;}

        event DelegateNoParameter BtnActionEvent;

        event DelegateID MailTypeChange;
    }
}
