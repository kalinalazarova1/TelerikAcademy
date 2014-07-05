///<reference path="libs/require.js" />
///<reference path="libs/jquery.js" />
///<reference path="combo-box-item.js" />

define(['combo-box-item', 'libs/jquery'], function (ComboBoxItem) {
    var controls = (function () {
        function ComboBox(collection) {
            this._items = collection || [];
            this._collapsed = true;
        }

        ComboBox.prototype.render = function (htmlTemplate) {
            var self = this;
            var $combo = $('<div>')
                .addClass('combo-box')
            $('body').on('click', '.person-item', function () {
                var $this = $(this);
                if (!self._collapsed) {
                    self._collapsed = true;
                    $this.parent().find('.person-item').hide();
                    $this.show();
                } else {
                    $this.parent().find('.person-item').show();
                    self._collapsed = false;
                }
            });
            $('<div>')
                .addClass('list')
                .appendTo($combo);
            for (var i = 0; i < this._items.length; i++) {
                $combo.html($combo.html() + ComboBoxItem(this._items[i]).render(htmlTemplate));
                $combo.find('.person-item').hide().first().show();
            }
            return $combo.html();
        };

        return {
            ComboBox: function (collection) { return new ComboBox(collection); }
        };
    }());

    return controls;
});
