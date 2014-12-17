//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: TrainCourseBackSearchPresenter.cs
// ������: Emma
// ��������: 2008-11-13
// ����: ��̨��ѯ�γ̵�Presenter
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.Train.TrainCourse
{
    public class TrainCourseBackSearchPresenter
    {
        private readonly ITrainCourseBackSearchView _ItsView;
        private ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();
        //private IGetTrainCourse _GetTrainCourse = new GetTrainCourse();
        private readonly Account _LoginUser;
        List<Course> courses;

        public TrainCourseBackSearchPresenter(ITrainCourseBackSearchView itsView, Account LoginUser)
        {
            _ItsView = itsView;
            _LoginUser = LoginUser;
            AttachEvent();
        }

        private void AttachEvent()
        {
            _ItsView.listView.BtnFinishEvent += FinishCourseEvent;
            _ItsView.listView.DataBind += BindData;
        }

        public void Init(bool isPostBack)
        {
            _ItsView.listView.SetVisisle = true;
            if (!isPostBack)
            {
                GetDataSource();
                SearchEvent(null, null);
            }
        }

        private void FinishCourseEvent(string courseId)
        {
            try
            {
                _ITrainFacade.FinishTrainCourse(Convert.ToInt32(courseId));
                SearchEvent(null, null);
                _ItsView.ErrorMessage = "<span class='fontred'>�����ɹ�</span>";
            }
            catch (Exception ex)
            {
                _ItsView.ErrorMessage = "<span class='fontred'>" + ex.Message + "</span>";
            }

        }

        private void BindData()
        {
            SearchEvent(null, null);
        }

        public void SearchEvent(object sender, EventArgs e)
        {
            if (Validate())
            {
                try
                {
                    _ItsView.ErrorMessage = string.Empty;

                    int scope = TrainScopeType.GetById(Convert.ToInt32(_ItsView.Scope)).Id;
                    int status = TrainStatusType.GetById(Convert.ToInt32(_ItsView.Status)).Id;

                    courses = _ITrainFacade.GetCourseByConditon(_ItsView.CourseName, _ItsView.Codinator,
                                                            scope, status, _ItsView.Trainer, _ItsView.Trainee,
                                                            _ItsView.Skill, _OutStartFrom, _OutStartTo, _OutEndFrom,
                                                            _OutEndTo, _ExpCost, _ExpHour, _ActCost, _ActHour, _LoginUser);
                    _ItsView.listView.Course = courses;

                    _ItsView.ErrorMessage = "<span class='font14b'>���鵽 " + "<span class='fontred'>" + courses.Count + "</span>" + "<span class='font14b'> ����¼</span>";
                }
                catch (Exception ex)
                {
                    _ItsView.TimeErrorMessage = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

        private void GetDataSource()
        {
            _ItsView.ScopeSource = TrainScopeType.AllTrainScopeTypes;
            _ItsView.StatusSource = TrainStatusType.AllTrainStatusTypes;
        }

        #region Validate
        public bool Validate()
        {
            if (!(VaildateExpectedST() && VaildateExpectedET() && VaildateActualST()
                  && VaildateActualET() && VaildateExpectedCost()
                  && VaildateExpectedHour() && VaildateActualCost() && VaildateActualHour()))
            {
                return false;
            }
            if (DateTime.Compare(_OutStartFrom, _OutStartTo) > 0)
            {
                _ItsView.TimeErrorMessage = "�ƻ���ʼʱ��β���ȷ";
                return false;
            }
            if (DateTime.Compare(_OutEndFrom, _OutEndTo) > 0)
            {
                _ItsView.TimeErrorMessage = "ʵ�ʽ���ʱ��β���ȷ";
                return false;
            }
            return true;
        }

        private decimal _ExpCost;
        private bool VaildateExpectedCost()
        {
            if (string.IsNullOrEmpty(_ItsView.ExpectedCost))
            {
                _ExpCost = Convert.ToDecimal(-1);
                return true;
            }
            if (!(decimal.TryParse(_ItsView.ExpectedCost, out _ExpCost)))
            {
                _ItsView.CostErrorMessage = "�ƻ��ɱ���ʽ���벻��ȷ";
                return false;
            }
            else
            {
                return true;
            }
        }
        private decimal _ExpHour;
        private bool VaildateExpectedHour()
        {
            if (string.IsNullOrEmpty(_ItsView.ExpectedHour))
            {
                _ExpHour = Convert.ToDecimal(-1);
                return true;
            }
            if (!(decimal.TryParse(_ItsView.ExpectedHour, out _ExpHour)))
            {
                _ItsView.CostErrorMessage = "�ƻ��ɱ���ʽ���벻��ȷ";
                return false;
            }
            else
            {
                return true;
            }
        }
        private decimal _ActCost;
        private bool VaildateActualCost()
        {
            if (string.IsNullOrEmpty(_ItsView.ActualCost))
            {
                _ActCost = Convert.ToDecimal(-1);
                return true;
            }
            if (!(decimal.TryParse(_ItsView.ActualCost, out _ActCost)))
            {
                _ItsView.CostErrorMessage = "ʵ�ʳɱ���ʽ���벻��ȷ";
                return false;
            }
            else
            {
                return true;
            }
        }
        private decimal _ActHour;
        private bool VaildateActualHour()
        {
            if (string.IsNullOrEmpty(_ItsView.ActualHour))
            {
                _ActHour = Convert.ToDecimal(-1);
                return true;
            }
            if (!(decimal.TryParse(_ItsView.ActualHour, out _ActHour)))
            {
                _ItsView.CostErrorMessage = "ʵ�ʳɱ���ʽ���벻��ȷ";
                return false;
            }
            else
            {
                return true;
            }
        }

        private readonly DateTime _DateFrom = Convert.ToDateTime("1999-1-1");
        private readonly DateTime _DateTo = Convert.ToDateTime("2999-12-31");

        private DateTime _OutStartFrom;
        private bool VaildateExpectedST()
        {
            if (string.IsNullOrEmpty(_ItsView.ExpectedST))
            {
                _OutStartFrom = _DateFrom;
                return true;
            }
            if (!DateTime.TryParse(_ItsView.ExpectedST, out _OutStartFrom))
            {
                _ItsView.TimeErrorMessage = "�ƻ���ʼʱ�����벻��ȷ";
                return false;
            }
            else
            {
                return true;
            }
        }
        private DateTime _OutStartTo;
        private bool VaildateExpectedET()
        {
            if (string.IsNullOrEmpty(_ItsView.ExpectedET))
            {
                _OutStartTo = _DateTo;
                return true;
            }
            if (!DateTime.TryParse(_ItsView.ExpectedET, out _OutStartTo))
            {
                _ItsView.TimeErrorMessage = "�ƻ�����ʱ�����벻��ȷ";
                return false;
            }
            else
            {
                return true;
            }
        }
        private DateTime _OutEndTo;
        private bool VaildateActualST()
        {
            if (string.IsNullOrEmpty(_ItsView.ActualST))
            {
                _OutEndFrom = _DateFrom;
                return true;
            }
            if (!DateTime.TryParse(_ItsView.ActualST, out _OutEndFrom))
            {
                _ItsView.TimeErrorMessage = "ʵ�ʿ�ʼʱ�����벻��ȷ";
                return false;
            }
            else
            {
                return true;
            }
        }
        private DateTime _OutEndFrom;
        private bool VaildateActualET()
        {
            if (string.IsNullOrEmpty(_ItsView.ActualET))
            {
                _OutEndTo = _DateTo;
                return true;
            }
            if (!DateTime.TryParse(_ItsView.ActualET, out _OutEndTo))
            {
                _ItsView.TimeErrorMessage = "ʵ�ʽ���ʱ�����벻��ȷ";
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        /// <summary>
        /// use for test
        /// </summary>
        public ITrainFacade GetTrainCouse
        {
            set { _ITrainFacade = value; }
        }
    }
}
