<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowDetailViewAttendance.ascx.cs" Inherits="SEP.Performance.Views.SEP.Calendar.ShowDetailViewAttendance" %>
<%@ Register Src="../../PageTemplate.ascx" TagName="PageTemplate" TagPrefix="uc1" %>
<div class="infodetailList" style=" white-space:normal;  background-color:White">
          <table runat="server" id="DetailTable" width="100%" border="0" cellpadding="0" cellspacing="0">
		  	  <tr>
			    <td style="text-align:left;">
                    <asp:Label ID="lbSummary" runat="server" ></asp:Label>
<div id="divAttendanceList" runat="server" visible="false">
                            <asp:GridView ID="grdAttendanceList" runat="server" AllowPaging="True"
                            AutoGenerateColumns="False" GridLines="None" Width="100%" PageSize="5"
                            OnPageIndexChanging="grdAttendanceList_PageIndexChanging" ShowHeader="false"
                                OnRowDataBound="grdAttendanceList_RowDataBound">
                                <HeaderStyle CssClass="headerstyleblue" Height="28px" HorizontalAlign="Center" />
                                <RowStyle Height = "28px" CssClass="GridViewRowLink" HorizontalAlign="Center"/>
                                <AlternatingRowStyle CssClass="table_g" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("RecordID") %>'
                                                CommandName="HiddenPostButtonCommand" runat="server" Text="" Style="display: none;" />
                                        </ItemTemplate>
                                        <ItemStyle Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="进出时间">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOperationTime" runat="server" Text='<%# Eval("IOTime") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="48%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="状态">
                                        <ItemTemplate>
                                          <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("IOStatus").ToString() == "In" ? "进入" : "离开"%>'></asp:Label>  
                                        </ItemTemplate>
                                        <ItemStyle Width="50%" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                </Columns>
                    <PagerTemplate>
                         <uc1:PageTemplate ID="PageTemplate1" runat="server" />		              
                    </PagerTemplate>
                            </asp:GridView>  

             </div>     
			    </td>
			  </tr>
          </table>
</div>