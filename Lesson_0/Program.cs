using Newtonsoft.Json;
using OfficeOpenXml;
using Lesson_0.Classes;

namespace Lesson_0
{
    internal class Program
    {
        private static readonly string jsonFilesPath = "C:\\Users\\PotatoKiller\\Source\\Repos\\dotnet-learning_course_solving\\Lesson_0\\JSON_files\\";
        private static readonly string allDataFilePath = "C:\\Users\\PotatoKiller\\Source\\Repos\\dotnet-learning_course_solving\\Lesson_0\\JSON_files\\allData.json";
        private static readonly string excelFilePath = "C:\\Users\\PotatoKiller\\Source\\Repos\\dotnet-learning_course_solving\\Lesson_0\\Data.xlsx";
        static void Main(string[] args)
        {
            //Output information about all tanks
            var jsonFactories = GetDeserializedLists<Factories>(jsonFilesPath + "factories.json");
            var jsonUnits = GetDeserializedLists<Units>(jsonFilesPath + "units.json");
            var jsonTanks = GetDeserializedLists<Tanks>(jsonFilesPath + "tanks.json");
            ShowTankInfo(jsonFactories, jsonUnits, jsonTanks);

            //Total tanks volume
            var totalVolume = jsonTanks.Sum(x => x.Volume);
            Console.WriteLine(totalVolume);

            //Output information about desired tank
            Console.WriteLine("Enter the name of the tank or 'q' to quit: ");
            while (true)
            {
                var desiredTank = new List<Tanks>();

                var enter = Console.ReadLine();
                if (enter == "q") break;

                var foundTank = jsonTanks.FirstOrDefault(x => x.Name.Equals(enter, StringComparison.OrdinalIgnoreCase));
                if (foundTank != null)
                {
                    desiredTank.Add(foundTank);
                    ShowTankInfo(jsonFactories, jsonUnits, desiredTank);
                }
                else
                {
                    Console.WriteLine($"Tank with name '{enter}' not found.");
                }
            }

            //Serialize data according new structure
            var allData = new AllData()
            {
                Factories = jsonFactories,
                Units = jsonUnits,
                Tanks = jsonTanks
            };
            SerializeAllData(allData, allDataFilePath);

            //Information output from excel file
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var excelFactories = ReadEntitiesFromExcel<Factories>(excelFilePath, "Factories", new[] { 1, 2, 3 });
            var excelUnits = ReadEntitiesFromExcel<Units>(excelFilePath, "Units", new[] { 1, 2, 3, 4 });
            var excelTanks = ReadEntitiesFromExcel<Tanks>(excelFilePath, "Tanks", new[] { 1, 2, 3, 4, 5, 6 });
            ShowTankInfo(excelFactories, excelUnits, excelTanks);
        }
        static List<T> GetDeserializedLists<T>(string filePath)
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
        static void ShowTankInfo(List<Factories> factories, List<Units> units, List<Tanks> tanks)
        {
            var tanksInfo = tanks.Select(tank =>
            {
                var unit = units.FirstOrDefault(x => x.Id == tank.UnitId);
                var factory = factories.FirstOrDefault(x => x.Id == unit?.FactoryId);

                return $"Id: {tank.Id}, Tank name: {tank.Name}, Description: {tank.Description}," +
                    $" Volume: {tank.Volume}, Max volume: {tank.MaxVolume}, unit: {unit?.Name ?? "Unit not found"}" +
                    $" ({unit?.Description ?? "Unit not found"}), factory: {factory?.Name ?? "Factory not found"}" +
                    $" ({factory?.Description ?? "Unit not found"})";
            }).ToList();

            foreach (var tank in tanksInfo)
            {
                Console.WriteLine(tank + "\n");
            }
        }
        static void SerializeAllData(AllData allData, string filePath)
        {
            var allDataJson = JsonConvert.SerializeObject(allData, Formatting.Indented);
            File.WriteAllText(filePath, allDataJson);

            Console.WriteLine("Serialized All Data JSON: ");
            Console.WriteLine(allDataJson);
        }
        static List<T> ReadEntitiesFromExcel<T>(string filePath, string sheetname, int[] columns) where T : new()
        {
            var entities = new List<T>();
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[sheetname];
                int rowCount = worksheet.Dimension.Rows;

                for (var row = 2; row <= rowCount; row++)
                {
                    var entity = new T();
                    var properties = entity.GetType().GetProperties();

                    for (var i = 0; i < columns.Length; i++)
                    {
                        var property = properties[i];
                        var value = worksheet.Cells[row, columns[i]].Text;
                        property.SetValue(entity, Convert.ChangeType(value, property.PropertyType));
                    }

                    entities.Add(entity);
                }
            }
            return entities;
        }
    }
}
