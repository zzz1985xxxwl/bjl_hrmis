using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter
{
    public interface IPositionGradeTowerTableIndexView
    {
        IStatisticsConditionView IStatisticsConditionView { get; set;}
        IPositionGradeTowerTableView IPositionGradeTowerTableView { get; set;}

    }
}
