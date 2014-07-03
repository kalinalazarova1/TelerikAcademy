module Firm {
    "use strict";
    export class Firm {

        constructor(public name: string, public hierarchy: Tree.Tree<Personnel.BasePersonnel>) { }

        toString(): string {
            return this.name + "\n" + this.hierarchy.toString();
        }

        makePurchase(startEmployee: Tree.Node<Personnel.BasePersonnel>, purchase: number): void {
            function accessPurchase(startEmployee: Tree.Node<Personnel.BasePersonnel>, purchase: number): void {
                if (!startEmployee.value.processPurchase(purchase)) {
                    console.log("Purchase for " + purchase + " USD is transferred to " + startEmployee.parent.toString());
                    accessPurchase(startEmployee.parent, purchase);
                }
            }

            if (startEmployee.value.processPurchase(purchase)) {
                console.log("Purchase for " + purchase + " USD is transferred to " + startEmployee.parent.toString());
                accessPurchase(startEmployee.parent, purchase);
            } else {
                throw new TypeError("" + startEmployee.toString() + " is not eligible to make an order.");
            }
        }
    }
} 