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
                        指标项描述&nbsp;<span class="redstar">*</span>&nbsp;</td>
                    <td align="left" style="width: 740px">
                        <asp:TextBox ID="txtQuestion" runat="server" CssClass="input1" size="28" Width="490px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
                            ID="lblNullMessage" runat="server" CssClass="psword_f"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" style="width: 2%;">
                    </td>
                      <td width="10%" align="left">
                        类&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;型&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="redstar">*</span>&nbsp;</td>
                    <td align="left" >
                         <asp:DropDownList ID="ddlItemType" runat="server" Width="496px"  AutoPostBack="true"  OnSelectedIndexChanged="rbItemType_SelectedIndexChanged">
                             <asp:ListItem>选择项</asp:ListItem>
                             <asp:ListItem>开放项</asp:ListItem>
                             <asp:ListItem>打分项</asp:ListItem>
                             <asp:ListItem>公式项</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                </tr>
               
                <tr>
                    <td align="right" style="width: 2%">
                    </td>
                    <td width="10%" align="left">
                        分&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;类&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="redstar">*</span>&nbsp;</td>
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
                            选&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;项(100')&nbsp;&nbsp;<span class="redstar">*</span>&nbsp;</td>
                        <td align="left" style="width: 740px">
                            <asp:TextBox ID="txtOption5" runat="server" CssClass="input1" size="28" Width="490px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
                                ID="lblOptionMessage5" runat="server" Text="" CssClass="psword_f"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 2%;">
                        </td>
                        <td width="10%" align="left">
                            选&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;项(80')&nbsp;&nbsp;<span class="redstar">*</span>&nbsp;</td>
                        <td align="left" style="width: 740px">
                            <asp:TextBox ID="txtOption4" runat="server" CssClass="input1" size="28" Width="490px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
                                ID="lblOptionMessage4" runat="server" Text="" CssClass="psword_f"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 2%">
                        </td>
                        <td width="10%" align="left">
                            选&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;项(60')&nbsp;&nbsp;<span class="redstar">*</span>&nbsp;</td>
                        <td align="left" style="width: 740px">
                            <asp:TextBox ID="txtOption3" runat="server" CssClass="input1" size="28" Width="490px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
                                ID="lblOptionMessage3" runat="server" Text="" CssClass="psword_f"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 2%">
                        </td>
                        <td width="10%" align="left">
                            选&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;项(40')&nbsp;&nbsp;<span class="redstar">*</span>&nbsp;</td>
                        <td align="left" style="width: 740px">
                            <asp:TextBox ID="txtOption2" runat="server" CssClass="input1" size="28" Width="490px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
                                ID="lblOptionMessage2" runat="server" Text="" CssClass="psword_f"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 2%">
                        </td>
                        <td width="10%" align="left">
                            选&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;项(20')&nbsp;&nbsp;<span class="redstar">*</span>&nbsp;</td>
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
                         打分范围&nbsp;&nbsp;<span class="redstar">*</span>&nbsp;</td>
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
                         公式&nbsp;&nbsp;<span class="redstar">*</span>&nbsp;</td>
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
                  <td colspan="2" align="left" valign="top"><strong>公式</strong>：</td>
                </tr>
                <tr>
                  <td width="2%" align="left" valign="top"><p>&nbsp;</p></td>
                  <td width="98%" align="left" valign="top"><p><%=FormulaSummary%><br />
                 </p></td>
                </tr>
                
                <tr>
                  <td colspan="2" align="left" valign="top"><strong>公式说明</strong>(详见用户手册)：</td>
                </tr>
                <tr>
                  <td width="2%" align="left" valign="top"><p>&nbsp;</p></td>
                  <td width="98%" align="left" valign="top"><p>
                    公式取值范围按考评时间段计算<br />
                    变量：即编号A1 A2 ... A48 ... <br />
                    表达式：由数字、变量和符号组成，允许的符号有+ - * / () , &gt;= &gt; &lt; &lt;= ==<br />
                    函数：<br />
                    If(X,Y,Z)：如果表达式X成立，那么结果等于Y，否则结果等于Z。<br />
                    Range(X,Y,Z)：在有效范围内计算表达式X，其中Y,Z分别表示范围的上限（下限）和下限（上限）</p></td>
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
                        说&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;明</td>
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
                        <asp:CheckBox ID="chkItemType" runat="server" />&nbsp;&nbsp;人力资源项</td>
                    <td align="left">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <div class="tablebt">
            <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="确　定" CssClass="inputbt" />
            <asp:Button ID="btnCancle" runat="server" OnClick="btnCancle_Click1" Text="取　消" CssClass="inputbt" />
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

