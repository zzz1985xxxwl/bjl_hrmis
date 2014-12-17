using System;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Presenter.IPresenter;
using SEP.Presenter.IPresenter.IDepartments;

namespace SEP.Presenter.Departments
{
    public class DepartmentDataCollector : IDataCollector<Department>
    {
        private readonly IDepartmentView _ItsView;

        public DepartmentDataCollector(IDepartmentView itsView)
        {
            _ItsView = itsView;
        }

        public void CompleteTheObject(Department theObjectToComplete)
        {
            if (theObjectToComplete != null)
            {
                theObjectToComplete.Name = _ItsView.DepartmentName;
                theObjectToComplete.Leader = new Account();
                theObjectToComplete.Leader.Name = _ItsView.LeaderName;
                theObjectToComplete.Address = _ItsView.Address;
                theObjectToComplete.Phone = _ItsView.Phone;
                theObjectToComplete.Fax = _ItsView.Fax;
                theObjectToComplete.Others = _ItsView.Others;
                theObjectToComplete.Description = _ItsView.Description;
                if (string.IsNullOrEmpty(_ItsView.FoundationTime))
                {
                    theObjectToComplete.FoundationTime = null;
                }
                else
                {
                    theObjectToComplete.FoundationTime =Convert.ToDateTime
                        (_ItsView.FoundationTime);
                }
            }
        }
    }
}