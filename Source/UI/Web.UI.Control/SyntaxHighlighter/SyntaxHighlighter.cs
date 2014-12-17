//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: SyntaxHighlighter.cs
// Creater:  Xue.wenlong
// Date:  2009-02-23
// Resume:
// ---------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace SyntaxHighlighter.Web.UI
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:SyntaxHighlighter runat=server></{0}:SyntaxHighlighter>")]
    public class SyntaxHighlighter : Control
    {
        private const String _cvSeperator = ":";

        private const String _cvCollapse = _cvSeperator + "collapse";

        private const String _cvNoGutter = _cvSeperator + "nogutter";

        private const String _cvNoControls = _cvSeperator + "nocontrols";

        private const String _cvFirstLine = _cvSeperator + "firstline[{0}]";

        private const String _vskLanguage = "Language";

        private const String _vskNoGutter = "NoGutter";

        private const String _vskNoControls = "NoControls";

        private const String _vskCollapse = "Collapse";

        private const String _vskFirstLine = "FirstLine";

        private const String _vskRows = "Rows";

        private const String _vskColumns = "Columns";

        private const String _vskName = "Name";

        private const String _vskScriptPath = "ScriptPath";

        private String _controlBody = String.Empty;

        private String _name;

        private String _scriptPath;

        private Boolean? _noGutter;

        private Boolean? _noControls;

        private Boolean? _collapse;

        private Int32? _firstLine;

        private Int32? _rows;

        private Int32? _columns;

        private CodeLanguage? _language;


        public string Text
        {
            get { return _controlBody; }
            set { _controlBody = value; }
        }

        //All these properties look alike. i smell abstraction
        /// <summary>
        /// 代码的语言，枚举CodeLanguage
        /// </summary>
        public CodeLanguage Language
        {
            get
            {
                if (_language == null)
                {
                    _language = new CodeLanguage?(CodeLanguage.Unknown);

                    ViewStateHelper.Get(ViewState, _vskLanguage, ref _language);
                }

                return _language.Value;
            }

            set
            {
                _language = value;

                ViewState[_vskLanguage] = value;
            }
        }

        /// <summary>
        /// 是否显示行号
        /// </summary>
        public Boolean NoGutter
        {
            get
            {
                if (_noGutter == null)
                {
                    _noGutter = new Boolean?(false);

                    ViewStateHelper.Get(ViewState, _vskNoGutter, ref _noGutter);
                }

                return _noGutter.Value;
            }

            set
            {
                _noGutter = value;

                ViewState[_vskNoGutter] = value;
            }
        }

        /// <summary>
        /// 是否在顶部显示控制器
        /// </summary>
        public Boolean NoControls
        {
            get
            {
                if (_noControls == null)
                {
                    _noControls = new Boolean?(false);

                    ViewStateHelper.Get(ViewState, _vskNoControls, ref _noControls);
                }

                return _noControls.Value;
            }

            set
            {
                _noControls = value;

                ViewState[_vskNoControls] = value;
            }
        }

        /// <summary>
        /// 是否折叠代码
        /// </summary>
        public Boolean Collapse
        {
            get
            {
                if (_collapse == null)
                {
                    _collapse = new Boolean?(false);

                    ViewStateHelper.Get(ViewState, _vskCollapse, ref _collapse);
                }

                return _collapse.Value;
            }

            set
            {
                _collapse = value;

                ViewState[_vskCollapse] = value;
            }
        }

        /// <summary>
        /// 行计数开始值。默认值是 1
        /// </summary>
        public Int32 FirstLine
        {
            get
            {
                if (_firstLine == null)
                {
                    _firstLine = new Int32?(1);

                    ViewStateHelper.Get(ViewState, _vskFirstLine, ref _firstLine);
                }

                return _firstLine.Value;
            }

            set
            {
                _firstLine = value;

                ViewState[_vskFirstLine] = value;
            }
        }

        /// <summary>
        /// 行
        /// </summary>
        public Int32 Rows
        {
            get
            {
                if (_rows == null)
                {
                    _rows = new Int32?(5);

                    ViewStateHelper.Get(ViewState, _vskRows, ref _rows);
                }

                return _rows.Value;
            }

            set
            {
                _rows = value;

                ViewState[_vskRows] = value;
            }
        }

        /// <summary>
        /// 列
        /// </summary>
        public Int32 Columns
        {
            get
            {
                if (_columns == null)
                {
                    _columns = new Int32?(10);

                    ViewStateHelper.Get(ViewState, _vskColumns, ref _columns);
                }

                return _columns.Value;
            }

            set
            {
                _columns = value;

                ViewState[_vskColumns] = value;
            }
        }

        /// <summary>
        /// 要代码修饰的textarea名称
        /// </summary>
        public String Name
        {
            get
            {
                if (_name == null)
                {
                    _name = ClientID;

                    ViewStateHelper.Get(ViewState, _vskName, ref _name);
                }

                return _name;
            }

            set
            {
                _name = value;

                ViewState[_vskName] = value;
            }
        }

        /// <summary>
        /// 脚本位置 ，默认"SyntaxHighlighter/"
        /// </summary>
        public String ScriptPath
        {
            get
            {
                if (_scriptPath == null)
                {
                    _scriptPath = "Controls/SyntaxHighlighter/";

                    ViewStateHelper.Get(ViewState, _vskScriptPath, ref _scriptPath);
                }

                return _scriptPath;
            }

            set
            {
                _scriptPath = value;

                ViewState[_vskScriptPath] = value;
            }
        }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            String url = Page.ResolveClientUrl(ScriptPath + @"Styles/SyntaxHighlighter.css");

            String link = "<link type=\"text/css\" rel=\"stylesheet\" href=\"" + url + "\"></link>";

            LiteralControl cssLink = new LiteralControl(link);

            cssLink.ID = "_cssLink";

            HtmlHead pageHead = Page.Header;

            if (pageHead.FindControl("_cssLink") == null)
            {
                pageHead.Controls.Add(cssLink);
            }
        }

        protected override void OnPreRender(EventArgs e)

        {
            base.OnPreRender(e);

            ClientScriptManager scripts = Page.ClientScript;

            CodeLanguage language = Language;

            String name = Name;

            if (!scripts.IsClientScriptIncludeRegistered("core"))
            {
                scripts.RegisterClientScriptInclude("core", Page.ResolveClientUrl(ScriptPath + "Scripts/shCore.js"));
            }

            switch (language)

            {
                case CodeLanguage.csharp:

                    if (!scripts.IsClientScriptIncludeRegistered("csharp"))
                    {
                        scripts.RegisterClientScriptInclude("csharp",
                                                            Page.ResolveClientUrl(ScriptPath +
                                                                                  "Scripts/shBrushCSharp.js"));
                    }

                    break;

                case CodeLanguage.delphi:

                    if (!scripts.IsClientScriptIncludeRegistered("delphi"))
                    {
                        scripts.RegisterClientScriptInclude("delphi",
                                                            Page.ResolveClientUrl(ScriptPath +
                                                                                  "Scripts/shBrushDelphi.js"));
                    }

                    break;

                case CodeLanguage.javascript:

                    if (!scripts.IsClientScriptIncludeRegistered("javascript"))
                    {
                        scripts.RegisterClientScriptInclude("javascript",
                                                            Page.ResolveClientUrl(ScriptPath +
                                                                                  "Scripts/shBrushJScript.js"));
                    }

                    break;

                case CodeLanguage.php:

                    if (!scripts.IsClientScriptIncludeRegistered("php"))
                    {
                        scripts.RegisterClientScriptInclude("php",
                                                            Page.ResolveClientUrl(ScriptPath + "Scripts/shBrushPhp.js"));
                    }

                    break;

                case CodeLanguage.python:

                    if (!scripts.IsClientScriptIncludeRegistered("python"))
                    {
                        scripts.RegisterClientScriptInclude("python",
                                                            Page.ResolveClientUrl(ScriptPath +
                                                                                  "Scripts/shBrushPython.js"));
                    }

                    break;

                case CodeLanguage.sql:

                    if (!scripts.IsClientScriptIncludeRegistered("sql"))
                    {
                        scripts.RegisterClientScriptInclude("sql",
                                                            Page.ResolveClientUrl(ScriptPath + "Scripts/shBrushSql.js"));
                    }

                    break;

                case CodeLanguage.vbnet:

                    if (!scripts.IsClientScriptIncludeRegistered("vb"))
                    {
                        scripts.RegisterClientScriptInclude("vb",
                                                            Page.ResolveClientUrl(ScriptPath + "Scripts/shBrushVb.js"));
                    }

                    break;

                case CodeLanguage.xml:

                    if (!scripts.IsClientScriptIncludeRegistered("xml"))
                    {
                        scripts.RegisterClientScriptInclude("xml",
                                                            Page.ResolveClientUrl(ScriptPath + "Scripts/shBrushXml.js"));
                    }

                    break;
                case CodeLanguage.css:

                    if (!scripts.IsClientScriptIncludeRegistered("css"))
                    {
                        scripts.RegisterClientScriptInclude("css",
                                                            Page.ResolveClientUrl(ScriptPath + "Scripts/shBrushCss.js"));
                    }

                    break;
                case CodeLanguage.ruby:

                    if (!scripts.IsClientScriptIncludeRegistered("ruby"))
                    {
                        scripts.RegisterClientScriptInclude("ruby",
                                                            Page.ResolveClientUrl(ScriptPath + "Scripts/shBrushRuby.js"));
                    }

                    break;
                default:
                    if (!scripts.IsClientScriptIncludeRegistered("unknown"))
                    {
                        scripts.RegisterClientScriptInclude("unknown",
                                                            Page.ResolveClientUrl(ScriptPath + "Scripts/shBrushUnknown.js"));
                    }
                    break;
            }

            String script = String.Format(
                "<script language=\"javascript\">dp.SyntaxHighlighter.HighlightAll('{0}');</script>",
                name);

            if (!scripts.IsStartupScriptRegistered(typeof (SyntaxHighlighter), "init" + name))
            {
                scripts.RegisterStartupScript(typeof (SyntaxHighlighter), "init" + name, script);
            }
        }

        /// i'll push these strings out later. this method won't last another iteration
        protected override void Render(HtmlTextWriter writer)
        {
            writer.WriteBeginTag("textarea");

            writer.WriteAttribute("name", Name);

            writer.WriteAttribute("class", BuildClassValue());

            writer.WriteAttribute("rows", Rows.ToString());

            writer.WriteAttribute("columns", Columns.ToString());

            writer.Write(HtmlTextWriter.TagRightChar);

            writer.WriteLine();

            writer.Write(_controlBody);

            writer.WriteLine();

            writer.WriteEndTag("textarea");
        }

        /// <summary>builds the class attribute value for the rendered textarea</summary>
        private String BuildClassValue()

        {
            StringBuilder builder = new StringBuilder();
            switch (Language)
            {
                case CodeLanguage.csharp:
                    builder.Append(CodeLanguage.csharp);
                    break;
                case CodeLanguage.delphi:
                    builder.Append(CodeLanguage.delphi);
                    break;
                case CodeLanguage.javascript:
                    builder.Append(CodeLanguage.javascript);
                    break;
                case CodeLanguage.php:
                    builder.Append(CodeLanguage.php);
                    break;
                case CodeLanguage.python:
                    builder.Append(CodeLanguage.python);
                    break;
                case CodeLanguage.sql:
                    builder.Append(CodeLanguage.sql);
                    break;
                case CodeLanguage.vbnet:
                    builder.Append(CodeLanguage.vbnet);
                    break;
                case CodeLanguage.xml:
                    builder.Append(CodeLanguage.xml);
                    break;
                case CodeLanguage.css:
                    builder.Append(CodeLanguage.css);
                    break;
                case CodeLanguage.ruby:
                    builder.Append(CodeLanguage.ruby);
                    break;
                default:
                    builder.Append(CodeLanguage.Unknown);
                    break;
            }

            if (NoControls)
            {
                builder.Append(_cvNoControls);
            }

            if (NoGutter)
            {
                builder.Append(_cvNoGutter);
            }

            if (Collapse)
            {
                builder.Append(_cvCollapse);
            }

            builder.AppendFormat(_cvFirstLine, FirstLine);

            return builder.ToString();
        }

        public CodeLanguage GetLanguageType(string type)
        {
            if (type.EndsWith("sql"))
            {
                return CodeLanguage.sql;
            }
            else if (type.EndsWith("cs"))
            {
                return CodeLanguage.csharp;
            }
            else if (type.EndsWith("aspx"))
            {
                return CodeLanguage.xml;
            }
            else if (type.EndsWith("css"))
            {
                return CodeLanguage.css;
            }
            else if (type.EndsWith("js"))
            {
                return CodeLanguage.javascript;
            }
            else
            {
                return CodeLanguage.Unknown;
            }
        }
    }

    #region CodeLanguage Enumeration

    public enum CodeLanguage
    {
        csharp,
        vbnet,
        delphi,
        javascript,
        php,
        python,
        sql,
        xml,
        css,
        ruby,
        Unknown
    }
   
    #endregion

    #region ViewStateHelper Class

    internal static class ViewStateHelper
    {
        internal static void Get<T>(StateBag bag, String key, ref T defaultValue)
        {
            Object o = bag[key];

            if (o != null)
            {
                defaultValue = (T) o;
            }
        }
    }

    #endregion

}