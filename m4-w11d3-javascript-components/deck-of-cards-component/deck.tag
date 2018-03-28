<deck>

    <button onclick="{draw}">DRAW</button>

    <table>
        <tr>
            <th>VALUE</th>
            <th>SUIT</th>
            <th>IMAGE</th>
        </tr>

        <tr each={cards}>
            <td>{value}</td>
            <td>{suit}</td>
            <td>
                <img src="{image}" />
            </td>
        </tr>
    </table>

    <style>
    </style>
    <script>

        this.deckId = 'new';
        this.cards = [];
        this.draw = function () {

            // define the endpoint url
            const url = `https://deckofcardsapi.com/api/deck/${this.deckId}/draw/?count=1`;

            // Call the endpoint
            const settings = {
                method: 'get'
            };

            fetch(url, settings)
                .then(response => response.json())
                .then(json => {
                    this.deckId = json.deck_id;              // save the deck id
                    //console.log(json.cards[0]);
                    this.cards.push(json.cards[0]);
                    this.update();
                });





        }

    </script>


</deck>