<%@ Control Language="C#" AutoEventWireup="true" Codebehind="EditTaxBand.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.Tax.EditTaxBand" %>
<div id="tbMessage" runat="server" class="leftitbor">
    <span class="font14b">
        <asp:Label ID="ErrorMessage" runat="server" CssClass="fontred"></asp:Label></span></div>
<div class="leftitbor2">
    <asp:Label ID="lblTitle" runat="server"></asp:Label>
</div>

        
<div  class="edittable">
  <table width="100%" border="0">

                    <tr>
                        <td style="width: 2%;">
                        </td>
                        <td style="width: 20%;">
                            超过起征点&nbsp;<span class="redstar">*</span></td>
                        <td style="width: 78%;" align="left">
                            <asp:TextBox ID="txtBandMin" Width="40%" runat="server" CssClass="input1"></asp:TextBox>&nbsp;元以上&nbsp;
                            <asp:Label ID="lblBindMin" runat="server" CssClass="psword_f"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 2%;">
                        </td>
                        <td style="width: 20%;">
                            税&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;率&nbsp;<span class="redstar">*</span></td>
                        <td style="width: 78%;" align="left">
                            <asp:TextBox ID="txtTaxRate" Width="40%" runat="server" CssClass="input1"></asp:TextBox>&nbsp;%&nbsp;
                            <asp:Label ID="lblTaxRate" runat="server" CssClass="psword_f"></asp:Label></td>
                    </tr>

    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnEdit" runat="server" Text="确　定" class="inputbt" OnClick="btnEdit_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="取　消" class="inputbt" />
</div>
