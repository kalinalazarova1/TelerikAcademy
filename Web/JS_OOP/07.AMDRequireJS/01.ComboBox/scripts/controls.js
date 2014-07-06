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
            var unique = new Date().getTime();
            var $combo = $('<div>')
            $('body').on('click', '#combo' + unique + ' .combo-box-item', function () {
            var $this = $(this);
                if (!self._collapsed) {
                    self._collapsed = true;
                    $this.parent().find('.combo-box-item').hide();
                    $this.show();
                } else {
                    $this.parent().find('.combo-box-item').show();
                    self._collapsed = false;
                }
            });
            
            for (var i = 0; i < this._items.length; i++) {
                $combo.html($combo.html() + ComboBoxItem(this._items[i]).render(htmlTemplate));
                $combo.find('.combo-box-item').hide().first().show();
            }
            
            var $list = $('<div>').append($('<div id="combo'+ unique +'">').append($combo));

            return $list.html();
        };

        return {
            ComboBox: function (collection) { return new ComboBox(collection); }
        };
    }());

    return controls;
});
