<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PositionGradeView.ascx.cs"
    Inherits="SEP.Performance.Views.SEP.Positions.PositionGradeView" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc1" %>
<%@ Register Assembly="ColorPickerControl" Namespace="ColorPickerControl" TagPrefix="cc1" %>
<link href="../../CSS/style.css" rel="stylesheet" type="text/css" />
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
            <div id="tbMessage" runat="server" visible="false" class="leftitbor">
<asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label></span>
            </div>
            <div class="leftitbor2" >
                                    <asp:Label ID="lblOperationTitle" runat="server">
                                    </asp:Label></div>
            <div class="linetablediv">
                <asp:GridView ID="dgPositionGradeList" GridLines="None" Width="100%" runat="server" AutoGenerateColumns="False"
                    BorderStyle="None" OnRowDataBound="PositionGradeList_RowDataBound">
                    <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                    <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
                    <AlternatingRowStyle CssClass="table_g" />
                    <Columns>
                        <asp:TemplateField HeaderStyle-Width="2%">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnHiddenPostButton" runat="server"
                                    CommandName="HiddenPostButtonCommand"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="2%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="职位等级名称">
                            <ItemTemplate>
                                <asp:TextBox ID="txtName" runat="server" CssClass="input1" Style="width: 90%"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="12%" />
                        </asp:TemplateField>
                              <asp:TemplateField HeaderText="福利描述">
                            <ItemTemplate>
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="input1" Style="width: 95%; height:80px" TextMode="MultiLine"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="74%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbAddItem" runat="server" OnCommand="lbAddItem_Command" />
                            </ItemTemplate>
                            <ItemStyle Width="3%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDeleteItem" runat="server" OnCommand="lbDeleteItem_Command" />
                            </ItemTemplate>
                            <ItemStyle Width="3%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbUpItem" runat="server" OnCommand="lbUpItem_Command" />
                            </ItemTemplate>
                            <ItemStyle Width="3%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDownItem" runat="server" OnCommand="lbDownItem_Command" />
                            </ItemTemplate>
                            <ItemStyle Width="3%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
                <div class="tablebt">
                                <asp:Button ID="btnOK" runat="server" Text="确定" CssClass="inputbt" OnClick="btnOK_Click">
                                </asp:Button>
                                <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="inputbt" OnClick="btnCancel_Click">
                                </asp:Button>
                           </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc1:Progressing ID="Progressing1" runat="server" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    </ContentTemplate>
</asp:UpdatePanel>
