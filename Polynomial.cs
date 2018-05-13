using System;
using System.Linq;
using System.Text;

namespace RD01_Task2_Polynomial
{
    internal class Polynomial
    {
        private readonly double[] polynomial;

        /// <summary>
        /// Конструктор класса Polynomial.
        /// </summary>
        /// <param name="args">Коэффициенты в членах многочлена в качестве параметра args.</param>
        public Polynomial(params double[] args)
        {
            polynomial = args ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Индексатор для чтения / изменения коэффициентов в членах многочлена.
        /// </summary>
        /// <param name="i">Индекс одночлена.</param>
        /// <returns>Коэффициент одночлена по заданному индексу.</returns>
        public double this[int i]
        {
            // Проверяется корректность индексов.
            get => i < 0 || i >= polynomial.Length
                ? throw new Exception("Indices are out of range.")
                : polynomial[i];
            set
            {
                if (i < 0 || i >= polynomial.Length)
                    throw new Exception("Indices are out of range.");
                polynomial[i] = value;
            }
        }

        /// <summary>
        /// Перегрузка оператора +.
        /// </summary>
        /// <param name="first">Первый многочлен.</param>
        /// <param name="second">Второй многочлен.</param>
        /// <returns>Результат сложения первого и второго многочлена в виде нового многочлена.</returns>
        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            // Определяем количество членов результирующего многочлена путём нахождения многочлена с наибольшим количеством членов.
            var addResult = first.polynomial.Length >= second.polynomial.Length
                ? new double[first.polynomial.Length]
                : new double[second.polynomial.Length];

            for (int i = 0; i < addResult.Length; i++)
            {
                if (i < first.polynomial.Length)
                    addResult[i] += first.polynomial[i];
                if (i < second.polynomial.Length)
                    addResult[i] += second.polynomial[i];
            }

            return new Polynomial(addResult);
        }

        /// <summary>
        /// Перегрузка оператора -.
        /// </summary>
        /// <param name="first">Первый многочлен.</param>
        /// <param name="second">Второй многочлен.</param>
        /// <returns>Результат вычитания второго многочлена из первого в виде нового многочлена.</returns>
        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            var subResult = first.polynomial.Length >= second.polynomial.Length
                ? new double[first.polynomial.Length]
                : new double[second.polynomial.Length];

            for (int i = 0; i < subResult.Length; i++)
            {
                if (i < first.polynomial.Length)
                    subResult[i] += first.polynomial[i];
                if (i < second.polynomial.Length)
                    subResult[i] -= second.polynomial[i];
            }

            return new Polynomial(subResult);
        }

        /// <summary>
        /// Перегрузка оператора *.
        /// </summary>
        /// <param name="first">Первый многочлен.</param>
        /// <param name="second">Второй многочлен.</param>
        /// <returns>Результат умножения первого и второго многочлена в виде нового многочлена.</returns>
        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            var multResult = new double[first.polynomial.Length + second.polynomial.Length - 1];

            for (int i = 0; i < first.polynomial.Length; i++)
            {
                for (int j = 0; j < second.polynomial.Length; j++)
                {
                    multResult[i + j] += first.polynomial[i] * second.polynomial[j];
                }
            }
            return new Polynomial(multResult);
        }

        /// <summary>
        /// Метод GetHashCode() для проверки равенства объекта.
        /// </summary>
        /// <returns>Hash-код текущего объекта.</returns>
        public override int GetHashCode()
        {
            int result = 0;
            foreach (var term in polynomial)
            {
                result *= 31 + term.GetHashCode();
            }

            return result;
        }

        /// <summary>
        /// Метод Equals() определяет, равен ли заданный объект текущему объекту.
        /// </summary>
        /// <param name="obj">Объект для проверки.</param>
        /// <returns>Результат проверки.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != GetType())
                return false;
            return polynomial.Length == ((Polynomial) obj).polynomial.Length &&
                   polynomial.SequenceEqual(((Polynomial) obj).polynomial);
        }

        /// <summary>
        /// Метод ToString() позволяет отображать многочлен в виде строки.
        /// </summary>
        /// <returns>Многочлен в виде строки.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < polynomial.Length; i++)
            {
                if (polynomial[i] != 0)
                {
                    sb.Append(polynomial[i]);

                    if (i >= 1)   // Второму коэффициенту добавляем переменную в первой степени.
                        sb.Append("x");

                    if (i >= 2)   // Третьему+ коэффициенту добавляем переменную в i-й степени.
                        sb.Append($"^{i}");

                    if (i != polynomial.Length - 1)   // Пока коэффициент не последний...
                        sb.Append(polynomial[i + 1] > 0 ? " + " : " ");   // ... и не первый, и положительный, добавлем "+"
                }

                if (polynomial[i] == 0)
                {
                    if (i == 0)   // Если первый коэффициент 0 выводим 0.
                        sb.Append("0");

                    if (i >= 1)   // Если второй коэффициент 0 выводим "+ x".
                        sb.Append("+ x");

                    if (i >= 2)   // Третьему+ коэффициенту добавляем переменную в i-й степени.
                        sb.Append($"^{i}");

                    if (i != polynomial.Length - 1)   // Пока коэффициент не последний...
                        sb.Append(polynomial[i + 1] > 0 ? " + " : " ");   // ... и не первый, и положительный, добавлем "+"
                }
            }

            return sb.ToString();
        }
    }
}