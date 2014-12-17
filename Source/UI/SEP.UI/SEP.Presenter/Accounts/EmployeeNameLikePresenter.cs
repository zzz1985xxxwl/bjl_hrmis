using System;
using System.Collections.Generic;
using System.Text;
using SEP.IBll;

namespace SEP.Presenter.Accounts
{
    public class EmployeeNameLikePresenter
    {
        private List<String> _AllEmployeeName;

        public EmployeeNameLikePresenter()
        {
            _AllEmployeeName = BllInstance.AccountBllInstance.GetAllEmployeeName();
        }

        public string SearchLikeName(string key)
        {
            string result = String.Empty;

            foreach (string s in _AllEmployeeName)
            {
                if(s.Contains(key))
                    result += s + "$";
            }
            return result.TrimEnd('$');
        }
    }
}
