//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: WelcomeMail.cs
// 创建者: 倪豪
// 创建日期: 2008-12-11
// 概述: 欢迎信
// ----------------------------------------------------------------
using System;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class WelcomeMail
    {
        private int _Id;
        private string _Content;
        private bool _EnableAutoSend;

        private const string _ReplaceSymbol = "#Name#";
        private const string _MessageLackOfSymbol = @"邮件内容中需要有""#Name#""的标识来替换成用户名与密码";

        public WelcomeMail(string content,bool enableAutoSend)
        {
            Content = content;
            EnableAutoSend = enableAutoSend;
        }

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        public bool EnableAutoSend
        {
            get { return _EnableAutoSend; }
            set { _EnableAutoSend = value; }
        }

        public void VaildateTheContent()
        {
            if (!_Content.Contains(_ReplaceSymbol))
            {
                throw new ApplicationException(_MessageLackOfSymbol);
            }
        }

        public bool BuildNameAndPassword(string loginName, string password)
        {
            if(_Content.Contains(_ReplaceSymbol))
            {
               _Content = _Content.Replace(_ReplaceSymbol, BuildFor(loginName, password));
                return true;
            }
            return false;
        }

        private string BuildFor(string loginName, string password)
        {
            return string.Format("登录名：{0} 密码：{1}", loginName, password);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (WelcomeMail)) return false;
            return Equals((WelcomeMail) obj);
        }

        public bool Equals(WelcomeMail obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj._Id == _Id && Equals(obj._Content, _Content) && obj._EnableAutoSend.Equals(_EnableAutoSend);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = _Id;
                result = (result*397) ^ (_Content != null ? _Content.GetHashCode() : 0);
                result = (result*397) ^ _EnableAutoSend.GetHashCode();
                return result;
            }
        }
    }
}