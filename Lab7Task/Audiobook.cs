using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7Task
{
    class Audiobook: Library
    {
        public string _narrator;  //Narrator.,
        public string _duration; //Duration.

        public Audiobook(string title, string author, string category, string narrator, string duration) : base(title, author, category, "Audio Book", narrator, duration)
        {
            Narrator = narrator;
            Duration = duration;
        }

        public override string GetData()
        {
            return $"{Type};{Title};{Author};{Category};{Narrator};{Duration}";
        }


        public string Narrator
        {
            get { return _narrator; }
            set
            {
                if ((value.Length > 0) && (!string.IsNullOrEmpty(value.Trim())))
                {
                    _narrator = value.Trim();

                }
                else
                {
                    throw new ArgumentException("Format of the book can not be empty !.");
                }

            }
        }

        public string Duration
        {
            get { return _duration; }

            set
            {
                if ((value.Length > 0) && (!string.IsNullOrEmpty(value.Trim())))
                {
                    _duration = value.Trim();
                }
                else
                {
                    throw new Exception("Duration of the file can not be empty !. ");
                }
            }
        }
    }
}
