namespace Expr10
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = SumOfNumbersMultipleThreeOrFive();
            Console.WriteLine(result);
        }

        /// <summary>
        /// Вычисляет сумму всех чисел от 1 до 1000, кратных 3 или 5.
        /// </summary>
        static int SumOfNumbersMultipleThreeOrFive()
        {
            int result = 0;

            for (int i = 0; i < 1000; i++)
            {
                if ((i % 3) == 0 || (i % 5) == 0)
                {
                    result += i;
                }
            }

            return result;
        }
    }
}
