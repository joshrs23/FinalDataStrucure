using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace FinalProyectData
{
    public partial class Form1 : Form
    {
        private String PathJson = @"../../MOCK_DATA.json";
        private String JsonToString;
        private dynamic data;

        public Form1()
        {
            InitializeComponent();
            JsonToString = File.ReadAllText(PathJson);
            data = JsonSerializer.Deserialize<dynamic>(JsonToString);
            List<News> news = JsonSerializer.Deserialize<List<News>>(JsonToString);

            Console.WriteLine(data[0]);
        }
    }
}
