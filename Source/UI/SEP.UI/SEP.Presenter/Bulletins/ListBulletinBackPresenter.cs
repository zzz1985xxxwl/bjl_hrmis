//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ListBulletinBackPresenter.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-18
// 概述: 增加ListBulletinBackPresenter
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using SEP.IBll;
using SEP.IBll.Bulletins;
using SEP.IBll.Departments;
using SEP.Model;
using SEP.Model.Bulletins;
using SEP.Model.Departments;
using SEP.Model.Utility;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IBulletins;
using SEP.Model.Accounts;

namespace SEP.Presenter.Bulletins
{
    public class ListBulletinBackPresenter : BasePresenter
    {
        private readonly IListBulletinBackView _View;
        private DateTime _PublishStartTime;
        private DateTime _PublishEndTime;
        private bool _Validation = true;
        private readonly IBulletinBll _BulletinBll = BllInstance.BulletinBllInstance;
        private readonly IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;

        public ListBulletinBackPresenter(IListBulletinBackView view,bool ispostback, Account loginUser)
            : base(loginUser)
        {
            _View = view;
            AttachViewEvent();
            if(!ispostback)
            {
                GetData();
            }
        }

        private void AttachViewEvent()
        {
            _View.btnSearchClicked += SearchBulletin;
            _View.DeleteBulletin += DeleteBulletin;
        }

        public void SearchBulletin(object sender, EventArgs e)
        {
            Valid();
            if (_Validation)
            {
                _View.BulletinList =
                    _BulletinBll.GetBulletinByCondition(_View.Title, _PublishStartTime, _PublishEndTime,_View.DepartmentId, LoginUser);
            }
        }

        public void DeleteBulletin(object sender, EventArgs e)
        {
            _View.Message = "";
            try
            {
                foreach (Appendix appendix in _BulletinBll.GetAppendixByBulletinID(_View.BulletinID, LoginUser))
                {
                    if (File.Exists(appendix.Directory))
                    {
                        File.Delete(appendix.Directory);
                    }
                }
                _BulletinBll.DeleteBulletin(_View.BulletinID, LoginUser);
                SearchBulletin(null, EventArgs.Empty);
            }
            catch (ApplicationException ex)
            {
                _View.Message = ex.Message;
            }
        }


        private void Valid()
        {
            _View.Message = "";
            if (String.IsNullOrEmpty(_View.PublishStartTime))
            {
                _PublishStartTime = Convert.ToDateTime("1900-1-1");
            }
            else if (!DateTime.TryParse(_View.PublishStartTime, out _PublishStartTime))
            {
                _Validation = false;
                _View.Message = "日期格式不正确";
            }
            if (String.IsNullOrEmpty(_View.PublishEndTime))
            {
                _PublishEndTime = Convert.ToDateTime("2999-12-31");
            }
            else if (!DateTime.TryParse(_View.PublishEndTime, out _PublishEndTime) &&
                     !string.IsNullOrEmpty(_View.PublishEndTime))
            {
                _Validation = false;
                _View.Message = "日期格式不正确";
            }
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