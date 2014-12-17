<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContractTypeView.ascx.cs" Inherits="SEP.Performance.Views.ContractType.ContractTypeView" %>
<div id="tbNoDataMessage"   runat="server" class="leftitbor" >
<asp:Label ID="lblResultMessage" runat="server" CssClass = "fontred"></asp:Label>
</div>

<div class="leftitbor2">
<asp:Label ID="lblTitle" runat="server"></asp:Label> 
<asp:HiddenField ID="Operation" runat="server" />
</div>

<div  class="linetablediv">
          <table width="100%" height="56" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10">
            <tr>
              <td width="2%" align="right" ></td>
              <td width="8%" align="left" >编&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号</td>
              <td width="41%" align="left" ><asp:TextBox ID="txtID" runat="server" ReadOnly="True" CssClass="input1" Width="160px"></asp:TextBox>            
              &nbsp;&nbsp;&nbsp;<asp:Label ID="lblValidateID" runat="server" CssClass="psword_f"></asp:Label> </td> 
              <td width="8%" align="left" >名&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;称&nbsp;<span class = "redstar">*</span>&nbsp;</td>
              <td align="left" style="width:43%;"  ><asp:TextBox ID="txtName" runat="server" CssClass="input1"></asp:TextBox>
              &nbsp;&nbsp;&nbsp;<asp:Label ID="lblValidateName" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
             <td width="2%" align="right" ></td>
              <td width="8%" align="left" >模&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;板</td>
              <td width="41%" align="left" > <asp:FileUpload ID="fuTemplate" runat="server" CssClass="fileupload" Width="242px" /> 
              <td colspan="2"/>           
            <tr>
            
            </tr>
          </table>   
</div>
<div class="tablebt">
<input id="btnOK" type="submit" runat ="server" value="确  定" class="inputbt" onserverclick="btnOK_ServerClick" />
<input id="btnCancel" type="button" runat ="server" value="取　消" class="inputbt" onserverclick="btnCancel_ServerClick"/>
</div>    