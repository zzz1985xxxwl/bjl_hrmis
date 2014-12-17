//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ITemplateItemListView.cs
// 创建者: 刘丹
// 创建日期: 2008-06-16
// 概述: 考评项显示接口
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public interface ITemplateItemListView
    {
        OperateType OperateType { get;}
        string Question { get;}

        string Message { set;}
       
        List<AssessTemplateItem> TemplateItems { get; set;}

        Dictionary<string, string> ItemClassficationSource { set;}
        string ItemClassfication { get;}

        string DelMessage{ set;}

        AssessTemplateItemType SelectedAssessTemplateItemType{ get;}
    }
}
