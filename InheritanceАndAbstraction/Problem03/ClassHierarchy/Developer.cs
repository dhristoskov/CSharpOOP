using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem03
{
    internal class Developer : RegularEmployee, IDeveloper
    {
        private List<Project> projects;

        public Developer(string firstName, string lastName, long id, decimal salary, Departments department,List<Project>projects)
            : base(firstName, lastName, id, salary, department)
        {
            this.Projects = projects;
        }

        public List<Project> Projects
        {
            get { return this.projects; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.projects = value;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Projects:");
            foreach (var project in this.projects)
            {
                sb.AppendLine(project.ToString());
            }
            return base.ToString() + sb.ToString();
        }
    }
}
