<%@ Import Namespace="SEP.HRMIS.Model" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReimburseView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.Reimburse.ReimburseView" %>
<div id="tbMessage" runat="server" class="leftitbor">
    <asp:Label ID="lblMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    <asp:Label ID="lblOperation" runat="server">  
    </asp:Label>
</div>
<%--<div class="linetabledivbg">
 <table width="100%" height="56" border="0" cellpadding="0" style="border-collapse:separate;" cellspacing="10">--%>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td width="2%" align="right" style="height: 24px">
            </td>
            <td width="10%" align="left" style="height: 24px">
                ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��
            </td>
            <td width="34%" align="left" style="height: 24px">
                <asp:TextBox runat="server" ID="txtID" CssClass="input1" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td width="14%" align="left" style="height: 24px">
                ����ʱ��
            </td>
            <td width="40%" align="left" style="height: 24px" colspan="2">
                <asp:TextBox runat="server" ID="dtpApplyDate" CssClass="input1"></asp:TextBox>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd"
                    TargetControlID="dtpApplyDate">
                </ajaxToolKit:CalendarExtender>
                <asp:Label ID="lblApplyDateMsg" runat="server" CssClass="psword_f"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 24px">
            </td>
            <td align="left" style="height: 24px">
                ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;��
            </td>
            <td align="left" style="height: 24px">
                <asp:TextBox runat="server" ID="txtDepartment" CssClass="input1" ReadOnly="True"></asp:TextBox>
            </td>
            <td align="left" style="height: 24px">
                ��&nbsp;&nbsp;��&nbsp;&nbsp;��
            </td>
            <td align="left" style="height: 24px" colspan="2">
                <asp:TextBox runat="server" ID="txtApplierName" CssClass="input1" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 24px">
            </td>
            <td align="left" style="height: 24px">
                ��������
            </td>
            <td align="left" style="height: 24px">
                <asp:DropDownList ID="ddlReimburseCategories" runat="server" Width="150px" AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td align="left" style="height: 24px">
                ��������<span class="redstar">*</span>
            </td>
            <td align="left" style="height: 24px" colspan="2">
                <asp:TextBox runat="server" ID="txtPaperCount" CssClass="input1"></asp:TextBox>
                <asp:Label ID="lblPaperCountMsg" runat="server" CssClass="psword_f"></asp:Label>
            </td>
        </tr>
        <tr id="trDestinations" runat="server">
            <td align="right" style="height: 24px">
            </td>
            <td align="left" style="height: 24px">
                ����ص�<span class="redstar">*</span>
            </td>
            <td align="left" style="height: 24px" colspan="4">
                <asp:TextBox runat="server" ID="txtDestinations" CssClass="input1"></asp:TextBox>
                <asp:Label ID="lblDestinationsMsg" runat="server" CssClass="psword_f"></asp:Label>
            </td>
        </tr>
        <tr id="trProject" runat="server">
            <td align="right" style="height: 24px">
            </td>
            <td align="left" style="height: 24px">
                ������Ŀ<span class="redstar">*</span>
            </td>
            <td align="left" style="height: 24px"  colspan="4">
                <asp:TextBox ID="txtProjectCode" runat="server" CssClass="input1"
                    OnTextChanged="txtProjectCode_TextChanged" AutoPostBack="true"></asp:TextBox>
                 <asp:Label ID="lblProjectName" runat="server"></asp:Label><asp:HiddenField ID="txtProjectID"  runat="server" />
                <asp:Label ID="lblProject" runat="server" CssClass="psword_f"></asp:Label>
                <br />
                ����д��Ŀ��ţ���M012345�����ϵͳ�޷����ݱ�ż��أ����������Ա��������ϵ��</td>

        </tr>
        <tr id="trDate" runat="server">
            <td align="right" style="height: 24px">
            </td>
            <td runat="server" align="left" id="tdOutCityDays">
                ��������
            </td>
            <td align="left">
                <asp:TextBox runat="server" ID="txtOutCityDays" CssClass="input1" Enabled="false"></asp:TextBox>
                <asp:Label ID="lbOutCityDays" runat="server" CssClass="psword_f"></asp:Label>
            </td>
            <td runat="server" align="left" id="tdOutCityAllowance">
                �����
            </td>
            <td align="left" colspan="2">
                <asp:TextBox runat="server" ID="txtOutCityAllowance" CssClass="input1" Enabled="false"></asp:TextBox>
                <asp:Label ID="lbOutCityAllowance" runat="server" CssClass="psword_f"></asp:Label>
            </td>
        </tr>
         <tr>
            <td>
            </td>
            <td align="left" style="height: 24px">
                ˵��
            </td>
            <td align="left" colspan="4">
                <asp:TextBox runat="server" ID="txtDiscription" TextMode="MultiLine" Height="40px" Width="500px"
                    CssClass="input1"></asp:TextBox>
            </td>
        </tr>
        <tr id="trremark" runat="server" visible="false">
            <td>
            </td>
            <td align="left" style="height: 24px">
                ��ע
            </td>
            <td align="left" colspan="4">
                <asp:TextBox runat="server" ID="txtRemak" TextMode="MultiLine" Height="40px" Width="500px"
                    CssClass="input1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 24px;">
            </td>
            <td align="left" style="height: 24px">
                <asp:Label ID="lblTimeName" runat="server"></asp:Label><span class="redstar">*</span>
            </td>
            <td align="left" colspan="3" style="height: 24px">
                <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dtpConsumeDateFrom"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="dtpConsumeDateTo"
                    Format="yyyy-MM-dd">
                </ajaxToolKit:CalendarExtender>
                <asp:TextBox runat="server" ID="dtpConsumeDateFrom" CssClass="input1" Width="105px" ></asp:TextBox>
                <asp:DropDownList ID="ddlConsumeDateFromHour" runat="server">
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
                ʱ<asp:DropDownList ID="ddlConsumeDateFromMinute" runat="server">
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
                �� ��
                <asp:TextBox runat="server" ID="dtpConsumeDateTo" CssClass="input1" Width="105px"></asp:TextBox>
                <asp:DropDownList ID="ddlConsumeDateToHour" runat="server">
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
                ʱ<asp:DropDownList ID="ddlConsumeDateToMinute" runat="server">
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
                ��
                <asp:Label ID="lblConsumeMsg" runat="server" CssClass="psword_f"></asp:Label>
            </td>
            <td align="right">
                 <strong>���֣�</strong> <asp:DropDownList ID="ddlExchangeRate" runat="server">
                </asp:DropDownList>&nbsp;&nbsp;
                <strong>�����ܶ</strong><asp:Label ID="lblTotalCost" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="20px" align="right">
            </td>
            <td align="left" colspan="6" valign="top">
                <div id="tbReimburseItem" runat="server" class="linetable">
                    <asp:GridView GridLines="None" Width="100%" ID="gvReimburseItem" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" OnPageIndexChanging="gvReimburseItem_PageIndexChanging" OnRowCommand="gvReimburseItem_RowCommand"
                        OnRowDataBound="gvReimburseItem_RowDataBound">
                        <HeaderStyle Height="28px" CssClass="headerstyleblue" />
                        <RowStyle Height="28px" CssClass="GridViewRowLink" />
                        <AlternatingRowStyle CssClass="table_g" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnHiddenPostButton" CommandArgument='<%# Eval("HashCode")  %>' CommandName="HiddenPostButtonCommand"
                                        runat="server" Text="" Style="display: none;" />
                                </ItemTemplate>
                                <ItemStyle Width="2%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="�������">
                                <ItemTemplate>
                                    <%#ReimburseItem.GetReimburseTypeNameByReimburseType((ReimburseTypeEnum)Eval("ReimburseTypeEnum"))%>
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="���ѵص�">
                                <ItemTemplate>
                                    <%# Eval("ConsumePlace")%>
                                </ItemTemplate>
                                <ItemStyle Width="16%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="�ͻ�����">
                                <ItemTemplate>
                                    <%# Eval("CustomerName")%>
                                </ItemTemplate>
                                <ItemStyle Width="26%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="����">
                                <ItemTemplate>
                                    <%# Eval("Reason")%>
                                </ItemTemplate>
                                <ItemStyle Width="26%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="���">
                                <ItemTemplate>
                                    <%#Eval("TotalCost")%>
                                </ItemTemplate>
                                <ItemStyle Width="11%" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbModifyItem" Text="�޸�" OnClientClick="Confirmed=false;" OnCommand="lbModifyItem_Click"
                                        CommandName="ModifyItem" runat="server" CommandArgument='<%# Eval("HashCode") %>' />
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDeleteItem" Text="ɾ��" OnCommand="lbDeleteItem_Click" OnClientClick="Confirmed = false; return confirm('ȷ��Ҫ�Ƴ��˱�������');"
                                        CommandName="DeleteItem" runat="server" CommandArgument='<%# Eval("HashCode") %>' />
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerTemplate>
                            <div class="pages">
                                <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                                    CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
                                <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                                    CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
                            </div>
                        </PagerTemplate>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td width="20px" align="right">
            </td>
            <td align="left" colspan="6" valign="top">
                ע������������������ʽƱ�ݣ��ύ��ӡ�����ڱ���ճ��Ʊ�ݵ���ز��Ž���������
            </td>
        </tr>
    </table>
</div>
<div id="Review1" runat="server" class="leftitbor2">
    <asp:Label ID="lbOperationType" runat="server">�������</asp:Label>
</div>
<div id="Review2" runat="server">
    <div id="tbReimburseFlow" runat="server" class="linetablediv">
        <asp:GridView GridLines="None" Width="100%" ID="gvReimburseFlow" runat="server" AutoGenerateColumns="False"
            OnRowDataBound="gvReimburseFlow_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvReimburseFlow_PageIndexChanging">
            <HeaderStyle Height="28px" CssClass="headerstyleblue" />
            <RowStyle Height="28px" CssClass="GridViewRowLink" />
            <AlternatingRowStyle CssClass="table_g" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnHiddenPostButton" CommandArgument='<%# Eval("ReimburseFlowID")%>'
                            CommandName="HiddenPostButtonCommand" runat="server" Style="display: none;" /></ItemTemplate>
                    <ItemStyle Width="2%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="������">
                    <ItemTemplate>
                        <%#Eval("Operator.Account.Name")%>
                    </ItemTemplate>
                    <ItemStyle Width="12%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="����״̬">
                    <ItemTemplate>
                        <%#Reimburse.GetReimburseStatusNameByReimburseStatus((ReimburseStatusEnum)Eval("ReimburseStatusEnum"))%></a>
                    </ItemTemplate>
                    <ItemStyle Width="12%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="����ʱ��">
                    <ItemTemplate>
                        <%#Eval("OperationTime")%>
                    </ItemTemplate>
                    <ItemStyle Width="12%" />
                </asp:TemplateField>
            </Columns>
            <PagerTemplate>
                <div class="pages">
                    <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CssClass="pageprevbutton"
                        CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>">
		    ��һҳ</asp:LinkButton>
                    <asp:LinkButton ID="LinkButtonNextPage" runat="server" CssClass="pagenextbutton"
                        CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>">
		    ��һҳ</asp:LinkButton>
                </div>
            </PagerTemplate>
        </asp:GridView>
    </div>
</div>
<div class="tablebt">
    <asp:Button Text="��  ��" ID="btnSave" runat="server" class="inputbt" OnClick="btnSave_Click" />
    <asp:Button Text="ȷ  ��" ID="btnOK" runat="server" class="inputbt" OnClick="btnOK_Click"
        Visible="false" />
    <asp:Button Text="ͨ  ��" ID="btnPass" runat="server" class="inputbt" OnClick="btnPass_Click"
        Visible="false" />
    <asp:Button Text="�ᡡ��" ID="btnSubmit" runat="server" class="inputbt" OnClick="btnSubmit_Click" />
    <asp:Button Text="�ˡ���" ID="btnIntermit" runat="server" class="inputbt" OnClick="btnReturn_Click"
        Visible="false" />
    <asp:Button Text="����������" ID="btnAddItem" OnClick="btnAddItem_Click" runat="server"
        class="inputbtlong" />
    <asp:Button Text="ȡ����" ID="btnCancel" runat="server" class="inputbt" OnClick="btnCancel_Click"
        Visible="false" />
    <asp:Button Text="ȡ����" ID="btnCancel1" runat="server" class="inputbt" OnClick="btnCancel_Click1"
        Visible="false" />
</div>
<script language="javascript " type="text/javascript" src="../../Inc/jquery.autocomplete.js"></script>
<link href="../../CSS/jquery.autocomplete.css" rel="stylesheet" type="text/css" />

