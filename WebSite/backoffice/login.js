// JavaScript source code
function Validate() {
    var errorMessage = "";
    var u = $("#user").val();
    var p = $("#password").val();

    if (u == "" || p == "") {
        alert("Username or Password can not is empty");
        return;
    }

    var url = 'https://localhost:44379/identity/Login';
    var jsonData = { Username: u, Password: p };

    $.ajax({
        url: url,
        type: "POST",
        contentType: 'application/json',
        dataType: 'json',
        cors: 'cors',
        data: JSON.stringify(jsonData),
        success: function (login) {
            sessionStorage.setItem("wpName", JSON.stringify(login.userName));
            sessionStorage.setItem("wpToken", JSON.stringify(login.token));
            location.href = "index.html";
        },
        error: function (err) {
            errorMessage = err.responseJSON;
            alert(errorMessage.message);
        }
    });
    
}