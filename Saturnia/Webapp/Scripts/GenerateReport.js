﻿/**
* Funcion "Document ready"
*/
$(document).ready(function () {
    //Ocultamos el area de reporte
    $('#reportPlace').hide();
    //Ocultamos el area de los botones de acciones con reporte
    $('#reportActions').hide();
    $('#btnPdf').hide();
    $('#btnExcel').hide();
    //Permitimos el "tooltip" para efectos visuales.
    $('[data-toggle="tooltip"]').tooltip();
    //Permitimos los calendarios
    $('#MainContent_txtFrom').datepicker({ dateFormat: 'dd-mm-yy' });
    $('#MainContent_txtTo').datepicker({ dateFormat: 'dd-mm-yy' });
});

/**
 * Método que cambia el valor de un hidden según se desee o no filtrar por una entidad
 * @param {CheckBox} checkBox Es el checkbox que llamó al método.
 * @param {string} entity Es el nombre de la entidad asociada al hidden para alterar.
 */
function ActivateFilter(checkBox, entity) {
    //Si el checkbox está seleccionado asignamos 1 al hiden, sino se asigna 0.
    document.getElementById('MainContent_hdn' + entity).value = (checkBox.checked? 1 : 0);
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
 * Función que muestra los botones de exportar en un formato predeterminado.
 */
function FadeInExportFormat() {
    FadeInElement('#btnPdf');
    FadeInElement('#btnExcel');
}

/**
 * Función que muestra tanto el lugar del reporte como los botones de acción sobre el reporte.
 */
function FadeInReportAndReportActions() {
    FadeInElement('#reportPlace');
    FadeInElement('#reportActions');
}

/**
 * Función que oculta los botones de exportar en un formato predeterminado.
 */
function FadeOutExportFormat() {
    FadeOutElement('#btnPdf');
    FadeOutElement('#btnExcel');
}

/**
 * Función que oculta tanto el lugar del reporte como los botones de acción sobre el reporte.
 */
function FadeOutReportAndReportActions() {
    FadeOutElement('#reportPlace');
    FadeOutElement('#reportActions');
}

/**
 * Función que oculta el lugar del reporte, los botones de exportar, los botones de acción y muestra la pantalla para generar reporte.
 */
function NewReport() {
    FadeOutExportFormat();
    FadeOutReportAndReportActions();
    FadeInElement('#formGenerateReport');
}