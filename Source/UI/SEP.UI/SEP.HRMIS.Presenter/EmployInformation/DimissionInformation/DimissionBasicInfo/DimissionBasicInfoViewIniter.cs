//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DimissionBasicInfoViewIniter.cs
// 创建者: 倪豪
// 创建日期: 2008-09-26
// 概述: 离职信息的大界面的界面初始化类
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews;

namespace SEP.HRMIS.Presenter.EmployInformation.DimissionInformation.DimissionBasicInfo
{
    public class DimissionBasicInfoViewIniter : IViewIniter
    {
        private readonly IDimissionBasicView _ItsView;

        public DimissionBasicInfoViewIniter(IDimissionBasicView itsView)
        {
            _ItsView = itsView;
        }

        public void InitTheViewToDefault()
        {
            //字段消息为空
            SetFiledAndMessageEmpty();
            //类型数据源绑定
            BindTypesSource();
            //Session数据为空
            SetTheSessionDataEmpty();
            _ItsView.DimissionOtherReasonVisible = false;
        }

        private void SetTheSessionDataEmpty()
        {
           //_ItsView.FileCargoDataSource = new List<FileCargo>();
        }

        private void BindTypesSource()
        {
            _ItsView.DimissionReasonTypeSource = DimissionReasonType.GetAll();
            _ItsView.DimissionReasonType = DimissionReasonType.No1.Id.ToString();
        }

        private void SetFiledAndMessageEmpty()
        {
            _ItsView.DimissionDate = string.Empty;
            _ItsView.DimissionDateMessage = string.Empty;
            _ItsView.DimissionMonth = string.Empty;
            _ItsView.DimissionMonthMessage = string.Empty;
            _ItsView.DimissionOtherReason = string.Empty;
            _ItsView.DimissionType = string.Empty;
        }
    }
}