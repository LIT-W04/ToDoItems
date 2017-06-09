$(function() {
    $("#category-filter").on('change', function() {
        //$("#filter-form").submit();
        var categoryId = $("#category-filter option:selected").val();
        $("table tr:gt(0)").each(function() {
            var currentRow = $(this);
            var currentCategoryId = currentRow.data('category-id');
            if (categoryId == currentCategoryId || categoryId == 0) {
                currentRow.show();
            } else {
                currentRow.hide();
            }
        });
    });
});