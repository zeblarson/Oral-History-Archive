using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using WebApplication1.DAO;
using WebApplication1.Models;
using Archive_Tests;

namespace Archive_Tests
{
    [TestClass]
    public class InterviewSqlDAOtests
    {
        private string connectionString = "Data Source=.\\SQLEXPRESS;Database=OralHistories;Integrated Security=True";

        private TransactionScope transaction;

        [TestInitialize]
        public void Initialize()
        {
            transaction = new TransactionScope();
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Dispose();
        }

        [TestMethod]
        public void GetListHardCodedPreliminaryValue()
        {
            InterviewSqlDAO interview = new InterviewSqlDAO(connectionString);

            IList<Interview> interviews = interview.ListInterviews();

            Assert.AreEqual(10, interviews.Count);
        }
        [DataTestMethod]
        [DataRow("Skinner", 1)]
        [TestMethod]
        public void SearchInterviewsByName(string name, int count)
        {
            InterviewSqlDAO interview = new InterviewSqlDAO(connectionString);

            IList<Interview> names = interview.GetInterviewBySubjectName(name);

            Assert.AreEqual(count, names.Count);
        }
        [DataTestMethod]
        [DataRow("Apartheid", 5)]
        [TestMethod]
        public void SearchInterviewsByKeyword(string keyword, int count)
        {
            InterviewSqlDAO interview = new InterviewSqlDAO(connectionString);
            IList<Interview> keywords = interview.SearchInterviewByKeyword(keyword);
            Assert.AreEqual(count, keywords.Count);
        }
    }
}
