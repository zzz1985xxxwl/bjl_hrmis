//created by wsl
//Implement in client page,以下函数实现在客户端,函数名小写开头
//postResponseClient(responseString)
var xmlHttpList = new Array();
var xmlHttpCount=0;
function JsAjaxCreateXMLHttpRequest(xmlHttp)
{
    if(window.ActiveXObject)
    {
        xmlHttp=new ActiveXObject("Microsoft.XMLHTTP");
    }
    else if(window.XMLHttpRequest)
    {
        xmlHttp=new XMLHttpRequest;
    }
    return xmlHttp;
}

function JsAjaxPostRequestServer(url)
{
    var xmlHttp;
    xmlHttp=JsAjaxCreateXMLHttpRequest(xmlHttp);  
    xmlHttpList[xmlHttpCount]=xmlHttp;
    xmlHttpCount=xmlHttpCount+1;
    xmlHttp.open("post",url,true);
    xmlHttp.onreadystatechange=function () { JsAjaxCallback(xmlHttp); };
    xmlHttp.setRequestHeader("Content-Type","application/x-www-form-urlencoded;charset=utf-8");
    xmlHttp.send(null);   
}

function JsAjaxCallback(xmlHttp)
{
    if(xmlHttp.readyState == 4)
    {
        if(xmlHttp.status == 200)
        {
            var responseString = xmlHttp.responseText;
            postResponseClient(responseString);
        }
    }
}
function AbortxmlHttp(){   

    for(var i=0;i<xmlHttpCount;i++) 
    {
        if(xmlHttpList[i].readyState!=4)
        {   
            xmlHttpList[i].abort();
        }   
    }
} 