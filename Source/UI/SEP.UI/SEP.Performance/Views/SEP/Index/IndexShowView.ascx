<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndexShowView.ascx.cs" Inherits="SEP.Performance.Views.SEP.Index.IndexShowView" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc2" %>
<%@ Register Src="IndexEditView.ascx" TagName="IndexEditView" TagPrefix="uc1" %>
      
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
  <ajaxToolKit:ModalPopupExtender id="mpeEdit" runat="server"  Drag="true" PopupDragHandleControlID="pnlEdit"
                   BackgroundCssClass="modalBackground" PopupControlID="pnlEdit" 
                    TargetControlID="btnHidden">
  </ajaxToolKit:ModalPopupExtender>
          <asp:Button ID="btnHidden" runat="Server" Style="display: none;"/>            
    <div id="divMPEReimburse" runat="server"> <asp:Panel ID="pnlEdit" runat="server" CssClass="modalBox" Style="display: none;">
        <div style="white-space: nowrap; text-align: center;">
            <uc1:IndexEditView ID="IndexEditView1" runat="server" />   
        </div>
    </asp:Panel></div>          
  <asp:Button ID="btnEdit" CssClass="SetWebPart" runat="Server" Style="display: none;" OnClick="btnEdit_Click"/>    
<asp:WebPartManager ID="WebPartManager1" runat="server"></asp:WebPartManager>

<div id="EmptyPage" runat="server" >
      <table class="linetable"  width="98%" border="0">
          <tr>
            <td height="28px" class="headerstyleblue"><strong>&nbsp;&nbsp;&nbsp;&nbsp;欢迎使用SEP系统</strong></td>
          </tr>
          <tr>
                <td align="center">
                <p><object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" 
                width="750" height="560">
                  <param name="movie" value="../../../Pages/image/spiral2.swf" />
                  <param name="quality" value="high" />
                  <param name="wmode" value="Opaque">
                  <embed src="../../../Pages/image/spiral2.swf" wmode="Opaque" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" 
                  width="750" height="560"></embed>
                </object>
              </p></td>
          </tr>
      </table>
</div>
 <table width="98%" border="0" cellpadding="0" cellspacing="0" id="webPartTable" runat="server" >
      <tr>
        <td style="width:65%; " valign="top" >
          <asp:WebPartZone ID="WebPartZone1" runat="server" Width="100%" BorderColor="Transparent" 
          BorderWidth="0px" HeaderText=" " WebPartVerbRenderMode="TitleBar" Padding="0" EmptyZoneText=" " PartChromeType="None" >
              <EmptyZoneTextStyle Height="300px" />
              <PartStyle BorderColor="#BCBCBC" />
              <PartTitleStyle HorizontalAlign="Left" CssClass="tdbgpic" Font-Size="10pt"/>
              <ExportVerb Visible="False" Enabled="False" />
              <RestoreVerb ImageUrl="../../../Pages/image/win03.gif" Text="" />
              <HelpVerb Visible="False" Enabled="False" />
              <CloseVerb ImageUrl="../../../Pages/image/win01.gif" />
              <ConnectVerb Visible="False" Enabled="False" />
              <PartChromeStyle   CssClass="lineBorder" />
              <DeleteVerb Visible="False" Enabled="False" />
              <EditVerb Visible="False" Enabled="False" />
              <MinimizeVerb ImageUrl="../../../Pages/image/win02.gif" Text="" />
            </asp:WebPartZone>
        </td>
       <td style="width:6px;" valign="top" />
        <td valign="top" style=" width:34%; "  align="center">
           <asp:WebPartZone ID="WebPartZone2" runat="server" Width="100%" BorderColor="Transparent" BorderWidth="0px"  HeaderText=" " WebPartVerbRenderMode="TitleBar"  Padding="0" EmptyZoneText=" " PartChromeType="None"  >
              <EmptyZoneTextStyle Height="300px" />
              <PartStyle BorderColor="#BCBCBC" />
              <PartTitleStyle HorizontalAlign="Left" CssClass="tdbgpic" Font-Size="10pt"/>
              <ExportVerb Visible="False" Enabled="False" />
              <RestoreVerb ImageUrl="../../../Pages/image/win03.gif" Text="" />
              <HelpVerb Visible="False" Enabled="False" />
              <CloseVerb ImageUrl="../../../Pages/image/win01.gif" />
              <ConnectVerb Visible="False" Enabled="False" />
              <PartChromeStyle   CssClass="lineBorder" />
              <DeleteVerb Visible="False" Enabled="False" />
              <EditVerb Visible="False" Enabled="False" />
              <MinimizeVerb ImageUrl="../../../Pages/image/win02.gif" Text="" />
            </asp:WebPartZone>
        </td>
       </tr>
    </table>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc2:Progressing ID="Progressing1" runat="server" />
            </ProgressTemplate>
        </asp:UpdateProgress>
  </ContentTemplate>   
</asp:UpdatePanel>
