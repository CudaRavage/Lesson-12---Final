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

namespace Lesson12_Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UpdateMovies();
        }

        public void UpdateTextBox()
        {
            if (File.Exists("movies.txt") == false)
            {
                StreamWriter addNew = File.AppendText("movies.txt");
                addNew.Close();
            }
            string movies;
            StreamReader showData = new StreamReader("movies.txt");
            movies = showData.ReadToEnd();
            txtBoxList.Text = movies;
            showData.Close();
        }

        public void UpdateMovies()
        {
            StreamWriter addNew = File.AppendText("movies.txt");
            string addTitle = Convert.ToString(txtBoxTitle.Text);
            string addRating = Convert.ToString(txtBoxRating.Text);
            addNew.WriteLine(addTitle + "   :Rating:  " + addRating);
            addNew.Close();
            txtBoxTitle.Text = null;
            txtBoxRating.Text = null;
            UpdateTextBox();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTextBox();
        }
    }
}
