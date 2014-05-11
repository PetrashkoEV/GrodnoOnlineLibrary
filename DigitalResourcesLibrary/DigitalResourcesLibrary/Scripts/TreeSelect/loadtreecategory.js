var obj = null;

var loadChildren = function (node, level) {
    if (obj == null) {
        var result = $.ajax({
            type: "POST",
            url: "/Search/СhildrenCategory",
            data: "id=" + node.id,
            async: false
        }).responseText;
        obj = jQuery.parseJSON(result);
    }
    return searchSelectCategoryId(node.id, node, obj);
};

function searchSelectCategoryId(categoryId, node, category) {
    if (categoryId == 0) {
        return getCategory(node, category);
    }
    // search select category 
    for (var i = 0; i < category.length; i++) {
        if (category[i].Id == categoryId) {
            node = getCategory(node, category[i].Subcategory); // return all subcategories
        } else {
            searchSelectCategoryId(categoryId, node, category[i].Subcategory); // search in subcategory
        }
    }
    return node;
}

function getCategory(node, category) {
    for (var i = 0; i < category.length; i++) {
        node.children.push({
            id: category[i].Id,
            title: category[i].Name,
            has_children: category[i].Subcategory.length,
            level: node.level + 1,
            children: []
        });
    }
    return node;
}