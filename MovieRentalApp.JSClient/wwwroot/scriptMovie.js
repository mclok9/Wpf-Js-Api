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