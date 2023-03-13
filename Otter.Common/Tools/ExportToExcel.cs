using System.Collections.Generic;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;

namespace Otter.Common.Tools
{
    public static class ExportToExcel
    {
        #region Methods

        public static byte[] ExportToXlsx<T>(List<T> values, string fileName)
        {
            using ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(fileName);

            worksheet.Cells["A1"].LoadFromCollection(values, true, TableStyles.Light10);

            for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
            {
                worksheet.Column(col).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Column(col).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Column(col).AutoFit();
            }

            return package.GetAsByteArray();
        }

        #endregion Methods
    }
}