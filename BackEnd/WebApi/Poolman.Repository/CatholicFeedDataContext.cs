using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poolman.Repository
{
  public class CatholicFeedDataContext : DbContext
  {

    public CatholicFeedDataContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=tcp:l7s4ew906p.database.windows.net,1433;Database=CatholicFeed_db;User ID=noandasan@l7s4ew906p;Password=TexasHunter123!@#;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }


    public virtual DbSet<RssFeedDto> RssFeeds { set; get; }
  }
}
