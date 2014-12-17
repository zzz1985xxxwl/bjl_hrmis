//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: Auth.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 权限
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.Model.Departments;

namespace SEP.Model.Accounts
{
    [Serializable]
    public class  Auth
    {
        #region
        
        private int _Id;
        private string _Name;
        private string _NavigateUrl;
        private AuthType _Type;
        private bool _IfHasDepartment;
        private List<Auth> _ChildAuths;
        private List<Department> _Departments;

        public Auth()
        {
            _ChildAuths = new List<Auth>();
            _Departments = new List<Department>();
        }

        public Auth(int id, string name)
            : this()
        {
            _Id = id;
            _Name = name;
        }

        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public string NavigateUrl
        {
            get
            {
                return _NavigateUrl;
            }
            set
            {
                _NavigateUrl = value;
            }
        }

        public AuthType Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
            }
        }

        /// <summary>
        /// 该权限是否有部门范围
        /// </summary>
        public bool IfHasDepartment
        {
            get
            {
                return _IfHasDepartment;
            }
            set
            {
                _IfHasDepartment = value;
            }
        }

        public List<Auth> ChildAuths
        {
            get
            {
                return _ChildAuths;
            }
            set
            {
                _ChildAuths = value;
            }
        }

        public List<Department> Departments
        {
            get
            {
                return _Departments;
            }
            set
            {
                _Departments = value;
            }
        }

        #endregion

        internal Auth FindAuth(int id)
        {
            if (id == _Id)
                return this;

            foreach (Auth auth in _ChildAuths)
            {
                Auth temp = auth.FindAuth(id);
                if(temp != null)
                    return temp;
            }

            return null;
        }

        internal bool IsExistAuth(int authId)
        {
            if (_Id == authId)
                return true;

            foreach (Auth auth in _ChildAuths)
            {
                if(auth.IsExistAuth(authId))
                    return true;
            }
            return false;
        }
    }

    public enum AuthType
    {
        SEP,
        HRMIS,
        CRM,
        MYCMMI,
        EShopping
    }
}
