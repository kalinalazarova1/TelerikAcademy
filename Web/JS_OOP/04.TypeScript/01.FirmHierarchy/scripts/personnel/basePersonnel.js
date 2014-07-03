var Personnel;
(function (Personnel) {
    "use strict";
    var BasePersonnel = (function () {
        function BasePersonnel(firstName, lastName, position) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.position = position;
            this._id = ++BasePersonnel._idGenerator;
        }
        Object.defineProperty(BasePersonnel.prototype, "id", {
            get: function () {
                return this._id;
            },
            enumerable: true,
            configurable: true
        });

        BasePersonnel.prototype.toString = function () {
            return this.id + "." + this.firstName + " " + this.lastName + " : " + this.position;
        };

        BasePersonnel.prototype.processPurchase = function (purchase) {
            return true;
        };
        BasePersonnel._idGenerator = 0;
        return BasePersonnel;
    })();
    Personnel.BasePersonnel = BasePersonnel;
})(Personnel || (Personnel = {}));
//# sourceMappingURL=basePersonnel.js.map
