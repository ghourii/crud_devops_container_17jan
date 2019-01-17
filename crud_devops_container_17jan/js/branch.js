$(function () {
    loadbranch();
    LoadDept();
    
   
   
});

var loadbranch= function ()


{

    $.ajax({
        type: "POST",
        url: "/Employee/LoadBranch",
       
       
        success: function (res) {
            $('#drpDiv').html(res);
        }
    });

}



var loadDivisions = function () {
    $.ajax({
        url: "/SchemeView/LoadDivisions",
        type: "POST",
        success: function (res) {
            $('#drpDiv').html(res);
        }
    });
}

var LoadDept = function () {

    $.ajax({
        type: "POST",
        url: "/Employee/LoadDept",

       
        success: function (res) {
            $('#drpDept').html(res);
        }
    });

}