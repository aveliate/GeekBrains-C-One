using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Homework_4
{
    #region Старое и графика

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

        /// <summary>
        /// Выбор файла в директории
        /// </summary>
        /// <param name="path">Путь к директории</param>
        /// <returns>Имя файла</returns>
        public static string SelectFile(string msg, string path)
        {
            string[] files = Directory.GetFiles(path, "*.csv");
            int choice = 0;
            bool looper = true;

            for (int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFileName(files[i]);
            }
            Console.Clear();

            Console.SetCursorPosition(25, 5);
            Console.WriteLine(msg);

            while (looper)
            {
                Console.SetCursorPosition(25, 7);
                for (int i = 0; i < (files.Length); i++)
                {
                    Draw.MSelect(2, choice, i, files[i]);
                }
                Console.WriteLine("");
                MSelect(2, choice, files.Length, "Выход");

                ConsoleKeyInfo InKey = Console.ReadKey();

                if (InKey.Key == ConsoleKey.UpArrow) { if (choice > 0) { choice--; } }     //Выбираем верхний вариант, если он есть.
                if (InKey.Key == ConsoleKey.DownArrow) { if (choice < files.Length) { choice++; } }   //Выбираем нижний вариант, если он есть.

                if (InKey.Key == ConsoleKey.Enter)
                {
                    if (choice >= 0 && choice < files.Length) { Notify("Выбран файл " + files[choice]); Console.Clear(); return files[choice]; }
                    else { Console.Clear(); return ""; }

                }
            }
            return "";
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

#endregion

    public class BinaryInteger
    {
        public int First, Second;

        private int rangemin = -10000;

        private int rangemax = 10001;

        public bool DivByThree
        {
            get { return ((this.First % 3 == 0) || (this.Second % 3 == 0)); }
        }

        public BinaryInteger(Random rnd)
        {
            this.First = rnd.Next(rangemin, rangemax);
            this.Second = rnd.Next(rangemin, rangemax);
        }

        public override string ToString()
        {
            return $"{this.First}: {this.Second}";
        }
    }

    public class ArrayBinary
    {
        private BinaryInteger[] Pair;

        private int _size;

        private int[] validPairs;

        private int validCounter = 0;

        public ArrayBinary(Random rnd, int size)
        {
            if (size <= 0) throw new ArgumentOutOfRangeException();
            this.Pair = new BinaryInteger[size];
            this._size = size;
            this.validPairs = new int[this._size];
            for (var i = 0; i < size; i++)
            {
                this.Pair[i] = new BinaryInteger(rnd);
                if (this.Pair[i].DivByThree)
                {
                    this.validPairs[this.validCounter] = i;
                    this.validCounter++;
                }
            }
        }

        public string ValidPairs()
        {
            if (this.validCounter == 0) return "Нет подходящих пар...";
            string terminator = "";
            for (int i = 0; i < this.validCounter; i++)
            {
                terminator += $"{this.Pair[this.validPairs[i]].ToString()}; " ;
            }
            terminator += $"\n Всего подходящих пар - {this.validCounter}.";
            return terminator;
        }

        public override string ToString()
        {
            string terminator = "";
            for (int i = 0; i < _size; i++) terminator += this.Pair[i].ToString();
            return terminator;
        }
    }

    class MyArray
    {
        #region Что уже было
        int[] a;

        public MyArray(int n, int el)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = el;
        }

        public MyArray(int n, int min, int max, Random rnd)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(min, max + 1);
        }

        public int Max
        {
            get
            {
                int max = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] > max) max = a[i];
                return max;
            }
        }

        public int Min
        {
            get
            {
                int min = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] < min) min = a[i];
                return min;
            }
        }

        public int CountPositiv
        {
            get
            {
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                    if (a[i] > 0) count++;
                return count;
            }
        }

        public override string ToString()
        {
            string s = "";
            foreach (int v in a)
                s = s + v + " ";
            return s;
        }
        #endregion

        #region Что добавили

        public int Sum
        {
            get 
            { int summe = 0;
                for (int i = 0; i < this.a.Length; i++) summe += a[i];
                return summe;
            }
        }

        public void Inverse()
        {
            for (int i = 0; i < this.a.Length; i++) a[i] *= -1;
        }

        public void Multi(int multiplier)
        {
            for (int i = 0; i < this.a.Length; i++) a[i] *= multiplier;
        }

        public int MaxCount()
        {
            int counter = 0;
            for (int i = 0; i < this.a.Length; i++)
                if (this.a[i] == this.Max) counter++;
            return counter;
        }

        public MyArray(int size, int start, int step, bool flag)
        {
            if (size <= 0) throw new ArgumentOutOfRangeException();
            this.a = new int[size];
            this.a[0] = start;
            for (int i = 1; i < size; i++) this.a[i] = this.a[i - 1] + step;
        }

        /// <summary>
        /// Функция сбрасывает полное содержимое массива в один файл, затирая всё, что было.
        /// </summary>
        /// <param name="path"></param>
        public void DumpAll(string path)
        {
            if (!File.Exists(path)) File.Delete(path);
            using (File.Create(path)) { }

            //  StreamReader sr = new StreamReader(path);
            string temp = $"ArrayList,{this.a.Length}";
            File.AppendAllText(path, $"{temp}\n");

            temp = "";
            for (int i = 0; i < this.a.Length; i++)
            {
                temp += this.a[i] + ","; 
            }
            File.AppendAllText(path, temp);
        }

        /// <summary>
        /// Прочитать файл и добавить его целиком.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool LoadAll(string path)
        {
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                string[] lineIn = reader.ReadLine().Split(',');
                if (lineIn[0] != "ArrayList") { reader.Close(); return false; }

                int arraySize = Int32.Parse(lineIn[1]);
                this.a = new int[arraySize];
                lineIn = reader.ReadLine().Split(',');

                for (int i = 0; i < arraySize; i++) this.a[i] = Int32.Parse(lineIn[i]);

                reader.Close();
                return true;
            }
            else return false;
        }

        public MyArray(string fileName)
        {
            this.LoadAll(fileName);
        }

        #endregion
    }

    class Validity
    {
        public enum Result
        {
            WrongLogin, WrongPsw, Correct
        }
    }

    class Account : Validity
    {
        private string _login, _psw;

        public Account(string login, string psw)
        {
            this._login = login;
            this._psw = psw;

        }

        private bool CheckLogin(string input)
        {
            return (input == _login);
        }

        private bool CheckPsw(string input)
        {
            return (input == _psw);
        }

        public Result Check(string login, string psw)
        {
            if (!CheckLogin(login)) return Result.WrongLogin;
            if (!CheckPsw(psw)) return Result.WrongPsw;
            return Result.Correct;
        }

        public string Loophole()
        {
            return "Логин: " + _login + " | Пароль: " + _psw;
        }
    }

    class AccountArray : Validity
    {
        Account[] accounts;

        public Result Check(string login, string psw)
        {
            Result checkResult = Result.WrongLogin;
            foreach (Account e in accounts)
            {
                checkResult = e.Check(login, psw);
                if ((checkResult == Result.Correct) || (checkResult == Result.WrongPsw)) break;
            }
            return checkResult;
        }

        public string Validate (string login, string psw)
        {
            switch (Check(login,psw))
            {
                case Result.Correct:
                    return "Верная пара!";
                case Result.WrongPsw:
                    return "Неверный пароль...";
                default:
                    return "Неверный логин...";
            }
        }

        public AccountArray(string path)
        {
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                string[] lineIn = reader.ReadLine().Split(',');
                if (lineIn[0] != "PswList")
                {
                    reader.Close();
                    this.accounts = new Account[1];
                    this.accounts[1] = new Account("1", "1");
                }
                else
                {

                    int arraySize = Int32.Parse(lineIn[1]);

                    this.accounts = new Account[arraySize];
                    int counter = 0;

                    while (!reader.EndOfStream)
                    {
                        lineIn = reader.ReadLine().Split(',');
                        this.accounts[counter] = new Account(lineIn[0], lineIn[1]);
                        counter++;
                    }
                    reader.Close();
                }
            }
        }

        public string[] RuschianHakerz()
        {
            string[] russo = new string[accounts.Length];
            for (int i = 0; i < russo.Length; i++)
                russo[i] = accounts[i].Loophole();
            return russo;
        }

    }

    class TwoRankArray
    {
        int[,] arr;

        int rows = 3; 
        int cols = 3;

        public TwoRankArray(Random rnd)
        {
            this.arr = new int[rows, cols];
            for (int i = 0; i<rows; i++)
            {
                for (int e = 0; e < cols; e++)
                    this.arr[i, e] = rnd.Next(-99, 100);
            }
        }

        public int sum
        { get 
            { int result = 0;
                for (int i = 0; i < rows; i++)
                    for (int e = 0; e < cols; e++)
                        result += this.arr[i, e];
                return result;
            } 
        }

        public int SumLargerThan(int start)
        {
            {
                int result = 0;
                for (int i = 0; i < rows; i++)
                    for (int e = 0; e < cols; e++)
                        if (this.arr[i, e] > start) result += this.arr[i, e];
                return result;
            }
        }

        public int min
        {
            get
            {
                int result = this.arr[0, 0];
                for (int i = 0; i < rows; i++)
                    for (int e = 0; e < cols; e++)
                        if (this.arr[i,e] > result) result = this.arr[i, e];
                return result;
            }
        }

        public int max
        {
            get
            {
                int result = this.arr[0, 0];
                for (int i = 0; i < rows; i++)
                    for (int e = 0; e < cols; e++)
                        if (this.arr[i, e] > result) result = this.arr[i, e];
                return result;
            }
        }

        /// <summary>
        /// Первое вхождение самого большого числа
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public int GetLargest(ref int row, ref int col)
        {
            int fatty = this.max;
            for (int i = 0; i < rows; i++)
                for (int e = 0; e < cols; e++)
                    if (this.arr[i, e] == fatty)
                    {
                        row = i;
                        col = e;
                    }
            return fatty;
        }

        /// <summary>
        /// Принтер лент массива.
        /// </summary>
        public string[] PrintArray()
        {
            string[] ArrayPrint = new string[this.rows];

            for (int i = 0; i < this.rows; i++)
            {
                ArrayPrint[i] = "|| ";
                for (int j = 0; j < this.cols; j++)
                {
                    ArrayPrint[i] += $" {this.arr[i, j],3} ";
                }
                ArrayPrint[i] += "||";
            }

            return ArrayPrint;
        }

        public void LoadAll(string path)
        {
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                string[] lineIn = reader.ReadLine().Split(',');
                if (lineIn[0] != "Matrix")
                {
                    reader.Close();

                    throw new FileLoadException();
                }
                else
                {

                    this.rows = Int32.Parse(lineIn[1]);
                    this.cols = Int32.Parse(lineIn[2]);

                    this.arr = new int[rows, cols];


                    for (int i = 0; i < rows; i++)
                    { 
                    lineIn = reader.ReadLine().Split(',');
                        for (int e = 0; e<cols; e++)
                            this.arr[i,e] = Int32.Parse(lineIn[e]);
                    }

                    reader.Close();
                }
            }
        }

        public void DumpAll(string path)
        {
            if (!File.Exists(path)) File.Delete(path);
            using (File.Create(path)) { }

            string temp = $"Matrix,{this.rows},{this.cols}";
            File.AppendAllText(path, $"{temp}\n");
            
            for (int i = 0; i < this.rows; i++)
            {
                temp = "";
                for (int e = 0; e < this.cols; e++)
                {
                    temp += this.arr[i,e];
                    if (e != this.cols - 1) temp += ",";
                }
                File.AppendAllText(path, $"{temp}\n");
            }
        }
    
    }
}



