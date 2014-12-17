<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VacationInfoListView.ascx.cs"
            Inherits="SEP.Performance.VacationInfoListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc2" %>
<%@ Register Src="ManageVacationView.ascx" TagName="ManageVacationView" TagPrefix="uc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <contenttemplate>
        <asp:Label ID="lbIsAdd" runat="server" Text="true"  Visible="False" Enabled="False"></asp:Label>
        <ajaxToolKit:ModalPopupExtender id="mpeEdit" runat="server"  BackgroundCssClass="modalBackground" PopupControlID="pnlEdit" 
                                        TargetControlID="btnHidden"></ajaxToolKit:ModalPopupExtender>
        <asp:Button ID="btnHidden" runat="Server" Style="display: none" />
        <div id="divMPEReimburse" > 
            <asp:Panel ID="pnlEdit" runat="server" CssClass="modalBox" Style="display: none" Width="670px">
                <div style="white-space: nowrap; text-align: center;">
                    <div class="leftitbor2" >
                        年假 
                    </div>
                    <uc1:ManageVacationView ID="ManageVacationView1" runat="server" /> 
                    <div class="tablebt">  
                        <asp:Button ID="btnOK" runat="server" Text="确  定" OnClick="btnOK_Click" CssClass="inputbt" />
                        <asp:Button ID="btnCancel" runat="server" Text="取  消"   OnClientClick=" return CloseModalPopupExtender('divMPEReimburse'); "  CssClass="inputbt"  />
                    </div>
                </div>
            </asp:Panel> 
        </div> 
        <div style="text-align: left; margin-left: 8px;"><span class="font14px">年假信息 &nbsp; &nbsp; &nbsp;</span><asp:LinkButton ID="btnAdd" runat="server" Text="新增年假" OnClick="BtnAdd_Click" /></div>

        <div id="tbVacationList"  runat="server" class="linetablediv"  style="margin-top: 0px;">
            <asp:GridView ID="gdVacationList" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="10"
                          GridLines="None" Width="100%" OnPageIndexChanging="gdVacationList_PageIndexChanging" OnRowDataBound="gdVacationList_RowDataBound" >
                <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
                <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
                <AlternatingRowStyle CssClass="table_g" />
                <Columns>
                    <asp:TemplateField >
                        <ItemTemplate>
                            <asp:Button ID="btnHiddenPostButton"  CommandName="HiddenPostButtonCommand" runat="server" Text="" style="display: none;"/>
                        </ItemTemplate>  
                        <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="HashCode" HeaderText="Id" Visible="false" >
                        <ItemStyle Width="0%" />
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="年假起始日"  HeaderStyle-Width="12%">
                        <ItemTemplate>
                            <%#Eval("VacationStartDate", "{0:yyyy-MM-dd}") %>
                        </ItemTemplate> 
                    </asp:TemplateField>   
                    <asp:TemplateField HeaderText="年假到期日"  HeaderStyle-Width="12%">
                        <ItemTemplate>
                            <%#Eval("VacationEndDate", "{0:yyyy-MM-dd}") %>
                        </ItemTemplate> 
                    </asp:TemplateField>  
                    <asp:BoundField DataField="VacationDayNum" HeaderText="年假总天数" >
                        <ItemStyle />
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>  
                    <asp:BoundField DataField="UsedDayNum" HeaderText="已用天数 " >
                        <ItemStyle  />
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SurplusDayNum" HeaderText="剩余天数" >
                        <ItemStyle  />
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>   
                        
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnUpdate" runat="server" CommandArgument='<%# Eval("HashCode") %>' 
                                            CommandName="BtnUpdateClick" OnCommand="BtnUpdate_Click" Text="修    改" ></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="7%" HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("HashCode") %>'
                                            CommandName="BtnDeleteClick" OnCommand="BtnDelete_Click" Text="删    除"  OnClientClick= " Confirmed = confirm('确定要删除吗？'); return Confirmed; "></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                    </asp:TemplateField>
                                 
                </Columns>          
                <PagerTemplate>
                    <%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>        --%>     
                    <uc2:PageTemplate ID="PageTemplate1" runat="server" />		             
                </PagerTemplate>
             
             
            </asp:GridView>
        </div>
    </contenttemplate>
</asp:UpdatePanel>