


function ThousandSeparatorMaskGlobal() {
    $('.ThousandSeparatorMask').each(function (i, obj) {
        var el = $(obj);
        var nodeName = $(obj)[0].nodeName;     
        if (nodeName === 'SELECT') {
            $(".ThousandSeparatorMask option").each(function (j, option) {
                var strtxt = $(option).text();
                strtxt = strtxt.replace(/\D+/g, '');
                $(option).text(strtxt.replace(/\B(?=(\d{3})+(?!\d))/g, ","));
            });
        } else {
            if (el[0].value !== undefined) {
                var str = el[0].value;
                str = str.replace(/\D+/g, '');
                el.val(str.replace(/\B(?=(\d{3})+(?!\d))/g, ","));
            } else {
                var strhtml = el[0].innerHTML;
                strhtml = strhtml.replace(/\D+/g, '');
                el.html(strhtml.replace(/\B(?=(\d{3})+(?!\d))/g, ","));
            }
        }
    });
}



$(document).ready(function () {
    setTimeout(function () {
        ThousandSeparatorMaskGlobal();
    }, 2000);

    $('.ThousandSeparatorMask').on('input', function () {
        var str = $(this).val();
        str = str.replace(/\D+/g, '');
        $(this).val(str.replace(/\B(?=(\d{3})+(?!\d))/g, ","));
    });
});