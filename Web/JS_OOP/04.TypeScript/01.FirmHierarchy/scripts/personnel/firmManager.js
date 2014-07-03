var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Personnel;
(function (Personnel) {
    "use strict";
    var FirmManager = (function (_super) {
        __extends(FirmManager, _super);
        function FirmManager(firstName, lastName, position, competency) {
            _super.call(this, firstName, lastName, position);
            this.firstName = firstName;
            this.lastName = lastName;
            this.position = position;
            this.competency = competency;
        }
        FirmManager.prototype.processPurchase = function (purchase) {
            if (this.competency >= purchase) {
                console.log("Purchase for " + purchase + " USD approved by " + this.toString());
                return true;
            } else {
                return false;
            }
        };
        return FirmManager;
    })(Personnel.BasePersonnel);
    Personnel.FirmManager = FirmManager;
})(Personnel || (Personnel = {}));
//# sourceMappingURL=firmManager.js.map
