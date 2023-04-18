using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProyectData
{
    public partial class Form1 : Form
    {
        private Main main;
        

        public Form1()
        {
            InitializeComponent();
            main = new Main();
            main.fill_All_data();
            
            
    }

        private void RefreshDisplayList()
        {
            lstNews.Items.Clear();

            //lstNews.Items.Add(main.GetNewsById(Convert.ToInt32(txtId.Text)));
            //List<News> news =  main.LoadData(); 

            /*List<News> news = main.LoadData();
           
            foreach (News item in news)
            {
                lstNews.Items.Add(item.ID);
            }
            */

            if (cmbSearchBy.Text == "Id")
            {

                int idToFilter = int.Parse(txtId.Text);

                /*
                //Another way to do it
                foreach(KeyValuePair<int, News> item in main.GetNewsByIdDictionary())
                {
                    if (item.Key == idToFilter) {

                        lstNews.Items.Add(item.Key + ":  Time: " + item.Value.Time + " Content: " + item.Value.Content + " Keywords: " + item.Value.Hits);

                        item.Value.Hits = item.Value.Hits++;

                        main.addNewWatched(item.Value);

                    }
                    
                }*/

                //We chose this option because of the complexity.

                News news = main.getNewsById(idToFilter);
                if (news != null)
                {
                    String keyword = "";
                    string[] Keywords_ = news.Keywords;
                    for (int i = 0; i < Keywords_.Length; i++)
                    {
                        keyword = keyword + " " + Keywords_[i];
                    }

                    String datatoShow = news.ID + ":  Time: " + news.Time + " Content: " + news.Content + " Keywords: " + keyword + " Hits: " + news.Hits;
                    lstNews.Items.Add(datatoShow);

                   
                    main.addNewWatched(news);


                }
                else
                {
                    MessageBox.Show("This Id does not exist");
                }
            }




        }


        public void RefreshDisplayList_news24() {
            lstNews.Items.Clear();
            string Keywords = this.txtKeywords.Text.Replace(" ","");
            string time = this.txtTime.Text;

            if (this.rbtnKeyword.Checked && !this.rbtnKeywordsTime.Checked && !this.rbtnTime.Checked)
            {
                if (Keywords.Length == 0 || !Validator.ValidateAlphabetical(Keywords))
                {
                    MessageBox.Show("Keyowrd must be text only");
                    Keywords = null;
                }

                time = "0";
            }
            else if (!this.rbtnKeyword.Checked && !this.rbtnKeywordsTime.Checked && this.rbtnTime.Checked)
            {
                if (!Validator.ValidateNumeric(time))
                {
                    MessageBox.Show("Time must be numeric only");
                    time = "0";
                }

                Keywords = null;
            }
            else if (!this.rbtnKeyword.Checked && this.rbtnKeywordsTime.Checked && !this.rbtnTime.Checked)
            {
                if (Keywords.Length == 0 && !Validator.ValidateAlphabetical(Keywords) && !Validator.ValidateNumeric(time))
                {
                    MessageBox.Show("Keyowrd must be text only and Time must be numeric only");
                    Keywords = null;
                    time = "0";
                }
            }
            else {
                Keywords = null;
                time = "0";
            }

            Stack < News > news = this.main.lastNews(Keywords,(long)Convert.ToInt32(time));
            //lau porfa muestrame los datos que encontro
        
            //List<News> recentNews = news.ToList();
            if (news != null)
            {
                String datatoShow;

                /* for ( int i = 0; i < recentNews.Count; i++)
                 {
                     datatoShow = recentNews[i].ID + ":  Time: " + recentNews[i].Time + " Content: " + recentNews[i].Content + " Keywords: " + recentNews[i].Keywords + " Hits: " + recentNews[i].Hits;
                     lstNews.Items.Add(datatoShow);

                 }*/
                News new_;//we are using stack to show the data from the new news to the older news with pop.
                while(news.Count>0)
                {
                    new_ = news.Pop();

                    String keyword = "";
                    string[] Keywords_ = new_.Keywords;
                    for (int i = 0; i < Keywords_.Length; i++)
                    {
                        keyword = keyword + " " + Keywords_[i];
                    }

                    datatoShow = new_.ID + ":  Time: " + new_.Time + " Content: " + new_.Content + " Keywords: " + keyword + " Hits: " + new_.Hits;
                    lstNews.Items.Add(datatoShow);

                }

            }
            else
            {
                MessageBox.Show("There are not recent news");
            }
        }

        public void RefreshDisplayTrending_news24()
        {
            lstNews.Items.Clear();
            string Keywords = this.txtKeywords.Text.Replace(" ", "");
            string time = this.txtTime.Text;

            if (this.rbtnKeyword.Checked && !this.rbtnKeywordsTime.Checked && !this.rbtnTime.Checked)
            {
                if (Keywords.Length == 0 || !Validator.ValidateAlphabetical(Keywords))
                {
                    MessageBox.Show("Keyowrd must be text only");
                    Keywords = null;
                }

                time = "0";
            }
            else if (!this.rbtnKeyword.Checked && !this.rbtnKeywordsTime.Checked && this.rbtnTime.Checked)
            {
                if (!Validator.ValidateNumeric(time))
                {
                    MessageBox.Show("Time must be numeric only");
                    time = "0";
                }

                Keywords = null;
            }
            else if (!this.rbtnKeyword.Checked && this.rbtnKeywordsTime.Checked && !this.rbtnTime.Checked)
            {
                if (Keywords.Length == 0 && !Validator.ValidateAlphabetical(Keywords) && !Validator.ValidateNumeric(time))
                {
                    MessageBox.Show("Keyowrd must be text only and Time must be numeric only");
                    Keywords = null;
                    time = "0";
                }
            }
            else
            {
                Keywords = null;
                time = "0";
            }

            List<News> news = this.main.showTrending(Keywords, (long)Convert.ToInt32(time));
            //List<News> recentNews = news.ToList();
            if (news != null)
            {
                String datatoShow;
                News new_;//we are using stack to show the data from the new news to the older news with pop.
                for (int j = 0; j < news.Count; j++)
                {
                    new_ = news[j];

                    String keyword = "";
                    string[] Keywords_ = new_.Keywords;
                    for (int i = 0; i < Keywords_.Length; i++)
                    {
                        keyword = keyword + " " + Keywords_[i];
                    }

                    datatoShow = new_.ID + ":  Time: " + new_.Time + " Content: " + new_.Content + " Keywords: " + keyword + " Hits: " + new_.Hits;
                    lstNews.Items.Add(datatoShow);

                }

            }
            else
            {
                MessageBox.Show("There are not recent news");
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            
            var filteredList = new List<News>();

            if(cmbSearchBy.Text == "Id")
            {
                if(!Validator.ValidateNumeric(txtId.Text))
                {
                    MessageBox.Show("Id must be numeric only");
                    return;
                }

                //Console.WriteLine(main.GetNewsById(1));

                RefreshDisplayList();

                // filteredList = listOfNews.Where
            }
            else if(cmbSearchBy.Text.Equals("Recent"))
            {
                this.RefreshDisplayList_news24();
            }
            else if (cmbSearchBy.Text.Equals("Trending"))
            {
                this.RefreshDisplayTrending_news24();
                //Trending
            }
        }

        private void txtKeywords_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void rbtnKeyword_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnKeyword.Checked)
            {
                txtKeywords.Enabled = true;
                txtTime.Enabled = false;
            }
        }

        private void rbtnTime_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnTime.Checked)
            {
                txtKeywords.Enabled = false;
                txtTime.Enabled = true;
            }
        }

        private void rbtnKeywordsTime_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnKeywordsTime.Checked)
            {
                txtKeywords.Enabled = true;
                txtTime.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtKeywords.Enabled = false;
            txtTime.Enabled = false;
            txtId.Enabled = false;
            rbtnKeyword.Enabled = false;
            rbtnKeywordsTime.Enabled = false;
            rbtnTime.Enabled = false;
        }

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearchBy.Text == "Id")
            {
                txtId.Enabled = true;
                txtKeywords.Enabled = false;
                txtTime.Enabled=false;
                rbtnKeyword.Enabled = false;
                rbtnKeywordsTime.Enabled = false;
                rbtnTime.Enabled = false;
                btnShow.Text = "SELECT";
            }
            else
            {
                txtId.Enabled = false;
                rbtnKeyword.Enabled = true;
                rbtnKeywordsTime.Enabled = true;
                rbtnTime.Enabled = true;
                btnShow.Text = "SHOW";

            }

           
        }
    }
}
