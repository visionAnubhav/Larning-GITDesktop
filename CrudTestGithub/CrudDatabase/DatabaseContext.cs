using CrudDatabase.tblCommit;
using Microsoft.EntityFrameworkCore;

namespace CrudDatabase
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
            
        }
      public DbSet<tblGitCommitInfo> GitCommitTable { get; set; }
    }
}
