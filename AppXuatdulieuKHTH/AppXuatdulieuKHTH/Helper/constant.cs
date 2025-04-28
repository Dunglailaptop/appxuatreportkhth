using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXuatDuLieuKHTH.Helper
{
    public static class constant
    {
        

        /// <summary>
        /// Thiết lập khoảng thời gian cho date_from và date_to từ DateTimePicker.
        /// Kiểm tra điều kiện Từ ngày <= Tới ngày.
        /// </summary>
        /// <param name="dtpTuNgay">DateTimePicker Từ ngày.</param>
        /// <param name="dtpToiNgay">DateTimePicker Tới ngày.</param>
        /// <returns>True nếu hợp lệ, False nếu Từ ngày > Tới ngày.</returns>
   
        public static string ConvertToDateFormat(string input, string defaultValue = "")
        {
            try
            {
                // Kiểm tra nếu input là null hoặc chuỗi rỗng
                if (string.IsNullOrWhiteSpace(input))
                {
                    return defaultValue;
                }

                // Định dạng đầu vào: M/dd/yyyy h:mm:ss tt (VD: "9/13/2020 12:00:00 AM")
                string inputFormat = "M/dd/yyyy h:mm:ss tt";
                // Phân tích chuỗi đầu vào
                if (DateTime.TryParseExact(input.Trim(), inputFormat,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                {
                    // Chuyển đổi sang định dạng dd/MM/yyyy
                    return parsedDate.ToString("dd/MM/yyyy");
                }

                // Nếu không phân tích được, trả về giá trị mặc định
                return defaultValue;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                Console.WriteLine($"Lỗi chuyển đổi ngày: {ex.Message}");
                return defaultValue;
            }
        }


        public static string searchreport_tuoi(string tungay,string toingay)
        {
            string query = @"SELECT 
                        COUNT(DISTINCT CASE WHEN TO_NUMBER(SUBSTR(PD2.TUOI, 2, 2)) < 1 AND PD2.PHAI = '1' THEN PD2.MABN END) AS NAM_NHOHON_1T,
                        COUNT(DISTINCT CASE WHEN TO_NUMBER(SUBSTR(PD2.TUOI, 2, 2)) < 1 AND PD2.PHAI = '0' THEN PD2.MABN END) AS NU_NHOHON_1T,

                        COUNT(DISTINCT CASE WHEN TO_NUMBER(SUBSTR(PD2.TUOI, 2, 2)) < 2 AND PD2.PHAI = '1' THEN PD2.MABN END) AS NAM_NHOHON_2T,
                        COUNT(DISTINCT CASE WHEN TO_NUMBER(SUBSTR(PD2.TUOI, 2, 2)) < 2 AND PD2.PHAI = '0' THEN PD2.MABN END) AS NU_NHOHON_2T,

                        COUNT(DISTINCT CASE WHEN TO_NUMBER(SUBSTR(PD2.TUOI, 2, 2)) < 3 AND PD2.PHAI = '1' THEN PD2.MABN END) AS NAM_NHOHON_3T,
                        COUNT(DISTINCT CASE WHEN TO_NUMBER(SUBSTR(PD2.TUOI, 2, 2)) < 3 AND PD2.PHAI = '0' THEN PD2.MABN END) AS NU_NHOHON_3T,

                        COUNT(DISTINCT CASE WHEN TO_NUMBER(SUBSTR(PD2.TUOI, 2, 2)) < 4 AND PD2.PHAI = '1' THEN PD2.MABN END) AS NAM_NHOHON_4T,
                        COUNT(DISTINCT CASE WHEN TO_NUMBER(SUBSTR(PD2.TUOI, 2, 2)) < 4 AND PD2.PHAI = '0' THEN PD2.MABN END) AS NU_NHOHON_4T,

                        COUNT(DISTINCT CASE WHEN TO_NUMBER(SUBSTR(PD2.TUOI, 2, 2)) < 5 AND PD2.PHAI = '1' THEN PD2.MABN END) AS NAM_NHOHON_5T,
                        COUNT(DISTINCT CASE WHEN TO_NUMBER(SUBSTR(PD2.TUOI, 2, 2)) < 5 AND PD2.PHAI = '0' THEN PD2.MABN END) AS NU_NHOHON_5T,

                        COUNT(DISTINCT CASE WHEN TO_NUMBER(SUBSTR(PD2.TUOI, 2, 2)) < 6 AND PD2.PHAI = '1' THEN PD2.MABN END) AS NAM_NHOHON_6T,
                        COUNT(DISTINCT CASE WHEN TO_NUMBER(SUBSTR(PD2.TUOI, 2, 2)) < 6 AND PD2.PHAI = '0' THEN PD2.MABN END) AS NU_NHOHON_6T,
    
                        COUNT(DISTINCT CASE WHEN TO_NUMBER(SUBSTR(PD2.TUOI, 2, 2)) > 6 AND PD2.PHAI = '1' THEN PD2.MABN END) AS NAM_LONHON_6THANG,
                        COUNT(DISTINCT CASE WHEN TO_NUMBER(SUBSTR(PD2.TUOI, 2, 2)) > 6 AND PD2.PHAI = '0' THEN PD2.MABN END) AS NU_LONHON_6THANG

                        FROM 
                        P_BENHANDT PD
                        LEFT JOIN P_DMBENHNHAN PD2 ON PD.MABN = PD2.MABN
                        WHERE 
                        TRUNC(PD.NGAY) >= TO_DATE('"+ tungay + @"', 'DD/MM/YYYY') 
                        AND TRUNC(PD.NGAY) <= TO_DATE('"+ toingay + @"', 'DD/MM/YYYY')";
            return query;
        }

        public static string searchreport_quanhuyen(string tungay,string toingay)
        {
            string query = @"SELECT 
                    PD3.MAQUANHUYEN,
                    PD3.TENQUANHUYEN,
                    COUNT(DISTINCT CASE WHEN TO_NUMBER(SUBSTR(PD2.TUOI, 2, 2)) <= 6 THEN PD2.MABN END) AS SO_BN_NHO_HON_6THANG,
                    COUNT(DISTINCT CASE WHEN TO_NUMBER(SUBSTR(PD2.TUOI, 2, 2)) > 6 THEN PD2.MABN END) AS SO_BN_LON_HON_6THANG
                FROM 
                    P_BENHANDT PD
                    LEFT JOIN P_DMBENHNHAN PD2 ON PD.MABN = PD2.MABN
                    LEFT JOIN P_DMQUANHUYEN PD3 ON PD2.MAQUANHUYEN  = PD3.MAQUANHUYEN 
                WHERE 
                    TRUNC(PD.NGAY) >= TO_DATE('" + tungay + @"', 'DD/MM/YYYY') 
                    AND TRUNC(PD.NGAY) <= TO_DATE('" + toingay + @"', 'DD/MM/YYYY')
                    AND PD3.MATINHTHANH = '79'
                GROUP BY 
                    PD3.MAQUANHUYEN,
                    PD3.TENQUANHUYEN";
            return query;
        }

      public static string searchreport_tinhthanh(string date_tungay,string date_toingay)
        {
            string query = @"SELECT 
                        pd4.MATINHTHANH,
                        pd4.TENTINHTHANH,
                        COUNT(CASE WHEN TO_NUMBER(SUBSTR(PD2.TUOI, 2, 2)) <= 6 THEN 1 END) AS SO_BN_NHO_HON_6THANG,
                        COUNT(CASE WHEN TO_NUMBER(SUBSTR(PD2.TUOI, 2, 2)) > 6 THEN 1 END) AS SO_BN_LON_HON_6THANG
                    FROM 
                        P_BENHANDT pd
                        LEFT JOIN P_DMBENHNHAN pd2 ON pd.MABN = PD2.MABN
                        LEFT JOIN P_DMTINHTHANH pd4 ON pd4.MATINHTHANH = PD2.MATINHTHANH
                    WHERE 
                       TRUNC(PD.NGAY) >= TO_DATE('" + date_tungay + @"', 'DD/MM/YYYY') 
                       AND TRUNC(PD.NGAY) <= TO_DATE('" + date_toingay + @"', 'DD/MM/YYYY')
                    GROUP BY 
                        pd4.MATINHTHANH,
                        pd4.TENTINHTHANH";
            return query;
        }


      public static string searchreport_nhiem(string date_tungay,string date_toingay,int type)
        {
            string query = "";
            string query_get = "";
            string query_ngay = @"'A80', 'A36', 'B95', 'A20', 'A98.4', 'A96.2', 'A98.3', 'B06', 
                        'A92.3', 'A95', 'A97', 'A91', 'A90', 'B05', 'A00', 'B08.4', 
                        'A22', 'U07.1', 'A39.0', 'A82', 'A37', 'A15', 'A01', 'A33', 
                        'A35', 'A34', 'B15', 'B16', 'B17.1', 'A83.0'";
            string query_thang = @"'B30.0','J10','A06','A03','B26','B01','A09','A08','B17'";
            if (type == 1) {
                query_get = query_ngay;
                query = @"
                        SELECT 
                            PD2.HOBENHNHAN,
                            PD2.TENBENHNHAN,
                            PD2.CHULOTBENHNHAN,
                            PD2.MABN,
                            PD2.TUOI,
                            PD2.NGAYSINH,
                            PD2.PHAI,
                            PD10.TENDANTOC,
                            PD9.TENNGHENGHIEP,
                            PD2.THON,
                            PD3.TENQUANHUYEN AS TENQUANHUYEN_THUONGTRU,      
                            PD5.TENPHUONGXA AS TENPHUONGXA_THUONGTRU,        
                            PD4.TENTINHTHANH AS TENTINHTHANH_THUONGTRU,     
                            PD6.TENPHUONGXA AS TENPHUONGXA_TAMTRU,          
                            PD7.TENQUANHUYEN AS TENQUANHUYEN_TAMTRU,        
                            PD8.TENTINHTHANH AS TENTINHTHANH_TAMTRU,        
                            PD2.DIACHITAMTRU,
                            PD2.MAPHUONGXATAMTRU,
                            PD2.HOTENME,
                            PD2.HOTENBO,
                            PD2.DIENTHOAI,
                            PD.MAICD,
                            PD.BENHCHINH,
                            PD.NGAY,
                            PD.DONE
                        FROM 
                            P_BENHANDT pd
                            LEFT JOIN P_DMBENHNHAN pd2 ON pd.MABN = PD2.MABN
                            LEFT JOIN P_DMQUANHUYEN pd3 ON PD3.MAQUANHUYEN = PD2.MAQUANHUYEN 
                            LEFT JOIN P_DMTINHTHANH pd4 ON PD4.MATINHTHANH = PD2.MATINHTHANH 
                            LEFT JOIN P_DMPHUONGXA pd5 ON PD5.MAPHUONGXA = PD2.MAPHUONGXA
                            LEFT JOIN P_DMPHUONGXA pd6 ON PD6.MAPHUONGXA = PD2.MAPHUONGXATAMTRU
                            LEFT JOIN P_DMQUANHUYEN pd7 ON PD7.MAQUANHUYEN = PD6.MAQUANHUYEN
                            LEFT JOIN P_DMTINHTHANH pd8 ON PD8.MATINHTHANH = PD7.MATINHTHANH
                            LEFT JOIN P_DMNGHENGHIEP pd9 ON TO_NUMBER(PD2.MANGHENGHIEP) = TO_NUMBER(PD9.MANGHENGHIEP)
                            LEFT JOIN P_DMDANTOC pd10 ON pd10.MADANTOC = pd2.MADANTOC 
                        WHERE 
                            (
                                PD.MAICD IN (
                                    " + query_ngay + @"
                                )
                                OR (PD.MAICD BETWEEN 'B50' AND 'B54')
                                OR (PD.MAICD BETWEEN 'A83' AND 'A85')
                            )
                            AND TRUNC(PD.NGAY) >= TO_DATE('" + date_tungay + @"', 'DD/MM/YYYY') 
                            AND TRUNC(PD.NGAY) <= TO_DATE('" + date_toingay + @"', 'DD/MM/YYYY')
                ";

            }
            else
            {
                query_get = query_thang;
               query = @"
                        SELECT 
                            PD2.HOBENHNHAN,
                            PD2.TENBENHNHAN,
                            PD2.CHULOTBENHNHAN,
                            PD2.MABN,
                            PD2.TUOI,
                            PD2.NGAYSINH,
                            PD2.PHAI,
                            PD10.TENDANTOC,
                            PD9.TENNGHENGHIEP,
                            PD2.THON,
                            PD3.TENQUANHUYEN AS TENQUANHUYEN_THUONGTRU,      
                            PD5.TENPHUONGXA AS TENPHUONGXA_THUONGTRU,        
                            PD4.TENTINHTHANH AS TENTINHTHANH_THUONGTRU,     
                            PD6.TENPHUONGXA AS TENPHUONGXA_TAMTRU,          
                            PD7.TENQUANHUYEN AS TENQUANHUYEN_TAMTRU,        
                            PD8.TENTINHTHANH AS TENTINHTHANH_TAMTRU,        
                            PD2.DIACHITAMTRU,
                            PD2.MAPHUONGXATAMTRU,
                            PD2.HOTENME,
                            PD2.HOTENBO,
                            PD2.DIENTHOAI,
                            PD.MAICD,
                            PD.BENHCHINH,
                            PD.NGAY,
                            PD.DONE
                        FROM 
                            P_BENHANDT pd
                            LEFT JOIN P_DMBENHNHAN pd2 ON pd.MABN = PD2.MABN
                            LEFT JOIN P_DMQUANHUYEN pd3 ON PD3.MAQUANHUYEN = PD2.MAQUANHUYEN 
                            LEFT JOIN P_DMTINHTHANH pd4 ON PD4.MATINHTHANH = PD2.MATINHTHANH 
                            LEFT JOIN P_DMPHUONGXA pd5 ON PD5.MAPHUONGXA = PD2.MAPHUONGXA
                            LEFT JOIN P_DMPHUONGXA pd6 ON PD6.MAPHUONGXA = PD2.MAPHUONGXATAMTRU
                            LEFT JOIN P_DMQUANHUYEN pd7 ON PD7.MAQUANHUYEN = PD6.MAQUANHUYEN
                            LEFT JOIN P_DMTINHTHANH pd8 ON PD8.MATINHTHANH = PD7.MATINHTHANH
                            LEFT JOIN P_DMNGHENGHIEP pd9 ON TO_NUMBER(PD2.MANGHENGHIEP) = TO_NUMBER(PD9.MANGHENGHIEP)
                            LEFT JOIN P_DMDANTOC pd10 ON pd10.MADANTOC = pd2.MADANTOC 
                        WHERE 
                            (
                                PD.MAICD IN (
                                    " + query_thang + @"
                                )
                                OR (PD.MAICD BETWEEN 'B50' AND 'B54')
                                OR (PD.MAICD BETWEEN 'A83' AND 'A85')
                            )
                            AND TRUNC(PD.NGAY) >= TO_DATE('" + date_tungay + @"', 'DD/MM/YYYY') 
                            AND TRUNC(PD.NGAY) <= TO_DATE('" + date_toingay + @"', 'DD/MM/YYYY')
                ";
            }
           
         
            return query;
        }

    }
}
