using System;

namespace ArxivOrgWinForm.DBModel
{
    public class ArticleModel
    {
        public int Id { get; set; }

        //наука
        public string Science { get; set; }

        //дисциплина
        public string Subject { get; set; }

        //категория
        public string Category { get; set; }

        //заголовок статьи
        public string Title { get; set; }

        //авторы статьи
        public string Autors { get; set; }

        //цитата статьи
        public string Quotation { get; set; }

        //дата публикации статьи
        public DateTime Publication_Date { get; set; } 
        
        //ссылка на статью
        public string Article_Source { get; set; }

        //ссылка на документ
        public string Document_Source { get; set; }

        //документ
        public string Document_Local { get; set; }
       
        //дата внесения в базу
        public DateTime Recording_Date { get; set; }
    }
}
