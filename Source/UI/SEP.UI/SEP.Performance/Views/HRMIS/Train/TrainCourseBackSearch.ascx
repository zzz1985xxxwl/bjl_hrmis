<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrainCourseBackSearch.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.Train.TrainCourseBackSearch" %>
<%@ Register Src="TrainCourseListView.ascx" TagName="TrainCourseListView" TagPrefix="uc1" %>
<div class="leftitbor" >
     <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
   </div>
  
  <div class="leftitbor2" >
            ��ѵ�γ̹���</div>
<div class="edittable" id="tbCourse" runat="server" >
   <table border="0" width="100%">
        <tr>
           <td align="right" width="2%"></td>
           <td align="left" width="8%">�γ�����</td>
           <td align="left" style="width: 190px"><asp:TextBox ID="txtCourseName" runat="server" CssClass="input1" Width="80%"></asp:TextBox></td>
           <td align="left" width="8%">��ѵʦ</td>
           <td align="left" style="width: 190px"><asp:TextBox ID="txtTrainer" runat="server" CssClass="input1" Width="80%"></asp:TextBox></td>
          <td width="8%" align="left">�ƻ�ʱ��</td>
          <td align="left" colspan="2">
                 <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd"
                     TargetControlID="txtExpectedST">
                 </ajaxToolKit:CalendarExtender>
                 <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd"
                     TargetControlID="txtExpectedET">
                 </ajaxToolKit:CalendarExtender><asp:TextBox ID="txtExpectedST" runat="server" CssClass="input1" Width="38%"></asp:TextBox>
              --
              <asp:TextBox ID="txtExpectedET" runat="server" CssClass="input1" Width="38%"></asp:TextBox></td>
         </tr>
        <tr>
          <td align="right" width="2%"></td>
          <td width="8%" align="left">��ѵ��Χ</td>
          <td align="left" style="width: 190px"><asp:DropDownList ID="listScope" runat="server" Width="80%"></asp:DropDownList></td>
          <td width="8%" align="left">��ѵ״̬</td>
          <td align="left">
              <asp:DropDownList ID="listStatus" runat="server" Width="80%" >
              </asp:DropDownList>
          </td>
          <td width="8%"align="left">ʵ��ʱ��</td>
          <td align="left" colspan="2">
                 <ajaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd"
                     TargetControlID="txtActualST">
                 </ajaxToolKit:CalendarExtender>
                 <ajaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" Format="yyyy-MM-dd"
                     TargetControlID="txtActualET">
                 </ajaxToolKit:CalendarExtender><asp:TextBox ID="txtActualST" runat="server" CssClass="input1" Width="38%"></asp:TextBox>
              --
              <asp:TextBox ID="txtActualET" runat="server" CssClass="input1" Width="38%"></asp:TextBox></td>
        </tr>
        <tr>
          <td align="right" width="2%"> </td>
          <td align="left">��ؼ���</td>
          <td align="left" style="width: 190px"><asp:TextBox ID="txtSkill" runat="server" CssClass="input1" Width="80%"></asp:TextBox></td>
          <td align="left">����ѵ��</td>
           <td align="left"><asp:TextBox ID="txtTrainee" runat="server" CssClass="input1" Width="80%" ></asp:TextBox></td>
          <td align="left">�ƻ��ɱ�</td>
          <td align="left" colspan="2"><asp:TextBox ID="txtExpectedCost" runat="server"  CssClass="input1" Width="38%"></asp:TextBox>
              --
              <asp:TextBox ID="txtExpectedHour" runat="server" CssClass="input1" Width="38%"></asp:TextBox></td>
        </tr>
        <tr>
               <td align="right" width="2%">
               </td>
           <td align="left">Э��Ա</td>
           <td align="left" style="width: 190px"><asp:TextBox ID="txtCodinator" runat="server" CssClass="input1" Width="80%"></asp:TextBox></td>
               <td align="left">
               </td>
               <td align="left">
               </td>
          <td align="left">ʵ�ʳɱ�</td>
          <td align="left" colspan="2"><asp:TextBox ID="txtActualCost" runat="server" CssClass="input1" Width="38%"></asp:TextBox>
              --
              <asp:TextBox ID="txtActualHour" runat="server" CssClass="input1" Width="38%"></asp:TextBox></td>
           </tr>
   </table>
</div>
  <div class="tablebt">
            <asp:Button ID="BtnSearch" runat="server" Text="��  ѯ" OnClick="BtnSearch_Click" class="inputbt"/>
            <asp:Button ID="BtnAdd" runat="server" Text="��  ��" OnClick="BtnAdd_Click" class="inputbt"/>
        </div>
  <div class="nolinetablediv">
        <uc1:TrainCourseListView ID="TrainCourseListView1" runat="server" />
    </div>
