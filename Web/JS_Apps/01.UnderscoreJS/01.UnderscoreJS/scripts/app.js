/// <reference path="../tasks/student.js" />
/// <reference path="../tasks/tasks.js" />
/// <reference path="../libs/require.js" />

require(['tasks/student', 'tasks/animal', 'tasks/book', 'tasks/person', 'tasks/tasks'], function (Student, Animal, Book, Person, tasks) {
    'use strict';
    var students = [],
        animals = [],
        books = [],
        people = [];

    students.push(new Student('Ivan', 'Minkov', 23, [3, 4, 6]));
    students.push(new Student('Nikolay', 'Kostov', 24, [6, 6, 6]));
    students.push(new Student('Maria', 'Bobeva', 17, [2, 6, 3]));
    students.push(new Student('Silvia', 'Lulcheva', 19, [3, 3, 5]));
    students.push(new Student('Petar', 'Penev', 21, [4, 6, 6]));
    students.push(new Student('Hristo', 'Valkov', 28, [5, 5, 5]));
    students.push(new Student('Georgi', 'Dimitrov', 31, [4, 3, 2]));
    students.push(new Student('Philip', 'Ivanov', 16, [2, 2, 6, 6]));
    students.push(new Student('Maya', 'Stoyanova', 11, [2, 3, 4, 4]));
    students.push(new Student('Ivaylo', 'Kenov', 25, [5, 5, 6]));
    students.push(new Student('Todor', 'Stoyanov', 28, [6, 5, 6]));

    animals.push(new Animal('Scooby Doo', 'dog', 4));
    animals.push(new Animal('Silvester', 'cat', 4));
    animals.push(new Animal('Tweety', 'bird', 2));
    animals.push(new Animal('Itsy Bitsy', 'spider', 8));
    animals.push(new Animal('Garfield', 'cat', 4));
    animals.push(new Animal('Roadrunner', 'bird', 2));
    animals.push(new Animal('Maja', 'bee', 6));
    animals.push(new Animal('Willy', 'bee', 6));
    animals.push(new Animal('Flip', 'grasshopper', 6));

    books.push(new Book('Pro Javascript Techniques', 'John Resig'));
    books.push(new Book('Javascript Patterns', 'Stoyan Stefanov'));
    books.push(new Book('Object Oriented Javascript', 'Stoyan Stefanov'));
    books.push(new Book('Javascript The Good Parts', 'Douglas Crockford'));
    books.push(new Book('Secrets of Javascript Ninja', 'John Resig'));
    books.push(new Book('Javascript for PHP Developers', 'Stoyan Stefanov'));
    books.push(new Book('Eloquent Javascript', 'Marijn Haverbeke'));

    people.push(new Person('Ivan', 'Petrov'));
    people.push(new Person('Petar', 'Petrov'));
    people.push(new Person('Hristo', 'Georgiev'));
    people.push(new Person('Ivan', 'Minkov'));
    people.push(new Person('Georgi', 'Georgiev'));
    people.push(new Person('Stefan', 'Georgiev'));
    people.push(new Person('Vasil', 'Iliev'));
    people.push(new Person('Ivan', 'Ivanov'));
    people.push(new Person('Petar', 'Popov'));
    people.push(new Person('Hristo', 'Ivanov'));

    tasks.studentTasks(students);
    tasks.animalTasks(animals);
    tasks.bookTasks(books);
    tasks.peopleTasks(people);
});
