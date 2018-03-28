<movie-list>

    <div each={movies}>
        <img src={Poster} />
        <p>{Title} ({Year})</p>
    </div>



    <style>
    
        img {
            display: block;
            height: 200px;
        }

    </style>



    <script>
    
    this.movies = [];

    // When a searchresult message arrives, look at the data attached to it
    this.opts.bus.on('searchresult', data => {
        console.log(data);

        this.movies = data;
        this.update();
    });
    
    </script>
</movie-list>