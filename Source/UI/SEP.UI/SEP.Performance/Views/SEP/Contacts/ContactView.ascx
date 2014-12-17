<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ContactView.ascx.cs"
    Inherits="SEP.Performance.Views.SEP.Contacts.ContactView" %>
<%@ Register Src="SearchSettingView.ascx" TagName="SearchSettingView" TagPrefix="uc1" %>
<%@ Register Src="LinkmanView.ascx" TagName="LinkmanView" TagPrefix="uc2" %>
<%@ Register Src="LinkmanListView.ascx" TagName="LinkmanListView" TagPrefix="uc3" %>
	  	<div  id="floatsetting">
	  	 <div class="floatbtbg" runat="server" id="persondiv">
               <asp:LinkButton ID="Personal" runat="server" OnClick="IsCompany_Click" Text="个人联系人"></asp:LinkButton></div>
	  	<div class="floatsetbt"  runat="server" id="companydiv"><asp:LinkButton ID="Company" runat="server"  OnClick="IsCompany_Click" Text="共享联系人"></asp:LinkButton></div>
	  	</div>
<div id="tbMessage" runat="server" class="leftitbor"><asp:Label ID="lblMessage" runat="server" CssClass = "fontred"></asp:Label> </div>

<div style="text-align: left;margin-top:8px;">
    <label id="showSet" style="text-align: left; margin-left: 2px; width: 80px" class="showsetdiv"
        onclick="ShowOrHideForm('searchConditionView','showSet','hiddenSet',1)">
        设置搜索条件</label>
    <label id="hiddenSet" style="text-align: left; margin-left: 2px; width: 80px" class="hiddensetdiv"
        onclick="ShowOrHideForm('searchConditionView','showSet','hiddenSet',0)">
        隐藏搜索条件</label></div>
<div id="searchConditionView" class="hiddenformdiv" style="position: absolute; float: left;">
    <table width="300px">
        <tr>
            <td>
                <uc1:SearchSettingView ID="SearchSettingView1" runat="server" />
            </td>
        </tr>
    </table>
</div>
<div id="telephone">
    <div id="teleborder">
        <div id="telesort">
            <ul>
                <asp:Button ID="btnA" runat="server" CssClass="contactLetter" Text="A" OnClick="btnLetter_Click" />
                <asp:Button ID="btnB" runat="server" CssClass="contactLetter" Text="B" OnClick="btnLetter_Click" />
                <asp:Button ID="btnC" runat="server" CssClass="contactLetter" Text="C" OnClick="btnLetter_Click" />
                <asp:Button ID="btnD" runat="server" CssClass="contactLetter" Text="D" OnClick="btnLetter_Click" />
                <asp:Button ID="btnE" runat="server" CssClass="contactLetter" Text="E" OnClick="btnLetter_Click" />
                <asp:Button ID="btnF" runat="server" CssClass="contactLetter" Text="F" OnClick="btnLetter_Click" />
                <asp:Button ID="btnG" runat="server" CssClass="contactLetter" Text="G" OnClick="btnLetter_Click" />
                <asp:Button ID="btnH" runat="server" CssClass="contactLetter" Text="H" OnClick="btnLetter_Click" />
                <asp:Button ID="btnI" runat="server" CssClass="contactLetter" Text="I" OnClick="btnLetter_Click" />
                <asp:Button ID="btnJ" runat="server" CssClass="contactLetter" Text="J" OnClick="btnLetter_Click" />
                <asp:Button ID="btnK" runat="server" CssClass="contactLetter" Text="K" OnClick="btnLetter_Click" />
                <asp:Button ID="btnL" runat="server" CssClass="contactLetter" Text="L" OnClick="btnLetter_Click" />
                <asp:Button ID="btnM" runat="server" CssClass="contactLetter" Text="M" OnClick="btnLetter_Click" />
                <asp:Button ID="btnN" runat="server" CssClass="contactLetter" Text="N" OnClick="btnLetter_Click" />
                <asp:Button ID="btnO" runat="server" CssClass="contactLetter" Text="O" OnClick="btnLetter_Click" />
                <asp:Button ID="btnP" runat="server" CssClass="contactLetter" Text="P" OnClick="btnLetter_Click" />
                <asp:Button ID="btnQ" runat="server" CssClass="contactLetter" Text="Q" OnClick="btnLetter_Click" />
                <asp:Button ID="btnR" runat="server" CssClass="contactLetter" Text="R" OnClick="btnLetter_Click" />
                <asp:Button ID="btnS" runat="server" CssClass="contactLetter" Text="S" OnClick="btnLetter_Click" />
                <asp:Button ID="btnT" runat="server" CssClass="contactLetter" Text="T" OnClick="btnLetter_Click" />
                <asp:Button ID="btnU" runat="server" CssClass="contactLetter" Text="U" OnClick="btnLetter_Click" />
                <asp:Button ID="btnV" runat="server" CssClass="contactLetter" Text="V" OnClick="btnLetter_Click" />
                <asp:Button ID="btnW" runat="server" CssClass="contactLetter" Text="W" OnClick="btnLetter_Click" />
                <asp:Button ID="btnX" runat="server" CssClass="contactLetter" Text="X" OnClick="btnLetter_Click" />
                <asp:Button ID="btnY" runat="server" CssClass="contactLetter" Text="Y" OnClick="btnLetter_Click" />
                <asp:Button ID="btnZ" runat="server" CssClass="contactLetter" Text="Z" OnClick="btnLetter_Click" />
                <asp:Button ID="AddBtn" runat="server" CssClass="contactLetterBtn" OnClick="btnAdd_Click"
                    Text="新 增" />
            </ul>
            <div class="divclear">
            </div>
        </div>
        <div id="teletable">
            <div>
                <uc2:LinkmanView ID="LinkmanView1" runat="server" Visible="false" />
            </div>            
            <div>
                <uc3:LinkmanListView ID="LinkmanListView1" runat="server" Visible="true" />
            </div>
        </div>
    </div>
</div>
