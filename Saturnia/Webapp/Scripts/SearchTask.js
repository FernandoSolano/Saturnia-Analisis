
$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
    $('#MainContent_txtFrom').datepicker({ dateFormat: 'dd-mm-yy' });
    $('#MainContent_txtTo').datepicker({ dateFormat: 'dd-mm-yy' });
    $('#btnPdf').click(function () {
        $('#reportPlace').printThis();
    });
});

/**
 * Esta funcion hace visible o invisible un area en base a un checkbox recibido y al nombre del area. Este método
 * debe ejecutarse al darle click a un checkbox que esté enlazado a este método.
 * @param {checkBox} checkBox es el checkbox que llama al método.
 * @param {string} entity es el nombre de la entidad sobre la que se trabaja.
 */
function FadeForm(checkBox, entity) {
    //Si el checkbox está seleccionado
    if (checkBox.checked) {
        FadeInElement('#area' + entity); //Mostramos el area de la entidad deseada.
        goTo('before' + entity, 500);
    } else {
        //Si no esta seleccionado
        FadeOutElement('#area' + entity); //Oculta el area de la entidad
        FadeOutElement('#reselect' + entity); //Oculta la opción de cambiar la entidad si esta fuera visible.
        document.getElementById('MainContent_hdn' + entity).value = 0; //Eliminar el valor del hidden.
    }
}

/**
 * Método que hace visible un elemento por id, de forma lenta y gradual.
 * @param {String} element es el id del elemento a mostrar.
 */
function FadeInElement(element) {
    $(element).fadeIn('slow');
}

/**
 * Método que oculta un elemento por id, de forma lenta y gradual.
 * @param {String} element es el id del elemento a ocultar.
 */
function FadeOutElement(element) {
    $(element).fadeOut('slow');
}

/**
 * Este metodo recibe el nombre de  la entidad y el id de dicha entidad, para guardarlo en el
 * hidden field correspondiente.
 * @param {String} entity Nombre de la entidad para buscar su hidden correspondiene.
 * @param {Integer} id Id de la entidad a guardar en el hidden.
 */
function FillHidden(entity, id, filteredBy) {
    document.getElementById('MainContent_hdn' + entity).value = id;
    FadeOutElement('#area' + entity);
    document.getElementById("labelReselect" + entity).innerHTML = filteredBy;
    FadeInElement('#reselect' + entity);
}

/**
 * Método para desplazar la pantalla a un lugar en específico con retardo de recibido.
 * @param {String} place es el id del lugar al que hay que moverse.
 * @param {Integer} time es la cantidad de retardo para el desplazamiento (1 segundo = 1000);
 */
function goTo(place, time) {
    setTimeout(function () { window.location.hash = place; }, time);
}

/**
 * Metodo que muestra nuevamente el area de un filtro y oculta el botón "cambiar entidad filtrada".
 * @param {String} filter es el nombre de la entidad del filtro a mostrar de nuevo y el nombre del "reselect" a ocultar.
 */
function reselectFilter(filter) {
    FadeOutElement('#reselect' + filter);
    FadeInElement('#area' + filter);
}