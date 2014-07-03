module Tree {
    "use strict";
    export class Tree<T> {
        private _root: Node<T>;
        
        constructor(node: Node<T>) {
            this._root = node;
        }

        get root() {
            return this._root;
        }

        public toString(): string
        {
            return this._toString(this.root, "");
        }

        private _toString(root: Node<T>, spaces: string): string {
            var result: string = "";
            
            if (!root) {
                return result;
            }

            result = spaces + root.toString() +"\n";

            for (var i: number = 0; i < root.childrenCount; i++) {
                result += this._toString(root.children[i], spaces + "   ");
            }
            return result;
        }

    }
} 