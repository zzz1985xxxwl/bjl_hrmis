namespace SEP.HRMIS.Presenter.IPresenter.IAuth
{
    public interface IAssignAuthInfoView
    {
        IAssignHrmisAuthView AssignHrmisAuthView { get; set;}

        IAssignAuthDepartmentTree DepartmentTreeView { get; set;}

        bool AssignAuthDepartmentTreeVisible { get; set;}
    }
}
