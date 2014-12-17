using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAuth
{
    public interface IAssignAuthDepartmentTree
    {
        string BackAccountsID { get; set;}

        string AuthID { get; set;}

        List<Department> DepartmentList { get; set;}

        event DelegateNoParameter ShowView;

        event DelegateNoParameter SaveClick;

        bool ActionSuccess { get; set; }

        List<Auth> AuthSource { get; set;}
    }
}
