using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7Task
{
    class Library
    {
        public string _title;
        public string _author;
        public string _category;
        public string _type;
        public string Format, Size;

        public Library(string title, string author, string category, string type, string format, string size)
        {
            Title       = title;
            Author      = author;
            Category    = category;
            Type        = type;
            this.Format = format;
            this.Size   = size;
        }
        virtual public string GetData()
        {
            return $"{Type};{Title};{Author};{Category};{Format};{Size}";
        }
        public Library(string data)
        {
            string[] splitedData = data.Split(';');
            Type     = splitedData[0];
            Title    = splitedData[1];
            Author   = splitedData[2];
            Category = splitedData[3];
            Format   = splitedData[4];
            Size     = splitedData[5];
             

        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }


        public string Title
        {
            get { return _title; }
            set
            {
                if ((value.Length > 0) && (!string.IsNullOrEmpty(value.Trim())))
                {
                    _title = value.Trim();

                }
                else
                {
                    MessageBox.Show("Title of the book should not be empty.", " worning!");
                }

            }
        }

        public string Author
        {
            get { return _author; }

            set
            {
                if ((value.Length > 0) && (!string.IsNullOrEmpty(value.Trim())))
                {
                    _author = value.Trim();
                }
                else
                {
                    MessageBox.Show("Title of the book should not be empty.", " worning!");
                }
            }
        }

        public string Category
        {
            get { return _category; }

            set
            {
                if ((value.Length > 0) && (!string.IsNullOrEmpty(value.Trim())))
                {
                    _category = value.Trim();
                }
                else
                {
                    MessageBox.Show("Category should not be empty.");
                }
            }
        }

    }
}
