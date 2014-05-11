// 5.Write a function that finds the youngest person in a given array of persons and prints his/hers full name
// Each person have properties firstname, lastname and age

function youngestPerson(arr) {
    var youngest = arr[0],
        i;
    for (i = 1; i < arr.length; i++) {
        if (arr[i].age < youngest.age) {
            youngest = arr[i];
        }
    }
    return youngest;
}

window.onload = function testYoungestPerson() {
    var persons = [{ firstname: "Ivan", lastname: "Ivanov", age: 21 }, { firstname: "Hristo", lastname: "Markov", age: 40 }, { firstname: "Albena", lastname: "Deneva", age: 33 }, { firstname: "Valia", lastname: "Berova", age: 52 }, { firstname: "Petar", lastname: "Penev", age: 27 }],
        youngest = youngestPerson(persons);
    jsConsole.writeLine("The youngest person is: " + youngest.firstname + " " + youngest.lastname);
};