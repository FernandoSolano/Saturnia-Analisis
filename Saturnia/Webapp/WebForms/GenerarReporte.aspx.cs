using Core.Domain;
using Core.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webapp.WebForms
{
    public partial class GenerarReporte : System.Web.UI.Page
    {
        private TaskBusiness taskBusiness;
        
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["userRole"] != null)
            {
                if ((int)Session["userRole"] == 1)
                {
                    this.MasterPageFile = "~/Site.master";
                }
                else if ((int)Session["userRole"] == 2)
                {
                    this.MasterPageFile = "~/SiteCollaborator.master";
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] == null)
            {
                Response.Redirect("~/WebForms/IniciarSesion.aspx");
            }
            else
            {
                this.lblUserName.Text = Session["userName"].ToString();
                //this.
                //= new TaskBusiness();
            }
        }

        /// <summary>
        /// Método que se ejecuta para generar un reporte.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            Task generate;
            List<Task> report;
            DateTime dateFrom = DateTime.Today, dateTo = DateTime.Today;
            int project, user, category;
            String textDateFrom, textDateTo;

            textDateFrom = (this.txtFrom.Text);
            textDateTo = (this.txtTo.Text);
            project = Int16.Parse(this.hdnProject.Value);
            user = Int16.Parse(this.hdnUser.Value);
            category = Int16.Parse(this.hdnCategory.Value);

            if( (project == 0) && (user == 0) && (category == 0) )
            {
                project = 1;
                user = 1;
                category = 1;
            }
            try { 
                dateFrom = DateTime.Parse(
                    (textDateFrom != "") ? textDateFrom : "1801-08-05"
                );
                dateTo = DateTime.Parse(
                    (textDateTo != "") ? textDateTo : "1801-08-05"
                );
            }
            catch {
                textDateFrom = "";
                textDateTo = "";
            }

            this.reportTable.Visible = false;
            this.lblDateMessage.Visible = false;

            if ( (textDateFrom == "") || (textDateTo == "") ) {
                this.lblDateMessage.Visible = true;
            } else
            {
                //Con la primer linea indicamos que no se debe filtrar por id de colaborador, en terminos sencillos ese 0 dice
                //que somos administradores, si fuera 1 el id de colaborador sería tomado para mostrar únicamente las tareas de
                //ese colaborador.
                generate = new Task { Id = 0 };
                generate.Project.Id = project;
                generate.Collaborator.Id = user;
                generate.Category.Id = category;
                //Luego las fechas.
                generate.Date = dateFrom;
                //Con esto nos ahorramos una conversión en data en algunos casos, en otros se obtiene de la descripcion del
                //proyecto que conforma la tarea.
                generate.Project.Description = (
                    dateFrom == dateTo ? ("Same") : (dateTo.ToString())
                );

                report = this.taskBusiness.GenerateReport(generate);

                FillReportTable(report);
            }
        }

        /// <summary>
        /// Método que nos devuelve a la página de inicio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("./IndexAdmin.aspx");
        }

        /// <summary>
        /// Método que en base a los hdnENTITY llenará la tabla de reporte o no.
        /// </summary>
        /// <param name="report">Lista de tareas con las que se hará el reporte.</param>
        private void FillReportTable(List<Task> report)
        {
            if ((this.hdnProject.Value != "0") && (this.hdnCategory.Value != "0") && (this.hdnUser.Value != "0"))
            {
                FillReportTableByThreEntities(report, 'p', 'c', 'u');
            }
            else if ((this.hdnProject.Value != "0") && (this.hdnCategory.Value != "0"))
            {
                FillReportTableByTwoEntities(report, 'p', 'c');
            }
            else if ((this.hdnProject.Value != "0") && (this.hdnUser.Value != "0"))
            {
                FillReportTableByTwoEntities(report, 'p', 'u');
            }
            else if ((this.hdnUser.Value != "0") && (this.hdnCategory.Value != "0"))
            {
                FillReportTableByTwoEntities(report, 'u', 'c');
            }
            else if ((this.hdnProject.Value != "0"))
            {
                FillReportTableBySingleEntity(report, 'p');
            }
            else if ((this.hdnCategory.Value != "0"))
            {
                FillReportTableBySingleEntity(report, 'c');
            }
            else if ((this.hdnUser.Value != "0"))
            {
                FillReportTableBySingleEntity(report, 'u');
            }
            else
            {
                FillReportTableByThreEntities(report, 'p', 'c', 'u');
            }
            this.reportTable.Visible = true;
        }

        /// <summary>
        /// Método que llena la tabla para un reporte de 3 entidades.
        /// </summary>
        /// <param name="report"></param>
        /// <param name="majorEntity"></param>
        /// <param name="middleEntity"></param>
        /// <param name="minorEntity"></param>
        private void FillReportTableByThreEntities(List<Task> report, char majorEntity, char middleEntity, char minorEntity)
        {
            TableRow tempRow;
            TableCell tempCell;
            String currentMajorEntity = "", currentMiddleEntity = "", currentMinorEntity = "", rowMajorEntity = "", rowMiddleEntity = "", rowMinorEntity = "";
            float regular, extra, regularTotal = 0, extraTotal = 0;
            bool firstMajor = true, firstMiddle = true, firstMinor = true, extraCell = false, middleExtraCell = false;

            currentMajorEntity = GetEntityName(report[0], majorEntity);
            currentMiddleEntity = GetEntityName(report[0], middleEntity);
            currentMinorEntity = GetEntityName(report[0], minorEntity);
            //Llamada a método creado, este se encuentra más abajo para efectos de querer "checkearlo"
            this.reportTable.Rows.Add(BuiltTableHeaderRow(majorEntity, middleEntity, minorEntity));
            //Recorremos la lista.
            foreach (Task task in report)
            {
                //Pasamos la tarea actual y obtenemos el nombre necesario según la entidad con la que se trabaje.
                rowMajorEntity = GetEntityName(task, majorEntity);
                rowMiddleEntity = GetEntityName(task, middleEntity);
                rowMinorEntity = GetEntityName(task, minorEntity);
                //Si no es la primera vez de una entidad mayor.
                if (!firstMajor)
                {
                    //Si la mayor actual es distinta a la mayor de la tarae actual
                    if (currentMajorEntity != rowMajorEntity)
                    {
                        //Re asignamos el valor de actual entidad mayor.
                        currentMajorEntity = rowMajorEntity;
                        //Método creado, más abajo se podrá encontrar, nos devuelve un "row" con el total dedicado dentro de
                        //la entidad mayor, para efectos del reporte.
                        tempRow = this.TotalHoursDedicatedRow(regularTotal, extraTotal, 3);
                        this.reportTable.Rows.Add(tempRow);
                        //Reiniciamos los totales de horas.
                        regularTotal = 0;
                        extraTotal = 0;
                        //Ahora este mayor es el primero.
                        firstMajor = true;
                        //No requeriremos una celda extra vacía para evitar repetir el nombre de la entidad mayor..
                        extraCell = false;
                    }
                }

                if (!firstMiddle)
                {
                    //Se consulta si es primer entidad del medio para los casos donde pese a ser de distintas entidades mayores
                    //la entidad del medio sea la misma, así forzamos a que agregue la del medio pese a no ser "distinta".
                    if ((currentMiddleEntity != rowMiddleEntity) || (firstMajor))
                    {
                        //Asignamos a la actual entidad menor el valor de la entidad menor de la tarea actual.
                        currentMiddleEntity = rowMiddleEntity;
                        firstMiddle = true;
                        //No requeriremos una celda extra vacía para evitar repetir el nombre de la entidad mayor..
                        middleExtraCell = false;
                    }
                }

                if (!firstMinor)
                {
                    //Se consulta si es primer entidad mayor para los casos donde pese a ser de distintas entidades mayores
                    //la entidad menor sea la misma, así forzamos a que agregue la menor pese a no ser "distinta".
                    if ((currentMinorEntity != rowMinorEntity) || (firstMiddle))
                    {
                        //Asignamos a la actual entidad menor el valor de la entidad menor de la tarea actual.
                        currentMinorEntity = rowMinorEntity;
                        firstMinor = true;
                    }
                }

                tempRow = new TableRow();

                //Solo si es la primera vez de  esta entidad mayor, negamos que sea primera para siguiente giro y no solicitamos
                //celda en blanco.
                //De lo contrario, solicitamos una celda en blanco en lugar de repetir el nombre de la entidad mayor.
                if (firstMajor)
                {
                    firstMajor = false;
                    extraCell = false;
                }
                else
                {
                    extraCell = true;
                }
                //Solo si es la primera vez de esta entidad del medio, negamos que sea primera para siguiente giro y no solicitamos
                //celda en blanco.
                //De lo contrario, solicitamos una celda en blanco en lugar de repetir el nombre de la entidad del medio.
                if (firstMiddle)
                {
                    firstMiddle = false;
                    middleExtraCell = false;
                }
                else
                {
                    middleExtraCell = true;
                }
                //Solo si es la primera vez de esta entidad menor, agregamos celdas con: Su nombre, su cantidad de horas regulares,
                //su cantidad de horas extra y su total de horas.
                if (firstMinor)
                {
                    firstMinor = false;
                    //Si se pide celda extra, se agrega primero una celda vacía en lugar de repetir el nombre de la entidad mayor.
                    //Caso contrario, agregamos una celda con el nombre actual de la entidad.
                    if (extraCell)
                    {
                        tempCell = MakeMeATableCell("-", "", 0);
                        tempRow.Cells.Add(tempCell);
                    } else
                    {
                        tempCell = MakeMeATableCell("results", currentMajorEntity, 0);
                        tempRow.Cells.Add(tempCell);
                    }
                    //Si se pide celda extra, se agrega primero una celda vacía en lugar de repetir el nombre de la entidad mayor.
                    //Caso contrario, agregamos una celda con el nombre actual de la entidad.
                    if (middleExtraCell)
                    {
                        tempCell = MakeMeATableCell("-", "", 0);
                        tempRow.Cells.Add(tempCell);
                    } else
                    {
                        tempCell = MakeMeATableCell("results", currentMiddleEntity, 0);
                        tempRow.Cells.Add(tempCell);
                    }
                    //Celda con nombre de entidad menor.
                    tempCell = MakeMeATableCell("results", currentMinorEntity, 0);
                    tempRow.Cells.Add(tempCell);
                    //Horas regulares de la entidad menor por medio de un método creado, este se encuentra más abajo.
                    regular = SumHoursThreeEntities(report, currentMajorEntity, currentMiddleEntity, currentMinorEntity, majorEntity, middleEntity, minorEntity, false);
                    regularTotal += regular;
                    tempCell = MakeMeATableCell("results", (regular + " regulares"), 0);
                    tempRow.Cells.Add(tempCell);
                    //Horas extra de la entidad menor por medio de un método creado, este se encuentra más abajo.
                    extra = SumHoursThreeEntities(report, currentMajorEntity, currentMiddleEntity, currentMinorEntity, majorEntity, middleEntity, minorEntity, true);
                    extraTotal += extra;
                    tempCell = MakeMeATableCell("results", (extra + " extra"), 0);
                    tempRow.Cells.Add(tempCell);
                    //Total de horas para la entidad menor.
                    tempCell = MakeMeATableCell("results", ((extra + regular) + " horas"), 0);
                    tempRow.Cells.Add(tempCell);
                }
                //Agregamos la fila creada en el reporte.
                this.reportTable.Rows.Add(tempRow);

            }
            //Agregamos nuevamente el "row" con los totales para entidad mayor, se hace fuera del ciclo "foreach" dado que la
            //última vez que debería agregarse, no lo hace por finalizado el ciclo.
            tempRow = new TableRow();
            tempRow = this.TotalHoursDedicatedRow(regularTotal, extraTotal, 3);

            this.reportTable.Rows.Add(tempRow);
        }

        /// <summary>
        /// Método que llena la tabla para un reporte de 2 entidades.
        /// </summary>
        /// <param name="report">Es la lista de tareas de la que generamos el reporte.</param>
        /// <param name="majorEntity">Es la letra código de la entidad mayor que limitará las entidades menores repetidas.</param>
        /// <param name="minorEntity">Es la letra código de la entidad que aporta las horas al reporte.</param>
        private void FillReportTableByTwoEntities(List<Task> report, char majorEntity, char minorEntity)
        {
            TableRow tempRow;
            TableCell tempCell;
            String currentMajorEntity = "", currentMinorEntity = "", rowMajorEntity = "", rowMinorEntity = "";
            float regular, extra, regularTotal = 0, extraTotal = 0;
            bool firstMajor = true, firstMinor = true, extraCell = false;

            currentMajorEntity = GetEntityName(report[0], majorEntity);
            currentMinorEntity = GetEntityName(report[0], minorEntity);
            //Llamada a método creado, este se encuentra más abajo para efectos de querer "checkearlo"
            this.reportTable.Rows.Add(BuiltTableHeaderRow(majorEntity, '-', minorEntity));
            //Recorremos la lista.
            foreach (Task task in report)
            {
                //Pasamos la tarea actual y obtenemos el nombre necesario según la entidad con la que se trabaje.
                rowMajorEntity = GetEntityName(task, majorEntity);
                rowMinorEntity = GetEntityName(task, minorEntity);
                //Si no es la primera vez de una entidad mayor.
                if (!firstMajor)
                {
                    //Si la mayor actual es distinta a la mayor de la tarae actual
                    if (currentMajorEntity != rowMajorEntity)
                    {
                        //Re asignamos el valor de actual entidad mayor.
                        currentMajorEntity = rowMajorEntity;
                        //Método creado, más abajo se podrá encontrar, nos devuelve un "row" con el total dedicado dentro de
                        //la entidad mayor, para efectos del reporte.
                        tempRow = this.TotalHoursDedicatedRow(regularTotal, extraTotal, 2);
                        this.reportTable.Rows.Add(tempRow);
                        //Reiniciamos los totales de horas.
                        regularTotal = 0;
                        extraTotal = 0;
                        //Ahora este mayor es el primero.
                        firstMajor = true;
                        //No requeriremos una celda extra vacía para evitar repetir el nombre de la entidad mayor..
                        extraCell = false;
                    }
                }

                if (!firstMinor)
                {
                    //Se consulta si es primer entidad mayor para los casos donde pese a ser de distintas entidades mayores
                    //la entidad menor sea la misma, así forzamos a que agregue la menor pese a no ser "distinta".
                    if ((currentMinorEntity != rowMinorEntity) || (firstMajor))
                    {
                        //Asignamos a la actual entidad menor el valor de la entidad menor de la tarea actual.
                        currentMinorEntity = rowMinorEntity;
                        firstMinor = true;
                    }
                }

                tempRow = new TableRow();

                //Solo si es la primera vez de esta entidad mayor, negamos primera vez para siguiente vuelta de ciclo y no pedimos
                //celda extra.
                //De lo contrario, solicitamos una celda en blanco en lugar de repetir el nombre de la entidad mayor.
                if (firstMajor)
                {
                    firstMajor = false;
                    extraCell = false;
                }
                else
                {
                    extraCell = true;
                }
                //Solo si es la primera vez de esta entidad menor, agregamos celdas con: Su nombre, su cantidad de horas regulares,
                //su cantidad de horas extra y su total de horas.
                if (firstMinor)
                {
                    firstMinor = false;
                    //Si se pide celda extra, se agrega primero una celda vacía en lugar de repetir el nombre de la entidad mayor.
                    //Si no se pide extra, se agrega una con el titulo de la entidad mayor.
                    if (extraCell)
                    {
                        tempCell = MakeMeATableCell("-", "", 0);
                        tempRow.Cells.Add(tempCell);
                    } else
                    {

                        tempCell = MakeMeATableCell("results", currentMajorEntity, 0);
                        tempRow.Cells.Add(tempCell);
                    }
                    //Celda con nombre de entidad menor.
                    tempCell = MakeMeATableCell("results", currentMinorEntity, 0);
                    tempRow.Cells.Add(tempCell);
                    //Horas regulares de la entidad menor por medio de un método creado, este se encuentra más abajo.
                    regular = SumHoursTwoEntities(report, currentMajorEntity, currentMinorEntity, minorEntity, majorEntity, false);
                    regularTotal += regular;
                    tempCell = MakeMeATableCell("results", (regular + " regulares"), 0);
                    tempRow.Cells.Add(tempCell);
                    //Horas extra de la entidad menor por medio de un método creado, este se encuentra más abajo.
                    extra = SumHoursTwoEntities(report, currentMajorEntity, currentMinorEntity, minorEntity, majorEntity, true);
                    extraTotal += extra;
                    tempCell = MakeMeATableCell("results", (extra + " extra"), 0);
                    tempRow.Cells.Add(tempCell);
                    //Total de horas para la entidad menor.
                    tempCell = MakeMeATableCell("results", ((extra + regular) + " horas"), 0);
                    tempRow.Cells.Add(tempCell);
                }
                //Agregamos la fila creada en el reporte.
                this.reportTable.Rows.Add(tempRow);

            }
            //Agregamos nuevamente el "row" con los totales para entidad mayor, se hace fuera del ciclo "foreach" dado que la
            //última vez que debería agregarse, no lo hace por finalizado el ciclo.
            tempRow = new TableRow();
            tempRow = this.TotalHoursDedicatedRow(regularTotal, extraTotal, 2);

            this.reportTable.Rows.Add(tempRow);
        }

        /// <summary>
        /// Método que llena la tabla para un reporte de una sola entidad.
        /// </summary>
        /// <param name="report">Es la lista de tareas de la que generamos el reporte.</param>
        /// <param name="minorEntity">Es la letra código de la entidad con la que trabajaremos.</param>
        private void FillReportTableBySingleEntity(List<Task> report, char minorEntity)
        {
            TableRow tempRow;
            TableCell tempCell;
            String currentEntity = "", rowEntity = "";
            float regular, extra, totalRegular = 0, totalExtra = 0;
            bool firstTime = true;

            currentEntity = GetEntityName(report[0], minorEntity);

            this.reportTable.Rows.Add(BuiltTableHeaderRow('-', '-', minorEntity));

            foreach (Task task in report)
            {
                rowEntity = GetEntityName(task, minorEntity);

                if (!firstTime)
                {
                    if (currentEntity != rowEntity)
                    {
                        currentEntity = rowEntity;
                        firstTime = true;
                    }
                }

                if (firstTime)
                {
                    firstTime = false;
                    tempRow = new TableRow();

                    tempCell = MakeMeATableCell("results", currentEntity, 0);
                    tempRow.Cells.Add(tempCell);
                    //Horas regulares
                    regular = SumHoursSingleEntity(report, currentEntity, minorEntity, false);
                    tempCell = MakeMeATableCell("results", (regular + " regulares"), 0);
                    tempRow.Cells.Add(tempCell);
                    //Horas extra
                    extra = SumHoursSingleEntity(report, currentEntity, minorEntity, true);
                    tempCell = MakeMeATableCell("results", (extra + " extra"), 0);
                    tempRow.Cells.Add(tempCell);
                    //Horas total
                    tempCell = MakeMeATableCell("results", ((regular + extra) + " horas"), 0);
                    totalExtra += extra;
                    totalRegular += regular;
                    tempRow.Cells.Add(tempCell);

                    this.reportTable.Rows.Add(tempRow);
                }
            }
            tempRow = new TableRow();
            tempRow = TotalHoursDedicatedRow(totalRegular, totalExtra, 1);
            this.reportTable.Rows.Add(tempRow);
        }

        /// <summary>
        /// Método que suma la totalidad de horas de una entidad para un reporte.
        /// </summary>
        /// <param name="report">Lista de tareas que será nuestro reporte.</param>
        /// <param name="entityName">El nombre de la entidad a calcular su total de horas.</param>
        /// <param name="entity">Letra código de la entidad, para buscar en una tarea específica de la lista.</param>
        /// <param name="extra">Indica si se retornara la suma de horas regulares o las horas extra.</param>
        /// <returns>La totalidad de horas de la entidad sumadas.</returns>
        private float SumHoursSingleEntity(List<Task> report, string entityName, char entity, bool extra)
        {
            float hours = 0;
            String currentEntity = "";

            foreach (Task task in report)
            {
                currentEntity = GetEntityName(task, entity);

                if ((extra == task.ExtraHours) && (entityName == currentEntity))
                {
                    hours += task.Hours;
                }
            }

            return hours;
        }

        /// <summary>
        /// Método que devuelve la totalidad de horas regulares o extra de una entidad menor que está dentro de una entidad mayor.
        /// </summary>
        /// <param name="report">Lista de tareas que será nuestro reporte.</param>
        /// <param name="majorEntityName">Tan solo evita que se sumen valores de otro campo del reporte.</param>
        /// <param name="minorEntityName">Es de quien buscaremos horas dentro de la entidad mayor.</param>
        /// <param name="minorEntity">Letra código de la entidad menor, para buscar en una tarea específica de la lista.</param>
        /// <param name="majorEntity">Letra código de la entidad mayor, para buscar en una tarea específica de la lista.</param>
        /// <param name="extra">Indica si se retornara la suma de horas regulares o las horas extra.</param>
        /// <returns>La totalidad de horas de la entidad dentro de la entidad mayor.</returns>
        private float SumHoursTwoEntities(List<Task> report, string majorEntityName, string minorEntityName, char minorEntity, char majorEntity, bool extra)
        {
            float hours = 0;
            String currentMajorEntity = "", currentMinorEntity = "";

            foreach (Task task in report)
            {
                currentMajorEntity = GetEntityName(task, majorEntity);
                currentMinorEntity = GetEntityName(task, minorEntity);

                if ((extra == task.ExtraHours) && (currentMajorEntity == majorEntityName) && (currentMinorEntity == minorEntityName))
                {
                    hours += task.Hours;
                }
            }

            return hours;
        }

        /// <summary>
        /// Método que devuelve la totalidad de horas regulares o extra de una entidad menor que está dentro de una entidad media y una mayor.
        /// </summary>
        /// <param name="report"></param>
        /// <param name="majorEntityName">Tan solo evita que se sumen valores de otro campo del reporte.</param>
        /// <param name="middleEntityName"></param>
        /// <param name="minorEntityName">Es de quien buscaremos horas dentro de la entidad del medio.</param>
        /// <param name="majorEntity">Letra código de la entidad mayor, para buscar en una tarea específica de la lista.</param>
        /// <param name="middleEntity"></param>
        /// <param name="minorEntity">Letra código de la entidad menor, para buscar en una tarea específica de la lista.</param>
        /// <param name="extra">Indica si se retornara la suma de horas regulares o las horas extra.</param>
        /// <returns>La totalidad de horas de la entidad dentro de la entidad del medio que pertenece a una mayor.</returns>
        private float SumHoursThreeEntities(List<Task> report, string majorEntityName, string middleEntityName, string minorEntityName, char majorEntity, char middleEntity, char minorEntity, bool extra)
        {
            float hours = 0;
            String currentMajorEntity = "", currentMiddleEntity = "", currentMinorEntity = "";

            foreach (Task task in report)
            {
                currentMajorEntity = GetEntityName(task, majorEntity);
                currentMiddleEntity = GetEntityName(task, middleEntity);
                currentMinorEntity = GetEntityName(task, minorEntity);

                if ((extra == task.ExtraHours) && (currentMajorEntity == majorEntityName) && (currentMiddleEntity == middleEntityName) && (currentMinorEntity == minorEntityName))
                {
                    hours += task.Hours;
                }
            }

            return hours;
        }

        /// <summary>
        /// Método que arma un "TableRow" indicando el tortal de horas dedicadas de una entidad mayor.
        /// La primer columna tendrá un mensaje indicando "Total de horas" y el colspan de esta columna es el alterado.
        /// Las siguientes columnas serás el total de horas regulares, luego las horas extra y finalmente la suma de estas.
        /// </summary>
        /// <param name="totalRegular">Total de horas regulares.</param>
        /// <param name="totalExtra">Total de horas extra.</param>
        /// <param name="span">Grosor de columnas de la columna mensaje.</param>
        /// <returns>Un TableRow armado y listo para ser insertado en una tabla.</returns>
        private TableRow TotalHoursDedicatedRow(float totalRegular, float totalExtra, byte columnSpan)
        {
            TableRow tempRow = new TableRow();
            TableCell tempCell;

            tempCell = MakeMeATableCell("total", "Total horas invertidas:", columnSpan);
            tempRow.Cells.Add(tempCell);

            tempCell = MakeMeATableCell("total", (totalRegular + " Regulares"), 0);
            tempRow.Cells.Add(tempCell);

            tempCell = MakeMeATableCell("total", (totalExtra + " Extra"), 0);
            tempRow.Cells.Add(tempCell);

            tempCell = MakeMeATableCell("total", (totalRegular + totalExtra + " horas"), 0);
            tempRow.Cells.Add(tempCell);

            return tempRow;
        }

        /// <summary>
        /// Método que devuelve el nombre requerido de una entidad de una tarea.
        /// </summary>
        /// <param name="task">La tarea de la cual obtendremos el nombre.</param>
        /// <param name="entity">La entidad deseada de la tarea.</param>
        /// <returns></returns>
        private String GetEntityName(Task task, char entity)
        {
            switch (entity)
            {
                case 'p':
                    return task.Project.Name;
                case 'c':
                    return task.Category.Name;
                case 'u':
                    return task.Collaborator.FirstName + " " + task.Collaborator.LastName;
                default:
                    return "";
            }
        }

        /// <summary>
        /// Método que construye la cabecera de la tabla de reporte.
        /// </summary>
        /// <param name="MajorEntity">Letra codigo de la entidad mayor, si es - se omite.</param>
        /// <param name="MiddleEntity">Letra codigo de la entidad del medio, si es - se omite.</param>
        /// <param name="MinorEntity">Letra codigo de la entidad menor, si es - se omite.</param>
        /// <returns>Un row de cabecera de asp table.</returns>
        private TableHeaderRow BuiltTableHeaderRow(char MajorEntity, char MiddleEntity, char MinorEntity)
        {
            TableHeaderRow tempHeader = new TableHeaderRow();
            TableHeaderCell tempHeaderCell;

            if (MajorEntity != '-')
            {
                tempHeaderCell = MakeMeATableHeaderCell("results", PassCharEntityToName(MajorEntity), 0);
                tempHeader.Cells.Add(tempHeaderCell);
            }

            if (MiddleEntity != '-')
            {
                tempHeaderCell = MakeMeATableHeaderCell("results", PassCharEntityToName(MiddleEntity), 0);
                tempHeader.Cells.Add(tempHeaderCell);
            }

            if (MinorEntity != '-')
            {
                tempHeaderCell = MakeMeATableHeaderCell("results", PassCharEntityToName(MinorEntity), 0);
                tempHeader.Cells.Add(tempHeaderCell);
            }

            tempHeaderCell = MakeMeATableHeaderCell("results","Horas",2);
            tempHeader.Cells.Add(tempHeaderCell);

            tempHeaderCell = MakeMeATableHeaderCell("results", "Total", 0);
            tempHeader.Cells.Add(tempHeaderCell);

            return tempHeader;
        }

        /// <summary>
        /// Sub método que devuelve el nombre correspondiente a una entidad en base a un caracter.
        /// </summary>
        /// <param name="entity">Caracter a convertir.</param>
        /// <returns>Nombre de la entidad.</returns>
        private string PassCharEntityToName(char entity)
        {
            switch (entity)
            {
                case 'p':
                    return "Proyecto";
                case 'c':
                    return "Categoría";
                case 'u':
                    return "Colaborador";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Método que fabrica un "TableCell", debido a que se hace mucho en esta clase
        /// se creó este método para ahorrar lineas de código.
        /// </summary>
        /// <param name="cssClass">Nommbre del class de css para la celda.</param>
        /// <param name="text">Texto que contendrá la celda, puede ser código html dentro de un string.</param>
        /// <param name="columnSpan">Columnas que abarcará la celda.</param>
        /// <returns>La celda deseada según los parametros recibidos.</returns>
        private TableCell MakeMeATableCell(string cssClass, string text, byte columnSpan)
        {
            TableCell tempCell = new TableCell
            {
                Text = text
            };

            if (cssClass != "-")
            {
                tempCell.CssClass = cssClass;
            }

            if (columnSpan != 0)
            {
                tempCell.ColumnSpan = columnSpan;
            }

            return tempCell;
        }

        /// <summary>
        /// Método que fabrica un "TableHeaderCell", debido a que se hace mucho en esta clase
        /// se creó este método para ahorrar lineas de código.
        /// </summary>
        /// <param name="cssClass">Nommbre del class de css para la celda.</param>
        /// <param name="text">Texto que contendrá la celda, puede ser código html dentro de un string.</param>
        /// <param name="columnSpan">Columnas que abarcará la celda.</param>
        /// <returns>La celda deseada según los parametros recibidos.</returns>
        private TableHeaderCell MakeMeATableHeaderCell(string cssClass, string text, byte columnSpan)
        {
            TableHeaderCell tempCell = new TableHeaderCell
            {
                Text = text
            };

            if (cssClass != "-")
            {
                tempCell.CssClass = cssClass;
            }

            if (columnSpan != 0)
            {
                tempCell.ColumnSpan = columnSpan;
            }

            return tempCell;
        }
    }
}