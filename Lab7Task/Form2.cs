using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab7Task
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Paper Book")//Paper Book, E - Book ,Audio Book
            {
                groupBox3.Enabled = false;
                groupBox2.Enabled = false;
                groupBox1.Enabled = true;
            }
            else if(comboBox1.SelectedItem.ToString() == "E-Book")
            {
                groupBox3.Enabled = false;
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Paperbook pb = new Paperbook(tbTitle.Text, tbAuthor.Text, tbCategory.Text, tbISBN.Text, tbPages.Text);

               FileStream fs = new FileStream("Books.txt", FileMode.Append, FileAccess.Write);
               StreamWriter sw = new StreamWriter(fs);
               sw.WriteLine(pb.GetData());

               sw.Close();
               fs.Close();
               ClearBox();
               MessageBox.Show("The new Paper Book has been added to the database. ", "information");
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            E_Book eb = new E_Book(tbTitle.Text, tbAuthor.Text, tbCategory.Text, tbFormat.Text, tbFileSize.Text);

            FileStream fs = new FileStream("Books.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(eb.GetData());

            sw.Close();
            fs.Close();
            ClearBox();
            MessageBox.Show("The new E_Book has been added to the database. ", "information");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Audiobook ab = new Audiobook(tbTitle.Text, tbAuthor.Text, tbCategory.Text, tbNarrator.Text, tbDuration.Text);

            FileStream fs = new FileStream("Books.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(ab.GetData());

            sw.Close();
            fs.Close();
            ClearBox();
            MessageBox.Show("The new Audio Book has been added to the database. ", "information");
        }

        private void ClearBox()
        {
            tbTitle   .Clear();
            tbAuthor.  Clear();
            tbCategory.Clear();
            tbISBN.    Clear();
            tbDuration.Clear();
            tbPages.   Clear();
            tbFileSize.Clear();
            tbFormat.  Clear();
            tbNarrator.Clear();
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
