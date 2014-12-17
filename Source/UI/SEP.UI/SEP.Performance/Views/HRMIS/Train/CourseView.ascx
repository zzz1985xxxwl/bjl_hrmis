<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseView.ascx.cs" Inherits="SEP.Performance.Views.HRMIS.Train.CourseView" %>
<%@ Register Src="../ChoseEmployee/ChoseEmployeeView.ascx" TagName="ChoseEmployeeView"
    TagPrefix="uc1" %>
  <%@ Register Src="../Train/ChooseSkillView.ascx" TagName="ChooseSkillView"
    TagPrefix="uc2" %>
<%@ Register Src="../../Progressing.ascx" TagName="Progressing" TagPrefix="uc5" %>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
    <script type="text/javascript" language="javascript">
       var txtCodinator = '<%= txtCodinator.ClientID %>';
       var btnMailHidden = '<%= btnMailHidden.ClientID %>';
       var btnSkillHidden = '<%= btnSkillHidden.ClientID %>';
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
            inputField = document.getElementById(txtCodinator);
            completeTable = document.getElementById("table1");
            completeDiv = document.getElementById("popup");
            completeBody = document.getElementById("body1");
            var s = inputField.value;
            temp_str=document.all.item(txtCodinator).value;
            //alert(s);
            var key= encodeURI(s);
            if(s=="")
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
				document.getElementById(txtCodinator).value=completeBody.childNodes[j].childNodes[0].firstChild.nodeValue;
				}
			else{
				document.getElementById(txtCodinator).value=temp_str;
				}
			}
		}	

function EmployeeHiddenBtnClick()
{
document.getElementById(btnMailHidden).click();
}

function SkillHiddenBtnClick()
{
document.getElementById(btnSkillHidden).click();
}
</script>    
 <div id="tbMessage" runat="server"  class="leftitbor" >
			<asp:Label ID="lblMessage" runat="server" CssClass = "fontred"></asp:Label>
</div>
<div class="leftitbor2" >
    <asp:Label ID="lblTitle" runat="server"></asp:Label>
</div>
<div class="edittable">
    <table width="100%" border="0">
        <tr>
            <td width="14%" align="left">
            课程名称<span class = "redstar">*</span></td>
            <td width="36%" align="left">
            <asp:TextBox ID="txtCourseName" runat="server" CssClass="input1"></asp:TextBox> &nbsp;
            <asp:Label ID="lblCourseNameMsg" runat="server" CssClass = "psword_f"></asp:Label></td>
            <td width="14%" align="left">
            培训地点<span class = "redstar">*</span></td>
            <td width="36%" align="left">
            <asp:TextBox ID="txtPlace" runat="server" CssClass="input1"></asp:TextBox>&nbsp;
            <asp:Label ID="lblPlaceMsg" runat="server" CssClass = "psword_f"></asp:Label></td>
        </tr>
        <tr>
            <td align="left">
            培训师<span class = "redstar">*</span></td>
            <td align="left">  
            <asp:TextBox ID="txtTrainer" runat="server" Text="" CssClass="input1"></asp:TextBox>
            &nbsp;
            <asp:Label ID="lblTrainerMsg" runat="server" CssClass = "psword_f"></asp:Label>             
            </td>
            <td align="left">
            协调员<span class = "redstar">*</span></td>
            <td align="left">
            <asp:TextBox ID="txtCodinator" runat="server" CssClass="input1"></asp:TextBox>&nbsp;
            <asp:Label ID="lblCodinatorMsg" runat="server" CssClass = "psword_f"></asp:Label>
            <br />
                <div  id="popup" style="position:absolute">
                <table id="table1" cellspacing="0" cellpadding="0" bgcolor="#fffafa" border="0">
                <tbody id="body1">
                </tbody>
                </table>
                </div>
            </td>
        </tr>
        <tr>
            <td align="left">
            培训范围</td>
            <td align="left">
            <asp:DropDownList ID="listScope" runat="server" Width="149px">
            </asp:DropDownList></td>
            <td width="14%" align="left">
            培训状态</td>
            <td align="left">
            <asp:DropDownList ID="listStatus" runat="server" Width="159px">
            </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="left" >
            相关技能<span class = "redstar">*</span></td>
            <td colspan="3" align="left" >
            <asp:TextBox ID="txtSkill" runat="server" Width="485px" CssClass="input1" ReadOnly="True"></asp:TextBox>&nbsp;
            <asp:Label ID="lblSkillMsg" runat="server" CssClass = "psword_f"></asp:Label><asp:Label
                ID="lblSkillDisplay" runat="server"></asp:Label></td>
            </tr>
            <tr>
            <td align="left">
            被培训人<span class = "redstar">*</span></td>
            <td colspan="3" align="left">
            <asp:TextBox ID="txtTrainee" runat="server" Width="484px" CssClass="input1" ReadOnly="True"></asp:TextBox>&nbsp;
            <asp:Label ID="lblTraineeMsg" runat="server" CssClass = "psword_f"></asp:Label></td>
        </tr>
                    <tr>
            <td align="left">
            反馈问卷</td>
            <td colspan="3" align="left">
                <asp:DropDownList ID="listPaper" runat="server" Width="484px">
                </asp:DropDownList>
                <asp:CheckBox ID="cbCertifiacation" runat="server" Text="是否有证书" /></td>
        </tr>
        <tr>
            <td align="left">计划开始时间&nbsp;<span class = "redstar">*</span></td>
            <td align="left">
            <asp:TextBox ID="txtExpectedST" runat="server" CssClass="input1"></asp:TextBox>&nbsp;
            <asp:Label ID="lblExpectedSTMsg" runat="server" CssClass = "psword_f"></asp:Label>
            <ajaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtExpectedST" Format="yyyy-MM-dd">
            </ajaxToolKit:CalendarExtender></td>
            <td align="left">计划结束时间&nbsp;<span class = "redstar">*</span></td>
            <td align="left">
            <asp:TextBox ID="txtExpectedET" runat="server" CssClass="input1"></asp:TextBox>&nbsp;
            <asp:Label ID="lblExpectedETMsg" runat="server" CssClass = "psword_f"></asp:Label>
            <ajaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtExpectedET" Format="yyyy-MM-dd">
            </ajaxToolKit:CalendarExtender></td>
        </tr>
        <tr>
            <td align="left">实际开始时间&nbsp;</td>
            <td align="left">
            <asp:TextBox ID="txtActualST" runat="server" CssClass="input1"></asp:TextBox>&nbsp;
            <asp:Label ID="lblActualSTMsg" runat="server" CssClass = "psword_f"></asp:Label>
            <ajaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtActualST" Format="yyyy-MM-dd">
            </ajaxToolKit:CalendarExtender></td>
            <td align="left">实际结束时间&nbsp;</td>
            <td align="left">
            <asp:TextBox ID="txtActualET" runat="server" CssClass="input1"></asp:TextBox>&nbsp;
            <asp:Label ID="lblActualETMsg" runat="server" CssClass = "psword_f"></asp:Label>
            <ajaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtActualET" Format="yyyy-MM-dd">
            </ajaxToolKit:CalendarExtender></td>
        </tr>
        <tr>
            <td align="left">
            计划课时&nbsp;<span class = "redstar">*</span></td>
            <td align="left">
            <asp:TextBox ID="txtExpectedHour" runat="server" CssClass="input1"></asp:TextBox>&nbsp;
            <asp:Label ID="lblExpHourMsg" runat="server" CssClass = "psword_f"></asp:Label></td>
            <td align="left">
            实际课时</td>
            <td align="left">
            <asp:TextBox ID="txtActualHour" runat="server" CssClass="input1"></asp:TextBox>&nbsp;
            <asp:Label ID="lblActualHourMsg" runat="server" CssClass = "psword_f"></asp:Label></td>
        </tr>
        <tr>
            <td align="left">
            计划成本&nbsp;<span class = "redstar">*</span></td>
            <td align="left">
            <asp:TextBox ID="txtExpectedCost" runat="server"  CssClass="input1"></asp:TextBox>&nbsp;
            <asp:Label ID="lblExpCostMsg" runat="server" CssClass = "psword_f"></asp:Label></td>
            <td align="left">
            实际成本</td>
            <td align="left">
            <asp:TextBox ID="txtActualCost" runat="server" CssClass="input1"></asp:TextBox>&nbsp;
            <asp:Label ID="lblActualCostMsg" runat="server" CssClass = "psword_f"></asp:Label></td>
        </tr>
    </table>
</div>
<div id="Backbtn" runat="server" class="tablebt">  
    <asp:Button ID="btnOk" OnClick="btnOK_Click"  runat="server" Text="确　定" CssClass="inputbt" />
    <asp:Button ID="btnCancle"  OnClick="btnCancel_Click" runat="server" Text="取  消"  CssClass="inputbt"/>
</div>

<div id="FrontBtn" runat="server"  class="tablebt">
    <asp:Button ID="btnOkFront" OnClick="btnOKFront_Click"  runat="server" Text="确　定" CssClass="inputbt" />
<asp:Button ID="btnCancleFront"  OnClick="btnCancelFront_Click" runat="server" Text="取  消"  CssClass="inputbt"/>
</div>
  
 <ajaxToolKit:ModalPopupExtender id="mpeEmployeeList" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlSearchEmployee" 
                    TargetControlID="btnMailHidden"></ajaxToolKit:ModalPopupExtender>
                    <asp:Button ID="btnMailHidden" runat="Server" Style="display: none" />  
<asp:Panel ID="pnlSearchEmployee" runat="server" CssClass="modalBox" Style="display: none;" Width="700px">
 <div style="white-space: nowrap; text-align: center;">
     <uc1:ChoseEmployeeView ID="ChoseEmployeeView1" runat="server" />
</div>
</asp:Panel>

 <ajaxToolKit:ModalPopupExtender id="mpeSkillList" runat="server" BackgroundCssClass="modalBackground" PopupControlID="pnlSearchSkill" 
                    TargetControlID="btnSkillHidden"></ajaxToolKit:ModalPopupExtender> 
                    <asp:Button ID="btnSkillHidden" runat="Server" Style="display: none" /> 
<asp:Panel ID="pnlSearchSkill" runat="server" CssClass="modalBox" Style="display: none;" Width="500px">
 <div style="white-space: nowrap; text-align: center;">
     <uc2:ChooseSkillView ID="ChooseSkillView1" runat="server" />
</div>
</asp:Panel>

 <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <uc5:Progressing ID="Progressing1" runat="server"></uc5:Progressing>
            </ProgressTemplate>
        </asp:UpdateProgress>
        
    </ContentTemplate>
</asp:UpdatePanel>