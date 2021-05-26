// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function MessageSuccessServ() {
    if ($("#nomServ").val() != "") {
        swal("Registro Exitoso", "El servicio se registró satisfactoriamente", "success");
        return false;
    }
}
function MessageEditSuccessServ() {
    if ($("#nomServ").val() != "") {
        swal("Edición Exitosa", "El servicio se editó satisfactoriamente", "success");
        return false;
    }
}
function MessageDeleteSuccessServ() {
    swal("Eliminación Exitosa", "El servicio se eliminó satisfactoriamente", "success");    
    return false;
}
function MessageSuccessInfo() {
    if ($("#nomEmpre").val() != "" && $("#location").val() != "" && $("#email").val() != "" && $("#cel").val() != "") {
        swal("Registro Exitoso", "La información se registró satisfactoriamente", "success");
        return false;
    }
}
function MessageEditSuccessInfo() {
    if ($("#nomEmpre").val() != "" && $("#location").val() != "" && $("#email").val() != "" && $("#cel").val() != "") {
        swal("Edición Exitosa", "La información se editó satisfactoriamente", "success");
        return false;
    }
}
function MessageDeleteSuccessInfo() {
    swal("Eliminación Exitosa", "La información se eliminó satisfactoriamente", "success");
    return false;
}
function MessageSuccessProd() {
    if ($("#nomProd").val() != "" && $("#price").val() != "" && $("#img").val() != "") {
        swal("Registro Exitoso", "El producto se registró satisfactoriamente", "success");
        return false;
    }
}
function MessageEditSuccessProd() {
    if ($("#nomProd").val() != "" && $("#price").val() != "" && $("#img").val() != "") {
        swal("Edición Exitosa", "El producto se editó satisfactoriamente", "success");
        return false;
    }
}
function MessageDeleteSuccessProd() {
    swal("Eliminación Exitosa", "El producto se eliminó satisfactoriamente", "success");
    return false;
}


