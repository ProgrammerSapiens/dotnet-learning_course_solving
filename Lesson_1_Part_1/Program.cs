using Lesson_1_Part_1.Classes;

namespace Lesson_1_Part_1
{
    internal class Program
    {
        static private readonly string jsonDealsFilePath = "C:\\Users\\PotatoKiller\\source\\repos\\dotnet-learning_course_solving\\Lesson_1_Part_1\\JSON_sample_1.json";

        static void Main(string[] args)
        {
            var deserializedDeals = DealMethods.GetDeserializedDeals(jsonDealsFilePath);

            //Getting the Ids of the 5 earliest deals where the sum is more than 100 rubles 
            IList<string> numbersOfDeals = DealMethods.GetNumbersOfDeals(deserializedDeals);
            foreach (var numberOfDeal in numbersOfDeals)
            {
                Console.WriteLine(numberOfDeal);
            }

            Console.WriteLine();

            //Getting the sum of deals for each month
            IList<DealMethods.SumByMonth> sumsByMonth = DealMethods.GetSumsByMonth(deserializedDeals);
            foreach (var month in sumsByMonth)
            {
                Console.WriteLine($"{month.Month.Year}.{month.Month.Month} - {month.Sum}");
            }
        }
    }
}
