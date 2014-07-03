var Tree;
(function (_Tree) {
    "use strict";
    var Tree = (function () {
        function Tree(node) {
            this._root = node;
        }
        Object.defineProperty(Tree.prototype, "root", {
            get: function () {
                return this._root;
            },
            enumerable: true,
            configurable: true
        });

        Tree.prototype.toString = function () {
            return this._toString(this.root, "");
        };

        Tree.prototype._toString = function (root, spaces) {
            var result = "";

            if (!root) {
                return result;
            }

            result = spaces + root.toString() + "\n";

            for (var i = 0; i < root.childrenCount; i++) {
                result += this._toString(root.children[i], spaces + "   ");
            }
            return result;
        };
        return Tree;
    })();
    _Tree.Tree = Tree;
})(Tree || (Tree = {}));
//# sourceMappingURL=tree.js.map
