window.addEventListener('load', function (e) {
    document.getElementById("cname").innerText = localStorage.getItem('cname');
    document.getElementById("cdegree").innerText = localStorage.getItem('cdegree');
    document.getElementById("cbranch").innerText = localStorage.getItem('cbranch');
    document.getElementById("cyear").innerText = localStorage.getItem('cyear');
});

const nameRegex = new RegExp("\\w{3,50}");
function editCollegename() {
    var newName = prompt('Enter the new college name');
    if (!nameRegex.test(newName.trim())) {
        alert("Enter proper value");
    }
    else {
          let options = {
                        method: "PUT",
                        Headers: {"Content-type": "text/json"},
                    }
        fetch(`https://localhost:44329/api/College/College/Update/name?Newvalue=${newName}&email=${localStorage.getItem('LoginEmail')}`, options)
            .then((response) => {
                if (response.status == 200) {
                    localStorage.setItem('cname', newName);
                    window.location.href = "EditCollegePage.html";
                }
            });        
    }
    
}

const yearRegex = new RegExp("^\\d{4}$");
const degreeRegex = new RegExp("^B\\.\\w{1,6}$");


function editDegree() {
    var newName = prompt('Enter the new degree');
    if (!degreeRegex.test(newName.trim())) {
        alert("Enter proper value");
    }
    else {
          let options = {
                        method: "PUT",
                        Headers: {"Content-type": "text/json"},
                    }
        fetch(`https://localhost:44329/api/College/College/Update/degree?Newvalue=${newName}&email=${localStorage.getItem('LoginEmail')}`, options)
            .then((response) => {
                if (response.status == 200) {
                    localStorage.setItem('cdegree', newName);
                    window.location.href = "EditCollegePage.html";
                }
            });        
    }
    
}

function editBranch() {
    var newName = prompt('Enter the new branch');
    if (!nameRegex.test(newName.trim())) {
        alert("Enter proper value");
    }
    else {
          let options = {
                        method: "PUT",
                        Headers: {"Content-type": "text/json"},
                    }
        fetch(`https://localhost:44329/api/College/College/Update/branch?Newvalue=${newName}&email=${localStorage.getItem('LoginEmail')}`, options)
            .then((response) => {
                if (response.status == 200) {
                    localStorage.setItem('cbranch', newName);
                    window.location.href = "EditCollegePage.html";
                }
            });        
    }
    
}

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
        fetch(`https://localhost:44329/api/College/College/Update/year?Newvalue=${newName}&email=${localStorage.getItem('LoginEmail')}`, options)
            .then((response) => {
                if (response.status == 200) {
                    localStorage.setItem('cyear', newName);
                    window.location.href = "EditCollegePage.html";
                }
            });        
    }
    
}

function deleteyear() {
    var choice = confirm('Are you sure?');
    if (choice) {
           let options = {
            method: "DELETE"
        }; 
        https://localhost:44329/api/College/College/Delete/branch?email=donald12%40gmail.com
           fetch(` https://localhost:44329/api/College/College/Delete/yearpassed?email=${localStorage.getItem('LoginEmail')}`, options)
        .then((response) => {
            if (response.ok) {
                 localStorage.setItem('cyear', '');
               window.location.href = "EditCollegePage.html";
            }
              
        });
    }
}

function deletebranch() {
    var choice = confirm('Are you sure?');
    if (choice) {
           let options = {
            method: "DELETE"
        }; 
           fetch(` https://localhost:44329/api/College/College/Delete/branch?email=${localStorage.getItem('LoginEmail')}`, options)
        .then((response) => {
            if (response.ok) {
                  localStorage.setItem('cbranch', '');
               window.location.href = "EditCollegePage.html";
            }
              
        });
    }
}

function deletename() {
    var choice = confirm('Are you sure?');
    if (choice) {
           let options = {
            method: "DELETE"
        }; 
     
           fetch(` https://localhost:44329/api/College/College/Delete/name?email=${localStorage.getItem('LoginEmail')}`, options)
        .then((response) => {
            if (response.ok) {
                  localStorage.setItem('cname', '');
               window.location.href = "EditCollegePage.html";
            }
              
        });
    }
}

function deletedegree() {
    var choice = confirm('Are you sure?');
    if (choice) {
           let options = {
            method: "DELETE"
        }; 
       
           fetch(` https://localhost:44329/api/College/College/Delete/degree?email=${localStorage.getItem('LoginEmail')}`, options)
        .then((response) => {
            if (response.ok) {
                  localStorage.setItem('cdegree', '');
               window.location.href = "EditCollegePage.html";
            }
              
        });
    }
}