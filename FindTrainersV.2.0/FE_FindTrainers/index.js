// function call() {
//     let email = document.getElementById("email").value.trim();
// let pass = document.getElementById("password").value.trim();

//     console.log(email + " " + pass);
    
//     isValidLoginCredentials(email, pass);
// }

// function isValidLoginCredentials(email,pass) {
//     fetch(`https://localhost:44329/api/Trainer/Trainer/Login?username=${email}&password=${pass}`)
//         .then((response) => {
//             if (response.status == 200) {
//                 window.location.href = "Profile.html";
//             }
//         });

// }
// function get() {
//     let val = document.getElementById("email").value;
//     fetch(`https://localhost:44329/api/Trainer/Trainer?id=${val}`)
//         .then((response) => {
//             if (response.status == 200) {
//                 response.json();
//             }
//         }).then(text=>console.log(text));
// }
  let options = {
                        method: "PUT",
                        Headers: {"Content-type": "text/json"},
                    }

// function update(){
//     let valnew=document.getElementById("value").value;
//     let em=document.getElementById("email").value;
//     fetch(`https://localhost:44329/api/Trainer/Trainer/Update/City?NewValue=${valnew}&email=${em}`,options)
//     .then((response)=>{
//         if(response.status==200){
//          console.log("success");
//         }
//     })
// }

