<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PersonalConfigView.ascx.cs"
    Inherits="SEP.Performance.Views.SEP.Accounts.PersonalConfigView" %>
<%--<object id="UsbActiveX" classid="clsid:cb9da3eb-89d4-492c-a9eb-adf638f822ea"  style="display:none;"></object>--%>
     <script language="javascript " type="text/javascript" src="../../../Pages/Inc/UsbKey.js"></script>
<script type="text/javascript">
    function PhotoHiddenBtnClick()
    {
        document.getElementById("divMPEPhoto").style.display="block";
        document.getElementById("cphCenter_PersonalConfigView1_btnPhotoHidden").click();
    }
</script>
<input id="lbUsbKeyCount" type="hidden" class="UsbKeyCount" runat="server" />
<input id="lbUsbKey" type="hidden" class="UsbKey" runat="server" />
<div id="divMessage" runat="server" class="leftitbor">     
    <asp:Label ID="lbResultMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2" ><asp:Label ID="lblOperation" runat="server">ϵͳ����</asp:Label>
        </div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td align="right" width="2%">
            </td>
            <td align="left" width="23%">
                �Ƿ����Email&nbsp;<span class="redstar">*</span></td>
            <td align="left" colspan="2" width="75%">
                <asp:RadioButtonList ID="rbEmail" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">��</asp:ListItem>
                    <asp:ListItem Value="1">��</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                �Ƿ���ܶ���&nbsp;<span class="redstar">*</span></td>
            <td align="left" colspan="2">
                <asp:RadioButtonList ID="rbSMS" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">��</asp:ListItem>
                    <asp:ListItem Value="1">��</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                �Ƿ���UsbKey�����֤&nbsp;<span class="redstar">*</span></td>
            <td align="left" colspan="2">
                <asp:RadioButtonList ID="rbUsbKey" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbUsbKey_SelectedIndexChanged">
                    <asp:ListItem Value="0">��</asp:ListItem>
                    <asp:ListItem Value="1">��</asp:ListItem>
                </asp:RadioButtonList>
                ���ѡ���ǡ������ڵ�¼ϵͳ�Ͳ鿴������Ϣʱ���������UsbKey����һ���������֤��
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                ����UsbKey</td>
                
            <td align="left" colspan="2">
                <asp:Button ID="btnChangeUsbKey" runat="server" CssClass="inputbtlong" Text="����UsbKey"
                    OnClientClick='var confirm=GetUsbKey();return confirm;' OnClick="btnChangeUsbKey_Click" />
                    &nbsp;<asp:Label ID="lbUsbKeyMsg" runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td align="right">
            </td>
            <td align="left"><asp:Label ID="lbElectricName" runat="server" Text = "���õ���ǩ��"></asp:Label></td>
            <td align="left" colspan="2" valign="middle">
            <a  id="PhotoLink" runat="server" href="javascript:PhotoHiddenBtnClick()" >
            <asp:Image ID="imgPhoto" runat="server" ImageAlign="Left" Width="100px" Height="30px" ImageUrl="../../../pages/image/electricName.jpg" BorderWidth="1px" BorderColor="#919191" /></a>
            &nbsp;<asp:Label ID="lbElectricNameMsg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button Text="ȷ  ��" ID="btnOK" OnClick="btnOK_Click" runat="server" class="inputbt" />
    <asp:Button Text="ȡ����" ID="btnCancel" OnClick="btnCancel_Click" runat="server" class="inputbt" />
</div>
 <ajaxToolKit:ModalPopupExtender id="mpePhoto" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlUpdatePhoto" 
                    TargetControlID="btnPhotoHidden"></ajaxToolKit:ModalPopupExtender>  
                    
 <asp:Button ID="btnPhotoHidden" runat="Server" Style="display: none" />
 
 <div id="divMPEPhoto" >
 <asp:Panel ID="pnlUpdatePhoto" runat="server" CssClass="modalBox"  Width="400px" style="display:none;"> 
  <div id="divSmallResultMessage" runat="server" class="leftitbor">
       <asp:Label ID="lbSmallResultMessage" runat="server"></asp:Label>
		</div>

<div class="leftitbor2">�ϴ�ͼƬ</div>

<div class="edittable">
    <table id = "Table1" runat="server"  width="98%" border="0">
        <tr>
          <td align="left" style="width:3%" ></td>       
          <td width="80%" align="left" >
          <asp:FileUpload ID="UpPhoto" name='UpPhoto' CssClass="fileupload" runat="server" Width="100%" onkeydown="event.returnValue=false;" onpaste="return false" /></td>
          <td width="17px" align="left" >
            <asp:Button id="btnAdd" name="btnAdd" runat="server" Text="�ϴ�" OnClick="btnAdd_Click" ></asp:Button>
           </td> 
       </tr>  
        <tr>
          <td align="left" style="width:3%" ></td>       
          <td width="80%" align="left" colspan="2" >
              ����ͼƬ��С��500k����&nbsp;������100��30</td> 
       </tr>   	 
    </table>
</div>               
<div class="tablebt">
   <asp:Button  Text="�ء���" ID="Button1" OnClick="btnClose_Click"  OnClientClick="UpPhoto.select();document.selection.clear();return CloseModalPopupExtender('divMPEPhoto');" runat="server" CssClass="inputbt" />
</div>   
 </asp:Panel>
 </div>                   


