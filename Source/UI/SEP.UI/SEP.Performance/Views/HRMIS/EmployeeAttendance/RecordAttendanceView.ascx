<%@ Control Language="C#" AutoEventWireup="true" Codebehind="RecordAttendanceView.ascx.cs"
    Inherits="SEP.Performance.Views.HRMIS.EmployeeAttendance.RecordAttendanceView" %>

<script language="javascript">
 		var j=-1;
		var temp_str;
        function getHttpObject()
        {
            var waystation = null;
            if(window.ActiveXObject)
            {
                waystation = new ActiveXObject("Microsoft.XMLHTTP");
            }
            else if(window.XMLHttpRequest)
            {
                waystation = new XMLHttpRequest();
            }
            else
            {
                waystation = false;
            }
            return waystation;
        }
        
        function addTest(e)
        {
        			var keyc;
			if(window.event){
				keyc=e.keyCode;
				}
			else if(e.which){
				keyc=e.which;
				}
							if(keyc!=40 && keyc!=38){
            inputField = document.getElementById("txtEmployeeName");
            completeTable = document.getElementById("table1");
            completeDiv = document.getElementById("popup");
            completeBody = document.getElementById("body1");
       
            var s = document.all.item("txtEmployeeName").value;
            temp_str=document.all.item("txtEmployeeName").value;
            //var key= encodeURI(s);
            var key=encodeURI(inputField.value);
            //alert(key);
            if(key=="")
            return;
            var xmlrequest =getHttpObject();
            xmlrequest.open("post","../../../Pages/HRMIS/AttendancePages/GoogleDownBackCode.aspx?key="+key);
            xmlrequest.onreadystatechange = function()
            {
                if(xmlrequest.readyState==4)
                {
                   //xmlrequest.responseText为你AddCity中输出的那段字符串；
                    setNames(xmlrequest.responseText);

                }
            }
            xmlrequest.send(null);
            }
        }
        
        function setNames(names)
        {
            if(names=="")
            {
                clearNames();
                return ;
            }
            clearNames();
            setOffsets();
            var row,cell,txtNode;
            
            var s = names.split("$");
            
            for (var i = 0; i < s.length; i++) 

               {

                 //s[i]为td的
                    var nextNode =s[i];
                    row = document.createElement("tr");
                    cell = document.createElement("td");
                    cell.onmouseout = function() {this.style.backgroundColor='';this.style.color='Black'};
                    cell.onmouseover = function() {this.style.backgroundColor='#4fa0df';this.style.color='White'};
                    cell.onclick = function() { completeField(this); } ;
                    cell.pop="T";
                    txtNode = document.createTextNode(nextNode);
                   cell.appendChild(txtNode);
                    row.appendChild(cell);
                    document.getElementById("body1").appendChild(row);
              }


        }
        
        //用来设置当鼠标失去焦点后文本框的隐藏
        document.onmousedown=function()
        {
            if(!event.srcElement.pop)
             clearNames();
         }//填写输入框

        function completeField(cell)
        {
            inputField.value = cell.firstChild.nodeValue;
            clearNames();
        }
        
        function clearNames()
        {
            completeBody = document.getElementById("body1");
            var ind = completeBody.childNodes.length;
            
            for(var i= ind-1;i>=0;i--)
            {
                completeBody.removeChild(completeBody.childNodes[i]);
            }
            completeDiv= document.getElementById("popup");
            completeDiv.style.border = "none";
            
        }
        
        function setOffsets()
        {
            completeTable.style.width = inputField.offsetWidth;+"px";
//            var left = calculateOffset(inputField,"offsetLeft");
//            var top = calculateOffset(inputField,"offsetTop")+inputField.offsetHeight;
//             var Abe = getLTWH(document.getElementById("txtEmployeeName"));
              completeDiv.style.border = "black 1px solid";
//               completeDiv.style.left = Abe.left;
//               completeDiv.style.top = Abe.top + Abe.height;
//                              completeDiv.style.left = inputField.offsetLeft+160 + "px";
//               completeDiv.style.top = inputField.offsetTop+110+ "px";
        }
        
        function calculateOffset(field, attr) {
    var offset = 0;
     while(field) {
     offset += field[attr]; 
     field = field.offsetParent;
    }
    return offset;
   } 
   
   function getLTWH(element) 
    { 
        if ( arguments.length != 1 || element == null ) 
        { 
            return null; 
        } 
        var offsetTop = element.offsetTop; 
        var offsetLeft = element.offsetLeft; 
        var offsetWidth = element.offsetWidth; 
        var offsetHeight = element.offsetHeight; 
        while( element == element.offsetParent ) 
        { 
            offsetTop += element.offsetTop; 
            offsetLeft += element.offsetLeft; 
        } 
        var Abe={
           left:offsetLeft,
           top:offsetTop,
           width:offsetWidth,
           height:offsetHeight
        }
        return Abe;
    } 
    
function keydowndeal(e){
         completeBody = document.getElementById("body1");
                     var ind = completeBody.childNodes.length;
			var keyc;
			if(window.event){
				keyc=e.keyCode;
				}
			else if(e.which){
				keyc=e.which;
				}
			if(keyc==40 || keyc==38){
			if(keyc==40){
				if(j<ind){
					j++;
					if(j>=ind){
						j=-1;
					}
				}
				if(j>=ind){
						j=-1;
					}
			}
			if(keyc==38){
				if(j>=0){
					j--;
					if(j<=-1){
						j=ind;
					}
				}
				else{
					j=ind;
				}
			}
						for(var i=0;i<ind;i++){
				completeBody.childNodes[i].childNodes[0].style.backgroundColor="";
					completeBody.childNodes[i].childNodes[0].style.color="Black";
			}					
			if(j>=0 && j<ind){
				completeBody.childNodes[j].childNodes[0].style.backgroundColor="#4fa0df";
					completeBody.childNodes[j].childNodes[0].style.color="White";
				}
			if(j>=0 && j<ind){
				document.getElementById("txtEmployeeName").value=completeBody.childNodes[j].childNodes[0].firstChild.nodeValue;
				}
			else{
				document.getElementById("txtEmployeeName").value=temp_str;
				}
			}
		}	
</script>

<div id="tbResultMessage" runat="server" class="leftitbor">
    <asp:Label ID="msgMessage" runat="server" CssClass="fontred"></asp:Label>
</div>
<div class="leftitbor2">
    新增缺勤记录
    <asp:HiddenField ID="Operation" runat="server" />
</div>
    
<div  class="edittable">
  <table width="100%" border="0">
        <tr>
            <td align="left" style="width: 5%">
            </td>
            <td align="left" style="width: 25%">缺&nbsp;&nbsp;勤&nbsp;&nbsp;类&nbsp;&nbsp;型&nbsp;
                <%--<asp:Label ID="lblType" runat="server" Text="缺&nbsp;&nbsp;勤&nbsp;&nbsp;类&nbsp;&nbsp;型"></asp:Label>--%>
                <span class="redstar">*</span></td>
            <td align="left" style="width: 70%;" valign="middle">
                <asp:DropDownList ID="ddlTypes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTypes_SelectedIndexChanged"
                    Width="159px">
                </asp:DropDownList>
                &nbsp; &nbsp;
                <asp:Label ID="msgTypes" runat="server" CssClass="psword_f"></asp:Label></td>
        </tr>
        <tr>
            <td align="left" style="width: 5%">
            </td>
            <td align="left" style="width: 25%">员&nbsp;&nbsp;工&nbsp;&nbsp;姓&nbsp;&nbsp;名&nbsp;
                <%--<asp:Label ID="lblName" runat="server" Text="员&nbsp;&nbsp;工&nbsp;&nbsp;姓&nbsp;&nbsp;名"></asp:Label>--%>
                <span class="redstar">*</span></td>
            <td style="width: 70%" valign="middle" align="left">
                <%--<asp:TextBox ID="txtEmployeeName" runat="server" CssClass="input1"></asp:TextBox>--%>
                <input id="txtEmployeeName" class="input1" name="txtEmployeeName" onkeydown="keydowndeal(event);"
                    onkeyup="addTest(event);" type="text" />
                &nbsp; &nbsp;
                <asp:Label ID="msgEmployeeName" runat="server" CssClass="psword_f"></asp:Label>
                <asp:Label ID="lblEmployeeName" runat="server" Text="" Visible="false"></asp:Label>
                <br />
                <div id="popup" style="position: absolute">
                    <table id="table1" border="0" cellpadding="0" cellspacing="0">
                        <tbody id="body1">
                        </tbody>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 5%">
            </td>
            <td align="left" style="width: 25%">缺&nbsp;&nbsp;勤&nbsp;&nbsp;日&nbsp;&nbsp;期&nbsp;
                <%--<asp:Label ID="lblDate" runat="server" Text="缺&nbsp;&nbsp;勤&nbsp;&nbsp;日&nbsp;&nbsp;期"></asp:Label>--%>
                <span class="redstar">*</span></td>
            <td align="left" style="width: 70%" valign="middle">
                <asp:TextBox ID="txtTheDay" runat="server" CssClass="input1"></asp:TextBox>
                &nbsp; &nbsp;
                <asp:Label ID="msgTheDay" runat="server" CssClass="psword_f"></asp:Label>&nbsp;<ajaxToolKit:CalendarExtender
                    ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTheDay">
                </ajaxToolKit:CalendarExtender>
            </td>
        </tr>
        <tr id="trMinute" runat="server">
            <td align="left" style="width: 5%;">
            </td>
            <td style="width: 25%;" align="left">
                <asp:Label ID="lblMinutes" runat="server" Text="分&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;钟"></asp:Label>
                <span class="redstar">*</span></td>
            <td style="width: 70%;" align="left">
                <asp:TextBox ID="txtMinutes" runat="server" CssClass="input1"></asp:TextBox>
                &nbsp; &nbsp;
                <asp:Label ID="msgMinutes" runat="server" CssClass="psword_f"></asp:Label></td>
        </tr>
    </table>
</div>
<div class="tablebt">
    <asp:Button ID="btnAction" runat="server" CssClass="inputbt" OnClick="btnAction_Click"
        Text="确 定" />
    <asp:Button ID="btnCancle" runat="server" CssClass="inputbt" OnClick="btnCancle_Click"
        Text="取 消" />
</div>
