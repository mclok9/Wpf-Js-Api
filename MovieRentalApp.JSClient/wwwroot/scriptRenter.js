let renters = [];
let connection = null;
let renterIdUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:12229/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("RenterCreated", (user, message) => {
        getdata();
    });

    connection.on("RenterDeleted", (user, message) => {
        getdata();
    });

    connection.on("RenterUpdated", (user, message) => {
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
    await fetch('http://localhost:12229/renter')
        .then(x => x.json())
        .then(y => {
            renters = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    renters.forEach(r => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + r.renterId + "</td><td>" +
            + r.rentId + "</td><td>"
            + r.postcode + "</td><td>"
            + r.name + "</td><td>"
            + r.city + "</td><td>"
            + r.street + "</td><td>"
            + r.houseNumber + "</td><td>"
            + r.membershipStart + "</td><td>"
            + r.membershipEnd + "</td><td>" +
            `<button type="button" onclick="remove(${r.renterId})">Delete</button>` +
            `<button type="button" onclick="showupdate(${r.renterId})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:12229/renter/' + id, {
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
    document.getElementById('renternameupdate').value = renters.find(t => t['renterId'] == id)['name'];
    document.getElementById('renterpostcodeupdate').value = renters.find(t => t['renterId'] == id)['postcode'];
    document.getElementById('rentercityupdate').value = renters.find(t => t['renterId'] == id)['city'];
    document.getElementById('renterstreetupdate').value = renters.find(t => t['renterId'] == id)['street'];
    document.getElementById('renterhousenumberupdate').value = renters.find(t => t['renterId'] == id)['houseNumber'];
    document.getElementById('rentermembershipstartupdate').value = renters.find(t => t['renterId'] == id)['membershipStart'];
    document.getElementById('rentermembershipendupdate').value = renters.find(t => t['renterId'] == id)['membershipEnd'];
    document.getElementById('renterrentIdupdate').value = renters.find(t => t['renterId'] == id)['rentId'];
    document.getElementById('updateformdiv').style.display = 'flex';
    renterIdUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let Name = document.getElementById('renternameupdate').value;
    let Postcode = document.getElementById('renterpostcodeupdate').value;
    let City = document.getElementById('rentercityupdate').value;
    let Street = document.getElementById('renterstreetupdate').value;
    let HouseNumber = document.getElementById('renterhousenumberupdate').value;
    let MembershipStart = document.getElementById('rentermembershipstartupdate').value;
    let MembershipEnd = document.getElementById('rentermembershipendupdate').value;
    let RentId = document.getElementById('renterrentIdupdate').value;
    fetch('http://localhost:12229/renter', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { renterId: renterIdUpdate, name: Name, postcode: Postcode, city: City, street: Street, houseNumber: HouseNumber, membershipStart: MembershipStart, membershipEnd: MembershipEnd, rentId: RentId })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let Name = document.getElementById('rentername').value;
    let Postcode = document.getElementById('renterpostcode').value;
    let City = document.getElementById('rentercity').value;
    let Street = document.getElementById('renterstreet').value;
    let HouseNumber = document.getElementById('renterhousenumber').value;
    let MembershipStart = document.getElementById('rentermembershipstart').value;
    let MembershipEnd = document.getElementById('rentermembershipend').value;
    let RentId = document.getElementById('renterrentId').value;
    fetch('http://localhost:12229/renter', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: Name, postcode: Postcode, city: City, street: Street, houseNumber: HouseNumber, membershipStart: MembershipStart, membershipEnd: MembershipEnd, rentId: RentId })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}