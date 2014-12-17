<%@ Control Language="C#" AutoEventWireup="true" Codebehind="AddTemplateItemView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.AssessManagement.AddTemplateItemView" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div id="tbMessage" runat="server" class="leftitbor">
            <asp:Label ID="lblMessage" runat="server" Text="" CssClass="font14b"/>
        </div>
        <div class="leftitbor2">
            <asp:Label ID="lblTilte" runat="server" Text=""></asp:Label>
        </div>
        <%--<div class="linetabledivbg">
            <table width="100%" height="56" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10">--%>
        <div class="edittable">
            <table width="100%" border="0"> 
               <tr>
                    <td align="right" style="width: 2%;">
                    </td>
                    <td width="10%" align="left">
                        ָ��������&nbsp;<span class="redstar">*</span>&nbsp;</td>
                    <td align="left" style="width: 740px">
                        <asp:TextBox ID="txtQuestion" runat="server" CssClass="input1" size="28" Width="490px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
                            ID="lblNullMessage" runat="server" CssClass="psword_f"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" style="width: 2%;">
                    </td>
                      <td width="10%" align="left">
                        ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="redstar">*</span>&nbsp;</td>
                    <td align="left" >
                         <asp:DropDownList ID="ddlItemType" runat="server" Width="496px"  AutoPostBack="true"  OnSelectedIndexChanged="rbItemType_SelectedIndexChanged">
                             <asp:ListItem>ѡ����</asp:ListItem>
                             <asp:ListItem>������</asp:ListItem>
                             <asp:ListItem>�����</asp:ListItem>
                             <asp:ListItem>��ʽ��</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                </tr>
               
                <tr>
                    <td align="right" style="width: 2%">
                    </td>
                    <td width="10%" align="left">
                        ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="redstar">*</span>&nbsp;</td>
                    <td align="left" style="width: 740px">
                        <asp:DropDownList ID="listClassfication" runat="server" Width="496px">
                        </asp:DropDownList></td>
                </tr>
            </table>
            <asp:Panel ID="PanelOption" runat="server">
            <table width="100%" border="0">
                    <tr>
                        <td align="right" style="width: 2%">
                        </td>
                        <td width="10%" align="left">
                            ѡ&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��(100')&nbsp;&nbsp;<span class="redstar">*</span>&nbsp;</td>
                        <td align="left" style="width: 740px">
                            <asp:TextBox ID="txtOption5" runat="server" CssClass="input1" size="28" Width="490px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
                                ID="lblOptionMessage5" runat="server" Text="" CssClass="psword_f"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 2%;">
                        </td>
                        <td width="10%" align="left">
                            ѡ&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��(80')&nbsp;&nbsp;<span class="redstar">*</span>&nbsp;</td>
                        <td align="left" style="width: 740px">
                            <asp:TextBox ID="txtOption4" runat="server" CssClass="input1" size="28" Width="490px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
                                ID="lblOptionMessage4" runat="server" Text="" CssClass="psword_f"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 2%">
                        </td>
                        <td width="10%" align="left">
                            ѡ&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��(60')&nbsp;&nbsp;<span class="redstar">*</span>&nbsp;</td>
                        <td align="left" style="width: 740px">
                            <asp:TextBox ID="txtOption3" runat="server" CssClass="input1" size="28" Width="490px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
                                ID="lblOptionMessage3" runat="server" Text="" CssClass="psword_f"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 2%">
                        </td>
                        <td width="10%" align="left">
                            ѡ&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��(40')&nbsp;&nbsp;<span class="redstar">*</span>&nbsp;</td>
                        <td align="left" style="width: 740px">
                            <asp:TextBox ID="txtOption2" runat="server" CssClass="input1" size="28" Width="490px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
                                ID="lblOptionMessage2" runat="server" Text="" CssClass="psword_f"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 2%">
                        </td>
                        <td width="10%" align="left">
                            ѡ&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��(20')&nbsp;&nbsp;<span class="redstar">*</span>&nbsp;</td>
                        <td align="left" style="width: 740px">
                            <asp:TextBox ID="txtOption1" runat="server" CssClass="input1" size="28" Width="490px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
                                ID="lblOptionMessage1" runat="server" Text="" CssClass="psword_f"></asp:Label></td>
                    </tr>
                    
                </table>
            </asp:Panel>
            <asp:Panel ID="PanelDaFen" runat="server"  style="display:none;">
                <table width="100%" border="0">
                    <tr>
                        <td align="right" style="width: 2%"></td>
                         <td width="10%" align="left">
                         ��ַ�Χ&nbsp;&nbsp;<span class="redstar">*</span>&nbsp;</td>
                         <td align="left" ><asp:TextBox ID="txtMin" runat="server" CssClass="input1"  Width="80px"></asp:TextBox> -- <asp:TextBox ID="txtMax" runat="server" CssClass="input1"  Width="80px"></asp:TextBox>
                         <asp:Label ID="lbMinMaxError" runat="server" Text="" CssClass="psword_f"></asp:Label></td>
                    </tr>
                   
                </table>
            </asp:Panel>
            <asp:Panel ID="PanelFamula" runat="server"  style="display:none;">
                <table width="100%" border="0">
                    <tr>
                        <td align="right" style="width: 2%"></td>
                         <td width="10%" align="left">
                         ��ʽ&nbsp;&nbsp;<span class="redstar">*</span>&nbsp;</td>
                         <td align="left" ><asp:TextBox ID="txtFormula" onblur="checkformula(this);"  CssClass="input1"  runat="server" Width="488px"></asp:TextBox>
                         &nbsp;<img  id="checkimg"  style=" display:none" /> <asp:Label ID="lblFormula" runat="server" Text="" CssClass="psword_f"></asp:Label></td>
                    </tr>
                   <tr>
                    <td align="right" style="width: 2%"></td>
                         <td width="10%" align="left"></td>
                   <td align="left">
                   <div class="linetablediv green2" style="width:492px;margin:0;">
                     <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td colspan="2" align="left" valign="top"><strong>��ʽ</strong>��</td>
                </tr>
                <tr>
                  <td width="2%" align="left" valign="top"><p>&nbsp;</p></td>
                  <td width="98%" align="left" valign="top"><p><%=FormulaSummary%><br />
                 </p></td>
                </tr>
                
                <tr>
                  <td colspan="2" align="left" valign="top"><strong>��ʽ˵��</strong>(����û��ֲ�)��</td>
                </tr>
                <tr>
                  <td width="2%" align="left" valign="top"><p>&nbsp;</p></td>
                  <td width="98%" align="left" valign="top"><p>
                    ��ʽȡֵ��Χ������ʱ��μ���<br />
                    �����������A1 A2 ... A48 ... <br />
                    ���ʽ�������֡������ͷ�����ɣ�����ķ�����+ - * / () , &gt;= &gt; &lt; &lt;= ==<br />
                    ������<br />
                    If(X,Y,Z)��������ʽX��������ô�������Y������������Z��<br />
                    Range(X,Y,Z)������Ч��Χ�ڼ�����ʽX������Y,Z�ֱ��ʾ��Χ�����ޣ����ޣ������ޣ����ޣ�</p></td>
                </tr>
             </table>
                    </div>
                  </td>
                   </tr>
                   
                </table>
            </asp:Panel>
            <table width="100%" border="0">
               <tr>
                    <td align="right" style="width: 2%; height: 134px;">
                    </td>
                    <td width="10%" align="left" style="height: 134px">
                        ˵&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��</td>
                    <td align="left" valign="top" colspan="3" style="height: 134px">
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Columns="58"  CssClass="grayborder" 
                            Rows="8" Width="490px" /></td>
                </tr>
          </table>
            <table width="100%" height="56" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10">
                <tr>
                    <td align="right" style="width: 2%">
                    </td>
                    <td align="right">
                        &nbsp;</td>
                    <td style="width: 740px" align="left">
                        <asp:CheckBox ID="chkItemType" runat="server" />&nbsp;&nbsp;������Դ��</td>
                    <td align="left">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <div class="tablebt">
            <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="ȷ����" CssClass="inputbt" />
            <asp:Button ID="btnCancle" runat="server" OnClick="btnCancle_Click1" Text="ȡ����" CssClass="inputbt" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<script type="text/javascript">
function checkformula(txtbox)
{
    $("#checkimg").attr("src","../../../Pages/image/loading_js.gif").css("display","inline");
    $.ajax({
       url:"CheckFormula.aspx",
       cache: false,
       type:"get", 
       data: "formula="+encodeURIComponent($(txtbox).val()),          
       success:function(data){ 
           if(data=="error"){$("#checkimg").attr("src","../../../Pages/image/wrong_icon.gif").css("display","inline");}
           else{$("#checkimg").attr("src","../../../Pages/image/right_icon.gif").css("display","inline");}
          }
       });
}
</script>

