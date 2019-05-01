using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Poolman.Repository
{
  [System.ComponentModel.DataAnnotations.Schema.Table("RssFeed",Schema = "CatholicDataFeedOnDemand")]
  public class RssFeedDto
  {

    [Key]
    public string Id { get; set; }
    public string summary { get; set; }
    
  }
}
