using System.Web.UI;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet;

namespace SEP.Performance.Views.HRMIS.PayModuleViews
{
    public partial class EmployeeAccountSetDetailBack : UserControl, IEmployeeAccountSetDetailBackPresenter
    {
        public IAdjustHistoryListPresenter AdjustHistoryListView
        {
            get
            {
                return AdjustHistoryListView1;
            }
        }

        public IEmployeeAccountSetDetailPresenter EmployeeAccountSetDetailView
        {
            get
            {
                return SetEmployeeAccountDetailView1;
            }
        }
    }
}