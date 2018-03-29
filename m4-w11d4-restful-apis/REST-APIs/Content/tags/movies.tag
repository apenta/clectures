<movies>

    <table>
        <tr>
            <th>IMDB Id</th>
            <th>Title</th>
            <th>Description</th>
            <th>Year Released</th>
            <th>Rating</th>
            <th></th>
        </tr>
        <tr each="{movies}" data-id="{Id}">
            <td>{ImdbId}</td>
            <td>{Title}</td>
            <td>{Description}</td>
            <td>{YearReleased}</td>
            <td>{Rating}</td>
            <td><button onclick="{remove}">Delete</button></td>
        </tr>
        <tr show="{newMovie}">
            <!-- show sets display: none if newMovie is false or null -->
            <td><input type="text" name="ImdbId" placeholder="imdb" /></td>
            <td><input type="text" name="Title" placeholder="title" /></td>
            <td><input type="text" name="Description" placeholder="description" /></td>
            <td><input type="text" name="YearReleased" placeholder="year" /></td>
            <td><input type="text" name="Rating" placeholder="rating" /></td>
            <td><button onclick="{save}">Save</button></td>
        </tr>
    </table>

    <!-- hide sets display: none if newMovie is true or has a value-->
    <button hide="{newMovie}" onclick="{add}">Add</button>

    <style>
    </style>

    <script>

        // HARD CODED DATA

        this.movies = [];

        // When the tag loads, bind some fake data to it until we have a real api
        this.on('mount', () => {
            this.movies = [
                { Id: 1, Title: "Test Movie 1", Description: "Test Description 1", YearReleased: 2018, Rating: "PG", ImdbId: "123" },
                { Id: 2, Title: "Test Movie 2", Description: "Test Description 2", YearReleased: 2017, Rating: "G", ImdbId: "456" }
            ];
            this.update();
        })


        this.remove = function (event) {
            // Figure out which delete was clicked
            const movie = event.item;

            // Get the index of the movie being removed from the array
            const index = this.movies.map(m => m.Id).indexOf(movie.Id);

            // Remove the movie
            this.movies.splice(index, 1);
        }

        this.add = function () {
            this.newMovie = {};
        }

        // Our function that saves the movie
        this.save = function () {

            // Get all the values and save them in the newMovie
            this.newMovie.ImdbId = this.root.querySelector('input[name=ImdbId]').value;
            this.newMovie.Title = this.root.querySelector('input[name=Title]').value;
            this.newMovie.Description = this.root.querySelector('input[name=Description]').value;
            this.newMovie.YearReleased = this.root.querySelector('input[name=YearReleased]').value;
            this.newMovie.Rating = this.root.querySelector('input[name=Rating]').value;

            // Clear out existing values
            this.root.querySelector('input[name=ImdbId]').value = '';
            this.root.querySelector('input[name=Title]').value = '';
            this.root.querySelector('input[name=Description]').value = '';
            this.root.querySelector('input[name=YearReleased]').value = '';
            this.root.querySelector('input[name=Rating]').value = '';

            // Fake saving the movie
            this.movies.push(this.newMovie);

            // Reset newMovie to hide it
            this.newMovie = null;
        }


        // REAL API DATA

        //this.movies = [];

        //this.on('mount', () => {
        //    fetch('http://localhost:55801/api/films')
        //        .then(response => response.json())
        //        .then(json => {
        //            this.movies = json;
        //            this.update();
        //        })
        //})

        //this.remove = function (event) {
            
        //    // Figure out which delete was clicked
        //    const movie = event.item;

        //    // Get the index of the movie being removed from the array
        //    const index = this.movies.map(m => m.Id).indexOf(movie.Id);

        //    this.movies.splice(index, 1);

        //    // Call the Api
        //    const url = `http://localhost:55801/api/films/${movie.Id}`
        //    const settings = {
        //        method: 'DELETE'
        //    };

        //    fetch(url, settings)
        //        .then(response => {                    
        //            this.update();
        //        });
        //}

        //this.add = function () {
        //    // Set an empty object up for newMovie
        //    this.newMovie = {};
        //}

        //// Our function that saves the movie
        //this.save = function () {

        //    // Get all the values and save them in the newMovie
        //    this.newMovie.ImdbId = this.root.querySelector('input[name=ImdbId]').value;
        //    this.newMovie.Title = this.root.querySelector('input[name=Title]').value;
        //    this.newMovie.Description = this.root.querySelector('input[name=Description]').value;
        //    this.newMovie.YearReleased = this.root.querySelector('input[name=YearReleased]').value;
        //    this.newMovie.Rating = this.root.querySelector('input[name=Rating]').value;

        //    // Clear out existing values
        //    this.root.querySelector('input[name=ImdbId]').value = '';
        //    this.root.querySelector('input[name=Title]').value = '';
        //    this.root.querySelector('input[name=Description]').value = '';
        //    this.root.querySelector('input[name=YearReleased]').value = '';
        //    this.root.querySelector('input[name=Rating]').value = '';

        //    // Build the Url
        //    const url = `http://localhost:55801/api/films`;
        //    const settings = {
        //        method: 'POST',
        //        headers: {
        //            "content-type": "application/json"
        //        },
        //        body: JSON.stringify(this.newMovie)
        //    };

        //    // Send the request
        //    fetch(url, settings)
        //        .then(response => response.json())
        //        .then(json => {
        //            this.movies.push(json);
        //            this.update();
        //        })

        //    // Reset newMovie to hide it
        //    this.newMovie = null;
        //}
    </script>
</movies>