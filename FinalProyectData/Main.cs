using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace FinalProyectData
{
    public class Main
    {

        private Dictionary<int, News> newsById;
        private Dictionary<string, List<News>> newsByKeyword;
        private Dictionary<DateTime, List<News>> newsByTime;
        private List<News> newsByKeywordAndTime;
        private List<News> allData;
        private String PathJson = @"../../MOCK_DATA.json";
        private String JsonToString;
        private dynamic data;


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

        public void get_All_data( ) {
            JsonToString = File.ReadAllText(PathJson);
            //1
            //data = JsonSerializer.Deserialize<dynamic>(JsonToString);

            //2
            List<News> news = JsonSerializer.Deserialize<List<News>>(JsonToString);

            //Console.WriteLine(data[0]);
            this.allData = news;
        }


    }
}
