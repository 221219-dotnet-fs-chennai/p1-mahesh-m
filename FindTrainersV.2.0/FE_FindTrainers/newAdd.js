function help() {
       let formval = document.getElementById("form1");

    formval.addEventListener('submit', function (e) { e.preventDefault(); });
    
    var fname = document.getElementById("fname").value;
    var lname = document.getElementById("lname").value;
    var email = document.getElementById("email").value;
    var phone = document.getElementById("phone").value;
    var password = document.getElementById("password").value;
    var city = document.getElementById("city").value;


    var college = document.getElementById("collegename").value;
    var cyearpassed = document.getElementById("yearpassedc").value;
    var branch = document.getElementById("branch").value;
    var degree = document.getElementById("degree").value;

    var skill1 = document.getElementById("sK_Skill1").value;
    var skill2 = document.getElementById("sK_Skill2").value;
    var skill3 = document.getElementById("sK_Skill3").value;
    var skill4 = document.getElementById("sK_Skill4").value;

    var hscname = document.getElementById("hsC_SchoolName").value;
    var hscyear = document.getElementById("hS_YearPassed").value;
    var hsccourse = document.getElementById("hsC_Course").value;

    var hsname = document.getElementById("hS_SchoolName").value;
    var hsyear = document.getElementById("hS_YearPassed").value;
    
    var company = document.getElementById("c_LastCompanyName").value;
    var exp = document.getElementById("c_TotalExp").value;



    


    
var data = {
  "T_FirstName": fname,
  "T_LastName": lname,
  "T_PhoneNo": phone,
  "T_Email": email,
  "T_Password": password,
  "T_City": city,
  "SK_Skill1": skill1,
  "SK_Skill2": skill2,
  "SK_Skill3": skill3,
  "SK_Skill4": skill4,
  "HSC_SchoolName": hscname,
  "HSC_YearPassed": hsyear,
  "HSC_Course": hsccourse,
  "HS_SchoolName": hsname,
  "HS_YearPassed": hsyear,
  "C_LastCompanyName":company,
  "C_TotalExp": exp,
  "UG_CollegeName": college,
  "UG_YearPassed": cyearpassed,
  "UG_Degree": degree,
  "UG_Branch": branch
  }
  
  console.log(data);
 

   fetch(`https://localhost:44329/api/Trainer/Trainer/SignUp?T_FirstName=${fname}&T_LastName=${lname}&T_PhoneNo=${phone}&T_Email=${email}&T_Password=${password}&T_City=${city}&SK_Skill1=${skill1}&SK_Skill2=${skill2}&SK_Skill3=${skill3}&SK_Skill4=${skill4}&HSC_SchoolName=${hscname}&HSC_YearPassed=${hscyear}&HSC_Course=${hsccourse}&HS_SchoolName=${hsname}&HS_YearPassed=${hsyear}&C_LastCompanyName=${company}&C_TotalExp=${exp}&UG_CollegeName=${college}&UG_YearPassed=${cyearpassed}&UG_Degree=${degree}&UG_Branch=${branch}`,{
        method: "POST",
        mode: "cors",
    })
        .then((response) => {
            if (response.ok) {
                console.log("success");
            }
            else {
                console.log(response.status + " Failed");
            }
        })
}


