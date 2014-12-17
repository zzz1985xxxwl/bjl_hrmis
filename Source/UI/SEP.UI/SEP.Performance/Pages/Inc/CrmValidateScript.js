	     //验证textbox是否为空
function validateNull(txtBoxId,labelId,message)
{
    document.getElementById(labelId).innerText="";
if(document.getElementById(txtBoxId).value.length<1)
{
      //lable显示错误消息
      document.getElementById(labelId).innerText=message;
 	  //textbox一直保持焦点	
      //document.getElementById(txtBoxId).focus();
}
}
      
      //验证时间格式不整齐
function validateTime(txtBoxId,labelId,message)
{
if(document.getElementById(txtBoxId).value.length>0)
{
//验证时间的正则表达式
    Reg = /^([0-9]{4}|[0-9]{2})[-]([0]?[1-9]|[1][0-2])[-]([0]?[1-9]|[1|2][0-9]|[3][0|1])$/;
if( !this.doReg(this.Reg,document.getElementById(txtBoxId).value) )
{
    document.getElementById(labelId).innerText=message;
}
else
{
   document.getElementById(labelId).innerText="";
}
}
}
  
this.doReg = function(reg,op)
{
    return reg.test(op);
}
    
//验证Email格式
function validateEmail(txtBoxId,labelId,labelMsgId,message)
{
    if(document.getElementById(txtBoxId).value.length>0)
    {
        //验证Email的正则表达式
        RegEmail = /^\w+([\.\-]\w+)*\@\w+([\.\-]\w+)*\.\w+$/;
    
        if( !this.doReg(this.RegEmail,document.getElementById(txtBoxId).value) )
        {
            document.getElementById(labelId).innerText=message;
            document.getElementById(labelMsgId).innerText="";
        }
        else
        {
            document.getElementById(labelId).innerText="";
            document.getElementById(labelMsgId).innerText="邮箱地址";
        }
    }
    else
    {
            document.getElementById(labelId).innerText="请输入用户名";
            document.getElementById(labelMsgId).innerText="";
    }
}

//验证textbox是否为空
function validatePasswordNull(txtBoxId,labelId,labelMsgId)
{
    document.getElementById(labelId).innerText="";
    if(document.getElementById(txtBoxId).value.length<1)
    {
        //lable显示错误消息
        document.getElementById(labelId).innerText="请输入密码";
        document.getElementById(labelMsgId).innerText="";
    }
    else
    {
        document.getElementById(labelId).innerText="";
        document.getElementById(labelMsgId).innerText="6-16位字符，可由英文及数字组成";
    }
}

	     //验证textbox是否相同
function validateSamePassword(txtBoxId,txtBoxId2,labelId)
{
    document.getElementById(labelId).innerText="";
    if(document.getElementById(txtBoxId).value.length<1)
    {
          //lable显示错误消息
        document.getElementById(labelId).innerText="请再次输入密码";
    }
    else if(document.getElementById(txtBoxId).value == document.getElementById(txtBoxId2).value)
    {
        document.getElementById(labelId).innerText="";
    }
    else
    {
        //lable显示错误消息
        document.getElementById(labelId).innerText="两次密码输入不一致";
    }
}