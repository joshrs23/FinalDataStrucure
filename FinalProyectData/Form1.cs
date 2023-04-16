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
            main.get_All_data();
            
        }

        private void btnShow_Click(object sender, EventArgs e)
        {

        }
    }
}
