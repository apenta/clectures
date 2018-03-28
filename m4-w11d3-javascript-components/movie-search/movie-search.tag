<movie-search>

    <input type="text" name="movieTitle" placeholder="enter a movie name" />
    <input type="button" onclick="{search}" value="SEARCH" />


    <style>


    </style>


    <script>


        this.search = function() { 

            // Get the movie title they are searching for
            const title = this.root.querySelector('input[type=text]').value;
            //console.log(searchTitle);

            // Build the URL to send our Fetch Request to
            const url = `http://www.omdbapi.com/?apikey=e78b4fa0&s=${title}`

            // Call the API
            fetch(url)
                .then(response => response.json())
                .then(json => this.opts.bus.trigger('searchresult', json.Search));

                // log the json

        }

    </script>





</movie-search>