//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: AddBulletinPresenter.cs
// 创建者: colbert
// 创建日期: 2009-02-22
// 概述: 增加公告
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using SEP.IBll;
using SEP.IBll.Bulletins;
using SEP.IBll.Departments;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Bulletins;
using SEP.Model.Departments;
using SEP.Model.Utility;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IBulletins;

namespace SEP.Presenter.Bulletins
{
    public class AddBulletinPresenter : BasePresenter
    {
        private DateTime _PublishTime;
        private readonly IEditBulletinView _View;
        public EventHandler _AddBulletinCompleteEvent;
        private readonly IBulletinBll _IBulletinBll = BllInstance.BulletinBllInstance;
        private readonly IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;

        public AddBulletinPresenter(IEditBulletinView view, Account loginUser)
            : base(loginUser)
        {
            _View = view;
            AttachViewEvent();
            InitMessage();
        }

        private void InitMessage()
        {
            _View.lblBulletinTitleMessage = String.Empty;
            _View.lblPublishTimeMessage = String.Empty;
        }

        private void AttachViewEvent()
        {
            _View.btnOKClicked += btnOKClick;
            _View.DeleteAppendix += btnDeleteAppendix;
            _View.AddAppendix += btnAddAppendix;
            _View.InitView += Init;
        }

        public bool Valid()
        {
            bool valid = true;
            if (string.IsNullOrEmpty(_View.Title))
            {
                _View.lblBulletinTitleMessage = "公告标题不能为空";
                valid = false;
            }
            if (_View.Title.Length > 50)
            {
                _View.lblBulletinTitleMessage = "公告标题不能超过50个字符";
                valid = false;
            }
            if (string.IsNullOrEmpty(_View.PublishTime))
            {
                _View.lblPublishTimeMessage = "请输入发布日期";
                valid = false;
            }
            else if (!DateTime.TryParse(_View.PublishTime, out _PublishTime))
            {
                _View.lblPublishTimeMessage = "日期格式不正确";
                valid = false;
            }
            return valid;
        }

        public void btnOKClick(object sender, EventArgs e)
        {
            _View.ErrorMessageFromBll = "";
            if (!Valid())
            {
                return;
            }
            try
            {
                Bulletin bulletin = new Bulletin(0, _View.Title, _View.Content, _PublishTime);
                bulletin.Dept=new Department(_View.DepartmentId,"");
                bulletin.AppendixList = _View.AppendixList;
                _IBulletinBll.CreateBulletin(bulletin, LoginUser);
                _AddBulletinCompleteEvent(this, EventArgs.Empty);
            }
            catch (ApplicationException ex)
            {
                _View.ErrorMessageFromBll = ex.Message;
            }
        }

        public void Init(object sender, EventArgs e)
        {
            _View.AppendixList = new List<Appendix>();
            if (string.IsNullOrEmpty(_View.PublishTime))
            {
                _View.PublishTime = DateTime.Now.ToString();
            }
            GetData();
        }

        public void btnDeleteAppendix(object sender, EventArgs e)
        {
            _View.AppendixList.RemoveAll(MatchTitle);
            File.Delete(_View.Directory);
        }

        public void btnAddAppendix(object sender, EventArgs e)
        {
            if (!_View.AppendixList.Exists(MatchTitle))
            {
                Appendix appendix = new Appendix(0, 0, _View.ATitle, _View.Directory);
                _View.AppendixList.Add(appendix);
            }
        }

        private bool MatchTitle(Appendix appendix)
        {
            if (appendix.Title == _View.ATitle)
            {
                return true;
            }
            return false;
        }

        private void GetData()
        {
            List<Department> deptList = _IDepartmentBll.GetAllDepartment();
            _View.DepartmentSource =
                Tools.RemoteUnAuthDeparetment(deptList, AuthType.SEP, LoginUser, Powers.A302);
        }

        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}