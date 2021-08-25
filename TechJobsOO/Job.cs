using System;
using System.Reflection;

namespace TechJobsOO
{
    public class Job
    {
        public int ID { get; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType PositionType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        // TODO: Add the two necessary constructors.

        public Job()
        {
            ID = nextId;
            nextId++;
        }

        public Job(string name, Employer employerName, Location location, PositionType jobType, CoreCompetency competency) : this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = location;
            PositionType = jobType;
            JobCoreCompetency = competency;
        }

        // TODO: Generate Equals() and GetHashCode() methods.

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   ID == job.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }

        public override string ToString()
        {
            string jobString = "";
            string temp = "";
            PropertyInfo[] properties = this.GetType().GetProperties();

            if(Name == null && EmployerName == null && EmployerLocation == null && PositionType == null && JobCoreCompetency == null)
            {
                return "OOPS! This job does not seem to exist.";
            }
            else
            {
                foreach (PropertyInfo property in properties)
                {
                    temp = property.Name;
                    for (int i = 2; i < temp.Length; i++)
                    {
                        if (char.IsUpper(temp[i]))
                        {
                            temp = temp.Insert(i, " ");
                            i++;
                        }
                    }

                    if (property.GetValue(this, null) != null && property.GetValue(this, null).ToString() != "")
                    {
                        jobString += "\n" + temp + ": " + property.GetValue(this, null);
                    }
                    else
                    {
                        jobString += "\n" + temp + ": Data not available";
                    }
                }
                jobString += "\n";

                return jobString;
            }
        }

    }
}
