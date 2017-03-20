$(document).ready(function () {
    $("[data-pdsa-action]").on("click", function (e) {
        e.preventDefault();

        $("#EventCommand").val(
          $(this).data("pdsa-action"));

        $("#EventArgument").val(
          $(this).attr("data-pdsa-val"));

        $("form").submit();
    });
});