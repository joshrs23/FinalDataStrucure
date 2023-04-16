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

        private Dictionary<int, News> newsById;//select
        private Dictionary<string[], News> newsByKeyword;
        private Dictionary<DateTime, List<News>> newsByTime;
        private List<News> newsByKeywordAndTime;
        private List<News> allData;
        private String PathJson = @"../../MOCK_DATA.json";
        private String JsonToString;
        private dynamic data;
        private Stack<News> recent;//show recent
        private Stack<News> trending;//show the last viewed
        private Stack<News> back; //Show last user reading
        private long realTime;

        public Main() {
            newsById = new Dictionary<int, News>();
            newsByKeyword = new Dictionary<string[], News > ();
            recent = new Stack<News>();
            trending = new Stack<News>();
            this.realTime = DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        public void set_realTime(long time) {
            this.realTime = time;
        }

        public void addNewWatched(News new_)
        {
            this.trending.Push(new_);
        }

        public Dictionary<int, News> GetNewsByIdDictionary()
        {
            return newsById;
        }

        public News getNewsById(int id)
        {
            if (this.newsById.ContainsKey(id))
            {
                this.newsById[id].Hits++;
                return this.newsById[id];
            }
            else
            {
                return null;
            }
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

            /*if (newsByKeyword.ContainsKey(keyword))
            {
                //listOfNews.AddRange(newsByKeyword[keyword]);
            }*/

            return listOfNews;

        }

        public List<News> GetNewsByKeywordAndTime(string keyword, DateTime time)
        {

            var listOfNews = newsByTime.Where(n => n.Key >= time && n.Value.Any(v => v.Keywords.Contains(keyword))).SelectMany(n => n.Value).ToList();

            return listOfNews;

        }

        public List<News> LoadData ()
        {
            
            return this.allData;

        }

        public void fill_All_data( ) {
            JsonToString = File.ReadAllText(PathJson);
            //1
            //data = JsonSerializer.Deserialize<dynamic>(JsonToString);

            //2
            List<News> news = JsonSerializer.Deserialize<List<News>>(JsonToString);

            //Console.WriteLine(data[0]);
            this.allData = news;
            for (int i = 0; i < this.allData.Count; i++)
            {

                // DataStructure HashMaps
                newsById.Add(this.allData[i].ID, this.allData[i]);
                newsByKeyword.Add(this.allData[i].Keywords, this.allData[i]);
            }
            /*
            Console.WriteLine("***");
            Console.WriteLine(newsById[2].Keywords);
            string[] key = {"tech"};
            Console.WriteLine(newsByKeyword[key]);
            Console.WriteLine("***");
            Console.WriteLine();*/

           

            
        }

        //
        public Stack<News> lastNews(string Keywords=null, long time=0) {
            //here we fill recent
            string news = "";
            this.recent.Clear();

            if (Keywords == null && time == 0)
            {//no filters
                for (int i = 0; i < this.allData.Count ; i++)
                {
                    if (this.realTime - (long)Convert.ToDouble(this.allData[i].Time) < 86401)//day - 24H
                    {
                        this.recent.Push(this.allData[i]);
                    }
                }
            }
            else if (Keywords != null && time == 0)
            {
                for (int i = 0; i < this.allData.Count; i++)
                {
                    if (this.realTime - (long)Convert.ToDouble(this.allData[i].Time) < 86401)//day - 24H
                    {
                        for (int j = 0; j < this.allData[i].Keywords.Length; j++)
                        {
                            if (this.allData[i].Keywords[j].Equals(Keywords))
                            {
                                this.recent.Push(this.allData[i]);
                            }
                        }
                    }
                }
            }
            else if (Keywords == null && time != 0)
            {
                for (int i = 0; i < this.allData.Count; i++)
                {
                    long subTime = (time > (long)Convert.ToDouble(this.allData[i].Time)) ?  (long)Convert.ToDouble(this.allData[i].Time)- time : time - (long)Convert.ToDouble(this.allData[i].Time);
                    //subTime =
                    if (subTime > -86401)//day - 24H
                    {
                        this.recent.Push(this.allData[i]);
                    }
                }
            }
            else if (Keywords != null && time != 0)
            {

            }

            return this.recent;
        }

        //public void 
    }
}
