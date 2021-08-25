using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;
using System;
using System.Linq;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        Employer test_employer;
        Location test_location;
        PositionType test_type;
        CoreCompetency test_comp;

        Job test_job1;
        Job test_job2;
        Job test_job3;
        Job test_job4;

        [TestInitialize]
        public void CreateJobObjects()
        {
            test_job1 = new Job();
            test_job2 = new Job();
            test_employer = new Employer("ACME");
            test_location = new Location("Desert");
            test_type = new PositionType("Quality control");
            test_comp = new CoreCompetency("persistence");
            test_job3 = new Job("Product tester", test_employer, test_location, test_type, test_comp);
            test_job4 = new Job("Ice cream tester", new Employer(""), new Location("Home"), new PositionType("UX"), new CoreCompetency("Tasting ability"));
        }

        [TestMethod]
        public void TestSettingJobID()
        {
            Assert.IsTrue((test_job2.ID - test_job1.ID)==1);
        }

        [TestMethod]
        public void TestSettingJobIDTestJobConstructorSetsAllFields()
        {
            Assert.IsTrue(test_job3.Name == "Product tester");
            Assert.IsTrue(test_job3.EmployerName == test_employer);
            Assert.IsTrue(test_job3.EmployerLocation == test_location);
            Assert.IsTrue(test_job3.PositionType == test_type);
            Assert.IsTrue(test_job3.JobCoreCompetency == test_comp);
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Assert.IsFalse(test_job1.Equals(test_job2));
        }

        [TestMethod]
        public void TestToStringForBlankLines()
        {
            string string3 = new string(test_job3.ToString());
            string[] string3Lines = string3.Split('\n');

            Assert.IsTrue(String.IsNullOrEmpty(string3Lines[0]));
            Assert.IsTrue(String.IsNullOrEmpty(string3Lines[string3Lines.Count()-1]));
        }

        [TestMethod]
        public void TestToStringForDataLines()
        {
            string string3 = new string(test_job3.ToString());
            string[] string3Lines = string3.Split('\n');

            Assert.IsTrue(string3Lines[1].Contains("ID") && string3Lines[1].Contains(test_job3.ID.ToString()));
            Assert.IsTrue(string3Lines[2].Contains("Name") && string3Lines[2].Contains(test_job3.Name));
            Assert.IsTrue(string3Lines[3].Contains("Employer") && string3Lines[3].Contains(test_job3.EmployerName.Value));
            Assert.IsTrue(string3Lines[4].Contains("Location") && string3Lines[4].Contains(test_job3.EmployerLocation.Value));
            Assert.IsTrue(string3Lines[5].Contains("Position Type") && string3Lines[5].Contains(test_job3.PositionType.Value));
            Assert.IsTrue(string3Lines[6].Contains("Core Competency") && string3Lines[6].Contains(test_job3.JobCoreCompetency.Value));
        }

        [TestMethod]
        public void TestToStringForEmptyDataLines()
        {
            string string4 = new string(test_job4.ToString());
            string[] string4Lines = string4.Split('\n');
            
            Assert.IsTrue(string4Lines[3].Contains("Data not available"));

        }

        [TestMethod]
        public void TestToStringForEmptyJobs()
        {
            string string2 = new string(test_job2.ToString());

            Assert.IsTrue(string2 == "OOPS! This job does not seem to exist.");

        }
    }
}
