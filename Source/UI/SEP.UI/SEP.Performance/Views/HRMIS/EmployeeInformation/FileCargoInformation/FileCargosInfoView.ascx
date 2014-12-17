<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileCargosInfoView.ascx.cs"
            Inherits="SEP.Performance.Views.HRMIS.EmployeeInformation.FileCargoInformation.FileCargosInfoView" %>
<%@ Register Src="../../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <contenttemplate>
        <%--档案成员的小界面--%>
        <ajaxToolKit:ModalPopupExtender id="ModalPopupExtender1" runat="server" Drag="true" PopupDragHandleControlID="pnlAttendance" BackgroundCssClass="modalBackground" PopupControlID="pnlAttendance" 
                                        TargetControlID="btnHidden"></ajaxToolKit:ModalPopupExtender>
        <asp:Button ID="btnHidden" runat="Server" Style="display: none" />
        <div id="divMPE" runat="server">
            <asp:Panel ID="pnlAttendance" runat="server" CssClass="modalBox" Style="display: none;" Width="600px">
                <div style="white-space: nowrap; text-align: center;">
                    <div class="leftitbor2">
                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                    </div>              
                    <div class="edittable">
                        <table width="100%" border="0" style="text-align: left">
                            <tr>
                                <td style="width: 14%;">资料类型</td>
                                <td style="width: 86%;">
                                    <asp:DropDownList ID="ddFileCargoType" runat="server" Width="83.5%"></asp:DropDownList>
                                    <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>备 注</td>
                                <td>
                                    <asp:TextBox ID="txtRemark" runat="server" Height="185px" TextMode="MultiLine" Width="82%" CssClass="grayborder"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>上传文件</td>
                                <td>
                                    <asp:FileUpload ID="Upload" CssClass="fileupload"  runat="server" Width="81%" onkeydown="event.returnValue=false;" onpaste="return false"/>
                                    <asp:Label ID="lblUpoadFile" runat="server"  CssClass="psword_f" Visible="False"></asp:Label>
                                </td>
                            </tr>
                                    	
                        </table>
                    </div>
                    <div class="tablebt">
                        <asp:Button ID="btnOK" runat="server" CssClass="inputbt" Text="确定" OnClick="btnOK_Click"/>
                        <asp:Button ID="btnCancel" runat="server" Text="取消"  CssClass="inputbt" OnClick="btnCancel_Click"/>
                    </div>     
		
                </div>
            </asp:Panel>
        </div>
        <%--主界面--%>
        <div class="tablebt" style="margin-top: 0px;"> <asp:Button ID="btnAddInfo" runat="server" CssClass="inputbt" Text="新增档案" OnClick="btnAddInfo_Click" /> </div>
        <table id="tbfileCargo" runat="server" cellpadding="0" cellspacing="0" border="0" width="98%"  visible="false"> 
            <tr>
                <td align="left"><span class="font14px">档案信息</span></td>
            </tr>
            <tr>
                <td align="center">
                    <table width="100%" class="linetable" style="margin-bottom: 8px;" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="100%">
                                <asp:GridView ID="FileCargoListGV" runat="server" AllowPaging="True" AutoGenerateColumns="False" GridLines="None" Width="100%" OnPageIndexChanging="DimissionInfoGV_PageIndexChanging"  OnRowDataBound="DimissionInfoGV_RowDataBound1" >
                                    <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
                                    <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
                                    <AlternatingRowStyle CssClass="table_g" />
                                    <Columns>
                                        <asp:TemplateField >
                                            <ItemTemplate>
                                                <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("Name.Name") %>' CommandName="HiddenPostButtonCommand" runat="server" Text="" style="display: none;"/>
                                            </ItemTemplate><ItemStyle Width="2%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FileCargoID" HeaderText="Id"  Visible="false">
                     
                                            <ItemStyle Width="0%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="资料类型" HeaderStyle-Width="25%">
                                            <ItemTemplate>　<%# Eval("Name.Name") %> </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="Remark" HeaderText="备注" >
                                            <ItemStyle Width="39%" HorizontalAlign="left" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDownLoad" runat="server" CommandArgument='<%# Eval("FileCargoID") %>'
                                                                CommandName='<%# Eval("File") %>' Enabled='<%# Eval("CanDownLoad") %>'  OnCommand="BtnDownLoad_Click" Text="下载"  ></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="8%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnUpdate" runat="server" CommandArgument='<%# Eval("FileCargoID") %>'
                                                                CommandName="BtnUpdateClick"  OnCommand="BtnUpdate_Click" Text="修    改" ></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="8%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("FileCargoID") %>'
                                                                CommandName="BtnDeleteClick"   OnCommand="BtnDelete_Click" Text="删    除"  OnClientClick= " Confirmed = confirm('确定要删除吗？'); return Confirmed; "></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="8%" />
                                        </asp:TemplateField>
              
                                    </Columns>
             
                                    <PagerTemplate>  
                                        <uc1:PageTemplate ID="PageTemplate1" runat="server" />
                                        <%--		<div class="pages">
		    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    上一页</asp:LinkButton>
		    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton" CommandArgument="Next" CommandName="Page"  Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    下一页</asp:LinkButton>
		</div>       --%>                   
                                    </PagerTemplate>
             
             
                                </asp:GridView>
           
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </contenttemplate>
    <triggers>
        <asp:PostBackTrigger ControlID="btnOK" />
        <asp:PostBackTrigger ControlID="FileCargoListGV" />
    </triggers>
</asp:UpdatePanel>