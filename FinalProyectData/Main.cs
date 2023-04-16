using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProyectData
{
    public class Main
    {

        private Dictionary<int, News> newsById;
        private Dictionary<string, List<News>> newsByKeyword;
        private Dictionary<DateTime, List<News>> newsByTime;
        private List<News> newsByKeywordAndTime;


        public List<News> GetNewsById(int id)
        {
            List<News> listOfNews = new List<News>();

            if (newsById.ContainsKey(id))
            {
                listOfNews.Add(newsById[id]);
            }

            return listOfNews;
        }

        public List<News> GetNewsByTime(DateTime time)
        {

            List<News> listOfNews = new List<News>();

            if (newsByTime.ContainsKey(time))
            {
                listOfNews.AddRange(newsByTime[time]);
            }

            return listOfNews;

        }

        public List<News> GetNewsByKeyword(string keyword)
        {

            List<News> listOfNews = new List<News>();

            if (newsByKeyword.ContainsKey(keyword))
            {
                listOfNews.AddRange(newsByKeyword[keyword]);
            }

            return listOfNews;

        }

        public List<News> GetNewsByKeywordAndTime(string keyword, DateTime time)
        {

            var listOfNews = newsByTime.Where(n => n.Key >= time && n.Value.Any(v => v.Keywords.Contains(keyword))).SelectMany(n => n.Value).ToList();

            return listOfNews;

        }




    }
}
