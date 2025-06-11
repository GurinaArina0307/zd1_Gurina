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
        public decimal Profit { get; private set; }

        // конструктор
        public Shop()
        {
            products = new Dictionary<Product, int>();
            Profit = 0;
        }


        // метод подсчета прибыли
        public void AddPrifit(Product product)
        {
            Profit += product.Price;
        }

        // добавление продуктов
        public void AddProduct(Product product, int count)
        {
            products.Add(product, count);
        }

        // метод создает и добавляет товар
        public void CreateProduct(string name, decimal price, int count)
        {
            products.Add(new Product(name, price), count);
        }

        // метод для продажи товаров по объекту
        public bool Sell(Product product)
        {
            if (products.ContainsKey(product))
            {
                if (products[product] == 0)
                {
                    return false;
                }
                else
                {
                    this.AddPrifit(product);
                    products[product]--;
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        // метод для продажи товаров по строке
        public bool Sell(string ProductName)
        {
            Product ToSell = FindByName(ProductName);
            if (ToSell != null)
            {
                this.Sell(ToSell);
                return true;
            }
            else
            {
                return false;
            }
        }

        // поиск продукта
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
                    Count = c.Value
                });
            }
            return result;
        }

        public class Info
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Count { get; set; }
        }

        // словарь
        public Dictionary<Product, int> DictProd()
        {
            return products;
        }
    }
}
