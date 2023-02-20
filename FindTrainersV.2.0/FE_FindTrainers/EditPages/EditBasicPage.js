window.addEventListener('load', function (e) {
    document.getElementById("bphone").innerText = localStorage.getItem('bphone');
    document.getElementById("bcity").innerText = localStorage.getItem('bcity');
});

const phoneRegex = new RegExp("^[9876]\\d{9}$");
const nameRegex = new RegExp("\\w{3,50}");

function editPhone() {
    var newName = prompt('Enter the new Phone no');
    if (!phoneRegex.test(newName.trim())) {
        alert("Enter proper value");
    }
    else {
          let options = {
                        method: "PUT",
                        Headers: {"Content-type": "text/json"},
                    }
        fetch(`https://localhost:44329/api/Trainer/Trainer/Update/PhoneNo?Newvalue=${newName}&email=${localStorage.getItem('LoginEmail')}`, options)
            .then((response) => {
                if (response.status == 200) {
                    localStorage.setItem('bphone', newName);
                    window.location.href = "EditBasicPage.html";
                }
            });        
    }
    
}

function editCity() {
    var newName = prompt('Enter the new city');
    if (!nameRegex.test(newName.trim())) {
        alert("Enter proper value");
    }
    else {
          let options = {
                        method: "PUT",
                        Headers: {"Content-type": "text/json"},
                    }
        fetch(`https://localhost:44329/api/Trainer/Trainer/Update/City?Newvalue=${newName}&email=${localStorage.getItem('LoginEmail')}`, options)
            .then((response) => {
                if (response.status == 200) {
                    localStorage.setItem('bcity', newName);
                    window.location.href = "EditBasicPage.html";
                }
            });        
    }
    
}

function deletePhone() {

    var choice = confirm("Do you want to delete the phone no. ?");
    if (choice) {
        let options = {
            method: "DELETE"
        }; 
           fetch(`https://localhost:44329/api/Trainer/Trainer/Delete/PhoneNo?email=${localStorage.getItem('LoginEmail')}`, options)
        .then((response) => {
            if (response.ok) {
                localStorage.setItem('bphone', "");
            }
               window.location.href = "EditBasicPage.html";
        });
        }
 
    }
    
function deleteCity() {

    var choice = confirm("Do you want to delete the city ?");
    if (choice) {
        let options = {
            method: "DELETE"
        };
           fetch(`https://localhost:44329/api/Trainer/Trainer/Delete/City?email=${localStorage.getItem('LoginEmail')}`, options)
        .then((response) => {
            if (response.ok) {
                localStorage.setItem('bcity', "");
            }
               window.location.href = "EditBasicPage.html";
        });
        }
 
    }


