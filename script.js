// JavaScript source code
function Logout() {
    sessionStorage.removeItem("wpName");
    sessionStorage.removeItem("wpToken");

    location.href = "./frontend/index.html";
}