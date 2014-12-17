//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: TemplageItemPresenterDetail.cs
// 创建者: 刘丹
// 创建日期: 2008-07-31
// 概述: 考评项详情Presenter
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public class TemplageItemPresenterDetail
    {
        private readonly IAddTemplateItemView _View;
        private IAssessManagementFacade _IAssessManagementFacade = InstanceFactory.CreateAssessManagementFacade();
        private int _TemplateItemID;

        public TemplageItemPresenterDetail(IAddTemplateItemView view)
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
            _View.PageTitle = "绩效考核项详情";
            if (!int.TryParse(itemId, out _TemplateItemID))
            {
                _View.Message = "<span class='fontred'>初始错误</span>";
                return;
            }
            _View.ReadOnly = true;
            if (!ispostback)
            {
                _View.ClassficationSource =AssessUtility.GetItemClassfication();
                AssessTemplateItem item = _IAssessManagementFacade.GetTemplateItemById(_TemplateItemID);
                _View.AssessTemplateItemType = (int)item.AssessTemplateItemType;
                _View.ItemOperateType = item.ItsOperateType;
                _View.Question = item.Question;
                _View.ClassficationId = item.Classfication.ToString();
                _View.Description = item.Description;
                string[] options = item.Option.Split('/');
                switch (_View.AssessTemplateItemType)
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
            ToTemlateItemListPageEvent(this, null);
        }

        public void Cancle(object sender, EventArgs e)
        {
            ToTemlateItemListPageEvent(this, null);
        }

        public int TemplateItemId
        {
            get { return _TemplateItemID; }
            set
            {
                _TemplateItemID = value;
            }
        }


        //for test
        public IAssessManagementFacade GetManagement
        {
            set { _IAssessManagementFacade = value; }
        }
    }
}
