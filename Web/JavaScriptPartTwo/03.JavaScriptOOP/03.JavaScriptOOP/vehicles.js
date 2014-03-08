Function.prototype.inherit = function (parent) {        //simple inheritence
    this.prototype = new parent();
    this.prototype.constructor = this;
}

Function.prototype.extend = function (parent) {         //multiple inheritence gets specified properties from parent
    for (var i = 1; i < arguments.length; i += 1) {
        var name = arguments[i];
        this.prototype[name] = parent.prototype[name];
    }
    return this;
}

var vehicles = (function () { 

    function PropulsionUnit() {
    }

    PropulsionUnit.prototype.createAcceleration = function () {
    }

    Wheel.inherit(PropulsionUnit);

    function Wheel(radius) {
        PropulsionUnit.apply(this, arguments);
        this.radius = radius;
    }

    Wheel.prototype.createAcceleration = function () {
        return this.radius * Math.PI * 2;
    }

    Nozzle.inherit(PropulsionUnit);

    function Nozzle(power) {
        PropulsionUnit.apply(this, arguments);
        this.power = power;
        this.afterburnerOn = false;
    }

    Nozzle.prototype.createAcceleration = function () {
        return this.power * (this.afterburnerOn ? 2 : 1);
    }

    Nozzle.prototype.toggleAfterburnerSwitch = function () {
        this.afterburnerOn = !this.afterburnerOn;
    }

    Propeller.inherit(PropulsionUnit);

    function Propeller(finCount) {
        PropulsionUnit.apply(this, arguments);
        this.finCount = finCount;
        this.clockwiseSpin = true;
    }

    Propeller.prototype.createAcceleration = function () {
        return this.clockwiseSpin ? this.finCount : (this.finCount * (-1));
    }

    Propeller.prototype.changeSpin = function () {
        this.clockwiseSpin = !this.clockwiseSpin;
    }

    function Vehicle() {
        this.speed = 0;
        this.propulsionUnits = [];
        for (var i = 0; i < arguments.length; i++)
            this.propulsionUnits.push(arguments[i]);
    }

    Vehicle.prototype.accelerate = function () {
        var sum = 0;
        for (var i = 0; i < this.propulsionUnits.length; i++)
            sum += this.propulsionUnits[i].createAcceleration();
        this.speed += sum;
    }

    LandVehicle.inherit(Vehicle);

    function LandVehicle(wheel1, wheel2, wheel3, wheel4) {
        Vehicle.apply(this, [wheel1, wheel2, wheel3, wheel4]);
    }

    AirVehicle.inherit(Vehicle);

    function AirVehicle(nozzle) {
        Vehicle.call(this, nozzle);
    }

    AirVehicle.prototype.toggleAfterburnerSwitch = function () {
        this.propulsionUnits[0].toggleAfterburnerSwitch();
    }

    WaterVehicle.inherit(Vehicle);

    function WaterVehicle(propellers) {
        var props = [];
        for (var i = 0; i < arguments.length; i++)
            props.push(arguments[i]);
        Vehicle.apply(this, props);
    }

    WaterVehicle.prototype.changePropellersSpin = function () {
        this.propulsionUnits.forEach(function (unit) { unit.changeSpin() });
    }

    AmphibiousVehicle.inherit(WaterVehicle);
    AmphibiousVehicle.extend(LandVehicle);

    function AmphibiousVehicle(wheels, propellers) {
        this.landPropulsionUnits = wheels;
        this.waterPropulsionUnits = propellers;
        this.propulsionUnits = this.landPropulsionUnits;
    }
    
    AmphibiousVehicle.prototype.toggleMode = function () {
        this.propulsionUnits = (this.propulsionUnits == this.landPropulsionUnits ? this.waterPropulsionUnits : this.landPropulsionUnits);
        this.speed = 0;
    }

    return {
        LandVehicle: LandVehicle,
        AirVehicle: AirVehicle,
        WaterVehicle: WaterVehicle,
        AmphibiousVehicle: AmphibiousVehicle,
        Wheel: Wheel,
        Nozzle: Nozzle,
        Propeller: Propeller,
    };
})();