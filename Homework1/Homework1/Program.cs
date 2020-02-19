using System;

namespace Homework1
{
    class Program
    {

        // Задание выполнил Дмитрий Политов (не Владимир Ульянов, как указано в задании)))
        // Спасибо за проверку! Извините, если много помарок - старался успеть быстро и новый
        // код не комментировал...

        #region Условия задания
        /*1. Написать программу «Анкета». Последовательно задаются вопросы 
         * (имя, фамилия, возраст, рост, вес). В результате вся информация 
         * выводится в одну строчку.
         * а) используя склеивание;
         * б) используя форматированный вывод;
         * в) *используя вывод со знаком $.

         * 2. Ввести вес и рост человека. Рассчитать и вывести 
         * индекс массы тела (ИМТ) по формуле I=m/(h*h); 
         * где m — масса тела в килограммах, h — рост в метрах

         * 3.
         * а) Написать программу, которая подсчитывает расстояние 
         * между точками с координатами x1, y1 и x2,y2 по формуле 
         * r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). 
         * Вывести результат, используя спецификатор формата .2f 
         * (с двумя знаками после запятой);
         * б) *Выполните предыдущее задание, оформив вычисления 
         * расстояния между точками в виде метода;

         * 4. Написать программу обмена значениями двух переменных.
         * а) с использованием третьей переменной;
         * б) *без использования третьей переменной.

         * 5.
         * а) Написать программу, которая выводит на экран ваше имя, фамилию 
         * и город проживания.
         * б) Сделать задание, только вывод организуйте в центре экрана
         * в) *Сделать задание б с использованием собственных методов 
         * (например, Print(string ms, int x,int y)

         * 6. *Создать класс с методами, которые могут пригодиться в вашей учебе 
         * (Print, Pause).
         */
        #endregion

        static void Main(string[] args)
        {
            #region Переменные
            string[] menuHeader = new string[] {"Домашнее задание 1. GeekBrains C#", 
                                    "Пожалуйста, выберите искомый пункт меню, используя стрелки, и подтвердите клавишей ВВОД." };
            string[] menuList = new string[] {"Задание  1. Анкета","Задание 2. Расчёт индекса массы тела", "Задание 3. Расчёт расстояния между координатами", 
                                    "Задание 4. Обмен данными двух переменных", "Задание 5. Печать данных по центру экрана"};
            bool looper = true;
            #endregion

            Console.CursorVisible = false;
            Console.Title = "Домашнее задание 1. Дмитрий Политов";
            Console.SetBufferSize(Console.LargestWindowWidth - 20,Console.LargestWindowHeight - 20);
            Console.SetWindowSize(Console.LargestWindowWidth - 20, Console.LargestWindowHeight - 20);

            while (looper)
            {
                Console.Clear();
                switch (Draw.MainMenu(menuHeader, menuList))
                {
                    case 0: Task1();
                        break;
                    case 1: Task2();
                        break;
                    case 2: Task3();
                        break;
                    case 3: Task4();
                        break;
                    case 4: Task5();
                        break;
                    default: looper = false;
                        break;
                }
            }
            
        }

        static void Task1()
        {
            Console.Clear();
            Draw.Print(4, "Задание 1. Вывод текста c форматированием.");
            string name = Draw.DialogBox("Пожалуйста, введите ваше имя:","");
            string lName = Draw.DialogBox("Пожалуйста, введите вашу фамилию:","");
            string age = Draw.DialogBox("Пожалуйста, введите ваш возраст:", "");
            string height = Draw.DialogBox("Пожалуйста, введите ваш вес:", "");

            string formatted = (name + " " + lName + " " + age + " " + height);
            string dollared = ($"Имя: {name} Фамилия: {lName} Возраст: {age} Рост: {height}");

            Console.Clear();
            Draw.Print(4, "Задание 1. Вывод текста c форматированием.");
            Draw.Print(6, "Конкотация:");
            Draw.Print(0, name + lName + age + height);

            Draw.Print(9, "Форматированный вывод:");
            Draw.Print(0, formatted);

            Draw.Print(12, "Вывод с использованием переменных (с $):");
            Draw.Print(0, dollared);

            Draw.Print(20, "Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static void Task2()
        {
            Console.Clear();
            Draw.Print(4, "Задание 2. Расчёт индекса массы тела");
            string heightInput, weightInput;
            int weight, height;

            do
            {
                heightInput = Draw.DialogBox("Укажите рост (в см): ", "");
            } while (!Int32.TryParse(heightInput, out height));

            do
            {
                weightInput = Draw.DialogBox("Укажите вес (в кг):", "");
            } while (!Int32.TryParse(weightInput, out weight));


            double bmi = weight / Math.Pow(Convert.ToDouble(height) / 100, 2);

            Console.Clear();
            Draw.Print(4, "Задание 2. Расчёт индекса массы тела");

            Draw.Print(10, "Индекс массы тела будет равен: " + $"{bmi,3}");

            Draw.Print(20, "Нажмите любую клавишу для продолжения...");
            Console.ReadKey();

        }

        static void Task3()
        {
            Console.Clear();
            Draw.Print(4, "Задание 3. Расчёт расстояния между точками");

            Dot one = new Dot("первой");
            Dot two = new Dot("второй");

            Console.Clear();
            Draw.Print(4, "Задание 3. Расчёт расстояния между точками");

            double product = Math.Sqrt(Math.Pow(two.x - one.x, 2) + Math.Pow(two.y - one.y, 2));

            Draw.Print(10, product.ToString("F2"));

            Draw.Print(20, "Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static void Task4()
        {
            Console.Clear();
            Draw.Print(4, "Задание 4. Обмен переменных");
            int a = 15;
            int b = 45;
            int c;

            VarPrinter(6, a, b);
            Draw.Print(8, "С помощью переменной 'c' добавим немного уличной магии...");
            c = a; a = b; b = c;
            VarPrinter(9, a, b);

            Draw.Print(11, "А теперь провернём то же самое обратно, но теперь без третьей переменной...");
            a *= b; b = a / b; a /= b;
            VarPrinter(12, a, b);

            Draw.Print(20, "Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static void VarPrinter(int lineNum, int a, int b)
        {
            Draw.Print(lineNum, "Есть переменные 'a', равная " + a + ", и b, равная " + b + ".");
        }

        static void Task5()
        {
            Console.Clear();
            Draw.Print(4, "Задание 5. Печать по центру");
            Draw.Print(5, "В целом, это задание выполнилось случайно, но для порядка -");
            Draw.Print(Console.BufferHeight / 2, "Владимир Ленин, Ульяновск");

            Draw.Print(Console.BufferHeight-1, "Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}
