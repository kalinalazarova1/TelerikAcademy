function solve(args) {
    var molsLines = args[0] | 0;
    var mols = {},
        sects = {},
        temp;
    var result = '';
    for (var i = 1; i <= molsLines; i++) {
        temp = args[i].split(':');
        if (temp.indexOf(',') < 0) {
            mols[temp[0].trim()] = temp[1];
        } else {
            mols[temp[0].trim()] = temp[1].split(',');
        }
    }
    var linesCount = args[molsLines + 1] | 0;
    var line = '';
    var isHTML = false;
    for (i = molsLines + 2; i < args.length; i++) {
        if (!isHTML) {
            for (line = args[i]; line.indexOf('@section') >= 0; line = args[i]) {
                var name = line.substring(9, line.length - 2);
                var text = '';
                line = args[++i];
                while (line !== '}') {
                    text += line + '\n';
                    line = args[++i];
                }
                sects[name.trim()] = text.substring(0, text.length - 1);
                i++;
            }
            isHTML = true;
        }
        if(isHTML){
            
        }
    }
    result = result.substring(0, result.length - 1);

    for (var mol in mols) {
        var sp = '@' + mol;
        result = result.split(sp).join(mols[mol]);
    } //ok
    result = result.replace('@@', '@');
    sp = '@renderSection';
    var tlines = result.split(sp);
    for (var q = 1; q < tlines.length; q++) {
        if (tlines[q].indexOf('(\"') === 0) {
            var sectName = '';
            p = tlines[q].indexOf('(\"') + 2;
            while (tlines[q][p] !== '\"') {
                sectName += tlines[q][p];
                p++;
            }
            p += 2;
            var ident = -tlines[q - 1].lastIndexOf('\n') + tlines[q - 1].length - 1;
            tlines[q] = sects[sectName].split('\n').join('\n' + new Array(ident + 1).join(' ')) + tlines[q].substring(p);
        }
    }
    result = tlines.join('');
    var iflines = result.split('@if ');
    for (q = 1; q < iflines.length; q++) {
        if (iflines[q].indexOf('(') === 0) {
            var ifName = '';
            p = iflines[q].indexOf('(') + 1;
            while (iflines[q][p] !== ')') {
                ifName += iflines[q][p];
                p++;
            }
            p += 3;
            if (mols[ifName] === 'true') {
                var test = iflines[q].substring(p);
                iflines[q] = iflines[q].substring(p);
                iflines[q] = iflines[q].replace('}\n', '');
            }
            else {
                p = iflines[q].indexOf('}') + 1
                iflines[q] = iflines[q].substring(p);
            }
        }
    }
    result = iflines.join('');
    var loopLines = result.split('@foreach (var ');
    for (q = 1; q < loopLines.length; q++) {
        var name = loopLines[q].substring(0, loopLines[q].indexOf(' '));
        var collName = loopLines[q].substring(loopLines[q].indexOf('in') + 3, loopLines[q].indexOf(')'));
        var tempResult = '';
        for (var k = 0; k < mols[collName].split(',').length; k++) {
            tempResult += loopLines[q].substring(loopLines[q].indexOf('{') + 1, loopLines[q].indexOf('}')).replace('@' + name, mols[collName].split(',')[k]);
        }
        loopLines[q] = tempResult + loopLines[q].substring(loopLines[q].indexOf('}') + 1);
    }
    result = loopLines.join('');
    return result;
}

var args = ['6','    title:Telerik Academy', '    showSubtitle:true', '    subTitle:Free training', '    showMarks:false', '    marks:3,4,5,6', 'students:Pesho,Gosho,Ivan', '42', '@section menu {', '<ul id="menu">', '    <li>Home</li>', '    <li>About us</li>', '</ul>', '}', '@section footer {', '<footer>', '    Copyright Telerik Academy 2014', '</footer>', '}', '<!DOCTYPE html>', '<html>', '<head>', '    <title>Telerik Academy</title>', '</head>', '<body>', '    @renderSection("menu")', '    <h1>@title</h1> ', '   @if (showSubtitle) { ', '        <h2>@subTitle</h2>', '        <div>@@JustNormalTextWithDoubleKliomba ;)</div>', '    }', '    <ul>', '        @foreach (var student in students) {', '            <li>', '                @student ', '            </li>', '            <li>Multiline @title</li>', '        }', '    </ul>', '    @if (showMarks) {', '        <div>', '            @marks ', '        </div>', '    }', '    @renderSection("footer")', '</body>', '</html>'];
console.log(solve(args));