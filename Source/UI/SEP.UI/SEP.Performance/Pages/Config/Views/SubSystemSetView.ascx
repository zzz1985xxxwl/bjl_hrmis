<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubSystemSetView.ascx.cs" Inherits="SEP.Performance.Pages.Config.Views.SubSystemSetView" %>
      <div class="leftitbor2"> 子系统使用设置</div>
      <div class="edittable">
        <table style="width: 100%">
            <tr>
                <td style="width: 10%">
                    <asp:CheckBox ID="cbHasHrmisSystem" runat="server" Text="Hrmis" /></td>
                <td style="width: 10%">
                    <asp:CheckBox ID="cbHasCRMSystem" runat="server" Text="CRM" /></td> 
                <td style="width: 10%">
                    <asp:CheckBox ID="cbHasMyCMMISystem" runat="server" Text="MyCMMI" /></td>
                <td style="width: 70%">
                    <asp:CheckBox ID="cbHasEShoppingSystem" runat="server" Text="EShopping" /></td>
            </tr>
        </table>
       </div>
