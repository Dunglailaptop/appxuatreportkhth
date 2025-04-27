using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXuatDuLieuKHTH.Models
{
    public class Patient
    {
        public int STT { get; set; }
        public string HoTenBenhNhan { get; set; }
        public string MaBn { get; set; }
        public string NgaySinh { get; set; }
        public string Phai { get; set; }
        public string? MaDanToc { get; set; }
        public string? TenNgheNghiep { get; set; }
        public string? DiaChiThuongTru { get; set; }
        public string? TenPhuongXaThuongTru { get; set; }
        public string? TenQuanHuyenThuongTru { get; set; }
        public string? TenTinhThanhThuongTru { get; set; }
        public string? TenPhuongXaTamTru { get; set; }
        public string? TenQuanHuyenTamTru { get; set; }
        public string? TenTinhThanhTamTru { get; set; }
        public string? DiaChiTamTru { get; set; }
        public string? HoTenBoMe { get; set; }
        public string? DienThoai { get; set; }
        public string? Chandoanchinh { get; set; }
        public string? DieuTri { get; set; } = "";
        public string? SoLanTieu { get; set; }
        public string? PhanLoaiChuanDoan { get; set; }
        public string? LayMauXetNghiem { get; set; }
        public string? NgayKhoiPhat { get; set; } = "";
        public string? NgayNhapVien { get; set; }
        public string? NgayRaVien { get; set; }
        public string? TinhTrangHienTai { get; set; }
        public string HoTenNguoiLap { get; set; } = "KẾ HOẠCH TỔNG HỢP";
        public string DienThoaiNguoiLap { get; set; } = "2838245923";
        public string EmailNguoiLap { get; set; } = "bv.nd2.khth@gmail.com";



    }
}
