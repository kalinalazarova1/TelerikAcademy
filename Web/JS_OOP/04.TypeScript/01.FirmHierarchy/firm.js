var Tree;
(function (_Tree) {
    var Tree = (function () {
        function Tree() {
        }
        Tree.prototype.Tree = function (node) {
            this._root = node;
        };

        Object.defineProperty(Tree.prototype, "root", {
            get: function () {
                return this._root;
            },
            enumerable: true,
            configurable: true
        });

        Tree.prototype.traverseDFS = function () {
            this._traverseDFS(this.root, '');
        };

        Tree.prototype._traverseDFS = function (root, spaces) {
            if (!root) {
                return;
            }

            console.log(spaces + root.value);

            for (var i = 0; i < root.childrenCount; i++) {
                this._traverseDFS(root.children[i], spaces + "   ");
            }
        };
        return Tree;
    })();
    _Tree.Tree = Tree;
})(Tree || (Tree = {}));
//# sourceMappingURL=firm.js.map
