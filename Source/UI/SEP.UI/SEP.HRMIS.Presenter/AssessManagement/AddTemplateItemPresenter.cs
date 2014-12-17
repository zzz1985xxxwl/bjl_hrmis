//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddTemplateItemPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-06-05
// 概述: 添加考评项Presenter
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public class AddTemplateItemPresenter
    {
        private readonly IAddTemplateItemView _View;
        private IAssessManagementFacade _IAssessManagementFacade = InstanceFactory.CreateAssessManagementFacade();
        private AssessTemplateItem _assessTemplateItem;
        private int _TemplateItemID;

        public AddTemplateItemPresenter(IAddTemplateItemView view)
        {
            _View = view;
        }

        public EventHandler ToTemlateItemListPageEvent;

        public void InitView(bool ispostback)
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
            _View.ReadOnly = false;
            _View.PageTitle = "新增绩效考核项";
            if (!ispostback)
            {
                _View.ClassficationSource = TemplatePaperUtility.GetItemClassficationEnum();
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


                    _assessTemplateItem.Classfication =
                        TemplatePaperUtility.GetChoosedItemClassfication(_View.ClassficationId);
                    TemplatePaperUtility.InitOperation(_View, _assessTemplateItem);
                    _assessTemplateItem.Description = _View.Description;

                    _IAssessManagementFacade.AddAssessTemplateItem(_assessTemplateItem);
                    _View.Message = "添加绩效考核项成功";
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

        public IAssessManagementFacade InsertItem
        {
            get { return _IAssessManagementFacade; }
        }
    }
}