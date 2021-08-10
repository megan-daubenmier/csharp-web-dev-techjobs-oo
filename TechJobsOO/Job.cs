using System;
namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        // TODO: Add the two necessary constructors.

        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employerName, Location location, PositionType jobType, CoreCompetency competency) : this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = location;
            JobType = jobType;
            JobCoreCompetency = competency;
        }

        // TODO: Generate Equals() and GetHashCode() methods.

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            string jobString = new string("\nID: "+ this.Id);
            jobString += "\nName: " + this.Name;
            jobString += "\nEmployer: " + this.EmployerName.Value;
            jobString += "\nLocation: " + this.EmployerLocation.Value;
            jobString += "\nPosition Type: " + this.JobType.Value;
            jobString += "\nCore Competency: " + this.JobCoreCompetency.Value;
            jobString += "\n";

            return jobString;
        }

    }
}
