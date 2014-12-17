function GetUsbKey()
{
    var object = new ActiveXObject("UsbGetterByAPI.device");
    var count=object.Count();
    var usbkey;
    for(var i = 1;i<=object.Count();i++)
    {
        usbkey=object.key(i).replace("USB\\VID_","");
        usbkey=usbkey.replace("&PID_","");
        usbkey=usbkey.replace("\\","");
        $(".UsbKeyCount").val(count);
        $(".UsbKey").val(usbkey);
        break;
    }    	
    return true;
}