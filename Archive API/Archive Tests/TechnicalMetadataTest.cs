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
    public class TechnicalMetadataTest
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
        //todo: revise, code not reading correctly. Compare against capstone reader.
        [DataTestMethod]
        [DataRow("Austin", "MP3")]
        [TestMethod]
        public void RetrieveCodecTest(string name, string format)
        {
            TechnicalMetadataSqlDAO codec = new TechnicalMetadataSqlDAO(connectionString);

            IList<TechnicalMetadata> testFormat = codec.GetTechnicalInfoByIntervieweeName(name);

            TechnicalMetadata tech = new TechnicalMetadata();

            for (int i = 0; i < testFormat.Count; i++)
            {
                tech = testFormat[i];
            }

            Assert.AreEqual(tech.Codec, format);
        }
    }
}
