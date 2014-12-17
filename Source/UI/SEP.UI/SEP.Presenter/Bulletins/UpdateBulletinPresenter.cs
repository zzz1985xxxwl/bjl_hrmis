//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ManageBulletinPresenter.cs
// 创建者: 薛文龙
// 创建日期: 2008-06-05
// 概述: 增加ManageBulletinPresenter
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
    public class UpdateBulletinPresenter : BasePresenter
    {
        //public bool _Validition = true;
        private readonly IEditBulletinView _View;
        private DateTime _PublishTime;
        private IBulletinBll _BulletinBll = BllInstance.BulletinBllInstance;
        private readonly IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        public EventHandler _UpdateCustomerCompleteEvent;

        public UpdateBulletinPresenter(IEditBulletinView view, Account loginUser)
            : base(loginUser)
        {
            _View = view;
            AttachViewEvent();
        }

        private void AttachViewEvent()
        {
            _View.btnOKClicked += btnOKClick;
            _View.DeleteAppendix += btnDeleteAppendix;
            _View.AddAppendix += btnAddAppendix;
            _View.InitView += Init;
        }

        #region 测试用

        public IBulletinBll MockGetBulletin
        {
            set { _BulletinBll = value; }
        }

        #endregion

        public void Init(object sender, EventArgs e)
        {
            GetData();
            SetBulletinAttribute();
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
                Bulletin bulletin = new Bulletin(_View.BulletinID, _View.Title,
                                                 _View.Content, _PublishTime);
                bulletin.Dept = new Department(_View.DepartmentId, "");
                _BulletinBll.UpdateBulletin(bulletin, LoginUser);
                _UpdateCustomerCompleteEvent(this, null);
            }
            catch (ApplicationException ex)
            {
                _View.ErrorMessageFromBll = ex.Message;
            }
        }

        public void btnDeleteAppendix(object sender, EventArgs e)
        {
            _View.ErrorMessageFromBll = "";
            try
            {
                _BulletinBll.DeleteAppendix(FindID(), LoginUser);
                if (File.Exists(_View.Directory))
                {
                    File.Delete(_View.Directory);
                }
                ReBindAppendix();
            }
            catch (ApplicationException ex)
            {
                _View.ErrorMessageFromBll = ex.Message;
            }
        }

        public void btnAddAppendix(object sender, EventArgs e)
        {
            _View.ErrorMessageFromBll = "";
            try
            {
                Appendix appendix = new Appendix(0, _View.BulletinID, _View.ATitle, _View.Directory);
                _BulletinBll.CreateAppendix(appendix, null);
                ReBindAppendix();
            }
            catch (ApplicationException ex)
            {
                _View.ErrorMessageFromBll = ex.Message;
            }
        }

        /// <summary>
        /// 初始化界面信息
        /// </summary>
        public void SetBulletinAttribute()
        {
            Bulletin bulletin = _BulletinBll.GetBulletinByBulletinID(_View.BulletinID, LoginUser);
            _View.Title = bulletin.Title;
            _View.PublishTime = bulletin.PublishTime.ToString();
            _View.Content = bulletin.Content;
            _View.AppendixList = bulletin.AppendixList;
            _View.DepartmentId = bulletin.Dept.Id;
            FindAppendixInDirectory();
        }

        private void FindAppendixInDirectory()
        {
            _View.lblAppendixListMessage = "";
            if (_View.AppendixList != null)
            {
                string message = "文件";
                foreach (Appendix appendix in _View.AppendixList)
                {
                    if (!File.Exists(appendix.Directory))
                    {
                        message += appendix.Title + ";";
                    }
                }
                message += "未能找到";
                if (message.Length > 6)
                {
                    _View.lblAppendixListMessage = message;
                }
            }
        }

        public bool Valid()
        {
            if (string.IsNullOrEmpty(_View.Title))
            {
                _View.lblBulletinTitleMessage = "公告标题不能为空";
                return false;
            }
            if (_View.Title.Length > 50)
            {
                _View.lblBulletinTitleMessage = "公告标题不能超过50个字符";
                return false;
            }
            if (string.IsNullOrEmpty(_View.PublishTime))
            {
                _View.lblPublishTimeMessage = "请输入发布日期";
                return false;
            }
            if (!DateTime.TryParse(_View.PublishTime, out _PublishTime))
            {
                _View.lblPublishTimeMessage = "日期格式不正确";
                return false;
            }
            return true;
        }

        public int FindID()
        {
            if (_View.AppendixList.Count > 0)
            {
                Appendix appendix;
                if ((appendix = _View.AppendixList.Find(MatchTitle)) != null)
                {
                    return appendix.AppendixID;
                }
            }
            return -1;
        }

        private bool MatchTitle(Appendix appendix)
        {
            return appendix.Title == _View.ATitle;
        }

        public void ReBindAppendix()
        {
            _View.AppendixList = _BulletinBll.GetAppendixByBulletinID(_View.BulletinID, LoginUser);
            FindAppendixInDirectory();
        }

        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void GetData()
        {
            List<Department> deptList = _IDepartmentBll.GetAllDepartment();
            _View.DepartmentSource =
                Tools.RemoteUnAuthDeparetment(deptList, AuthType.SEP, LoginUser, Powers.A302);
        }
    }
}