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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userRole"] == null)
            {
                Response.Redirect("~/WebForms/IniciarSesion.aspx");
            }
            else
            {
                this.lblUserName.Text = Session["userName"].ToString();
                this.taskBusiness = new TaskBusiness();
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
            DateTime dateFrom, dateTo;
            int project, user, category;
            String textDateFrom, textDateTo;

            textDateFrom = this.txtFrom.Text;
            textDateTo = this.txtTo.Text;
            project = Int16.Parse(this.hdnProject.Value);
            user = Int16.Parse(this.hdnUser.Value);
            category = Int16.Parse(this.hdnCategory.Value);

            dateFrom = DateTime.Parse(
                (textDateFrom != "") ? textDateFrom : "1801-08-05"
            );
            dateTo = DateTime.Parse(
                (textDateTo != "") ? textDateTo : "1801-08-05"
            );

            generate = new Task();
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
                //FillReportTableByAllFilter(report);
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
                //Tagar al usuario por no indicar.
            }
        }

        
        /// <summary>
        /// Defectuso, borrelo apenas lo logre suplantar.
        /// </summary>
        /// <param name="report"></param>
        /*private void FillReportTableByAllFilter(List<Task> report)
        {
            TableRow tempRow;
            TableCell tempCell;
            String currentProject, currentCategory, currentUser, rowUser;
            Boolean firstProyect = true, firstCategory = true, change = false;
            float tempHours = 0, tempExtra = 0, totalExtra = 0, totalHours = 0;

            currentProject = report[0].Project.Name;
            currentCategory = report[0].Category.Name;
            currentUser = report[0].Collaborator.FirstName + " " + report[0].Collaborator.LastName;

            foreach (Task temp in report)
            {
                tempRow = new TableRow();
                tempCell = new TableCell();

                rowUser = temp.Collaborator.FirstName + " " + temp.Collaborator.LastName;

                tempHours = 0;
                tempExtra = 0;

                if ((currentUser == rowUser) && (change))
                {
                    continue;
                }
                else
                {
                    currentUser = rowUser;
                    if (temp.Project.Name != currentProject)
                    {
                        currentProject = temp.Project.Name;
                        tempCell.Text = currentProject;
                        tempCell.CssClass = "results";

                    }
                    else
                    {
                        if (firstProyect)
                        {
                            firstProyect = false;
                            tempCell.Text = currentProject;
                            tempCell.CssClass = "results";
                        }
                        else
                        {
                            tempCell.Text = "";
                            tempCell.CssClass = "";
                        }
                    }
                    tempRow.Cells.Add(tempCell);

                    tempCell = new TableCell
                    {
                        Text = rowUser,
                        CssClass = "results"
                    };
                    tempRow.Cells.Add(tempCell);

                    tempCell = new TableCell();
                    if (temp.Category.Name != currentCategory)
                    {
                        currentCategory = temp.Category.Name;
                        tempCell.Text = currentCategory;
                        tempCell.CssClass = "results";
                    }
                    else
                    {
                        if (firstCategory)
                        {
                            firstCategory = false;
                            tempCell.Text = currentCategory;
                            tempCell.CssClass = "results";
                        }
                        else
                        {
                            tempCell.Text = "";
                            tempCell.CssClass = "";
                        }
                    }
                    tempRow.Cells.Add(tempCell);

                    tempHours = this.SumHoursOfUser(report, rowUser, currentProject, currentCategory, false);
                    tempCell = new TableCell();
                    tempCell.Text = tempHours + " regulares";
                    tempCell.CssClass = "results";
                    tempRow.Cells.Add(tempCell);
                    totalHours += tempHours;

                    tempExtra = this.SumHoursOfUser(report, rowUser, currentProject, currentCategory, true);
                    tempCell = new TableCell();
                    tempCell.Text = tempExtra + " extra";
                    tempCell.CssClass = "results";
                    tempRow.Cells.Add(tempCell);
                    totalExtra += tempExtra;

                    tempCell = new TableCell();
                    tempCell.Text = (tempExtra + tempHours) + "";
                    tempCell.CssClass = "results";
                    tempRow.Cells.Add(tempCell);


                    this.reportTable.Rows.Add(tempRow);
                }
                change = true;
            }
        }*/

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

            this.reportTable.Rows.Add(BuiltTableHeaderRow(majorEntity, '-', minorEntity));

            foreach (Task task in report)
            {
                rowMajorEntity = GetEntityName(task, majorEntity);
                rowMinorEntity = GetEntityName(task, minorEntity);

                if (!firstMajor)
                {
                    if (currentMajorEntity != rowMajorEntity)
                    {
                        currentMajorEntity = rowMajorEntity;
                        tempRow = this.TotalHoursDedicatedRow(regularTotal, extraTotal, 2);
                        this.reportTable.Rows.Add(tempRow);
                        regularTotal = 0;
                        extraTotal = 0;
                        firstMajor = true;
                        extraCell = false;
                    }
                }

                if (!firstMinor)
                {
                    if (currentMinorEntity != rowMinorEntity)
                    {
                        currentMinorEntity = rowMinorEntity;
                        firstMinor = true;
                    }
                }

                tempRow = new TableRow();


                if (firstMajor)
                {
                    firstMajor = false;
                    extraCell = false;
                    tempCell = new TableCell
                    {
                        CssClass = "results",
                        Text = currentMajorEntity
                    };
                    tempRow.Cells.Add(tempCell);
                }
                else
                {
                    extraCell = true;
                }

                if (firstMinor)
                {
                    firstMinor = false;

                    if (extraCell)
                    {
                        tempCell = new TableCell();
                        tempCell.Text = "";
                        tempRow.Cells.Add(tempCell);
                    }

                    tempCell = new TableCell
                    {
                        CssClass = "results",
                        Text = currentMinorEntity
                    };
                    tempRow.Cells.Add(tempCell);
                    //Horas regulares
                    regular = SumHoursTwoEntities(report, currentMajorEntity, currentMinorEntity, minorEntity, majorEntity, false);
                    regularTotal += regular;
                    tempCell = new TableCell
                    {
                        Text = regular + " regulares",
                        CssClass = "results"
                    };
                    tempRow.Cells.Add(tempCell);
                    //Horas extra
                    extra = SumHoursTwoEntities(report, currentMajorEntity, currentMinorEntity, minorEntity, majorEntity, true);
                    extraTotal += extra;
                    tempCell = new TableCell
                    {
                        Text = extra + " extra",
                        CssClass = "results"
                    };
                    tempRow.Cells.Add(tempCell);
                    //Horas total
                    tempCell = new TableCell
                    {
                        Text = extra + regular + " horas",
                        CssClass = "results"
                    };
                    tempRow.Cells.Add(tempCell);
                }

                this.reportTable.Rows.Add(tempRow);

            }
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
            float regular, extra;
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

                    tempCell = new TableCell
                    {
                        Text = currentEntity,
                        CssClass = "results"
                    };
                    tempRow.Cells.Add(tempCell);
                    //Horas regulares
                    regular = SumHoursSingleEntity(report, currentEntity, minorEntity, false);
                    tempCell = new TableCell
                    {
                        Text = regular + " regulares",
                        CssClass = "results"
                    };
                    tempRow.Cells.Add(tempCell);
                    //Horas extra
                    extra = SumHoursSingleEntity(report, currentEntity, minorEntity, true);
                    tempCell = new TableCell
                    {
                        Text = extra + " extra",
                        CssClass = "results"
                    };
                    tempRow.Cells.Add(tempCell);
                    //Horas total
                    tempCell = new TableCell
                    {
                        Text = extra + regular + " horas",
                        CssClass = "results"
                    };
                    tempRow.Cells.Add(tempCell);

                    this.reportTable.Rows.Add(tempRow);
                }

            }
        }

        /// <summary>
        /// Método que suma las horas de una entidad para un reporte.
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
        /// Método que suma las horas de la entidad menor.
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
        /// Método que arma un "TableRow" indicando el tortal de horas dedicadas de una entidad mayor.
        /// La primer columna tendrá un mensaje indicando "Total de horas" y el colspan de esta columna es el alterado.
        /// Las siguientes columnas serás el total de horas regulares, luego las horas extra y finalmente la suma de estas.
        /// </summary>
        /// <param name="totalRegular">Total de horas regulares.</param>
        /// <param name="totalExtra">Total de horas extra.</param>
        /// <param name="span">Grosor de columnas de la columna mensaje.</param>
        /// <returns>Un TableRow armado y listo para ser insertado en una tabla.</returns>
        private TableRow TotalHoursDedicatedRow(float totalRegular, float totalExtra, byte span)
        {
            TableRow tempRow = new TableRow();
            TableCell tempCell = new TableCell
            {
                ColumnSpan = span,
                CssClass = "results",
                Text = "Total horas invertidas:"
            };
            tempRow.Cells.Add(tempCell);

            tempCell = new TableCell
            {
                CssClass = "results",
                Text = totalRegular + " Regulares"
            };
            tempRow.Cells.Add(tempCell);

            tempCell = new TableCell
            {
                CssClass = "results",
                Text = totalExtra + " Extra"
            };
            tempRow.Cells.Add(tempCell);

            tempCell = new TableCell
            {
                CssClass = "results",
                Text = totalRegular+ totalExtra + " horas"
            };
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
            
            if(MajorEntity != '-')
            {
                tempHeaderCell = new TableHeaderCell
                {
                    CssClass = "results",
                    Text = PassCharEntityToName(MajorEntity)
                };
                tempHeader.Cells.Add(tempHeaderCell);
            }

            if (MiddleEntity != '-')
            {
                tempHeaderCell = new TableHeaderCell
                {
                    CssClass = "results",
                    Text = PassCharEntityToName(MiddleEntity)
                };
                tempHeader.Cells.Add(tempHeaderCell);
            }

            if (MinorEntity != '-')
            {
                tempHeaderCell = new TableHeaderCell
                {
                    CssClass = "results",
                    Text = PassCharEntityToName(MinorEntity)
                };
                tempHeader.Cells.Add(tempHeaderCell);
            }

            tempHeaderCell = new TableHeaderCell
            {
                Text = "Horas",
                ColumnSpan = 2,
                CssClass = "results"
            };
            tempHeader.Cells.Add(tempHeaderCell);
            tempHeaderCell = new TableHeaderCell
            {
                Text = "Total",
                CssClass = "results"
            };
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
    }
}