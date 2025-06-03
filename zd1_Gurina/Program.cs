using System;

namespace zd1_Gurina
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите имя кота: ");
                Console.WriteLine("Введите вес кота: ");

                Cat newCat = new Cat(Console.ReadLine(), Convert.ToDouble(Console.ReadLine()));
                newCat.Meow();
            }
            catch(Exception)
            {
                Console.WriteLine($"Неверный ввод.");
            }
            
        }
    }
}
