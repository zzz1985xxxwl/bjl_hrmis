using System;
using SEP.HRMIS.Presenter;
namespace SEP.Performance.Pages.HRMIS.EmployeeStatisticsPages
{
    public partial class EmployeeStatistics : BasePage
    {
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            CommonStatisticsPresenter commonStatisticsBackPresenter =
                new CommonStatisticsPresenter(CommonStatisticsView1, LoginUser);
            commonStatisticsBackPresenter.InitPresent(IsPostBack);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}
