function addTrainer() {
   
    let HTTP= new XMLHttpRequest


    let formval = document.getElementById("form1");

    formval.addEventListener('submit', function (e) { e.preventDefault(); });

    const formData = new FormData(formval);
    // const data = new URLSearchParams(formData);

    const data = Object.fromEntries(formData);



  
    let options = {
        method: "POST",
        mode:"cors",
        Headers:{'content-type':'application/json' , 'X-Content-Type-Options':'nosniff'},
        body: JSON.stringify(data),
    }

    console.log(JSON.stringify(data));
    fetch('https://localhost:44329/api/Trainer/Trainer/SignUp', options)
        .then((response) => {
            if (response.ok) {
                console.log(success);
            }
            else {
                console.log(response.status);
            }
        })
}