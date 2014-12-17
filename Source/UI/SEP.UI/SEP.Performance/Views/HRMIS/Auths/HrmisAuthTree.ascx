<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HrmisAuthTree.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.Auths.HrmisAuthTree" %>
<div id="authTree" class="authTree">
    <ul>
        <%if (AllAuth != null && AllAccountAuth != null)
          {
              var allParentAuth = AllAuth.Where(x => x.AuthParentId == 0).ToList();
              for (int i = 0; i < allParentAuth.Count; i++)
              {
                  var childAuth = AllAuth.Where(x => x.AuthParentId == allParentAuth[i].PKID).ToList();
                  var accountChildAuth =
                      childAuth.Where(x => AllAccountAuth.Where(y => y.AuthId == x.PKID).Count() > 0).ToList();
                  if (accountChildAuth.Count > 0)
                  {
                      var menuOn = MenuOn(accountChildAuth);
        %>
        <li class="menuHead" <%=i==0?"style='margin-top:0;'":"" %>>
        <a class="<%=menuOn?"on":""%>"><%=allParentAuth[i].AuthName%></a>
        </li>
        <li class="menuChild" style="display:<%=menuOn?"list-item": "none"%>">
            <ul>
                <%foreach (var item in accountChildAuth)
                  {%>
                <li class="<%=Request.RawUrl.Contains(item.NavigateUrl.Replace("../",""))?"on":""%>">
                    <a href="<%=item.NavigateUrl%>"><%=item.AuthName%></a>
                 </li>
                <%}%>
            </ul>
        </li>
        <% }
              }
          }%>
    </ul>
</div>
