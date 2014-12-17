<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoalAllLastView.ascx.cs" Inherits="SEP.Performance.Views.GoalAllLastView" %>


            <table width="100%" border="0" cellspacing="0" cellpadding="0"  >
        <tr>
        <td colspan="9">
            <asp:Label ID="lblResultMessage" runat="server" CssClass="fontred"></asp:Label></td>            
            </tr>
            <tr align="center" style=" width:100%; height :153px">
            <td align="center" >            
            <table border="0" cellspacing="0" cellpadding="0" width="99%">
              <tr >
                <td rowspan="2" align="center" style="width:30%">
                    &nbsp;<img src="../../../Pages/image/menupic01.jpg" alt="" id="p" runat="server" /> &nbsp;
                </td>
                <td  style="width: 204" valign="top" align="left"><span style="vertical-align:top" class="fontred1"><strong>[个人目标]</strong></span> <a href="#" style=" vertical-align:top">
             <asp:LinkButton Width="50%" ID="lbtnPersonalGoal"  runat="server" OnCommand="lbtnPersonalGoal_Command">LinkButton</asp:LinkButton></a></td>
              </tr>
              <tr>
                <td align="left">
                <img src="../../../Pages/image/add.gif" alt="" id="t" runat="server"/> <asp:LinkButton ID="lbtnAddPersonalGoal" runat="server" OnCommand="lbtnAddPersonalGoal_Command">新增</asp:LinkButton>　　　　&nbsp;&nbsp;
                    <img src="../../../Pages/image/edit.gif" id="ImgPEdit" runat="server"/>
                    <img src="../../../Pages/image/editgray.gif" id="ImgPEditGray" runat="server"/><asp:LinkButton ID="lbtnUpdatePersonalGoal" runat="server" OnCommand="lbtnUpdatePersonalGoal_Command">编辑</asp:LinkButton></td>
              </tr>
            </table>
            </td>
          </tr>
            <tr  style="width:100%;  height :154px">
            <td  align="center">
            <table border="0" cellspacing="0" cellpadding="0" width="99%">
              <tr>
                <td  style="width:30%" rowspan="2" align="center">
            <img src="../../../Pages/image/menupic02.jpg" alt="" id="tg" runat="server" /> &nbsp;</td>
                <td  style="width: 204" valign="top" align="left"><span style="vertical-align:top"  class="fontred1"><strong>[团队目标]</strong></span> 
                <asp:LinkButton ID="lbtnTeamGoal" Width="50%"  runat="server" OnCommand="lbtnTeamGoal_Command">LinkButton</asp:LinkButton></td>
              </tr>
              <tr>
                <td align="left">
                    <img src="../../../Pages/image/add.gif" id="ImgAdd" runat="server" />
                    <img src="../../../Pages/image/addgray.gif" id="ImgAddGray" runat="server" />
                    <asp:LinkButton ID="lbtnAddTeamGoal" runat="server" OnCommand="lbtnAddTeamGoal_Command">新增</asp:LinkButton>　　　　&nbsp;
                    <img src="../../../Pages/image/edit.gif" id="ImgTEdit" runat="server" />
                    <img src="../../../Pages/image/editgray.gif" id="ImgTEditGray" runat="server" /> <asp:LinkButton ID="lbtnUpdateTeamGoal" runat="server" OnCommand="lbtnUpdateTeamGoal_Command">编辑</asp:LinkButton></td>
              </tr>
            </table>
            </td>
            </tr>
            <tr  style="width:100%;  height :153px">
            <td align="center" >
            <table border="0" cellspacing="0" cellpadding="0" width="99%">
              <tr>
                <td  style="width:30%" rowspan="2" align="center">
            <img src="../../../Pages/image/menupic03.jpg" alt="" id="c" runat="server" /> &nbsp;</td>
                <td style="width: 204" valign="top" align="left"><span style="vertical-align:top"  class="fontred1"><strong>[公司目标]</strong></span> 
            <asp:LinkButton ID="lbtnCompanyGoal" Width="50%" runat="server" OnCommand="lbtnCompanyGoal_Command">LinkButton</asp:LinkButton></td>
              </tr>
              <tr>
                <td align="left">　　　</td>
              </tr>
            </table>
            </td>
            </tr>
        </table>
