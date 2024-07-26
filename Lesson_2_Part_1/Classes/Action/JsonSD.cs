using Lesson_2_Part_1.Classes.Descriptive;
using Newtonsoft.Json;

namespace Lesson_2_Part_1.Classes.Action
{
    static internal class JsonSD
    {
        static internal List<T> GetDeserializedLists<T>(string filePath)
        {
            try
            {
                var jsonString = File.ReadAllText(filePath);
                return string.IsNullOrEmpty(jsonString) ? new List<T>() : JsonConvert.DeserializeObject<List<T>>(jsonString) ?? new List<T>();
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

        static internal void SerializeAllData(AllData allData, string filePath)
        {
            var allDataJson = JsonConvert.SerializeObject(allData, Formatting.Indented);
            File.WriteAllText(filePath, allDataJson);

            Console.WriteLine("Serialized All Data JSON: ");
            Console.WriteLine(allDataJson);
        }
    }
}
