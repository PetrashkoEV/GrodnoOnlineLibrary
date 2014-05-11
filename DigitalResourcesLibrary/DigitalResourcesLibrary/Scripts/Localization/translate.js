var result;

if (typeof settings !== 'object') {
    var settings = {};
    result = $.ajax({
        type: "POST",
        url: "/Localization/GetCurentLocalization",
        async: false
    }).responseText;
}
// Default language
settings.lang = result;

function resx (params, lang) {
    var lang = lang || settings.lang, translated = '', code;
    params = params.toLowerCase().split(':');
    if (messages[lang] !== undefined && params.length) {
        for (var i = 0, msgcat = messages[lang]; i < params.length; i++) {
            code = params[i];
            if (typeof msgcat[code] === 'object') {
                msgcat = msgcat[code];
            }
            if (typeof msgcat[code] === 'string') {
                translated = msgcat[code];
                break;
            }
        }
    }
    return translated;
};
