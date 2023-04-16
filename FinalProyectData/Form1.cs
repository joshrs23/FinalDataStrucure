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
                    String datatoShow = news.ID + ":  Time: " + news.Time + " Content: " + news.Content + " Keywords: " + news.Keywords + " Hits: " + news.Hits;
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
            string Keywords = this.txtKeywords.Text;
            string time = this.txtTime.Text;

            if (this.rbtnKeyword.Checked && !this.rbtnKeywordsTime.Checked && !this.rbtnTime.Checked)
            {
                if (Keywords.Length == 0 && !Validator.ValidateAlphabetical(Keywords))
                {
                    MessageBox.Show("Keyowrd must be text only");
                    Keywords = null;
                }
            }
            else if (!this.rbtnKeyword.Checked && !this.rbtnKeywordsTime.Checked && this.rbtnTime.Checked)
            {
                if (!Validator.ValidateNumeric(time))
                {
                    MessageBox.Show("Time must be numeric only");
                    time = "0";
                }
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

            this.main.lastNews(Keywords,(long)Convert.ToInt64(time));
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
