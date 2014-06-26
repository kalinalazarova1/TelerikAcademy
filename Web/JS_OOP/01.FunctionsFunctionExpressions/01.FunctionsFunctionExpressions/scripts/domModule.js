// 1. Create a module for working with DOM. The module should have the following functionality
// Add DOM element to parent element given by selector
// Remove element from the DOM  by given selector
// Attach event to given selector by given event type and event hander
// Add elements to buffer, which appends them to the DOM when their count for some selector becomes 100
// The buffer contains elements for each selector it gets
// Get elements by CSS selector
// The module should reveal only the methods

var domModule = (function () {
    'use strict';
    var buffer = {},
        MAX_BUFFER_SIZE = 100;

    function addElement(parentSelector, element) {
        var parent = document.querySelector(parentSelector);
        parent.appendChild(element);
    }

    function removeElement(parentSelector, element) {
        var parent = document.querySelector(parentSelector),
            child = document.querySelector(element);
        if (child && child.parentNode === parent) {
            parent.removeChild(child);
        }
    }

    function addEventHandler(selector, eventType, eventHandler) {
        var elements = document.querySelectorAll(selector),
            i;
        for (i = 0; i < elements.length; i++) {
            elements[i].addEventListener(eventType, eventHandler);
        }
    }

    function addToBuffer(parentSelector, element) {
        var parent = document.querySelector(parentSelector);
        if (!buffer[parentSelector]) {
            buffer[parentSelector] = document.createDocumentFragment();
        }
        buffer[parentSelector].appendChild(element);
        if (buffer[parentSelector].childNodes.length === MAX_BUFFER_SIZE) {
            parent.appendChild(buffer[parentSelector]);
            buffer[parentSelector] = null;
        }
    }

    function getElements(selector) {
        return document.querySelectorAll(selector);
    }

    return {
        addElement: addElement,
        removeElement: removeElement,
        addEventHandler: addEventHandler,
        addToBuffer: addToBuffer,
        getElements: getElements
    };
}());