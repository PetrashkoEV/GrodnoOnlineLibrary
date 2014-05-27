var addDocument = $("#add-document");
var removeDocument = $("#remove-document");
var blokBookmarks = $("#display-bookmarks");
var lengthtTitile = 21;

function AddDocumentInCookie(docId, docType) {
    $.ajax({
        type: 'POST',
        url: "/Documents/AddCookieDocument",
        data: { id: docId, type: docType },
        success: function (data) {
            addDocument.hide();
            removeDocument.show();
            var object = JSON.parse(data);
            if (object != null && object.Id != null){
                addBookmarkInLeftPanel(object.Id, object.TypeDocument, object.Title);
            }
        }
    });
}

function RemoveDocumentInCookie(docId, docType) {
    $.ajax({
        type: 'POST',
        url: "/Documents/RemoveCookieDocument",
        data: { id: docId, type: docType },
        success: function (data) {
            addDocument.show();
            removeDocument.hide();
            var object = JSON.parse(data);
            if (object != null && object.Id != null) {
                removeBookmarkInLeftPanel(object.Id, object.TypeDocument);
            }
        }
    });
}

function HideButtonAddAndRemoveBookmarks() {
    addDocument.show();
    removeDocument.hide();

    var bookmarks = document.getElementsByClassName('bookmarks')[0];
    if (bookmarks != null) {
        var idAndType = bookmarks.id.split('-');
        var jCookie = GetCookie("listdocumet");
        var object = JSON.parse(jCookie);
        if (object != null) {
            for (var i = 0; i < object.length; i++) {
                if (object[i].Id == idAndType[0] && object[i].TypeDocument == idAndType[1]) {
                    removeDocument.show();
                    addDocument.hide();
                }
            }
        }
    }
}

function LoadBookmarksLeftPanel() {
    if (blokBookmarks.length) {
        $.ajax({
            type: 'POST',
            url: "/Documents/GetTitleDookmarks",
            success: function(data) {
                var object = JSON.parse(data);
                for (var i = 0; i < object.length; i++) {
                    addBookmarkInLeftPanel(object[i].Id, object[i].TypeDocument, object[i].Title);
                }
            }
        });
    }
}





function addBookmarkInLeftPanel(id, type, title) {
    var newTitle = replaseTitle(title);
    var linkString = '<a id="' + id + '-' + type +'" ' +
                        'class="label label-info" ' +
                        'href="/Documents/' + getTypeDocumentById(type) + '/' + id + '" ' +
                        'data-placement="bottom" data-toggle="tooltip" ' +
                        'rel="tooltip" ' +
                        'data-original-title="' + title + '">' + newTitle +
                        '</a><button type="button" class="close" data-dismiss="modal" aria-hidden="true" onclick="RemoveDocumentInCookie(' + id + ', ' + getTypeDocumentById(type) + ')">&times;</button>' +
                        ' <br>';
    blokBookmarks.append(linkString);
}

function removeBookmarkInLeftPanel(id, type) {
    var content = '#' + id + '-' + type;
    var removeBlock = blokBookmarks.find(content);
    if (removeBlock != null) {
        removeBlock.remove();
    }
}

function replaseTitle(title) {
    if (title.length > lengthtTitile) {
        var newTitle = title.substr(0, lengthtTitile);
        newTitle += "...";
        return newTitle;
    }
    return title;
}
function GetCookie(name) {
    var cookie = " " + document.cookie;
    var search = " " + name + "=";
    var setStr = null;
    var offset = 0;
    var end = 0;
    if (cookie.length > 0) {
        offset = cookie.indexOf(search);
        if (offset != -1) {
            offset += search.length;
            end = cookie.indexOf(";", offset);
            if (end == -1) {
                end = cookie.length;
            }
            setStr = unescape(cookie.substring(offset, end));
        }
    }
    return (setStr);
}
