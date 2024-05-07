$(document).ready(function () {
    GetAddList();
    RedirectDetails();
});

let id = 0;
var Savereg = function () {
    debugger;
    var id = $("#HdnId").val();
    var name = $("#txtName").val();
    var email = $("#txtEmail").val();
    var mobile = $("#txtMobile").val();
    var feedback = $("#txtFeedback").val();
    var model = {
        ID: id,
        Name: name,
        Email: email,
        Mobile: mobile,
        Feedback: feedback,
    };

    if (name == "") {
        alert("Please Enter Your Name");
    }
    else if (email == "") {
        alert("please Enter your Email");
    }
    else if (mobile == "") {
        alert("please Enter your Mobile");
    }
    else if (feedback == "") {
        alert("please Enter your Feedback");
    }
        
    debugger;
    $.ajax({
        url: "/Feedback/Savereg",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.Message);
            GetAddList();
        },
        error: function (response) {
            alert(response.Message);
        }
    });
};

var GetAddList = function () {
    debugger;
    $.ajax({
        url: "/Feedback/GetAddList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            debugger;
            var html = "";
            $("#tblFeedback tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.ID +
                    "</td><td>" + elementValue.Name +
                    "</td><td>" + elementValue.Email +
                    "</td><td>" + elementValue.Mobile +
                    "</td><td>" + elementValue.Feedback +
                    "</td><td><input type='button' value='delete' class='btn btn-danger' onclick ='deleteFeedback(" + elementValue.ID + ")' /> &nbsp <input type='button' value='Edit'  class='btn btn-success' onclick ='GetUpdateFeed(" + elementValue.ID + ")'/> &nbsp <input type='button' value ='Redirect Details 'class='btn btn-info' onclick='Details(" + elementValue.ID + ")'/></td ></tr >";

            });

            $("#tblFeedback tbody").append(html);
        }



    });
}
var deleteFeedback = function (ID) {
    debugger;
    model = { ID: ID }
    $.ajax({
        url: "/Feedback/deleteFeedback",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.model);
                    
        }
    })
}

var GetUpdateFeed = function (ID) {
    debugger;
    ID = id;
    model = { ID : ID }
    $.ajax({
        url: "/Feedback/GetUpdateFeed",
        method: "get",
       // data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",

        success: function (response) {
            console.log(response);
            $("#HdnId").val(response.model.ID);
            $("#txtName").val(response.model.Name);
            $("#txtEmail").val(response.model.Email);
            $("#txtMobile").val(response.model.Mobile);
            $("#txtFeedback").val(response.model.Feedback);

        }
    });
}
var Details = function (ID) {
    id = ID;
    window.location.href = "/Feedback/DetailsIndex?ID=" + ID;
}
var RedirectDetails = function () {
    var ID = id;
    debugger;
    model = { ID: ID }
    $.ajax({
        url: "/Feedback/GetUpdateFeed",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            debugger;
            $("#HdnId").text(response.model.ID);
            $("#txtname").text(response.model.Name);
            $("#txtemail").text(response.model.Email);
            $("#txtmobile").text(response.model.Mobile);
            $("#txtFeedback").text(response.model.Feedback);
        }
    });

}
