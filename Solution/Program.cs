using Newtonsoft.Json;
using Solution.Classes;

namespace Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Factories> factories = GetDeserializedLists<Factories>("factories.json");
            List<Units> units = GetDeserializedLists<Units>("units.json");
            List<Tanks> tanks = GetDeserializedLists<Tanks>("tanks.json");

            foreach (var tank in tanks)
            {
                var unit = units.FirstOrDefault(x => x.Id == tank.UnitId);
                string unitName = unit?.Name ?? "Unit not found";
                string unitDescription = unit?.Description ?? "Unit not found";

                var factory = factories.FirstOrDefault(x => x.Id == unit?.FactoryId);
                string factoryName = factory?.Name ?? "Factory not found";
                string factoryDescription = factory?.Description ?? "Factory not found";

                Console.WriteLine($"Id: {tank.Id}, Название: {tank.Name}, Описание: {tank.Description}," +
                    $" Объем: {tank.Volume}, Максимальный объем: {tank.MaxVolume}, Цех: {unitName}" +
                    $" ({unitDescription}), Фабрика: {factoryName} ({factoryDescription})");
            }
        }
        static List<T> GetDeserializedLists<T>(string filename)
        {
            string filePath = Path.Combine("C:\\Users\\PotatoKiller\\Source\\Repos\\dotnet-learning_course_solving\\Solution\\JSON_files\\", filename);
            try
            {
                string jsonString = File.ReadAllText(filePath);

                if (string.IsNullOrEmpty(jsonString))
                {
                    return new List<T>();
                }

                return JsonConvert.DeserializeObject<List<T>>(jsonString) ?? new List<T>();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File not found: {filePath}");
                return new List<T>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON file: {filePath}. Exception: {ex.Message}");
                return new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occured: {ex.Message}");
                return new List<T>();
            }
        }
    }
}
