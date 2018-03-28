<player>


    <p><span class="{turn: current_turn}">Player {opts.pid}</span> Score: {score}</p>

    <style>
    .turn {
        font-weight: bold;
    }
    </style>

    <script>

        const self = this;

        this.score = 0;
        this.current_turn = (opts.pid == 1);
        

        opts.bus.on('endTurn', data => {

            if (data.currentPlayer == opts.pid && data.result == 'match') {
                this.score++;
            }

            this.current_turn = (opts.pid == data.nextPlayer);

            this.update();
        });

    </script>
</player>