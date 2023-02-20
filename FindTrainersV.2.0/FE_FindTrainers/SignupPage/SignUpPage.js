const form1 = document.getElementById("form1");
if (form1 != null) {
    form1.addEventListener('submit', function (e) {
    e.preventDefault();


});

form1.addEventListener("focusout", function (e) {
    validateBasic(0);
});

}

const form2 = document.getElementById("form2");
if (form2 != null) {
    form2.addEventListener('submit', function (e) {
    e.preventDefault();
});

form2.addEventListener("focusout", function (e) {
    validateEducation(0);
});
}

const form3 = document.getElementById("form3");
if (form3 != null) {
    form3.addEventListener('submit', function (e) {
    e.preventDefault();
});

form3.addEventListener("focusout", function (e) {
    validateExperience(0);
});
}




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


const nameRegex = new RegExp("\\w{3,50}");
const emailRegex = new RegExp("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+\\.[a-z]{2,6}$");
const phoneRegex = new RegExp("^[9876]\\d{9}$");
const passReg = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$");
const yearRegex = new RegExp("^\\d{4}$");
const degreeRegex = new RegExp("^B\\.\\w{1,6}$");


var fname;
var lname;
var email;
var phone;
var pass;
var cpass;
var city;

var college;
var cyear;
var cbranch;
var cdegree;

var hscname;
var hscyear;
var hsccourse;

var hsname;
var hsyear;

var lastCompany;
var totalexp;

var skill1;
var skill2;
var skill3;
var skill4;



function validateBasic(check) {
    var fflag = 0;
    var lflag = 0;
    var eflag = 0;
    var pflag = 0;
    var paflag = 0;
    var cpflag = 0;
    var passflag = 0;
    var ctflag = 0;
    const fna = document.getElementById("firstname");
    const lna = document.getElementById("lastname");
    const ema = document.getElementById("email");
    const pho= document.getElementById("Phone");
    const pa = document.getElementById("password");
    const cpa = document.getElementById("Confirmpassword");
    const cit= document.getElementById("city");
    

     fname = fna.value.trim();
     lname = lna.value.trim();
     email = ema.value.trim();
     phone = pho.value.trim();
     pass = pa.value.trim();
     cpass = cpa.value.trim();
     city = cit.value.trim();


    if (!nameRegex.test(fname)) {
        fflag = 1;
        setError(fna, "min 3 to max 50 characters");
    }
    else {
        fflag = 0;
        setSuccess(fna, "");
    }
    
    if (!nameRegex.test(lname)) {
        lflag = 1;
        setError(lna, "min 3 to max 50 characters");
        
    }
    else {
        lflag = 0;
        setSuccess(lna, "");

    }

    if (!phoneRegex.test(phone)) {
        pflag = 1;
        setError(pho,"invalid phone number")
    }
    else {
        pflag = 0;
        setSuccess(pho, "");

    }

    if (!emailRegex.test(email)) {
        eflag = 1;
        setError(ema, "invalid email id");
    }
    else {
        eflag = 0;
        setSuccess(ema, "");
    }

    if (!passReg.test(pass)) {
        paflag = 1;
        setError(pa, "min 1 lowercase, 1 uppercase, 1 number");



    }
    else {
        paflag = 0;
        setSuccess(pa, "");

    }

    if (!passReg.test(cpass)) {
        cpflag = 1;
          setError(cpa, "min 1 lowercase, 1 uppercase, 1 number");
    }
    else {
        cpflag = 0;
        setSuccess(cpa, "");

    }

    if (!nameRegex.test(city)) {
        ctflag = 1;
         setError(cit, "min 3 to max 50 characters");
    }
    else {
        ctflag = 0;
        setSuccess(cit, "");
        
    }

    if (paflag == 0 && cpflag == 0) {
        if (pass != cpass) {
        passflag = 1;
        setError(pa, "passwords not matching");
         setError(cpa, "passwords not matching");
    }
    else {
        passflag = 0;
        setSuccess(pa, "");
        setSuccess(cpa, "");
    }
   }

    if (fflag != 0 || lflag != 0 || pflag != 0 || pflag != 0 || paflag != 0 || cpflag != 0 || passflag != 0 || ctflag != 0||eflag!=0) {
    
        
    }
    else {
        if (check == 1) {
    localStorage.setItem('fname', fname);
    localStorage.setItem('lname', lname);
    localStorage.setItem('LoginEmail', email);
    localStorage.setItem('pass', pass);
    localStorage.setItem('phone', phone);
    localStorage.setItem('city', city);

         window.location.href = "Signup1Page.html";
    
        }
        
    }

}

function validateEducation(check) {
    
    let cflag = 0;
    let cyearflag = 0;
    let cbranchflag = 0;
    let cdegreeflag = 0;

    let hscflag = 0;
    let hscyearflag = 0;
    let hsccourseflag = 0;
    
    let hsflag = 0;
    let hsyearflag = 0;
    
    const col = document.getElementById("collegename");
    const colyear = document.getElementById("year");
    const colbranch = document.getElementById("branch");
    const coldegree = document.getElementById("degree");

    const hscnameele = document.getElementById("schoolName");
    const hsccourseele = document.getElementById("hsccourse");
    const hscyearele = document.getElementById("syear");

    const hsnameele = document.getElementById("hschoolName");
    const hsyearele = document.getElementById("hsyear");


    
    college = col.value.trim();
    cyear = colyear.value.trim();
    cbranch = colbranch.value.trim();
    cdegree = coldegree.value.trim();

    hscname = hscnameele.value.trim();
    hsccourse = hsccourseele.value.trim();
    hscyear = hscyearele.value.trim();

    hsname = hsnameele.value.trim();
    hsyear = hsyearele.value.trim();

    if (!nameRegex.test(college)) {
        cflag = 1;
        setError(col, "min 3 to max 50 characters");
    }
    else {
        cflag = 0;
        setSuccess(col, "");
    }

    if (!nameRegex.test(cbranch)) {
        cbranchflag = 1;
        setError(colbranch, "min 3 to max 50 characters");
    }
    else {
        cbranchflag = 0;
        setSuccess(colbranch, ""); 
    }

    if (!yearRegex.test(cyear)) {
        cyearflag = 1;
        setError(colyear, "invalid year format");
    }
    else {
        let y = parseInt(cyear);
        if (y> 2023) {
        cyearflag = 1;
        setError(colyear, "year can't be greater than 2023")
        }
        else {
             cyearflag = 0;
        setSuccess(colyear, "");
        }
       
    }

    if (!degreeRegex.test(cdegree)) {
        cdegreeflag = 1;
        setError(coldegree, "invalid degree (valid B.tech, B.A, B.arc)");
    }
    else {
        cdegreeflag = 0;
        setSuccess(coldegree, "");
    }


    if (!nameRegex.test(hscname)) {
        hscflag = 1;
        setError(hscnameele, "min 3 to max 50 characters");
    }
    else {
        hscflag = 0;
        setSuccess(hscnameele, "");
    }

    if (!yearRegex.test(hscyear)) {
        hscyearflag = 1;
        setError(hscyearele, "invalid year format");
    }
    else {
       
         let y = parseInt(hscyear);
        if (y> 2023) {
            hscyearflag = 1;
        setError(hscyearele, "year can't be greater than 2023")
        }
        else {
            hscyearflag = 0;
         setSuccess(hscyearele, "");
        }
 
    }

    if (!nameRegex.test(hsccourse)) {
        hsccourseflag = 1;
        setError(hsccourseele, "min 3 to max 50 characters");
    }
    else {
        hsccourseflag = 0;
        setSuccess(hsccourseele, "");
    }


    if (!nameRegex.test(hsname)) {
        hsflag = 1;
        setError(hsnameele, "min 3 to max 50 characters");
    }
    else {
        hsflag = 0;
        setSuccess(hsnameele, "");
    }

    if (!yearRegex.test(hsyear)) {
        hsyear = 1;
        setError(hsyearele, "invalid year format");
    }
    else {

         let y = parseInt(hsyear);
        if (y> 2023) {
            hsyearflag = 1;
        setError(hsyearele, "year can't be greater than 2023")
        }
        else {
            hsyearflag = 0;
         setSuccess(hsyearele, "");
        }
 
    }

    if (cflag != 0 || cbranchflag != 0 || cdegreeflag != 0 || cyearflag != 0 || hscflag != 0 || hsccourseflag != 0 || hscyearflag != 0 || hsflag != 0 || hsyearflag != 0) {
        
    }
    else {
        if (check == 1) {
        
            localStorage.setItem('college', college);
            localStorage.setItem('degree', cdegree);
            localStorage.setItem('cyear', cyear);
            localStorage.setItem('branch', cbranch);

            localStorage.setItem('hsc', hscname);
            localStorage.setItem('hscyear', hscyear);
            localStorage.setItem('hsccourse', hsccourse);

            localStorage.setItem('hsname', hsname);
            localStorage.setItem('hsyear', hsyear);
         window.location.href = "Signup2Page.html";
        
        }
    }



}

function validateExperience(check) {
    const eleCompany = document.getElementById("lastcompany");
    const eleExperience = document.getElementById("Experience");



    const eleSkill1 = document.getElementById("skill1");
    const eleSkill2 = document.getElementById("skill2");
    const eleSkill3 = document.getElementById("skill3");
    const eleSkill4 = document.getElementById("skill4");


    lastCompany = eleCompany.value.trim();
    totalexp = eleExperience.value.trim();

    skill1 = eleSkill1.value.trim();
    skill2 = eleSkill2.value.trim();
    skill3 = eleSkill3.value.trim();
    skill4 = eleSkill4.value.trim();

   var flagcompany = 0;
    var flagskill1 = 0;
    var flagskill2 = 0;
    var flagskill3 = 0;
    var flagskill4 = 0;

    if (!nameRegex.test(lastCompany)) {
        flagcompany = 1;
        setError(eleCompany, "min 3 to 50 characters");
    }
    else {
        flagcompany = 0;
        setSuccess(eleCompany, "");
    }
    if (!nameRegex.test(skill1)) {
        flagskill1 = 1;
        setError(eleSkill1, "min 3 to 50 characters");
    }
    else {
        flagcompany = 0;
        setSuccess(eleSkill1, "");
        
    }
    
     if (!nameRegex.test(skill2)) {
        flagskill2 = 1;
        setError(eleSkill2, "min 3 to 50 characters");
    }
    else {
        flagskill2 = 0;
        setSuccess(eleSkill2, "");
        
    }

     if (!nameRegex.test(skill3)) {
        flagskill3= 1;
        setError(eleSkill3, "min 3 to 50 characters");
    }
    else {
        flagskill3= 0;
        setSuccess(eleSkill3, "");
    }

    if (!nameRegex.test(skill4)) {
        flagskill4= 1;
        setError(eleSkill4, "min 3 to 50 characters");
    }
    else {
        flagskill4= 0;
        setSuccess(eleSkill4, "");
    }


    if (flagcompany != 0 || flagskill1 != 0 || flagskill2 != 0 || flagskill3 != 0 || flagskill4 != 0) {
        
    }
    else {

        if (check == 1) {
              fetch(`https://localhost:44329/api/Trainer/Trainer/SignUp?T_FirstName=${localStorage.getItem('fname')}&T_LastName=${localStorage.getItem('lname')}&T_PhoneNo=${localStorage.getItem('phone')}&T_Email=${localStorage.getItem('LoginEmail')}&T_Password=${localStorage.getItem('pass')}&T_City=${localStorage.getItem('city')}&SK_Skill1=${skill1}&SK_Skill2=${skill2}&SK_Skill3=${skill3}&SK_Skill4=${skill4}&HSC_SchoolName=${localStorage.getItem('hsc')}&HSC_YearPassed=${localStorage.getItem('hscyear')}&HSC_Course=${localStorage.getItem('hsccourse')}&HS_SchoolName=${localStorage.getItem('hsname')}&HS_YearPassed=${localStorage.getItem('hsyear')}&C_LastCompanyName=${lastCompany}&C_TotalExp=${totalexp}&UG_CollegeName=${localStorage.getItem('college')}&UG_YearPassed=${localStorage.getItem('cyear')}&UG_Degree=${localStorage.getItem('degree')}&UG_Branch=${localStorage.getItem('branch')}`,{
        method: "POST",
        mode: "cors",
    })
        .then((response) => {
            if (response.ok) {
                console.log("success");
                  window.location.href = "../RedirectionPages/SignupSuccess.html";
            }
            else {
                console.log(response.status + " Failed");
            }
        })
        }
       
    }
    

}