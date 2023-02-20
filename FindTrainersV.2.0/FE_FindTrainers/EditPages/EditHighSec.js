window.addEventListener('load', function (e) {
    document.getElementById("hscname").innerText = localStorage.getItem('hscschool');
    document.getElementById("hscyear").innerText = localStorage.getItem('hscyear');
        document.getElementById("hsccourse").innerText = localStorage.getItem('hsccourse');
});

const nameRegex = new RegExp("\\w{3,50}");
function editSchoolname() {
    var newName = prompt('Enter the new school name');
    if (!nameRegex.test(newName.trim())) {
        alert("Enter proper value");
    }
    else {
          let options = {
                        method: "PUT",
                        Headers: {"Content-type": "text/json"},
                    }
        fetch(`https://localhost:44329/HighSec/Update/name?Newvalue=${newName}&email=${localStorage.getItem('LoginEmail')}`, options)
            .then((response) => {
                if (response.status == 200) {
                    localStorage.setItem('hscschool', newName);
                    window.location.href = "EditHighSec.html";
                }
            });        
    }
    
}

function editCourse() {
    var newName = prompt('Enter the new course');
    if (!nameRegex.test(newName.trim())) {
        alert("Enter proper value");
    }
    else {
          let options = {
                        method: "PUT",
                        Headers: {"Content-type": "text/json"},
                    }
        fetch(`https://localhost:44329/HighSec/Update/course?Newvalue=${newName}&email=${localStorage.getItem('LoginEmail')}`, options)
            .then((response) => {
                if (response.status == 200) {
                    localStorage.setItem('hsccourse', newName);
                    window.location.href = "EditHighSec.html";
                }
            });        
    }
    
}

const yearRegex = new RegExp("^\\d{4}$");
function editYear() {
    var newName = prompt('Enter the new year of passing');
    if (!yearRegex.test(newName.trim())) {
        alert("Enter proper value");
    }
    else {
          let options = {
                        method: "PUT",
                        Headers: {"Content-type": "text/json"},
                    }
        fetch(`https://localhost:44329/HighSec/Update/year?Newvalue=${newName}&email=${localStorage.getItem('LoginEmail')}`, options)
            .then((response) => {
                if (response.status == 200) {
                    localStorage.setItem('hscyear', newName);
                    window.location.href = "EditHighSec.html";
                }
            });        
    }
    
}


function deleteSchool() {

    var choice = confirm("Do you want to the school name ?");
    if (choice) {
        let options = {
            method: "DELETE"
        }; 
           fetch(`https://localhost:44329/HighSec/Delete/schoolname?email=${localStorage.getItem('LoginEmail')}`, options)
        .then((response) => {
            if (response.ok) {
                localStorage.setItem('hscschool', "");
            }
               window.location.href = "EditHighSec.html";
        });
        }
 
    }

    function deleteCourse() {

    var choice = confirm("Do you want to delete the course?");
    if (choice) {
        let options = {
            method: "DELETE"
        }; 
           fetch(`https://localhost:44329/HighSec/Delete/course?email=${localStorage.getItem('LoginEmail')}`, options)
        .then((response) => {
            if (response.ok) {
                localStorage.setItem('hsccourse', "");
            }
               window.location.href = "EditHighSec.html";
        });
        }
 
    }


    function deleteYear() {

    var choice = confirm("Do you want to delete the year of passing ?");
    if (choice) {
        let options = {
            method: "DELETE"
        }; 
           fetch(`https://localhost:44329/HighSec/Delete/yearpassed?email=${localStorage.getItem('LoginEmail')}`, options)
        .then((response) => {
            if (response.ok) {
                localStorage.setItem('hscyear', "");
            }
               window.location.href = "EditHighSec.html";
        });
        }
 
    }