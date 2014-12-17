using System;
using SEP.Presenter.IPresenter.IDepartments;

namespace SEP.Presenter.Departments
{
    public class DepartmentVaildater
    {
        private readonly IDepartmentView _ItsView;

        public DepartmentVaildater(IDepartmentView itsView)
        {
            _ItsView = itsView;
        }

        public bool Vaildate()
        {
            _ItsView.DepNameMsg = string.Empty;
            _ItsView.LeaderNameMsg = string.Empty;
            _ItsView.Message = string.Empty;
            DateTime temp;
            bool ret = true;
            if (string.IsNullOrEmpty(_ItsView.DepartmentName.Trim()))
            {
                _ItsView.DepNameMsg = DepartmentUtility._NameIsEmpty;
                ret = false;
            }
            if (string.IsNullOrEmpty(_ItsView.LeaderName.Trim()))
            {
                _ItsView.LeaderNameMsg = DepartmentUtility._LeaderIsEmpty;
                ret = false;
            }
            if (string.IsNullOrEmpty(_ItsView.FoundationTime.Trim()))
            {
                ret = true;
            }
            else if (!DateTime.TryParse(_ItsView.FoundationTime,out temp))
            {
                _ItsView.TimeErrorMsg = DepartmentUtility._ErrorDateTime;
                ret = false;
            }
            return ret;
        }
    }
}