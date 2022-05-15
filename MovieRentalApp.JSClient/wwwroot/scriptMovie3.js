let movies = [];

fetch('http://localhost:12229/movie')
    .then(x => x.json())
    .then(y => {
        movies = y;
        console.log(movies);
        display();
    });

function display() {
    movies.forEach(m => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + m.movieId + "</td><td>" +
            + m.rentId + "</td><td>"
            + m.title + "</td><td>"
            + m.distributor + "</td><td>"
            + m.category + "</td><td>"
            + m.length + "</td><td>"
            + m.language + "</td></tr>";
    });
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
            { title: Title, distributor: Distributor, category: Category, length: Length, language: Language, rentId: RentId }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
        })
        .catch((error) => { console.error('Error:', error); });
    display();
}