window.onload = function() { 
    // Add Event Listener for the Draw Button
    const button = document.querySelector("#draw");
    button.addEventListener("click", draw);
}

let deckId = 'new';

// Call the API to get a new card
function draw() {
    
    // define the endpoint url
    const url = `https://deckofcardsapi.com/api/deck/${deckId}/draw/?count=1`;
    
    // Call the endpoint
    const settings = {
        method: 'get'
    };

    fetch(url, settings)
    .then(response => response.json())
    .then(json => { 
        deckId = json.deck_id;              // save the deck id
        displayCard(json.cards[0]);         // display the first card that comes back
    });                
}


// Takes a card from deck of cards API and displays it
function displayCard(card) { 

    // Find the table
    const table = document.querySelector("#cards");

    // Create a <tr>
    const tr = document.createElement("tr");

    // Create a <td> for the img
    const imageTd = document.createElement("td");

    // Create an <img>
    const img = document.createElement("img");
    img.src = card.image;
    img.alt = `${card.value} of ${card.suit}`;
    img.title = `${card.value} of ${card.suit}`;

    // Append img into td
    imageTd.appendChild(img);

    // Create a <td>
    const suitTd = document.createElement("td");

    // Set the text of the <td> to the card suit
    suitTd.innerText = card.suit;

    // Create a <td>
    const valueTd = document.createElement("td");

    // Set the text of the <td> to the card value
    valueTd.innerText = card.value;

    // Append the <td> to the <tr>
    tr.appendChild(suitTd);
    tr.appendChild(valueTd);
    tr.appendChild(imageTd);

    // Append the <tr> to the <table>
    table.appendChild(tr);
}