/* 6.*Create a TreeView component
            Initially only the top items must be visible
            On item click
            If its children are hidden (collapsed), 
            they must be made visible (expanded)
            If its children are visible (expanded), 
            they must be made hidden (collapsed)
            Research about events.*/

var all = document.getElementsByTagName('li'),
    i;

function toggleDisplay(event) {
    if (this.getElementsByTagName('ul').length === 0) {
        return;
    }
    if ((this === event.target || this === event.target.parentNode) && this.getElementsByTagName('ul')[0].style.display === 'block') { //makes sure the toggleDisplay() is executed only on clicked a element or its parent li element
        this.getElementsByTagName('ul')[0].style.display = 'none';
    } else {
        this.getElementsByTagName('ul')[0].style.display = 'block';
    }
}

for (i = 0; i < all.length; i++) {
    all[i].addEventListener("click", toggleDisplay, false);
}
