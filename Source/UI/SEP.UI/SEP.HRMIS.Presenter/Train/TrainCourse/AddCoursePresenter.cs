//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddCoursePresenter.cs
// 创建者: ZZ
// 创建日期: 2008-11-13
// 概述:新增培训课程
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;
using SEP.Model.Accounts;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Presenter.Train.TrainCourse
{
    public class AddCoursePresenter
    {

        private readonly ICourseView _ItsView;
        private readonly ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();
        public Course _ANewObject;
        private readonly Account _LoginUser;
        public AddCoursePresenter(ICourseView itsView, Account loginUser)
        {
            _ItsView = itsView;
            _LoginUser = loginUser;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += AddEvent;
            //_ItsView.CancelButtonEvent += CanclEvent;
        }

        public void InitView(bool isPostBack, bool IsFront)
        {
            _ItsView.Message = string.Empty;
            if (!isPostBack)
            {
                new CourseInfoViewIniter(_ItsView).InitTheViewToDefault();
                _ItsView.OperationTitle = CourseUtility.AddPageTitle;
                _ItsView.OperationType = CourseUtility.AddOperationType;
            }
            if (!IsFront)
            {
                _ItsView.SetBtnhiden = true;
            }
        }

        public void AddEvent()
        {
            //数据验证过程
            if (!new CourseValidation(_ItsView).Vaildate())
            {
                return;
            }
            //数据收集过程
            _ANewObject = new Course();
            new CouserDataCollecter(_ItsView).CompleteTheObject(_ANewObject);
            _ANewObject.TrainFBResult = new TrainFBResult();
            try
            {
                _ITrainFacade.AddTrainCourse(_ANewObject, _ItsView.SkillList, _ItsView.EmployeeList, _LoginUser);
                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
        }

        public ITrainFacade SetTrainCourse
        {
            get { return _ITrainFacade; }
        }

        public void SetApplicationBind(string applicationId)
        {
            int Id;
            if (!int.TryParse(applicationId, out Id))
            {
                _ItsView.Message = "初始化错误";
            }
            ITraineeApplicationFacade facade = InstanceFactory.CreateTraineeApplicationFacade();
            TraineeApplication application = facade.GetTraineeApplicationByPkid(Id);

            _ItsView.CourseName = application.CourseName;
            _ItsView.Place = application.TrainPlace;

            _ItsView.Trainer = application.Trainer;

            _ItsView.TrainScope = application.TrainType.Id.ToString();
            _ItsView.EmployeeList = application.StudentList;
            _ItsView.ChoosedEmployees = RequestUtility.GetEmployeeNames(application.StudentList);
            _ItsView.SkillDisplay = application.Skills;

            _ItsView.ExpectST = application.StratTime.ToString();
            _ItsView.ExpectET = application.EndTime.ToString();
            _ItsView.ExpectCost = application.TrainCost.ToString();
            _ItsView.ExpectHour = application.TrainHour.ToString();
            _ItsView.HasCertifaction = application.HasCertifacation;
        }
    }
}


