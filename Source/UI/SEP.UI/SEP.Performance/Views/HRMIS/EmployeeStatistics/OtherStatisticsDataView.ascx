<%@ Import namespace="SEP.HRMIS.Model"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OtherStatisticsDataView.ascx.cs" Inherits="SEP.Performance.Views.EmployeeStatistics.OtherStatisticsDataView" %>
<script type="text/javascript">

</script>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td align="center"><table width="100%"  cellpadding="10px" cellspacing="0"  class="linetable">
      <tr>
        <td align="left" class="green1">
          <table width="100%" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10">
            <tr>
              <td>����ͳ������</td>
            </tr> 
            <tr>
              <td>1. Ŀǰ��ְ���� 
                  <asp:Label ID="lbCount" runat="server" Text="0"></asp:Label> ��</td>
            </tr> 
            <tr>
              <td> 2. ���½�������
              <span id="spanEntry" runat="server">
                  <asp:Label ID="lbEntry" runat="server" Text="0"></asp:Label>
                  <div id="divEntry" style="display:none; background-color:#FFFFFF; z-index:10; position:absolute;">
                    <table width="130px" class="linetable_5"  cellpadding="0" cellspacing="0" >
                      <tr>
                        <td>
                             <table width="100%" border="0" cellspacing="0" cellpadding="8">
                               <tr>
                                 <td align="center" valign="top"><table width="98%" border="0" cellpadding="5" style="border-collapse:separate;" cellspacing="6">
                                    <tr>
                                        <td width="97%" class="fonttable_2" align="left" valign="top">
<asp:GridView GridLines="None" Width="100%" ID="gvEntryList" runat="server" AutoGenerateColumns="false" ShowHeader="false">
<HeaderStyle Height="28px" CssClass="headerstyleblue"/>
<RowStyle Height = "28px" CssClass="GridViewRowLink"/>
<AlternatingRowStyle CssClass="table_g" />
    <Columns>
    <asp:TemplateField>                    
                        <ItemTemplate> 
                        </ItemTemplate>
                            <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate> 
                            <%#Eval("Account.Name")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate> 
                            <%#Convert.ToDateTime(Eval("EmployeeDetails.StatisticsTime")).Year == Convert.ToDateTime(Eval("EmployeeDetails.Work.ComeDate")).Year && Convert.ToDateTime(Eval("EmployeeDetails.StatisticsTime")).Month == Convert.ToDateTime(Eval("EmployeeDetails.Work.ComeDate")).Month ? Convert.ToDateTime(Eval("EmployeeDetails.Work.ComeDate")).Month + "/" + Convert.ToDateTime(Eval("EmployeeDetails.Work.ComeDate")).Day : "�ڵ�"%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <ItemTemplate>
                        <asp:LinkButton ID="btnEntryModify" Text="�޸�" OnCommand="btnEntryModify_Click"  
                        CommandName="ResidencePermitModify" runat="server" CommandArgument='<%# Eval("Account.Id")%>'/>
                      </ItemTemplate>
                    </asp:TemplateField>
    </Columns>                
</asp:GridView>
                                        </td>
                                    </tr>
                                   </table>                                             </td>
                               </tr>
                             </table>                                     </td>
                      </tr>
                      </table>
                </div>
              </span>��                
              </td>
            </tr> 
            <tr>
              <td> 3. �����뿪����
              <span id="spanDimission" runat="server">
                  <asp:Label ID="lbDimission" runat="server" Text="0"></asp:Label>
                  <div id="divDimission" style="display:none; background-color:#FFFFFF; z-index:10; position:absolute;">
                    <table width="130px" class="linetable_5"  cellpadding="0" cellspacing="0" >
                      <tr>
                        <td>
                             <table width="100%" border="0" cellspacing="0" cellpadding="8">
                               <tr>
                                 <td align="center" valign="top"><table width="98%" border="0" cellpadding="5" style="border-collapse:separate;" cellspacing="6">
                                    <tr>
                                        <td width="97%" class="fonttable_2" align="left" valign="top">
<asp:GridView GridLines="None" Width="100%" ID="gvDimissionList" runat="server" AutoGenerateColumns="false" ShowHeader="false">
<HeaderStyle Height="28px" CssClass="headerstyleblue"/>
<RowStyle Height = "28px" CssClass="GridViewRowLink"/>
<AlternatingRowStyle CssClass="table_g" />
    <Columns>
    <asp:TemplateField>                    
                        <ItemTemplate> 
                        </ItemTemplate>
                            <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate> 
                            <%#Eval("Account.Name")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate> 
                            <%#Convert.ToDateTime(Eval("EmployeeDetails.StatisticsTime")).AddMonths(1).Year == Convert.ToDateTime(Eval("EmployeeDetails.Work.DimissionInfo.DimissionDate")).Year && Convert.ToDateTime(Eval("EmployeeDetails.StatisticsTime")).AddMonths(1).Month == Convert.ToDateTime(Eval("EmployeeDetails.Work.DimissionInfo.DimissionDate")).Month ? Convert.ToDateTime(Eval("EmployeeDetails.Work.DimissionInfo.DimissionDate")).Month + "/" + Convert.ToDateTime(Eval("EmployeeDetails.Work.DimissionInfo.DimissionDate")).Day : "�ڵ�"%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <ItemTemplate>
                        <asp:LinkButton ID="btnDimissionModify" Text="�޸�" OnCommand="btnDimissionModify_Click"  
                        CommandName="ResidencePermitModify" runat="server" CommandArgument='<%# Eval("Account.Id")%>'/>
                      </ItemTemplate>
                    </asp:TemplateField>
    </Columns>                
</asp:GridView>
                                        </td>
                                    </tr>
                                   </table>                                             </td>
                               </tr>
                             </table>                                     </td>
                      </tr>
                      </table>
                </div>
              </span>��                
              </td>
            </tr> 
            <tr>
              <td> 4. ������ĩ��ְ���� <asp:Label ID="lbMonthLastDay" runat="server" Text="0"></asp:Label> ��</td>
            </tr> 
            <tr>
              <td> 5. ������ְ�� <asp:Label ID="lbDimissionRate" runat="server" Text="0"></asp:Label>%</td>
            </tr> 
            <tr>
              <td> 6. ������ٵ�������
              <span id="spanVacation" runat="server" >
                  <asp:Label ID="lbVacation" runat="server" Text="0"></asp:Label>
                  <div id="divVacation" style="display:none; background-color:#FFFFFF; z-index:10; position:absolute;">
                    <table width="130px" class="linetable_5"  cellpadding="0" cellspacing="0" >
                      <tr>
                        <td>
                             <table width="100%" border="0" cellspacing="0" cellpadding="8">
                               <tr>
                                 <td align="center" valign="top"><table width="98%" border="0" cellpadding="5" cellspacing="6" style="border-collapse:separate;">
                                    <tr>
                                        <td width="97%" class="fonttable_2" align="left" valign="top">
<asp:GridView GridLines="None" Width="100%" ID="gvVacationList" runat="server" AutoGenerateColumns="false" ShowHeader="false">
<HeaderStyle Height="28px" CssClass="headerstyleblue"/>
<RowStyle Height = "28px" CssClass="GridViewRowLink"/>
<AlternatingRowStyle CssClass="table_g" />
    <Columns>
    <asp:TemplateField>                    
                        <ItemTemplate> 
                        </ItemTemplate>
                            <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate> 
                            <%#Eval("Account.Name")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <ItemTemplate>
                        <asp:LinkButton ID="btnVacationModify" Text="�޸�" OnCommand="btnVacationModify_Click"  
                        CommandName="ResidencePermitModify" runat="server" CommandArgument='<%# Eval("Account.Id")%>'/>
                      </ItemTemplate>
                    </asp:TemplateField>
    </Columns>                
</asp:GridView>
                                        </td>
                                    </tr>
                                   </table>                                             </td>
                               </tr>
                             </table>                                     </td>
                      </tr>
                      </table>
                </div>
              </span>��                
              </td>
            </tr> 
            <tr>
              <td> 7. ���¾�ס֤��������
              <span id="spanResidencePermit" runat="server">
                  <asp:Label ID="lbResidencePermit" runat="server" Text="0"></asp:Label>
                  <div id="divResidencePermit" style="display:none; background-color:#FFFFFF; z-index:10; position:absolute;">
                    <table width="130px" class="linetable_5"  cellpadding="0" cellspacing="0" >
                      <tr>
                        <td>
                             <table width="100%" border="0" cellspacing="0" cellpadding="8">
                               <tr>
                                 <td align="center" valign="top"><table width="98%" border="0" cellpadding="5" cellspacing="6" style="border-collapse:separate;">
                                    <tr>
                                        <td width="97%" class="fonttable_2" align="left" valign="top">
<asp:GridView GridLines="None" Width="100%" ID="gvResidencePermitList" runat="server" AutoGenerateColumns="false" ShowHeader="false">
<HeaderStyle Height="28px" CssClass="headerstyleblue"/>
<RowStyle Height = "28px" CssClass="GridViewRowLink"/>
<AlternatingRowStyle CssClass="table_g" />
    <Columns>
    <asp:TemplateField>                    
                        <ItemTemplate> 
                        </ItemTemplate>
                            <ItemStyle Width="2%" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate> 
                            <%#Eval("Account.Name")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate> 
                            <%#Convert.ToDateTime(Eval("EmployeeDetails.ResidencePermits.DueDate")).Month + "/" + Convert.ToDateTime(Eval("EmployeeDetails.ResidencePermits.DueDate")).Day%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <ItemTemplate>
                        <asp:LinkButton ID="btnResidencePermitModify" Text="�޸�" OnCommand="btnResidencePermitModify_Click"  
                        CommandName="ResidencePermitModify" runat="server" CommandArgument='<%# Eval("Account.Id")%>'/>
                      </ItemTemplate>
                    </asp:TemplateField>
    </Columns>                
</asp:GridView>
                                        </td>
                                    </tr>
                                   </table>                                             </td>
                               </tr>
                             </table>                                     </td>
                      </tr>
                      </table>
                </div>
              </span>��                
                </td>
            </tr>
            <tr>
               <td>8. ���³��б��սɷ����� <asp:Label ID="lbCityInsurance" runat="server" Text="0"></asp:Label> ��
               </td>
            </tr> 
            <tr>
               <td>9. ���³����սɷ����� <asp:Label ID="lbTownInsurance" runat="server" Text="0"></asp:Label> ��
               </td>
            </tr>
            <tr>
               <td>10. �����ۺϱ��սɷ����� <asp:Label ID="lbComprehensiveInsurance" runat="server" Text="0"></asp:Label> ��
               </td>
            </tr>
          </table>          
        </td>
      </tr>
    </table></td>
  </tr>
</table>
