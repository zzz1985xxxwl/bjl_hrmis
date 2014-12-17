<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassFactoryView.ascx.cs" Inherits="SEP.Performance.Pages.Config.Views.ClassFactoryView1" %>
       <div class="leftitbor2"> 类工厂设置</div>
       <div class="edittable">
        <table style="width: 100%">
          
            <tr>
                <td style="width: 10%;text-align:left">
                    SEPDal</td>
                <td style="width: 90%">
                    <asp:TextBox ID="txtSEPDal" runat="server" Width="650px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    SEPBll</td>
                <td>
                    <asp:TextBox ID="txtSEPBll" runat="server" Width="650px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    HrmisDal</td>
                <td>
                    <asp:TextBox ID="txtHrmisDal" runat="server" Width="650px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    HrmisFacade</td>
                <td>
                    <asp:TextBox ID="txtHrmisFacade" runat="server" Width="650px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    CRMFacade</td>
                <td>
                    <asp:TextBox ID="txtCRMFacade" runat="server" Width="650px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    MyCMMIWebDAL</td>
                <td>
                    <asp:TextBox ID="txtMyCMMIWebDAL" runat="server" Width="650px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:left">
                    MyCMMIFacade</td>
                <td>
                    <asp:TextBox ID="txtMyCMMIFacade" runat="server" Width="650px"></asp:TextBox></td>
            </tr>
        </table>
        </div>
