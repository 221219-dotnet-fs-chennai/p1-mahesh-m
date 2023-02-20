const form2 = document.getElementById("form2");
form2.addEventListener('submit', function (e) {
    e.preventDefault();
});

form2.addEventListener("focusout", function (e) {
    validateEducation(0);
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

const nameRegex = new RegExp("\\w{3,50}");
const yearRegex = new RegExp("^\\d{4}$");
const degreeRegex = new RegExp("^B\\.\\w{1,6}$");



var college;
var cyear;
var cbranch;
var cdegree;

var hscname;
var hscyear;
var hsccourse;

var hsname;
var hsyear;


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
        cyearflag = 0;
        setSuccess(colyear, "");
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
        setSuccess(hscnameele, "");
    }

    if (!yearRegex.test(hscyear)) {
        hscyearflag = 1;
        setError(hscyearele, "invalid year format");
    }
    else {
        setSuccess(hscyearele, "");
    }


}