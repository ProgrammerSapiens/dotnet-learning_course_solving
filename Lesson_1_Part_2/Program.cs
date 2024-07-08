using Dadata;

namespace Lesson_1_Part_2
{
    internal class Program
    {
        static private readonly string API_KEY = "Enter your API key";

        static async Task Main(string[] args)
        {
            var token = $"{API_KEY}";
            var api = new SuggestClientAsync(token);

            while (true)
            {
                Console.Write("Enter the INN of the company (or 'q' to quit): ");
                string? query = Console.ReadLine()?.Trim();
                if (query == "q") break;

                if (string.IsNullOrEmpty(query))
                {
                    Console.WriteLine("The INN cannot be empty. Please try again.");
                    continue;
                }

                await SearchAndDisplayCompany(api, query);

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static private async Task SearchAndDisplayCompany(SuggestClientAsync api, string query)
        {
            try
            {
                var result = await api.FindParty(query);
                if (result.suggestions.Count == 0)
                {
                    Console.WriteLine("Company does not exist.");
                }
                else
                {
                    foreach (var party in result.suggestions)
                    {
                        Console.WriteLine($"Company: {party.value}, address: {party.data.address.value} ");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }
        }
    }
}
