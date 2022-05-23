let rents = [];
let connection = null;
let rentIdUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:12229/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("RentCreated", (user, message) => {
        getdata();
    });

    connection.on("RentDeleted", (user, message) => {
        getdata();
    });

    connection.on("RentUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:12229/rent')
        .then(x => x.json())
        .then(y => {
            rents = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    rents.forEach(r => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + r.rentId + "</td><td>" +
            + r.price + "</td><td>"
            + r.overrunFee + "</td><td>"
            + r.order + "</td><td>"
            + r.rentalStart + "</td><td>"
            + r.rentalEnd + "</td><td>" +
            `<button type="button" onclick="remove(${r.rentId})">Delete</button>` +
            `<button type="button" onclick="showupdate(${r.rentId})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:12229/rent/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function showupdate(id) {
    document.getElementById('rentorderupdate').value = rents.find(t => t['rentId'] == id)['order'];
    document.getElementById('rentpriceupdate').value = rents.find(t => t['rentId'] == id)['price'];
    document.getElementById('rentrentalstartupdate').value = rents.find(t => t['rentId'] == id)['rentalStart'];
    document.getElementById('rentrentalendupdate').value = rents.find(t => t['rentId'] == id)['rentalEnd'];
    document.getElementById('rentoverrunfeeupdate').value = rents.find(t => t['rentId'] == id)['overrunFee'];
    document.getElementById('updateformdiv').style.display = 'flex';
    rentIdUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let Order = document.getElementById('rentorderupdate').value;
    let Price = document.getElementById('rentpriceupdate').value;
    let RentalStart = document.getElementById('rentrentalstartupdate').value;
    let RentalEnd = document.getElementById('rentrentalendupdate').value;
    let OverrunFee = document.getElementById('rentoverrunfeeupdate').value;
    fetch('http://localhost:12229/rent', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { rentId: rentIdUpdate, order: Order, price: Price, rentalStart: RentalStart, rentalEnd: RentalEnd, overrunFee: OverrunFee })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let Order = document.getElementById('rentorder').value;
    let Price = document.getElementById('rentprice').value;
    let RentalStart = document.getElementById('rentrentalstart').value;
    let RentalEnd = document.getElementById('rentrentalend').value;
    let OverrunFee = document.getElementById('rentoverrunfee').value;
    fetch('http://localhost:12229/rent', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { order: Order, price: Price, rentalStart: RentalStart, rentalEnd: RentalEnd, overrunFee: OverrunFee })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}