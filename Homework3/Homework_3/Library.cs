using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Homework_3
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

        public static void ColorPrint(int lineNum, string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Print(lineNum, msg);
            Console.ResetColor();
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
                    Console.SetCursorPosition((38), 21 + Current);
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
        /// Функция печати меню справа управления матрицами.
        /// </summary>
        /// <param name="Text">Текст для выведения.</param>
        public static int MatMenu(string[] Text)
        {
            ConsoleColor Recall1 = Console.ForegroundColor;
            ConsoleColor Recall2 = Console.BackgroundColor;
            int Choice = 0;


            while (true)
            {
                int e = 0;
                for (e = 0; e < Text.Length; e++)
                {
                    Console.SetCursorPosition(75, (6 + e));
                    if (Choice != e) { Console.Write(Text[e], 30); }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write(Text[e], 30);
                        Console.ForegroundColor = Recall1;
                        Console.BackgroundColor = Recall2;
                    }
                }

                Console.SetCursorPosition(75, (6 + e));
                if (Choice != e) { Console.Write("Выход", 30); }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write("Выход", 30);
                    Console.ForegroundColor = Recall1;
                    Console.BackgroundColor = Recall2;
                }

                ConsoleKeyInfo InKey = Console.ReadKey();

                if (InKey.Key == ConsoleKey.UpArrow) { if (Choice > 0) { Choice--; } }     //Выбираем верхний вариант, если он есть.
                if (InKey.Key == ConsoleKey.DownArrow) { if (Choice < Text.Length) { Choice++; } }   //Выбираем нижний вариант, если он есть.

                if (InKey.Key == ConsoleKey.Enter) return Choice;
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

        /// <summary>
        /// Функция обозначения ошибки.
        /// </summary>
        /// <param name="error">Текст описания ошибки</param>
        public static void SummonError(string error)
        {
            string onto = "  Нажмите любую клавишу...  ";
            string clean = new string(' ', (error.Length > onto.Length ? error.Length : onto.Length));

            Console.SetCursorPosition((Console.WindowWidth - error.Length) / 2, 16);
            Highlight(error);
            Console.SetCursorPosition((Console.WindowWidth - onto.Length) / 2, 17);
            Highlight(onto);
            Console.ReadKey();
            Console.SetCursorPosition((Console.WindowWidth - error.Length) / 2, 16);
            Console.Write(clean);
            Console.SetCursorPosition((Console.WindowWidth - onto.Length) / 2, 17);
            Console.Write(clean);

        }

        /// <summary>
        /// Функция подсветки текста красным.
        /// </summary>
        /// <param name="Text">Текст для подсветки</param>
        public static void Highlight(string Text)
        {
            ConsoleColor Recall1 = Console.ForegroundColor;
            ConsoleColor Recall2 = Console.BackgroundColor;

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write(Text);
            Console.ForegroundColor = Recall1;
            Console.BackgroundColor = Recall2;
        }

        /// <summary>
        /// Функция уведомления о результате операции.
        /// </summary>
        /// <param name="text">Текст для выведения снизу и по центру</param>
        public static void Notify(string text)
        {
            ConsoleColor Recall1 = Console.ForegroundColor;
            ConsoleColor Recall2 = Console.BackgroundColor;
            string onto = "  Нажмите любую клавишу...  ";
            string clean = new string(' ', text.Length);

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, 16);
            Console.Write(text);
            Console.SetCursorPosition((Console.WindowWidth - onto.Length) / 2, 17);
            Console.Write(onto);
            Console.ForegroundColor = Recall1;
            Console.BackgroundColor = Recall2;
            Console.ReadKey();
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, 16);
            Console.Write(clean);
            Console.SetCursorPosition((Console.WindowWidth - onto.Length) / 2, 17);
            Console.Write(clean);
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

    /// <summary>
    /// Простая дробь
    /// </summary>
    public class Fraction
    {
        //Числитель и знаменатель дроби
        private int numerator;

        private int denominator;

        /// <summary>
        /// Выдача значений дроби для операций с ними.
        /// </summary>
        /// <param name="num">Числитель</param>
        /// <param name="den">Знаменатель</param>
        public void ShowFraction(out int num, out int den)
        {
            num = this.numerator;
            den = this.denominator;
        }

        /// <summary>
        /// Перечень операторов для дроби
        /// </summary>
        public enum Operator
        { Add, Subtract, Multiply, Divide}

        /// <summary>
        /// Конструктор дроби с заданными значениями.
        /// </summary>
        /// <param name="Num">Числитель</param>
        /// <param name="Den">Знаменатель</param>
        public Fraction(int Num, int Den)
        {
            this.numerator = Num;
            if (Den != 0) this.denominator = Den;
                else this.denominator = 1;
        }

        /// <summary>
        /// Конструктор дроби из двух случайных значений от 1 до 100.
        /// </summary>
        /// <param name="rnd">Объект типа Random - чтобы не наделать одинаковых дробей</param>
        public Fraction(Random rnd)
        {
            Initialize(rnd);
        }

        /// <summary>
        /// Рандомизатор дроби.
        /// </summary>
        /// <param name="rnd">Объект типа Random</param>
        public void Initialize(Random rnd)
        {
            int a = rnd.Next(1, 101);
            int b = rnd.Next(1, 101);
            if (a > b)
            {
                this.denominator = a;
                this.numerator = b;
            }
            else //Если чудом получилось целое число, то нам просто крупно повезло и пусть будет.
            {
                this.denominator = b;
                this.numerator = a;
            }
        }

        /// <summary>
        /// Конструктор дроби с умножением на целое число
        /// </summary>
        /// <param name="A">Дробь</param>
        /// <param name="B">Целое число</param>
        public Fraction(Fraction A, int B)
        {
            A.ShowFraction(out int num, out int den);
            this.numerator = num * B;
            this.denominator = den;
            this.Simplify();
        }

        /// <summary>
        /// Конструктор дроби с использованием двух других.
        /// </summary>
        /// <param name="A">Дробь №1 (А)</param>
        /// <param name="B">Дробь №2 (B)</param>
        /// <param name="command">Команда из перечня для определения операции</param>
        public Fraction(Fraction A, Fraction B, Operator command)
        {
            A.ShowFraction(out int numA, out int denA);
            B.ShowFraction(out int numB, out int denB);
            switch(command)
            {
                case Operator.Add:
                    this.numerator = numA * denB  + numB*denA;
                    this.denominator = denA * denB;
                    break;
                case Operator.Subtract:
                    this.numerator = numA * denB - numB * denA;
                    this.denominator = denA * denB;
                    break;
                case Operator.Multiply:
                    this.numerator = numA * numB;
                    this.denominator = denA * denB;
                    break;
                case Operator.Divide:
                    this.numerator = numA * denB;
                    this.denominator = denA * numB;
                    break;
            }
            this.Simplify();
        }

        /// <summary>
        /// Алгоритм Евклида для поиска наибольшего общего делителя.
        /// </summary>
        /// <param name="num">Числитель</param>
        /// <param name="den">Знаменатель</param>
        /// <returns>НОД - наибольший общий делитель</returns>
        private int GCD(int num, int den)
        {
            int xchange;

            num = Math.Abs(num);
            den = Math.Abs(den);

            while (den != 0 && num != 0)
            {
                if (num % den != 0)
                {
                    xchange = num;
                    num = den;
                    den = xchange % den;
                }
                else break;
            }
                if (den != 0 && num != 0) return den;
                return 1;
        }

        /// <summary>
        /// Упрощает эту дробь
        /// </summary>
        private void Simplify()
        {
            int greatCD = GCD(this.numerator, this.denominator);
            this.numerator /= greatCD;
            this.denominator /= greatCD;

            //Оставляем знак только у числителя...
            if ((this.numerator < 0 && this.denominator < 0) ||
                (this.numerator > 0 && this.denominator < 0))
            { this.numerator *= -1; this.denominator *= -1; }
        }

        /// <summary>
        /// Возвращает строковый вид дроби
        /// </summary>
        /// <returns>Строка вида "1", "1 1/2", "1/2"</returns>
        public override string ToString()
        {
            string sign = (this.numerator >= 0 ? "" : "-");
            int whole = Math.Abs(this.numerator / this.denominator);
            int totalNumenator = Math.Abs(this.numerator) - whole * this.denominator;
            if (totalNumenator != 0 && whole != 0)
                return $"{sign}{whole} целых и {totalNumenator}/{this.denominator}";
            else if (totalNumenator == 0) return $"{sign}{whole} целых";
            else return $"{this.numerator}/{this.denominator}";
        }

        /// <summary>
        /// Возвращает строковый вид дроби без "вытаскивания" целых частей
        /// </summary>
        /// <returns>Строковый вид дроби</returns>
        public string ToStringTrue()
        {
            return $"{this.numerator}/{this.denominator}";
        }
    }


}



