var galleryHolder = document.createElement('div');
galleryHolder.id = 'image-gallery-holder';
document.body.appendChild(galleryHolder);

function onClick(ev) {
    if (!ev) {
        ev = window.event;
    }
    if (event.target.className === 'visible') {
        event.target.className = '';
        var next = event.target.parentNode.children[1];
        
        while (next) {
            next.style.display = 'none';
            next = next.nextSibling;
        }
    } else {
        event.target.className = 'visible';
        var next = event.target.parentNode.children[1];

        while (next) {
            next.style.display = 'inline-block';
            next = next.nextSibling;
        }
    }
}

function safe(text) {
    text.replace(/</gi, '&gt;');
    text.replace(/>/gi, '&lt;');
    return text;
}

Node.prototype.addImage = function (title, src) {
    var frame = document.createElement('div');
    frame.className = 'image-frame';
    var imageTitle = document.createElement('h1');
    imageTitle.innerHTML = safe(title);
    frame.appendChild(imageTitle);
    var imageFrame = document.createElement('div');
    imageFrame.className = 'frame';
    var img = document.createElement('img');
    img.setAttribute('src', src);
    imageFrame.appendChild(img);
    frame.appendChild(imageFrame);
    this.appendChild(frame);
};

Node.prototype.addAlbum = function (title) {
    var frame = document.createElement('div');
    frame.className = 'album-frame';
    var albumTitle = document.createElement('h1');
    albumTitle.addEventListener('click', onClick, false);
    frame.appendChild(albumTitle);
    albumTitle.innerHTML = safe(title);
    this.appendChild(frame);
    return frame;
};

var controls = (function () {
    function getImageGallery(containerId) {
        return document.getElementById(containerId.substring(1));
    }
    return {
        getImageGallery: getImageGallery
    };
})();