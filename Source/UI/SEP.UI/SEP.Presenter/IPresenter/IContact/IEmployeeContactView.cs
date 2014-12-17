namespace SEP.Presenter.IPresenter.IContact
{
    public interface IEmployeeContactView
    {
        IEmployeeContactDetailView EmployeeContactDetailView { get; set;}

        IEmployeeContactListInfoView  EmployeeContactListInfoView{ get; set;}

    }
}