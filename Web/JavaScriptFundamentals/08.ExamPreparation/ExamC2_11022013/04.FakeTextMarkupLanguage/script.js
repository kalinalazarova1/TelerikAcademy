
function solve(args) {
    var texts = [],
        tags = [],
        head = 0,
        i,
        j,
        input,
        result = '',
        isOpenTag = false,
        tag = '',
        text = '',
        currentText;

        function parseFTML(text, tag) {

            function reverse(s) {
                var r = '',
                    ii;
                for (ii = s.length - 1; ii >= 0; ii--) {
                    r += s[ii];
                }

                return r;
            }

            function toggle(s) {
                var t = '',
                    ii;
                for (ii = 0; ii < s.length; ii++) {
                    if (s.charCodeAt(ii) > 96 && s.charCodeAt(ii) < 123) {
                        t += s.charAt(ii).toUpperCase();
                    }
                    else {
                        t += s.charAt(ii).toLowerCase();
                    } 
                }

                return t;
            }

            switch (tag) {
                case 'rev': return reverse(text);
                case 'del': return '';
                case 'upper': return text.toUpperCase();
                case 'lower': return text.toLowerCase();
                case 'toggle': return toggle(text);

            }
        }

    for (i = 1; i < args.length; i++) {
        input = args[i] + '\n';
        for (j = 0; j < input.length; j++) {
            if (input.charAt(j) === '<' && tags.length == 0) {
                result += text;
                text = '';
                isOpenTag = true;
            } else if (input.charAt(j) === '<' && input.charAt(j + 1) !== '/') {
                if (text === '') {
                    text = '#';
                }
                texts.push(text);
                text = '';
                isOpenTag = true;
            } else if (input.charAt(j) === '<' && input.charAt(j + 1) === '/') {
                while (input.charAt(j) !== '>') {
                    j++;
                }
                isOpenTag = false;
                if (tags.length > 1) {
                    currentText = texts.pop();
                    text = (currentText === '#' ? parseFTML(text, tags.pop()) : currentText + parseFTML(text, tags.pop()));
                } else {
                    text = parseFTML(text, tags.pop());
                }
            } else if (input.charAt(j) === '>') {
                tags.push(tag);
                tag = '';
                isOpenTag = false;
            } else if (isOpenTag) {
                tag += input.charAt(j);
            } else {
                text += input.charAt(j);
            }
        }
    }

    if (text !== '' && tags.length === 0) {
        result += text;
    }

    return result;
}

(function print() {
    var args = ['3', '<toggle><rev>ERa</rev></toggle> you', '<rev>noc</rev><lower>FUSED</lower>', '<rev>?<rev>already </rev></rev>'];
    console.log(solve(args));
})();
