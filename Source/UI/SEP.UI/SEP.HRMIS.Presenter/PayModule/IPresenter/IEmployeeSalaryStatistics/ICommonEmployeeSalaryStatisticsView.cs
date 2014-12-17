
namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics
{
    public interface ICommonEmployeeSalaryStatisticsView
    {
        IAverageStatistics.ICommonStatisticsView IAverageStatistics_ICommonStatisticsView {get; set;}
        ISummaryStatistics.ICommonStatisticsView ISummaryStatistics_ICommonStatisticsView {get; set;}
    }
}
