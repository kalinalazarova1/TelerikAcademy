// 6.Write a function that groups an array of persons by age, first or last name. The function must return an associative array,
// with keys - the groups, and values -arrays with persons in this groups
// Use function overloading (i.e. just one function)

function groupPersons(persons, prop) {
    var groupedPersons = {},
        i;
    for (i = 0; i < persons.length; i++) {
        if (groupedPersons[persons[i][prop]]) {
            groupedPersons[persons[i][prop]].push(persons[i]);
        } else {
            groupedPersons[persons[i][prop]] = new Array(persons[i]);
        }
    }
    return groupedPersons;
}

window.onload = function testGroupPersons() {
    var group,
        i,
        persons = [{ firstname: "Ivan", lastname: "Ivanov", age: 21 },
                    { firstname: "Hristo", lastname: "Ivanov", age: 33 },
                    { firstname: "Hristo", lastname: "Penev", age: 52 },
                    { firstname: "Petar", lastname: "Hristov", age: 33 },
                    { firstname: "Petar", lastname: "Penev", age: 52 }];
    jsConsole.writeLine("Grouped by first name:");
    for (group in groupPersons(persons, "firstname")) {
        if (groupPersons(persons, "firstname").hasOwnProperty(group)) {
            jsConsole.writeLine("-----------------------------------");
            jsConsole.writeLine("Group: " + group);
            for (i = 0; i < groupPersons(persons, "firstname")[group].length; i++) {
                jsConsole.writeLine(groupPersons(persons, "firstname")[group][i].firstname + " " + groupPersons(persons, "firstname")[group][i].lastname);
            }
        }
    }
    jsConsole.writeLine();
    jsConsole.writeLine("Grouped by age:");
    for (group in groupPersons(persons, "age")) {
        if (groupPersons(persons, "age").hasOwnProperty(group)) {
            jsConsole.writeLine("-----------------------------------");
            jsConsole.writeLine("Group: " + group);
            for (i = 0; i < groupPersons(persons, "age")[group].length; i++) {
                jsConsole.writeLine(groupPersons(persons, "age")[group][i].firstname + " " + groupPersons(persons, "age")[group][i].lastname);
            }
        }
    }
};