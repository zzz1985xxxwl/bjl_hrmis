<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AutoRemindFunctionSetView.ascx.cs" Inherits="SEP.Performance.Pages.Config.Views.AutoRemindFunctionSetView" %>
         <div class="leftitbor2">��������</div>
         <div class="edittable">
        <table style="width: 100%">
         
            <tr >
                <td colspan="2">
                    �Զ�����Ч����</td>
            </tr>
            <tr>
                <td style="width: 20%;">
                    <asp:CheckBox ID="cbIsAutoAssess" runat="server" />�����˹���</td>
                <td style="width: 80%">
                    </td>
            </tr>
            <tr>
                <td colspan="2">
                    �Զ�����Ա����ס֤���ڣ��ڸþ�ס֤����ǰXX�죬���Է�Email����������Դ���ź�Ա�����˾�ס֤��������</td>
            </tr>
            <tr>
                <td style="width: 20%;">
                    <asp:CheckBox ID="cbIsAutoEmployeeResidenceDateRearch" runat="server" />�����˹���</td>
                <td style="width: 80%">
                    ����ǰ<asp:TextBox ID = "txtBeforeEmployeeResidenceDateRearchDays" runat="server" Width="50px"></asp:TextBox>������&nbsp;
                    <asp:Label
                        ID="lbBeforeEmployeeResidenceDateRearchDaysMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    �µ��Զ�����Ա���˶Կ�������</td>
            </tr>
            <tr>
                <td style="width: 20%;">
                    <asp:CheckBox ID="cbIsAutoRemindEmployeeConfirmAttendance" runat="server" />�����˹���</td>
                <td style="width: 80%">
                    </td>
            </tr>
            <tr >
                <td colspan="2">
                    ��ٵ���ǰXX�����Ѹ��ˣ�����������Դ��</td>
            </tr>
            <tr >
                <td style="width: 20%;">
                    <asp:CheckBox ID="cbIsAutoRemindVacation" runat="server" />�����˹���</td>
                <td style="width: 80%">
                    ����ǰ<asp:TextBox ID = "txtBeforeRemindVacationDays" runat="server" Width="50px"></asp:TextBox>������&nbsp;
                    <asp:Label
                        ID="lbBeforeRemindVacationDaysMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    Ա����ͬ����ǰXX������������Դ��</td>
            </tr>
            <tr>
                <td style="width: 20%;">
                    <asp:CheckBox ID="cbIsAutoRemindContract" runat="server" />�����˹���</td>
                <td style="width: 80%">
                    ����ǰ<asp:TextBox ID = "txtBeforeRemindContractDays" runat="server" Width="50px"></asp:TextBox>������&nbsp;
                    <asp:Label
                        ID="lbBeforeRemindContractDaysMsg" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
            <tr >
                <td colspan="2">
                    Ա�������ڵ���ǰXX������������Դ��</td>
            </tr>
            <tr >
                <td style="width: 20%;">
                    <asp:CheckBox ID="cbIsAutoRemindProbationDateRearch" runat="server" />�����˹���</td>
                <td style="width: 80%">
                    ����ǰ<asp:TextBox ID = "txtBeforeRemindProbationDateRearchDays" runat="server" Width="50px"></asp:TextBox>������&nbsp;
                    <asp:Label
                        ID="lbBeforeRemindProbationDateRearchDays" runat="server" CssClass="psword_f"></asp:Label></td>
            </tr>
        </table>
        </div>
