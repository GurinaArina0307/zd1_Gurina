using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd_2_3_Gurina
{
    class Shop
    {
        private Dictionary<Product, int> products;
        public decimal Profit { get; set; }

        public Shop()
        {
            products = new Dictionary<Product, int>();
        }

        public void AddProduct(Product product, int count)
        {
            products.Add(product, count);
        }

        // метод создает и добавляет товар
        public void CreateProduct(string name, decimal price, decimal count)
        {
            products.Add(new Product(name, price), (int)count);
        }

        // метод для продажи товаров
        public void Sell(string ProductName)
        {
            Product ToSell = FindByName(ProductName);
            if (ToSell != null)
            {
                //this.Sell(ToSell);
            }
            else
            {
                Console.WriteLine("Товар не найден!");
            }
        }

        public Product FindByName(string name)
        {
            foreach (var product in products.Keys)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }
            return null;
        }

        public List<Info> GetProducts()
        {
            List<Info> result = new List<Info>();
            
            foreach (var c in products)
            {
                result.Add(new Info
                {
                    Name = c.Key.Name,
                    Price = c.Key.Price,
                    Count = c.Key.Count
                });
            }
            return result;
        }

        public class Info
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Count { get; set; }
        }
    }
}
