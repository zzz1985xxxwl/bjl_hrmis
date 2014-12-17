<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PositionView.ascx.cs"
    Inherits="SEP.Performance.Views.SEP.Positions.PositionView" %>
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<div id="tbResultMessage" runat="server" class="leftitbor">
     <asp:Label ID="LabResultMessage" runat="server" CssClass="fontred"></asp:Label>
                </div>
<div class="leftitbor2" >
                            <asp:Label ID="PositionOperation" runat="server">
                            </asp:Label>
                        <span class = "displaynone">
                            <asp:Label ID="lblNum" runat="server"></asp:Label>
                        </span>
                   </div>
<div class="edittable">
    <table id="tbPositionView" runat="server" width="100%" border="0">
        <tr>
            <td width="2%" align="right">
            </td>
            
            <td align="left" style="width: 14%">
                名&nbsp;&nbsp;&nbsp;&nbsp;称&nbsp;<span class="redstar">*</span></td>
            <td align="left" style="width: 84%;">
                <asp:TextBox runat="server" ID="TxtName" Width="70%" class="input1"></asp:TextBox>&nbsp;
                <asp:Label runat="server" ID="lbNameMsg" CssClass="psword_f"></asp:Label>
            </td>
        </tr>
<%--        <tr>
                <td align="right" width="2%">
                </td>
                <td align="left" style="width: 13%">
                    职位等级 &nbsp;<span class="redstar">*</span></td>
                <td align="left" width="35%">
                    <asp:DropDownList ID="ddlGrade" runat="server" Width="60%">
                    </asp:DropDownList>&nbsp;
                    <asp:Label ID="lbGradeNullMessage" runat="server" CssClass="psword_f"></asp:Label></td>
                
        </tr>--%>
        <tr>
                <td align="right">
                </td>
                <td align="left">
                    职位说明 </td>
                <td align="left">
                    <asp:TextBox ID="txtDescription" runat="server" Width="90%" TextMode="MultiLine" Height="150px">
                    </asp:TextBox>
                    </td>
                
        </tr>                        
    </table>
</div>
<div class="tablebt">
    <asp:Button Text="确  定" ID="BtnOK" OnClick="BtnOK_Click" runat="server" CssClass="inputbt" />
    <asp:Button Text="取　消" ID="BtnCancel" OnClick="BtnCancel_Click" runat="server" CssClass="inputbt" />
</div>
