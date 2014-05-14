// 7.Write a script that parses an URL address given in the format:
// [protocol]://[server]/[resource]
// and extracts from it the [protocol], [server] and [resource] elements. Return the elements in a JSON object.
// For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
// { protocol : "http",
//   server : "www.devbg.org",
//   resource : "/forum/index.php"}

window.onload = function () {
    document.getElementById("input1").focus();
};

function parseURL(address) {
    var indexProtocol = address.indexOf(':'),
        indexServer = address.indexOf('/', indexProtocol + 3);
    return {
        protocol: address.substr(0, indexProtocol),
        server: address.substr(indexProtocol + 3, indexServer - indexProtocol - 3),
        resource: address.substr(indexServer),
        toString: function () {
            return "protocol: " + this.protocol + ",<br/> server: " + this.server + ",<br/> resource: " + this.resource;
        }
    };
}

function parseURLTest() {
    var address = jsConsole.read("input#input1");
    //var address = "http://www.devbg.org/forum/index.php";
    jsConsole.writeLine("The result is: ");
    jsConsole.writeLine(parseURL(address));
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        parseURLTest();
    }
}