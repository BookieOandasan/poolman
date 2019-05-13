using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Poolman.Repository
{
    [Table("SaintOfTheDay", Schema = "Saint")]
    
    public class SaintDTO
    {
        [Key]
        public int Id { get; set; }
        public string summary { get; set; }
        public DateTime publishdate { get; set; }
        public string title { get; set; }
        public string link { get; set; }
    }
}
