let staffs = [];
let connection = null;
let staffIdUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:12229/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("StaffCreated", (user, message) => {
        getdata();
    });

    connection.on("StaffDeleted", (user, message) => {
        getdata();
    });

    connection.on("StaffUpdated", (user, message) => {
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
    await fetch('http://localhost:12229/staff')
        .then(x => x.json())
        .then(y => {
            staffs = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    staffs.forEach(s => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + s.staffId + "</td><td>" +
            + s.movieId + "</td><td>"
            + s.studio + "</td><td>"
            + s.director + "</td><td>"
            + s.mainCharacter + "</td><td>"
            + s.supportingCharacters + "</td><td>"
            + s.cost + "</td><td>" +
            `<button type="button" onclick="remove(${s.staffId})">Delete</button>` +
            `<button type="button" onclick="showupdate(${s.staffId})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:12229/staff/' + id, {
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
    document.getElementById('staffdirectorupdate').value = staffs.find(t => t['staffId'] == id)['director'];
    document.getElementById('staffmaincharacterupdate').value = staffs.find(t => t['staffId'] == id)['mainCharacter'];
    document.getElementById('staffsupportingcharactersupdate').value = staffs.find(t => t['staffId'] == id)['supportingCharacters'];
    document.getElementById('staffcostupdate').value = staffs.find(t => t['staffId'] == id)['cost'];
    document.getElementById('staffstudioupdate').value = staffs.find(t => t['staffId'] == id)['studio'];
    document.getElementById('staffmovieIdupdate').value = staffs.find(t => t['staffId'] == id)['movieId'];
    document.getElementById('updateformdiv').style.display = 'flex';
    staffIdUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let Director = document.getElementById('staffdirectorupdate').value;
    let MainCharacter = document.getElementById('staffmaincharacterupdate').value;
    let SupportingCharacters = document.getElementById('staffsupportingcharactersupdate').value;
    let Cost = document.getElementById('staffcostupdate').value;
    let Studio = document.getElementById('staffstudioupdate').value;
    let MovieId = document.getElementById('staffmovieIdupdate').value;
    fetch('http://localhost:12229/staff', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { staffId: staffIdUpdate, director: Director, mainCharacter: MainCharacter, supportingCharacters: SupportingCharacters, cost: Cost, studio: Studio, movieId: MovieId })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let Director = document.getElementById('staffdirector').value;
    let MainCharacter = document.getElementById('staffmaincharacter').value;
    let SupportingCharacters = document.getElementById('staffsupportingcharacters').value;
    let Cost = document.getElementById('staffcost').value;
    let Studio = document.getElementById('staffstudio').value;
    let MovieId = document.getElementById('staffmovieId').value;
    fetch('http://localhost:12229/staff', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { director: Director, mainCharacter: MainCharacter, supportingCharacters: SupportingCharacters, cost: Cost, studio: Studio, movieId: MovieId })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}