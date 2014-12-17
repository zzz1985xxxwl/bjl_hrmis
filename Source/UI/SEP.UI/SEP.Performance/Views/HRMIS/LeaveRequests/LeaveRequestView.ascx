<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeaveRequestView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.LeaveRequests.LeaveRequestView" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc5" %>
<%@ Register Src="../ChoseEmployee/ChoseEmployeeView.ascx" TagName="ChoseEmployeeView"
    TagPrefix="uc1" %>
<script type="text/javascript">
    var IsNextExecute = true;
    function showdescription(strID) {
        strID = "Item" + strID;
        if (!IsNextExecute) {
            return;
        }
        var currtr = document.getElementById(strID);
        for (i = 0; i < document.all.length; i++) {
            if (document.all(i).tagName.toUpperCase() == "DIV"
        && document.all(i).id != ""
        && document.all(i).id.substring(0, 4) == "Item"
        && document.all(i).id != strID) {
                document.all(i).style.display = "none";
            }
        }
        if (currtr == null) {
            return;
        }
        if (currtr.style.display == "none") {
            currtr.style.display = "inline"; //展开
        }
        else {
            currtr.style.display = "none"; //收缩
        }
    }

    function MailHiddenBtnClick() {
        document.getElementById("cphPage_LeaveRequestView1_btnMailHidden").click();
    }

</script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <contenttemplate>
        <div onclick="javascript:showdescription('');IsNextExecute = true;">
            <div id="divResultMessage" runat="server" class="leftitbor">
                <asp:Label ID="lbResultMessage" runat="server" CssClass="fontred"></asp:Label>
            </div>
            <div class="leftitbor2">
                <asp:Label ID="lbOperationType" runat="server"></asp:Label>
                <asp:HiddenField ID="hfEmployeeID" runat="server" />
                <asp:Label ID="lbID" runat="server" Text="#" Style="display: none;"></asp:Label>
            </div>
            
            <div class="edittable">
                <table width="100%" border="0">
                    <tr>
                        <td align="right" style="width: 2%">
                        </td>
                        <td align="left" style="width: 10%;">
                            员工姓名</td>
                        <td align="left" style="width: 41%">
                            <strong>
                                <asp:Label ID="lbEmployeeName" runat="server"></asp:Label></strong></td>
                        <td align="left" style="width: 10%;">
                            请假时间段</td>
                        <td align="left" style="width: 36%">
                            <strong>
                                <asp:Label ID="lbDate" runat="server"></asp:Label></strong></td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td align="left">
                            请假类型&nbsp;<span class="redstar">*</span></td>
                        <td align="left">
                            <asp:DropDownList ID="ddlAbsentType" runat="server" Width="160px" OnSelectedIndexChanged="ddlAbsentType_SelectedIndexChanged"
                                AutoPostBack="True">
                            </asp:DropDownList>
                            <a href="javascript:showdescription('lblTypeDescription');">
                                <img src="../../image/icon01.gif" align="absmiddle" border="0" /></a>
                            <div id="ItemlblTypeDescription" style="display: none; background-color: #FFFFFF;
                                z-index: 10; position: absolute;">
                                <table onclick="javascript:IsNextExecute = false;" width="450px" class="linetable_3"
                                     cellpadding="0" cellspacing="0" >
                                    <tr>
                                        <td height="28" class="tdbg02bg" >
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="8%" height="23" align="center">
                                                        <img src="../../image/icon04.jpg" /></td>
                                                    <td width="84%" align="left">
                                                        <strong style="color: #FFFFFF">
                                                            <asp:Label ID="lblTypeTitle" runat="server" />详细说明</strong></td>
                                                    <td width="8%" align="center">
                                                        <a href="javascript:showdescription('lblTypeDescription');">
                                                            <img src="../../image/xxx.jpg" border="0" /></a></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="8">
                                                <tr>
                                                    <td height="100" align="center" valign="top">
                                                        <table width="98%" height="100" border="0" cellpadding="5" style="border-collapse:separate;" cellspacing="6">
                                                            <tr>
                                                                <td width="97%" class="fonttable_2" align="left" valign="top" height="100">
                                                                    <asp:Label ID="lblTypeDescription" runat="server" />
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
                            <asp:Label ID="lbTypeMessage" runat="server" CssClass="psword_f"></asp:Label></td>
                        <td align="left">
                            请假时间</td>
                        <td align="left">
                            <asp:Label ID="lbCostTime" runat="server" Style="font-weight: bold; margin-right: 6px;"></asp:Label><asp:Label
                                ID="lbAnnualLeave" runat="server"></asp:Label></td>
                    </tr>
                    <tr id="trRule" runat="server" style="display: none;">
                        <td align="right">
                        </td>
                        <td align="left">
                        </td>
                        <td align="left" colspan="3">
                            注：你目前的工作时间为
                            <asp:Label ID="lblMorningRule" runat="server"></asp:Label>，
                            <asp:Label ID="lblAfternoonTimeRule" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td align="left" valign="top">
                            邮件抄送</td>
                        <td align="left" colspan="3" valign="top">
                            <asp:TextBox runat="server" ID="txtMailCC" CssClass="input1" 
                                Width="85%" onfocus="btnChooseMailCCClick();"></asp:TextBox>
                        </td>
                    </tr>
                                        
                    <tr>
                        <td align="right">
                        </td>
                        <td align="left" valign="top">
                            请假理由&nbsp;<span class="redstar">*</span></td>
                        <td align="left" colspan="3" valign="top">
                            <asp:TextBox runat="server" ID="tbRemark" CssClass="grayborder" Height="91px" TextMode="MultiLine"
                                Width="558px"></asp:TextBox>
                            <asp:Label ID="lbRemarkMessage" runat="server" CssClass="psword_f"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td align="left" colspan="5" valign="top">
                            <div id="tbLeaveRequestItem" runat="server" class="linetable">
                               
                                        <asp:GridView GridLines="None" Width="100%" ID="gvLeaveRequestItemList" runat="server"
                                            AutoGenerateColumns="false" OnRowDataBound="gvLeaveRequestItemList_RowDataBound">
                                            <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                                            <RowStyle Height="28px" CssClass="GridViewRowLink" />
                                            <AlternatingRowStyle CssClass="table_g" />
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnHiddenPostButton" CommandArgument='1' CommandName="HiddenPostButtonCommand"
                                                            runat="server" Text="" Style="display: none;" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="编号">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl" runat="server" Text='<%# Eval("LeaveRequestItemID").ToString() != "-1" ? Eval("LeaveRequestItemID").ToString() : "*"%>'>
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="5%" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="开始时间">
                                                    <ItemTemplate>
                                                        <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tbStart"
                                                            Format="yyyy-MM-dd">
                                                        </ajaxToolKit:CalendarExtender>
                                                        <asp:TextBox ID="tbStart" runat="server" CssClass="input1  fromdate" Width="90%"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="10%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="时">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlStartHour" runat="server" CssClass="fromhour">
                                                            <asp:ListItem>0</asp:ListItem>
                                                            <asp:ListItem>1</asp:ListItem>
                                                            <asp:ListItem>2</asp:ListItem>
                                                            <asp:ListItem>3</asp:ListItem>
                                                            <asp:ListItem>4</asp:ListItem>
                                                            <asp:ListItem>5</asp:ListItem>
                                                            <asp:ListItem>6</asp:ListItem>
                                                            <asp:ListItem>7</asp:ListItem>
                                                            <asp:ListItem>8</asp:ListItem>
                                                            <asp:ListItem>9</asp:ListItem>
                                                            <asp:ListItem>10</asp:ListItem>
                                                            <asp:ListItem>11</asp:ListItem>
                                                            <asp:ListItem>12</asp:ListItem>
                                                            <asp:ListItem>13</asp:ListItem>
                                                            <asp:ListItem>14</asp:ListItem>
                                                            <asp:ListItem>15</asp:ListItem>
                                                            <asp:ListItem>16</asp:ListItem>
                                                            <asp:ListItem>17</asp:ListItem>
                                                            <asp:ListItem>18</asp:ListItem>
                                                            <asp:ListItem>19</asp:ListItem>
                                                            <asp:ListItem>20</asp:ListItem>
                                                            <asp:ListItem>21</asp:ListItem>
                                                            <asp:ListItem>22</asp:ListItem>
                                                            <asp:ListItem>23</asp:ListItem>
                                                        </asp:DropDownList>
                                                        时
                                                    </ItemTemplate>
                                                    <ItemStyle Width="7%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="分">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlStartMinute" runat="server" CssClass="fromminute">
                                                            <asp:ListItem>00</asp:ListItem>
                                                            <asp:ListItem>01</asp:ListItem>
                                                            <asp:ListItem>02</asp:ListItem>
                                                            <asp:ListItem>03</asp:ListItem>
                                                            <asp:ListItem>04</asp:ListItem>
                                                            <asp:ListItem>05</asp:ListItem>
                                                            <asp:ListItem>06</asp:ListItem>
                                                            <asp:ListItem>07</asp:ListItem>
                                                            <asp:ListItem>08</asp:ListItem>
                                                            <asp:ListItem>09</asp:ListItem>
                                                            <asp:ListItem>10</asp:ListItem>
                                                            <asp:ListItem>11</asp:ListItem>
                                                            <asp:ListItem>12</asp:ListItem>
                                                            <asp:ListItem>13</asp:ListItem>
                                                            <asp:ListItem>14</asp:ListItem>
                                                            <asp:ListItem>15</asp:ListItem>
                                                            <asp:ListItem>16</asp:ListItem>
                                                            <asp:ListItem>17</asp:ListItem>
                                                            <asp:ListItem>18</asp:ListItem>
                                                            <asp:ListItem>19</asp:ListItem>
                                                            <asp:ListItem>20</asp:ListItem>
                                                            <asp:ListItem>21</asp:ListItem>
                                                            <asp:ListItem>22</asp:ListItem>
                                                            <asp:ListItem>23</asp:ListItem>
                                                            <asp:ListItem>24</asp:ListItem>
                                                            <asp:ListItem>25</asp:ListItem>
                                                            <asp:ListItem>26</asp:ListItem>
                                                            <asp:ListItem>27</asp:ListItem>
                                                            <asp:ListItem>28</asp:ListItem>
                                                            <asp:ListItem>29</asp:ListItem>
                                                            <asp:ListItem>30</asp:ListItem>
                                                            <asp:ListItem>31</asp:ListItem>
                                                            <asp:ListItem>32</asp:ListItem>
                                                            <asp:ListItem>33</asp:ListItem>
                                                            <asp:ListItem>34</asp:ListItem>
                                                            <asp:ListItem>35</asp:ListItem>
                                                            <asp:ListItem>36</asp:ListItem>
                                                            <asp:ListItem>37</asp:ListItem>
                                                            <asp:ListItem>38</asp:ListItem>
                                                            <asp:ListItem>39</asp:ListItem>
                                                            <asp:ListItem>40</asp:ListItem>
                                                            <asp:ListItem>41</asp:ListItem>
                                                            <asp:ListItem>42</asp:ListItem>
                                                            <asp:ListItem>43</asp:ListItem>
                                                            <asp:ListItem>44</asp:ListItem>
                                                            <asp:ListItem>45</asp:ListItem>
                                                            <asp:ListItem>46</asp:ListItem>
                                                            <asp:ListItem>47</asp:ListItem>
                                                            <asp:ListItem>48</asp:ListItem>
                                                            <asp:ListItem>49</asp:ListItem>
                                                            <asp:ListItem>50</asp:ListItem>
                                                            <asp:ListItem>51</asp:ListItem>
                                                            <asp:ListItem>52</asp:ListItem>
                                                            <asp:ListItem>53</asp:ListItem>
                                                            <asp:ListItem>54</asp:ListItem>
                                                            <asp:ListItem>55</asp:ListItem>
                                                            <asp:ListItem>56</asp:ListItem>
                                                            <asp:ListItem>57</asp:ListItem>
                                                            <asp:ListItem>58</asp:ListItem>
                                                            <asp:ListItem>59</asp:ListItem>
                                                        </asp:DropDownList>
                                                        分
                                                    </ItemTemplate>
                                                    <ItemStyle Width="7%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:Label ID="bb" runat="server" Text=" ～"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="结束时间">
                                                    <ItemTemplate>
                                                        <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="tbEnd"
                                                            Format="yyyy-MM-dd">
                                                        </ajaxToolKit:CalendarExtender>
                                                        <asp:TextBox ID="tbEnd" runat="server" CssClass="input1 todate" Width="90%"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="10%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="时">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlEndHour" CssClass="tohour" runat="server">
                                                            <asp:ListItem>0</asp:ListItem>
                                                            <asp:ListItem>1</asp:ListItem>
                                                            <asp:ListItem>2</asp:ListItem>
                                                            <asp:ListItem>3</asp:ListItem>
                                                            <asp:ListItem>4</asp:ListItem>
                                                            <asp:ListItem>5</asp:ListItem>
                                                            <asp:ListItem>6</asp:ListItem>
                                                            <asp:ListItem>7</asp:ListItem>
                                                            <asp:ListItem>8</asp:ListItem>
                                                            <asp:ListItem>9</asp:ListItem>
                                                            <asp:ListItem>10</asp:ListItem>
                                                            <asp:ListItem>11</asp:ListItem>
                                                            <asp:ListItem>12</asp:ListItem>
                                                            <asp:ListItem>13</asp:ListItem>
                                                            <asp:ListItem>14</asp:ListItem>
                                                            <asp:ListItem>15</asp:ListItem>
                                                            <asp:ListItem>16</asp:ListItem>
                                                            <asp:ListItem>17</asp:ListItem>
                                                            <asp:ListItem>18</asp:ListItem>
                                                            <asp:ListItem>19</asp:ListItem>
                                                            <asp:ListItem>20</asp:ListItem>
                                                            <asp:ListItem>21</asp:ListItem>
                                                            <asp:ListItem>22</asp:ListItem>
                                                            <asp:ListItem>23</asp:ListItem>
                                                        </asp:DropDownList>
                                                        时
                                                    </ItemTemplate>
                                                    <ItemStyle Width="7%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="分">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlEndMinute" CssClass="tominute" runat="server">
                                                            <asp:ListItem>00</asp:ListItem>
                                                            <asp:ListItem>01</asp:ListItem>
                                                            <asp:ListItem>02</asp:ListItem>
                                                            <asp:ListItem>03</asp:ListItem>
                                                            <asp:ListItem>04</asp:ListItem>
                                                            <asp:ListItem>05</asp:ListItem>
                                                            <asp:ListItem>06</asp:ListItem>
                                                            <asp:ListItem>07</asp:ListItem>
                                                            <asp:ListItem>08</asp:ListItem>
                                                            <asp:ListItem>09</asp:ListItem>
                                                            <asp:ListItem>10</asp:ListItem>
                                                            <asp:ListItem>11</asp:ListItem>
                                                            <asp:ListItem>12</asp:ListItem>
                                                            <asp:ListItem>13</asp:ListItem>
                                                            <asp:ListItem>14</asp:ListItem>
                                                            <asp:ListItem>15</asp:ListItem>
                                                            <asp:ListItem>16</asp:ListItem>
                                                            <asp:ListItem>17</asp:ListItem>
                                                            <asp:ListItem>18</asp:ListItem>
                                                            <asp:ListItem>19</asp:ListItem>
                                                            <asp:ListItem>20</asp:ListItem>
                                                            <asp:ListItem>21</asp:ListItem>
                                                            <asp:ListItem>22</asp:ListItem>
                                                            <asp:ListItem>23</asp:ListItem>
                                                            <asp:ListItem>24</asp:ListItem>
                                                            <asp:ListItem>25</asp:ListItem>
                                                            <asp:ListItem>26</asp:ListItem>
                                                            <asp:ListItem>27</asp:ListItem>
                                                            <asp:ListItem>28</asp:ListItem>
                                                            <asp:ListItem>29</asp:ListItem>
                                                            <asp:ListItem>30</asp:ListItem>
                                                            <asp:ListItem>31</asp:ListItem>
                                                            <asp:ListItem>32</asp:ListItem>
                                                            <asp:ListItem>33</asp:ListItem>
                                                            <asp:ListItem>34</asp:ListItem>
                                                            <asp:ListItem>35</asp:ListItem>
                                                            <asp:ListItem>36</asp:ListItem>
                                                            <asp:ListItem>37</asp:ListItem>
                                                            <asp:ListItem>38</asp:ListItem>
                                                            <asp:ListItem>39</asp:ListItem>
                                                            <asp:ListItem>40</asp:ListItem>
                                                            <asp:ListItem>41</asp:ListItem>
                                                            <asp:ListItem>42</asp:ListItem>
                                                            <asp:ListItem>43</asp:ListItem>
                                                            <asp:ListItem>44</asp:ListItem>
                                                            <asp:ListItem>45</asp:ListItem>
                                                            <asp:ListItem>46</asp:ListItem>
                                                            <asp:ListItem>47</asp:ListItem>
                                                            <asp:ListItem>48</asp:ListItem>
                                                            <asp:ListItem>49</asp:ListItem>
                                                            <asp:ListItem>50</asp:ListItem>
                                                            <asp:ListItem>51</asp:ListItem>
                                                            <asp:ListItem>52</asp:ListItem>
                                                            <asp:ListItem>53</asp:ListItem>
                                                            <asp:ListItem>54</asp:ListItem>
                                                            <asp:ListItem>55</asp:ListItem>
                                                            <asp:ListItem>56</asp:ListItem>
                                                            <asp:ListItem>57</asp:ListItem>
                                                            <asp:ListItem>58</asp:ListItem>
                                                            <asp:ListItem>59</asp:ListItem>
                                                        </asp:DropDownList>
                                                        分
                                                    </ItemTemplate>
                                                    <ItemStyle Width="7%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="请假小时">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtCaculate" Text='<%# Eval("CostTime").ToString()%>' runat="server"
                                                            Enabled="false" CssClass="input1 answer" Style="width: 90%" Rows="1" Width="20px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="7%" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="状态">
                                                    <ItemTemplate>
                                                        <asp:Label ID="txtStatus" Text='<%# Eval("Status.Name").ToString()%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="11%" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <img src="../../../Pages/image/loading_js.gif" class="lording" id="imgResultCaculate"
                                                            runat="server" style="display: none" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="4%" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbAddItem" runat="server" OnCommand="lbAddItem_Command" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="4%" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbDeleteItem" runat="server" OnCommand="lbDeleteItem_Command" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="4%" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                  
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Label ID="lblRemind" runat="server" Visible="false"></asp:Label>
            <div class="tablebt">
                <asp:Button ID="BtnOK" OnClick="BtnOK_Click" OnClientClick="return judgeTime();"
                    runat="server" class="inputbt" />
                <asp:Button ID="BtnSubmit" OnClick="BtnSubmit_Click" runat="server" OnClientClick="return judgeTime();"
                    class="inputbt" />
            </div>
            <ajaxToolKit:ModalPopupExtender ID="mpeChooseEmployee" runat="server" BackgroundCssClass="modalBackground"
            PopupControlID="pnlChooseEmployee" TargetControlID="btnChooseEmployeeHidden">
        </ajaxToolKit:ModalPopupExtender>
        <asp:Button ID="btnChooseEmployeeHidden" runat="Server" Style="display: none" />
		<div id="divMPEReimburse" runat="server">        
        <asp:Panel ID="pnlChooseEmployee" runat="server" CssClass="modalBox" Style="display: none;"
            Width="700px">
            <div style="white-space: nowrap; text-align: center;">
                <uc1:ChoseEmployeeView ID="ChoseEmployeeView1" runat="server" />
            </div>
        </asp:Panel>
        </div>

            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc5:progressing id="Progressing1" runat="server"></uc5:progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </contenttemplate>
</asp:UpdatePanel>
<script type="text/javascript">

    function btnChooseMailCCClick() {
        $("#cphCenter_LeaveRequestView1_btnChooseEmployeeHidden").trigger("click");
    }
    function AjaxCount(obj) {
        var eventHandle = $(obj);
        var $tr = $(obj).parent("td").parent("tr");
        var $td = $tr.children("td");
        var $FromDate = $td.children(".fromdate");
        var $FromHour = $td.children(".fromhour");
        var $FromMinute = $td.children(".fromminute");
        var $ToDate = $td.children(".todate");
        var $ToHour = $td.children(".tohour");
        var $ToMinute = $td.children(".tominute");
        var $Answer = $td.children(".answer");
        var $Lording = $td.children(".lording");
        $Lording.attr("src", "../../../Pages/image/loading_js.gif").css("display", "block");
        $.ajax({
            url: "../LeaveRequestPages/CalculateLeaveRequest.aspx",
            cache: false,
            type: "get",
            data: "FromDate=" + $FromDate.val() + "&FromHour=" + $FromHour.val() + "&FromMinute=" + $FromMinute.val() + "&ToDate=" + $ToDate.val() + "&ToHour=" + $ToHour.val() + "&ToMinute=" + $ToMinute.val() + "&AccountID=" + $("#cphCenter_LeaveRequestView1_hfEmployeeID").val() + "&LeaveRequestTypeID=" + $("#cphCenter_LeaveRequestView1_ddlAbsentType").val(),
            success: function (data) {
                if (data == "error") { $Lording.attr("src", "../../../Pages/image/wrong_icon.gif").css("display", "block"); $Answer.val("0"); }
                else { $Lording.css("display", "none"); $Answer.val(data); } AllCount(); GetCountMonth(); judgeTime();
            }
        });
    }
    function GetCountMonth() {
        var fromMax = CountMonth("from", "min"); var toMax = CountMonth("to", "max");
        $("#cphCenter_LeaveRequestView1_lbDate").html(ReplaceCh(fromMax.toLocaleString()) + " ～ " + ReplaceCh(toMax.toLocaleString()));
    }

    function ReplaceCh(tm)
    { tm = tm.replace("年", "-"); tm = tm.replace("月", "-"); tm = tm.replace("日", ""); return tm; }
    function AllCount() {
        var count = 0; $(".answer").each(function () { count = Number(count) + Number($(this).val()); }); $("#cphCenter_LeaveRequestView1_lbCostTime").html(Number(count) + "小时");
    }

    function CountMonth(fot, maxormin) {
        var allDate = new Array();
        $("." + fot + "date").each(function () {
            var $tr = $(this).parent("td").parent("tr");
            var $td = $tr.children("td");
            var fotDate = $(this).val();
            var fotHour = $td.children("." + fot + "hour").val();
            var fotMinute = $td.children("." + fot + "minute").val();
            if (fotDate.isDate()) {
                var dtstring = fotDate.replace(/-/g, "/") + " " + fotHour + ":" + fotMinute + ":00";
                var dt = new Date(dtstring);
                allDate.push(dt);
            }
        });
        var max;
        for (var i = 0; i < allDate.length; i++) {
            if (!max) {
                max = allDate[i];
            }
            if (maxormin == "max") {
                if (max < allDate[i]) {
                    max = allDate[i];
                }
            }
            else
            { if (max > allDate[i]) { max = allDate[i]; } }

        }
        return max;
    }
    String.prototype.isDate = function () {
        var t = this.replace(/-/g, "/");
        var r = t.match(/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/);
        if (r == null)
            return false;
        var d = new Date(r[1], r[3] - 1, r[4]);
        return (d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[4]);
    }
    function judgeTime() {
        var time = true;
        $(".fromdate,.todate").each(function () { if (!($(this).val().isDate())) time = false; });
        if (!time) {
            $("#cphCenter_LeaveRequestView1_divResultMessage").show();
            $("#cphCenter_LeaveRequestView1_lbResultMessage").html("<span class='fontred'>时间格式错误</span>");
        }
        else { $("#cphCenter_LeaveRequestView1_divResultMessage").hide(); }
        return time;
    }
    //    $( function(){
    //        bind();
    //    })
    //    function bind()
    //    {
    //       $(".fromdate").each(function(){AjaxCount(this);});
    //       $(".fromdate,.todate").blur(function(){AjaxCount(this);});
    //       $(".fromhour,.tohour,.fromminute,.tominute").change(function(){AjaxCount(this);});
    //    }
</script>
