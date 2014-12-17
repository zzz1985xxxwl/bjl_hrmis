//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IEditCompanyRegulationsView.cs
// 创建者: SYY
// 创建日期: 2009-01-04
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.Model.CompanyRegulations;

namespace SEP.Presenter.IPresenter.ICompanyRegulations
{
    public interface IEditCompanyRegulationView
    {
        /// <summary>
        /// 规章PKID
        /// </summary>
        int ComanyReguId { get; set;}

        /// <summary>
        /// 标题
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// 公司规章制度类型数据源
        /// </summary>
        List<KeyValuePair<int, string>> ReguTypeDataSrc { get; set;}

        /// <summary>
        /// 选择的公司规章制度类型
        /// </summary>
        int SelectedReguType { get; set;}

        /// <summary>
        /// 内容
        /// </summary>
        string Content { get; set; }

        /// <summary>
        /// 附件列表
        /// </summary>
        List<CompanyReguAppendix> CompanyReguAppendixList { get; set; }

        /// <summary>
        /// 选择的附件PKID
        /// </summary>
        int SelectedCompanyReguAppendixId { get; }


        /// <summary>
        /// 标题报错信息
        /// </summary>
        string CompanyRegulationsTitleErrorMessage { get;set; }

        /// <summary>
        /// 报错信息
        /// </summary>
        string ErrorMessageFromCompanyRegulations { get;set;}

        /// <summary>
        /// 附件信息
        /// </summary>
        string CompanyReguAppendixListErrorMessage { get;set; }

        /// <summary>
        /// 初始化界面
        /// </summary>
        event EventHandler InitView;

        /// <summary>
        /// 更改类型
        /// </summary>
        event EventHandler ChangedType;

        /// <summary>
        /// 保存
        /// </summary>
        event EventHandler btnOKClicked;

        /// <summary>
        /// 新增附件
        /// </summary>
        event EventHandler AddAppendix;

        /// <summary>
        /// 删除附件
        /// </summary>
        event EventHandler DeleteAppendix;

    }
}
