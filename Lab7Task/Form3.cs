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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.LinkLabel;

namespace Lab7Task
{
    public partial class Form3 : Form
    {
        int indexLeft=0;
        int presnentIndex = 1;
        int TotalIndexOnFile = 1;
        bool Apply = false;
        int intal = 0;
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            //EnableDisableTBox(false);
            tbTitle.Enabled    = false;
            tbAuthor.Enabled   = false;
            tbCategory.Enabled = false;
            tbType.Enabled     = false;
            tbFormat.Enabled   = false;
            tbSize.Enabled     = false;
            button4.Enabled    = false;
            updateIndexer();
        }

        private void EnableDisableTBox(Boolean TrueFalse) 
        {
            tbTitle.Enabled    = TrueFalse;
            tbAuthor.Enabled   = TrueFalse;
            tbCategory.Enabled = TrueFalse;
            tbType.Enabled     = TrueFalse;
            tbFormat.Enabled   = TrueFalse;
            tbSize.Enabled     = TrueFalse;
            button4.Enabled    = TrueFalse;
        }

        private void updateIndexer()
        {
            ReadDataAndCreateLibrary(presnentIndex);
            
            for (int i = 1; i < RLTfile.libraries.Count; i++)
            {
                TotalIndexOnFile = i;
            }
            Labelindexer.Text = $"{presnentIndex}/{TotalIndexOnFile+1}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            presnentIndex -=1;
            
            if (presnentIndex <= indexLeft)
            {
                presnentIndex =1;
                button1.Enabled = false;
            }
            updateIndexer();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            presnentIndex +=1;
            updateIndexer();
            if (presnentIndex > TotalIndexOnFile)
            {
                button2.Enabled = false;
            }
        }
        private void DisplayLibraryOnTextBox(int y)
        {
            tbTitle.   Clear();
            tbAuthor.  Clear();
            tbCategory.Clear();
            tbType.    Clear();
            tbFormat.  Clear();
            tbSize.    Clear();

            tbTitle.Text    = RLTfile.libraries[y].Title;
            tbAuthor.Text   = RLTfile.libraries[y].Author;
            tbCategory.Text = RLTfile.libraries[y].Category;
            tbType.Text     = RLTfile.libraries[y].Type;
            tbFormat.Text   = RLTfile.libraries[y].Format;
            tbSize.Text     = RLTfile.libraries[y].Size;
        }
        
        private void WriteToListAndUpdate(int i)
        {
            
            Library lab = new Library(tbTitle.Text, tbAuthor.Text, tbCategory.Text, tbType.Text, tbFormat.Text, tbSize.Text);
            int indexer = i-1;
            FileStream fs3 = new FileStream("MyFile.txt", FileMode.Create, FileAccess.Write);
            FileStream fs4 = new FileStream("temp.txt", FileMode.Open, FileAccess.Read);
            StreamWriter sw2 = new StreamWriter(fs3);
            StreamReader sr2 = new StreamReader(fs4);

            RLTfile.libraries[indexer] = lab;
            for (int x = 0; x < RLTfile.libraries.Count; x++)
            {
                sw2.WriteLine (RLTfile.libraries[x].GetData());
            }
           

            sr2.Close();
            sw2.Close();
            fs4.Close();
            fs3.Close();
        }

        private void ReadDataAndCreateLibrary(int i)
        {
            RLTfile.libraries.Clear();
            int indexer = i- 1;
            FileStream fs = new FileStream("MyFile.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line;
            while (!sr.EndOfStream)
            {
                 line = sr.ReadLine();
                 Library l = new Library(line);
                 RLTfile.libraries.Add(l);
            }
            DisplayLibraryOnTextBox(indexer);
            sr.Close();
            fs.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            intal += 1;

            if(!Apply  & button3.Text == "Edit")
            {
                //EnableDisableTBox(true);
                tbTitle.Enabled = true;
                tbAuthor.Enabled = true;
                tbCategory.Enabled = true;
                tbType.Enabled = true;
                tbFormat.Enabled = true;
                tbSize.Enabled = true;
                button4.Enabled = true;
                Apply = true;
                button3.Text = "Apply";
                RLTfile.libraries.Clear();
                Library lab = new Library(tbTitle.Text, tbAuthor.Text, tbCategory.Text, tbType.Text, tbFormat.Text, tbSize.Text);
                FileStream fs1 = new FileStream("MyFile.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs1);
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    Library l = new Library(s);
                    RLTfile.libraries.Add(l);
                }
                sr.Close();
                fs1.Close();

            }

            if(Apply &(intal>=2) & button3.Text == "Apply")
            {
                WriteToListAndUpdate(presnentIndex);
                MessageBox.Show("The list has been edited !", "Message!");
                updateIndexer();
                //EnableDisableTBox(false);
                tbTitle.Enabled = false;
                tbAuthor.Enabled = false;
                tbCategory.Enabled = false;
                tbType.Enabled = false;
                tbFormat.Enabled = false;
                tbSize.Enabled = false;
                button4.Enabled = false;
                button3.Text = "Edit";
                Apply = false;
                intal = 0;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("You are about to delete this list! Do you still want to delete?", "Warning!", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {

                Library lab = new Library(tbTitle.Text, tbAuthor.Text, tbCategory.Text, tbType.Text, tbFormat.Text, tbSize.Text);

                FileStream fs1 = new FileStream("Books.txt", FileMode.Open, FileAccess.Read);
                FileStream fs2 = new FileStream("temp.txt", FileMode.Create, FileAccess.Write);
                StreamReader sr = new StreamReader(fs1);
                StreamWriter sw = new StreamWriter(fs2);

                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();

                    if (s != lab.GetData()) sw.WriteLine(s);
                }
                sw.Close();
                sr.Close();
                fs2.Close();
                fs1.Close();

                FileStream fs3 = new FileStream("Books.txt", FileMode.Create, FileAccess.Write);
                FileStream fs4 = new FileStream("temp.txt", FileMode.Open, FileAccess.Read);
                StreamWriter sw2 = new StreamWriter(fs3);
                StreamReader sr2 = new StreamReader(fs4);
                while (!sr2.EndOfStream)
                {
                    string s = sr2.ReadLine();
                    sw2.WriteLine(s);
                }
                sr2.Close();
                sw2.Close();
                fs4.Close();
                fs3.Close();
                tbTitle.Clear();
                tbAuthor.Clear();
                tbCategory.Clear();
                tbType.Clear();
                tbFormat.Clear();
                tbSize.Clear();
                MessageBox.Show("All the list has been deleted !", "Message!");
                updateIndexer();
                //EnableDisableTBox(false);
                tbTitle.Enabled = false;
                tbAuthor.Enabled = false;
                tbCategory.Enabled = false;
                tbType.Enabled = false;
                tbFormat.Enabled = false;
                tbSize.Enabled = false;
                button4.Enabled = false;
                button3.Text = "Edit";
                Apply = false;
                intal = 0;
            }
            else
            {
                Form1 f1 = new Form1();
                this.Hide();
                f1.ShowDialog();
                this.Close();
            }
        }
    }
}
