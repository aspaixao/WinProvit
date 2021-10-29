// JavaScript source code
function Logout() {
    sessionStorage.removeItem("wpToken");
    sessionStorage.removeItem("wpName");
    location.href = "../frontend/index.html";
}

function getCandidates() {
    var request;
    var $candidates = $('#tbody');
    
    $('#tCandidate tbody').empty();

    request = $.ajax({
        url: 'https://localhost:44379/candidate',
        type: "GET",
        success: function (candidates) {
            $.each(candidates, function (i, candidate) {
                $candidates.append(fCandidate(candidate));
            });
        }
    });
}

function fCandidate(c) {

    var div = '<tr>';
    div += '<td>'+c.name+'</td>';
    div += '<td>'+c.email+'</td>';
    div += '<td>'+c.phone+'</td>';
    div += '<td>';
    div += '<button type="button" class="btn btn-success btn-sm" onClick="EditCandidate(\''+c.id+'\')">Edit</button>';
    div += '<button type="button" class="btn btn-danger btn-sm"  onClick="DeleteCandidate(\''+c.id+'\')">Delete</button>';
    div += '</td>';
    div += '</tr>';

    return div;
}

function AddCandidate() {

    var code = $('#code').val();
    var name = $('#name').val();
    var email = $('#email').val();
    var phone = $('#phone').val();
    var address = $('#address').val();

    var jsonData = { Name: name, Email: email, Phone: phone, Address: address };

    var url = 'https://localhost:44379/candidate';

    if (code != "")
    {
        url = 'https://localhost:44379/candidate/'+code;
    }

    $.ajax({
        url: url,
        type: code != "" ? "PUT" : "POST",
        contentType: 'application/json',
        dataType: 'json',
        cors: "cors",
        headers:{ 'Authorization': 'Bearer '+getToken()},
        data: JSON.stringify(jsonData),
        success: function (resp) {
            alert("Candidate saved with success");
            getCandidates();
            clearForm();
        },
        error: function (err) {
            alert(JSON.stringify(err)); 
        }
    });
}

function DeleteCandidate(code) {
    var url = 'https://localhost:44379/candidate/'+code;

    $.ajax({
        url: url,
        type: "DELETE",
        cors: "cors",
        headers:{ 'Authorization': 'Bearer '+getToken()},
        success: function (resp) {
            alert("Candidate excluded!");
            getCandidates();
        },
        error: function (err) {
            alert(JSON.stringify(err)); 
        }
    }); 
}

function EditCandidate(code) {
    var url = 'https://localhost:44379/candidate/'+code;

    $.ajax({
        url: url,
        type: "GET",
        cors: "cors",
        headers:{ 'Authorization': 'Bearer '+getToken()},
        success: function (resp) {
            $('#code').val(resp.id);
            $('#name').val(resp.name);
            $('#email').val(resp.email);
            $('#phone').val(resp.phone);
            $('#address').val(resp.address);
        },
        error: function (err) {
            alert(JSON.stringify(err)); 
        }
    });

}

function clearForm() {
    $('#code').val("");
    $('#name').val("");
    $('#email').val("");
    $('#phone').val("");
    $('#address').val("");
}

function getToken() {
    var token = JSON.parse(sessionStorage.getItem("wpToken"));
    
    return token;
}

function VerifyPage() {
    
    var token = sessionStorage.getItem("wpToken");

    if (token == null || token == 'undefined' || token == "") {
        alert("Not authorized");
        location.href = "../frontend/index.html";
    }
}

function AddUser() {

    var username = $('#username').val();
    var password = $('#password').val();

    var jsonData = { Username: username, Password: password, Role: 0 };

    var url = 'https://localhost:44379/identity/Register';

    alert(JSON.stringify(jsonData));

    $.ajax({
        url: url,
        type: "POST",
        contentType: 'application/json',
        dataType: 'json',
        cors: "cors",
        headers:{ 'Authorization': 'Bearer '+getToken()},
        data: JSON.stringify(jsonData),
        success: function (resp) {
            alert("User saved with success");
            clearFormUser();
        },
        error: function (err) {
            alert(JSON.stringify(err)); 
        }
    });
}

function clearFormUser() {
    $('#username').val("");
    $('#password').val("");
}


function GetUserName() {
    var name = sessionStorage.getItem("wpName");
    $('divName').val(name);
}


VerifyPage();
GetUserName();