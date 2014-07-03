module Personnel {
    "use strict";
    export class FirmEmployee extends BasePersonnel
        implements IPersonnel, IEmployee {
        
        constructor(public firstName: string, public lastName: string, public position: string, public couldTakePurchase: boolean) {
            super(firstName, lastName, position);
        }

        processPurchase(purchase: number): boolean {
            if (this.couldTakePurchase) {
                console.log("Purchase for " + purchase + " USD is processed by " + this.toString());
                return true;
            } else {
                return false;
            }
        }
    }
} 