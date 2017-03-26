$(document).ready(function () {
    $("[data-pdsa-action]").on("click", function (e) {
        e.preventDefault();

        $("#EventCommand").val(
          $(this).data("pdsa-action"));

        $("#EventArgument").val(
          $(this).attr("data-pdsa-val"));

        $("form").submit();
    });

    $("input:file").change(function () {
        var ext = this.value.match(/\.([^\.]+)$/)[1];
        switch (ext) {
        case 'jpg':
        case 'jpeg':
        case 'png':
            break;
        default:
            alert('Not allowed type! Only .jpg, .jpeg, .png');
            this.value = '';
        }

        var filename = $('input[type=file]').val().split('\\').pop();
        $('#Entity_PicturePath').val(filename);
    });
});