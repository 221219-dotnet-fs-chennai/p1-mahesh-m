
const form = document.getElementById("form");
const email = document.getElementById("email");
const password = document.getElementById("password");

form.addEventListener('submit', e => {
    e.preventDefault();
    
    validateInputs();
});

function setError(element, message) {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector(".error");
    errorDisplay.innerText = message;

    inputControl.classList.add('error');
    inputControl.classList.remove('success');
}

function setSuccess(element, message) {
      const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector(".error");
    errorDisplay.innerText = message;

    inputControl.classList.add('success');
    inputControl.classList.remove('error')
}

const emailReg = new RegExp("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+\.[a-z]{2,6}$");
const passReg=new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$");

function validateInputs(){
    const emailVal = email.value.trim();
    const passwordVal = password.value.trim();


    if (!emailReg.test(emailVal)) {
        setError(email, "Invalid email format");
    }
    else {
        setSuccess(email, '');
    }

    if (!passReg.test(passwordVal)) {
        setError(password, "min 8 characters, 1 smallcase,1 uppercase,1 number");
    }
    else {
        setSuccess(password, '');
    }
    authUser(emailVal, passwordVal);
}




// function isValidformat(email, password) {
//     if (emailReg.test(email) && passReg.test(passReg)) {
//         console.log("valid format");
//         return true;
//     }
//     else {
//         return false;
//     }
    
// }

function authUser(email,pass) {
    fetch(`https://localhost:44329/api/Trainer/Trainer/Login?username=${email}&password=${pass}`)
        .then((response) => { 
            if (response.status == 200) {
                localStorage.setItem('LoginEmail', email);
                window.location.href = "../RedirectionPages/LoginSuccess.html";
            }
            else {
                window.location.href = "../RedirectionPages/LoginFailed.html";
            }
        });
}


// function isValidLoginCredentials(email,password) {
//     fetch(`https://localhost:44329/api/Trainer/Trainer/Login?username=${email}&password=${password}`)
//         .then(reponse => console.log(reponse.status))
//         .then(response=> function (response) { if (!response.status != 200) { return false } else { return true } });
        
// }