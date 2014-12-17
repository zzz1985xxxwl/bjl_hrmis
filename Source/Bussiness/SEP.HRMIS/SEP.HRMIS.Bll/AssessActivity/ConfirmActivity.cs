//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ConfirmActivity.cs
// 创建者: 倪豪
// 创建日期: 2008-05-20
// 概述: 人事确认考评活动的事务
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.IBll;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// 人事确认考评活动的事务
    /// </summary>
    public class ConfirmActivity : Transaction
    {
        private readonly int _ActivityId;
        private readonly int _AssessTempletPaperId;
        private readonly DateTime _ManagerExpectedFinish;
        private readonly DateTime _PersonalExpectedTime;
        private readonly string _CurrentEmployeeName;
        private readonly bool _IsPrefectTemplate;
        private Model.AssessActivity _ItsAssessActivity;
        private AssessTemplatePaper _ItsAssessTemplatePaper;

        private IActiveFlow _iActiveFlow = new ActiveFlow();
        private static IAssessActivity _IAssessActivity = DalFactory.DataAccess.AssessActivityDal;
        private static IAssessTemplatePaper _IAssessTemplatePaper = DalFactory.DataAccess.CreateAssessTemplatePaper();

        /// <summary>
        /// 人事确认考评活动的事务
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="assessTempletPaperId"></param>
        /// <param name="managerExpectedFinish"></param>
        /// <param name="personalExpectedTime"></param>
        /// <param name="currentEmployeeName"></param>
        public ConfirmActivity(int activityId, int assessTempletPaperId, DateTime managerExpectedFinish, DateTime personalExpectedTime, string currentEmployeeName)
        {
            _ActivityId = activityId;
            _AssessTempletPaperId = assessTempletPaperId;
            _ManagerExpectedFinish = managerExpectedFinish;
            _PersonalExpectedTime = personalExpectedTime;
            _IsPrefectTemplate = CheckTemplatePapaer();
            _CurrentEmployeeName = currentEmployeeName;
        }

        /// <summary>
        /// 人事确认考评活动的事务
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="assessTempletPaperId"></param>
        /// <param name="managerExpectedFinish"></param>
        /// <param name="employeeExpectedTime"></param>
        /// <param name="currentEmployeeName"></param>
        /// <param name="ia"></param>
        /// <param name="itp"></param>
        public ConfirmActivity(int activityId, int assessTempletPaperId, DateTime managerExpectedFinish, DateTime employeeExpectedTime, string currentEmployeeName, IAssessActivity ia, IAssessTemplatePaper itp)
        {
            _ActivityId = activityId;
            _AssessTempletPaperId = assessTempletPaperId;
            _ManagerExpectedFinish = managerExpectedFinish;
            _PersonalExpectedTime = employeeExpectedTime;
            _CurrentEmployeeName = currentEmployeeName;
            _IAssessActivity = ia;
            _IAssessTemplatePaper = itp;

            _IsPrefectTemplate = CheckTemplatePapaer();
        }

        protected override void Validation()
        {
            try
            {
                _ItsAssessActivity = _IAssessActivity.GetAssessActivityById(_ActivityId);
                _ItsAssessActivity.ItsEmployee.Account =
                    BllInstance.AccountBllInstance.GetAccountById(_ItsAssessActivity.ItsEmployee.Account.Id);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
            if (_ItsAssessActivity == null)
            {
                BllUtility.ThrowException(BllExceptionConst._InvalidActivityId);
            }
            if (_ItsAssessActivity.ItsAssessStatus != AssessStatus.HRComfirming)
            {
                BllUtility.ThrowException(BllExceptionConst._InvalidStatus);
            }
        }

        protected override void ExcuteSelf()
        {
            MakeAssessPaper map = new MakeAssessPaper(_ItsAssessTemplatePaper, _ItsAssessActivity);
            _ItsAssessActivity.HRConfirmerName = _CurrentEmployeeName;
            _ItsAssessActivity.ManagerExpectedFinish = _ManagerExpectedFinish;
            _ItsAssessActivity.PersonalExpectedFinish = _PersonalExpectedTime;

            TransferAssessTemplatePaperToAssessActivityPaper(_ItsAssessTemplatePaper);
            PrepareAssessActivity(map);
            _iActiveFlow.AssessActivity = _ItsAssessActivity;
            ++_iActiveFlow.AssessActivity.NextStepIndex;
            _iActiveFlow.ExcuteFlow();
        }

        private void TransferAssessTemplatePaperToAssessActivityPaper(AssessTemplatePaper assessTemplatePaper)
        {
            _ItsAssessActivity.ItsAssessActivityPaper.PaperName = assessTemplatePaper.PaperName;
            _ItsAssessActivity.ItsAssessActivityPaper.ItsAssessActivityItems = new List<AssessActivityItem>();

            foreach (AssessTemplateItem item in assessTemplatePaper.ItsAssessTemplateItems)
            {
                switch (item.ItsOperateType)
                {
                    case OperateType.HR:
                        HRItem hrItem =
                            new HRItem(item.Question, item.Option, item.Classfication, item.Description);
                        hrItem.Grade = 0;
                        hrItem.Note = "";
                        hrItem.AssessTemplateItemType = item.AssessTemplateItemType;
                        hrItem.Weight = item.Weight;
                        _ItsAssessActivity.ItsAssessActivityPaper.ItsAssessActivityItems.Add(hrItem);
                        break;
                    case OperateType.NotHR:
                        PersonalItem personalItem =
                            new PersonalItem(item.Question, item.Option, item.Classfication, item.Description);
                        personalItem.Grade = 0;
                        personalItem.Note = "";
                        personalItem.AssessTemplateItemType = item.AssessTemplateItemType;
                        personalItem.Weight = item.Weight;
                        _ItsAssessActivity.ItsAssessActivityPaper.ItsAssessActivityItems.Add(personalItem);
                        ManagerItem managerItem =
                            new ManagerItem(item.Question, item.Option, item.Classfication, item.Description);
                        managerItem.Grade = 0;
                        managerItem.Note = "";
                        managerItem.AssessTemplateItemType = item.AssessTemplateItemType;
                        managerItem.Weight = item.Weight;
                        _ItsAssessActivity.ItsAssessActivityPaper.ItsAssessActivityItems.Add(managerItem);
                        break;
                    default:
                        break;
                }
            }
        }

        private void PrepareAssessActivity(MakeAssessPaper map)
        {
            for (int i = 0; i < _ItsAssessActivity.DiyProcess.DiySteps.Count; i++)
            {
                switch (_ItsAssessActivity.ItsAssessActivityPaper.SubmitInfoes[i].SubmitInfoType.Id)
                {
                    //SubmitInfoType.HRAssess
                    case 0:
                        _ItsAssessActivity.ItsAssessActivityPaper.SubmitInfoes[i].ItsAssessActivityItems = map.HrItems();
                        break;
                    //SubmitInfoType.MyselfAssess
                    case 1:
                    //SubmitInfoType.ManagerAssess
                    case 2:
                        _ItsAssessActivity.ItsAssessActivityPaper.SubmitInfoes[i].ItsAssessActivityItems = map.NotHrItems();
                        break;
                }
            }
        }

        /// <summary>
        /// 判断template表是否是一个完美的模板(包括item的数量必须满足一定条件)
        /// </summary>
        private bool CheckTemplatePapaer()
        {
            try
            {
                _ItsAssessTemplatePaper = _IAssessTemplatePaper.GetTempletPaperAndItemById(_AssessTempletPaperId);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
            if (_ItsAssessTemplatePaper == null)
            {
                BllUtility.ThrowException(BllExceptionConst._InvalidTemplateId);
            }
            if (_ItsAssessTemplatePaper.ItsAssessTemplateItems == null)
            {
                BllUtility.ThrowException(BllExceptionConst._AssessTemplateItem_Not_Exist);
            }
            if (_ItsAssessTemplatePaper.ItsAssessTemplateItems.Count == AAUtility._ItemsNotNull)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// for test
        /// </summary>
        public IActiveFlow ActiveFlow
        {
            set
            {
                _iActiveFlow = value;
            }
        }

        /// <summary>
        /// 用于界面层判断是否所选的assessTemplatePaper是否满足条件
        /// </summary>
        public bool IsPrefectTemplate
        {
            get
            {
                return _IsPrefectTemplate;
            }
        }
    }
}
