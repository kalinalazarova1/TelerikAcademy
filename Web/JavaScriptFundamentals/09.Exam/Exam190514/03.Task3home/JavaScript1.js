function solve(args) {
    var modelLines = args[0] | 0,
        models = {},
        model,
        sections = {},
        splitIndex,
        result = [],
        content = '',
        name = '',
        collection = '',
        i,
        p,
        counter,
        line = '',
        isHTML = false,
        indent = '',
        resultStr,
        splitString;

    for (i = 1; i <= modelLines; i++) { // parses the models
        splitIndex = args[i].split(':');
        if (splitIndex.indexOf(',') < 0) {
            models[splitIndex[0].trim()] = splitIndex[1];
        } else {
            models[splitIndex[0].trim()] = splitIndex[1].split(',');
        }
    }

    for (i = 0; i < args.length; i++) {     // replace all escape sequences with special symbol ('б') which will be replaced with '@' later
        if (args[i].indexOf('@@') >= 0) {
            args[i] = args[i].split('@@').join('б');
        }
    }

    resultStr = args.join('\n');
    for (model in models) {             // replaces all the models in the input
        splitString = '@' + model;
        resultStr = resultStr.split(splitString).join(models[model]);
    }

    args = resultStr.split('\n');
    for (i = modelLines + 2; i < args.length; i++) {
        if (!isHTML) {                                  // parses the first part of the input where sections are declared
            for (line = args[i]; line.indexOf('@section') >= 0; line = args[i]) {
                name = line.substring(9, line.length - 2);
                content = '';
                line = args[++i];
                while (line !== '}') {
                    content += line + '\n';
                    line = args[++i];
                }
                sections[name.trim()] = content.substring(0, content.length - 1);
                i++;
            }
            isHTML = true;
        }
        if (isHTML) {
            if (args[i].indexOf('@renderSection') >= 0) {           // parses the sections rendering
                name = args[i].substring(args[i].indexOf('@renderSection') + 16, args[i].indexOf('\")'));
                indent = args[i].substring(0, args[i].indexOf('@renderSection'));
                result.push(indent + sections[name].split('\n').join('\n' + indent) + args[i].substring(args[i].indexOf('\")') + 3));
            } else if (args[i].indexOf('@if (') >= 0) {               // parses the if statements
                name = args[i].substring(args[i].indexOf('@if (') + 5, args[i].indexOf(')'));
                indent = args[i].substring(0, args[i].indexOf('@if ('));
                if (models[name] === 'true') {
                    i++;
                    while (args[i].indexOf('}') < 0) {
                        result.push(args[i].substring(indent.length));
                        i++;
                    }
                } else {
                    i++;
                    while (args[i].indexOf('}') < 0) {
                        i++;
                    }
                }
            } else if (args[i].indexOf('@foreach (') >= 0) {          // parses the foreach loops
                name = args[i].substring(args[i].indexOf('@foreach (') + 14, args[i].indexOf(' in'));
                collection = args[i].substring(args[i].indexOf(' in ') + 4, args[i].indexOf(')'));
                indent = args[i].substring(0, args[i].indexOf('@foreach ('));
                i++;
                for (counter = 0; counter < models[collection].split(',').length; counter++) {
                    p = i;
                    while (args[p].indexOf('}') < 0) {
                        result.push(args[p].split('@' + name).join(models[collection].split(',')[counter]).substring(4));
                        p++;
                    }
                }
                i = p;
            } else {
                result.push(args[i]);                               // when it is only plain HTML it is directly put in the result
            }
        }
    }
    resultStr = result.join('\n').split('б').join('@');             // replaces the special symbol ('б') with '@'
    return resultStr;
}

var args = ['6',
    'title:Telerik Academy',
    'showSubtitle:true',
    'subTitle:Free training',
    'showMarks:false',
    'marks:3,4,5,6',
    'students:Pesho,Gosho,Ivan',
    '42',
    '@section menu {',
    '<ul id="menu">',
    '    <li>Home</li>',
    '    <li>About us</li>',
    '</ul>',
    '}',
    '@section footer {',
    '<footer>',
    '    Copyright Telerik Academy 2014',
    '</footer>',
    '}',
    '<!DOCTYPE html>',
    '<html>',
    '<head>',
    '    <title>Telerik Academy</title>',
    '</head>',
    '<body>',
    '    @renderSection("menu")',
    '',
    '    <h1>@title</h1>',
    '    @if (showSubtitle) {',
    '        <h2>@subTitle</h2>',
    '        <div>@@JustNormalTextWithDoubleKliomba ;)</div>',
    '    }',
    '',
    '    <ul>',
    '        @foreach (var student in students) {',
    '            <li>',
    '                @student ',
    '            </li>',
    '            <li>Multiline @title</li>',
    '        }',
    '    </ul>',
    '    @if (showMarks) {',
    '        <div>',
    '            @marks',
    '        </div>',
    '    }',
    '',
    '    @renderSection("footer")',
    '</body>',
    '</html>'
    ];
console.log(solve(args));