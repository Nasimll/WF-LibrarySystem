using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace Lab7Task
{
    class Paperbook: Library
    {
        public string   _isbn;    //ISBN,
        public string _noPages; // Number of pages.

        public Paperbook(string title, string author, string category, string isbn, string noPages): base(title, author, category,"Paper Book" , isbn, noPages)
        {
            ISBN = isbn;
            NoPages = noPages;
        }
        public override string GetData()
        {
            return  $"{Type};{Title};{Author};{Category};{ISBN};{NoPages}";
        }


        public string ISBN
        {
            get { return _isbn; }
            set
            {
                if ((value.Length > 0) && (!string.IsNullOrEmpty(value.Trim())))
                {
                    _isbn = value.Trim();

                }
                else
                {
                    throw new ArgumentException("ISBN of the book should not be empty.");
                }

            }
        }

        public string NoPages
        {
            get { return _noPages; }

            set
            {_noPages = value;}
        }
    }
}
