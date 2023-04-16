using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProyectData
{
    public class News
    {
        public int ID { get; set; } // Unique id for each news
        public string Time { get; set; } // Time of news publication which is based on EPOCH
        public string[] Keywords { get; set; } // Keywords that best describe the content of news
        public string Content { get; set; } // The content of news
        public int Hits { get; set; } // Number of times that news has been retrieved

        /*public News(int iD, long time, string[] keywords, string content, int hits)
        {
            this.ID1  = iD;
            this.Time1 = time;
            this.Keywords1 = keywords;
            this.Content1 = content;
            this.Hits1 = hits;
        }

        public long Time1 { get => Time; set => Time = value; }
        public string[] Keywords1 { get => Keywords; set => Keywords = value; }
        public string Content1 { get => Content; set => Content = value; }
        public int Hits1 { get => Hits; set => Hits = value; }
        public int ID1 { get => ID; set => ID = value; }

        public override string ToString()
        {
            String keyword = "";
            string[] Keywords = this.Keywords1;
            for (int i = 0; i < Keywords.Length; i++)
            {
                keyword = keyword +" "+ Keywords[i];
            }
            return "Id :"+this.ID1+" Time : "+this.Time1+" Keywords: "+keyword+" Content: "+this.Content1+" Hits: "+this.Hits1;
        }*/
    }
}
