using Newtonsoft.Json;

namespace Lesson_1_Part_1
{
    internal class Program
    {
        static private readonly string jsonDealsFilePath = "C:\\Users\\PotatoKiller\\source\\repos\\dotnet-learning_course_solving\\Lesson_1_Part_1\\JSON_sample_1.json";
        static void Main(string[] args)
        {
            var deserializedDeals = GetDeserializedDeals(jsonDealsFilePath);

            //Getting the Ids of the 5 earliest deals where the sum is more than 100 rubles 
            IList<string> numbersOfDeals = GetNumbersOfDeals(deserializedDeals);
            foreach (var numberOfDeal in numbersOfDeals)
            {
                Console.WriteLine(numberOfDeal);
            }

            //Getting the sum of deals for each month
            IList<SumByMonth> sumsByMonth = GetSumsByMonth(deserializedDeals);
            foreach (var month in sumsByMonth)
            {
                Console.WriteLine($"Year and month: {month.Month.Year}.{month.Month.Month} - {month.Sum}");
            }
        }
        static Deal[] GetDeserializedDeals(string filePath)
        {
            try
            {
                var jsonString = File.ReadAllText(filePath);
                return string.IsNullOrEmpty(jsonString) ? Array.Empty<Deal>() : JsonConvert.DeserializeObject<Deal[]>(jsonString) ?? Array.Empty<Deal>();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File not found: {filePath}");
                return Array.Empty<Deal>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON file: {filePath}.Exception: {ex.Message}");
                return Array.Empty<Deal>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occured: {ex.Message}");
                return Array.Empty<Deal>();
            }
        }
        static IList<string> GetNumbersOfDeals(IEnumerable<Deal> deals)
        {
            return new List<string>(deals
                .Where(deal => deal.Sum >= 100)
                .OrderBy(deal => deal.Date)
                .Select(deal => deal.Id)
                .Take(5)
                .ToList());
        }
        record SumByMonth(DateTime Month, int Sum);
        static IList<SumByMonth> GetSumsByMonth(IEnumerable<Deal> deals)
        {
            return deals
                .GroupBy(deal => new DateTime(deal.Date.Year, deal.Date.Month, 1))
                .Select(group => new SumByMonth(
                    Month: group.Key,
                    Sum: group.Sum(deal => deal.Sum)
                ))
                .OrderBy(result => result.Month)
                .ToList();
        }
    }
}
