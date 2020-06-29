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
    public class UnitTest1
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
        public void GetList()
        {
            InterviewSqlDAO interview = new InterviewSqlDAO(connectionString);

            IList<Interview> interviews = interview.ListInterviews();

            Assert.AreEqual(10, interviews.Count);
        }
    }
}
