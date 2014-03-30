function LoadPage() {
    $('body').tooltip({
        selector: "[rel=tooltip]"
    });
    
    $(document).ready(function () {
        $('.carousel').carousel({
            interval: 10000
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
}