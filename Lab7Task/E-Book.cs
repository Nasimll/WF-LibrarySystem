using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7Task
{
     class E_Book: Library
    {
        public string _format;     //Format,
        public string _fileSize; //File size.

        public E_Book(string title, string author, string category, string format, string fileSize) : base(title, author, category, "E-Book", format, fileSize)
        {
            Format = format;
            FileSize = fileSize;
        }

        public override string GetData()
        {
            return $"{Type};{Title};{Author};{Category};{Format};{FileSize}";
        }
        public string Format
        {
            get { return _format; }
            set
            {
                if ((value.Length > 0) && (!string.IsNullOrEmpty(value.Trim())))
                {
                    _format = value.Trim();

                }
                else
                {
                    throw new ArgumentException("Format of the book can not be empty !.");
                }

            }
        }

        public string FileSize
        {
            get { return _fileSize; }

            set
            {
                if ((value.Length > 0) && (!string.IsNullOrEmpty(value.Trim())))
                {
                    _fileSize = value.Trim();
                }
                else
                {
                    throw new Exception("Size of the file can not be empty !. ");
                }
            }
        }
    }
}
