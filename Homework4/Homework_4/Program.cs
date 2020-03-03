using System;
using System.IO;

namespace Homework_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // ВЫПОЛНИЛ ДМИТРИЙ ПОЛИТОВ

            #region Условия Задания
            /*
             * 1. Дан целочисленный массив из 20 элементов. Элементы массива могут принимать 
             * целые значения от –10 000 до 10 000 включительно. Написать программу, позволяющую 
             * найти и вывести количество пар элементов массива, в которых хотя бы одно число 
             * делится на 3. В данной задаче под парой подразумевается два подряд идущих элемента 
             * массива. Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.
             * 
             * 2. а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, 
             * создающий массив заданной размерности и заполняющий массив числами от начального 
             * значения с заданным шагом. Создать свойство Sum, которые возвращают сумму элементов 
             * массива, метод Inverse, меняющий знаки у всех элементов массива, метод Multi, умножающий 
             * каждый элемент массива на определенное число, свойство MaxCount, возвращающее количество 
             * максимальных элементов. В Main продемонстрировать работу класса.
             * б)Добавить конструктор и методы, которые загружают данные из файла и записывают данные 
             * в файл.
             * 
             * 3. Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла 
             * в массив. Создайте структуру Account, содержащую Login и Password.
             * 
             * 4. *а) Реализовать класс для работы с двумерным массивом. Реализовать конструктор, 
             * заполняющий массив случайными числами. Создать методы, которые возвращают 
             * сумму всех элементов массива, 
             * сумму всех элементов массива больше заданного, 
             * свойство, возвращающее минимальный элемент массива, 
             * свойство, возвращающее максимальный элемент массива, 
             * метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор 
             * ref или out)
             * 
             * *б) Добавить конструктор и методы, которые загружают данные из файла и записывают 
             * данные в файл.
             * 
             * Дополнительные задачи
             * в) Обработать возможные исключительные ситуации при работе с файлами.
             */

            #endregion


            #region Переменные
            string[] menuHeader = new string[] {"Домашнее задание 4. GeekBrains C#",
                                    "Пожалуйста, выберите искомый пункт меню, используя стрелки, и подтвердите клавишей ВВОД." };
            string[] menuList = new string[] {"Задание  1. Массив пар",
                                    "Задание 2. Операции с новым классом массивов",
                                    "Задание 3. Авторизация и операции с файлами",
                                    "Задание 4. Класс для двумерного массива"};
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
                    case 2:
                        Task3(menuList[2]);
                        break;
                    case 3:
                        Task4(menuList[3]);
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
            int arraySize = 20;
            ArrayBinary testArray = new ArrayBinary(rnd, arraySize);
            Console.Clear();
            Draw.ColorPrint(2, title);
            Console.WriteLine("\n\nВаш рандомный массив получился таким:\n" + testArray.ToString());
            Console.WriteLine("\nПодходящие пары: " + testArray.ValidPairs());
            Console.WriteLine("Нажмите любую клавишу для возврата в главное меню...");
            Console.ReadKey();
        }

        public static void Task2(string title)
        {
            string[] menuList = new string[] {"Пересобрать случайный массив",
                                              "Подмножить массив на константу",
                                              "Обратить знаки в массиве",
                                              "Показать сумму элементов массива",
                                              "Загрузить из файла",
                                              "Сохранить в файл"};
            string path = Directory.GetCurrentDirectory();

            Random rnd = new Random();
            bool looper = true;
            bool result;
            Console.Clear();
            Draw.ColorPrint(2, title);
            MyArray testArray = new MyArray(30, -100, 100, true);

            while(looper)
            {
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("Наш рабочий массив:\n");
                Console.WriteLine(testArray.ToString());
                Console.WriteLine("Число одинаковых максимальных элементов - " + testArray.MaxCount());

                switch (Draw.MatMenu(menuList))
                {
                    case 0: 
                        testArray = new MyArray(20, -1000, 1001, rnd);
                        Draw.Notify("Матрица пересобрана!");
                        break;
                    case 1:
                        int rope; bool feasible = false;
                        do
                        {
                            feasible = Int32.TryParse(Draw.DialogBox("Введите константу для умножения всех элементов массива", ""), out rope);
                        } while (!feasible);
                        testArray.Multi(rope);
                        break;
                    case 2: 
                        testArray.Inverse();
                        Draw.Notify("Знаки обращены");
                        break;
                    case 3:
                        Draw.Notify("Сумма всех элементов массива - "+testArray.Sum);
                        break;
                    case 4:
                        result = testArray.LoadAll(Draw.SelectFile("Пожалуйста, выберите файл формата .csv", path));
                        if (result) Draw.Notify("Данные подгружены"); else Draw.Notify("Ошибка загрузки!");
                        break;
                    case 5:
                        testArray.DumpAll(path + "\\data.csv");
                        Draw.Notify("Файл data.csv записан");
                        break;
                    default:
                        looper = false;
                        break;
                }

            }
        }

        public static void Task3(string title)
        {
            Console.Clear();
            Draw.ColorPrint(2, title);
            string path = Directory.GetCurrentDirectory() + "\\logdata.csv";
            string login, psw;
            bool looper = true;
            AccountArray logdata = new AccountArray(path);

            while(looper)
            {
                string[] truth = logdata.RuschianHakerz();
                Console.WriteLine("\n\n");
                foreach (string s in truth) Console.WriteLine(s);

                login = Draw.DialogBox("Пожалуйста, введите логин...","");
                psw = Draw.DialogBox("Пожалуйста, введите логин...", "");

                Draw.Notify(logdata.Validate(login, psw));
                if (logdata.Check(login, psw) == Validity.Result.Correct) looper = false;
            }

        }

        public static void Task4(string title)
        {
            Console.Clear();
            string path = Directory.GetCurrentDirectory() + "\\matrix.csv";
            string[] menuList = new string[] {"Пересобрать массив",
                                              "Сумма всех элементов массива",
                                              "Константа, больше которой мы считаем", 
                                              "Адрес максимального элемента массива",
                                              "Подгрузить массив",
                                              "Сохранить массив"};

            Random rnd = new Random();
            TwoRankArray testArray = new TwoRankArray(rnd);
            bool looper = true;
            bool goodInput;
            int x = 0,y = 0;

            while (looper)
            {
                Draw.ColorPrint(2, title);
                string[] visible = testArray.PrintArray();
                Console.SetCursorPosition(0, 6);
                foreach (string s in visible) Console.WriteLine(s);
                switch (Draw.MatMenu(menuList))
                {
                    case 0: testArray = new TwoRankArray(rnd);
                        break;
                    case 1: Draw.Notify("Сумма всех элементов массива - " + testArray.sum);
                        break;
                    case 2: do
                        {
                            goodInput = Int32.TryParse(Draw.DialogBox("Пожалуйста, укажите минимальное значение для отсчёта...", ""), out x);
                        } while (!goodInput);
                        Draw.Notify("Сумма всех элементов массива больше, чем "+ x +" - " + testArray.SumLargerThan(x));
                        break;
                    case 3: testArray.GetLargest(ref x, ref y);
                        Draw.Notify("Самый большой элемент - " + testArray.max + " находится в " + x + " ряду и " + y + " колонке.");
                        break;
                    case 4: testArray.LoadAll(path);
                        break;
                    case 5: testArray.DumpAll(path);
                        break;
                    default: looper = false;
                        break;


                }
            }
        }
    }
}
