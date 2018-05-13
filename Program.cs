using System;
using System.Globalization;

/** <remark>
 * • Разработать класс «многочлен» для работы с многочленами от одной переменной.
 * • Перегрузить для класса операции, допустимые для работы с многочленами
 * (чтение/изменение коэффициэнтов в членах многочлена, степень многочлена, сложение, вычитание, умножение многочленов).
 *
 * Математика это просто. Одночлены и многочлены 3: https://www.youtube.com/watch?v=TVnXkEhgmqA
 * Одночлен - это произведение чисел, переменных и их степеней.
 * Многочлен - это сумма или разность двух и более одночленов.
 </remark> */

namespace RD01_Task2_Polynomial
{
    internal class Program
    {
        private static void Main()
        {
            Console.Title = "Polynomial arithmetic";
            int index = 1;   // Индекс позиции одночлена которому будем менять коэффициент.
            double newInsexValue = 3.3;   // Новое значение коэффициента.

            try
            {
                var firstPolinomial = new Polynomial(7, 4, 0, 5);
                var secondPolinomial = new Polynomial(1, 8, 4);

                Console.WriteLine($"1'st polynomial (A) is:\t {firstPolinomial}");
                Console.WriteLine();

                Console.Write($"The coefficient of the {index + 1} monomial of the first polynomial: ");
                Console.WriteLine(firstPolinomial[index].ToString(CultureInfo.InvariantCulture));

                Console.WriteLine($"We change the coefficient of the {index + 1} monomial of the first polynomial to a: \"{newInsexValue}\"");
                firstPolinomial[index] = newInsexValue;
                Console.WriteLine();

                Console.WriteLine("Now: ");
                Console.WriteLine($"1'st polynomial (A) is:\t {firstPolinomial}");
                Console.WriteLine($"2'nd polynomial (B) is:\t {secondPolinomial}");
                Console.WriteLine();

                // Мы можем добавить, вычесть, умножить многочлены с помощью перегруженных операторов:
                Console.WriteLine($"A + B = {firstPolinomial + secondPolinomial}");
                Console.WriteLine($"A - B = {firstPolinomial - secondPolinomial}");
                Console.WriteLine($"A * B = {firstPolinomial * secondPolinomial}");
            }
            catch (ArgumentNullException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nBlock of ArgumentNullException!");
                Console.WriteLine("Error: " + ex.Message);
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nBlock of Exception!");
                Console.WriteLine("Error: " + ex.Message);
                Console.ResetColor();
            }

            Console.ReadKey();
        }
    }
}