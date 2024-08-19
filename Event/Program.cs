namespace Event
{
    internal class Program
    {
        const string invalidInputMessage = "Ввод некорректен. Попробуйте еще раз";
        static void Main(string[] args)
        {
            Console.WriteLine("Нажмите q, если хотите выйти из программы");
            Console.WriteLine();

            EnteringNumber enteringNumber = new EnteringNumber();
            enteringNumber.TakeNumber += DisplayNumberAndTime;

            while (true)
            {
                Console.Write("Введите целое число: ");
                string? line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    Console.WriteLine(invalidInputMessage);
                    Console.WriteLine();
                    continue;
                }
                if (line == "q")
                {
                    break;
                }

                if (!int.TryParse(line, out int number))
                {
                    Console.WriteLine(invalidInputMessage);
                    Console.WriteLine();
                    continue;
                }

                UserEnteredNumberEventArgs numberAndTime = new UserEnteredNumberEventArgs(number, DateTime.Now);
                enteringNumber.ShowEnteredNumber(numberAndTime);

                Console.WriteLine();
            }

            enteringNumber.TakeNumber -= DisplayNumberAndTime;
        }

        static internal void DisplayNumberAndTime(object? sender, UserEnteredNumberEventArgs numberAndTime)
        {
            Console.WriteLine($"Введен номер: {numberAndTime.Input} в {numberAndTime.EnteredAt}");
        }
    }
}
