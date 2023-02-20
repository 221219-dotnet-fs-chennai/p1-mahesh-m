window.addEventListener('load', function (e) {
    
   fetch(`https://localhost:44329/api/Trainer/Trainer?id=${localStorage.getItem('singleEmail').split('@')[0]}`)
            .then(response => response.json())
            .then(trainer => show(trainer));
})
function show(trainer){
    document.getElementById('name').innerText = trainer.t_FirstName + " " + trainer.t_LastName;
    document.getElementById('email').innerText = trainer.t_Email;
    document.getElementById('Phone').innerText = trainer.t_PhoneNo;
    document.getElementById('city').innerText = trainer.t_City;
}