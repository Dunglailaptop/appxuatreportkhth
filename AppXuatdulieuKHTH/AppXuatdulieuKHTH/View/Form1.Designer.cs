namespace AppXuatDuLieuKHTH
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            split_report_nhiem = new SplitContainer();
            lb_total_data = new Label();
            label3 = new Label();
            btn_search = new Button();
            check_month = new CheckBox();
            check_date = new CheckBox();
            btn_export_excel_report_nhiem = new Button();
            label2 = new Label();
            date_pic_end__report_nhiem = new DateTimePicker();
            label1 = new Label();
            date_pic_start_report_nhiem = new DateTimePicker();
            data_table_report_nhiem = new DataGridView();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            splitContainer1 = new SplitContainer();
            total_report_tinhthanh = new Label();
            label5 = new Label();
            btn_tim_report_tinhthanh = new Button();
            btn_xuat_excel_report_tinhthanh = new Button();
            label6 = new Label();
            date_toi_report_tinhthanh = new DateTimePicker();
            label7 = new Label();
            date_tu_report_tinhthanh = new DateTimePicker();
            datagv_report_tinhthanh = new DataGridView();
            tabPage4 = new TabPage();
            splitContainer2 = new SplitContainer();
            total_rpquanhuyen = new Label();
            label8 = new Label();
            btn_rpquanhuyen = new Button();
            btn_excel_rpquanhuyen = new Button();
            label9 = new Label();
            date_toingay_rpquanhuyen = new DateTimePicker();
            label10 = new Label();
            date_tungay_rpquanhuyen = new DateTimePicker();
            datagv_rp_quanhuyen = new DataGridView();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)split_report_nhiem).BeginInit();
            split_report_nhiem.Panel1.SuspendLayout();
            split_report_nhiem.Panel2.SuspendLayout();
            split_report_nhiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)data_table_report_nhiem).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)datagv_report_tinhthanh).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)datagv_rp_quanhuyen).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1032, 689);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(split_report_nhiem);
            tabPage1.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1024, 661);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Báo cáo bệnh nhiễm theo thông tư 54";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // split_report_nhiem
            // 
            split_report_nhiem.Dock = DockStyle.Fill;
            split_report_nhiem.Location = new Point(3, 3);
            split_report_nhiem.Name = "split_report_nhiem";
            split_report_nhiem.Orientation = Orientation.Horizontal;
            // 
            // split_report_nhiem.Panel1
            // 
            split_report_nhiem.Panel1.Controls.Add(lb_total_data);
            split_report_nhiem.Panel1.Controls.Add(label3);
            split_report_nhiem.Panel1.Controls.Add(btn_search);
            split_report_nhiem.Panel1.Controls.Add(check_month);
            split_report_nhiem.Panel1.Controls.Add(check_date);
            split_report_nhiem.Panel1.Controls.Add(btn_export_excel_report_nhiem);
            split_report_nhiem.Panel1.Controls.Add(label2);
            split_report_nhiem.Panel1.Controls.Add(date_pic_end__report_nhiem);
            split_report_nhiem.Panel1.Controls.Add(label1);
            split_report_nhiem.Panel1.Controls.Add(date_pic_start_report_nhiem);
            split_report_nhiem.Panel1.Paint += split_report_nhiem_Panel1_Paint;
            // 
            // split_report_nhiem.Panel2
            // 
            split_report_nhiem.Panel2.Controls.Add(data_table_report_nhiem);
            split_report_nhiem.Size = new Size(1018, 655);
            split_report_nhiem.SplitterDistance = 98;
            split_report_nhiem.TabIndex = 0;
            // 
            // lb_total_data
            // 
            lb_total_data.AutoSize = true;
            lb_total_data.ForeColor = Color.Red;
            lb_total_data.Location = new Point(476, 67);
            lb_total_data.Name = "lb_total_data";
            lb_total_data.Size = new Size(13, 15);
            lb_total_data.TabIndex = 11;
            lb_total_data.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(387, 67);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 1;
            label3.Text = "Tổng số hồ sơ:";
            // 
            // btn_search
            // 
            btn_search.BackColor = Color.DodgerBlue;
            btn_search.ForeColor = Color.White;
            btn_search.Location = new Point(387, 18);
            btn_search.Margin = new Padding(3, 2, 3, 2);
            btn_search.Name = "btn_search";
            btn_search.Size = new Size(144, 47);
            btn_search.TabIndex = 10;
            btn_search.Text = "Tìm";
            btn_search.UseVisualStyleBackColor = false;
            btn_search.Click += btn_search_Click;
            // 
            // check_month
            // 
            check_month.AutoSize = true;
            check_month.Location = new Point(32, 50);
            check_month.Margin = new Padding(3, 2, 3, 2);
            check_month.Name = "check_month";
            check_month.Size = new Size(60, 19);
            check_month.TabIndex = 9;
            check_month.Text = "Tháng";
            check_month.UseVisualStyleBackColor = true;
            check_month.CheckedChanged += check_month_CheckedChanged;
            // 
            // check_date
            // 
            check_date.AutoSize = true;
            check_date.Location = new Point(32, 18);
            check_date.Margin = new Padding(3, 2, 3, 2);
            check_date.Name = "check_date";
            check_date.Size = new Size(53, 19);
            check_date.TabIndex = 8;
            check_date.Text = "Ngày";
            check_date.UseVisualStyleBackColor = true;
            check_date.CheckedChanged += check_date_CheckedChanged;
            // 
            // btn_export_excel_report_nhiem
            // 
            btn_export_excel_report_nhiem.BackColor = Color.ForestGreen;
            btn_export_excel_report_nhiem.ForeColor = Color.White;
            btn_export_excel_report_nhiem.Location = new Point(536, 18);
            btn_export_excel_report_nhiem.Name = "btn_export_excel_report_nhiem";
            btn_export_excel_report_nhiem.Size = new Size(152, 47);
            btn_export_excel_report_nhiem.TabIndex = 7;
            btn_export_excel_report_nhiem.Text = "Xuất Excel";
            btn_export_excel_report_nhiem.UseVisualStyleBackColor = false;
            btn_export_excel_report_nhiem.Click += btn_export_excel_report_nhiem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(137, 44);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 3;
            label2.Text = "Tới ngày:";
            label2.Click += label2_Click;
            // 
            // date_pic_end__report_nhiem
            // 
            date_pic_end__report_nhiem.CustomFormat = "dd/MM/yyyy";
            date_pic_end__report_nhiem.Format = DateTimePickerFormat.Custom;
            date_pic_end__report_nhiem.Location = new Point(137, 59);
            date_pic_end__report_nhiem.Name = "date_pic_end__report_nhiem";
            date_pic_end__report_nhiem.Size = new Size(200, 21);
            date_pic_end__report_nhiem.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(137, 2);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 1;
            label1.Text = "Từ ngày:";
            // 
            // date_pic_start_report_nhiem
            // 
            date_pic_start_report_nhiem.CustomFormat = "dd/MM/yyyy";
            date_pic_start_report_nhiem.Format = DateTimePickerFormat.Custom;
            date_pic_start_report_nhiem.Location = new Point(137, 18);
            date_pic_start_report_nhiem.Name = "date_pic_start_report_nhiem";
            date_pic_start_report_nhiem.Size = new Size(200, 21);
            date_pic_start_report_nhiem.TabIndex = 0;
            // 
            // data_table_report_nhiem
            // 
            data_table_report_nhiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            data_table_report_nhiem.Dock = DockStyle.Fill;
            data_table_report_nhiem.Location = new Point(0, 0);
            data_table_report_nhiem.Name = "data_table_report_nhiem";
            data_table_report_nhiem.RowHeadersWidth = 51;
            data_table_report_nhiem.Size = new Size(1018, 553);
            data_table_report_nhiem.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1024, 661);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Báo cáo phân loại chẩn đoán";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(splitContainer1);
            tabPage3.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1024, 661);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Báo cáo phân loại tỉnh thành";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(total_report_tinhthanh);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(btn_tim_report_tinhthanh);
            splitContainer1.Panel1.Controls.Add(btn_xuat_excel_report_tinhthanh);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(date_toi_report_tinhthanh);
            splitContainer1.Panel1.Controls.Add(label7);
            splitContainer1.Panel1.Controls.Add(date_tu_report_tinhthanh);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(datagv_report_tinhthanh);
            splitContainer1.Size = new Size(1018, 655);
            splitContainer1.SplitterDistance = 107;
            splitContainer1.TabIndex = 0;
            // 
            // total_report_tinhthanh
            // 
            total_report_tinhthanh.AutoSize = true;
            total_report_tinhthanh.ForeColor = Color.Red;
            total_report_tinhthanh.Location = new Point(345, 70);
            total_report_tinhthanh.Name = "total_report_tinhthanh";
            total_report_tinhthanh.Size = new Size(13, 15);
            total_report_tinhthanh.TabIndex = 21;
            total_report_tinhthanh.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(256, 72);
            label5.Name = "label5";
            label5.Size = new Size(83, 15);
            label5.TabIndex = 13;
            label5.Text = "Tổng số hồ sơ:";
            // 
            // btn_tim_report_tinhthanh
            // 
            btn_tim_report_tinhthanh.BackColor = Color.DodgerBlue;
            btn_tim_report_tinhthanh.ForeColor = Color.White;
            btn_tim_report_tinhthanh.Location = new Point(256, 23);
            btn_tim_report_tinhthanh.Margin = new Padding(3, 2, 3, 2);
            btn_tim_report_tinhthanh.Name = "btn_tim_report_tinhthanh";
            btn_tim_report_tinhthanh.Size = new Size(144, 47);
            btn_tim_report_tinhthanh.TabIndex = 20;
            btn_tim_report_tinhthanh.Text = "Tìm";
            btn_tim_report_tinhthanh.UseVisualStyleBackColor = false;
            btn_tim_report_tinhthanh.Click += btn_tim_report_tinhthanh_Click;
            // 
            // btn_xuat_excel_report_tinhthanh
            // 
            btn_xuat_excel_report_tinhthanh.BackColor = Color.ForestGreen;
            btn_xuat_excel_report_tinhthanh.ForeColor = Color.White;
            btn_xuat_excel_report_tinhthanh.Location = new Point(405, 23);
            btn_xuat_excel_report_tinhthanh.Name = "btn_xuat_excel_report_tinhthanh";
            btn_xuat_excel_report_tinhthanh.Size = new Size(152, 47);
            btn_xuat_excel_report_tinhthanh.TabIndex = 17;
            btn_xuat_excel_report_tinhthanh.Text = "Xuất Excel";
            btn_xuat_excel_report_tinhthanh.UseVisualStyleBackColor = false;
            btn_xuat_excel_report_tinhthanh.Click += btn_xuat_excel_report_tinhthanh_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 49);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 16;
            label6.Text = "Tới ngày:";
            // 
            // date_toi_report_tinhthanh
            // 
            date_toi_report_tinhthanh.CustomFormat = "dd/MM/yyyy";
            date_toi_report_tinhthanh.Format = DateTimePickerFormat.Custom;
            date_toi_report_tinhthanh.Location = new Point(6, 64);
            date_toi_report_tinhthanh.Name = "date_toi_report_tinhthanh";
            date_toi_report_tinhthanh.Size = new Size(200, 21);
            date_toi_report_tinhthanh.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 7);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 14;
            label7.Text = "Từ ngày:";
            // 
            // date_tu_report_tinhthanh
            // 
            date_tu_report_tinhthanh.CustomFormat = "dd/MM/yyyy";
            date_tu_report_tinhthanh.Format = DateTimePickerFormat.Custom;
            date_tu_report_tinhthanh.Location = new Point(6, 23);
            date_tu_report_tinhthanh.Name = "date_tu_report_tinhthanh";
            date_tu_report_tinhthanh.Size = new Size(200, 21);
            date_tu_report_tinhthanh.TabIndex = 12;
            // 
            // datagv_report_tinhthanh
            // 
            datagv_report_tinhthanh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagv_report_tinhthanh.Dock = DockStyle.Fill;
            datagv_report_tinhthanh.Location = new Point(0, 0);
            datagv_report_tinhthanh.Name = "datagv_report_tinhthanh";
            datagv_report_tinhthanh.Size = new Size(1018, 544);
            datagv_report_tinhthanh.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(splitContainer2);
            tabPage4.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1024, 661);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Báo cáo phân loại thành phố";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(total_rpquanhuyen);
            splitContainer2.Panel1.Controls.Add(label8);
            splitContainer2.Panel1.Controls.Add(btn_rpquanhuyen);
            splitContainer2.Panel1.Controls.Add(btn_excel_rpquanhuyen);
            splitContainer2.Panel1.Controls.Add(label9);
            splitContainer2.Panel1.Controls.Add(date_toingay_rpquanhuyen);
            splitContainer2.Panel1.Controls.Add(label10);
            splitContainer2.Panel1.Controls.Add(date_tungay_rpquanhuyen);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(datagv_rp_quanhuyen);
            splitContainer2.Size = new Size(1018, 655);
            splitContainer2.SplitterDistance = 99;
            splitContainer2.TabIndex = 0;
            splitContainer2.SplitterMoved += splitContainer2_SplitterMoved;
            // 
            // total_rpquanhuyen
            // 
            total_rpquanhuyen.AutoSize = true;
            total_rpquanhuyen.ForeColor = Color.Red;
            total_rpquanhuyen.Location = new Point(347, 71);
            total_rpquanhuyen.Name = "total_rpquanhuyen";
            total_rpquanhuyen.Size = new Size(13, 15);
            total_rpquanhuyen.TabIndex = 29;
            total_rpquanhuyen.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(258, 73);
            label8.Name = "label8";
            label8.Size = new Size(83, 15);
            label8.TabIndex = 23;
            label8.Text = "Tổng số hồ sơ:";
            // 
            // btn_rpquanhuyen
            // 
            btn_rpquanhuyen.BackColor = Color.DodgerBlue;
            btn_rpquanhuyen.ForeColor = Color.White;
            btn_rpquanhuyen.Location = new Point(258, 24);
            btn_rpquanhuyen.Margin = new Padding(3, 2, 3, 2);
            btn_rpquanhuyen.Name = "btn_rpquanhuyen";
            btn_rpquanhuyen.Size = new Size(144, 47);
            btn_rpquanhuyen.TabIndex = 28;
            btn_rpquanhuyen.Text = "Tìm";
            btn_rpquanhuyen.UseVisualStyleBackColor = false;
            btn_rpquanhuyen.Click += btn_rpquanhuyen_Click;
            // 
            // btn_excel_rpquanhuyen
            // 
            btn_excel_rpquanhuyen.BackColor = Color.ForestGreen;
            btn_excel_rpquanhuyen.ForeColor = Color.White;
            btn_excel_rpquanhuyen.Location = new Point(407, 24);
            btn_excel_rpquanhuyen.Name = "btn_excel_rpquanhuyen";
            btn_excel_rpquanhuyen.Size = new Size(152, 47);
            btn_excel_rpquanhuyen.TabIndex = 27;
            btn_excel_rpquanhuyen.Text = "Xuất Excel";
            btn_excel_rpquanhuyen.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(8, 50);
            label9.Name = "label9";
            label9.Size = new Size(58, 15);
            label9.TabIndex = 26;
            label9.Text = "Tới ngày:";
            // 
            // date_toingay_rpquanhuyen
            // 
            date_toingay_rpquanhuyen.CustomFormat = "dd/MM/yyyy";
            date_toingay_rpquanhuyen.Format = DateTimePickerFormat.Custom;
            date_toingay_rpquanhuyen.Location = new Point(8, 65);
            date_toingay_rpquanhuyen.Name = "date_toingay_rpquanhuyen";
            date_toingay_rpquanhuyen.Size = new Size(200, 21);
            date_toingay_rpquanhuyen.TabIndex = 25;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(8, 8);
            label10.Name = "label10";
            label10.Size = new Size(54, 15);
            label10.TabIndex = 24;
            label10.Text = "Từ ngày:";
            // 
            // date_tungay_rpquanhuyen
            // 
            date_tungay_rpquanhuyen.CustomFormat = "dd/MM/yyyy";
            date_tungay_rpquanhuyen.Format = DateTimePickerFormat.Custom;
            date_tungay_rpquanhuyen.Location = new Point(8, 24);
            date_tungay_rpquanhuyen.Name = "date_tungay_rpquanhuyen";
            date_tungay_rpquanhuyen.Size = new Size(200, 21);
            date_tungay_rpquanhuyen.TabIndex = 22;
            // 
            // datagv_rp_quanhuyen
            // 
            datagv_rp_quanhuyen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagv_rp_quanhuyen.Dock = DockStyle.Fill;
            datagv_rp_quanhuyen.Location = new Point(0, 0);
            datagv_rp_quanhuyen.Name = "datagv_rp_quanhuyen";
            datagv_rp_quanhuyen.Size = new Size(1018, 552);
            datagv_rp_quanhuyen.TabIndex = 0;
            // 
            // tabPage5
            // 
            tabPage5.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1024, 661);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Báo phân loại tuổi";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage6.Location = new Point(4, 24);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(1024, 661);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Tình hình hoạt động chuyên môn";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 689);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            split_report_nhiem.Panel1.ResumeLayout(false);
            split_report_nhiem.Panel1.PerformLayout();
            split_report_nhiem.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)split_report_nhiem).EndInit();
            split_report_nhiem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)data_table_report_nhiem).EndInit();
            tabPage3.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)datagv_report_tinhthanh).EndInit();
            tabPage4.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)datagv_rp_quanhuyen).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private SplitContainer split_report_nhiem;
        private Label label2;
        private DateTimePicker date_pic_end__report_nhiem;
        private Label label1;
        private DateTimePicker date_pic_start_report_nhiem;
        private Button btn_export_excel_report_nhiem;
        private DataGridView data_table_report_nhiem;
        private CheckBox check_month;
        private CheckBox check_date;
        private Button btn_search;
        private Label label3;
        private Label lb_total_data;
        private SplitContainer splitContainer1;
        private Label total_report_tinhthanh;
        private Label label5;
        private Button btn_tim_report_tinhthanh;
        private Button btn_xuat_excel_report_tinhthanh;
        private Label label6;
        private DateTimePicker date_toi_report_tinhthanh;
        private Label label7;
        private DateTimePicker date_tu_report_tinhthanh;
        private DataGridView datagv_report_tinhthanh;
        private SplitContainer splitContainer2;
        private Label total_rpquanhuyen;
        private Label label8;
        private Button btn_rpquanhuyen;
        private Button btn_excel_rpquanhuyen;
        private Label label9;
        private DateTimePicker date_toingay_rpquanhuyen;
        private Label label10;
        private DateTimePicker date_tungay_rpquanhuyen;
        private DataGridView datagv_rp_quanhuyen;
    }
}
