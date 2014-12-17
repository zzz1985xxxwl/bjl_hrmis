<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditBulletinView.ascx.cs" Inherits="SEP.Performance.Views.SEP.Bulletins.EditBulletinView" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>  

<div id="message" runat="server" class="leftitbor">
      <asp:Label ID="ErrorMessageForBll" runat="server" CssClass="fontred"></asp:Label>
 </div>
<div class="leftitbor2" ><asp:Label ID="lblTitle" runat="server"></asp:Label></div>  
<div class="edittable">
    <table width="100%" border="0">
        <tr>
          <td width="14" align="right" style="height: 24px"></td>
          <td align="left" style="width: 65px; height: 24px;">标&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;题&nbsp;<span class = "redstar">*</span>&nbsp;</td>
          <td width="46%" align="left" valign="middle" style="height: 24px">
          <asp:TextBox ID="txtTitle" runat="server" CssClass="input1" Width="341px"></asp:TextBox>
          <asp:Label ID="lblBulletinTitleError" runat="server" CssClass="psword_f"></asp:Label></td>
        </tr>
        <tr>
         <td width="14" align="right"></td>
          <td align="left" style="width: 65px">发布时间&nbsp;<span class = "redstar">*</span>&nbsp;</td>
          <td width="31%" align="left" valign="middle">
          <asp:TextBox ID="txtPublishTime" runat="server" CssClass="input1"></asp:TextBox><asp:Label ID="lblPublishTimeError" runat="server" CssClass="psword_f"></asp:Label></td>
        </tr>
        <tr>
         <td width="14" align="right"></td>
          <td align="left" style="width: 65px">所属部门&nbsp;<span class = "redstar">*</span>&nbsp;</td>
          <td width="31%" align="left" valign="middle">
              <asp:DropDownList ID="listDepartment" runat="server">
              </asp:DropDownList>
          </td>
        </tr>
        <tr>
         <td width="14" align="right"></td>
         <td align="left" valign="top" style="height: 189px; width: 65px;" >内&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;容</td>
            <td align="left" valign="middle" colspan="4" height="200"> <FCKeditorV2:FCKeditor ID="txtContent" runat="server"  Width="579px" Height="580px">  
    </FCKeditorV2:FCKeditor></td>
        </tr>
        <tr>
         <td width="14" align="right"></td>
         <td align="left" valign="top" style="width: 65px">附件列表</td>
          <td colspan="3" align="left" valign="middle"><asp:ListBox ID="lbAppendixList" runat="server" Height="159px" Width="579px"  ></asp:ListBox><br /><asp:Label ID="lblAppendixMessage" runat="server" CssClass="fontred"></asp:Label></td>
        </tr>
        <tr>
        <td width="14" align="right"></td>
        <td align="right" style="width: 65px">&nbsp;</td>
         
          <td colspan="3" align="left" valign="middle"><asp:Button ID="btnDeleteAppendix" runat="server" OnClick="btnDeleteAppendix_Click" Text="删除" CssClass="inputbt" />&nbsp;&nbsp;
                                      <asp:FileUpload ID="Upload"  runat="server" Width="375px" onkeydown="event.returnValue=false;" onpaste="return false"  CssClass="fileupload" />&nbsp;&nbsp;
                                       <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="增加附件"  CssClass="inputbt" />&nbsp;&nbsp;
          </td>
        </tr>
    </table>
 </div>  
<div class="tablebt">
  <asp:Button ID="btnOK" runat="server" Text="确定" CssClass="inputbt"  OnClick="btnOK_Click"></asp:Button>
  <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="inputbt"   OnClick="btnCancel_Click"></asp:Button>
</div>