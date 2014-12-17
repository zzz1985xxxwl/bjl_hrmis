using System;
using System.Collections.Generic;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse
{
    public interface IReimburseItemView
    {
        string Operation { set; }

        /// <summary>
        /// ²îÂÃ±¨Ïú
        /// </summary>
        bool IsTravelReimburse { get; set; }

        List<ReimburseItem> ReimburseItemSource { get; set;}

        bool ActionSuccess { get; set; }

        //string ConsumeDateFrom { get; set;  }

        //string ConsumeDateTo { get; set;  }

        string ConsumePlace { get; set;  }

        //string PaperCount { get; set;  }

        //string ProjectName { get; set;  }

        string Reason { get; set;  }

        ReimburseTypeEnum ReimburseType { get; set;  }

        string TotalCost { get; set;  }

        string Message { get; set; }

        //string ConsumeDateMsg { get; set; }

        //string ProjectNameMsg { get; set; }

        //string PaperCountMsg { get; set; }

        string TotalCostMsg { get; set; }

        string ReasonMsg { get; set; }

        string OperationType { get; set;}

        Dictionary<string, string> ReimburseTypeSource { get; set; }


        string ReimburseItemID { get; set; }
        bool SetFormReadonly { get; set; }

        event EventHandler btnCancelClick;

        event EventHandler btnOKClick;

        event EventHandler btnCustomerCodeChange;

        int? CustomerID { get; set; }

        string CustomerName { get; set; }

        string CustomerNameError { get; set; }

        string CustomerNameCode { get; set; }

        string btnCancelOnClientClick { set;}
    }
}
