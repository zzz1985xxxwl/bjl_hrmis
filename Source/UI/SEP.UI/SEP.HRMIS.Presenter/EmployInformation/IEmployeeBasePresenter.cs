namespace SEP.HRMIS.Presenter.EmployInformation
{
    public interface IEmployeeBasePresenter
    {
        void AttachViewEvent();
        void InitView(bool pageIsPostBack);
    }
}
