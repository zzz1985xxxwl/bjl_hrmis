using System;
using System.Collections.Generic;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse
{
    public interface IReimburseView
    {
        string DepartmentName { set;}
        Reimburse Reimburse { get; set;}

        string Message { get; set; }

        Employee Employee { get; set; }

        string ApplyDate { get; set; }

        List<ReimburseItem> ReimburseItemSource { get; set; }

        string Operation { get; set; }
        int ExchangeRateID{ get; set; }

        List<ExchangeRateEntity> ExchangeRateSource { set; }
        int SetDeleteFormButton { set; }

        bool SetFormReadonly { get; set; }

        //bool SetUpdateReadonly { set; }

        bool SetDetailReadonly { set; }

        bool SetComfirmReadonly { set;}

        bool SetOutCityVisible{ set;}

        event DelegateID btnUpdateClick;

        event DelegateID btnDeleteClick;

        event DelegateNoParameter btnAddClick;
        string lblApplyDateMsg { set;}
        event EventHandler btnSaveClick;
        event EventHandler btnSubmitClick;
        event EventHandler btnOKClick;
        event EventHandler btnCancelClick;
        event DelegateID btnDetailClick;
        event DelegateID btnPassClick;
        event DelegateID btnIntermitClick;
        event DelegateNoParameter BindReimburseHistorySource;
        /// <summary>
        /// 联系人
        /// </summary>
        List<ReimburseFlow> ReimburseHistorySource { set; }

        /// <summary>
        /// 消费时间
        /// </summary>
        string ConsumeDateFrom { get; set;  }

        /// <summary>
        /// 消费时间
        /// </summary>
        string ConsumeDateFromHour { get; set;  }

        /// <summary>
        /// 消费时间
        /// </summary>
        string ConsumeDateFromMinute { get; set;  }

        /// <summary>
        /// 消费时间
        /// </summary>
        string ConsumeDateTo { get; set;  }

        /// <summary>
        /// 消费时间
        /// </summary>
        string ConsumeDateToHour { get; set;  }

        /// <summary>
        /// 消费时间
        /// </summary>
        string ConsumeDateToMinute { get; set;  }

        string ConsumeDateMsg { get; set; }

        /// <summary>
        /// 投诉类别
        /// </summary>
        List<ReimburseCategoriesEnum> ReimburseCategoriesEnumDataSrc { set;}

        /// <summary>
        /// 投诉类别名称
        /// </summary>
        string ReimburseCategoriesEnumID { set; get;}

        /// <summary>
        /// 单据张数
        /// </summary>
        string PaperCount { get; set;  }
        string PaperCountMsg { get; set; }

        /// <summary>
        /// 差旅报销
        /// </summary>
        bool IsTravelReimburse { get; set; }

        /// <summary>
        /// 目的地
        /// </summary>
        string Destinations { get; set;  }
        string DestinationsMsg { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        //string CustomerName { get; set;  }
        //string CustomerNameMsg { get; set; }

        /// <summary>
        /// 项目
        /// </summary>
        string ProjectName { get; set;  }
        string ProjectNameMsg { get; set; }
        int ProjectID { get; set; }

        string OutCityAllowance { get; set;  }
        string OutCityAllowanceMsg { get; set;  }

        string OutCityDays { get; set;  }
        string OutCityDaysMsg { get; set;  }

        string Remark { get; set;  }
        string Discription { get; set; }


    }
}
