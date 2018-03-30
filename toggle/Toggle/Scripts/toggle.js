/// <reference path="jquery-1.6.4.js" />
/// <reference path="jquery.signalR-2.2.1.js" />
/// <reference path="jquery-1.6.4-vsdoc.js" />



$(document).ready(function () {

    // Create the web socket connection object
    var connection = $.connection("/togglesocket");


    // Attach an event handler to execute code
    // when a message is received
    connection.received(function (data) {
        var dataObject = JSON.parse(data);

        if (dataObject.type == "cellUpdate") {
            updateCell(dataObject.row, dataObject.col, dataObject.colorValue);
        } else {
            updateTable(dataObject);
        }

    });

    connection.start();

    $(".rounded-box").click(function () {
        $(".selected").removeClass("selected");
        $(this).addClass("selected");
    });

    $("td").click(function () {

        var rowIndex = $(this).attr("data-row");
        var colIndex = $(this).attr("data-col");
        var colorValue = $(".selected").css("background-color");

        var message = {
            type: "cellUpdate",
            row: rowIndex,
            col: colIndex,
            colorValue: colorValue
        };
        connection.send(message);
    });

});


function updateCell(row, column, colorValue) {
    var cell = $(`td[data-row='${row}']`).filter(`td[data-col='${column}']`);
    cell.css("background-color", colorValue);
    cell.removeClass("default");
}

function updateTable(data) {
    for (var rowIndex = 0; rowIndex < data.mapData.length; rowIndex++) {
        for (var colIndex = 0; colIndex < data.mapData[rowIndex].length; colIndex++) {
                        
            var colorValue = data.mapData[rowIndex][colIndex];
            if(colorValue != null){
                updateCell(rowIndex, colIndex, colorValue);
            }
            
        }
    }
}