using System;
using ComService.ServiceModels;

namespace SEP.Presenter.IPresenter.IContact
{
    public interface IEmployeeContact
    {
        int UserId { get;}

        bool IsCompany { get;}

        Contact CurrentContact { set;}

        event DelegateLinkmanSearch SearchByName;
        event DelegateLinkmanSearch SearchByIndexKey;
        event DelegateLinkman SaveLinkman;
        event DelegeteGuid DeleteLinkman;
        string Message { get; set;}
    }

    public delegate void DelegateLinkmanSearch(string condition);

    public delegate void DelegateLinkman(Linkman linkman);

    public delegate void DelegeteGuid(Guid guid);
}