<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeSalaryHistoryDetailView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryHistoryDetailView" %>
    <div id="divResultMessage" runat="server" class="leftitbor" >
                <asp:Label ID="lbResultMessage" runat="server"></asp:Label>
	      </div>

<div class="leftitbor2" >
              <asp:Label ID="lblOperation" runat="server" >Ա��������</asp:Label>
              &nbsp;
           <asp:HiddenField ID="hdAdjustHistoryID" runat="server" />        
            <asp:HiddenField ID="hdEmployeeID" runat="server" />
		</div>
 <div class="edittable">
	<table width="100%"  cellpadding="10" cellspacing="0" >
	<tr>
        <td align="center" >
          <table width="100%" border="0">
          <tr>
              <td width="2%" align="right" ></td>
              <td align="right" style="width:8%;">Ա������</td>
              <td align="left"style="width:40%;"><asp:Label ID="lbName" runat="server"></asp:Label></td>
              <td align="right" width="8%">�ù���ʽ</td>
              <td align="left" width="40%"><asp:Label ID="lbType" runat="server"></asp:Label></td>
          </tr>
          <tr>
              <td align="right" ></td>
              <td align="right">����</td>
              <td align="left"><asp:Label ID="lbDepartment" runat="server"></asp:Label></td>
              <td align="right">ְλ</td>
              <td align="left"><asp:Label ID="lbPosition" runat="server"></asp:Label></td>
          </tr>
          <tr>
              <td align="right">
              </td>
              <td align="right">
                  ����</td>
              <td align="left">
                  <asp:Label ID="lbAccountSet" runat="server"></asp:Label></td>
              <td align="right">
              </td>
              <td align="left">
              </td>
              </tr>
              <tr id="trAccountSet" runat="server"  class="green2">
                <td colspan="5">
                <table width="100%"  id="tbAccountSet"  runat="server" border="0">
                </table>
                </td>
             </tr>
              <tr>
                  <td align="right">
                  </td>
                  <td align="right">��ע
                  </td>
                  <td align="left" colspan="3">
                      <asp:Label ID="lbDescription" runat="server"></asp:Label></td>
              </tr>
          </table>
		  </td>
      </tr>     
      </table>
     </div>
      <div class="tablebt">
		   <asp:Button  Text="ȷ  ��" ID="btnOK"  OnClick="btnOK_Click" runat="server" class="inputbt"/>
           <asp:Button  Text="ȡ����" ID="btnCancel" OnClick="btnCancel_Click" runat="server" class="inputbt" />
          </div>
