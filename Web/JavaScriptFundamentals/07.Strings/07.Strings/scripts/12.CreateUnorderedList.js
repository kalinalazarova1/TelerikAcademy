// 12.Write a function that creates a HTML UL using a template for every HTML LI. The source of the list should an array
// of elements. Replace all placeholders marked with –{…}–   with the value of the corresponding property of the object. Example: 
// <div data-type="template" id="list-item"<strong>-{name}-</strong> <span>-{age}-</span>/div>
// var people = [{name: "Peter", age: 14},…];
// var tmpl = document.getElementById("list-item").innerHtml;
// var peopleList = generateList(people, template);
// peopleList = "<ul><li><strong>Peter</strong> <span>14</span></li><li>…</li>…</ul>"

function generateList(people, template) {       //generates the list according to the template and additional fields could be added(for example: town) without changing the function
    var result = "",
        i,
        temp,
        listItem,
        j;
    for (i = 0; i < people.length; i++) {
        temp = template.split(/[{}]/);
        listItem = "";
        for (j = 1; j < temp.length; j += 2) {
            listItem += temp[j - 1] + people[i][temp[j]];
        }
        listItem += temp[temp.length - 1];
        result += "<li>" + listItem + "</li>";
    }
    result = "<ul>" + result + "</ul>";
    return result;
}

var people = [{ name: "Peter", age: 14, town: "Sofia" }, { name: "Maria", age: 15, town: "Plovdiv" }, { name: "Ivan", age: 18, town: "Burgas" }],
    template = document.getElementById("list-item").innerHTML,
    peopleList = generateList(people, template);
document.getElementById("list-item").innerHTML = peopleList;