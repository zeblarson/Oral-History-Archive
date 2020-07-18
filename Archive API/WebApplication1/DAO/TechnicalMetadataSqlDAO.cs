using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class TechnicalMetadataSqlDAO
    {
        private string connectionString;

        public TechnicalMetadataSqlDAO(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }

        private TechnicalMetadata ConvertReaderToTechnicalMetadata(SqlDataReader reader)
        {
            TechnicalMetadata technical = new TechnicalMetadata();
            technical.Codec = Convert.ToString(reader["codec"]);
            technical.FileSize = Convert.ToDecimal(reader["file_size"]);
            technical.Format = Convert.ToString(reader["recording_format"]);
            technical.Id = Convert.ToInt32(reader["id"]);
            technical.InterviewLength = Convert.ToString(reader["interview_length"]);

            return technical;
        }

        public List<TechnicalMetadata> GetTechnicalInfoByIntervieweeName(string name)
        {
            List<TechnicalMetadata> technicals = new List<TechnicalMetadata>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sqlSearch = " SELECT id.interviewee_name, im.id, im.file_size, im.codec, im.interview_length, " +
                        "im.recording_format FROM interview_descriptions id JOIN interview_metadata im ON id.interview_id = im.id " +
                        "WHERE id.interviewee_name LIKE '%'+@name+'%'";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlSearch, conn) ;
                    cmd.Parameters.AddWithValue("@name", name);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TechnicalMetadata technical = ConvertReaderToTechnicalMetadata(reader);
                        technicals.Add(technical);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return technicals;
        }
    }
}
