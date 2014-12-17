using System;
using System.Web.UI.WebControls;

namespace SEP.Presenter.IPresenter.IContact
{
    public interface IEmployeeContactListInfoView
    {
        IEmployeeContactListView contactListView{ get; set;}

        IEmployeeContactDetailView contactDetailView{ get; set;}

        IEmployeeContactSearchView contactSearchView{ get; set;}

        bool IsDisplayDetail { get;set;}

        event EventHandler AddDetailButton;

        event CommandEventHandler LetterButton;
       
    }
}