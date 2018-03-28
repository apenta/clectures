<game>


    <div id="gameBoard">
        <card each={cards} onClick={cardClick}></card>
    </div>

    <style>
        #gameBoard {
            display: flex;
            flex-wrap: wrap;
            margin: 0 auto;
            justify-content: center;
        }

        card {
            display: inline-block;
            width: calc(100% * (1/6) - 10px);
            text-align: center;
        }
    </style>

    <script>

        const self = this;

        this.selectedCards = [];
        this.cards = [];
        this.player = 1;
        this.checkMove = endTurn.bind(this);

        this.cardClick = function (event) {
            const card = event.item; // refers to the item in the cards array clicked

            if (card.faceDown) { // flip the card
                card.faceDown = false;
                self.update();

                this.selectedCards.push(card);

                if (this.selectedCards.length > 1) {
                    this.checkMove();
                }
            }
        }

        this.on('mount', () => {

            const deck = this.opts.deck;
            const cardChoices = deck.split(',');

            // Get the deck and then draw the cards from it
            getDeck(deck)
                .then(deckId => drawCards(deckId, cardChoices.length * 2))
                .then(cards => {
                    this.cards = cards;
                    this.cards.forEach(card => card.faceDown = true);
                    this.update();
                });
        })

        this.endTurn = function () {

        }

        // Extracted this method as it handles complex logic for checking 
        // if the turn is over.
        function endTurn() {
            if (this.selectedCards[0].code === this.selectedCards[1].code) {

                triggerTurnEvent(this.opts.bus, this.player, this.player, 'match');
                this.selectedCards.length = 0;

            } else {
                const nextPlayer = (this.player == 1) ? 2 : 1;

                setTimeout(() => {
                    this.selectedCards.forEach(c => c.faceDown = true);

                    triggerTurnEvent(this.opts.bus, this.player, nextPlayer, 'miss');
                    this.selectedCards.length = 0;
                    this.player = nextPlayer;

                    this.update();
                }, 700);
            }
        }

        // Extracted this method from above to handle repetitive code
        function triggerTurnEvent(bus, currentPlayer, nextPlayer, result) {
            bus.trigger('endTurn', {
                currentPlayer,
                nextPlayer,
                result
            });
        }

        // The call for fetching a deck has been wrapped in a promise
        // so that it can be used asynchronously with .then
        function getDeck(deck) {
            return new Promise((resolve, reject) => {
                const url = `https://deckofcardsapi.com/api/deck/new/shuffle/?cards=${deck}&deck_count=2`;

                fetch(url)
                    .then(response => response.json())
                    .then(json => resolve(json.deck_id));
            });
        }

        // The call for drawing cards has been wrapped in a promise
        // so that it can be used asynchronously with .then
        function drawCards(deckId, drawAmount) {
            return new Promise((resolve, reject) => {
                const url = `https://deckofcardsapi.com/api/deck/${deckId}/draw/?count=${drawAmount}`
                fetch(url)
                    .then(response => response.json())
                    .then(json => {
                        resolve(json.cards);
                    });
            });
        }

    </script>


</game>