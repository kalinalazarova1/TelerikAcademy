// 1.Create a TODO list with the following UI controls
// Form input for new Item
// Button for adding the new Item
// Button for deleting some item
// Show and Hide Button

window.onload = function () {
    function add() {
        var item = document.createElement('p'),
            check = document.createElement('input'),
            itemContent;
        check.type = 'checkbox';
        item.appendChild(check);
        itemContent = document.createElement('label');
        itemContent.innerHTML = document.getElementById('item').value;
        item.appendChild(itemContent);
        document.getElementById('list').appendChild(item);
        document.getElementById('item').value = '';
    }

    function getSelected() {
        var result = [],
            all = document.getElementById('list').getElementsByTagName('input'),
            i,
            len;
        for (i = 0, len = all.length; i < len; i++) {
            if (all[i].checked && all[i].parentElement.style.display !== 'none') {
                result.push(all[i].parentElement);
            }
        }
        return result;
    }

    function hide() {
        var arr = getSelected();
        arr.forEach(function (unit) { unit.style.display = 'none'; });
    }

    function show() {
        var arr = document.getElementById('list').getElementsByTagName('p'),
            i,
            len;
        for (i = 0, len = arr.length; i < len; i++) {
            arr[i].style.display = 'block';
        }
    }

    function del() {
        var arr = getSelected();
        arr.forEach(function (unit) { unit.parentElement.removeChild(unit); });
    }

    document.getElementById('add').addEventListener('click', add, false);
    document.getElementById('hide').addEventListener('click', hide, false);
    document.getElementById('show').addEventListener('click', show, false);
    document.getElementById('del').addEventListener('click', del, false);
};