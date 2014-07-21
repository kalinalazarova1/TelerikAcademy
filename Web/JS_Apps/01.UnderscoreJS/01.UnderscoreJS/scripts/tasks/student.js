/// <reference path="../libs/require.js" />

define(function () {
    'use strict';
    var Student;
    Student = (function () {
        function Student(fname, lname, age, marks) {
            this.fname = fname;
            this.lname = lname;
            this.age = age;
            this.marks = marks;
        }

        return Student;
    }());

    return Student;
});
