//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: TemplatePaperUpdatePresenter.cs
// ������: ����
// ��������: 2008-06-16
// ����: TemplatePaperUpdate��Presenter
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.AssessManagement;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public class TemplatePaperUpdatePresenter : BasePresenter
    {
        private readonly int _TemplatePaperId;
        private readonly ITemplatePaperView _ITemplatePaperView;
        private readonly IAssessManagementFacade _IAssessManagementFacade;

        public bool Validation()
        {
            _ITemplatePaperView.ValidatePaperName = "";

            if (string.IsNullOrEmpty(_ITemplatePaperView.TemplatePaperName))
            {
                _ITemplatePaperView.ValidatePaperName = "��Ч���˱�����Ʋ���Ϊ��";
                return false;
            }
            if (_ITemplatePaperView.TemplatePaperName.Length > 50)
            {
                _ITemplatePaperView.ValidatePaperName = "��Ч���˱����ֲ��ܳ���50���ַ�";
                return false;
            }
            foreach (AssessTemplateItem item in _ITemplatePaperView.AssessItemList)
            {
                decimal temp;
                if (string.IsNullOrEmpty(item.WeightString))
                {
                    _ITemplatePaperView.ResultMessage = "Ȩ�ز���Ϊ��";
                    return false;
                }
                else if (!Decimal.TryParse(item.WeightString, out temp))
                {
                    _ITemplatePaperView.ResultMessage = "Ȩ�ظ�ʽ����";
                    return false;
                }
            }
            return true;
        }

        private void UpdateEvent()
        {
            if (!Validation())
                return;

            try
            {
                List<AssessTemplateItem> items = new List<AssessTemplateItem>();
                for (int i = 0; i < _ITemplatePaperView.AssessItemList.Count; i++)
                {
                    if (_ITemplatePaperView.AssessItemList[i].AssessTemplateItemID != -1)
                    {
                        _ITemplatePaperView.AssessItemList[i].Weight =
                            Convert.ToDecimal(_ITemplatePaperView.AssessItemList[i].WeightString);
                        items.Add(_ITemplatePaperView.AssessItemList[i]);
                    }
                }
                AssessTemplatePaper _Paper = new AssessTemplatePaper(_TemplatePaperId, _ITemplatePaperView.TemplatePaperName, items);
                _Paper.PositionList = _ITemplatePaperView.PositionList;
                _IAssessManagementFacade.UpdateAssessTemplatePaper(_Paper);
                _ITemplatePaperView.ActionSuccess = true;
                ToAccountSetListPage();
            }
            catch (Exception ex)
            {
                _ITemplatePaperView.ResultMessage = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }


        public TemplatePaperUpdatePresenter(int paperId, ITemplatePaperView view, Account loginUser)
            : base(loginUser)
        {
            _ITemplatePaperView = view;
            _TemplatePaperId = paperId;
            _IAssessManagementFacade = InstanceFactory.CreateAssessManagementFacade();
        }

        public TemplatePaperUpdatePresenter(int paperId, ITemplatePaperView view, Account loginUser, IAssessManagementFacade iFacade)
            : base(loginUser)
        {
            _ITemplatePaperView = view;
            _TemplatePaperId = paperId;
            _IAssessManagementFacade = iFacade;
        }

        public event DelegateNoParameter CancelEvent;
        public event DelegateNoParameter ToAccountSetListPage;

        public override void Initialize(bool isPostBack)
        {
            _ITemplatePaperView.ResultMessage = string.Empty;
            _ITemplatePaperView.ValidatePaperName = string.Empty;
            _ITemplatePaperView.AssessItems = _IAssessManagementFacade.GetAllTemplateItems();

            _ITemplatePaperView.ActionButtonEvent += UpdateEvent;

            TemplageItemEditor itemEditor = new TemplageItemEditor(_ITemplatePaperView);
            _ITemplatePaperView.btnCopyEvent += itemEditor.btnCopyEvent;
            _ITemplatePaperView.btnPasteEvent += itemEditor.btnPasteEvent;
            _ITemplatePaperView.CancelButtonEvent += CancelEvent;
            _ITemplatePaperView.ddlAssessItemChangedForAddEvent += itemEditor.ddlChangedForAddEvent;
            _ITemplatePaperView.ddlAssessItemChangedForUpdateEvent += itemEditor.ddlChangedForUpdateEvent;
            _ITemplatePaperView.ddlAssessItemChangedForDeleteEvent += itemEditor.ddlChangedForDeleteEvent;
            _ITemplatePaperView.ddlAssessItemChangedForAddAtEvent += itemEditor.ddlAssessItemChangedForAddAtEvent;
            _ITemplatePaperView.ddlAssessItemChangedForUpEvent += itemEditor.ddlAssessItemChangedForUpEvent;
            _ITemplatePaperView.ddlAssessItemChangedForDownEvent += itemEditor.ddlAssessItemChangedForDownEvent;

            if (!isPostBack)
            {
                _ITemplatePaperView.OperationInfo = "�޸ļ�Ч���˱�";
                _ITemplatePaperView.OperationType = "Update";

                AssessTemplatePaper paper = _IAssessManagementFacade.GetTempletPaperAndItemById(_TemplatePaperId);
                _ITemplatePaperView.PositionList = paper.PositionList;
                _ITemplatePaperView.TemplatePaperName = paper.PaperName;
                paper.ItsAssessTemplateItems.Add(new AssessTemplateItem(-1, "", OperateType.NotHR));
                _ITemplatePaperView.AssessItemList = paper.ItsAssessTemplateItems;
            }

            _ITemplatePaperView.SetbtnPasteVisible = _ITemplatePaperView.SessionCopyPaper != null;
        }
    }
}
