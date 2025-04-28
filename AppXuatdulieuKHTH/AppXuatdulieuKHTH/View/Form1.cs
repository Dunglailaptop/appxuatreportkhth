using AppXuatDuLieuKHTH.Controller;
using AppXuatDuLieuKHTH.Models;
using System.Data;
using System.Windows.Forms;

namespace AppXuatDuLieuKHTH
{
    public partial class Form1 : Form
    {
        public int type = 0;

        private PatientController _patientController;

        private reportTinhThanh _reportTinhthanh;

        private reportQuanHuyen _reportQuanHuyen;

        private rpTuoi _reportTuoi;
        public Form1()
        {
            InitializeComponent();
            setup();
            load_data_report_nhiemthongtu54();
        }
        public void setup()
        {
            check_date.Checked = true;
            datagv_report_tinhthanh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datagv_rp_quanhuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            data_grv_report_tuoi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _reportTuoi = new rpTuoi();
            _reportQuanHuyen = new reportQuanHuyen();
            _patientController = new PatientController();
            _reportTinhthanh = new reportTinhThanh();
        }
        // load data report báo cáo tuổi
        private async void load_data_report_tuoi()
        {
            try
            {
                DateTime tuNgay = date_rptungay_tuoi.Value.Date; // Chỉ lấy phần ngày (bỏ giờ, phút, giây)
                DateTime toiNgay = date_toingay_tuoi.Value.Date;

                if (tuNgay > toiNgay)
                {
                    MessageBox.Show("Tu ngay phai nho hon toi ngay tiep theo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng xử lý nếu điều kiện không thỏa mãn
                }
                string gettungay = date_rptungay_tuoi.Value.ToString("dd/MM/yyyy");

                string gettoingay = date_toingay_tuoi.Value.ToString("dd/MM/yyyy");
                var data = await _reportTuoi.getReporttuoi(gettungay, gettoingay);
                data_grv_report_tuoi.DataSource = data;
                total_rptuoi.Text = data.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not connection to server");
            }

        }
        //load data report báo cáo quận huyện
        private async void load_data_report_quanhuyen()
        {
            try
            {
                DateTime tuNgay = date_tungay_rpquanhuyen.Value.Date; // Chỉ lấy phần ngày (bỏ giờ, phút, giây)
                DateTime toiNgay = date_toingay_rpquanhuyen.Value.Date;

                if (tuNgay > toiNgay)
                {
                    MessageBox.Show("Tu ngay phai nho hon toi ngay tiep theo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng xử lý nếu điều kiện không thỏa mãn
                }
                string gettungay = date_tungay_rpquanhuyen.Value.ToString("dd/MM/yyyy");

                string gettoingay = date_toingay_rpquanhuyen.Value.ToString("dd/MM/yyyy");
                var data = await _reportQuanHuyen.getReportQuanhuyen(gettungay, gettoingay);
                datagv_rp_quanhuyen.DataSource = data;
                total_rpquanhuyen.Text = data.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not connection to server");
            }

        }
        //load data report báo cáo tỉnh thành
        private async void load_data_report_tinhthanh()
        {
            try
            {
                DateTime tuNgay = date_tu_report_tinhthanh.Value.Date; // Chỉ lấy phần ngày (bỏ giờ, phút, giây)
                DateTime toiNgay = date_toi_report_tinhthanh.Value.Date;

                if (tuNgay > toiNgay)
                {
                    MessageBox.Show("Tu ngay phai nho hon toi ngay tiep theo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng xử lý nếu điều kiện không thỏa mãn
                }
                string gettungay = date_tu_report_tinhthanh.Value.ToString("dd/MM/yyyy");

                string gettoingay = date_toi_report_tinhthanh.Value.ToString("dd/MM/yyyy");
                var data = await _reportTinhthanh.getReportTinhThanh(gettungay, gettoingay);
                datagv_report_tinhthanh.DataSource = data;
                total_report_tinhthanh.Text = data.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not connection to server");
            }
        }

        //load data report báo cáo nhiễm thông tư 54



        private async void load_data_report_nhiemthongtu54()
        {
            Console.WriteLine(type);
            try
            {
                DateTime tuNgay = date_pic_start_report_nhiem.Value.Date; // Chỉ lấy phần ngày (bỏ giờ, phút, giây)
                DateTime toiNgay = date_pic_end__report_nhiem.Value.Date;

                if (tuNgay > toiNgay)
                {
                    MessageBox.Show("Tu ngay phai nho hon toi ngay tiep theo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng xử lý nếu điều kiện không thỏa mãn
                }
                string gettungay = date_pic_start_report_nhiem.Value.ToString("dd/MM/yyyy");

                string gettoingay = date_pic_end__report_nhiem.Value.ToString("dd/MM/yyyy");
                var data = await _patientController.getReportNhiem(gettungay, gettoingay, type);
                data_table_report_nhiem.DataSource = data;
                lb_total_data.Text = data.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not connection to server");
            }


        }

        public DataTable ConvertDataGridViewToDataTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // Thêm tên c?t
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                dt.Columns.Add(column.Name, column.ValueType ?? typeof(string));
            }

            // Thêm dòng d? li?u
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow) // B? qua dòng tr?ng cu?i
                {
                    DataRow dr = dt.NewRow();
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        dr[column.Name] = row.Cells[column.Name].Value ?? DBNull.Value;
                    }
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }


        public async Task ExportReportNhiem()
        {
            try
            {
                _patientController.ExportFile(ConvertDataGridViewToDataTable(data_table_report_nhiem), "baocaonhiemthongtu54");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i: {ex.Message}", "L?i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_export_excel_report_nhiem_Click(object sender, EventArgs e)
        {

            ExportReportNhiem();
        }

        private void split_report_nhiem_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void check_date_CheckedChanged(object sender, EventArgs e)
        {
            if (check_date.Checked)
            {
                type = 1;
                check_month.Checked = false;
            }
            else
            {
                type = 2;
                check_month.Checked = true;
            }
        }

        private void check_month_CheckedChanged(object sender, EventArgs e)
        {
            if (check_month.Checked)
            {
                type = 2;
                check_date.Checked = false;
            }
            else
            {
                type = 1;
                check_date.Checked = true;
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            load_data_report_nhiemthongtu54();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = tabControl1.SelectedIndex;

            // Kiểm tra tab hợp lệ
            if (selectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn một tab!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Gọi hàm tương ứng dựa trên tab
            switch (selectedIndex)
            {
                case 0:
                    load_data_report_nhiemthongtu54();
                    break;
                case 1:

                    break;
                case 2:
                    load_data_report_tinhthanh();
                    break;
                case 3:
                    load_data_report_quanhuyen();
                    break;
                case 4:
                    load_data_report_tuoi();
                    break;
                default:
                    MessageBox.Show("Tab không được hỗ trợ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void btn_tim_report_tinhthanh_Click(object sender, EventArgs e)
        {
            load_data_report_tinhthanh();
        }

        private void btn_xuat_excel_report_tinhthanh_Click(object sender, EventArgs e)
        {
            _reportTinhthanh.ExportFile(ConvertDataGridViewToDataTable(datagv_report_tinhthanh), "BAOCAOTINHTHANH");
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void btn_rpquanhuyen_Click(object sender, EventArgs e)
        {
            load_data_report_quanhuyen();
        }

        private void btn_search_rptuoi_Click(object sender, EventArgs e)
        {
            load_data_report_tuoi();
        }

        private void btn_excel_rpquanhuyen_Click(object sender, EventArgs e)
        {
            _reportQuanHuyen.ExportFileThongKe(ConvertDataGridViewToDataTable(datagv_rp_quanhuyen), "BAOCAOQUANHUYEN");
        }

        private void btn_export_excel_rptuoi_Click(object sender, EventArgs e)
        {
            _reportTuoi.ExportFileThongKe(ConvertDataGridViewToDataTable(data_grv_report_tuoi), "BAOCAOTUOI");
        }
    }
}
