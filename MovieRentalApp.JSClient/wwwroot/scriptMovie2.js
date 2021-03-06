let movies = [];
let connection = null;
let movieIdUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:12229/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("MovieCreated", (user, message) => {
        getdata();
    });

    connection.on("MovieDeleted", (user, message) => {
        getdata();
    });

    connection.on("MovieUpdated", (user, message) => {
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
    await fetch('http://localhost:12229/movie')
        .then(x => x.json())
        .then(y => {
            movies = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    movies.forEach(m => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + m.movieId + "</td><td>" +
            + m.rentId + "</td><td>"
            + m.title + "</td><td>"
            + m.distributor + "</td><td>"
            + m.category + "</td><td>"
            + m.length + "</td><td>"
            + m.language + "</td><td>" +
            `<button type="button" onclick="remove(${m.movieId})">Delete</button>` +
            `<button type="button" onclick="showupdate(${m.movieId})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:12229/movie/' + id, {
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
    document.getElementById('movietitleupdate').value = movies.find(t => t['movieId'] == id)['title'];
    document.getElementById('moviedistributorupdate').value = movies.find(t => t['movieId'] == id)['distributor'];
    document.getElementById('moviecategoryupdate').value = movies.find(t => t['movieId'] == id)['category'];
    document.getElementById('movielengthupdate').value = movies.find(t => t['movieId'] == id)['length'];
    document.getElementById('movielanguageupdate').value = movies.find(t => t['movieId'] == id)['language'];
    document.getElementById('movierentIdupdate').value = movies.find(t => t['movieId'] == id)['rentId'];
    document.getElementById('updateformdiv').style.display = 'flex';
    movieIdUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let Title = document.getElementById('movietitleupdate').value;
    let Distributor = document.getElementById('moviedistributorupdate').value;
    let Category = document.getElementById('moviecategoryupdate').value;
    let Length = document.getElementById('movielengthupdate').value;
    let Language = document.getElementById('movielanguageupdate').value;
    let RentId = document.getElementById('movierentIdupdate').value;
    fetch('http://localhost:12229/movie', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { movieId: movieIdUpdate, title: Title, distributor: Distributor, category: Category, length: Length, language: Language, rentId: RentId })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let Title = document.getElementById('movietitle').value;
    let Distributor = document.getElementById('moviedistributor').value;
    let Category = document.getElementById('moviecategory').value;
    let Length = document.getElementById('movielength').value;
    let Language = document.getElementById('movielanguage').value;
    let RentId = document.getElementById('movierentId').value;
    fetch('http://localhost:12229/movie', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { title: Title, distributor: Distributor, category: Category, length: Length, language: Language, rentId: RentId })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}