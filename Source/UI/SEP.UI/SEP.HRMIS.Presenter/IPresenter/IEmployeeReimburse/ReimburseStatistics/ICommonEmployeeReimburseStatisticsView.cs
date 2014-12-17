using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics
{
    public interface ICommonEmployeeReimburseStatisticsView
    {
        ICommonStatisticsView ICommonStatisticsView { get; set;}
        IEmployeeCommonStatisticsView IEmployeeCommonStatisticsView { get; set;}
    }
}
