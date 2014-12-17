//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: TemplatePaperListPresenter.cs
// 创建者: 张珍
// 创建日期: 2008-06-16
// 概述: TemplatePaperList的Presenter
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;
using SEP.Presenter.Core;


namespace SEP.HRMIS.Presenter
{
    public class TemplatePaperListPresenter : BasePresenter
    {
        private IAssessManagementFacade _IFacade;
        private readonly ITemplatePaperListView _ItsView;

        /// <summary>
        /// 复制事件
        /// </summary>
        private void btnCopyClick(string strAssessPaperId)
        {
            int assessPaperId;
            if (!int.TryParse(strAssessPaperId, out assessPaperId))
            {
                return;
            }
            _ItsView.SessionCopyPaper = _IFacade.GetAssessTempletPaperById(assessPaperId);
        }

        private void TemplatePaperDataBind()
        {
            List<AssessTemplatePaper> itsSource = _IFacade.GetTemplatePapersByPaperName(_ItsView.TemplatePaperName);
            _ItsView.AssessTemplatePapers = itsSource;
        }

        public event DelegateNoParameter btnAddClick;
        public event DelegateID btnUpdateClick;
        public event DelegateID btnDeleteClick;
        public event DelegateID btnDetailClick;

        public TemplatePaperListPresenter(ITemplatePaperListView itsView, Account loginUser)
            : base(loginUser)
        {
            _ItsView = itsView;
        }

        public TemplatePaperListPresenter(ITemplatePaperListView itsView, Account loginUser, IAssessManagementFacade iFacade)
            : this(itsView, loginUser)
        {
            _IFacade = iFacade;
        }

        public override void Initialize(bool isPostBack)
        {
            _ItsView.BtnAddEvent += btnAddClick;
            _ItsView.BtnUpdateEvent += btnUpdateClick;
            _ItsView.BtnDeleteEvent += btnDeleteClick;
            _ItsView.BtnDetailEvent += btnDetailClick;
            _ItsView.BtnCopyEvent += btnCopyClick;
            _ItsView.BtnSearchEvent += TemplatePaperDataBind;

            _ItsView.ImportEvent += ImportPapers;

            _IFacade = InstanceFactory.CreateAssessManagementFacade();
            if (!isPostBack)
            {
                TemplatePaperDataBind();
            }
        }

        private void ImportPapers(string filePath)
        {
            try
            {
                string ret = InstanceFactory.CreateAssessManagementFacade().ImportTemplatePaper(filePath);
                TemplatePaperDataBind();
                _ItsView.Message = "<span class='fontred'>" + ret + "</span>";
            }
            catch (Exception e)
            {
                _ItsView.Message = "<span class='fontred'>" + e.Message + "</span>";
            }
        }
    }
}


