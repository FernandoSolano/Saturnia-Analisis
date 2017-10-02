using Core.Data;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class ProjectBusiness
    {
        private ProjectData projectData;

        public ProjectBusiness()
        {
            projectData = new ProjectData();
        }

        public Project AddProject(Project project)
        {
            project.StartDate = DateTime.Today;
            project.State = true;
            return projectData.AddProject(project);
        }
    }
}
