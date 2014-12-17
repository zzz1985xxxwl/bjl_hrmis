//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CardModel.cs
// Creater:  Xue.wenlong
// Date:  2009-04-10
// Resume:
// ---------------------------------------------------------------

using System;

namespace CardTable.Web.UI
{
    [Serializable]
    public class CardControl
    {
        private string _Id;
        private string _Content;
        private string _Color;
        private CardTypeControl _CardTypeControl;
        private bool _ShowDetail = true;

        public CardControl(string id, CardTypeControl cardTypeControl)
        {
            _Id = id;
            _CardTypeControl = cardTypeControl;
        }

        public CardControl(string id, string content, string color, CardTypeControl cardTypeControl)
            : this(id, cardTypeControl)
        {
            _Content = content;
            _Color = color;
        }

        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        /// <summary>
        /// 类型
        /// </summary>
        public CardTypeControl CardTypeControl
        {
            get { return _CardTypeControl; }
            set { _CardTypeControl = value; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        /// <summary>
        /// 是否显示详细内容
        /// </summary>
        public bool IsShowDetail
        {
            get { return _ShowDetail; }
            set { _ShowDetail = value; }
        }
    }

    [Serializable]
    public class CardTypeControl
    {
        private string _Name;
        private string _AjaxRequestUrl;
        private string _Params = string.Empty;

        public CardTypeControl(string name, string ajaxRequestUrl)
        {
            _Name = name;
            _AjaxRequestUrl = ajaxRequestUrl;
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string AjaxRequestUrl
        {
            get { return _AjaxRequestUrl; }
            set { _AjaxRequestUrl = value; }
        }

        /// <summary>
        ///参数 example:d=123&f=dfddf
        /// </summary>
        public string Params
        {
            get
            {
                if (string.IsNullOrEmpty(_Params))
                {
                    return string.Empty;
                }
                else
                {
                    return string.Format("{0}&", _Params);
                }
            }
            set { _Params = value; }
        }
    }
}