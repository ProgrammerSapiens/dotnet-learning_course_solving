using Newtonsoft.Json;

namespace Lesson_1_Part_1.Classes
{
    static internal class DealMethods
    {
        static public Deal[] GetDeserializedDeals(string filePath)
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

        static public IList<string> GetNumbersOfDeals(IEnumerable<Deal> deals)
        {
            return new List<string>(deals
                .Where(deal => deal.Sum >= 100)
                .OrderBy(deal => deal.Date)
                .Select(deal => deal.Id)
                .Take(5)
                .ToList());
        }

        public record SumByMonth(DateTime Month, int Sum);

        static public IList<SumByMonth> GetSumsByMonth(IEnumerable<Deal> deals)
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
