using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter
{
    public interface IIndexEditView
    {
        bool HasStatisticsAuth {  set; }
        bool HasValueAddedServices { set; }
    }
}
