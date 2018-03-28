/*
    Example of a multi-line comment just like in C#/Java    
*/

// Single line comment


// Functions in JS start with the word function
function declareVariables() {

    const daysPerWeek = 7; // declares a variable whose value cannot be changed
    console.log(`There are ${daysPerWeek} days in the week.`);

    let daysPerMonth = 30; // declares a variable whose value can be changed
    console.log(`There are ${daysPerMonth} days in the month.`);

    const weekdays = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"];
    console.table(weekdays);

    // For Loops work just like in C#
    for (let i = 0; i < weekdays.length; i++) {
        console.log(weekdays[i]);
    }
}

// Functions can accept parameters
function printParameters(param1, param2) {
    console.log(`The value of param1 is ${param1}`);
    console.log(`The value of param2 is ${param2}`);
}


function equality(x, y) {
    console.log(`x is ${typeof x}`); //prints out the data type of x
    console.log(`y is ${typeof y}`); //prints out the data type of y

    console.log(`x == y : ${x == y}`);
    console.log(`x === y : ${x === y}`);
}

/*
    Objects are simple key-value pairs   
    Values can be primitive (number, string), complex (array), functions, or objects 
*/
function objects() {
    const person = {
        firstName: "Bill",      // properties are name : value
        lastName: "Lumbergh",
        age: 47,
        employees: ["Peter Gibbons", "Michael Bolton"],
        toString: function () {
            return `${this.lastName}, ${this.firstName} (age: ${this.age})`;
        }
    };

    console.table(person);
    console.log(`First name is ${person.firstName}`);   // properties can be accessed using dot notation

    console.log(`First name is: ${person["firstName"]}`); // or like an array

    // Loop through object array
    for (let i = 0; i < person.employees.length; i++) {
        console.log(`Employee ${person.employees[i]}`);
    }

    // Foreach - Prints out the properties of the oject
    for (let prop in person) {
        console.log(prop);
    }

    console.log(person.toString());

}


// String Methods

function strings(value) {
    console.log(`.length - ${value.length}`);
    console.log(`.endsWith('World') - ${value.endsWith('World')}`);

    /* Methods for JavaScript
        - split(string)
        - substr(number, number)
        - substring(number, number)
        - toLowerCase()
        - trim()
    */
}


function filterExample() {
    const numbers = [3, 10, -3, -2, 100, 36, 72, 84, 10];

    const filtered = numbers.filter(n => n >= 0 && n <= 100);
    console.table(filtered);


    // Sorts the array in place, in ascending order
    numbers.sort((num1, num2) => num1 > num2);

    // Sorts the array in place, in descending order
    numbers.sort((num1, num2) => num1 < num2);

}


const inventors = [
    { first: 'Albert', last: 'Einstein', year: 1879, passed: 1955 },
    { first: 'Isaac', last: 'Newton', year: 1643, passed: 1727 },
    { first: 'Galileo', last: 'Galilei', year: 1564, passed: 1642 },
    { first: 'Marie', last: 'Curie', year: 1867, passed: 1934 },
    { first: 'Johannes', last: 'Kepler', year: 1571, passed: 1630 },
    { first: 'Nicolaus', last: 'Copernicus', year: 1473, passed: 1543 },
    { first: 'Max', last: 'Planck', year: 1858, passed: 1947 },
    { first: 'Katherine', last: 'Blodgett', year: 1898, passed: 1979 },
    { first: 'Ada', last: 'Lovelace', year: 1815, passed: 1852 },
    { first: 'Sarah E.', last: 'Goode', year: 1855, passed: 1905 },
    { first: 'Lise', last: 'Meitner', year: 1878, passed: 1968 },
    { first: 'Hanna', last: 'HammarstrÃ¶m', year: 1829, passed: 1909 }
];

function filterInventors() {

    const sixteenthCenturyInventors = inventors.filter(i => (i.year >= 1500 && i.year <= 1599) || (i.passed >= 1500 && i.passed <= 1599));
    console.table(sixteenthCenturyInventors);


}