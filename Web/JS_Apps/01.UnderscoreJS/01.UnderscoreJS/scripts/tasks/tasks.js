/// <reference path="../libs/underscore.js" />
/// <reference path="../libs/require.js" />

// 1. Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Print the students in descending order by full name. Use Underscore.js
// 2. Write function that finds the first name and last name of all students with age between 18 and 24. Use Underscore.js
// 3. Write a function that by a given array of students finds the student with highest marks
// 4. Write a function that by a given array of animals, groups them by species and sorts them by number of legs
// 5. By a given array of animals, find the total number of legs. Each animal can have 2, 4, 6, 8 or 100 legs
// 6. By a given collection of books, find the most popular author (the author with the highest number of books)
// 7. By an array of people find the most common first and last name. Use underscore.

define(['libs/underscore'], function () {
    'use strict';
    var tasks = (function () {
        function studentTasks(collection) {

            // Task 1:
            _.chain(collection)
                .filter(function (student) {
                    return student.fname < student.lname;
                })
                .sortBy('lname')
                .reverse()
                .each(function (student) {
                    console.log(student);
                });

            // Task 2:
            var result = _.chain(collection)
                .filter(function (student) {
                    return student.age >= 18 && student.age <= 24;
                })
                .map(function (student) {
                    return student.fname + ' ' + student.lname;
                })
                .value();

            console.log(result);

            // Task 3:
            result = _.chain(collection)
                .map(function (student) {
                    var sum = _.reduce(student.marks, function (subsum, mark) {
                        return subsum + mark;
                    });
                    student.averageMarks = sum / student.marks.length;
                    return student;
                })
                .max(function (student) { return student.averageMarks; })
                .value();

            console.log(result);
        }

        // Task 4
        function animalTasks(collection) {
            var result = _.chain(collection)
                .sortBy('legs')
                .groupBy('type')
                .value();

            console.log(result);

            // Task 5
            result = _.chain(collection)
                .map(function (animal) {
                    return animal.legs;
                })
                .reduce(function (mem, legs) {
                    return mem + legs;
                })
                .value();

            console.log('Total legs: ' + result);
        }

        function mostPopularProperty(collection, prop) { // function used both for task 6 and 7
            var result = _.chain(collection)
                .groupBy(prop)
                .max(function (items) {
                    return items.length;
                })
                .map(function (item) {
                    return item[prop];
                })
                .first()
                .value();

            return result;
        }

        // Task 6:
        function bookTasks(collection) {
            console.log('Most popular author: ' + mostPopularProperty(collection, 'author'));
        }

        // Task 7:
        function peopleTasks(collection) {
            console.log('Most popular first name: ' + mostPopularProperty(collection, 'fname'));
            console.log('Most popular last name: ' + mostPopularProperty(collection, 'lname'));
        }

        return {
            studentTasks: studentTasks,
            animalTasks: animalTasks,
            bookTasks: bookTasks,
            peopleTasks: peopleTasks
        };
    }());

    return tasks;
});