var Firm;
(function (_Firm) {
    "use strict";
    var Firm = (function () {
        function Firm(name, hierarchy) {
            this.name = name;
            this.hierarchy = hierarchy;
        }
        Firm.prototype.toString = function () {
            return this.name + "\n" + this.hierarchy.toString();
        };

        Firm.prototype.makePurchase = function (startEmployee, purchase) {
            function accessPurchase(startEmployee, purchase) {
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
        };
        return Firm;
    })();
    _Firm.Firm = Firm;
})(Firm || (Firm = {}));
//# sourceMappingURL=firm.js.map
