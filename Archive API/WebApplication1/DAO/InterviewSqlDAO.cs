using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class InterviewSqlDAO
    {
        private string connectionString;

        public InterviewSqlDAO(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }


    }
}
