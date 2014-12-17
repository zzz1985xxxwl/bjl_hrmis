<%@ Import namespace="SEP.Performance"%>
<%@ Import namespace="ShiXin.Security"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SystemErrorListView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.SystemErrors.SystemErrorListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>

<div class="nolinetablediv">
<table width="100%"><tr><td style=" width:2%;"></td><td style=" width:98%;" align="left"><asp:CheckBox ID="cbShowIgnore" runat="server" Text="显示忽略" AutoPostBack="true" OnCheckedChanged="cbShowIgnore_CheckedChanged" /></td></tr></table>
<asp:GridView ID="gvSystemError" runat="server" Width="100%" AutoGenerateColumns="False"  AllowPaging="true" 
OnPageIndexChanging="gvSystemError_PageIndexChanging"   ShowHeader="false" GridLines="None"   OnRowDataBound="gvSystemError_RowDataBound">
<HeaderStyle Height="28px" CssClass="headerstyleblue"/>
<RowStyle Height = "28px" CssClass="GridViewRowLink" HorizontalAlign="Left"/>
<AlternatingRowStyle CssClass="table_g" />
        <Columns>  
            <asp:TemplateField><ItemTemplate ><asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("PKID") %>' CommandName="HiddenPostButtonCommand" runat="server" Text="" style=" display:none;"/></ItemTemplate>
                <ItemStyle Width="2%" VerticalAlign="Middle" />
            </asp:TemplateField>                                                           
           <asp:TemplateField >
                <ItemTemplate>
                    <%#Eval("Description")%>
                </ItemTemplate>
                <ItemStyle Width="78%" />
            </asp:TemplateField>   
            <asp:TemplateField >
                <ItemTemplate>
                     <a onclick='window.open("<%#Eval("EditUrl")%>")' href="#">更正</a>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField> 
            <asp:TemplateField >
                <ItemTemplate>
                    <asp:LinkButton ID="lbIgnore" runat="server" Text='<%#Eval("ErrorStatus.ID").ToString() =="1"?"显示":"忽略"%>' CommandArgument='<%#Eval("MarkID")%>' CommandName='<%#Eval("ErrorType.ID")%>' OnCommand="lbIgnore_Click"/>
                </ItemTemplate>
                <ItemStyle Width="10%" />
            </asp:TemplateField>               
        </Columns>
        <PagerTemplate>
                        <uc1:PageTemplate ID="PageTemplate1" runat="server" />                   
        </PagerTemplate>   
</asp:GridView>
</div>

