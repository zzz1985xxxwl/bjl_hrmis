<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CompanyInfoView.ascx.cs" Inherits="SEP.Performance.Pages.Config.Views.CompanyInfoView" %>
        <div class="leftitbor2">���ù�˾��Ϣ</div>
        <div class="edittable">
        <table width="100%">
            <tr style="display:none;">
                <td style="width:10%;">	Ĭ�ϵ�ϵͳ����ԴMail��ַ
                </td>
                <td style="width:90%;">
                    <asp:TextBox runat="server" ID="txtSYSTEMMAILADDRESS" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none;">
                <td>	Ĭ�ϵ�ϵͳ����Դ����
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSYSTEMMAILCOMMAND" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Notes ��������
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSMTPHOST" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none;">
                <td>�û���ƾ֤Mail��ַ
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtUSERNAMEMAILADDRESS" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Mail����
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtUSERNAMEPASSWORD" Width="650px"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>�����ʼ���ַ
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMAILTOHR" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>��ҳ��ַ

                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtLOCALHOSTADDRESS" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>��˾����ϵ�绰
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCOMPANYTEL" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>��˾����ϵ����
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCOMPANYFAX" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>��˾��Title
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCOMPANYTITLE" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>�½��û�Ĭ������
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDEFAULTPASSWORD" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>ϵͳ�ı�ʶ��
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtSYSTEMID" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td> ������ʾ��׼
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtATTENDANCEISNORMALISINCLUDEOUTINTIME" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td > ����ҳ���ַ
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtHELPADDRESS" Width="650px"></asp:TextBox>
                </td>
            </tr>
        </table>
        </div>
