<%@ Control Language="C#" AutoEventWireup="true" Codebehind="AuthTree.ascx.cs" Inherits="SEP.Performance.Views.SEP.Auths.AuthTree" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div id="AllAuth" class="authTree1">
    <ajaxToolKit:Accordion ID="AllAuthAccordion" runat="server" SelectedIndex="0" AutoSize="None"
        FadeTransitions="false" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false"
        SuppressHeaderPostbacks="true"
        HeaderCssClass="rightbt1" HeaderSelectedCssClass="rightbt1change">
        <Panes>
            <%--用户管理--%>
            <ajaxToolKit:AccordionPane ID="apAccountManage" runat="server" >
                <Header>
                    <asp:LinkButton ID="btnAccountManage" Text="用户管理" runat="server" />
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
            <%--组织结构管理--%>
            <ajaxToolKit:AccordionPane ID="apDeptMange" runat="server">
                <Header>
                    <asp:LinkButton ID="btnDeptMange" Text="组织架构管理" runat="server" />
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
            <%--公告管理--%>
            <ajaxToolKit:AccordionPane ID="apBulletinsManage" runat="server">
                <Header>
                    <asp:LinkButton ID="btnBulletinsManage" Text="公告管理" runat="server" />
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
            <%--公司目标管理--%>
            <ajaxToolKit:AccordionPane ID="apGoalMange" runat="server">
                <Header>
                    <asp:LinkButton ID="btnGoalMange" Text="公司目标管理" runat="server" />
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
            <%--企业文化--%>
            <ajaxToolKit:AccordionPane ID="apCompanuManage" runat="server">
                <Header>
                    <asp:LinkButton ID="btnCompanuManage" Text="企业文化" runat="server" />
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
            <%--增值服务--%>
            <ajaxToolKit:AccordionPane ID="apServiceManage" runat="server">
                <Header>
                    <asp:LinkButton ID="btnServiceManage" Text="增值服务" runat="server" />
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
            <%--个人设置--%>
            <ajaxToolKit:AccordionPane ID="apPersonalManage" runat="server">
                <Header>
                    <asp:LinkButton ID="btnPersonalManage" Text="个人设置" runat="server" />
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
