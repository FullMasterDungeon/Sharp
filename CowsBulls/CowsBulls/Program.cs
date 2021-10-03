using System;
using System.Collections.Generic;

namespace CowsBulls
{
    class Program
    {
        public static string Number = Create(First);
        // Number - загаданное число.
        public static string Answer;
        // Answer - число введеное пользователем.
        public static bool B;
        // переменная зависит от того что ввел пользователь при угадывании числа (некорректный ввод - false, корректный - true).
        public static bool First = false;
        static void Main(string[] args)
        {
            Console.WriteLine(Create(First));
        }
        /// <summary>
        /// Метод Create создает рандомное число из количества цифр указанного пользователем, при этом число не может быть больше 10 и меньше 0.
        /// </summary>
        /// <param name="first"></param>
        /// <returns></returns>
        public static string Create(bool First)
        {
            string Number = "";
            // number будет содержать в себе значение загаданного числа.
            while (First == false)
            {
                Console.WriteLine("Введите длину числа");
                string count = Console.ReadLine(); 
                //длина загаданного числа
                bool a = int.TryParse(count, out int count_final);
                // проверка является ли число int-ом.
                if (a == false | count_final > 10 | count_final < 1)
                    Console.WriteLine("Incorrect input");
                else
                {
                    Random rnd = new Random();
                    for (int i = 0; i < count_final; i++)
                    {
                        int value = rnd.Next(0, 10);
                        while (i == 0 & value == 0)
                        {
                            value = rnd.Next(0, 10);
                        }
                        while (Number.Contains(Convert.ToString(value)))
                        {
                            value = rnd.Next(0, 10);
                        }
                        Number += value;
                    }
                    // каждое новое число создается по отдельности, если перемнная number уже содержит число value оно проверяется методом Contains,
                    // и если было обнаружено совпадение, value генерирует новое число и добовляется к number.
                    Console.WriteLine(Number);
                    //выводит загаданное число (не убрал для того, чтобы было легче проверять).
                    First = true;
                    //first
                    Program.Final(Number, count_final);
                    // вызов следующего метода.
                }
            }
            return Number;
            

        }
        /// <summary>
        /// Метод Final принимает в себя число которое вводит пользователь и проверяет совпадает ли длина числа введенго пользователем с длиной из сгенерированного числа.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="Number"></param>
        /// <param name="count_final"></param>
        /// <returns></returns>
        public static string Final(string Number, int count_final)
        {
            bool second = true;
            while (second == true)
            {
                int lenght = 0;
                Console.WriteLine($"Введите {count_final} значное число");
                Answer = Console.ReadLine();
                bool B = ulong.TryParse(Answer, out ulong answer_final);
                if (B == true)
                {
                    foreach (int counter in Answer)
                    {
                        lenght += 1;
                    }
                }
                // счетчик длины.
                if (B == false | lenght != count_final)
                {
                    Console.WriteLine("Incorrect input");
                    Program.Final(Number, count_final);
                }
                // если введеное число было некорректно метод возвращается к началу.
                else
                {
                    second = false;
                }
                Program.Check(Number, Answer, count_final, B);
                //если все верно вызывает следующий метод.
            }

            return Answer;
            Program.Check(Number, Answer, count_final, B);
        }
        /// <summary>
        /// проверяет числа из Answer и Number на совпадения.
        /// </summary>
        /// <param name="Number"></param>
        /// <param name="Answer"></param>
        /// <param name="count_final"></param>
        /// <param name="B"></param>
        public static void Check(string Number, string Answer, int count_final, bool B)
        {
            int bull = 0;
            int cow = 0;
            if (Number == Answer)
            {
                Console.WriteLine($"{count_final} быков");
                Console.WriteLine("0 коров");
                Console.WriteLine("Correct!!!");
                Console.WriteLine("Чтобы начать игру заново напишите: \"Yes\". Чтобы завершить игру нажмите \"Enter\"") ;
                string repeat = Console.ReadLine();
                if (repeat == "Yes")
                {
                    Program.Create(First);
                }
                //если пользователь рещил продолжить игру вызывает метод Create и начинает программу  сначала.
                else
                {
                    Environment.Exit(0);
                }
                //завершение работы программы.
            }
            else if (B == false)
            {
                Program.Final(Number, count_final);
            }
            // если значение введеное пользователем было некорректно, возвращается к методу Final.
            else
            {
                for (int v = 0; v < count_final; v++)
                {
                    if (Number[v] == Answer[v])
                    {
                        bull += 1;
                    }
                    else
                    { 

                        for (int k = 0; k < count_final; k++)
                        {
                            if (Number[v] == Answer[k])
                            {
                                cow += 1;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                // счетчик быков и коров.
                Console.WriteLine($"коров: {cow} ");
                Console.WriteLine($"быков: {bull}");
                Program.Final(Number, count_final);
                // повтор ввода числа от пользователя.
            }
        }
    }
}
