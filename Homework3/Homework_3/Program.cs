using System;
using System.Collections.Generic;

namespace Homework_3
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Условия ДЗ
            /*
             * Выполнил Дмитрий Политов.
             * 
             * В НАСТОЯЩЕЙ РАБОТЕ РЕАЛИЗОВАНЫ ЗАДАЧИ №2 И №3.
             * 
             * 1. а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. 
             * Продемонстрировать работу структуры; 
             * б) Дописать класс Complex, добавив методы вычитания и произведения чисел. 
             * Проверить работу класса;
             * 
             * 2. а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке). 
             * Требуется подсчитать сумму всех нечетных положительных чисел. 
             * Сами числа и сумму вывести на экран, используя tryParse; 
             * б) Добавить обработку исключительных ситуаций на то, что могут быть введены 
             * некорректные данные. При возникновении ошибки вывести сообщение. 
             * Напишите соответствующую функцию;
             * 
             * 3. *Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел. 
             * Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, 
             * демонстрирующую все разработанные элементы класса. 
             * ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение
             * ArgumentException("Знаменатель не может быть равен 0");
             * Добавить упрощение дробей.
             * 
             * Достаточно решить 2 задачи. Все программы сделать в одном решении.
             */
            #endregion

            #region Комментарии к работе
            /* В процессе реализации увидел, что операции с дробями, конечно, очень
             * похожи на нормальные: сложение это прибавление отрицательной дроби, деление
             * это умножение на обратную дробь... имело бы смысл переопределить операции для дробей,
             * а не накидывать так, как я сделал - просто повторяя
             * (public static Fraction operator +(Fraction A, FractionB)...
             * На будущее взял в толк...
             *  
             */
            #endregion

            #region Переменные
            string[] menuHeader = new string[] {"Домашнее задание 3. GeekBrains C#",
                                    "Пожалуйста, выберите искомый пункт меню, используя стрелки, и подтвердите клавишей ВВОД." };
            string[] menuList = new string[] {"Задание  2. Ввод чисел и подсчёт суммы нечётных положительных",
                                    "Задание 3. Дроби и операции с ними"};
            bool looper = true;
            #endregion

            Draw.StartUp("Домашняя работа №3. Дмитрий Политов");

            while (looper)
            {
                Console.Clear();
                switch (Draw.MainMenu(menuHeader, menuList))
                {
                    case 0:
                        Task1(menuList[0]);
                        break;
                    case 1:
                        Task2(menuList[1]);
                        break;
                    default:
                        looper = false;
                        break;
                }
            }

        }

        public static void Task1(string title)
        {
            Random rnd = new Random();
            ulong lastInt = 1;
            List<ulong> series = new List<ulong>();
            Console.Clear();
            Draw.ColorPrint(2, title);
            Draw.Print(0, "Пожалуйста, вводите натуральные числа, пока вам не надоест.");
            Draw.Print(0,"А мы посчитаем сумму всех нечётных.");
            Draw.Print(0, "Сигнал к завершению - ввод '0', нуля.");
            Draw.ColorPrint(0, "Но будьте осторожны: программа ужасно нестабильна и выпадает ПОСТОЯННО!");
            Draw.Print(0, "Мы рады сообщить, что не работаем над этим и не планируем. Удачи!");

            while (lastInt != 0) //Принимаем ввод и выдаём всякие весёлые ошибки.
            {
                Console.Write("Следующее значение: ");
                if (!UInt64.TryParse(Console.ReadLine(),out lastInt))
                {
                    Draw.SummonError("НЕКОРРЕКТНЫЙ ВВОД. ВЫХОЖУ...");
                    throw new ArithmeticException("Не могу преобразовать ввод.");
                }
                if (lastInt<0)
                {
                    Draw.SummonError("ОТРИЦАТЕЛЬНОЕ ЗНАЧЕНИЕ ЭТО УЖАСНО. ВЫХОЖУ...");
                    throw new ArgumentOutOfRangeException("Пользователь ввёл отрицательное значение.");
                }
                if (rnd.Next(1,101) == 100)
                {
                    Draw.SummonError("СЛУЧАЙНАЯ ОШИБКА ПРОГРАММЫ...");
                    throw new Exception("Рандомайзер сгубил программу.");
                }

                if (lastInt % 2 != 0) series.Add(lastInt);
            }
            Console.Clear();
            Draw.ColorPrint(2, "Поздравляем! Вам удалось добраться до конца.");
            Draw.Print(0, "Вот что осталось от вашего ввода:");
            ulong[] resultArray = series.ToArray();
            ulong result = 0;
            foreach(ulong i in resultArray)
            {
                Console.Write(i + " ");
                result += i;
            }
            Console.WriteLine("\nА сумма ваших изысков: "+result);
            Console.WriteLine("Нажмите любую клавишу для возврата в главное меню...");
            Console.ReadKey();

        }

        public static void Task2(string title)
        {
            Random rnd = new Random();
            Fraction A = new Fraction(rnd);
            Fraction B = new Fraction(rnd);
            string[] menu = new string[] {"Собрать новые случайные дроби", 
                                          "Задать первую дробь", 
                                          "Задать вторую дробь",
                                          "Сложить дроби",
                                          "Перемножить дроби",
                                          "Вычесть из первой дроби вторую",
                                          "Поделить первую дробь на вторую",
                                          "Поменять дроби местами"};
            bool looper = true;

            Console.Clear();

            while (looper)
            {
                Draw.ColorPrint(2, title);
                Draw.Print(3, "Выберите желаемую операцию и нажмите ENTER.");
                FractionPrint(A, B);
                switch (Draw.MatMenu(menu))
                {
                    case 0:
                        A.Initialize(rnd);
                        B.Initialize(rnd);
                        break;
                    case 1:
                        SetFraction(ref A, "№1");
                        break;
                    case 2:
                        SetFraction(ref B, "№2");
                        break;
                    case 3:
                        Draw.Notify("Результат сложения: " + 
                            new Fraction(A, B, Fraction.Operator.Add).ToString());
                        break;
                    case 4:
                        Draw.Notify("Результат умножения: " +
                            new Fraction(A, B, Fraction.Operator.Multiply).ToString());
                        break;
                    case 5:
                        Draw.Notify("Результат вычитания:  " +
                            new Fraction(A, B, Fraction.Operator.Subtract).ToString());
                        break;
                    case 6:
                        Draw.Notify("Результат деления: " +
                            new Fraction(A, B, Fraction.Operator.Divide).ToString());
                        break;
                    case 7:
                        Fraction C = A;
                        A = B;
                        B = C;
                        break;
                    default: looper = false; break;
                }
            }
        }

        public static void FractionPrint(Fraction A, Fraction B)
        {
            Console.SetCursorPosition(0, 4);
            Console.WriteLine($"{' ', 40}");
            Console.WriteLine($"{' ',40}");
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("Сегодня машина дала нам две дроби.\nЭто " + A.ToString() + " и " + B.ToString() + ".");
        }

        public static void SetFraction(ref Fraction A, string name)
        {
            bool shutdown = false;
            int num, den;
            do
            {
                shutdown = Int32.TryParse(Draw.DialogBox("Введите (целое число) знаменатель дроби "+name, ""),
                out num);
                if (!shutdown) Draw.SummonError("Некорректный ввод...");
            } while (!shutdown);

            shutdown = false;
            do
            {
                
                shutdown = Int32.TryParse(Draw.DialogBox("Введите (целое число) знаменатель дроби "+name, ""),
                                out den);
            } while (!shutdown);

            // МЕСТО ВЫПОЛНЕНИЯ ЗАДАЧИ ПО ВЫБРАСЫВАНИЮ ИСКЛЮЧЕНИЯ
            try
            {
                int temp = num / den;
            }
            catch (DivideByZeroException)
            {
                Draw.SummonError("В приличном обществе не делят на ноль! Выхожу...");
                throw new ArgumentException("Деление на ноль при задании дроби");
            }

            Fraction Result = new Fraction(num, den);
            A = Result;

        }
    }
}
