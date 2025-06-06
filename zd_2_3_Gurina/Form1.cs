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
        private PlayList playList = new PlayList();
        public Menu()
        {
            InitializeComponent();
            // добавление столбцов
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Column 1", "Название товара");
            dataGridView1.Columns.Add("Column 2", "Цена товара");
            dataGridView1.Columns.Add("Column 3", "Кол-во товара");

            
        }

        // кнопка добавления продуктов
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // проверка названия
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

                // проверка цены
                decimal priceProd = numericPrice.Value;
                if (priceProd == 0 || priceProd > 1000000)
                {
                    MessageBox.Show("Цена и кол-во должны быть больше 0", "Подсказка");
                    return;
                }
                else
                {
                    priceProd = numericPrice.Value;
                }

                // проверка кол-ва
                decimal countProd = numericCount.Value;
                if (countProd== 0 || countProd > 1000)
                {
                    MessageBox.Show("Цена и кол-во должны быть больше 0", "Подсказка");
                    return;
                }
                else
                {
                    countProd = numericCount.Value;
                }


                Clear();
                shop.CreateProduct(nameProd, priceProd, (int)countProd);
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

            foreach (var info in shop.DictProd())
            {
                dataGridView1.Rows.Add(info.Key.Name, info.Key.Price, info.Value);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count == 0 || dataGridView1.CurrentCell.RowIndex < 0)
                {
                    MessageBox.Show($"Необходимо выбрать товар для продажи!", "Подсказка");
                    return;
                }

                //
                if (shop.Sell(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()))
                {
                    dataGridView1.Rows.Clear();
                    List<Product> delet = new List<Product>();

                    foreach (var pr in shop.DictProd())
                    {
                        if (pr.Value > 0) ProductToGrid();
                        else  delet.Add(pr.Key); 
                    }

                    ProductToGrid();
                    label4.Text = $"Прибыль : {shop.Profit} руб.";

                }
                else
                {
                    MessageBox.Show("Ошибка!");
                    return;
                }

                ProductToGrid();
                label4.Text = $"Прибыль : {shop.Profit} руб.";

            }
            catch (Exception)
            {
                MessageBox.Show($"Неверный ввод!", "Ошибка");
            }
        }

        private void плейлистToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            //listBoxSongs.AddSong(textBox2.Text, textBox3.Text);
        }


    }
}
