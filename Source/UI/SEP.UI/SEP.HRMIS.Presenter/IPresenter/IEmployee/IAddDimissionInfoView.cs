//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: IAddDimissionInfoView.cs
// 创建者: 顾艳娟
// 创建日期: 2008-09-04
// 概述: AddDimissionInfoView需要实现的接口
// ----------------------------------------------------------------

using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter
{
    public interface IAddDimissionInfoView
    {
        /// <summary>
        /// 离职日期
        /// </summary>
        string DimissionDate { get; set;}

        /// <summary>
        /// 经济补偿标准
        /// </summary>
        string DimissionMonth { get; set;}

        string DimissionMonthMessage{ get; set;}

        /// <summary>
        /// 离职类型
        /// </summary>
        string DimissionType{ get; set;}

        /// <summary>
        /// 离职原因
        /// </summary>
        //DimissionReasonType DimissionReasonTypes{ get; set;}
        int DimissionReasonTypeId { get; set;}

        /// <summary>
        /// 其他原因
        /// </summary>
        string DimissionOtherReason { get; set;}
        //界面绑定的显示源
        List<FileCargo> FileCargoes { get; set;}

        event CommandEventHandler btnDeleteClick;

        event CommandEventHandler btnUpdateClick;
        
        bool SetButtonStatus{ set;}

    }
}
