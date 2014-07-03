module Personnel {
    "use strict";
    export class BasePersonnel implements IPersonnel {
        private _id: number;

        private static _idGenerator = 0;

        constructor(public firstName: string, public lastName: string, public position: string) {
            this._id = ++BasePersonnel._idGenerator;
        }

        get id() {
            return this._id;
        }

        toString(): string {
            return this.id + "." + this.firstName + " " + this.lastName + " : " + this.position;
        }

        processPurchase(purchase: number): boolean {
            return true;
        }
    }
} 