window.addEventListener('load', function (e) {
    let email = localStorage.getItem('LoginEmail');
    const arr = email.split("@");
    let trainerId = arr[0];
    fetch(`https://localhost:44329/api/Trainer/Trainer?id=${trainerId}`)
        .then(response => response.json())
        .then(trainer => show(trainer));
    
    
   
       fetch(`https://localhost:44329/api/College/College?trainerid=${trainerId}`)
        .then(response => response.json())
        .then(college => showCollege(college));
    
   https://localhost:44329/HighSchool?trainerid=donald12

          fetch(`https://localhost:44329/HighSec?trainerid=${trainerId}`)
        .then(response => response.json())
        .then(hsc => showHSC(hsc));
    
     fetch(` https://localhost:44329/HighSchool?trainerid=${trainerId}`)
        .then(response => response.json())
        .then(hs => showHS(hs));
  

     fetch(`https://localhost:44329/Skill?trainerid=${trainerId}`)
        .then(response => response.json())
        .then(skills => showSkills(skills));

       fetch(`https://localhost:44329/company?trainerid=${trainerId}`)
        .then(response => response.json())
        .then(companyArr => showCompanies(companyArr));

});

function show(trainer) {
    document.getElementById('b_name').innerText = trainer.t_FirstName + " " + trainer.t_LastName;
    document.getElementById('b_phone').innerText = trainer.t_PhoneNo;
    document.getElementById('b_city').innerText = trainer.t_City;
    localStorage.setItem('bphone', trainer.t_PhoneNo);
    localStorage.setItem('bcity', trainer.t_City);
}

function showCollege(college) {
    document.getElementById("c_college").innerText = college.uG_CollegeName;
    document.getElementById("c_degree").innerText = college.uG_Degree;
    document.getElementById("c_branch").innerText = college.uG_Branch;
    document.getElementById("c_year").innerText = college.uG_YearPassed;
    localStorage.setItem('ctrainerId', college.uG_TrainerId);
    localStorage.setItem('cname', college.uG_CollegeName);
    localStorage.setItem('cbranch', college.uG_Branch);
    localStorage.setItem('cdegree', college.uG_Degree);
    localStorage.setItem('cyear', college.uG_YearPassed);
}

function showHSC(hsc) {
    document.getElementById("hsc_school").innerText = hsc.hsC_SchoolName;
    document.getElementById("hsc_course").innerText = hsc.hsC_Course;
    document.getElementById("hsc_year").innerText = hsc.hsC_YearPassed;
    localStorage.setItem('hscschool', hsc.hsC_SchoolName);
    localStorage.setItem('hsccourse', hsc.hsC_Course);
    localStorage.setItem('hscyear', hsc.hsC_YearPassed);
    
}

function showHS(hs) {
    document.getElementById("hs_school").innerText = hs.hS_SchoolName;
    document.getElementById("hs_year").innerText = hs.hS_YearPassed;
    localStorage.setItem('hsschool', hs.hS_SchoolName);
    localStorage.setItem('hsyear', hs.hS_YearPassed);

}



function showSkills(skills) {
    document.getElementById("skill1").innerText = skills.sK_Skill1;
    document.getElementById("skill2").innerText = skills.sK_Skill2;
    document.getElementById("skill3").innerText = skills.sK_Skill3;
    document.getElementById("skill4").innerText = skills.sK_Skill4;
    document.getElementById("skillpr").innerText = skills.sK_Skill1;
    localStorage.setItem('skill1', skills.sK_Skill1);
    localStorage.setItem('skill2', skills.sK_Skill2);
    localStorage.setItem('skill3', skills.sK_Skill3);
    localStorage.setItem('skill4', skills.sK_Skill4);


}

function showCompanies(companyArr) {
    let main = document.getElementById("expcard");
    let output = '<div class="card experience" style="width:18rem">';
    output += '<div class="card-body">';
    output += '<h4 class="card-title mb-2">';
    output += 'Experience';
    output += ' </h4>';        
  
                                 
    for (let comp of companyArr) {
        output+=` <p class="card-title" style="font-weight: bold"> Company: <span class="card-text text-muted "
                            class="companies">${comp.c_LastCompanyName} ${comp.c_TotalExp} year(s)</span></p>`
    }
    output+='  <i class="bi bi-pencil-fill" onclick="RedirectToEditExperience()"></i>'
    output += '</div>';
    output += '</div>';
    
    main.insertAdjacentHTML('afterbegin',output);

}

function RedirectToEditCollege() {
    window.location.href = "../EditPages/EditCollegePage.html";
}

function RedirecToEditBasic() {
    window.location.href = "../EditPages/EditBasicPage.html";
}

function RedirectToEditHighSchool() {
    window.location.href = "../EditPages/EditHighSchool.html";
}

function RedirectToEditHighSec() {
     window.location.href = "../EditPages/EditHighSec.html";
}

function RedirectToEditSkills() {
    window.location.href = "../EditPages/EditSkillsPage.html";
}

function RedirectToEditExperience(){
    window.location.href = "../EditPages/EditExperiencePage.html";
}

function deleteAccount() {
      var choice = confirm("Do you want to delete the account ?");
    if (choice) {
        let options = {
            method: "DELETE"
        }; 
           fetch(`https://localhost:44329/api/Trainer/Trainer/Delete/account?trainerid=${localStorage.getItem('LoginEmail').split('@')[0]}`, options)
        .then((response) => {
            if (response.ok) {
                alert("account deleted successfully");
                window.location.href = "../HomePage/HomePage.html";
            }
               
        });
        }
}