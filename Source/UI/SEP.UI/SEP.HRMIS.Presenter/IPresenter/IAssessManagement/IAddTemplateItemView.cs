//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IAddTemplateItemView.cs
// 创建者: 刘丹
// 创建日期: 2008-06-05
// 概述: 添加考评项界面
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public interface IAddTemplateItemView
    {
        string Message { set;}
        string QestionNullMessage { set;}
        string Question { get; set;}
        int AssessTemplateItemType { get; set;}
        OperateType ItemOperateType { get; set;}
        Dictionary<string, string> ClassficationSource {set;}
        string ClassficationId { get; set;}
        string Option5 { get; set;}
        string Option4 { get; set;}
        string Option3 { get; set;}
        string Option2 { get; set;}
        string Option1 { get; set;}
        string ItemMessage5 { set;}
        string ItemMessage4 { set;}
        string ItemMessage3 { set;}
        string ItemMessage2 { set;}
        string ItemMessage1 { set;}
        string Description { get; set;}
        string PageTitle { set;}
        bool ReadOnly { set;}

        #region 打分

        string MaxRange { get; set;}
        string MinRange { get; set;}
        string RangeError{ set;}

        #endregion

        #region 公式

        string Formula { get; set;}
        string FormulaError{ set;}

        #endregion


    }
}
