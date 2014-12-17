<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccountSetView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.PayModuleViews.AccountSetView" %>
<%@ Register Src="../../../Progressing.ascx" TagName="Progressing" TagPrefix="uc1" %>
<link href="../../CSS/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<script language="javascript " type="text/javascript" src="../../Inc/jquery.autocomplete.js"></script>
<script type="text/javascript">
var ImgLoading = "../../image/loading_js.gif";
var ImgRight = "../../image/right_icon.gif";
var ImgWrong = "../../image/wrong_icon.gif";
function showimgStatus(imgResult,status)
{
    var imgResult = document.getElementById(imgResult);
    imgResult.style.display="none";
    if(status=="Wait")
    {
        imgResult.style.display = "block";
        imgResult.src = ImgLoading;
    }
    if(status=="Right")
    {
        imgResult.style.display = "block";
        imgResult.src = ImgRight;
    }
    if(status=="Wrong")
    {
        imgResult.style.display = "block";
        imgResult.src = ImgWrong;
    }
}
function isimgExist(ctrlName)
{
    var rowctrl = document.getElementById(ctrlName);
    if(rowctrl==null)
    {
        return false;
    }
    return true;
}
function postResponseClient(responseString)
{
    var responseInfo=responseString.split("||end")[0];
    var imgResult = responseInfo.split("|")[0];
    if(responseInfo.split("|")[1]=="")
    {
        showimgStatus(imgResult,"Right");
    }
    else
    {
        showimgStatus(imgResult,"Wrong");
    }
}
function postRequestServer(imgResult,paraID,rowindexID, txtCaculate)
{
    if(!isimgExist(imgResult))
    {
        return;
    }
    if(txtCaculate=="")
    {
        showimgStatus(imgResult,"Wrong");
        return;
    }
    showimgStatus(imgResult,"Wait");
    JsAjaxPostRequestServer("AccountSetBackCode.aspx?expression="+encodeURIComponent(txtCaculate)+"&imgResult="+encodeURIComponent(imgResult)+"&paraID="+encodeURIComponent(paraID)+"&rowindexID="+encodeURIComponent(rowindexID)+"&operation=checkitem");
}
function showBindItem(ddlFieldAttribute,BindFieldID,CalculateFieldID,ddlBindItem,txtCaculate,imgResult)
{
    var ddlFieldAttributeCtrl = document.getElementById(ddlFieldAttribute);
    var ddlBindItemCtrl = document.getElementById(ddlBindItem);
    var txtCaculateCtrl = document.getElementById(txtCaculate);
    var imgResultCtrl = document.getElementById(imgResult);
    if(ddlFieldAttributeCtrl.value==CalculateFieldID)
    {
        txtCaculateCtrl.style.display="block";
        imgResultCtrl.style.display="block";
    }
    else
    {
        txtCaculateCtrl.style.display="none";
        imgResultCtrl.style.display="none";
    }
    if(ddlFieldAttributeCtrl.value==BindFieldID)
    {
        ddlBindItemCtrl.style.display="block";
    }
    else
    {
        ddlBindItemCtrl.style.display="none";
    }
}
function BindGoogleDownAccountSetPara()
{
    $(".AccountSetParaInfo").autocomplete("AccountSetBackCode.aspx?operation=googledownAccountSetParaInfo");
    $(".AccountSetParaInfo").result(function(event, data, formatted) {btntxtAccountSetParaChangeClick(event.target);});
}
function btntxtAccountSetParaChangeClick(th)
{
  $(th).next().val($(th).val());
  $(th).next().trigger("click");
}
</script>
<script type="text/javascript" src="../../../../Pages/Inc/JsAjax.js">
</script>
<%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<div id="tbMessage" runat="server" class="leftitbor" >
			<asp:Label ID="lblMessage" runat="server" CssClass = "fontred"></asp:Label>
	   </div>
<div class="leftitbor2" >
<asp:Label ID="lblOperationTitle" runat="server">
		      </asp:Label>
		</div>
  <div class="nolinetablediv">
	<table id = "tbAccountSetParaView" runat="server"  width="100%" border="1" cellpadding="10" cellspacing="0" class="linetable" style=" border-color:#bcbcbc">
	<tr>
        <td align="center">
          <table width="100%" height="56px" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10">
            <tr>
              <td width="1%" align="right" ></td>
              <td align="left" style="width: 10%" >
                  帐套名称 &nbsp;<span class = "redstar">*</span></td>
              <td align="left" colspan="3" >
              <asp:TextBox  runat="server" ID="txtName" Width="60%" class="input1"></asp:TextBox>&nbsp;&nbsp;<asp:Label ID="lblNameMsg" runat="server" CssClass="psword_f"></asp:Label> </td> 
            </tr>  
            <tr>  
              <td width="1%" align="right" ></td>
              <td align="left" >
                  帐套描述</td>
              <td align="left" colspan="3" >
              <asp:TextBox  runat="server" ID="txtDescrition" Width="60%" class="grayborder" Height="61px" TextMode="MultiLine"></asp:TextBox>
			  </td>
			</tr> 
            <tr>
              <td width="1%" align="right" ></td>
                <td align="left" colspan="5" valign="top">
        <table id="tbAccountSetItem" runat="server" width="100%"  cellpadding="0" cellspacing="0"  class="linetable">
            <tr>
                <td>
                    <asp:GridView  GridLines="None" Width="100%" ID="gvAccountSetItemList" runat="server" AutoGenerateColumns="false"
                    OnRowDataBound="gvAccountSetItemList_RowDataBound">
            <HeaderStyle Height="28px" CssClass="headerstyleblue"/>
            <RowStyle Height = "28px" CssClass="GridViewRowLink"/>
            <AlternatingRowStyle CssClass="table_g" />
                <Columns>
                                <asp:TemplateField>
　　　　　　　　　　<ItemTemplate>
　　　　　　　　　　　　<asp:Button ID="btnHiddenPostButton" CommandArgument='1' CommandName="HiddenPostButtonCommand" runat="server" Text="" style=" display:none;"/>
　　　　　　　　　　</ItemTemplate>
                                        <ItemStyle Width="0%" />
                                </asp:TemplateField> 
                                <asp:TemplateField HeaderText="NO.">
                                    <ItemTemplate> 
                                    <asp:Label ID="lbl" runat="server">
<%# Eval("AccountSetPara.AccountSetParaID").ToString()!="-1"? Eval("ParameterNameTitle")+Eval("AccountSetPara.AccountSetParaID").ToString():"*"%>
                                    </asp:Label>
                                    </ItemTemplate>
                                        <ItemStyle Width="5%" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="帐套参数">
                                    <ItemTemplate> 
                                        <asp:TextBox ID="txtAccountSetPara" CssClass="input1 AccountSetParaInfo" AutoPostBack="true" runat="server" Width="92%" OnTextChanged="txtAccountSetPara_OnTextChanged"></asp:TextBox>
                                        <asp:Button ID="btntxtAccountSetPara" runat="server" Text="Button" Style=" display:none;"  />
                                    </ItemTemplate>
                                        <ItemStyle Width="14%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="数据类型">
                                    <ItemTemplate> 
                                        <asp:DropDownList ID="ddlFieldAttribute" Width="95%" runat="server"></asp:DropDownList>
                                    </ItemTemplate>
                                        <ItemStyle Width="12%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="计算公式/绑定值">
                                    <ItemTemplate> 
                                    <asp:TextBox ID = "txtCaculate" runat="server" CssClass="grayborder" style="width:98%" TextMode="MultiLine" Rows="1"></asp:TextBox>
                                    <asp:DropDownList ID = "ddlBindItem"  runat="server" Width="50%"></asp:DropDownList>
                                    </ItemTemplate>
                                        <ItemStyle Width="38%" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate> 
                                    <img src="../../../../Pages/image/wrong_icon.gif" id="imgResult" runat="server" style="display:none"/>
                                    </ItemTemplate>
                                    <ItemStyle Width="3%" HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="尾数舍入">
                                    <ItemTemplate> 
                                        <asp:DropDownList ID="ddlMantissaRound" Width="95%" runat="server"></asp:DropDownList> 
                                    </ItemTemplate>
                                        <ItemStyle Width="16%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                  <ItemTemplate>
                       <asp:LinkButton ID="lbAddItem" runat="server" OnCommand="lbAddItem_Command" />
                                  </ItemTemplate>
                                        <ItemStyle Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                  <ItemTemplate>
                       <asp:LinkButton ID="lbDeleteItem" runat="server" OnCommand="lbDeleteItem_Command"/>
                                  </ItemTemplate>
                                        <ItemStyle Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                  <ItemTemplate>
                       <asp:LinkButton ID="lbUpItem" runat="server"  OnCommand="lbUpItem_Command" />
                                  </ItemTemplate>
                                        <ItemStyle Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                  <ItemTemplate>
                       <asp:LinkButton ID="lbDownItem" runat="server"  OnCommand="lbDownItem_Command" />
                                  </ItemTemplate>
                                        <ItemStyle Width="3%" />
                                </asp:TemplateField>
                </Columns>                
            </asp:GridView>
                </td>
            </tr>
        </table>
                </td>
			  </tr>

          </table>
		  </td>
      </tr>     
      </table>
    </div>
 <div class="linetablediv">
    <table width="100%" cellspacing="0" cellpadding="0" >
      <tr>
        <td class="green2"><table width="98%" border="0" cellpadding="10" cellspacing="0" style="margin:8px;8px;8px;8px">
          <tr>
            <td align="left"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td colspan="2" align="left" valign="top"><strong>公式说明</strong>(详见用户手册)：</td>
                </tr>
                <tr>
                  <td width="2%" align="left" valign="top"><p>&nbsp;</p></td>
                  <td width="98%" align="left" valign="top"><p>变量：即编号A1 A2 ... A48 ... <br />
                    表达式：由数字、变量和符号组成，允许的符号有+ - * / () , &gt;= &gt; &lt; &lt;= ==<br />
                    函数：<br />
                    If(X,Y,Z)：如果表达式X成立，那么结果等于Y，否则结果等于Z。<br />
                    Range(X,Y,Z)：在有效范围内计算表达式X，其中Y,Z分别表示范围的上限（下限）和下限（上限）<br />
                    TaxWithPoint(X,Y)：根据设定的起征点计算个税，X表示税前收入，Y表示起征点<br />
                    Tax(X)：计算个税，X表示税前收入<br />
                    AnnualBonusTax(X,Y)：计算年终奖的个税，X表示起征点，Y表示当年年终奖金<br />
                    ForeignTax(X)：计算外籍人员个税，X表示税前收入<br />
                    AnnualBonusForeignTax(X,Y)：计算外籍人员年终奖的个税，X表示起征点，Y表示当年年终奖金<br />
                    IsSalaryEndDateMonthEquel(X)：判断发薪月份是否是X月。例如：发薪时间是2009-12-21--2010-1-20，IsSalaryEndDateMonthEquel(2)则返回0，IsSalaryEndDateMonthEquel(1)则返回1
                    <br />
                    DoubleSalary(X)：计算双薪，X表示帐套参数ID，获得去年X的平均值。例如：A34表示税前工资，则DoubleSalary(34)表示计算员工去年税前工资的平均值</p></td>
                </tr>
            </table></td>
          </tr>
        </table></td>
      </tr>
    </table> </div>
<div class="tablebt">
		   <asp:Button  Text="确  定" ID="btnOK" OnClientClick="AbortxmlHttp();" runat="server" class="inputbt" OnClick="btnOK_Click"/>
           <asp:Button  Text="取　消" ID="btnCancel" runat="server" class="inputbt" OnClick="btnCancel_Click"/>
           <asp:Button  Text="复制帐套" ID="btnCopy" runat="server" class="inputbt" OnClick="btnCopy_Click"/>
           <asp:Button  Text="粘贴帐套" ID="btnPaste" runat="server" class="inputbt" OnClick="btnPaste_Click" OnClientClick="Confirmed = confirm('此操作会覆盖当前帐套信息，确定要粘贴吗？'); return Confirmed;"/>
       </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
<uc1:Progressing ID="Progressing1" runat="server" />
            </ProgressTemplate>
        </asp:UpdateProgress>
<img src="../../image/add.gif" id="imgHide" style="display:none" onload="BindGoogleDownAccountSetPara();"/>        
</ContentTemplate>
</asp:UpdatePanel>
