using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zd_2_3_Gurina
{
    public partial class Menu : Form
    {
        private Shop shop = new Shop();
        public Menu()
        {
            InitializeComponent();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Column 1", "Название товара");
            dataGridView1.Columns.Add("Column 2", "Цена товара");
            dataGridView1.Columns.Add("Column 3", "Кол-во товара");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nameProd = textBox1.Text;
                foreach (char c in nameProd)
                {
                    bool letter = true;
                    if (!char.IsLetter(c))
                    {
                        letter = false;
                        MessageBox.Show("Поле название должно содержать только буквы!", "Ошибка");
                        return;
                    }

                    if (letter)
                    {
                        nameProd = textBox1.Text;
                    }
                }
                if (string.IsNullOrEmpty(nameProd))
                {
                    MessageBox.Show("Необходимо заполнить все поля!", "Ошибка");
                    return;
                }

                decimal priceProd = numericPrice.Value;
                if (priceProd == 0 || priceProd > 1000000)
                {
                    MessageBox.Show("Цена и кол-во должны быть больше 0", "Подсказка");
                    return;
                }

                decimal countProd = numericCount.Value;
                if (countProd== 0 || countProd > 100)
                {
                    MessageBox.Show("Цена и кол-во должны быть больше 0", "Подсказка");
                    return;
                }


                Clear();
                shop.CreateProduct(nameProd, priceProd, countProd);
                ProductToGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка!");
            }
           
        }

        public void Clear()
        {
            textBox1.Clear();
            numericPrice.Value = 0;
            numericCount.Value = 0;

        }

        public void ProductToGrid()
        {
            dataGridView1.Rows.Clear();

            foreach (var info in shop.GetProducts())
            {
                dataGridView1.Rows.Add(info.Name, info.Price, info.Count);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Необходимо выбрать строку для продажи!", "Подсказка");
                    return;
                }

                string nameProduct = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                shop.Sell(nameProduct);
                ProductToGrid();
                label4.Text = $"Прибыль : {shop.Profit} руб.";

            }
            catch (Exception)
            {
                MessageBox.Show($"Неверный ввод!", "Ошибка");
            }
        }
    }
}
