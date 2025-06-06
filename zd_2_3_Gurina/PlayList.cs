using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd_2_3_Gurina
{
    class PlayList
    {
        private List<Song> list;
        private int currentIndex;

        //конструктор, поля для списка композиций и индеса текущей песни
        public PlayList()
        {
            list = new List<Song>();
            currentIndex = -1; //плейлист пуст
        }

        //Метод для получения текущей аудиозаписи
        public Song CurrentSong()
        {
            if (list.Count > 0)
                return list[currentIndex];
            else
                throw new IndexOutOfRangeException("Невозможно получить текущую аудиозапись для пустого плейлиста!");
        }

        // св-во кол-ва песен
        public int CountSongs => list.Count;

        // метод добавления песни перегрузка 1
        public void AddSong(string author, string title)
        {
            list.Add(new Song(author, title));

            if (currentIndex == -1) currentIndex = 0;

        }

        // метод добавления песни перегрузка 2
        public void AddSong(Song song)
        {
            list.Add(song);
            if (currentIndex == -1) currentIndex = 0;
        }

        // метод для перехода к следующей песне
        public bool Next()
        {
            if (list.Count == 0) return false;

            currentIndex++;

            // переход с учетом границ массива
            if (currentIndex >= list.Count)
            {
                currentIndex = 0;
            }

            return true;
        }

        // метод для перехода к предыдущей песне
        public bool Previous()
        {
            if (list.Count == 0) return false;

            currentIndex--;

            // переход с учетом границ массива
            if (currentIndex > 0)
            {
                currentIndex = list.Count - 1;
            }

            return true;
        }

        // преход к песне по индексу
        public bool GoToIndex(int index)
        {
            if (index >= 0 && index <= list.Count)
            {
                currentIndex = index;
                return true;
            }
            return false;
        }

        // вызврат в начало списка
        public void GoToStart()
        {
            if (list.Count > 0)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex = -1;
            }
        }

        // удаление песни по индексу перегрузка 1
        public bool RemoveSong(int index)
        {
            if (index  >= 0 && index < list.Count)
            {
                list.RemoveAt(index);

                if (list.Count == 0)
                {
                    currentIndex = -1;
                }
                else if (currentIndex >= index && currentIndex > 0)
                {
                    currentIndex--;
                }
                else if (currentIndex >= list.Count)
                {
                    currentIndex = list.Count - 1;
                }

                return true;
            }
            return false;
        }

        // удаление песни по индексу перегрузка 2
        public bool RemoveSong(Song song)
        {
            int index = list.FindIndex(s => s.Author == list.Author && s.Title == list.Title);

            if (index >= 0)
            {
                return RemoveSong(index);
            }
            return false;
        }

        // Загрузка плейлиста из файла
        //public void LoadFromFile(string filename)
        //{
        //    Clear();

        //    try
        //    {
        //        foreach (var line in lines)
        //        {
        //            var parts = line.Split('|');
        //            if (parts.Length == 3)
        //            {
        //                AddSong(parts[0], parts[1], parts[2]);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Ошибка загрузки плейлиста: " + ex.Message);
        //    }
        //}

        // Выгрузка плейлиста в файл
        //public void SaveToFile(string filename)
        //{
        //    try
        //    {
        //        var lines = list.Select(s => $"{s.Author}|{s.Title}");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Ошибка сохранения плейлиста: " + ex.Message);
        //    }
        //}

        // Очистка плейлиста
        public void Clear()
        {
            list.Clear();
            currentIndex = -1;
        }

        // Получение списка песен для отображения в ListBox
        public List<string> GetSongList()
        {
            return list.Select(s => s.ToString()).ToList();
        }
    }
}

