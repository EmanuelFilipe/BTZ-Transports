$(document).ready(function () {
	$('#cpf').keyup(function () {
		var valor = getOnlyNumber($('#cpf').val());
		// limpa máscara se o campo estiver vazio
		if (valor.length == 0)
			$('#cpf').unmask();
	});

	$('#cpf').blur(function () {
		debugger
		$('#cpf').unmask();

		var valor = getOnlyNumber($(this).val());

		if (valor === "")
			$('#cpf').val('');
		else if (/^\d{11}$/.test(valor))
			$('#cpf').mask('999.999.999-99');
	});

	function getOnlyNumber(value) {
		return value.replace(/\D/g, '');
	};
});