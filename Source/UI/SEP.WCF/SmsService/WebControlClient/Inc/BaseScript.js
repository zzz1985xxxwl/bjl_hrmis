try
{
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
}
catch(ex){}
function EndRequestHandler(sender, args) 
{ 
    if (args.get_error() != undefined) 
    { 
        window.location.reload(); 

        args.set_errorHandled(true); 
    } 
}  
