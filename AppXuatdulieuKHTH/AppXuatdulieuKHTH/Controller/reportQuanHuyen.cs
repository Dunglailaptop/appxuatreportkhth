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
    public class reportQuanHuyen
    {
        private readonly ConnectionDB _connectiondb;

        public reportQuanHuyen()
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
                    worksheet.Range("A1:E1").Merge();
                    worksheet.Cell(1, 1).Value = "BÁO CÁO PHÂN LOẠI THÀNH PHỐ";
                    worksheet.Cell(1, 1).Style.Font.Bold = true;
                    worksheet.Cell(1, 1).Style.Font.FontName = "Arial";
                    worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                    worksheet.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Tên cột
                    string[] headers = new[]
                    {
                "STT", "Mã Quận/Huyện", "Tên Quận/Huyện", "Số trẻ < 6 tháng", "Số trẻ ≥ 6 tháng"
            };

                    double[] columnWidths = new double[] { 8, 15, 25, 20, 20 };

                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cell(3, i + 1).Value = headers[i];
                        worksheet.Column(i + 1).Width = columnWidths[i];
                    }

                    // Định dạng header
                    var headerRange = worksheet.Range("A3:E3");
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Font.FontName = "Arial";
                    headerRange.Style.Fill.BackgroundColor = XLColor.LightGreen;
                    headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    // Đổ dữ liệu
                    for (int row = 0; row < dataTable.Rows.Count; row++)
                    {
                        for (int col = 0; col < dataTable.Columns.Count; col++)
                        {
                            worksheet.Cell(row + 4, col + 1).Value = dataTable.Rows[row][col]?.ToString();
                            worksheet.Cell(row + 4, col + 1).Style.Font.FontName = "Arial";
                        }
                    }

                    // Định dạng dữ liệu
                    var dataRange = worksheet.Range(4, 1, dataTable.Rows.Count + 3, dataTable.Columns.Count);
                    dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    dataRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                    // Lưu file
                    using (var saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx",
                        FileName = "baocaoquanhuyentphcm.xlsx"
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


        public async Task<List<rpQuanHuyen>> getReportQuanhuyen(string tungay, string toingay)
        {
            try
            {

                string query = constant.searchreport_quanhuyen(tungay, toingay);
                var result = new DataTable();
                int count = 0;
                result = await _connectiondb.GetConnectionList(query);
                var list = result.AsEnumerable().Select(row => new rpQuanHuyen
                {
                    STT = ++count,
                    MaQuanHuyen = row["MAQUANHUYEN"].ToString(),
                    TenQuanHuyen = row["TENQUANHUYEN"].ToString(),
                    BeNhoHon6T = row["SO_BN_NHO_HON_6THANG"].ToString(),
                    BeLonHon6T = row["SO_BN_LON_HON_6THANG"].ToString(),
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
