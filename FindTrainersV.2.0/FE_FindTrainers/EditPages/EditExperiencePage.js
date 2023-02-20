window.addEventListener('load', function (e) {
 let email = localStorage.getItem('LoginEmail');
    const arr = email.split("@");
    let trainerId = arr[0];
      fetch(`https://localhost:44329/company?trainerid=${trainerId}`)
        .then(response => response.json())
        .then(companyArr => showCompanies(companyArr));
    
});



function showCompanies(companyArr) {
    let output = '';
    const main = document.getElementById("main");
    let row = 1;
    for (let comp of companyArr) {
        output += `<tr> 
                <th scope="row">${row}</th>
                <td>${comp.c_LastCompanyName}</td>
                <td>${comp.c_TotalExp}</td>
                <tr>`
        row++;
        
    }
    main.insertAdjacentHTML('afterbegin', output);

}

const nameRegex = new RegExp("\\w{3,50}");

function updateExperience() {
    var newCompany = prompt('Enter the new Company');
    var newExp = prompt('Enter the new Experience');
  if (!nameRegex.test(newCompany.trim())) {
        alert("Enter proper value");
    }
  else {

       let options = {
                        method: "PUT",
                        Headers: {"Content-type": "text/json"},
                        
      }

        fetch(`https://localhost:44329/Company/update?company=${newCompany}&exp=${newExp}&email=${localStorage.getItem('LoginEmail')}`, options)
            .then((response) => {
                if (response.status == 200) {
                    window.location.href = "EditExperiencePage.html";
                }
            });        
      
    }

}

function deleteExperience() {
    var companyName = prompt("Enter the company name");
    var choice = confirm("Are you sure?");

    if(choice){
           let options = {
            method: "DELETE"
        }; 
           fetch(`https://localhost:44329/Company/delete?company=${companyName.trim()}&email=${localStorage.getItem('LoginEmail')}`, options)
        .then((response) => {
            if (response.ok) {
               window.location.href = "EditExperiencePage.html";
            }
              
        });
    }
}