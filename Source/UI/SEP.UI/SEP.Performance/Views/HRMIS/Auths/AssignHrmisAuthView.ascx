<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssignHrmisAuthView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.Auths.AssignHrmisAuthView" %>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.autocomplete.js"></script>
<link href="../../CSS/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    /* common styling */
    .childAuth
    {
        padding: 0px 0px 0px 0px;
        height: 28px;
        width: 140px;
        valign: absmiddle;
    }
    /* common styling */
    .checkboxlist li
    {
        float: left;
        width: 150px;
        height: 26px;
    }
</style>
<script type="text/jscript">
    function SelectChildren(ParentID) {
        var ctrlname = "cphCenter_AssignHrmisAuthInfoView1_AssignHrmisAuthView1_";
        var ParentCtrl = document.getElementById(ctrlname + ParentID);
        if (ParentID == "cb1") {
            document.getElementById(ctrlname + "cb101").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb102").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb103").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb104").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb105").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb106").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb107").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb108").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb109").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb1010").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb1011").checked = ParentCtrl.checked;
        }
        else if (ParentID == "cb2") {
            document.getElementById(ctrlname + "cb201").checked = ParentCtrl.checked;
        }
        else if (ParentID == "cb3") {
            document.getElementById(ctrlname + "cb301").checked = ParentCtrl.checked;
        }
        else if (ParentID == "cb4") {
            document.getElementById(ctrlname + "cb401").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb402").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb403").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb404").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb405").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb406").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb407").checked = ParentCtrl.checked;
        }
        else if (ParentID == "cb5") {
            document.getElementById(ctrlname + "cb501").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb502").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb503").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb504").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb505").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb506").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb507").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb508").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb509").checked = ParentCtrl.checked;
        }
        else if (ParentID == "cb6") {
            document.getElementById(ctrlname + "cb601").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb602").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb603").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb604").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb605").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb606").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb607").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb608").checked = ParentCtrl.checked;
        }
        else if (ParentID == "cb7") {
            document.getElementById(ctrlname + "cb701").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb702").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb703").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb704").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb705").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb706").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb707").checked = ParentCtrl.checked;
        }
        else if (ParentID == "cb8") {
            document.getElementById(ctrlname + "cb801").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb802").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb803").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb804").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb805").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb806").checked = ParentCtrl.checked;
        }
        else if (ParentID == "cb9") {
            document.getElementById(ctrlname + "cb901").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb902").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb903").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb904").checked = ParentCtrl.checked;
        }
        else if (ParentID == "cb10") {
            document.getElementById(ctrlname + "cb1001").checked = ParentCtrl.checked;
            document.getElementById(ctrlname + "cb1002").checked = ParentCtrl.checked;
        }
    }

    function SelectParent(ParentID) {
        var ctrlname = "cphCenter_AssignHrmisAuthInfoView1_AssignHrmisAuthView1_";
        var ParentCtrl = document.getElementById(ctrlname + ParentID);
        if (ParentID == "cb1") {
            ParentCtrl.checked =
        document.getElementById(ctrlname + "cb101").checked &&
        document.getElementById(ctrlname + "cb102").checked &&
        document.getElementById(ctrlname + "cb103").checked &&
        document.getElementById(ctrlname + "cb104").checked &&
        document.getElementById(ctrlname + "cb105").checked &&
        document.getElementById(ctrlname + "cb106").checked &&
        document.getElementById(ctrlname + "cb107").checked &&
        document.getElementById(ctrlname + "cb108").checked &&
        document.getElementById(ctrlname + "cb109").checked &&
        document.getElementById(ctrlname + "cb1010").checked &&
        document.getElementById(ctrlname + "cb1011").checked;
        }
        else if (ParentID == "cb2") {
            ParentCtrl.checked =
        document.getElementById(ctrlname + "cb201").checked;
        }
        else if (ParentID == "cb3") {
            ParentCtrl.checked =
        document.getElementById(ctrlname + "cb301").checked;
        }
        else if (ParentID == "cb4") {
            ParentCtrl.checked =
        document.getElementById(ctrlname + "cb401").checked &&
        document.getElementById(ctrlname + "cb402").checked &&
        document.getElementById(ctrlname + "cb403").checked &&
        document.getElementById(ctrlname + "cb404").checked &&
        document.getElementById(ctrlname + "cb405").checked &&
        document.getElementById(ctrlname + "cb406").checked &&
        document.getElementById(ctrlname + "cb407").checked;
        }
        else if (ParentID == "cb5") {
            ParentCtrl.checked =
        document.getElementById(ctrlname + "cb501").checked &&
        document.getElementById(ctrlname + "cb502").checked &&
        document.getElementById(ctrlname + "cb503").checked &&
        document.getElementById(ctrlname + "cb504").checked &&
        document.getElementById(ctrlname + "cb505").checked &&
        document.getElementById(ctrlname + "cb506").checked &&
        document.getElementById(ctrlname + "cb507").checked &&
        document.getElementById(ctrlname + "cb508").checked &&
        document.getElementById(ctrlname + "cb509").checked;
        }
        else if (ParentID == "cb6") {
            ParentCtrl.checked =
        document.getElementById(ctrlname + "cb601").checked &&
        document.getElementById(ctrlname + "cb602").checked &&
        document.getElementById(ctrlname + "cb603").checked &&
        document.getElementById(ctrlname + "cb604").checked &&
        document.getElementById(ctrlname + "cb605").checked &&
        document.getElementById(ctrlname + "cb606").checked &&
        document.getElementById(ctrlname + "cb607").checked &&
        document.getElementById(ctrlname + "cb608").checked;
        }
        else if (ParentID == "cb7") {
            ParentCtrl.checked =
        document.getElementById(ctrlname + "cb701").checked &&
        document.getElementById(ctrlname + "cb702").checked &&
        document.getElementById(ctrlname + "cb703").checked &&
        document.getElementById(ctrlname + "cb704").checked &&
        document.getElementById(ctrlname + "cb705").checked &&
        document.getElementById(ctrlname + "cb706").checked &&
        document.getElementById(ctrlname + "cb707").checked;
        }
        else if (ParentID == "cb8") {
            ParentCtrl.checked =
        document.getElementById(ctrlname + "cb801").checked &&
        document.getElementById(ctrlname + "cb802").checked &&
        document.getElementById(ctrlname + "cb803").checked &&
        document.getElementById(ctrlname + "cb804").checked &&
        document.getElementById(ctrlname + "cb805").checked &&
        document.getElementById(ctrlname + "cb806").checked;
        }
        else if (ParentID == "cb9") {
            ParentCtrl.checked =
        document.getElementById(ctrlname + "cb901").checked &&
        document.getElementById(ctrlname + "cb902").checked &&
        document.getElementById(ctrlname + "cb903").checked &&
        document.getElementById(ctrlname + "cb904").checked;
        }
        else if (ParentID == "cb10") {
            ParentCtrl.checked =
        document.getElementById(ctrlname + "cb1001").checked &&
        document.getElementById(ctrlname + "cb1002").checked;
        }
    }

    function BinGoogledown() {
        $(".txtAccount").autocomplete("../../../Pages/HRMIS/AuthPages/AssignAuthGooldownPage.aspx", { mouseovershow: false });
        $(".txtAccount").result(function (event, data, formatted) { txtAccountChanged(event.target); });
    }
    function txtAccountChanged(th) {
        $(th).next("input").eq(0).trigger("click");
    }
    $(function () {
        BinGoogledown();
    });

</script>
<div id="tbMessage" runat="server" class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    分配权限</div>
<div class="edittable">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="left" style="width: 2%;">
            </td>
            <td align="left" style="width: 8%;">
                帐号
            </td>
            <td align="left" style="width: 41%">
                <asp:TextBox ID="txtAccount" CssClass="txtAccount input1" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Style="display: none;" OnClick="btnSearch_Click" />
            </td>
            <td align="left" style="width: 8%;">
            </td>
            <td align="left" style="width: 41%">
            </td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="确　定" CssClass="inputbt" />
</div>
<div class="linetablediv">
    <table width="100%">
        <tr>
            <td align="left" style="padding: 0px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2" align="left" style="height: 26px; vertical-align: middle;">
                            <strong>
                                <asp:CheckBox ID="cb1" runat="server" Text=" 参数设置" onclick="SelectChildren('cb1');" /></strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="10" style="height: 26px; vertical-align: middle;">
                            &nbsp;
                        </td>
                        <td align="left" valign="top">
                            <ul id="checkboxlist" class="checkboxlist">
                                <li>
                                    <asp:CheckBox ID="cb101" runat="server" Text=" 设置合同类型" onclick="SelectParent('cb1')" /></li>
                                <li>
                                    <asp:CheckBox ID="cb102" runat="server" Text=" 设置请假类型" onclick="SelectParent('cb1')" /></li>
                                <li>
                                    <asp:CheckBox ID="cb103" runat="server" Text=" 设置技能类型" onclick="SelectParent('cb1')" /></li>
                                <li>
                                    <asp:CheckBox ID="cb104" runat="server" Text=" 设置技能" onclick="SelectParent('cb1')" /></li>
                                <li>
                                    <asp:CheckBox ID="cb105" runat="server" Text=" 设置自定义流程" onclick="SelectParent('cb1')" /></li>
                                <li>
                                    <asp:CheckBox ID="cb106" runat="server" Text=" 设置共享联系人" onclick="SelectParent('cb1')" /></li>
                                <li>
                                    <asp:CheckBox ID="cb107" runat="server" Text=" 设置国籍" onclick="SelectParent('cb1')" /></li>
                                <li>
                                    <asp:CheckBox ID="cb108" runat="server" Text=" 设置调休规则" onclick="SelectParent('cb1')" /></li>
                                <li>
                                    <asp:CheckBox ID="cb109" runat="server" Text=" 设置客户信息" onclick="SelectParent('cb1')" /></li>
                                <li>
                                    <asp:CheckBox ID="cb1010" runat="server" Text=" 设置项目信息" onclick="SelectParent('cb1')" /></li>
                                <li>
                                    <asp:CheckBox ID="cb1011" runat="server" Text=" 设置汇率信息" onclick="SelectParent('cb1')" /></li>
                            </ul>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="table_g">
            <td align="left" style="padding: 0px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2" align="left" style="height: 26px; vertical-align: middle;">
                            <strong>
                                <asp:CheckBox ID="cb2" runat="server" Text=" 用户管理" onclick="SelectChildren('cb2');" /></strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="10" style="height: 26px; vertical-align: middle;">
                            &nbsp;
                        </td>
                        <td align="left" valign="top">
                            <ul id="Ul1" class="checkboxlist">
                                <li>
                                    <asp:CheckBox ID="cb201" runat="server" Text=" 分配权限" onclick="SelectParent('cb2')" /></li>
                            </ul>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" class="AssignAuthtablecolor" style="padding: 0px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2" align="left" style="height: 26px; vertical-align: middle;">
                            <strong>
                                <asp:CheckBox ID="cb3" runat="server" Text=" 组织架构管理" onclick="SelectChildren('cb3');" /></strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="10" style="height: 26px; vertical-align: middle;">
                            &nbsp;
                        </td>
                        <td align="left" valign="top">
                            <ul id="Ul2" class="checkboxlist">
                                <li>
                                    <asp:CheckBox ID="cb301" runat="server" Text=" 查询部门历史" onclick="SelectParent('cb3')" /></li>
                            </ul>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="table_g">
            <td align="left" style="padding: 0px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2" align="left" style="height: 26px; vertical-align: middle;">
                            <strong>
                                <asp:CheckBox ID="cb4" runat="server" Text=" 员工管理" onclick="SelectChildren('cb4');" /></strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="10" style="height: 26px; vertical-align: middle;">
                            &nbsp;
                        </td>
                        <td align="left" valign="top">
                            <ul id="Ul4" class="checkboxlist">
                                <li>
                                    <asp:CheckBox ID="cb401" runat="server" Text=" 查询员工" onclick="SelectParent('cb4')" />
                                    <asp:ImageButton ID="ib401" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb402" runat="server" Text=" 查询员工合同" onclick="SelectParent('cb4')" />
                                    <asp:ImageButton ID="ib402" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb403" runat="server" Text=" 查询员工年假" onclick="SelectParent('cb4')" />
                                    <asp:ImageButton ID="ib403" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb404" runat="server" Text="查询员工调休" onclick="SelectParent('cb4')" />
                                    <asp:ImageButton ID="ib404" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb405" runat="server" Text="员工统计" onclick="SelectParent('cb4')" />
                                    <asp:ImageButton ID="ib405" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb406" runat="server" Text="员工高级查询" onclick="SelectParent('cb4')" />
                                    <asp:ImageButton ID="ib406" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb407" runat="server" Text="员工合同高级查询" onclick="SelectParent('cb4')" />
                                    <asp:ImageButton ID="ib407" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                            </ul>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding: 0px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2" align="left" style="height: 26px; vertical-align: middle;">
                            <strong>
                                <asp:CheckBox ID="cb5" runat="server" Text=" 考勤管理" onclick="SelectChildren('cb5');" /></strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="10" style="height: 26px; vertical-align: middle;">
                            &nbsp;
                        </td>
                        <td align="left" valign="top">
                            <ul id="Ul9" class="checkboxlist">
                                <li>
                                    <asp:CheckBox ID="cb501" runat="server" Text=" 设置班别" onclick="SelectParent('cb5')" /></li>
                                <li>
                                    <asp:CheckBox ID="cb502" runat="server" Text=" 设置排班表" onclick="SelectParent('cb5')" />
                                    <asp:ImageButton ID="ib502" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb503" runat="server" Text=" 员工打卡信息" onclick="SelectParent('cb5')" />
                                    <asp:ImageButton ID="ib503" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb504" runat="server" Text=" 查询打卡记录" onclick="SelectParent('cb5')" />
                                    <asp:ImageButton ID="ib504" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb505" runat="server" Text=" 出勤管理" onclick="SelectParent('cb5')" />
                                    <asp:ImageButton ID="ib505" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb506" runat="server" Text=" 日考勤明细" onclick="SelectParent('cb5')" />
                                    <asp:ImageButton ID="ib506" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb507" runat="server" Text=" 考勤统计" onclick="SelectParent('cb5')" />
                                    <asp:ImageButton ID="ib507" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb508" runat="server" Text=" 打卡信息修改日志" onclick="SelectParent('cb5')" />
                                    <asp:ImageButton ID="ib508" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb509" runat="server" Text=" 查询申请记录" onclick="SelectParent('cb5')" />
                                    <asp:ImageButton ID="ib509" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                            </ul>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="table_g">
            <td align="left" style="padding: 0px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2" align="left" style="height: 26px; vertical-align: middle;">
                            <strong>
                                <asp:CheckBox ID="cb6" runat="server" Text=" 薪资管理" onclick="SelectChildren('cb6');" /></strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="10" style="height: 26px; vertical-align: middle;">
                            &nbsp;
                        </td>
                        <td align="left" valign="top">
                            <ul id="Ul3" class="checkboxlist">
                                <li>
                                    <asp:CheckBox ID="cb601" runat="server" Text=" 设置帐套项参数" onclick="SelectParent('cb6')" /></li>
                                <li>
                                    <asp:CheckBox ID="cb602" runat="server" Text=" 设置帐套" onclick="SelectParent('cb6')" /></li>
                                <li>
                                    <asp:CheckBox ID="cb603" runat="server" Text=" 设置税制" onclick="SelectParent('cb6')" /></li>
                                <li>
                                    <asp:CheckBox ID="cb604" runat="server" Text=" 设置员工帐套" onclick="SelectParent('cb6')" />
                                    <asp:ImageButton ID="ib604" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb605" runat="server" Text=" 设置员工福利" onclick="SelectParent('cb6')" />
                                    <asp:ImageButton ID="ib605" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb606" runat="server" Text=" 发薪" onclick="SelectParent('cb6')" />
                                    <asp:ImageButton ID="ib606" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb607" runat="server" Text=" 薪资统计" onclick="SelectParent('cb6')" />
                                    <asp:ImageButton ID="ib607" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb608" runat="server" Text=" 员工薪资统计" onclick="SelectParent('cb6')" />
                                </li>
                            </ul>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding: 0px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2" align="left" style="height: 26px; vertical-align: middle;">
                            <strong>
                                <asp:CheckBox ID="cb7" runat="server" Text=" 绩效管理" onclick="SelectChildren('cb7');" /></strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="10" style="height: 26px; vertical-align: middle;">
                            &nbsp;
                        </td>
                        <td align="left" valign="top">
                            <ul id="Ul7" class="checkboxlist">
                                <li>
                                    <asp:CheckBox ID="cb701" runat="server" Text=" 设置绩效考核项" onclick="SelectParent('cb7')" /></li>
                                <li>
                                    <asp:CheckBox ID="cb702" runat="server" Text=" 设置绩效考核表" onclick="SelectParent('cb7')" /></li>
                                <li>
                                    <asp:CheckBox ID="cb703" runat="server" Text=" 发起绩效考核" onclick="SelectParent('cb7')" />
                                    <asp:ImageButton ID="ib703" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb704" runat="server" Text=" 确认绩效考核" onclick="SelectParent('cb7')" />
                                    <asp:ImageButton ID="ib704" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb705" runat="server" Text=" 查询绩效考核" onclick="SelectParent('cb7')" />
                                    <asp:ImageButton ID="ib705" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb706" runat="server" Text=" 查询合同绩效考核" onclick="SelectParent('cb7')" />
                                    <asp:ImageButton ID="ib706" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb707" runat="server" Text=" 查询年终绩效考核" onclick="SelectParent('cb7')" />
                                    <asp:ImageButton ID="ib707" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <%--<li>
                                    <asp:CheckBox ID="cb706" runat="server" Text=" 查询绩效考核" onclick="SelectParent('cb7')" />
                                    <asp:ImageButton ID="ib706" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>--%>
                            </ul>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="table_g">
            <td align="left" style="padding: 0px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2" align="left" style="height: 26px; vertical-align: middle;">
                            <strong>
                                <asp:CheckBox ID="cb8" runat="server" Text=" 培训管理" onclick="SelectChildren('cb8');" /></strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="10" style="height: 26px; vertical-align: middle;">
                            &nbsp;
                        </td>
                        <td align="left" valign="top">
                            <ul id="Ul11" class="checkboxlist">
                                <li>
                                    <asp:CheckBox ID="cb801" runat="server" Text=" 培训课程管理" onclick="SelectParent('cb8')" />
                                    <asp:ImageButton ID="ib801" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb802" runat="server" Text=" 培训反馈管理" onclick="SelectParent('cb8')" />
                                    <asp:ImageButton ID="ib802" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb803" runat="server" Text=" 设置反馈问题类型" onclick="SelectParent('cb8')" /></li>
                                <li>
                                    <asp:CheckBox ID="cb804" runat="server" Text=" 培训反馈问题管理" onclick="SelectParent('cb8')" />
                                    <asp:ImageButton ID="ib804" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb805" runat="server" Text=" 设置反馈问卷" onclick="SelectParent('cb8')" />
                                    <asp:ImageButton ID="ib805" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb806" runat="server" Text=" 培训申请管理" onclick="SelectParent('cb8')" />
                                    <asp:ImageButton ID="ib806" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                            </ul>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding: 0px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2" align="left" style="height: 26px; vertical-align: middle;">
                            <strong>
                                <asp:CheckBox ID="cb9" runat="server" Text=" 报销管理" onclick="SelectChildren('cb9');" /></strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="10" style="height: 26px; vertical-align: middle;">
                            &nbsp;
                        </td>
                        <td align="left" valign="top">
                            <ul id="Ul10" class="checkboxlist">
                                <li>
                                    <asp:CheckBox ID="cb901" runat="server" Text=" 报销单管理" onclick="SelectParent('cb9')" />
                                    <asp:ImageButton ID="ib901" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb902" runat="server" Text=" 报销查询" onclick="SelectParent('cb9')" />
                                    <asp:ImageButton ID="ib902" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb903" runat="server" Text=" 报销统计" onclick="SelectParent('cb9')" />
                                    <asp:ImageButton ID="ib903" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                                <li>
                                    <asp:CheckBox ID="cb904" runat="server" Text=" 报销单客户维护" onclick="SelectParent('cb9')" />
                                    <asp:ImageButton ID="ib904" runat="server" ImageAlign="absMiddle" ImageUrl="../../../pages/image/arrow1.gif"
                                        OnClick="ib402_Click" /></li>
                            </ul>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="table_g">
            <td align="left" style="padding: 0px;">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2" align="left" style="height: 26px; vertical-align: middle;">
                            <strong>
                                <asp:CheckBox ID="cb10" runat="server" Text=" 数据同步" onclick="SelectChildren('cb10');" /></strong>
                        </td>
                    </tr>
                    <tr>
                        <td width="10" style="height: 26px; vertical-align: middle;">
                            &nbsp;
                        </td>
                        <td align="left" valign="top">
                            <ul id="Ul5" class="checkboxlist">
                                <li>
                                    <asp:CheckBox ID="cb1001" runat="server" Text=" 数据导出" onclick="SelectParent('cb10')" />
                                </li>
                                <li>
                                    <asp:CheckBox ID="cb1002" runat="server" Text=" 数据导入" onclick="SelectParent('cb10')" />
                                </li>
                            </ul>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
