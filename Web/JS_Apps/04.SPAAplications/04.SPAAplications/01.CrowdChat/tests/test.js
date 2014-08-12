//define(['init', 'controller'], function (init, controller) {
    describe('#toSaveString', function () {
        it('when < replace with &lt;', function () {
            var actual = controller.toSaveString('first<second');
            var expected = 'first&lt;second';
        });
        it('when > replace with &gt;', function () {
            var actual = controller.toSaveString('first>second');
            var expected = 'first&gt;second';
        });
    });
//});