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
        //private List<News> listOfNews = 

        public Form1()
        {
            InitializeComponent();
            main = new Main();
            main.fill_All_data();

      
            
        }

        private void RefreshDisplayList()
        {
            lstNews.Items.Clear();


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

               // filteredList = listOfNews.Where
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
