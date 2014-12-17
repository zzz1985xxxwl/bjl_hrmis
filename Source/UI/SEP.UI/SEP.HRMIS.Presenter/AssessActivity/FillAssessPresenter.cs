//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: FillAssessPresenter.cs
// 创建者:wang.shali
// 创建日期: 2008-06-16
// 概述: 填写考评项基类
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.Positions;
using SEP.Presenter.Core;
using hrmisModel = SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class FillAssessPresenter : BasePresenter
    {
        protected IAssessAnswerView _View;
        protected Model.AssessActivity _AssessActivity;
        protected SubmitInfo _SubmitInfo;
        private readonly string _StrAssessActivityId;
        private readonly string _StrSubmitId;
        protected decimal? _SalaryNow;
        protected decimal? _SalaryChange;
        protected string _ManageSalary;

        public FillAssessPresenter(string strAssessActivityId, string submitID, IAssessAnswerView view,
                                   Account loginUser)
            : base(loginUser)
        {
            if (view == null)
            {
                throw new Exception("view may not be null");
            }

            _StrAssessActivityId = strAssessActivityId;
            _StrSubmitId = submitID;
            _View = view;
        }

        public override void Initialize(bool isPostBack)
        {
            _View.Message = string.Empty;
            int assessActivityID;
            if (!int.TryParse(_StrAssessActivityId, out assessActivityID))
            {
                _View.Message = "考核信息传入错误";
                return;
            }

            _AssessActivity = InstanceFactory.AssessActivityFacade.GetAssessActivityByAssessActivityID(assessActivityID);
            if (_AssessActivity.AssessCharacterType == AssessCharacterType.ProbationII)
            {
                _View.SalaryName = "转正后工资&nbsp;<span class=\"redstar\">*</span>";
            }
            else if (_AssessActivity.AssessCharacterType == AssessCharacterType.Annual)
            {
                _View.SalaryName = "建议工资";
            }
            int submitID;
            if (!int.TryParse(_StrSubmitId, out submitID))
            {
                _View.Message = "考核信息传入错误";
                return;
            }

            if (submitID == 0)
            {
                _SubmitInfo = _AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_AssessActivity.NextStepIndex];
            }
            else
            {
                for (int i = 0; i < _AssessActivity.ItsAssessActivityPaper.SubmitInfoes.Count; i++)
                {
                    if (_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[i].SubmitInfoID == submitID)
                    {
                        _SubmitInfo = _AssessActivity.ItsAssessActivityPaper.SubmitInfoes[i];
                    }
                }
            }
            for (int i = 0; i < _AssessActivity.ItsAssessActivityPaper.SubmitInfoes.Count; i++)
            {
                if (_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[i].SubmitInfoType.Id ==
                    SubmitInfoType.HRAssess.Id)
                {
                    _SalaryNow = _AssessActivity.ItsAssessActivityPaper.SubmitInfoes[i].SalaryNow;
                }
                else if (_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[i].SubmitInfoType.Id ==
                         SubmitInfoType.Approve.Id)
                {
                    _SalaryChange = _AssessActivity.ItsAssessActivityPaper.SubmitInfoes[i].SalaryChange;
                }
                else if (_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[i].SubmitInfoType.Id ==
                         SubmitInfoType.ManagerAssess.Id)
                {
                    if (
                        !string.IsNullOrEmpty(
                             _AssessActivity.ItsAssessActivityPaper.SubmitInfoes[i].SalaryChange.ToString()))
                    {
                        _ManageSalary =
                            string.Format("主管意见：{0}",
                                          _AssessActivity.ItsAssessActivityPaper.SubmitInfoes[i].SalaryChange);
                    }
                }
            }
        }

        public string[] GetIntentionsForUI()
        {
            string[] Intentions = _AssessActivity.Intention.Split('/');
            return Intentions;
        }

        public List<AssessActivityItem> GetItemsForUI(bool ifHrItem)
        {
            List<AssessActivityItem> newItems = new List<AssessActivityItem>();
            string itemType = "";
            foreach (AssessActivityItem originalItems in _SubmitInfo.ItsAssessActivityItems)
            {
                switch (_SubmitInfo.SubmitInfoType.Id)
                {
                        //HRAssess
                    case 0:
                        itemType = GetHRItemClass();
                        break;
                        //MyselfAssess
                    case 1:
                        itemType = GetPersonalItemClass();
                        break;
                        //ManagerAssess
                    case 2:
                        itemType = GetManagerItemClass();
                        break;
                }
                AssessActivityItem item =
                    FindAssessActivityItem(originalItems.Question, itemType,
                                           _AssessActivity.ItsAssessActivityPaper.ItsAssessActivityItems);
                if (item != null)
                {
                    newItems.Add(item);
                }
            }
            return newItems;
        }

        /// <summary>
        /// 通过question以及itemType找到当前AssessActivityPaper的相应的items
        /// </summary>
        private static AssessActivityItem FindAssessActivityItem(string question, string itemType,
                                                                 List<AssessActivityItem> assessActivityItems)
        {
            foreach (AssessActivityItem item in assessActivityItems)
            {
                if (item.Question.Equals(question) && itemType.Equals(item.GetType().ToString()))
                {
                    return item;
                }
            }

            return null;
        }

        private static string GetHRItemClass()
        {
            HRItem hrItem = new HRItem("", "", ItemClassficationEmnu.All, "");
            return hrItem.GetType().ToString();
        }

        private static string GetManagerItemClass()
        {
            ManagerItem managerItem = new ManagerItem("", "", ItemClassficationEmnu.All, "");
            return managerItem.GetType().ToString();
        }

        private static string GetPersonalItemClass()
        {
            PersonalItem personalItem = new PersonalItem("", "", ItemClassficationEmnu.All, "");
            return personalItem.GetType().ToString();
        }

        public bool HrValidation()
        {
            _View.CommentMsg = string.Empty;
            _View.IntentionMsg = string.Empty;
            _View.Message = string.Empty;
            _View.SalaryNowMessage = string.Empty;
            bool ret = true;
            ret &= ValideScore(ret);
            if (!string.IsNullOrEmpty(_View.SalaryNow))
            {
                decimal d;
                if (!decimal.TryParse(_View.SalaryNow, out d))
                {
                    _View.SalaryNowMessage = "格式错误";
                    ret = false;
                }
            }
            else if (_AssessActivity.AssessCharacterType == AssessCharacterType.ProbationII)
            {
                _View.SalaryNowMessage = "不可为空";
                ret = false;
            }
            return ret;
        }

        private bool ValideScore(bool ret)
        {
            if (_View.AssessActivityItems != null)
            {
                foreach (AssessActivityItem item in _View.AssessActivityItems)
                {
                    if (item.AssessTemplateItemType == AssessTemplateItemType.Score)
                    {
                        string[] range = item.Option.Split('/');
                        decimal temp;
                        if (string.IsNullOrEmpty(item.GradeString))
                        {
                            _View.Message = "打分不能为空;";
                            ret = false;
                        }
                        else if (!Decimal.TryParse(item.GradeString, out temp))
                        {
                            _View.Message = "打分格式错误;";
                            ret = false;
                        }
                        else if (temp < Convert.ToInt32(range[0]) || temp > Convert.ToInt32(range[1]))
                        {
                            _View.Message = "打分超出范围;";
                            ret = false;
                        }
                    }
                    else if (item.AssessTemplateItemType == AssessTemplateItemType.Open)
                    {
                        if (string.IsNullOrEmpty(item.Note) && (!_View.Message.Contains("个人总结项必填")))
                        {
                            _View.Message += "个人总结项必填";
                            ret = false;
                        }
                    }
                }
                if (ret)
                {
                    foreach (AssessActivityItem item in _View.AssessActivityItems)
                    {
                        if (item.AssessTemplateItemType == AssessTemplateItemType.Score)
                        {
                            item.Grade = Convert.ToDecimal(item.GradeString);
                        }
                    }
                }
            }

            return ret;
        }

        public bool PersonalValidation()
        {
            _View.CommentMsg = string.Empty;
            _View.IntentionMsg = string.Empty;
            _View.Message = string.Empty;
            bool ret = true;
            if (!String.IsNullOrEmpty(_AssessActivity.Intention) &&
                (_AssessActivity.ItsAssessStatus == AssessStatus.ManagerFilling ||
                 _AssessActivity.ItsAssessStatus == AssessStatus.PersonalFilling) &&
                String.IsNullOrEmpty(_View.SelectIntention))
            {
                _View.IntentionMsg = "意向必须填写";
                ret = false;
            }
            return ValideScore(ret);
        }

        public bool Validation()
        {
            _View.CommentMsg = string.Empty;
            _View.IntentionMsg = string.Empty;
            _View.Message = string.Empty;
            _View.SalaryChangeMessage = string.Empty;
            bool ret = true;
            if (String.IsNullOrEmpty(_View.Comment))
            {
                _View.CommentMsg = "总评不可以为空";
                ret = false;
            }
            if (!String.IsNullOrEmpty(_AssessActivity.Intention) &&
                (_AssessActivity.ItsAssessStatus == AssessStatus.ManagerFilling ||
                 _AssessActivity.ItsAssessStatus == AssessStatus.PersonalFilling) &&
                String.IsNullOrEmpty(_View.SelectIntention))
            {
                _View.IntentionMsg = "意向必须填写";
                ret = false;
            }
            if (!string.IsNullOrEmpty(_View.SalaryChange))
            {
                decimal d;
                if (!decimal.TryParse(_View.SalaryChange, out d))
                {
                    _View.SalaryChangeMessage = "格式错误";
                    ret = false;
                }
            }
            else if (_AssessActivity.AssessCharacterType == AssessCharacterType.ProbationII)
            {
                _View.SalaryChangeMessage = "不可为空";
                ret = false;
            }
            return ValideScore(ret);
        }

        public static decimal? ConvertToDecaiml(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }
            else
            {
                return Convert.ToDecimal(s);
            }
        }
    }
}