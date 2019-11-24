
using Microsoft.EntityFrameworkCore;

namespace ArxivOrgWinForm.DBModel
{   

    class ContextDBMySQL : DbContext
    {
        public DbSet<ArticleModel> Articles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;UserId=root;Password=####;database=articlestemp;");
        }
    }
}
