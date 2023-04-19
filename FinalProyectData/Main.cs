using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace FinalProyectData
{
    public class Main
    {

        private Dictionary<int, News> newsById;//select
        private Dictionary<string[], News> newsByKeyword;
        private Dictionary<DateTime, List<News>> newsByTime;
        private List<News> allData;
        private String PathJson = @"../../MOCK_DATA.json";
        private String JsonToString;
        private Stack<News> recent;//show recent
        private Dictionary<int, int> trending;//show the last viewed
        private Stack<News> back; //Show last user reading
        private long realTime;

        public Main() {
            newsById = new Dictionary<int, News>();
            newsByKeyword = new Dictionary<string[], News > ();
            recent = new Stack<News>();
            trending = new Dictionary<int, int>();
            back = new Stack<News>();
            this.realTime = DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        public void set_realTime(long time) {
            this.realTime = time;
        }

        public void addNewWatched(News new_)
        {
            if (!trending.ContainsKey(new_.ID))
            {
                this.trending.Add(new_.ID, new_.ID);
            }
            this.back.Push(new_);
        }

        public News getBack()
        {

            News lastNews = null;

            if (this.back.Count > 1)
            {
                lastNews = this.back.Pop();

                lastNews = this.back.Pop();
            }
            

            return lastNews;

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
            this.allData.Sort((s1, s2) => s1.Time.CompareTo(s2.Time));
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
            Dictionary<int, int> noRepeat = new Dictionary<int, int>();
            
            if (Keywords == null && time == 0)
            {//no filters
                for (int i = 0; i < this.allData.Count ; i++)
                {
                    long subTime = this.realTime - (long)Convert.ToDouble(this.allData[i].Time);
                    if (subTime < 86401 && subTime>=0)//day - 24H
                    {
                        if (!noRepeat.ContainsKey(this.allData[i].ID))
                        {
                            this.recent.Push(this.allData[i]);
                            noRepeat.Add(this.allData[i].ID, this.allData[i].ID);
                        }
                        if (this.recent.Count>500)
                        {
                            break;
                        }
                    }
                }
                
            }
            else if (Keywords != null && time == 0)
            {//keywords filter
                for (int i = 0; i < this.allData.Count; i++)
                {
                    long subTime = this.realTime - (long)Convert.ToDouble(this.allData[i].Time);
                    if (subTime < 86401 && subTime >= 0)//day - 24H
                    {
                        for (int j = 0; j < this.allData[i].Keywords.Length; j++)
                        {
                            string[] keyword = Keywords.Split(',');
                            for (int k = 0; k < keyword.Length; k++)
                            {
                                if (this.allData[i].Keywords[j].Equals(keyword[k]))
                                {
                                    if (!noRepeat.ContainsKey(this.allData[i].ID))
                                    {
                                        this.recent.Push(this.allData[i]);
                                        noRepeat.Add(this.allData[i].ID, this.allData[i].ID);
                                    }
                                    if (this.recent.Count > 500)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (Keywords == null && time != 0)
            {//time filter
                for (int i = 0; i < this.allData.Count; i++)
                {
                    long subTime = time - (long)Convert.ToDouble(this.allData[i].Time);
                    if (subTime < 86401 && subTime >= 0)//day - 24H
                    {
                        if (!noRepeat.ContainsKey(this.allData[i].ID))
                        {
                            this.recent.Push(this.allData[i]);
                            noRepeat.Add(this.allData[i].ID, this.allData[i].ID);
                        }
                        if (this.recent.Count > 500)
                        {
                            break;
                        }
                    }
                }
            }
            else if (Keywords != null && time != 0)
            {//keyword and time filter
                for (int i = 0; i < this.allData.Count; i++)
                {
                    long subTime = time - (long)Convert.ToDouble(this.allData[i].Time);
                    if (subTime < 86401 && subTime >= 0)//day - 24H
                    {
                        for (int j = 0; j < this.allData[i].Keywords.Length; j++)
                        {
                            string[] keyword = Keywords.Split(',');
                            for (int k = 0; k < keyword.Length; k++)
                            {
                                if (this.allData[i].Keywords[j].Equals(keyword[k]))
                                {
                                    if (!noRepeat.ContainsKey(this.allData[i].ID))
                                    {
                                        this.recent.Push(this.allData[i]);
                                        noRepeat.Add(this.allData[i].ID, this.allData[i].ID);
                                    }
                                    if (this.recent.Count > 500)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return this.recent;
        }

        public List<News> showTrending(string Keywords = null, long time = 0) {
            List<News> allTrending = new List<News>();
            Dictionary<int, int> noRepeat = new Dictionary<int, int>();

            if (Keywords == null && time == 0)
            {//no filters
                foreach (int value in this.trending.Values)
                {
                    long subTime = this.realTime - (long)Convert.ToDouble(this.newsById[value].Time);
                    if (subTime < 86401 && subTime >= 0)//day - 24H
                    {
                        allTrending.Add(this.newsById[value]);
                    }
                    if (allTrending.Count > 500)
                    {
                        break;
                    }
                }
            }
            else if (Keywords != null && time == 0)
            {//keywords filter
                foreach (int value in this.trending.Values)
                {
                    long subTime = this.realTime - (long)Convert.ToDouble(this.newsById[value].Time);
                    if (subTime < 86401 && subTime >= 0)//day - 24H
                    {
                        for (int j = 0; j < this.newsById[value].Keywords.Length; j++)
                        {
                            string[] keyword = Keywords.Split(',');
                            for (int k = 0; k < keyword.Length; k++)
                            {
                                if (this.newsById[value].Keywords[j].Equals(keyword[k]))
                                {
                                    if (!noRepeat.ContainsKey(this.newsById[value].ID))
                                    {
                                        allTrending.Add(this.newsById[value]);
                                        noRepeat.Add(this.newsById[value].ID, this.newsById[value].ID);
                                    }
                                    if (allTrending.Count > 500)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (Keywords == null && time != 0)
            {//time filter
                foreach (int value in this.trending.Values)
                {
                    long subTime = time - (long)Convert.ToDouble(this.newsById[value].Time);
                    //subTime =
                    if (subTime < 86401 && subTime >= 0)//day - 24H
                    {
                        if (!noRepeat.ContainsKey(this.newsById[value].ID))
                        {
                            allTrending.Add(this.newsById[value]);
                            noRepeat.Add(this.newsById[value].ID, this.newsById[value].ID);
                        }
                        if (allTrending.Count > 500)
                        {
                            break;
                        }
                    }
                }
            }
            else if (Keywords != null && time != 0)
            {//keyword and time filter
                foreach (int value in this.trending.Values)
                {
                    long subTime = time - (long)Convert.ToDouble(this.newsById[value].Time);
                    //subTime =
                    if (subTime < 86401 && subTime >= 0)//day - 24H
                    {
                        for (int j = 0; j < this.newsById[value].Keywords.Length; j++)
                        {
                            string[] keyword = Keywords.Split(',');
                            for (int k = 0; k < keyword.Length; k++)
                            {
                                if (this.newsById[value].Keywords[j].Equals(keyword[k]))
                                {
                                    if (!noRepeat.ContainsKey(this.newsById[value].ID))
                                    {
                                        allTrending.Add(this.newsById[value]);
                                        noRepeat.Add(this.newsById[value].ID, this.newsById[value].ID);
                                    }
                                    if (allTrending.Count > 500)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            allTrending.Sort((s1, s2) => s2.Hits.CompareTo(s1.Hits));
            return allTrending;
        }
    }
}
