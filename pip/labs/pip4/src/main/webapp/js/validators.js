function passwordCheck(login, password) {
    if (login.length < 5 || login.length > 20)
        return "Длина логина должна быть в диапазоне от 5 до 20 символов!";
    if (password.length < 5 || password.length > 20)
        return "Длина пароля должна быть в диапазоне от 5 до 20 символов!";
}

function validateSignup(form) {
    let login = form.login.value;
    let password = form.password.value;
    let repeat_password = form.repeatPassword.value;
    let error = passwordCheck(login, password);

    if (password !== repeat_password)
        error = "Пароли не совпадают!";

    if (error){
        $("#errorLabel").text(error);
        return false;
    } 
    return true;
}

function validateLogin(form) {
    let login = form.login.value;
    let password = form.password.value;
    let error = passwordCheck(login, password);

    if (error){
        $("#errorLabel").text(error);
        return false;
    }
    return true;
}

function validateInput(form) {
    function isNumeric(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }

    let y = form.Y.value;
    let error;

    if (!isNumeric(y)) error = "Y введён некорректно.";
    else if (y < -5 || y > 3) error = "Y должен быть в диапазоне от -5 до 3.";

    if (error){
        $("#errorLabel").text(error);
        return false;
    }
    $("#errorLabel").text("");
    return true;
}