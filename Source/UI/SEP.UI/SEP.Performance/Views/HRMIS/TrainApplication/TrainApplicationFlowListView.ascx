<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrainApplicationFlowListView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.TrainApplication.TrainApplicationFlowListView" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<div id="divTrainApplicationFlowList" runat="server">
            <div class="linetablediv">
                            <asp:GridView ID="grdTrainApplicationFlowList" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" GridLines="None" 
                            OnPageIndexChanging="grdTrainApplicationFlowList_PageIndexChanging" Width="100%" 
                                OnRowDataBound="grdTrainApplicationFlowList_RowDataBound">
                                <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
                                <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
                                <AlternatingRowStyle CssClass="table_g" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("TraineeApplicationFlowID") %>'
                                                CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" />
                                        </ItemTemplate>
                                        <ItemStyle Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="操作人">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAccount" runat="server" Text='<%# Eval("Account.Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="15%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="操作时间">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOperationTime" runat="server" Text='<%# Eval("OperationTime") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="状态">
                                        <ItemTemplate>
                                          <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("TraineeApplicationStatus.Name")%>'></asp:Label>  
                                        </ItemTemplate>
                                        <ItemStyle Width="18%" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="备注">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemark" runat="server" Text='<%# Eval("Remark") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="45%" />
                                    </asp:TemplateField>
                                </Columns>
                    <PagerTemplate>
                         <uc1:PageTemplate ID="PageTemplate1" runat="server" />		              
                    </PagerTemplate>
                            </asp:GridView>  

             </div>     
</div>
   </ContentTemplate>
</asp:UpdatePanel>