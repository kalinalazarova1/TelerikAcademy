// Write a script that converts a number in the range [0...999] to a text corresponding to its English pronunciation.

window.onload = function () {
    document.getElementById("number-input").focus();
};

function englishNumbers() {
    var numberByDigits = jsConsole.readInteger("input"),
        units = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"],
        tens = ["twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety"],
        teens = ["ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"],
        numberByWords,
        numberHundreds,
        numberTens,
        numberUnits;
    numberHundreds = numberTens = numberUnits = null;
    if ((!numberByDigits && numberByDigits !== 0) || numberByDigits > 999 || numberByDigits < 0) {
        jsConsole.writeLine("The entered number is not valid.");
    } else {
        if (Math.floor(numberByDigits / 100) > 0) {
            numberHundreds = units[Math.floor(numberByDigits / 100)] + " hundred";  //return the hundreds
            numberByDigits %= 100;
        }
        if (Math.floor(numberByDigits / 10) > 1) {
            numberTens = tens[Math.floor(numberByDigits / 10) - 2];             //returns the tens if they are >= 20
            if (numberByDigits % 10 !== 0) {
                numberUnits = units[numberByDigits % 10];           //returns the units when tens are not null
            }
        } else if (Math.floor(numberByDigits / 10) === 1) {
            numberUnits = teens[numberByDigits % 10];                   //returns numbers from 10 to 19
        } else if (numberHundreds !== null && numberByDigits % 10 === 0) {
            numberUnits = null;                                     //return numbers like 100, 200, 300
        } else {
            numberUnits = units[numberByDigits % 10];       //returns units when tens are null
        }
                                                            //formats the spaces and "and" for the output string
        if (numberHundreds !== null) {
            if (numberTens !== null) {
                numberByWords = numberHundreds + " " + numberTens + " " + numberUnits;
            } else {
                if (numberUnits !== null) {
                    numberByWords = numberHundreds + " and " + numberUnits;
                } else {
                    numberByWords = numberHundreds;
                }
            }
        } else {
            if (numberTens !== null) {
                numberByWords = numberTens + " " + numberUnits;
            } else {
                numberByWords = numberUnits;
            }
        }
        numberByWords = numberByWords.charAt(0).toUpperCase() + numberByWords.slice(1); // Makes first letter uppercase
        jsConsole.writeLine(numberByWords);
    }
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        englishNumbers();
    }
}