module Personnel {
    "use strict";
    export class FirmManager extends BasePersonnel
        implements IPersonnel, IManager {
        
        constructor(public firstName: string, public lastName: string, public position: string, public competency: number) {
            super(firstName, lastName, position);
        }

        processPurchase(purchase: number): boolean {
            if (this.competency >= purchase) {
                console.log("Purchase for " + purchase + " USD approved by " + this.toString());
                return true;
            } else {
                return false;
            }
        }
    }
} 