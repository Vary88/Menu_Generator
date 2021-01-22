$(document).ready(function () {
    var $btnAddCategoryFilter = $('#btnAddCategoryFilter');
    $btnAddCategoryFilter.on('click', function () {
        var $categoryTemplate = $('[name=categoryTemplate]:hidden');
        var $categoryContainer = $('#categoryContainer');
        $categoryTemplate.clone().show().appendTo($categoryContainer);
    });
    var $menuForm = $('#menuForm');
    $menuForm.submit(submitHandler);
})

function removeCategoryFilter(sender) {
    $(sender).parents('[name=categoryTemplate]').remove();
}

function selectedFilterChanged(sender) {
    $(sender).next('input:hidden').val(sender.value);
}

function submitHandler() {
    var $categoryContainer = $('#categoryContainer');
    $categoryContainer.find('[name=categoryTemplate]').each(function (index) {
        var $currentHiddens = $(this).find('input:hidden');
        $currentHiddens.each(function () {
            var newName = $(this).attr('name').replace('index', index);
            $(this).attr('name', newName);
        })
    });
}
