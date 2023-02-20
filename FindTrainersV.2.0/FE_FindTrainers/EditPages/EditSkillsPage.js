window.addEventListener('load', function (e) {
    document.getElementById("skill1").innerText = this.localStorage.getItem('skill1');
    document.getElementById("skill2").innerText = this.localStorage.getItem('skill2');
    document.getElementById("skill3").innerText = this.localStorage.getItem('skill3');
    document.getElementById("skill4").innerText = this.localStorage.getItem('skill4');
    
});


const nameRegex = new RegExp("\\w{3,50}");
function editSkill(skill) {
    var newName = prompt('Enter the new skill');
    if (!nameRegex.test(newName.trim())) {
        alert("Enter proper value");
    }
    else {
          let options = {
                        method: "PUT",
                        Headers: {"Content-type": "text/json"},
                    }
        fetch(`https://localhost:44329/Skill/Update/${skill}?Newvalue=${newName}&email=${localStorage.getItem('LoginEmail')}`, options)
            .then((response) => {
                if (response.status == 200) {
                    localStorage.setItem(`${skill}`, newName);
                    window.location.href = "EditSkillsPage.html";
                }
            });        
    }
    
}


function deleteSkill(skill) {

    var choice = confirm("Do you want to the skill ?");
    if (choice) {
        let options = {
            method: "DELETE"
        }; 
           fetch(`https://localhost:44329/Skill/Delete/${skill}?email=${localStorage.getItem('LoginEmail')}`, options)
        .then((response) => {
            if (response.ok) {
                localStorage.setItem(`${skill}`, "");
            }
               window.location.href = "EditSkillsPage.html";
        });
        }
 
    }
