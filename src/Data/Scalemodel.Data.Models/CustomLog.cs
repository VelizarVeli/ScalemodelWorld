using System;
using System.ComponentModel.DataAnnotations;

namespace Scalemodel.Data.Models
{
   public class CustomLog
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public int EventId { get; set; }

        public string LogLevel { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedTime { get; set; }
    }
}
