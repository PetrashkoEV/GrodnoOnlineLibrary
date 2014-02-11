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
}