//$("#ApiUrl") : its is a hidden field in _layout.cshtml
//value set from gitapplication's web.config file , ApiUrl  key 
function CallAjaxGet(strURL, OnSuccess, OnFailure) {
     
    //var baseURl = location.protocol + "//" + location.hostname + ":" + (apiPort) + "/";
    strURL = $("#ApiUrl").val() + strURL;

    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        beforeSend: function (xhr) {

        },
        url: strURL,
        success: OnSuccess,
        error: OnFailure
        
    });
}