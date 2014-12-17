//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DimissionBasicInfoDataBinder.cs
// 创建者: 倪豪
// 创建日期: 2008-09-26
// 概述: 离职信息的大界面的数据绑定类
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.EmployInformation.EmployeeInformationInterfaces;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews;

namespace SEP.HRMIS.Presenter.EmployInformation.DimissionInformation.DimissionBasicInfo
{
    public class DimissionBasicInfoDataBinder : IDataBinder<Employee>
    {
        private readonly IDimissionBasicView _ItsView;
        private Employee _TheEmployeToShow;

        public DimissionBasicInfoDataBinder(IDimissionBasicView itsView)
        {
            _ItsView = itsView;
        }

        public bool DataBind(Employee theDataToBind)
        {
            _TheEmployeToShow = theDataToBind;

            bool retVal = true;
            if (_TheEmployeToShow != null)
            {
                retVal &= HandleEmployeeDetails();
            }
            return retVal;
        }

        private bool HandleEmployeeDetails()
        {
            bool retVal = true;

            if (_TheEmployeToShow.EmployeeDetails != null)
            {
                //_ItsView.FileCargoDataView = _TheEmployeToShow.EmployeeDetails.FileCargo;
                //_ItsView.FileCargoDataSource = _TheEmployeToShow.EmployeeDetails.FileCargo;

                retVal &= HandleWork();
            }
            return retVal;
        }

        private bool HandleWork()
        {
            bool retVal = true;

            if (_TheEmployeToShow.EmployeeDetails.Work != null)
            {
                retVal &= HandleDimmision();
            }
            return retVal;
        }

        private bool HandleDimmision()
        {
            bool retVal = true;
            if (_TheEmployeToShow.EmployeeDetails.Work.DimissionInfo != null)
            {
                _ItsView.DimissionDate = _TheEmployeToShow.EmployeeDetails.Work.DimissionInfo.DimissionDate.ToShortDateString();
                _ItsView.DimissionMonth = _TheEmployeToShow.EmployeeDetails.Work.DimissionInfo.NewDimissionMonth.ToString();
                _ItsView.DimissionType = _TheEmployeToShow.EmployeeDetails.Work.DimissionInfo.DimissionType;
                try
                {
                    if (_TheEmployeToShow.EmployeeDetails.Work.DimissionInfo.DimissionReasonType != null)
                    {
                        _ItsView.DimissionReasonType =
                            _TheEmployeToShow.EmployeeDetails.Work.DimissionInfo.DimissionReasonType.Id.ToString();
                        if (
                            _TheEmployeToShow.EmployeeDetails.Work.DimissionInfo.DimissionReasonType.Id.Equals(
                                DimissionReasonType.No7.Id))
                        {
                            _ItsView.DimissionOtherReasonVisible = true;
                            _ItsView.DimissionOtherReason =
                                _TheEmployeToShow.EmployeeDetails.Work.DimissionInfo.DimissionReason;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    _ItsView.DimissionReasonTypeMessage = EmployeePresenterUtilitys._TypeNotDefined;
                    retVal &= false;
                }
            }

            return retVal;
        }
    }
}