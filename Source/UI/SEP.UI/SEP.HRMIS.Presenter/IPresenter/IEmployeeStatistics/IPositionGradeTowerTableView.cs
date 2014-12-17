using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model;
using SEP.Model.Positions;

namespace SEP.HRMIS.Presenter
{
    public interface IPositionGradeTowerTableView
    {
        List<PositionGradeStatistics> PositionGradeList{ set;}
    }
}
