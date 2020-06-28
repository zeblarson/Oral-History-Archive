using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Interview
    {
        public int? Id { get; set; }
        public string Title {get; set;}
        public string InterviewerName { get; set; }
        public string IntervieweeName { get; set; }
        public DateTime DateConducted { get; set; }
        public int TranscriptAvailableInt { get; set; }
        public string TranscriptAvailable { get; set; }
        public string Summary { get; set; }

        public Interview ()
        {

        }
        
        public bool IsValid
        {
            get
            {
                return Id != 0 && Title != null && InterviewerName != null && IntervieweeName != null && DateConducted != null && Summary != null;
            }
        }
    }
}
