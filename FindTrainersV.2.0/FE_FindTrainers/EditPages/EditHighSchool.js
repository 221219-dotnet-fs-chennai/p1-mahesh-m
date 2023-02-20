window.addEventListener('load', function (e) {
    document.getElementById("hsname").innerText = localStorage.getItem('hsschool');
    document.getElementById("hsyear").innerText = localStorage.getItem('hsyear');
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
        fetch(`https://localhost:44329/HighSchool/Update/name?Newvalue=${newName}&email=${localStorage.getItem('LoginEmail')}`, options)
            .then((response) => {
                if (response.status == 200) {
                    localStorage.setItem('hsschool', newName);
                    window.location.href = "EditHighSchool.html";
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
        fetch(`https://localhost:44329/HighSchool/Update/year?Newvalue=${newName}&email=${localStorage.getItem('LoginEmail')}`, options)
            .then((response) => {
                if (response.status == 200) {
                    localStorage.setItem('hsyear', newName);
                    window.location.href = "EditHighSchool.html";
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
           fetch(`https://localhost:44329/HighSchool/Delete/schoolname?email=${localStorage.getItem('LoginEmail')}`, options)
        .then((response) => {
            if (response.ok) {
                localStorage.setItem('hsschool', "");
            }
               window.location.href = "EditHighSchool.html";
        });
        }
 
    }



    function deleteYear() {

    var choice = confirm("Do you want to delete the year of passing ?");
    if (choice) {
        let options = {
            method: "DELETE"
        }; 
           fetch(`https://localhost:44329/HighSchool/Delete/yearpassed?email=${localStorage.getItem('LoginEmail')}`, options)
        .then((response) => {
            if (response.ok) {
                localStorage.setItem('hsyear', "");
            }
               window.location.href = "EditHighSchool.html";
        });
        }
 
    }