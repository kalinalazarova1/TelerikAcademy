Function.prototype.inherit = function (parent) {        //simple inheritence
    this.prototype = new parent();
    //this.prototype.constructor = parent;
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

    function Wheel(radius) {
        PropulsionUnit.apply(this, arguments);
        this.radius = radius;
    }

    Wheel.prototype.createAcceleration = function () {
        return this.radius * Math.PI * 2;
    }

    Wheel.extend(PropulsionUnit);

    function Nozzle(power) {
        this.power = power;
        this.afterburnerOn = false;
    }

    Nozzle.prototype.createAcceleration = function () {
        return this.power * (this.afterburnerOn ? 2 : 1);
    }

    Nozzle.prototype.toggleAfterburnerSwitch = function () {
        this.afterburnerOn = !this.afterburnerOn;
    }

    Nozzle.extend(PropulsionUnit);

    function Propeller(finCount) {
        this.finCount = finCount;
        this.clockwiseSpin = true;
    }

    Propeller.prototype.createAcceleration = function () {
        return this.clockwiseSpin ? this.finCount : (this.finCount * (-1));
    }

    Propeller.prototype.changeSpin = function () {
        this.clockwiseSpin = !this.clockwiseSpin;
    }

    Propeller.extend(PropulsionUnit);

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
        console.log(sum);
        this.speed += sum;
    }

    function LandVehicle(wheel1, wheel2, wheel3, wheel4) {
        Vehicle.apply(this, [wheel1, wheel2, wheel3, wheel4]);
    }

    LandVehicle.inherit(Vehicle)

    function AirVehicle(nozzle) {
        Vehicle.call(this, nozzle);
    }

    AirVehicle.inherit(Vehicle);

    function WaterVehicle(propellers) {
        var props = [];
        for (var i = 0; i < arguments.length; i++)
            props.push(arguments[i]);
        Vehicle.apply(this, props);
    }

    WaterVehicle.inherit(Vehicle);

    function AmphibiousVehicle(wheels, propellers) {
        this.landPropulsionUnits = wheels;
        this.waterPropulsionUnits = propellers;
        this.propulsionUnits = this.landPropulsionUnits;
    }

    AmphibiousVehicle.inherit(Vehicle);
    AmphibiousVehicle.prototype.toggleMode = function () {
        this.propulsionUnits = (this.propulsionUnits == this.landPropulsionUnits ? this.waterPropulsionUnits : this.landPropulsionUnits);
        this.speed = 0;

    }
    AmphibiousVehicle.extend(WaterVehicle);

    return {
        LandVehicle: LandVehicle,
        AirVehicle: AirVehicle,
        WaterVehicle: WaterVehicle,
        AmphibiousVehicle: AmphibiousVehicle,
        Wheel: Wheel,
        Nozzle: Nozzle,
        Propeller: Propeller
    };
})();