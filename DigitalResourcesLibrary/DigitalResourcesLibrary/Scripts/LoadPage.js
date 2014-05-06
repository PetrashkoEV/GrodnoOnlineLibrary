﻿function LoadPage() {
    $('body').tooltip({
        selector: "[rel=tooltip]"
    });

    $(document).ready(function () {
        $('.carousel').carousel({
            interval: 9999
        });

        $('.carousel').carousel('cycle');
    });

    $('audio').audioPlayer(
    {
        classPrefix: 'audioplayer',
        strPlay: 'Play',
        strPause: 'Pause',
        strVolume: 'Volume'
    });

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

    $('#tags').multiselect({
        includeSelectAllOption: true,
        enableCaseInsensitiveFiltering: true,
        numberDisplayed: 5,
        maxHeight: 250,
        buttonWidth: '245px',
        inputContainer: '.tagSelect'
    });

    $('#format').multiselect({
        includeSelectAllOption: true,
        inputContainer: '.documentsSelect'
    });

    HidePlauerBytNoHTML5();

    $('div.chosentree').chosentree({
        width: 500,
        deepLoad: true,
        showtree: true,
        load: function (node, callback) {
            setTimeout(function () {
                callback(loadChildren(node, 0));
            }, 1000);
        }
    });
}

function HidePlauerBytNoHTML5() {
    if (!Modernizr.video || !Modernizr.audio) {
        var inner = document.getElementsByClassName("media-content")[0];
        inner.style.display = "none";
    }
}