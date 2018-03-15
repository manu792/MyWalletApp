function submitBtn(item) {
    var baseUrl = $('base').attr('href');

    var ev = event;
    if (ev.target.innerHTML === 'Eliminar') {
        ev.target.innerHTML = 'Agregar';
    } else {
        ev.target.innerHTML = 'Eliminar';
    }
    $.ajax({
        url: baseUrl + '/proyeccion/delete/' + item.id,
        type: 'POST',
        success: function (result) {
            console.log(result);

            // update gastos proximo mes chart
            options.data[0].dataPoints = result.Proyecciones;
            $("#chartContainer").CanvasJSChart().render();

            // update savings chart
            if (ev.target.innerHTML === 'Agregar') {
                options2.data[0].dataPoints.push(item);
                $("#totalAhorros").text(parseFloat($("#totalAhorros").text()) + item.y);
                $("#totalGastos").text(parseFloat($("#totalGastos").text()) - item.y);
            } else {
                options2.data[0].dataPoints.splice(options2.data[0].dataPoints.indexOf(item), 1);
                $("#totalAhorros").text(parseFloat($("#totalAhorros").text()) - item.y);
                $("#totalGastos").text(parseFloat($("#totalGastos").text()) + item.y);
            }
            $("#chartContainer2").CanvasJSChart().render();

        }, error: function () {
            alert('Hubo un problema al tratar de obtener los servicios.');
        }
    });
}