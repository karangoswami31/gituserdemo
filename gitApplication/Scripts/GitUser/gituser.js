if (typeof _gitUser === 'undefined') {
    _gitUser = {};
};

_gitUser.getUserDetail = function () {
    $("#spnsearch").show()
    _gitUser.RequestForGetUerDetail($("#txtUserName").val());
   
};
//make a api call to get a user details
_gitUser.RequestForGetUerDetail = function(userdata) {
    var serviceUrl = 'api/GitUser/getuserdata?login=' + userdata + '';
    CallAjaxGet(serviceUrl, _gitUser.getUserDetailSuccess, _gitUser.getUserDetailFail);
   
}
//after getting a data from api 
//show div
//if there is no data then hide a div

_gitUser.getUserDetailSuccess = function (res) {
     
    _gitUser.clearData();
    if (res != null) {
        $("#divUserDetail").show();
        $("#divNoRecord").hide();
        $("#divimg img").attr('src', res.user.avatar_url);
        $(".username").html(res.user.name);
        $(".location").html(res.user.location);
        //if public_repos value is  > 0 then bind a repo list
        if (res.user.public_repos > 0) {
             
            _gitUser.bindRepoRecord(res.gitrepositorymodel);

        }
    }
    else {
        $("#divUserDetail").hide();
        $("#divNoRecord").show();
        $("#repoContainer").html('');
        $("#spnsearch").hide();
    }
}
//to bind a top 5 repository on page
_gitUser.bindRepoRecord = function (data) {
    var i = 0,
        arrLen = data.length - 1
    str = "";
			
    for (; i <= arrLen; i++) {
        str = str + '<div style="">'
            + '<span for="name"><b>Name:</b>"' + data[i].name + '" </span>'
            + '<span for="description"><b>description:</b>"' + data[i].description + '"</span>'
            + '<span for="stargazers_count"><b>count:</b>"' + data[i].stargazers_count + '"</span>'
            + ''
            + "</div><br>";
    };
    //append the markup to the DOM
    $("#repoContainer").html(str);
    $("#spnsearch").hide()
}
//while fail case 
_gitUser.getUserDetailFail = function (res) {
    $("#spnsearch").hide()     
}
//this function is use for clean a controller

_gitUser.clearData = function () {
    $("#divimg img").attr('src', '');
    $(".username").html('');
    $(".location").html('');
    $(".username").html('');
}