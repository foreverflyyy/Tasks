using System;
using System.Collections.Generic;

namespace LabApp3
{
    class Program
    {
        //метод проверки какие элементы могут подойти
        // k,l,m - это всё число, постепенно умножаем их(то есть возводим в нужную степень)
        // сначала смотрим к в первой степени, к ней л в первой степени и м тоже
        // подоходит - то м уже равна 7 (7 в 1-ой степени)
        // подходит то потом 49 будет, не подходим возвращаемся к м и будем м равна 5 (5 в первой степени)
        // не подохдит также к k вернёмся и все по кругу
        static List<int> Computation(int x)
        {
            List<int> result = new List<int>();
            for (int k = 1; k <= x; k *= 3)
                for (int l = 1; k * l <= x; l *= 5)
                    for (int m = 1; k * l * m <= x; m *= 7)
                        result.Add(k * l * m);
            return result;
        }

        static void Main(string[] args)
        {
            /*Console.WriteLine("Enter value x pls: ");
            int x = Convert.ToInt32(Console.ReadLine());*/
            int x = 20;
            List<int> numbers = Computation(x);
            numbers.Sort();
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine((i+1) + ") " + numbers[i]);
            }
        }
    }
}
/*На вход дается одно число х, нужно вывести все числа от 1 до х, удовлетворяющие условию: 
3^K*5^L*7^M=xi ,где K, L, M - натуральные числа или могут быть равны 0.*/


// при x = 1.000.000.000 чисел будет 1100
// если вводимое число x<= 69.000, то будет ushort(От 0 до 65 535)
// если вводимое число x<= 4.300.000, то будет uint(От 0 до 4 294 967 295)
// если вводимое число x>4.300.000 , то будет ulong(От 0 до 18 446 744 073 709 551 615)
