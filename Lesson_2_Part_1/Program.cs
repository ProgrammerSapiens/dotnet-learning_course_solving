using Lesson_2_Part_1.Classes.Action;
using Lesson_2_Part_1.Classes.Descriptive;
using OfficeOpenXml;

namespace Lesson_2_Part_1
{
    public class Program
    {
        private static readonly string jsonFilesPath = "C:\\Users\\PotatoKiller\\Source\\Repos\\dotnet-learning_course_solving\\Lesson_2_Part_1\\JSON_files\\";
        private static readonly string allDataFilePath = "C:\\Users\\PotatoKiller\\Source\\Repos\\dotnet-learning_course_solving\\Lesson_2_Part_1\\JSON_files\\allData.json";
        private static readonly string excelFilePath = "C:\\Users\\PotatoKiller\\Source\\Repos\\dotnet-learning_course_solving\\Lesson_2_Part_1\\Excel_file\\Data.xlsx";
        public static void Main(string[] args)
        {
            var jsonFactories = JsonSD.GetDeserializedLists<Factories>(jsonFilesPath + "factories.json");
            var jsonUnits = JsonSD.GetDeserializedLists<Units>(jsonFilesPath + "units.json");
            var jsonTanks = JsonSD.GetDeserializedLists<Tanks>(jsonFilesPath + "tanks.json");
            Input_output.ShowTanksInfo(jsonFactories, jsonUnits, jsonTanks);
            Input_output.ShowOneTank(jsonFactories, jsonUnits, jsonTanks);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var excelFactories = Excel_IO.ReadEntitiesFromExcel<Factories>(excelFilePath, "Factories", new[] { 1, 2, 3 });
            var excelUnits = Excel_IO.ReadEntitiesFromExcel<Units>(excelFilePath, "Units", new[] { 1, 2, 3, 4 });
            var excelTanks = Excel_IO.ReadEntitiesFromExcel<Tanks>(excelFilePath, "Tanks", new[] { 1, 2, 3, 4, 5, 6 });
            Input_output.ShowTanksInfo(excelFactories, excelUnits, excelTanks);

            //var builder = WebApplication.CreateBuilder(args);

            //// Add services to the container.

            //builder.Services.AddControllers();
            //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            //var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            //app.UseHttpsRedirection();

            //app.UseAuthorization();


            //app.MapControllers();

            //app.Run();
        }
    }
}
