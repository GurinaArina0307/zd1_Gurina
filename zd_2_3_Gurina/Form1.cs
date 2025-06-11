using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zd_2_3_Gurina
{
    public partial class Menu : Form
    {
        private Shop shop = new Shop();


        private PlayList playList = new PlayList();
        public string nameFile = "Play_List.txt";
         
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






        // ПЛЕЙЛИСТ


        // обновление данных
        private void UpdateListBox()
        {
            listBoxSongs.DataSource = null;
            listBoxSongs.DataSource = playList.GetSongList();

            if (playList.CountSongs > 0 && playList.CurrentIndex >= 0)
            {
                listBoxSongs.SelectedIndex = playList.CurrentIndex;
                UpdateLabel();
            }
            else
            {
                label7.Text = $"Нет текущей песни.";
            }
        }

        private void UpdateLabel()
        {
            try
            {
                Song current = playList.CurrentSong();
                label7.Text = $" Текущая песня: {current}";
            }
            catch
            {
                label7.Text = $"Нет текущей песни.";
            }
        }

        // добавление песни
        private void button3_Click(object sender, EventArgs e)
        {
            bool result = playList.AddSong(textBox2.Text, textBox3.Text);

            if (!result)
            {
                MessageBox.Show("Не удалось добавить песню!", "Ошибка");
            }
            else
            {
                UpdateListBox();
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        // кнопка перехода к следующей песне
        private void button8_Click(object sender, EventArgs e)
        {
            playList.Next();
            UpdateListBox();
        }

        // кнопка перехода к предыдущей песне
        private void button7_Click(object sender, EventArgs e)
        {
            playList.Previous();
            UpdateListBox();
        }

        // удаление песни по индексу
        private void button5_Click(object sender, EventArgs e)
        {
            if (listBoxSongs.SelectedIndex >= 0)
            {
                playList.RemoveSong(listBoxSongs.SelectedIndex);
                UpdateListBox();
            }
        }

        //кнопка выгрузки из файла
        private void button10_Click(object sender, EventArgs e)
        {
            string fileName = textBox4.Text.Trim();
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                try
                {
                    playList.LoadFromFile(fileName);
                    UpdateListBox();
                    MessageBox.Show("Файл выгружен", "Успех");
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                catch(FileNotFoundException ex)
                {
                    MessageBox.Show($"Файл <{fileName}> не найден!");
                }
                
            }
            else
            {
                MessageBox.Show("Укажите название файла");
                return;
            }
        }

        // сохранение в файл
        private void button9_Click(object sender, EventArgs e)
        {
            string fileName = textBox4.Text.Trim();
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                playList.SaveToFile(fileName);
                MessageBox.Show("Файл сохранен", "Успех");
                textBox3.Text = "";
                textBox4.Text = "";
            }
            else
            {
                MessageBox.Show("Укажите название файла");
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            playList.Clear();
            UpdateListBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBoxSongs.SelectedIndex >= 0)
            {
                // Получаем выбранную строку из ListBox
                string selectedSong = listBoxSongs.SelectedItem.ToString();

                var parts = selectedSong.Split(new[] { " - " }, StringSplitOptions.None);

                if (parts.Length > 0)
                {
                    // Создаем объект Song для удаления
                    Song songToRemove = new Song(parts[0], parts[1]);

                    bool removed = playList.RemoveSong(songToRemove);

                    if (removed)
                    {
                        UpdateListBox();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось найти песню для удаления", "Ошибка");
                    }
                }
            }
        }

    }
}
