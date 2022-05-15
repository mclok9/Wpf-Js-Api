let movies = [];

getdata();

async function getdata() {
    await fetch('http://localhost:12229/movie')
        .then(x => x.json())
        .then(y => {
            movies = y;
            console.log(movies);
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
            `<button type="button" onclick="remove(${m.movieId})">Delete</button>`
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