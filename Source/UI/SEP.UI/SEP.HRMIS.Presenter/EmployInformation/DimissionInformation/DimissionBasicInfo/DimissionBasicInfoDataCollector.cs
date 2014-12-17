//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DimissionBasicInfoDataCollector.cs
// 创建者: 倪豪
// 创建日期: 2008-09-04
// 概述: 离职信息的大界面的数据收集类
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews;

namespace SEP.HRMIS.Presenter.EmployInformation.DimissionInformation.DimissionBasicInfo
{
    public class DimissionBasicInfoDataCollector : IDataCollector<Employee>
    {
        private readonly IDimissionBasicView _ItsView;
        private Employee _TheEmployeeToComplete;

        public DimissionBasicInfoDataCollector(IDimissionBasicView  itsView)
        {
            _ItsView = itsView;
        }

        public void CompleteTheObject(Employee theObjectToComplete)
        {
            _TheEmployeeToComplete = theObjectToComplete;
            if (_TheEmployeeToComplete == null)
            {
                throw new Exception(EmployeePresenterUtilitys._ObjectIsNull);
            }

            HandleEmployeeDetailsInfo();
        }

        private void HandleEmployeeDetailsInfo()
        {
            if (_TheEmployeeToComplete.EmployeeDetails == null)
            {
                _TheEmployeeToComplete.EmployeeDetails = new EmployeeDetails(null, null, null, 0m, 0m, null, null,
                                                                             null, new DateTime(1900, 1, 1), null,
                                                                             new DateTime(1900, 1, 1), null, null);
            }
            CollectEmployeeDetailInfo();
        }

        private void HandleWorkInfo()
        {
            if (_TheEmployeeToComplete.EmployeeDetails.Work == null)
            {
                _TheEmployeeToComplete.EmployeeDetails.Work = new Work(null, null, null, new DateTime(1900, 1, 1), null);
                CollectWorkInfo();
            }
            CollectWorkInfo();
        }

        private void HandleDimissionInfo()
        {
            //若界面的离职日显示为空，则认为没有离职信息
            if(string.IsNullOrEmpty(_ItsView.DimissionDate))
            {
                _TheEmployeeToComplete.EmployeeDetails.Work.DimissionInfo = null;
                return;
            }

            if (_TheEmployeeToComplete.EmployeeDetails.Work.DimissionInfo == null)
            {
                _TheEmployeeToComplete.EmployeeDetails.Work.DimissionInfo = new DimissionInfo(new DateTime(1900, 1, 1), null, null, 0, null);
            }
            CollectDimissionInfo();
        }


        private void CollectEmployeeDetailInfo()
        {
            //_TheEmployeeToComplete.EmployeeDetails.FileCargo = _ItsView.FileCargoDataSource;

            HandleWorkInfo();
        }

        private void CollectWorkInfo()
        {
            HandleDimissionInfo();
        }

        private void CollectDimissionInfo()
        {
            _TheEmployeeToComplete.EmployeeDetails.Work.DimissionInfo.DimissionDate = DateTime.Parse(_ItsView.DimissionDate);
            decimal d_NewDimissionMonth = 0;
            _TheEmployeeToComplete.EmployeeDetails.Work.DimissionInfo.NewDimissionMonth =
                decimal.TryParse(_ItsView.DimissionMonth, out d_NewDimissionMonth)
                    ? d_NewDimissionMonth
                    : 0;
            _TheEmployeeToComplete.EmployeeDetails.Work.DimissionInfo.DimissionReason = _ItsView.DimissionOtherReason;
            _TheEmployeeToComplete.EmployeeDetails.Work.DimissionInfo.DimissionReasonType =
                DimissionReasonType.ChooseDimissionReasonType(int.Parse(_ItsView.DimissionReasonType));
            _TheEmployeeToComplete.EmployeeDetails.Work.DimissionInfo.DimissionType = _ItsView.DimissionType;
        }
    }
}