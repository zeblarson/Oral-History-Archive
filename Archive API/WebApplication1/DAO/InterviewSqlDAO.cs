using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
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
        private Interview ConvertReaderToInterview(SqlDataReader reader)
        {
            Interview interview = new Interview();
            interview.DateConducted = Convert.ToDateTime(reader["date_conducted"]);
            interview.Id = Convert.ToInt32(reader["interview_id"]);
            interview.IntervieweeName = Convert.ToString(reader["interviewee_name"]);
            interview.InterviewerName = Convert.ToString(reader["interviewer_name"]);
            interview.Title = Convert.ToString(reader["title"]);
            interview.TranscriptAvailableInt = Convert.ToInt32(reader["transcript_available"]);

            if (interview.TranscriptAvailableInt == 1)
            {
                interview.TranscriptAvailable = "Yes";
            }
            if (interview.TranscriptAvailableInt == 0)
            {
                interview.TranscriptAvailable = "No";
            }
            return interview;
        }

        public List<Interview> ListInterviews()
        {
            List<Interview> interviews = new List<Interview>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Select * From interview_descriptions;", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Interview interview = ConvertReaderToInterview(reader);
                        interviews.Add(interview);
                    }    
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return interviews;
        }
        public List<Interview> GetInterviewBySubjectName(string name)
        {
            List<Interview> interviews = new List<Interview>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "Select * From interview_descriptions WHERE interviewee_name LIKE '%@name%'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", name);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Interview interview = ConvertReaderToInterview(reader);
                        interviews.Add(interview);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return interviews;
        }
    }
}
