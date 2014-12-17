<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MachineControl.aspx.cs" Inherits="WebControlClient.MachineControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml"><head><title>短信管理</title>
<link href="CSS/style.css" rel="stylesheet" type="text/css" /><style>
.inputtxtl{border:1px solid #7f9db9;padding:4px;}
</style>
</head><body style="margin:5px 10px;">
<form id="form1" runat="server">


<%--基本命令--%>
   
      <div id="Panel1" >
            <table width="100%" class="linetable_3" border="1" cellpadding="0" cellspacing="0" bordercolor="#259517">
              <tr>
                <td height="28" background="image/tdbg02.jpg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="3%" height="23" align="center"><img src="image/icon04.jpg" width="23" height="14" /></td>
                      <td width="61%" align="left"><strong>基本命令 &nbsp; &nbsp;&nbsp; </strong><asp:Label ID="lblBasicMessage" runat="server"></asp:Label></td>
                      <td width="36%" align="left">&nbsp;</td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="8">
                    <tr>
                      <td width="33%" height="50"> 　 
                                <asp:Button ID="btnQuickStart" runat="server" CssClass="inputbt6" OnClick="btnQuickStart_Click" Text="快速开始机器" />
                                <asp:Button ID="btnQuickStop" runat="server" CssClass="inputbt6" OnClick="btnQuickStop_Click" Text="快速终止机器" />
                                <asp:Button ID="btnSystemEventBind" runat="server" Text="系统开始处理信息" CssClass="inputbt6" OnClick="btnSystemEventBind_Click" />
                                <asp:Button ID="btnSystemRemoveSmsEvent" runat="server" Text="系统停止处理信息" CssClass="inputbt6" OnClick="btnSystemRemoveSmsEvent_Click" /></td>
                    </tr>
                    <tr>
                      <td height="57"><table width="400" height="111" border="0" cellpadding="0" cellspacing="5">
                        <tr>
                          <td width="54" align="right"><span id="Label10">发送到：</span></td>
                          <td width="331" align="left"><asp:TextBox ID="txtSendToQueue" CssClass="inputtxtl" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <td align="right"><span id="Label11">内容：</span></td>
                          <td align="left"><asp:TextBox ID="txtSendContextQueue" CssClass="inputtxtl" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <td align="left">&nbsp;</td>
                          <td align="left"><asp:Button ID="btnAddSmsToQueue" runat="server" OnClick="btnAddSmsToQueue_Click" Text="加入发送队列" CssClass="inputbt6" /></td>
                        </tr>
                        
                      </table>
                      <br /></td>
                    </tr>
                </table></td>
              </tr>
        </table>
      </div>
      
      
      <%--高级命令--%>
        <div id="Panel2" >
	
            <table width="100%" class="linetable_3" border="1" cellpadding="0" cellspacing="0" bordercolor="#259517">
              <tr>
                <td height="28" background="image/tdbg02.jpg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="3%" height="23" align="center"><img src="image/icon04.jpg" width="23" height="14" /></td>
                      <td width="61%" align="left"><strong>高级命令 &nbsp; &nbsp;&nbsp; </strong><asp:Label ID="lblGaoJiMessage" runat="server"></asp:Label></td>
                      <td width="36%" align="left">&nbsp;</td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="8">
                    <tr>
                      <td width="33%" height="50"> 　 
                                <asp:Button ID="btnOpenPort" runat="server" Text="打开串口" OnClick="btnOpenPort_Click" CssClass="inputbt6" />
                                <asp:Button ID="btnStartThread" runat="server" Text="打开短信收发线程" OnClick="btnStartThread_Click" CssClass="inputbt6" /></td></tr> 
                            <tr>
                                  <td width="33%" height="50"> 　 
                                <asp:Button ID="btnStopPort" runat="server" Text="关闭串口" OnClick="btnStopPort_Click" CssClass="inputbt6" />
                                <asp:Button ID="btnStopThread" runat="server" Text="关闭短信收发线程" OnClick="btnStopThread_Click" CssClass="inputbt6" /></td></tr> 
                            <tr><td width="33%" height="50"> 　
				<asp:Button ID="btnTestMachine" runat="server" Text="测试机器" OnClick="btnTestMachine_Click" CssClass="inputbt6" />
                                <asp:Label ID="lblTestResult" runat="server"></asp:Label></td>
                    </tr>         
                      </table>
                      </td>
                    </tr>
                </table>
      </div>
      
      <%--调试命令--%>
      <div id="Div2">
            <table width="100%" class="linetable_3" border="1" cellpadding="0" cellspacing="0" bordercolor="#259517">
              <tr>
                <td height="28" background="image/tdbg02.jpg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="3%" align="center" style="height: 23px"><img src="image/icon04.jpg" width="23" height="14" /></td>
                      <td width="61%" align="left" style="height: 23px"><strong>同步收发短信命令 &nbsp; &nbsp;&nbsp; </strong><asp:Label ID="lblTiaoShi" runat="server"></asp:Label></td>
                      <td width="36%" align="left" style="height: 23px">&nbsp;</td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td><table width="400" height="111" border="0" cellpadding="0" cellspacing="5">
                        <tr>
                          <td width="54" align="right"><span id="Span2">发送到：</span></td>
                          <td width="331" align="left"><asp:TextBox ID="txtSendTo" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <td align="right"><span id="Span3">内容：</span></td>
                          <td align="left"><asp:TextBox ID="txtContent" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <td align="left">&nbsp;</td>
                          <td align="left"><asp:Button ID="btnSendSms" runat="server" OnClick="btnSendSms_Click" Text="立即发送" CssClass="inputbt6" /></td>
                        </tr>
			<tr>
                          <td align="left">&nbsp;</td>
                          <td align="left"><asp:Button ID="btnSendMoneyMessage" runat="server" Text="余额查询" OnClick="btnSendMoneyMessage_Click" CssClass="inputbt6" /></td>
                        </tr>
                  	    <tr>
                          <td align="left">&nbsp;</td>
                          <td align="left"><asp:Button ID="btnReceiveAllMessage" runat="server" Text="接受所有短信" OnClick="btnReceiveAllMessage_Click" CssClass="inputbt6" /></td>
                        </tr>
                      </table>

                      </td>
                      </tr>
                      </table>
                         </div>
			
			
	     <%--AT命令--%>
        <div id="Div7" >
	
            <table width="100%" class="linetable_3" border="1" cellpadding="0" cellspacing="0" bordercolor="#259517">
              <tr>
                <td height="28" background="image/tdbg02.jpg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="3%" height="23" align="center"><img src="image/icon04.jpg" width="23" height="14" /></td>
                      <td width="61%" align="left"><strong>AT命令 &nbsp; &nbsp;&nbsp; </strong><asp:Label ID="Label1" runat="server"></asp:Label></td>
                      <td width="36%" align="left">&nbsp;</td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td><table width="400" height="111" border="0" cellpadding="0" cellspacing="5">
                        <tr>
                          <td width="54" align="right"><span id="Span5">等待时间:</span></td>
                          <td width="331" align="left"><asp:TextBox ID="txtWaitMillionSeconds" runat="server">8000</asp:TextBox><span id="Span1"> 毫秒</span></td>
                        </tr>
                        <tr>
                          <td align="right"><span id="Span6">内容：</span></td>
                          <td align="left"><asp:TextBox ID="txtSendCommand" runat="server" TextMode="MultiLine" Height="40px" Width="300px"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <td align="left">&nbsp;</td>
                          <td align="left"><asp:Button ID="btnSendCommand" runat="server" Text="发送命令" OnClick="btnSendCommand_Click" CssClass="inputbt6" /></td>
                        </tr>
			<tr>
                          <td align="left">&nbsp;</td>
                          <td align="left"><asp:TextBox ID="txtCommandReplay" runat="server" Height="60px" ReadOnly="True" Width="300px" TextMode="MultiLine"></asp:TextBox></td>
                          </tr></table></td>
                    </tr>
                </table>
      </div>
  
  
      
      <!--机器状态-->
        <div id="Div3">
	
            <table width="100%" class="linetable_3" border="1" cellpadding="0" cellspacing="0" bordercolor="#259517" style="margin-bottom:5px;">
              <tr>
                <td height="28" background="image/tdbg02.jpg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="3%" height="23" align="center"><img src="image/icon04.jpg" width="23" height="14" /></td>
                      <td width="81%" align="left"><strong>机器状态</strong></td>
                      <td width="16%" align="left">&nbsp;</td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="8">
                    <tr>
                      <td width="33%" align="center" style="height: 90px"><table width="98%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td width="953" height="45" align="left"><asp:Button ID="btnReflashStatus" runat="server" Text="刷新状态" OnClick="btnReflashStatus_Click" CssClass="inputbt6" /></td>
                          </tr>
                          <tr>
                            <td align="left"><img src="image/menuicon.jpg" width="17" height="16" border="0" align="absmiddle" /><span id="Span7">COM口状态：</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblComStatus" runat="server"></asp:Label></td></tr>
                          <tr>
                                <td align="left"><img src="image/menuicon.jpg" width="17" height="16" border="0" align="absmiddle" /><span id="Span9">短信收发线程状态：</span><asp:Label ID="lblWorkThreadStatus" runat="server"></asp:Label></td>
                          </tr>
                          <tr>
                                <td align="left"><img src="image/menuicon.jpg" width="17" height="16" border="0" align="absmiddle" /><span id="Span4">系统开始处理短信：</span><asp:Label ID="lblTheEventHasHandler" runat="server"></asp:Label></td>
                          </tr>
                      </table></td>
                    </tr>
                </table></td>
              </tr>
            </table>
        </div>
      
      
      
      <!--待发送短信队列-->
        <div id="Div4">
            <table width="100%" class="linetable_3" border="1" cellpadding="0" cellspacing="0" bordercolor="#259517" style="margin-bottom:5px;">
              <tr>
                <td height="28" background="image/tdbg02.jpg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="3%" align="center" style="height: 23px"><img src="image/icon04.jpg" width="23" height="14" /></td>
                      <td width="81%" align="left" style="height: 23px"><strong>待发送短信队列 &nbsp; &nbsp;&nbsp; </strong><asp:Label ID="lblWait" runat="server"></asp:Label></td>
                      <td width="16%" align="left" style="height: 23px">&nbsp;</td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="8">
                    <tr>
                      <td width="33%" height="90" align="left"><table width="98%" border="0" cellspacing="0" cellpadding="0">
                        <asp:GridView ID="gvWait" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnPageIndexChanging="gvWait_PageIndexChanging">
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#E3EAEB" />
                <EditRowStyle BackColor="#7C6F57" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
                      </table></td>
                    </tr>
                </table></td>
              </tr>
            </table>
        </div>
      
      
    <!--接受到短信队列-->
        <div id="Div5">
	
            <table width="100%" class="linetable_3" border="1" cellpadding="0" cellspacing="0" bordercolor="#259517" style="margin-bottom:5px;">
              <tr>
                <td height="28" background="image/tdbg02.jpg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="3%" height="23" align="center"><img src="image/icon04.jpg" width="23" height="14" /></td>
                      <td width="81%" align="left"><strong>接受到短信队列 &nbsp; &nbsp;&nbsp; </strong><asp:Label ID="lblReceive" runat="server"></asp:Label></td>
                      <td width="16%" align="left">&nbsp;</td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="8">
                    <tr>
                      <td width="33%" height="90" align="left"><table width="98%" border="0" cellspacing="0" cellpadding="0">
                         <asp:GridView ID="gvReceive" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnPageIndexChanging="gvReceive_PageIndexChanging">
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#E3EAEB" />
                <EditRowStyle BackColor="#7C6F57" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
                      </table></td>
                    </tr>
                </table></td>
              </tr>
            </table>
        </div>
        
        
    <!--发送成功的短信-->
        <div id="Div6">
	
            <table width="100%" class="linetable_3" border="1" cellpadding="0" cellspacing="0" bordercolor="#259517" style="margin-bottom:5px;">
              <tr>
                <td height="28" background="image/tdbg02.jpg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="3%" height="23" align="center"><img src="image/icon04.jpg" width="23" height="14" /></td>
                      <td width="81%" align="left"><strong>发送成功的短信 &nbsp; &nbsp;&nbsp; </strong><asp:Label ID="lblSuccess" runat="server"></asp:Label></td>
                      <td width="16%" align="left">&nbsp;</td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="8">
                    <tr>
                      <td width="33%" height="90" align="left"><table width="98%" border="0" cellspacing="0" cellpadding="0">
                         <asp:GridView ID="gvSuccess" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnPageIndexChanging="gvSuccess_PageIndexChanging">
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#E3EAEB" />
                <EditRowStyle BackColor="#7C6F57" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
                      </table></td>
                    </tr>
                </table></td>
              </tr>
            </table>
        </div>
        
        
        
    <!--发送失败的短信-->
        <div id="Div1">
	
            <table width="100%" class="linetable_3" border="1" cellpadding="0" cellspacing="0" bordercolor="#259517" style="margin-bottom:5px;">
              <tr>
                <td height="28" background="image/tdbg02.jpg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td width="3%" height="23" align="center"><img src="image/icon04.jpg" width="23" height="14" /></td>
                      <td width="81%" align="left"><strong>发送失败的短信 &nbsp; &nbsp;&nbsp; </strong><asp:Label ID="lblFailed" runat="server"></asp:Label></td>
                      <td width="16%" align="left">&nbsp;</td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="8">
                    <tr>
                      <td width="33%" height="90" align="left"><table width="98%" border="0" cellspacing="0" cellpadding="0">
                         <asp:GridView ID="gvFailed" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnPageIndexChanging="gvFailed_PageIndexChanging">
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#E3EAEB" />
                <EditRowStyle BackColor="#7C6F57" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
                      </table></td>
                    </tr>
                </table></td>
              </tr>
            </table>
        </div>
      
        </form>
    </body>
</html>