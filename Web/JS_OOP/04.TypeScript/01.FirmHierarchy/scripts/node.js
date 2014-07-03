﻿var Tree;
(function (Tree) {
    var Node = (function () {
        function Node() {
        }
        Node.prototype.Node = function (value) {
            this.value = value;
        };

        Node.prototype.addChild = function (item) {
            this._children.push(item);
        };

        Node.prototype.removeChild = function (item) {
            var index = this._children.indexOf(item);
            this.children.splice(index, 1);
        };

        Object.defineProperty(Node.prototype, "children", {
            get: function () {
                return this._children;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Node.prototype, "childrenCount", {
            get: function () {
                return this._children.length;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Node.prototype, "parent", {
            get: function () {
                return this._parent;
            },
            set: function (item) {
                this._parent = item;
            },
            enumerable: true,
            configurable: true
        });


        Object.defineProperty(Node.prototype, "value", {
            get: function () {
                return this._value;
            },
            set: function (item) {
                this._value = item;
            },
            enumerable: true,
            configurable: true
        });

        return Node;
    })();
    Tree.Node = Node;
})(Tree || (Tree = {}));
//# sourceMappingURL=node.js.map
