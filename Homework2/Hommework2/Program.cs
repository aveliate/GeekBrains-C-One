using System;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Переменные
            string[] menuHeader = new string[] {"Домашнее задание 2. GeekBrains C#",
                                    "Пожалуйста, выберите искомый пункт меню, используя стрелки, и подтвердите клавишей ВВОД." };
            string[] menuList = new string[] {"Задание  1. Наименьшее и наибольшее из трёх чисел",
                                    "Задание 2. Подсчёт количества цифр в числе", 
                                    "Задание 6. Подсчёт числа 'хороших' чисел до 1 млрд",
                                    "Задание 7. Рекурсивная функция"};
            bool looper = false;
            #endregion

            Draw.StartUp("Домашнее задание №2. Дмитрий Политов");

            for (int i = 0; i < 3 && !looper; i++) looper = Auth("root", "GeekBrains");

            while (looper)
            {
                Console.Clear();
                switch (Draw.MainMenu(menuHeader, menuList))
                {
                    case 0:
                        Task1();
                        break;
                    case 1:
                        Task2();
                        break;
                    case 2:
                        Task6();
                        break;
                    case 3:
                        Task7();
                        break;
                    default:
                        looper = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Юмористическая версия авторизации. ОСТОРОЖНО: ВЗЛОМАНА РУССКИМИ ХАКЕРАМИ!
        /// </summary>
        /// <param name="login"></param>
        /// <param name="psw"></param>
        /// <returns></returns>
        public static bool Auth(string login, string psw)
        {
            Draw.Print(5, "Для продолжения работы введите логин и пароль...");
            Draw.Print(Console.BufferHeight/2 - 5, "ХАКЕРЫ СОВЕТУЮТ: попробуйте написать "+login);
            string inLogin = Draw.DialogBox("Введите ЛОГИН", "");
            Draw.Print(Console.BufferHeight / 2 - 5, "ХАКЕРЫ СОВЕТУЮТ: попробуйте написать "+psw);
            string inPsw = Draw.DialogBox("Введите ПАРОЛЬ","");
            return (inLogin == login && inPsw == psw);
        }

        /// <summary>
        /// Наименьшее и наибольшее из трёх чисел
        /// </summary>
        public static void Task1()
        {
            Console.Clear();
            Draw.Print(2, "Задание 1. Наименьшее и наибольшее из трёх чисел");
            Draw.Print(4, "Для вашего удобства, числы предоставлены системным временем компьютера.");
            Random rnd = new Random();
            int a = rnd.Next(0, 1001);
            int b = rnd.Next(0, 1001);
            int c = rnd.Next(0, 1001);

            Console.WriteLine("\n\nНаши счастливчики это числа 'a' = "+ a +", 'b' = "+ b +" и 'c' = " + c);
            Console.WriteLine("Разумеется, максимальное из них - " + (a>b && a>c?a:(b>a&&b>c?b:c)));
            Console.WriteLine("А минимальное - " + (a < b && a < c ? a : (b < a && b < c ? b : c)));
            Draw.Print(Console.BufferHeight - 2, "Нажмите любую клавишу для продолжения...");
            Console.ReadKey();

        }

        /// <summary>
        /// Сколько же цифр в этом числе?..
        /// </summary>
        public static void Task2()
        {
            Console.Clear();
            Random rnd = new Random();
            Draw.Print(2, "Задание 2. Сколько цифр в числе?");
            Draw.Print(4, "Для вашего удобства, числа предоставлены системным временем компьютера.");
            int a = rnd.Next();
            int b = rnd.Next(); 
            int c = rnd.Next();
            Console.WriteLine("\n\n\nНа сцене счастливчики, три числа, в каждом из которых...");
            Console.WriteLine("Число 'а', " + a + ", в котором " + a.ToString().Length + " символов");
            Console.WriteLine("Число 'b', " + b + ", в котором " + b.ToString().Length + " символов");
            Console.WriteLine("Число 'c', " + c + ", в котором " + c.ToString().Length + " символов");

            Draw.Print(Console.BufferHeight - 2, "Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        /// <summary>
        /// Задачка на сходить попить кофе и не перенапрягаться
        /// </summary>
        public static void Task6()
        {
            int counter = 0;
            Console.Clear();
            Draw.Print(2, "Задание 6.Подсчёт числа 'хороших' чисел до 1 млрд");
            DateTime startTime = DateTime.Now;
            Console.WriteLine("\n\nБезобразие начато в " + startTime.ToString("HH:mm:ss"));
            Console.Write("                      ]\r" + "[");
            for (int i = 1; i <=1_000_000_000;i++)
            {
                if (i%Crunch(i) == 0) counter++;
                if (i % 50_000_000 == 0) Console.Write("*");
            }
            Console.Write("]");
            string elapsed = DateTime.Now.Subtract(startTime).ToString();
            Console.WriteLine("\n\n Закончено безобразие в " + DateTime.Now.ToString("HH:mm:ss"));
            Console.WriteLine("\n За это время мы насчитали " + counter + " годных чисел.");
            Console.Write("Времени потрачено " + elapsed);

            Console.Write("\n\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }

        public static int Crunch(Int64 victim)
        {
            int digitsLength = victim.ToString().Length;
            int sum = 0;
            for (int i = 0; i<digitsLength;i++)
            {
                sum += Convert.ToInt32(Char.GetNumericValue(victim.ToString()[i]));
            }
            return sum;
        }

        /// <summary>
        /// Рекурсия, вызывающая рекурсию...
        /// </summary>
        public static void Task7()
        {
            Console.Clear();
            Draw.Print(2, "Задание 7. Рекурсия про сумму и обратный отсчёт");
            Draw.Print(4, "Для вашего удобства, числа предоставлены системным временем компьютера.");
            Random rnd = new Random();
            int a = 0, b = 0, i = 0;
            Int64 sum = 0;
            while (!(a<b)) { a = rnd.Next(1, 1025); b = rnd.Next(1, 1025); i++; }
            Console.WriteLine("Нам удалось подобрать годную комбинацию с " + i + " попытки.");
            Console.WriteLine("Это числа "+ a +" и "+ b + ".");
            Console.WriteLine("Вот разделяющие их числа - ");
            Task7Func(a, b, ref sum);
            Console.WriteLine("\n\nА сумма их - " + sum);
            Console.Write("\n\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }

        public static void Task7Func(int start, int end, ref Int64 sum)
        {
            Console.Write(" " + start);
            if (start < end)
            { sum += start; Task7Func(++start, end, ref sum); }
        }


    }
}
