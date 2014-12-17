//created by wsl
//Implement in client page
//getRequestInfo()
//checkValid()
//postResponseClient(responseString)
var xmlHttp;
function JsAjaxCreateXMLHttpRequest()
{
    if(window.ActiveXObject)
    {
        xmlHttp=new ActiveXObject("Microsoft.XMLHTTP");
    }
    else if(window.XMLHttpRequest)
    {
        xmlHttp=new XMLHttpRequest;
    }
}

function JsAjaxPostRequestServer(url)
{
    getRequestInfo();
    if(checkValid())
    {
        JsAjaxCreateXMLHttpRequest();
        xmlHttp.open("post",url,true);
        xmlHttp.onreadystatechange=JsAjaxCallback;
        xmlHttp.setRequestHeader("Content-Type","application/x-www-form-urlencoded;charset=utf-8");
        xmlHttp.send(null);
    }
    
}

function JsAjaxCallback()
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
