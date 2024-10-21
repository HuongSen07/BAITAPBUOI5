using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAITAPBUOI5
{
    public partial class Form1 : Form
    {
        private StudentModel db;
        public Form1()
        {
            InitializeComponent();
            db = new StudentModel();
            LoadData();
            LoadKhoaData();
        }
        private void LoadData()
        {
            try
            {
                var sinhViens = db.SinhVien.ToList();
                dataGridView1.DataSource = sinhViens;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadKhoaData()
        {
            try
            {
                // Lấy danh sách khoa từ cơ sở dữ liệu
                var khoaList = db.SinhVien.Select(sv => sv.Khoa).Distinct().ToList();

                // Đổ dữ liệu vào ComboBox
                cmbKhoa.DataSource = khoaList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra chỉ số hàng có hợp lệ không
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Đổ dữ liệu từ DataGridView lên các control
                txtMSSV.Text = row.Cells["MSSV"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                cmbKhoa.Text = row.Cells["Khoa"].Value.ToString();
                txtDiem.Text = row.Cells["Diem"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var newSinhVien = new SinhVien
            {
                MSSV = txtMSSV.Text,
                HoTen = txtHoTen.Text,
                Khoa = cmbKhoa.Text,
                Diem = float.Parse(txtDiem.Text)
            };

            db.SinhVien.Add(newSinhVien);
            db.SaveChanges();
            LoadData();
            ClearFields();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var mssv = txtMSSV.Text;
            var sinhVien = db.SinhVien.FirstOrDefault(sv => sv.MSSV == mssv);
            if (sinhVien != null)
            {
                sinhVien.HoTen = txtHoTen.Text;
                sinhVien.Khoa = cmbKhoa.Text;
                sinhVien.Diem = float.Parse(txtDiem.Text);

                db.SaveChanges();
                LoadData();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Sinh viên không tồn tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var mssv = txtMSSV.Text;
            var sinhVien = db.SinhVien.FirstOrDefault(sv => sv.MSSV == mssv);
            if (sinhVien != null)
            {
                db.SinhVien.Remove(sinhVien);
                db.SaveChanges();
                LoadData();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Sinh viên không tồn tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ClearFields()
        {
            txtMSSV.Clear();
            txtHoTen.Clear();
            cmbKhoa.SelectedIndex = -1; // Chọn không có giá trị
            txtDiem.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Hủy bỏ việc đóng form nếu người dùng chọn "Không"
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
