using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiServiceEndpoints.Models
{
    public class FileInformation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string FullFilePath { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdatedTimestamp { get; set; }
        public string ContentType { get; set; }
    }
}