using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd1_Gurina
{
    class Cat
    {
        private string name;
        private double ves;

        // св-во имени
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                bool OnlyLetters = true;

                foreach (var ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        OnlyLetters = false;
                    }
                }

                if (OnlyLetters)
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine($"{value} - неправильное имя!!!");
                }
            }
        }

        // св-во веса
        public double Ves
        {
            get
            {
                return ves;
            }
            set
            {
                if (value > 0)
                {
                    ves = value;
                }
                else
                {
                    Console.WriteLine($"{value} - вес неверный!!!");
                }
            }
        }

        //конструктор 
        public Cat (string CatName, double VesCat)
        {
            Name = CatName;
            Ves = VesCat;
        }

        // функция вывода информации
        public void Meow()
        {
            if(!(name == null))
            {
                if (!(ves == 0))
                {
                    Console.WriteLine($"{name}: МЯУ!!!");
                    Console.WriteLine($"Вес кота: {ves}!");
                }
            }
            
        }


    }
}
