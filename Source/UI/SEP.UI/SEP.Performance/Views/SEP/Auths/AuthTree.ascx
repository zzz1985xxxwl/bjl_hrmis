<%@ Control Language="C#" AutoEventWireup="true" Codebehind="AuthTree.ascx.cs" Inherits="SEP.Performance.Views.SEP.Auths.AuthTree" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div id="AllAuth" class="authTree1">
    <ajaxToolKit:Accordion ID="AllAuthAccordion" runat="server" SelectedIndex="0" AutoSize="None"
        FadeTransitions="false" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false"
        SuppressHeaderPostbacks="true"
        HeaderCssClass="rightbt1" HeaderSelectedCssClass="rightbt1change">
        <Panes>
            <%--�û�����--%>
            <ajaxToolKit:AccordionPane ID="apAccountManage" runat="server" >
                <Header>
                    <asp:LinkButton ID="btnAccountManage" Text="�û�����" runat="server" />
                </Header>
                <Content>
                    <div>
                        <asp:Repeater ID="rptAccountManage" runat="server">
                            <ItemTemplate>
                                <div id="divLink" runat="server" 
                                    class='<%# Eval("Name").ToString().Trim() != selectbtn ? "rightbt2" : "rightbt3"%>'>
                                <asp:LinkButton CommandArgument="0" runat="server" CommandName='<%#Eval("NavigateUrl") %>'
                                    Text='<%#Eval("Name")%>' 
                                    OnClick="LinkButton_Click"/>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </Content>
            </ajaxToolKit:AccordionPane>
            <%--��֯�ṹ����--%>
            <ajaxToolKit:AccordionPane ID="apDeptMange" runat="server">
                <Header>
                    <asp:LinkButton ID="btnDeptMange" Text="��֯�ܹ�����" runat="server" />
                </Header>
                <Content>
                    <div>
                        <asp:Repeater ID="rptDeptManage" runat="server">
                            <ItemTemplate>
                                <div id="divLink" runat="server" 
                                    class='<%# Eval("Name").ToString().Trim() != selectbtn ? "rightbt2" : "rightbt3"%>'>                            
                                <asp:LinkButton CommandArgument="1" runat="server" CommandName='<%#Eval("NavigateUrl") %>'
                                    
                                    OnClick="LinkButton_Click" Text='<%#Eval("Name")%>'/>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </Content>
            </ajaxToolKit:AccordionPane>
            <%--�������--%>
            <ajaxToolKit:AccordionPane ID="apBulletinsManage" runat="server">
                <Header>
                    <asp:LinkButton ID="btnBulletinsManage" Text="�������" runat="server" />
                </Header>
                <Content>
                    <div>
                        <asp:Repeater ID="rptBulletinsManage" runat="server">
                            <ItemTemplate>
                                <div id="divLink" runat="server" 
                                    class='<%# Eval("Name").ToString().Trim() != selectbtn ? "rightbt2" : "rightbt3"%>'>                            
                                <asp:LinkButton CommandArgument="2" runat="server" CommandName='<%#Eval("NavigateUrl") %>'
                                    
                                    OnClick="LinkButton_Click" Text='<%#Eval("Name")%>'/>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </Content>
            </ajaxToolKit:AccordionPane>
            <%--��˾Ŀ�����--%>
            <ajaxToolKit:AccordionPane ID="apGoalMange" runat="server">
                <Header>
                    <asp:LinkButton ID="btnGoalMange" Text="��˾Ŀ�����" runat="server" />
                </Header>
                <Content>
                    <div>
                        <asp:Repeater ID="rptGoalMange" runat="server">
                            <ItemTemplate>
                                <div id="divLink" runat="server" 
                                    class='<%# Eval("Name").ToString().Trim() != selectbtn ? "rightbt2" : "rightbt3"%>'>                            
                                <asp:LinkButton CommandArgument="3" runat="server" CommandName='<%#Eval("NavigateUrl") %>'
                                    
                                    OnClick="LinkButton_Click" Text='<%#Eval("Name")%>'/>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </Content>
            </ajaxToolKit:AccordionPane>
            <%--��ҵ�Ļ�--%>
            <ajaxToolKit:AccordionPane ID="apCompanuManage" runat="server">
                <Header>
                    <asp:LinkButton ID="btnCompanuManage" Text="��ҵ�Ļ�" runat="server" />
                </Header>
                <Content>
                    <div>
                        <asp:Repeater ID="rptCompanuManage" runat="server">
                            <ItemTemplate>
                                <div id="divLink" runat="server" 
                                    class='<%# Eval("Name").ToString().Trim() != selectbtn ? "rightbt2" : "rightbt3"%>'>                            
                                <asp:LinkButton CommandArgument="4" runat="server" CommandName='<%#Eval("NavigateUrl") %>'
                                    
                                    OnClick="LinkButton_Click" Text='<%#Eval("Name")%>'/>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </Content>
            </ajaxToolKit:AccordionPane>
            <%--��ֵ����--%>
            <ajaxToolKit:AccordionPane ID="apServiceManage" runat="server">
                <Header>
                    <asp:LinkButton ID="btnServiceManage" Text="��ֵ����" runat="server" />
                </Header>
                <Content>
                    <div>
                        <asp:Repeater ID="rptServiceManage" runat="server">
                            <ItemTemplate>
                                <div id="divLink" runat="server" 
                                    class='<%# Eval("Name").ToString().Trim() != selectbtn ? "rightbt2" : "rightbt3"%>'>                            
                                <asp:LinkButton CommandArgument="5" runat="server" CommandName='<%#Eval("NavigateUrl") %>'
                                    
                                    OnClick="LinkButton_Click" Text='<%#Eval("Name")%>'/>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </Content>
            </ajaxToolKit:AccordionPane>
            <%--��������--%>
            <ajaxToolKit:AccordionPane ID="apPersonalManage" runat="server">
                <Header>
                    <asp:LinkButton ID="btnPersonalManage" Text="��������" runat="server" />
                </Header>
                <Content>
                        <asp:Repeater ID="rptPersonalManage" runat="server">
                            <ItemTemplate>
                                <div id="divLink" runat="server" 
                                    class='<%# Eval("Name").ToString().Trim() != selectbtn ? "rightbt2" : "rightbt3"%>'>
                                    <asp:LinkButton  CommandArgument="6" runat="server" CommandName='<%#Eval("NavigateUrl") %>'
                                        OnClick="LinkButton_Click" Text='<%#Eval("Name")%>'/>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                </Content>
            </ajaxToolKit:AccordionPane>
        </Panes>
    </ajaxToolKit:Accordion>
    <div class="authTreebt4"></div>
</div>
