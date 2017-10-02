using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Data;

namespace Core.Business
{
    public class ProjectBusiness
    {

        private ProjectData projectData;

        public ProjectBusiness()
        {
            this.projectData = new ProjectData();
        }

        public Project ShowProject(Project project)
        {
            project = this.projectData.ShowProject(project);

            return project;
        }

        public List<Project> SearchProject(Project project)
        {
            List<Project> projects;

            projects = this.projectData.SearchProject(project);

            return projects;
        }

    }
}
