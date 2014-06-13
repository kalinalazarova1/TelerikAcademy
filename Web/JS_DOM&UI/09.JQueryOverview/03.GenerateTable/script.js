// 3.By given an array of students, generate a table that represents these students
// Each student has first name,
// last name and grade
// Use jQuery

var students = [
        {
            firstName: 'Peter',
            lastName: 'Ivanov',
            grade: 3
        }, {
            firstName: 'Milena',
            lastName: 'Grigorova',
            grade: 6
        }, {
            firstName: 'Gergana',
            lastName: 'Borisova',
            grade: 12
        }, {
            firstName: 'Boyko',
            lastName: 'Petrov',
            grade: 7
        }];

$('#wrapper').append($('<table>').css({
    'border-collapse': 'collapse'
}));

var i,
    $table = $('table'),
    $row = $('<tr>').append(
        $('<td>')
            .html('<strong>First name</strong>')
            .css({
                'border': '2px solid black',
                'width': '80px',
                'padding': '5px'
            })
    );

$row.append(
    $('<td>')
        .html('<strong>Last name</strong>')
        .css({
            'border': '2px solid black',
            'width': '80px',
            'padding': '5px'
        })
);
$row.append(
    $('<td>')
        .html('<strong>Grade</strong>')
        .css({
            'border': '2px solid black',
            'width': '80px',
            'padding': '5px'
        })
);
$table.append($row);
for (i = 0; i < students.length; i++) {
    $row = $('<tr>').append(
        $('<td>')
            .text(students[i].firstName)
            .css({
                'border': '2px solid black',
                'width': '80px',
                'padding': '5px'
            })
    );
    $row.append(
        $('<td>')
            .text(students[i].lastName)
            .css({
                'border': '2px solid black',
                'width': '80px',
                'padding': '5px'
            })
    );
    $row.append(
        $('<td>')
            .text(students[i].grade)
            .css({
                'border': '2px solid black',
                'width': '80px',
                'padding': '5px'
            })
    );

    $table.append($row);
}
