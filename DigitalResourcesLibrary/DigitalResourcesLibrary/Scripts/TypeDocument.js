var Article = 0;
var Store = 1;

function getTypeDocumentById(id) {
    if (id == Article) {
        return "Article";
    } else {
        return "Store";
    }
}

function getIdByTypeDocument(type) {
    if (type == "Article") {
        return 0;
    } else {
        return 1;
    }
}