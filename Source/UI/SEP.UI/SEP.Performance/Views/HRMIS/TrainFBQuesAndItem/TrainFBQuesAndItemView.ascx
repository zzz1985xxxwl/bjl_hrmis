<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrainFBQuesAndItemView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.TrainFBQuesAndItem.TrainFBQuesAndItemView" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
 <div id="divResultMessage" runat="server" class="leftitbor">
    <asp:Label ID="lbResultMessage" runat="server" CssClass="fontred"></asp:Label>
                    </div>
<div class="leftitbor2" >
    <asp:Label ID="lbOperationType" runat="server"></asp:Label>
    <asp:Label ID="lbID" runat="server" Text="#" Style="display: none;"></asp:Label>
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="right" style="width: 14%;">
                问题名称&nbsp;<span class="redstar">*</span></td>
            <td align="left" style="width: 40%">
                <asp:TextBox runat="server" ID="tbName" CssClass="input1" Width="50%"></asp:TextBox>
                <asp:Label ID="lbNameMessage" runat="server" CssClass="psword_f"></asp:Label></td>
            <td align="right" style="width: 6%;">
                类型&nbsp;<span class="redstar">*</span></td>
            <td align="left" style="width: 40%">
                <asp:DropDownList ID="ddlType" runat="server" Width="50%" >
                </asp:DropDownList>
                 <asp:Label ID="lblTypeMessage" runat="server" CssClass="psword_f"></asp:Label></td>
        </tr>
        
        <tr>
            <td align="left" colspan="5" valign="top">
                <div id="tbLeaveRequestItem" runat="server" class="linetable" >
                    <asp:GridView GridLines="None" Width="100%" ID="gvTrainFBItemList" runat="server" AutoGenerateColumns="false"
                        OnRowDataBound="gvDiyStepList_RowDataBound" >
                        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                        <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
                        <AlternatingRowStyle CssClass="table_g" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnHiddenPostButton" CommandArgument='1' CommandName="HiddenPostButtonCommand"
                                        runat="server" Text="" Style="display: none;" />
                                </ItemTemplate>
                                <ItemStyle Width="2%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="编号" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbl" runat="server" Text='<%# Eval("FBItemID").ToString() != "-1" ? Eval("FBItemID").ToString() : "*"%>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="8%" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="反馈项描述">
                                <ItemTemplate>
                                    <asp:TextBox ID = "txtDescription" runat="server" Text=""  CssClass="input1"   Rows="1"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="20%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="反馈项分值">
                                <ItemTemplate>
                                     <asp:TextBox ID = "txtValue" runat="server" Text=""  CssClass="input1"   Rows="1"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="20%" />
                            </asp:TemplateField>
                                                                                                       
                          <asp:TemplateField>
                                      <ItemTemplate>
                           <asp:LinkButton ID="lbAddItem" runat="server" OnCommand="lbAddItem_Command"/>
                                      </ItemTemplate>
                                            <ItemStyle Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                      <ItemTemplate>
                           <asp:LinkButton ID="lbDeleteItem" runat="server" OnCommand="lbDeleteItem_Command"/>
                                      </ItemTemplate>
                                            <ItemStyle Width="3%" />
                                    </asp:TemplateField>
                                   
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="BtnOK" OnClick="BtnOK_Click" runat="server" class="inputbt" Text="确定" />
    <asp:Button ID="btnCancel" OnClick="BtnSubmit_Click" runat="server" class="inputbt"
        Text="取消" />
</div>
       
</ContentTemplate>
</asp:UpdatePanel>