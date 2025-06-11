using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd_2_3_Gurina
{
    public struct Song
    {
        public string Author { get; set; }
        public string Title { get; set; }

        // конструктор
        public Song (string author, string title)
        {
            this.Author = author;
            this.Title = title;
        }

        // функция вывода информации
        public override string ToString()
        {
            return $"{Author} - {Title}";
        }
    }
}
