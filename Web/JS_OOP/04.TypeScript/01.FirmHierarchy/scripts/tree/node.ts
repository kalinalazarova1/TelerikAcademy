module Tree {
    "use strict";
    export class Node<T> {
        private _children: Node<T>[];
        private _parent: Node<T>;
        private _value: T;

        constructor(value: T) {
            this._children = [];
            this.value = value;
        }

        equals(node: any): boolean {
            return this.value === node.value;
        }

        addChild(item: Node<T>): void {
            this._children.push(item);
        }

        removeChild(item: Node<T>): void {
            var index: number = this._children.indexOf(item);
            this.children.splice(index, 1);
        }

        toString(): string {
            return this.value + "";
        }

        get children() {
            return this._children;
        }

        get childrenCount() {
            return this._children.length;
        }

        get parent() {
            return this._parent;
        }

        set parent(item: Node<T>) {
            this._parent = item;
        }

        get value() {
            return this._value;
        }

        set value(item: T) {
            this._value = item;
        }
    }
} 