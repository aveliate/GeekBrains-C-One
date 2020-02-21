using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Homework2
{
    /// <summary>
    /// Управление графикой и навигацией консоли
    /// </summary>
    public static class Draw
    {  
        /// <summary>
        /// Устанавливает базовые параметры для программы
        /// </summary>
        /// <param name="Title">Заголовок для окна консоли</param>
        public static void StartUp(string Title)
        {
            Console.CursorVisible = false;
            Console.Title = Title;
            Console.SetBufferSize(Console.LargestWindowWidth - 20, Console.LargestWindowHeight - 20);
            Console.SetWindowSize(Console.LargestWindowWidth - 20, Console.LargestWindowHeight - 20);
        }

        /// <summary>
        /// Вызывает подобие диалогового окна для ввода
        /// </summary>
        /// <param name="Text">Заголовок окна</param>
        /// <param name="Prompt">Строка запроса ввода</param>
        /// <returns>Отдаёт строку</returns>
        public static string DialogBox(string Text, string Prompt)
        {
            string onto = "  Введите ответ, и нажмите клавишу Enter.  ";
            int menuWidth = 80;
            string clean = new string(' ', menuWidth);

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition((Console.WindowWidth - menuWidth) / 2, 16);
            Print(16, clean);
            Print(18, clean);
            Print(17, clean);
            Print(16, Text);
            Print(18, onto);
            Console.SetCursorPosition((Console.WindowWidth - 3 - Prompt.Length) / 2, 17);
            Console.Write(Prompt);
            string reply = Console.ReadLine();
            Console.ResetColor();
            Console.Clear();
            return reply;
        }

        
        /// <summary>
        /// Вывод строки по центру экрана
        /// </summary>
        /// <param name="Line">Строка для вывода. Если 0, просто печатаем дальше.</param>
        /// <param name="Text">Текст для выведения.</param>
        public static void Print(int Line, string Text)
        {
            if (Line == 0) //проверяем, дали ли нам указатель на линию. Если дали 0, просто спускаемся дальше.
            {
                Console.SetCursorPosition(((Console.WindowWidth - (Text.Length)) / 2), Console.CursorTop);
            }
            else
            { Console.SetCursorPosition(((Console.WindowWidth - Text.Length) / 2), Line); }

            Console.WriteLine(Text);
        }

        /// <summary>
        /// Функция печати меню - в зависимости от функции, с указанием выбранного пункта.
        /// </summary>
        /// <param name="MenuType">Номер меню: определяет, какое меню выводить (см.описание).</param>
        /// <param name="Choice">Переменная, указывающая активный пункт меню.</param>
        /// <param name="Current">Номер пункта, печатаемого сейчас.</param>
        /// <param name="Text">Текст для выведения.</param>
        public static void MSelect(int MenuType, int Choice, int Current, string Text)
        {
            ConsoleColor Recall1 = Console.ForegroundColor;
            ConsoleColor Recall2 = Console.BackgroundColor;

            //MenuType
            //1 - Главное меню. 2 - Настройки. 3 - Горизонтальное меню. 4 - Сортировка

            switch (MenuType)
            {
                case 1:
                    if (Choice != Current) { Print(0, Text); }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Print(0, Text);
                        Console.ForegroundColor = Recall1;
                        Console.BackgroundColor = Recall2;
                    }
                    break;
                case 2:
                    Console.SetCursorPosition(5, Console.CursorTop);
                    if (Choice != Current) { Console.WriteLine(Text); }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine(Text);
                        Console.ForegroundColor = Recall1;
                        Console.BackgroundColor = Recall2;
                    }
                    break;
                case 3:
                    Console.SetCursorPosition((2 + Current * 18), 20);
                    if (Choice != Current) { Console.Write(Text, 30); }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write(Text, 30);
                        Console.ForegroundColor = Recall1;
                        Console.BackgroundColor = Recall2;
                    }
                    break;
                case 4:
                    Console.SetCursorPosition((38), 21+Current);
                    if (Choice != Current) { Console.Write(Text, 20); }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write(Text, 20);
                        Console.ForegroundColor = Recall1;
                        Console.BackgroundColor = Recall2;
                    }
                    break;

                default:
                    break;
            }
        }


        /// <summary>
        /// Функция управления главным меню.
        /// </summary>
        /// <param name="Header">Массив строк - заголовков для вывода вверху страницы.</param>
        /// <param name="Itemset">Перечень пунктов меню.</param>
        public static int MainMenu(string[] Header, string[] Itemset)
        {
            int Choice = 0;

            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Print(1, Header[0]);
            Console.ForegroundColor = defaultColor;

            for (int x = 1; x < (Header.Length); x++)
            {
                Print(1 + x, Header[x]);
            }
            Console.WriteLine("");
            Console.WriteLine("");

            while (true)
            {
                Console.SetCursorPosition(1, 7);
                for (int i = 0; i < (Itemset.Length); i++)
                {
                    MSelect(1, Choice, i, Itemset[i]);
                }
                Console.WriteLine("");
                MSelect(1, Choice, Itemset.Length, "Выход");

                ConsoleKeyInfo InKey = Console.ReadKey();

                if (InKey.Key == ConsoleKey.UpArrow) { if (Choice > 0) { Choice--; } }     //Выбираем верхний вариант, если он есть.
                if (InKey.Key == ConsoleKey.DownArrow) { if (Choice < Itemset.Length) { Choice++; } }   //Выбираем нижний вариант, если он есть.

                if (InKey.Key == ConsoleKey.Enter) return Choice;
                
            }
        }
        
    }

    ///Класс точка с двумя координатами и функцией запроса
    public class Dot
    {
        public int x;

        public int y;

        string number;

        public Dot(int xIn, int yIn)
        {
            this.x = xIn;
            this.y = yIn;
        }

        public Dot(string number)
        {
            string xIn, yIn;
            this.number = number;

            do
            {
                xIn = Draw.DialogBox("Введите координату X "+ number +" точки:", "");
            } while (!Int32.TryParse(xIn, out this.x));

            do
            {
                yIn = Draw.DialogBox("Введите координату Y " + number + " точки:", "");
            } while (!Int32.TryParse(yIn, out this.y));
        }

    }



}



