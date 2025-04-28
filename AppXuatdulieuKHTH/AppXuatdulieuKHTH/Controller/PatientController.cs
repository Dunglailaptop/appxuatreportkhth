using AppXuatDuLieuKHTH.Data;
using AppXuatDuLieuKHTH.Helper;
using AppXuatDuLieuKHTH.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using System.Drawing;
using ClosedXML.Excel;

namespace AppXuatDuLieuKHTH.Controller
{
    public class PatientController
    {
        private readonly ConnectionDB _connectiondb;

        public PatientController()
        {
            _connectiondb = new ConnectionDB();
        }


        public void ExportFile(DataTable dataTable, string sheetName)
        {
            try
            {
                // Kiểm tra đầu vào
              
            

                // Debug title và DataTable
             
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine($"Row: {string.Join(", ", row.ItemArray)}");
                }

                // Tạo workbook
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(sheetName);

                    // Tạo tiêu đề chính
                    worksheet.Range("A1:AC1").Merge(); // Từ cột A đến AC (29 cột)
                    worksheet.Cell(1, 1).Value = "DANH SÁCH BỆNH TRUYỀN NHIỄM NỘI TRÚ - NGOẠI TRÚ TỪ NGÀY 21/03/2025"; // Sử dụng tham số title
                    worksheet.Cell(1, 1).Style.Font.Bold = true;
                    worksheet.Cell(1, 1).Style.Font.FontName = "Arial";
                    worksheet.Cell(1, 1).Style.Font.FontSize = 20;
                    worksheet.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Tạo tiêu đề cột (dòng 3)
                    string[] headers = new[]
                    {
                        "STT", "Họ và tên", "Mã quản lý tại cơ sở", "Ngày sinh", "Giới tính",
                        "Dân tộc", "Nghề nghiệp", "Địa chỉ thường trú", "Phường/xã thường trú",
                        "Quận/huyện thường trú", "Tỉnh/TP thường trú", "Phường/xã tạm trú",
                        "Quận/huyện tạm trú", "Tỉnh/TP tạm trú", "Địa chỉ tạm trú",
                        "Họ tên cha/mẹ", "Điện thoại", "Chẩn đoán chính", "Điều trị",
                        "Số lần tiêm/uống", "Phân loại chẩn đoán", "Lấy mẫu xét nghiệm",
                        "Ngày khởi phát", "Ngày nhập viện/Ngày khám", "Ngày ra viện/chuyển viện/tử vong",
                        "Tình trạng hiện tại", "Họ và tên người lập", "Số điện thoại người lập", "Email người lập"
                    };
                    double[] columnWidths = new double[]
                    {
                12, 25, 15, 10.5, 10, 15, 20, 30, 15, 15, 15, 15, 15, 15, 30,
                20, 15, 20, 15, 15, 15, 15, 15, 15, 15, 15, 25, 15, 20
                    };

                    for (int i = 0; i < headers.Length; i++)
                    {
                        worksheet.Cell(3, i + 1).Value = headers[i];
                        worksheet.Column(i + 1).Width = columnWidths[i];
                    }

                    // Định dạng tiêu đề cột
                    var headerRange = worksheet.Range("A3:AC3"); // Từ cột A đến AC
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Font.FontName = "Arial";
                    headerRange.Style.Fill.BackgroundColor = XLColor.Yellow;
                    headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // Điền dữ liệu (từ dòng 4)
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
                        FileName = "benh_nhan_nhiem.xlsx"
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


        public async Task<List<Patient>> getReportNhiem(string dateto, string dateform, int type)
        {
            try
            {
               
                    string query = constant.searchreport_nhiem(dateto, dateform,type);
                    var result = new DataTable();
                    int count = 0;
                    result = await _connectiondb.GetConnectionList(query);
                    var list = result.AsEnumerable().Select(row => new Patient
                    {
                        STT = ++count,
                        HoTenBenhNhan = $"{row["HOBENHNHAN"]} {row["CHULOTBENHNHAN"]} {row["TENBENHNHAN"]}".Trim(),
                        MaBn = row["MABN"].ToString(),
                        NgaySinh = constant.ConvertToDateFormat(row["NGAYSINH"].ToString()),
                        Phai = row["PHAI"].ToString() == "1" ? "Nam" : "Nữ",
                        MaDanToc = row["TENDANTOC"].ToString(),
                        TenNgheNghiep = row["TENNGHENGHIEP"].ToString(),
                        DiaChiThuongTru = $"{row["THON"]}, {row["TENPHUONGXA_THUONGTRU"]}, {row["TENQUANHUYEN_THUONGTRU"]}, {row["TENTINHTHANH_THUONGTRU"]}".Trim(),
                        TenPhuongXaThuongTru = row["TENPHUONGXA_THUONGTRU"].ToString(),
                        TenQuanHuyenThuongTru = row["TENQUANHUYEN_THUONGTRU"].ToString(),
                        TenTinhThanhThuongTru = row["TENTINHTHANH_THUONGTRU"].ToString(),
                        DiaChiTamTru = row["DIACHITAMTRU"].ToString(),
                        TenPhuongXaTamTru = row["TENPHUONGXA_TAMTRU"].ToString(),
                        TenQuanHuyenTamTru = row["TENQUANHUYEN_TAMTRU"].ToString(),
                        TenTinhThanhTamTru = row["TENTINHTHANH_TAMTRU"].ToString(),
                        HoTenBoMe = $"Họ tên cha: {row["HOTENBO"]}|Họ tên mẹ: {row["HOTENME"]}",
                        DienThoai = row["DIENTHOAI"].ToString(),
                        Chandoanchinh = row["MAICD"].ToString(),
                        PhanLoaiChuanDoan = row["BENHCHINH"].ToString(),
                        NgayNhapVien = constant.ConvertToDateFormat(row["NGAY"].ToString()),

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
