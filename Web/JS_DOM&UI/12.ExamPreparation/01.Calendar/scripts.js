function createCalendar(selector, events) {
    var day,
        dayOfWeek = ['Sun','Mon','Tue','Wed','Thr','Fri','San'],
        table = document.createElement('table');

    function onMouseOver(ev) {
        if (!ev) {
            ev = window.event;
        }
        if (ev.target.className === 'title') {
            ev.target.style.backgroundColor = '#AAA';
        } 
    }

    function onMouseOut(ev) {
        if (!ev) {
            ev = window.event;
        }
        if (ev.target.className === 'title') {
            ev.target.style.backgroundColor = '#777';
        }
    }

    function onClick(ev) {
        if (!ev) {
            ev = window.event;
        }
        for (var k = 0; k < cells.length; k++) {
            if (cells[k].className === 'title' || cells[k].className === 'title selected') {
                cells[k].style.backgroundColor = '#777';
                cells[k].className = 'title';
            } else {
                cells[k].style.backgroundColor = '#fff';
                cells[k].className = '';
            }
        }
        ev.target.style.backgroundColor = '#0ff';
        if (ev.target.className) {
            ev.target.className += ' selected';
            var cellUnder = document.getElementById(ev.target.id + 'j');
            cellUnder.style.backgroundColor = '#0ff';
            cellUnder.className = 'selected';
        } else {
            ev.target.className = 'selected';
            var selectorTitle = ev.target.id + '';
            var cellAbove = document.getElementById(selectorTitle.substring(0, selectorTitle.length - 1));
            cellAbove.style.backgroundColor = '#0ff';
            cellAbove.className += ' selected';
        }
    }

    table.style.borderCollapse = 'collapse';
    table.style.border = '2px solid black';

    for (var r = 0; r < 5; r++) {
        var row = document.createElement('tr');
        var cell = document.createElement('td');
        cell.style.backgroundColor = 'gray';
        cell.style.fontWeight = 'bold';
        cell.style.textAlign = 'center';
        cell.style.width = '150px';
        cell.style.border = '2px solid black';
        cell.innerHTML = dayOfWeek[0] + ' ' + (7 * r + 1) + ' June 2014';
        cell.className = 'title';
        cell.id = '' + 7 * r + 1;
        row.appendChild(cell);

        for (var i = 1; i < 7; i++) {
            day = 7 * r + (i + 1);
            if (day > 30) {
                break;
            }
            cell = cell.cloneNode(true);
            cell.innerHTML = dayOfWeek[i] + ' ' + day + ' June 2014';
            cell.id = '' + day;
            
            row.appendChild(cell);
        }
        table.appendChild(row);
        cell = document.createElement('td');
        cell.style.fontWeight = 'bold';
        cell.style.textAlign = 'left';
        cell.style.verticalAlign = 'top';
        cell.style.width = '150px';
        cell.style.height = '100px';
        cell.style.border = '2px solid black';
        cell.id = 1 + 'j';
        row = document.createElement('tr');
        for (i = 0; i < 7; i++) {
            day = 7 * r + (i + 1);
            if (day > 30) {
                break;
            }
            cell = cell.cloneNode(true);
            cell.id = day + 'j';
            events.forEach(function (e) {
                if (Number(e.date) === day) {
                    cell.innerHTML = e.hour + ' ' + e.title;
                }
            });
            
            row.appendChild(cell);
        }
        table.appendChild(row);
    }
    var container = document.querySelector(selector);
    container.appendChild(table);
    var cells = container.getElementsByTagName('td');
    for (i = 0; i < cells.length; i++) {
        if (cells[i].className === 'title') {
            cells[i].addEventListener('mouseover', onMouseOver, false);
            cells[i].addEventListener('mouseout', onMouseOut, false);
        }
        cells[i].addEventListener('click', onClick, false);
    }
}