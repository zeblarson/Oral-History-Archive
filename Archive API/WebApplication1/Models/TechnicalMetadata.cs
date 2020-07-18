using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class TechnicalMetadata
    {
        public int Id { get; set; }
        public string Format { get; set; }
        public decimal FileSize { get; set; }
        public string Codec { get; set; }
        public string InterviewLength { get; set; }

        public bool IsValid
        {
            get
            {
                return Id != 0 && Format != null && FileSize != 0 && Codec != null && InterviewLength != null;
            }
        }
    }
}
