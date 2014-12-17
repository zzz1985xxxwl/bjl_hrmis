
var _URL;
function KeepConnect(URL){
    _URL =URL;
    TimeCycleConnect();
}
function TimeCycleConnect(){
 VisitServer(_URL);
 setTimeout("TimeCycleConnect()",600000);
}

function VisitServer(url)
{    
        $.ajax(
        {
            url: url,
            dataType: 'json',
            data: 
                {
                    type: "Initial"
                },
            type: "post",
            cache: false,
            success: function(ans) {
            }
        });
        
}

