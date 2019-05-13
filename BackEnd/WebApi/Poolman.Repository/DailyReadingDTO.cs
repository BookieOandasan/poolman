using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Poolman.Repository
{
    [Table("DailyReading", Schema = "Reading")]
    public class DailyReadingDTO
    {
        [Key]
        public int Id { get; set; }
        public string summary { get; set; }
        public DateTime publishdate { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string type { get; set; }
    }
}
