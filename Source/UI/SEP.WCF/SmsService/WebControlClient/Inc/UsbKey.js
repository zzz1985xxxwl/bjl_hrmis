    
    timer=setInterval("GetUsbKey()",2000); 
    function GetUsbKey()
    {
    var object = new ActiveXObject("usbdevinfo.device");
    var count=object.GetDeviceNumber();
    var usbkey=object.GetDeviceID(count);
    document.getElementById("lbUsbKeyCount").value=count;
    document.getElementById("lbUsbKey").value=usbkey;
    }