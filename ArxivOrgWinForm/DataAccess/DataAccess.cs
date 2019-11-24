using ArxivOrgWinForm.DBModel;

namespace ArxivOrgWinForm.DAL
{
    public class DataAccess
    {
        public void WriteDBSQL(ArticleModel article)
        {
            using (ContextDBMySQL context = new ContextDBMySQL())
            {
                context.Database.EnsureCreated();                
                context.Articles.Add(article);                
                context.SaveChanges();
            }
        }

    }
}
