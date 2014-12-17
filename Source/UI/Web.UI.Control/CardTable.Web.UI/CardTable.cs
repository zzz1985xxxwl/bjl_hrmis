//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CardTable.cs
// Creater:  Xue.wenlong
// Date:  2009-02-23
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;

[assembly : WebResource("CardTable.Web.UI.DragCard.js", "text/javascript")]
[assembly : WebResource("CardTable.Web.UI.DragCardStyle.css", "text/css")]
[assembly : WebResource("CardTable.Web.UI.spinner.gif", "image/gif")]

namespace CardTable.Web.UI
{
    [ToolboxData("<{0}:CardTable runat=server></{0}:CardTable>")]
    public class CardTable : Control
    {
        private List<CardControl> _CardList;
        private List<CardTypeControl> _CardTypeList;
        private const string _vskCardList = "cardList";
        private const string _vskCardTypeList = "cardTypeList";

        public List<CardControl> CardList
        {
            get
            {
                if (_CardList == null)
                {
                    _CardList = new List<CardControl>();

                    ViewStateHelper.Get(ViewState, _vskCardList, ref _CardList);
                }
                return _CardList;
            }

            set
            {
                _CardList = value;

                ViewState[_vskCardList] = value;
            }
        }


        public List<CardTypeControl> CardTypeList
        {
            get
            {
                if (_CardTypeList == null)
                {
                    _CardTypeList = new List<CardTypeControl>();

                    ViewStateHelper.Get(ViewState, _vskCardTypeList, ref _CardTypeList);
                }
                return _CardTypeList;
            }

            set
            {
                _CardTypeList = value;

                ViewState[_vskCardTypeList] = value;
            }
        }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            AddCssLink();
        }

        private void AddCssLink()
        {
            string cssRef = Page.ClientScript.GetWebResourceUrl(GetType(), "CardTable.Web.UI.DragCardStyle.css");
            HtmlLink link = new HtmlLink();
            link.Href = cssRef;
            link.Attributes.Add("type", "text/css");
            link.Attributes.Add("rel", "stylesheet");
            Page.Header.Controls.Add(link);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Page.ClientScript.RegisterClientScriptResource(GetType(), "CardTable.Web.UI.DragCard.js");
        }

        private void RenderBody(TextWriter writer)
        {
            if (CardTypeList != null && CardTypeList.Count > 0)
            {
                writer.Write("<tr class='pool-head'>");
                foreach (CardTypeControl type in _CardTypeList)
                {
                    string str =
                        string.Format(
                            "<th><span class='group'>{0}<span class='lane-card-number'>({1})</span></span></th>",
                            type.Name, CountCard(type.Name));
                    writer.Write(str);
                }
                writer.Write("</tr>");

                writer.Write("<tr class='sortable-continor'>");
                foreach (CardTypeControl type in _CardTypeList)
                {
                    writer.Write(string.Format("<td  class='cards-container' url='{0}'>", type.AjaxRequestUrl));
                    foreach (CardControl card in CardList)
                    {
                        if (card.CardTypeControl.Name == type.Name)
                        {
                            RenderCard(writer, card);
                        }
                    }
                    writer.Write("</td> ");
                }
                writer.Write("</tr>");
            }
        }

        private int CountCard(string typename)
        {
            int itemCount = 0;
            foreach (CardControl card in CardList)
            {
                if (card.CardTypeControl.Name == typename)
                {
                    itemCount++;
                }
            }
            return itemCount;
        }

        private void RenderCard(TextWriter writer, CardControl cardControl)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<div class='card-icon draggable' id='card_{0}' CardID='{0}'>", cardControl.Id);
            if (cardControl.IsShowDetail)
            {
                sb.AppendFormat(
                    "<div class='card-inner-wrapper' style='border-left: solid 6px {0}' >", cardControl.Color);
            }
            else
            {
                sb.AppendFormat("<div class='card-inner-wrapper' style='border-left: solid 6px {0}'>", cardControl.Color);
            }
            sb.AppendFormat(
                "<img alt=''id='card_{0}_spinner' src='{1}' class='spinner' style='display: none; position: absolute; float:left' />",
                cardControl.Id, Page.ClientScript.GetWebResourceUrl(GetType(), "CardTable.Web.UI.spinner.gif"));
            sb.AppendFormat("<span class='card-summary-number'>#{0}</span>", cardControl.Id);
            sb.Append(cardControl.Content);
            sb.Append("</div></div>");
            writer.Write(sb.ToString());
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<table class='pool-table'>");
            RenderBody(writer);
            writer.Write("</table>");
        }
    }

    #region ViewStateHelper Class

    internal static class ViewStateHelper
    {
        internal static void Get<T>(StateBag bag, String key, ref T defaultValue)
        {
            Object obj = bag[key];

            if (obj != null)
            {
                defaultValue = (T) obj;
            }
        }
    }

    #endregion
}