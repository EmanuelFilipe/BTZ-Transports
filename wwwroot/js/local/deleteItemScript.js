var pathToDelete;

$(".deleteItem").click(function () {
	debugger
	pathToDelete = $(this).data('path');
});

$("#btnContinueToDelete").click(function () {
	debugger
	window.location = pathToDelete;
});