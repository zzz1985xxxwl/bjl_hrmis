

using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public interface IVacationInfoListView
    {
       List<Vacation> VacationList{ get; set;}
       Employee Employee{ get; set;}
       event CommandEventHandler DeleteEvent;
       event CommandEventHandler InitVacationDetailEvent;
       event EventHandler AddEvent;
       event EventHandler InitEvent;
       event EventHandler UpdateEvent;
   }
}
