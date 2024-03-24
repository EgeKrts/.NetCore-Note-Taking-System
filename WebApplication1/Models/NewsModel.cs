namespace WebApplication1.Models
{
    public class NewsModel
    {



        public class Rootobject
        {
            public string status { get; set; }
            public int totalResults { get; set; }
            public Article[] articles { get; set; }
        }

        public class Article
        {
            public string title { get; set; }
            public string url { get; set; }
            public DateTime published_date { get; set; }
            public Publisher publisher { get; set; }
        }

        public class Publisher
        {
            public string name { get; set; }
            public string url { get; set; }
        }


    }
}
