<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyFeedBackView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.Train.MyFeedBackView" %>
<%@ Register Src="FeedBackListView.ascx" TagName="FeedBackListView" TagPrefix="uc1" %>

<div id="tbSelf" runat="server" class="leftitbor" >
    <span class="font14b">
        <asp:Label ID="LblMessage" runat="server" Text="" ></asp:Label>
    </span>
</div>
<div class="leftitbor2">开始的培训课程</div>
<div class="nolinetablediv">
    <uc1:FeedBackListView id="FeedBackListViewStrat" runat="server">
    </uc1:FeedBackListView>
</div>
<div class="leftitbor2" >
    已结束的培训课程
</div>
<div class="nolinetablediv">
    <uc1:FeedBackListView id="FeedBackListViewEnd" runat="server">
    </uc1:FeedBackListView>
</div>