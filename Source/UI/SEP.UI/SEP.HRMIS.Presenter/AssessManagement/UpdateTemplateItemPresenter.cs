//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateTemplateItemPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-07-31
// 概述: 修改考评项Presenter
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public class UpdateTemplateItemPresenter
    {
        private readonly IAddTemplateItemView _View;
        private AssessTemplateItem _assessTemplateItem;
        private IAssessManagementFacade _IAssessManagementFacade = InstanceFactory.CreateAssessManagementFacade();
        private int _TemplateItemID;

        public UpdateTemplateItemPresenter(IAddTemplateItemView view)
        {
            _View = view;
        }

        public EventHandler ToTemlateItemListPageEvent;

        public void InitView(bool ispostback, string itemId)
        {
            _View.Message = "";
            _View.ItemMessage5 = "";
            _View.ItemMessage4 = "";
            _View.ItemMessage3 = "";
            _View.ItemMessage2 = "";
            _View.ItemMessage1 = "";
            _View.QestionNullMessage = "";
            _View.RangeError = "";
            _View.FormulaError = "";
            _View.PageTitle = "修改绩效考核项";
            if (!int.TryParse(itemId, out _TemplateItemID))
            {
                _View.Message = "<span class='fontred'>初始错误</span>";
                return;
            }
            _View.ReadOnly = false;
            if (!ispostback)
            {
                _View.ClassficationSource = TemplatePaperUtility.GetItemClassficationEnum();
                AssessTemplateItem item = _IAssessManagementFacade.GetTemplateItemById(_TemplateItemID);
                _View.AssessTemplateItemType = (int) item.AssessTemplateItemType;
                _View.ItemOperateType = item.ItsOperateType;
                _View.Question = item.Question;
                _View.ClassficationId = item.Classfication.ToString();
                string[] options = item.Option.Split('/');
                switch(_View.AssessTemplateItemType)
                {
                    case 0:
                        _View.Option5 = options[0];
                        _View.Option4 = options[1];
                        _View.Option3 = options[2];
                        _View.Option2 = options[3];
                        _View.Option1 = options[4];
                        break;
                    case 2:
                        _View.MinRange = options[0];
                        _View.MaxRange = options[1];
                        break;
                    case 3:
                        _View.Formula = item.Option;
                        break;
                }
                _View.Description = item.Description;
            }
        }


        public void ExectEvent(object sender, EventArgs e)
        {
            if (TemplatePaperUtility.Validate(_View))
            {
                try
                {
                    _assessTemplateItem =
                        new AssessTemplateItem(TemplateItemId, _View.Question, _View.ItemOperateType);
                    _assessTemplateItem.AssessTemplateItemType =
                        (AssessTemplateItemType) _View.AssessTemplateItemType;
                    TemplatePaperUtility.InitOperation(_View, _assessTemplateItem);
                    _assessTemplateItem.Description = _View.Description;
                    _assessTemplateItem.Classfication =
                        TemplatePaperUtility.GetChoosedItemClassfication(_View.ClassficationId);
                    _IAssessManagementFacade.UpdateAssessTemplateItem(_assessTemplateItem);
                    _View.Message = "更新绩效考核项成功";
                    ToTemlateItemListPageEvent(this, null);
                }
                catch (Exception ex)
                {
                    _View.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

        public void Cancle(object sender, EventArgs e)
        {
            ToTemlateItemListPageEvent(this, null);
        }

        public int TemplateItemId
        {
            get { return _TemplateItemID; }
            set { _TemplateItemID = value; }
        }


        //for test
        public IAssessManagementFacade GetManagement
        {
            set { _IAssessManagementFacade = value; }
        }

        public IAssessManagementFacade Update
        {
            get { return _IAssessManagementFacade; }
        }

    }
}