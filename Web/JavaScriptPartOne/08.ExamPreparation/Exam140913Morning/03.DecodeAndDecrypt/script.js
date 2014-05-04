function solve(args) {
    'use strict';
    var cipherLen = '',
        cipher,
        message,
        decoded,
        i;

    function decrypt(encrypted) {
        var decrypted = '';

        for (i = 0; i < encrypted.length; i++) {
            decrypted += String.fromCharCode(((encrypted.charCodeAt(i % encrypted.length) - 65) ^ (cipher.charCodeAt(i % cipher.length) - 65)) + 65);
        }

        return decrypted;

    }

    function decode(coded) {
        var decodedString = "",
            count = "",
            j;

        for (i = 0; i < coded.length; i++) {
            if (!(coded.charAt(i) >= 0 && coded.charAt(i) <= 9)) {
                decodedString += coded[i];
            } else {
                while (coded.charAt(i) >= 0 && coded.charAt(i) <= 9) {
                    count += coded[i];
                    i++;
                }

                for (j = 0; j < Number.parseInt(count); j++) {
                    decodedString += coded[i];
                }
            }
        }

        return decodedString;
    }

    i = args[0].length - 1;
    while (args[0].charAt(i) >= 0 && args[0].charAt(i) <= 9) {
        i--;
    }

    cipherLen = args[0].substr(i + 1);
    args[0] = args[0].substring(0, i + 1);
    decoded = decode(args[0]);
    cipher = decoded.slice(decoded.length - cipherLen);
    message = decoded.substring(0, decoded.length - cipherLen);

    return decrypt(message);
}

function test() {
    'use strict';
    var args = ["ABBAA6BA7"];
    console.log(solve(args));
}