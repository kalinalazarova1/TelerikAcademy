onload = function () {
    'use strict';
    var humans = [],
        tree = [],
        i,
        j,
        l,
        forAdding,
        stage,
        layer,
        //familyMembers = [{
        //    mother: 'Maria Petrova',
        //    father: 'Georgi Petrov',
        //    children: ['Teodora Petrova', 'Peter Petrov']
        //}, {
        //    mother: 'Petra Stamatova',
        //    father: 'Todor Stamatov',
        //    children: ['Teodor Stamatov', 'Boris Opanov', 'Maria Petrova']
        //}, {
        //    mother: 'Boriana Stamatova',
        //    father: 'Teodor Stamatov',
        //    children: ['Martin Stamatov', 'Albena Dimitrova']
        //}, {
        //    mother: 'Albena Dimitrova',
        //    father: 'Ivan Dimitrov',
        //    children: ['Doncho Dimitrov', 'Ivaylo Dimitrov']
        //}, {
        //    mother: 'Donika Dimitrova',
        //    father: 'Doncho Dimitrov',
        //    children: ['Vladimir Dimitrov', 'Iliana Dobreva']
        //}, {
        //    mother: 'Juliana Petrova',
        //    father: 'Peter Petrov',
        //    children: ['Dimitar Petrov', 'Galina Opanova']
        //}, {
        //    mother: 'Iliana Dobreva',
        //    father: 'Delian Dobrev',
        //    children: ['Dimitar Dobrev', 'Galina Pundiova']
        //}, {
        //    mother: 'Galina Pundiova',
        //    father: 'Martin Pundiov',
        //    children: ['Dimitar Pundiov', 'Todor Pundiov']
        //}, {
        //    mother: 'Maria Pundiova',
        //    father: 'Dimitar Pundiov',
        //    children: ['Georgi Pundiov', 'Stoian Pundiov']
        //}, {
        //    mother: 'Dobrinka Pundiova',
        //    father: 'Georgi Pundiov',
        //    children: ['Pavel Pundiov', 'Marian Pundiov']
        //}, {
        //    mother: 'Elena Pundiova',
        //    father: 'Marian Pundiov',
        //    children: ['Kamen Pundiov', 'Hristina Ivancheva']
        //}, {
        //    mother: 'Hristina Ivancheva',
        //    father: 'Martin Ivanchev',
        //    children: ['Kamen Ivanchev', 'Evgeny Ivanchev']
        //}, {
        //    mother: 'Maria Ivancheva',
        //    father: 'Kamen Ivanchev',
        //    children: ['Ivo Ivanchev', 'Delian Ivanchev']
        //}, {
        //    mother: 'Nadejda Ivancheva',
        //    father: 'Ivo Ivanchev',
        //    children: ['Petio Ivanchev', 'Marin Ivanchev']
        //}, {
        //    mother: 'Natalia Ivancheva',
        //    father: 'Delian Ivanchev',
        //    children: ['Galina Hristova']
        //}, {
        //    mother: 'Galina Opanova',
        //    father: 'Boian Opanov',
        //    children: ['Maria Opanova', 'Patar Opanov']
        //}, {
        //    mother: 'Galina Hristova',
        //    father: 'Marin Hristov',
        //    children: ['Petar Hristov', 'Kamen Hristov', 'Ivan Hristov']
        //}, {
        //    mother: 'Simona Hristova',
        //    father: 'Kamen Hristov',
        //    children: ['Elena Hristova', 'Valeria Hristova']
        //}];
        familyMembers = [
            {
                mother: 'Ganka',
                father: 'Petur',
                children: ['Stefan', 'Rumqna']
            },
            {
                mother: 'Stanka',
                father: 'Rumen',
                children: ['Stamen', 'Petq', 'Stoqn']
            },
            {
                mother: 'Mariq',
                father: 'Ico',
                children: ['Ivo']
            },
            {
                mother: 'Pavlina',
                father: 'Genadi',
                children: ['Jivka']
            },
            {
                mother: 'Diana',
                father: 'Pesho',
                children: ['Iva']
            },
            {
                mother: 'Iva',
                father: 'Stefan',
                children: ['Joro']
            },
            {
                mother: 'Jivka',
                father: 'Joro',
                children: ['Stefani', 'Daniela']
            },
            {
                mother: 'Petq',
                father: 'Ivo',
                children: ['Doncho', 'Monika']
            },
            {
                mother: 'Rumqna',
                father: 'Stamen',
                children: ['Gancho', 'Mihaela']
            }];

    function findNode(name) {
        var k;
        for (k = 0; k < humans.length; k++) {
            if (humans[k].name === name) {
                return humans[k];
            }
        }
    }

    function findParents(name) {
        var k,
            parents;
        for (k = 0; k < familyMembers.length; k++) {
            parents = [];
            if (familyMembers[k].children.indexOf(name) >= 0) {
                parents.push(familyMembers[k].mother);
                parents.push(familyMembers[k].father);
                return parents;
            }
        }
    }

    function isProbablyMale(name) {
        var k;
        for (k = 0; k < familyMembers.length; k++) {
            if (name.indexOf(familyMembers[k].father) >= 0) {
                return true;
            }
        }
        if (name[name.length - 1] !== 'a' && name[name.length - 1] !== 'q') {
            return true;
        }
        return false;
    }

    function findNodeTree(name) {
        var lev,
            k;
        for (lev = 0; lev < tree.length; lev++) {
            for (k = 0; k < tree[lev].length; k++) {
                if (tree[lev][k].name === name) {
                    return tree[lev][k];
                }
            }
        }
    }

    function markLevel(node, level) {
        var k;
        if (node.level === undefined || level > node.level) {
            node.level = level;
            node.isRendered = false;
            node.renderedLinks = false;
            tree[level] = tree[level] || [];
            tree[level].push(node);
        }
        if (node.children === undefined) {
            return;
        }

        for (k = 0; k < node.children.length; k++) {
            markLevel(findNode(node.children[k]), level + 1);
        }
    }

    function renderNode(node, row, col) {

        var rect = new Kinetic.Rect({
            x: col * 270 + 5,
            y: row * 80 + 5,
            width: 100,
            height: 40,
            strokeWidth: 2,
            stroke: 'yellowgreen',
            cornerRadius: node.isMale ? 5 : 20
        }),
            text = new Kinetic.Text({
                x: col * 270 + 5,
                y: row * 80 + 13 + 5,
                width: 100,
                heigth: 40,
                align: 'center',
                fill: 'black',
                text: node.name,
                fontSize: 14,
                fontFamily: 'Calibri'
            });
        layer.add(text);
        layer.add(rect);
        node.isRendered = true;
        node.x = col * 270 + 5;
        node.y = row * 80 + 5;
        if (node.partner !== undefined) {
            rect = new Kinetic.Rect({
                x: col * 270 + 120 + 5,
                y: row * 80 + 5,
                width: 100,
                height: 40,
                strokeWidth: 2,
                stroke: 'yellowgreen',
                cornerRadius: !node.isMale ? 5 : 20
            });
            text = new Kinetic.Text({
                x: col * 270 + 120 + 5,
                y: row * 80 + 13 + 5,
                width: 100,
                heigth: 40,
                align: 'center',
                fill: 'black',
                text: node.partner,
                fontSize: 14,
                fontFamily: 'Calibri'
            });
            findNodeTree(node.partner).isRendered = true;
            findNodeTree(node.partner).x = col * 270 + 120 + 5;
            findNodeTree(node.partner).y = row * 80 + 5;
            layer.add(text);
            layer.add(rect);
        }
        stage.add(layer);
    }

    function renderTree(root, column) {
        var k,
            child;
        if (root === undefined) {
            return;
        }
        if (!root.isRendered) {
            renderNode(root, root.level, column);
            for (k = 0; k < (root.children !== undefined ? root.children.length : 0); k++) {
                child = findNodeTree(root.children[k]);
                if (!child.isRendered) {
                    renderTree(child, Math.max(tree[child.level].indexOf(child), k));
                }
            }
        }
    }

    function renderLinks(p1X, p1Y, childX, childY) {
        var color = 'yellowgreen',
            link = new Kinetic.Shape({
                drawFunc: function (context) {
                    var beizerCPdx = Math.abs(childX - p1X) / 10,
                        beizerCPdY = Math.abs(childY - p1Y - 20) * 0.95;
                    context.beginPath();
                    context.moveTo(p1X + 100, p1Y + 20);
                    context.lineTo(p1X + 100 + 20, p1Y + 20);
                    context.moveTo(p1X + 100 + 10, p1Y + 20);
                    context.bezierCurveTo(p1X + 100 + 10 + beizerCPdx, p1Y + 20 + beizerCPdY,
                        childX + 50 - beizerCPdx, childY - beizerCPdY,
                        childX + 50, childY);
                    context.strokeShape(this);
                    context.beginPath();
                    context.lineTo(childX + 50 + 5, childY - 5);
                    context.lineTo(childX + 50 - 5, childY - 5);
                    context.lineTo(childX + 50, childY);
                    context.fillShape(this);
                },
                strokeWidth: 1,
                fill: color,
                stroke: color
            });
        layer.add(link);
        stage.add(layer);
    }

    function renderTreeLinks(root) {
        var k,
            child;
        if (root === undefined) {
            return;
        }
        if (root.children === undefined) {
            return;
        }
        for (k = 0; k < root.children.length; k++) {
            child = findNodeTree(root.children[k]);
            if (!root.renderedLinks) {
                renderLinks(root.x, root.y, child.x, child.y);
            }
            renderTreeLinks(child);
        }
        root.renderedLinks = true;
        findNodeTree(root.partner).renderedLinks = true;
    }

    for (i = 0; i < familyMembers.length; i++) {        // converts the families JSON to personal JSON
        humans.push({
            name: familyMembers[i].mother,
            isMale: false,
            partner: familyMembers[i].father,
            children: familyMembers[i].children,
            parents: findParents(familyMembers[i].mother)
        });

        humans.push({
            name: familyMembers[i].father,
            isMale: true,
            partner: familyMembers[i].mother,
            children: familyMembers[i].children,
            parents: findParents(familyMembers[i].father)
        });
    }

    for (i = 0; i < familyMembers.length; i++) {        // adds the persons without children and partners
        for (l = 0; l < familyMembers[i].children.length; l++) {
            forAdding = true;
            for (j = 0; j < humans.length; j++) {
                if (familyMembers[i].children[l] === humans[j].name) {
                    forAdding = false;
                    break;
                }
            }
            if (forAdding) {
                humans.push({
                    name: familyMembers[i].children[l],
                    isMale: isProbablyMale(familyMembers[i].children[l]),
                    partner: undefined,
                    children: undefined,
                    parents: findParents(familyMembers[i].children[l])
                });
            }
        }
    }

    for (i = 0; i < humans.length; i++) {           // marks the level of every person and builds the tree
        if (humans[i].parents === undefined) {
            markLevel(humans[i], 0);
        }
    }

    stage = new Kinetic.Stage({                     // initializes the canvas
        container: 'canvas-container',
        width: (tree[0].length + 1) * 270,
        height: (tree.length + 1) * 80
    });
    layer = new Kinetic.Layer();
    i = 0;
    for (j = 0; j < tree[0].length; j++) {          // renders the tree nodes (persons)
        if (!tree[0][j].isRendered) {
            renderTree(tree[0][j], i);
            i++;
        }
    }
    for (j = 0; j < tree[0].length; j++) {          // renders the links between them
        renderTreeLinks(tree[0][j]);
    }
};