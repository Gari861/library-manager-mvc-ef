$("#seleccionImg").change(function () {
    var fileName = this.files[0].name;
    var fileSize = this.files[0].size;
    var esArchValido = 0;

    if (fileSize > 3000000) {
        alert('El archivo no debe superar los 3MB');
        this.value = '';
        esArchValido = 1;
    } else {
        // Recuperamos la extensión del archivo
        var ext = fileName.split('.').pop();

        // Convertimos en minúsculas
        ext = ext.toLowerCase();

        switch (ext) {
            case 'jpg':
            case 'jpeg':
            case 'png':
                break;
            default:
                alert('El archivo no tiene la extensión adecuada');
                this.value = ''; // Resetear el valor
                esArchValido = 1;
        }
    }

    // Si el archivo es válido, llamamos a readURL para la vista previa
    if (esArchValido == 0) {
        readURL(this);
    }
});

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $("#imagen").attr("src", e.target.result).css("display", "block");
        }
        reader.readAsDataURL(input.files[0]); // Leer el archivo en string base 64
    }
}
