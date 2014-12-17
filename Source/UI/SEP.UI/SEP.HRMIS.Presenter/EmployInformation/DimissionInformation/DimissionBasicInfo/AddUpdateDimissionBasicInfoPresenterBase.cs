//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DimissionBasicInfoDataBinder.cs
// 创建者: 倪豪
// 创建日期: 2008-09-04
// 概述: 新增/修改离职信息的大界面的Presenter的基类，主要处理公共事件
// ----------------------------------------------------------------
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews;

namespace SEP.HRMIS.Presenter.EmployInformation.DimissionInformation.DimissionBasicInfo
{
    public class AddUpdateDimissionBasicInfoPresenterBase
    {
        protected readonly IDimissionBasicView _ItsView;

        public AddUpdateDimissionBasicInfoPresenterBase(IDimissionBasicView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        private void AttachViewEvent()
        {
            _ItsView.SelectDimissionReasonTypeChange += SelectDimissionReasonTypeChange;
        }
        private void SelectDimissionReasonTypeChange()
        {
            if (DimissionReasonType.No7.Id.ToString().Equals(_ItsView.DimissionReasonType))
            {
                _ItsView.DimissionOtherReasonVisible = true;
            }
            else
            {
                _ItsView.DimissionOtherReason = string.Empty;
                _ItsView.DimissionOtherReasonVisible = false;
            }
        }

    }
}