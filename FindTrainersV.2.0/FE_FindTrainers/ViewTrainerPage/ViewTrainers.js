
           
//             // document.getElementById('name').innerText=res.toString();
// function show(trainer) {
//     let count = 1;
//     for (let c of trainer) {
//         console.log(c.firstName);
//         var table = document.getElementById("tableval");
//         var row = table.rows.length;
//         var cell = table.rows[0].length;
//         var newRow = table.insertRow(count);
//         var cell1 = newRow.insertCell(0);
//         var n = document.createElement("p");
//         n.innerText = c.trainerId;
//         cell1.appendChild(n);

//         var cell2 = newRow.insertCell(1);
//         var o = document.createElement("p");
//         o.innerText = c.firstName;
//         cell2.appendChild(o);

//         var cell3 = newRow.insertCell(2);
//         var e = document.createElement("p");
//         e.innerText = c.lastName;
//         cell3.appendChild(e);

//         var cell4 = newRow.insertCell(3);
//         var j = document.createElement("p");
//         j.innerText = c.phoneNo;
//         cell4.appendChild(j);

//          var cell5 = newRow.insertCell(4);
//         var s = document.createElement("p");
//         s.innerText = c.email
//         cell5.appendChild(s);

//          var cell6 = newRow.insertCell(5);
//         var d = document.createElement("p");
//         d.innerText = c.skill1
//         cell6.appendChild(d);

//         var cell7=newRow.insertCell(6);
//         var f = document.createElement("p");
//         f.innerText = c.city
//         cell7.appendChild(f);




//         count++;
//     }
// }

window.addEventListener('load', function (e) {
      fetch('https://localhost:44329/api/Trainer/all')
            .then(response => response.json())
            .then(trainer => show(trainer));
});

function show(trainer) {
    let output = '';
    const main = document.getElementById("main");
    for (let c of trainer) {
        output +=
             `<div class="col-sm">
                <div class="card my-5" style="width: 18rem;height: 290px;">
                    <div class="card-body ">
                        <img src="../Assets/tileImage.png"
                            class="card-img-top" alt="">
                        <h4 class="card-title my-2">${c.firstName+" "+c.lastName}</h4>
                        <p class="card-text text-muted mb-3">${c.skill1}</p>
                          
                        <i class="bi bi-eye-fill" onclick="viewSingle()"></i>
                    </div>
                
                </div>
            </div>`
        localStorage.setItem('singleEmail', c.email);
        
    }
    main.insertAdjacentHTML('afterbegin', output);
   
}

function viewSingle() {
  
    window.location.href = "SingleView.html";
}