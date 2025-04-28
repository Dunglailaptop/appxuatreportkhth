using AppXuatDuLieuKHTH.Data;
using AppXuatDuLieuKHTH.Helper;
using AppXuatDuLieuKHTH.Models;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXuatDuLieuKHTH.Controller
{
    public class rpTuoi
    {
        private readonly ConnectionDB _connectiondb;

        public rpTuoi()
        {
            _connectiondb = new ConnectionDB();
        }
        public void ExportFileThongKe(DataTable dataTable, string sheetName)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(sheetName);

                    // Tiêu đề chính
                    worksheet.Range("A1:O1").Merge();
                    worksheet.Cell(1, 1).Value = "BÁO CÁO PHÂN LOẠI TUỔI";
                    worksheet.Cell(1, 1).Style.Font.Bold = true;
                    worksheet.Cell(1, 1).Style.Font.FontName = "Arial";
                    worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                    worksheet.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Tên cột (Bỏ Mã và Tên Quận/Huyện)
                    string[] headers = new[]
                    {
                "STT",
                "Nam < 1T", "Nữ < 1T",
                "Nam < 2T", "Nữ < 2T",
                "Nam < 3T", "Nữ < 3T",
                "Nam < 4T", "Nữ < 4T",
                "Nam < 5T", "Nữ < 5T",
                "Nam < 6T", "Nữ < 6T",
                "Nam ≥ 6T", "Nữ ≥ 6T"
            };

                    double[] columnWidths = new double[]
                    {
                8,
                12, 12, 12, 12,
                12, 12, 12, 12,
                12, 12, 12, 12,
                12, 12
                    };

                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cell(3, i + 1).Value = headers[i];
                        worksheet.Column(i + 1).Width = columnWidths[i];
                    }

                    // Định dạng header
                    var headerRange = worksheet.Range(3, 1, 3, headers.Length);
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Font.FontName = "Arial";
                    headerRange.Style.Fill.BackgroundColor = XLColor.LightGreen;
                    headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    // Đổ dữ liệu
                    for (int row = 0; row < dataTable.Rows.Count; row++)
                    {
                        int currentRow = row + 4;
                        worksheet.Cell(currentRow, 1).Value = row + 1; // STT

                        worksheet.Cell(currentRow, 2).Value = dataTable.Rows[row]["NAM_NHOHON_1T"]?.ToString();
                        worksheet.Cell(currentRow, 3).Value = dataTable.Rows[row]["NU_NHOHON_1T"]?.ToString();

                        worksheet.Cell(currentRow, 4).Value = dataTable.Rows[row]["NAM_NHOHON_2T"]?.ToString();
                        worksheet.Cell(currentRow, 5).Value = dataTable.Rows[row]["NU_NHOHON_2T"]?.ToString();

                        worksheet.Cell(currentRow, 6).Value = dataTable.Rows[row]["NAM_NHOHON_3T"]?.ToString();
                        worksheet.Cell(currentRow, 7).Value = dataTable.Rows[row]["NU_NHOHON_3T"]?.ToString();

                        worksheet.Cell(currentRow, 8).Value = dataTable.Rows[row]["NAM_NHOHON_4T"]?.ToString();
                        worksheet.Cell(currentRow, 9).Value = dataTable.Rows[row]["NU_NHOHON_4T"]?.ToString();

                        worksheet.Cell(currentRow, 10).Value = dataTable.Rows[row]["NAM_NHOHON_5T"]?.ToString();
                        worksheet.Cell(currentRow, 11).Value = dataTable.Rows[row]["NU_NHOHON_5T"]?.ToString();

                        worksheet.Cell(currentRow, 12).Value = dataTable.Rows[row]["NAM_NHOHON_6T"]?.ToString();
                        worksheet.Cell(currentRow, 13).Value = dataTable.Rows[row]["NU_NHOHON_6T"]?.ToString();

                        worksheet.Cell(currentRow, 14).Value = dataTable.Rows[row]["NAM_LONHON_6THANG"]?.ToString();
                        worksheet.Cell(currentRow, 15).Value = dataTable.Rows[row]["NU_LONHON_6THANG"]?.ToString();

                        for (int col = 1; col <= 15; col++)
                        {
                            worksheet.Cell(currentRow, col).Style.Font.FontName = "Arial";
                        }
                    }

                    // Định dạng dữ liệu
                    var dataRange = worksheet.Range(4, 1, dataTable.Rows.Count + 3, 15);
                    dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    dataRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                    // Lưu file
                    using (var saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx",
                        FileName = "baocaophanloaituoi.xlsx"
                    })
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            using (var stream = new MemoryStream())
                            {
                                workbook.SaveAs(stream);
                                File.WriteAllBytes(saveFileDialog.FileName, stream.ToArray());
                            }
                            MessageBox.Show("Export thành công!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }



        public async Task<List<reportTuoi>> getReporttuoi(string tungay, string toingay)
        {
            try
            {

                string query = constant.searchreport_tuoi(tungay, toingay);
                var result = new DataTable();
                int count = 0;
                result = await _connectiondb.GetConnectionList(query);
                var list = result.AsEnumerable().Select(row => new reportTuoi
                {
                  
                    NAM_NHOHON_1T = row["NAM_NHOHON_1T"].ToString(),
                    NU_NHOHON_1T = row["NU_NHOHON_1T"].ToString(),
                    NAM_NHOHON_2T = row["NAM_NHOHON_2T"].ToString(),
                    NU_NHOHON_2T = row["NU_NHOHON_2T"].ToString(),
                    NAM_NHOHON_3T = row["NAM_NHOHON_3T"].ToString(),
                    NU_NHOHON_3T = row["NU_NHOHON_3T"].ToString(),
                    NAM_NHOHON_4T = row["NAM_NHOHON_4T"].ToString(),
                    NU_NHOHON_4T = row["NU_NHOHON_4T"].ToString(),
                    NAM_NHOHON_5T = row["NAM_NHOHON_5T"].ToString(),
                    NU_NHOHON_5T = row["NU_NHOHON_5T"].ToString(),
                    NAM_NHOHON_6T = row["NAM_NHOHON_6T"].ToString(),
                    NU_NHOHON_6T = row["NAM_NHOHON_6T"].ToString(),
                    NAM_LONHON_6THANG = row["NAM_NHOHON_6T"].ToString(),
                    NU_LONHON_6THANG = row["NU_LONHON_6THANG"].ToString(),
                }).ToList();
                return list;


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving province list: {ex.Message}");
                throw;
            }
        }
    }
}
