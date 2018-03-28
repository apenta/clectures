<card>

    <div class="{card: true, faceUp: !faceDown}" >

        <div class="face front">
            <img src={image} />
        </div>
        <div class="face back">
            <img src='images/card_background.png' />
        </div>
    </div>

    <style>
        card {
            position: relative;
            max-width: 100%;
            height: 200px;
            perspective: 1000;
        }

        .card {
            width: 100%;
            height: 100%;
            transform-style: preserve-3d;
            transition: all 0.6s linear;
        }

        img {
            width: 137px;
        }

        .card.faceUp {
            transform: rotateY(180deg);
        }

        .face {
            position: absolute;
            width: 100%;
            height: 100%;
            backface-visibility: hidden;
        }

        .face.front {
            display: block;
            transform: rotateY(180deg);
            box-sizing: border-box;            
        }

    </style>
</card>