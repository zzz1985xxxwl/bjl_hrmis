//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IReimburseCustomerView.cs
// 创建者: 刘丹
// 创建日期: 2009-09-07
// 概述: 添加出差客户界面
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse
{
   public interface IReimburseCustomerView
    {
        string DepartmentName { set;}
        Reimburse Reimburse { get; set;}

       string ApplierName { set;}

        string Message { get; set; }

        string ApplyDate { get; set; }

        List<ReimburseItem> ReimburseItemSource { get; set; }
        string PaperCount { get; set;  }
        string Destinations { get; set;  }
        string ProjectName { get; set;  }

        event EventHandler btnOKClick;


        /// <summary>
        /// 消费时间
        /// </summary>
        string ConsumeDateFrom { get; set;  }


        /// <summary>
        /// 消费时间
        /// </summary>
        string ConsumeDateTo { get; set;  }


        /// <summary>
        /// 投诉类别
        /// </summary>
        List<ReimburseCategoriesEnum> ReimburseCategoriesEnumDataSrc { set;}

        /// <summary>
        /// 投诉类别名称
        /// </summary>
        string ReimburseCategoriesEnumID { set; get;}


        /// <summary>
        /// 差旅报销
        /// </summary>
        bool IsTravelReimburse { get; set; }


        string OutCityAllowance { get; set;  }

        string OutCityDays { get; set;  }

        string Remark { get; set;  }
    }
}
