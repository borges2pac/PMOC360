// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

///Função que valida os campos do formulário
function GetValoresCamposTela(formulario = "myForm") {
    debugger;
    const formValores = document.getElementById(formulario);
    const jsonObject = {};

    //Obtem todos os campos do formulario com o atributo id
    const fields = formValores.querySelectorAll('[id]');

    for (var i = 0; i < fields.length; i++)
    {
        const field = fields[i];
        const id = field.id;
        const value = field.value;

        //Verifica se o campo é uma caixa de seleção ou botão de rádio selecionado
        if (field.type == 'checkbox' && field.checked) {
            if (field.name in jsonObject) {
                if (!Array.isArray(jsonObject[field.name])) {
                    jsonObject[field.name] = [jsonObject[field.name]];
                }
                jsonObject[field.name].push(paseInt(value));
            } else {
                jsonObject[field.name] = [paseInt(value)];
            }
        } else if (field.type == 'radio' && field.checked) {
            jsonObject[field.name] = paseInt(value); //Converte o valor para número;
        } else if (field.type == 'radio' && field.value !== "") {
            jsonObject[id] = value;
        } else {
            jsonObject[id] = value;
        }
    }

    return jsonObject;
}
