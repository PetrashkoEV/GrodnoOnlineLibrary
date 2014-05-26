var addDocument = $("#add-document");
var removeDocument = $("#remove-document");

function AddDocument(docId, docType) {
    $.ajax({
        type: 'POST',
        url: "/Documents/AddCookieDocument",
        data: { id: docId, type: docType },
        success: function () {
            addDocument.hide();
            removeDocument.show();
        }
    });
}

function RemoveDocument(docId, docType) {
    $.ajax({
        type: 'POST',
        url: "/Documents/RemoveCookieDocument",
        data: { id: docId, type: docType },
        success: function () {
            addDocument.show();
            removeDocument.hide();
        }
    });
}

function HideBookmarks() {
    addDocument.show();
    removeDocument.hide();

    var idAndType = document.getElementsByClassName('bookmarks')[0].id.split('-');
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
            end = cookie.indexOf(";", offset)
            if (end == -1) {
                end = cookie.length;
            }
            setStr = unescape(cookie.substring(offset, end));
        }
    }
    return (setStr);
}