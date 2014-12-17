//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateCoursePresenter.cs
// ������: ����
// ��������: 2008-11-15
// ����:�޸���ѵ�γ�
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.Train.TrainCourse
{
    public class UpdateCoursePresenter
    {
        private readonly ICourseView _ItsView;
        private readonly ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();
        private Course _ANewObject;
        //private IGetTrainCourse _GetTrainCourse = new GetTrainCourse();
        private readonly string _CourseId;
        private readonly Account _LoginUser;
        public UpdateCoursePresenter(ICourseView itsView, string courseId, Account loginUser)
        {
            _ItsView = itsView;
            _CourseId = courseId;
            _LoginUser = loginUser;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += UpdateEvent;
        }

        public void InitView(bool isPostBack, bool IsFront)
        {
            _ItsView.Message = string.Empty;
            _ItsView.OperationTitle = CourseUtility.UpdatePageTitle;
            _ItsView.OperationType = CourseUtility.UpdateOperationType;

            if (!isPostBack)
            {
                new CourseInfoViewIniter(_ItsView).InitTheViewToDefault();
                new CourseDataBinder(_ItsView).DataBind(_CourseId);
            }
            if (!IsFront)
            {
                _ItsView.SetBtnhiden = true;
            }
        }

        public void UpdateEvent()
        {
            //������֤����
            if (!new CourseValidation(_ItsView).Vaildate())
            {
                return;
            }
            //�����ռ�����
            _ANewObject = _ITrainFacade.GetTrainCourseByPKID(Convert.ToInt32(_CourseId));
            new CouserDataCollecter(_ItsView).CompleteTheObject(_ANewObject);
            //ִ���������

            try
            {
                _ITrainFacade.UpdateTrainCourse(_ANewObject, _ItsView.SkillList, _ItsView.EmployeeList,_LoginUser);
                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
        }

        ///// <summary>
        ///// use for test
        ///// </summary>
        //public IGetTrainCourse GetTrainCouse
        //{
        //    set { _GetTrainCourse = value; }
        //}
    }
}
