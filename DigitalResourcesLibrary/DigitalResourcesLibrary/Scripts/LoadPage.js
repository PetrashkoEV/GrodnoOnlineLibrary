function LoadPage() {
    $('body').tooltip({
        selector: "[rel=tooltip]"
    });

    LoadBookmarksLeftPanel();

    // carousel
    $(document).ready(function () {
        $('.carousel').carousel({
            interval: 9999
        });

        $('.carousel').carousel('cycle');
    });

    // audio player
    $('audio').audioPlayer(
    {
        classPrefix: 'audioplayer',
        strPlay: 'Play',
        strPause: 'Pause',
        strVolume: 'Volume'
    });

    // autocomplete
    $('#autocompleteRepository').autocomplete({
        serviceUrl: '/Search/AutoComplete', // Страница для обработки запросов автозаполнения
        paramName: 'search',
        minChars: 2, // Минимальная длина запроса для срабатывания автозаполнения
        delimiter: /(,|;)\s*/, // Разделитель для нескольких запросов, символ или регулярное выражение
        maxHeight: 400, // Максимальная высота списка подсказок, в пикселях
        width: 300, // Ширина списка
        zIndex: 9999, // z-index списка
        deferRequestBy: 300, // Задержка запроса (мсек), на случай, если мы не хотим слать миллион запросов, пока пользователь печатает. Я обычно ставлю 300.
        onSelect: function (data, value) { }, // Callback функция, срабатывающая на выбор одного из предложенных вариантов,
    });

    // multiselect tags
    $('#tags').multiselect({
        includeSelectAllOption: true,
        enableCaseInsensitiveFiltering: true,
        numberDisplayed: 5,
        maxHeight: 250,
        buttonWidth: '245px',
        inputContainer: '.tagSelect',
        selectAllText: resx('resource:multiselect:select_all'),
        nonSelectedText: resx('resource:multiselect:none_selected_tag'),
        nSelectedText: resx('resource:multiselect:n_selected_text_tag'),
        filterPlaceholder: resx('resource:base:search')
    });

    // multiselect format document
    $('#format').multiselect({
        includeSelectAllOption: true,
        inputContainer: '.documentsSelect',
        selectAllText: resx('resource:multiselect:select_all'),
        nonSelectedText: resx('resource:multiselect:none_selected_type_doc'),
        nSelectedText: resx('resource:multiselect:n_selected_text_type_doc')
    });

    // hide if not supported by the player html
    HidePlauerBytNoHTML5();

    // multiselect tree view
    $('div.chosentree').chosentree({
        width: 500,
        /*autosearch: true,
        input_type: 'search',*/
        deepLoad: true,
        showtree: true,
        input_placeholder: resx('resource:multiselect:select_item_category'),
        load: function (node, callback) {
            setTimeout(function () {
                callback(loadChildren(node, 0));
            }, 40);
        }
    });

    HideButtonAddAndRemoveBookmarks();
}


function HidePlauerBytNoHTML5() {
    if (!Modernizr.video || !Modernizr.audio) {
        var inner = document.getElementsByClassName("media-content")[0];
        inner.style.display = "none";
    }
}
