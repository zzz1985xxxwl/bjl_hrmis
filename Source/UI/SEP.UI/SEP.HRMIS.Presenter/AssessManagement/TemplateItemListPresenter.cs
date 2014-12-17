//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: TemplateItemListPresenter.cs
// 创建者: 刘丹
// 创建日期: 2008-06-16
// 概述: 考评项显示Presenter
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public class TemplateItemListPresenter
    {
        private IAssessManagementFacade _IAssessManagementFacade = InstanceFactory.CreateAssessManagementFacade();
        private readonly ITemplateItemListView _View;
        public EventHandler _ToTemplateItemAddPage;

        public void InitViewList(bool ispostbacek)
        {
            if (!ispostbacek)
            {
                GetData();
            }
            _View.DelMessage = "";
        }

        public TemplateItemListPresenter(ITemplateItemListView view)
        {
            _View = view;
        }

        public void ExecuteEvent(object sender, EventArgs e)
        {
            try
            {
                ItemClassficationEmnu itemClassfication = AssessUtility.GetChoosedItemClassfication(_View.ItemClassfication);
                _View.TemplateItems = _IAssessManagementFacade.GetTemplateItemsByConditon(_View.Question, _View.OperateType, itemClassfication,_View.SelectedAssessTemplateItemType);
                _View.Message =
                      "<span class='font14b'>共查到 </span>"
                      + "<span class='fontred'>" + _View.TemplateItems.Count + "</span>"
                      + "<span class='font14b'> 个绩效考核项</span>";
            }
            catch (Exception ex)
            {
                _View.Message = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        public void DeleteEvent(object sender, CommandEventArgs e)
        {
            int itemId;
            if (!int.TryParse(e.CommandArgument.ToString(), out itemId))
            {
                _View.DelMessage = "绩效考核项编号不存在";
                return;
            }
            try
            {
                _IAssessManagementFacade.DeleteAssessTemplateItem(itemId);
                ExecuteEvent(null, null);
            }
            catch (Exception ex)
            {
                _View.DelMessage = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        private void GetData()
        {
            _View.ItemClassficationSource = AssessUtility.GetItemClassfication();
        }


        #region test
        public IAssessManagementFacade Management
        {
            set { _IAssessManagementFacade = value; }
        }
        #endregion
    }
}
