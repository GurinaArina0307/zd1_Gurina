using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd_2_3_Gurina
{
    class Product
    {
        // св-ва
        public string Name { get; set; }
        public decimal Price { get; set; }

        // конструктор
        public Product(string Name, decimal Price)
        {
            this.Name = Name;
            this.Price = Price;

        }

        // функция вывода информации
        public string GetInfo()
        {
            return $"Наименование: {Name}; Цена: {Price}";
        }
    }
}
