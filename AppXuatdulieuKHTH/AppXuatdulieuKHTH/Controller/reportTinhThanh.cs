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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppXuatDuLieuKHTH.Controller
{
    public class reportTinhThanh
    {
        private readonly ConnectionDB _connectiondb;

        public reportTinhThanh()
        {
            _connectiondb = new ConnectionDB();
        }

        public void ExportFile(DataTable dataTable, string sheetName)
        {
            try
            {
                // Kiểm tra đầu vào
                if (dataTable == null || dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Debug DataTable
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine($"Row: {string.Join(", ", row.ItemArray)}");
                }

                // Tạo workbook
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(sheetName);

                    // Tạo tiêu đề chính
                    worksheet.Range("A1:E1").Merge(); // Từ cột A đến D (4 cột)
                    worksheet.Cell(1, 1).Value = "BÁO CÁO TỈNH THÀNH";
                    worksheet.Cell(1, 1).Style.Font.Bold = true;
                    worksheet.Cell(1, 1).Style.Font.FontName = "Arial";
                    worksheet.Cell(1, 1).Style.Font.FontSize = 20;
                    worksheet.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Tạo tiêu đề cột (dòng 3)
                    string[] headers = new[]
                    {
                "STT", "Mã tỉnh thành", "Tên tỉnh thành", "Bệnh nhân nhỏ hơn 6 tháng", "Bệnh nhân lớn hơn 6 tháng"
            };
                    double[] columnWidths = new double[]
                    {
                8, 15, 30, 20, 20
                    };

                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cell(3, i + 1).Value = headers[i];
                        worksheet.Column(i + 1).Width = columnWidths[i];
                    }

                    // Định dạng tiêu đề cột
                    var headerRange = worksheet.Range("A3:E3"); // Từ cột A đến D
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Font.FontName = "Arial";
                    headerRange.Style.Fill.BackgroundColor = XLColor.Yellow;
                    headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Điền dữ liệu (từ dòng 4)
                    for (int row = 0; row < dataTable.Rows.Count; row++)
                    {
                        // Cột STT
                       
                        // Cột Mã tỉnh thành, Tên tỉnh thành, Số BN nhỏ hơn 6 tháng, Số BN lớn hơn 6 tháng
                        for (int col = 0; col < dataTable.Columns.Count; col++)
                        {
                         
                            worksheet.Cell(row + 4, col + 1).Value = dataTable.Rows[row][col]?.ToString();
                            worksheet.Cell(row + 4, col + 1).Style.Font.FontName = "Arial";
                        }
                    }

                    // Định dạng dữ liệu
                    var dataRange = worksheet.Range(4, 1, dataTable.Rows.Count + 3, dataTable.Columns.Count); // 5 cột (A đến D)
                    dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    dataRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                    // Lưu file
                    using (var saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx",
                        FileName = "bao_cao_tinh_thanh.xlsx"
                    })
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            using (var stream = new MemoryStream())
                            {
                                workbook.SaveAs(stream);
                                File.WriteAllBytes(saveFileDialog.FileName, stream.ToArray());
                            }
                            MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public async Task<List<RP_TinhThanh>> getReportTinhThanh(string tungay,string toingay)
        {
            try
            {

                string query = constant.searchreport_tinhthanh(tungay, toingay);
                var result = new DataTable();
                int count = 0;
                result = await _connectiondb.GetConnectionList(query);
                var list = result.AsEnumerable().Select(row => new RP_TinhThanh
                {
                    STT = ++count,
                    MaTinhThanh = row["MATINHTHANH"].ToString(),
                    TenThinhThanh = row["TENTINHTHANH"].ToString(),
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
