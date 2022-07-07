namespace Percents
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter initial sum, interest rate and credit term in months separated by whitespace");
            string rawUserInput = Console.ReadLine();

            double result = Calculate(rawUserInput);
            Console.WriteLine($"Result: {result}");
        }

        /// <summary>
        /// Вычисляет накопившуюся сумму на момент окончания вклада.
        /// </summary>
        /// <param name="userInput">Ввод пользователя, содержащий начальную сумму, годовую процентную ставку и срок вклада в месяцах, разделённые через пробелы.</param>
        public static double Calculate(string userInput)
        {
            string[] splittedInput = userInput.Split(' ');

            var initialSum = double.Parse(splittedInput[0]);
            var interestRate = double.Parse(splittedInput[1]);
            var term = double.Parse(splittedInput[2]);


            var finalSum = initialSum * Math.Pow(1 + (interestRate / 100) / 12, term);

            return Math.Round(finalSum);
        }
    }
}
