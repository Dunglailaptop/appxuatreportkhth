using AppXuatDuLieuKHTH.Data;
using AppXuatDuLieuKHTH.Helper;
using AppXuatDuLieuKHTH.Models;
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
