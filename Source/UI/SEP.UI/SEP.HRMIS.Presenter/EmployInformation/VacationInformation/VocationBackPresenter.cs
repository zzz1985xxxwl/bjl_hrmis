//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: VocationInfoPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-10-09
// 概述: 假期的Presenter，用于配合总界面处理假期的tab view
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.HRMIS.Presenter.EmployInformation
{
    public class VocationBackPresenter
    {
       
        private readonly IEmployeeInfoView _ItsView;
        //private IVacationFacade _IVacationFacade = InstanceFactory.CreateVacationFacade();

        public VocationBackPresenter(IEmployeeInfoView itsView)
        {
            _ItsView = itsView;
           // AttachViewEvent();
        }

        //private void AttachViewEvent()
        //{
        //    _ItsView.BtnActionEvent += VocationEvent;
        //}

        public void InitTheVacation(Employee theEmployee)
        {
            _ItsView.VocationView.Employee = theEmployee;
            _ItsView.VocationView.IsBack = true;
            if (theEmployee.SocWorkAgeAndVacationList == null)
            {
                _ItsView.VocationView.SocietyWorkAge = "0";
            }
            else
            {
                _ItsView.VocationView.SocietyWorkAge = theEmployee.SocWorkAgeAndVacationList.SocietyWorkAge.ToString();
            }

        }

        //private void VocationEvent()
        //{
        //    try
        //    {
        //        _IVacationFacade.EditVacation(_ItsView.VocationView.VacationList, _ItsView.VocationView.Employee); 
        //    }
        //    catch (ApplicationException e)
        //    {
        //        _ItsView.Message = e.Message;
        //        _ItsView.ActionSuccess = false;
        //    }
        //}

    }
}