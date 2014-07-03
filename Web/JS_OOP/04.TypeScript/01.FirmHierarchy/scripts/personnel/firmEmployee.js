var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Personnel;
(function (Personnel) {
    "use strict";
    var FirmEmployee = (function (_super) {
        __extends(FirmEmployee, _super);
        function FirmEmployee(firstName, lastName, position, couldTakePurchase) {
            _super.call(this, firstName, lastName, position);
            this.firstName = firstName;
            this.lastName = lastName;
            this.position = position;
            this.couldTakePurchase = couldTakePurchase;
        }
        FirmEmployee.prototype.processPurchase = function (purchase) {
            if (this.couldTakePurchase) {
                console.log("Purchase for " + purchase + " USD is processed by " + this.toString());
                return true;
            } else {
                return false;
            }
        };
        return FirmEmployee;
    })(Personnel.BasePersonnel);
    Personnel.FirmEmployee = FirmEmployee;
})(Personnel || (Personnel = {}));
//# sourceMappingURL=firmEmployee.js.map
