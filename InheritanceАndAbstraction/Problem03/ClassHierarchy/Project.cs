using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem03
{
    internal class Project : IProject
    {
        private string projectName;
        private DateTime startDate;
        private string details;
        private States state;
        private string p1;
        private int p2;
        private string p3;
        private States states;

        public Project(string projectName, DateTime startDate, string details, States state)
        {
            this.ProjectName = projectName;
            this.StartDate = startDate;
            this.Details = details;
            this.State = state;
        }
     
        public string ProjectName
        {
            get{ return this.projectName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                this.projectName = value;
            }
        }
        public DateTime StartDate
        {
            get { return this.startDate; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.startDate = value;
            }
        }
        public string Details
        {
            get { return this.details; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                this.details = value;
            }
        }
        public States State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public void CloseProject()
        {
            if (this.State == States.Open)
            {
                this.State = States.Closed;
            }
        }

        public override string ToString()
        {
            return String.Format("Project Name:{0},Start Date:{1},Details:{2},State{3}", 
                this.ProjectName, this.StartDate, this.Details, this.State);
        }
    }
}
