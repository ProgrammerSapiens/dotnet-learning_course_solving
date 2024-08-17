using OfficeOpenXml;

namespace Lesson_2_Part_2.Classes.Action
{
    static internal class Excel_IO
    {
        static internal IList<T> ReadEntitiesFromExcel<T>(string filePath, string sheetname, int[] columns) where T : new()
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
