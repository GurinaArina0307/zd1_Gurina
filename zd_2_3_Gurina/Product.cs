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
        public decimal Price { get; set; }
        public string Name { get; set; }
        public decimal Count { get; set; }

        // конструктор
        public Product(string Name, decimal Price)
        {
            this.Name = Name;
            this.Price = Price;
            this.Count = Count;
        }

        // функция вывода информации
        public string GetInfo()
        {
            return $"Наименование: {Name}; Цена: {Price}";
        }
    }
}
