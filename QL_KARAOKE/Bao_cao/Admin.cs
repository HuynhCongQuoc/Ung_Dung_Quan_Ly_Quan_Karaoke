using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bao_cao
{
    public partial class Admin : Form
    {
        KetNoi k = new KetNoi();

        public Admin()
        {
            InitializeComponent();
        }
       public void taiNhanVien()
        {
            string lenh = "SELECT * FROM NHANVIEN ";
            dataGridView_NV.DataSource = k.thuchien(lenh,"NHANVIEN");
            databingding_NV();
        }
        public void taiHang()
        {
            string lenh = "SELECT * FROM MATHANG ";
              dataGridView_MH.DataSource = k.thuchien(lenh, "MATHANG");
            databingding_MH();
        }
        public void taiKH()
        {
            string lenh = "SELECT * FROM KHACHHANG ";
           dataGridView_KH.DataSource = k.thuchien(lenh, "KHACHHANG");
            databingding_KH();

        }
        public void databingding_MH()
        {
            txt_MaMH.DataBindings.Clear();
            txt_TenMh.DataBindings.Clear();
            txt_SL.DataBindings.Clear();
            comboBox_DVT.DataBindings.Clear();
            txt_giaban.DataBindings.Clear();

            txt_MaMH.DataBindings.Add("Text", dataGridView_MH.DataSource, "MAMH");
            txt_TenMh.DataBindings.Add("Text", dataGridView_MH.DataSource, "TENMH");
            txt_SL.DataBindings.Add("Text", dataGridView_MH.DataSource, "SLTON");
            comboBox_DVT.DataBindings.Add("Text", dataGridView_MH.DataSource, "DVT");
            txt_giaban.DataBindings.Add("Text", dataGridView_MH.DataSource, "GIABAN");

        }
        public void databingding_KH()
        {
            txt_Makh.DataBindings.Clear();
            txt_tenKH.DataBindings.Clear();
            txt_DCKH.DataBindings.Clear();
            txt_SDTKH.DataBindings.Clear();
            txt_Makh.DataBindings.Add("Text", dataGridView_KH.DataSource, "MAKH");
            txt_tenKH.DataBindings.Add("Text", dataGridView_KH.DataSource, "TEN");
            txt_DCKH.DataBindings.Add("Text", dataGridView_KH.DataSource, "DIACHI");
            txt_SDTKH.DataBindings.Add("Text", dataGridView_KH.DataSource, "SDT");
        }
        public void databingding_NV()
        {
            txt_maNV.DataBindings.Clear();
            txt_tenNV.DataBindings.Clear();
            txt_tenDN.DataBindings.Clear();
            txt_matKhau.DataBindings.Clear();
            txt_SDT.DataBindings.Clear();
            comboBox_chucvu.DataBindings.Clear();
            txt_CMT.DataBindings.Clear();
            dateTimePicker_NgayLam.DataBindings.Clear();
            dateTimePicker_ngaySinh.DataBindings.Clear();
            txt_diaChi.DataBindings.Clear();
            comboBox_GT.DataBindings.Clear();

            txt_maNV.DataBindings.Add("Text",dataGridView_NV.DataSource,"MANV");
            txt_tenNV.DataBindings.Add("Text", dataGridView_NV.DataSource, "TENNV");
            txt_tenDN.DataBindings.Add("Text", dataGridView_NV.DataSource, "TENDN");
            txt_matKhau.DataBindings.Add("Text", dataGridView_NV.DataSource, "MATKHAU");
            txt_SDT.DataBindings.Add("Text", dataGridView_NV.DataSource, "SDT");
            comboBox_chucvu.DataBindings.Add("Text", dataGridView_NV.DataSource, "CHUCVU");
            txt_CMT.DataBindings.Add("Text", dataGridView_NV.DataSource, "CMT");
            //dateTimePicker_NgayLam.("Text", dataGridView_NV.DataSource, "TENNV");
            //dateTimePicker_ngaySinh.Add("Text", dataGridView_NV.DataSource, "TENNV");
            txt_diaChi.DataBindings.Add("Text", dataGridView_NV.DataSource, "DIACHI");
            comboBox_GT.DataBindings.Add("Text", dataGridView_NV.DataSource, "GIOITINH");


        }
        private void txt_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                this.errorProvider1.SetError(ctr, "Chỉ nhập sô");
            }
            else
                this.errorProvider1.Clear();

        }

        private void txt_CMT_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                this.errorProvider1.SetError(ctr, "Chỉ nhập sô");
            }

            else
                this.errorProvider1.Clear();
        }

        private void txt_SL_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                this.errorProvider1.SetError(ctr, "Chỉ nhập sô");
            }
            else
                this.errorProvider1.Clear();

        }

        private void txt_giaban_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                this.errorProvider1.SetError(ctr, "Chỉ nhập sô");
            }
            else
                this.errorProvider1.Clear();

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                this.errorProvider1.SetError(ctr, "Chỉ nhập sô");
            }
            else
                this.errorProvider1.Clear();



        }

        private void Admin_Load(object sender, EventArgs e)
        {
            taiNhanVien();
            taiHang();
            taiKH();
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            if(txt_tenTim.Text.Length==0)
            {
                MessageBox.Show("Không được để trống");
            }    
            else
            {
                string lenh = "SELECT * FROM NHANVIEN where TENNV like N'%"+txt_tenTim.Text+"%' ";
               dataGridView_NV.DataSource = k.thuchien(lenh, "NHANVIEN");
                databingding_NV();
            }    
        }

        private void btn_timMH_Click(object sender, EventArgs e)
        {
            if (txt_tnMH.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống");
            }
            else
            {
                string lenh = "SELECT * FROM MATHANG where TENMH like N'%" + txt_tnMH.Text + "%' ";
                dataGridView_MH.DataSource = k.thuchien(lenh, "MATHANG");
                databingding_MH();
            }
        }

        private void btn_timkH_Click(object sender, EventArgs e)
        {
            if (txt_TimKH.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống");
            }
            else
            {
                string lenh = "SELECT * FROM KHACHHANG where TEN like N'%" +txt_TimKH.Text+ "%' ";
             dataGridView_KH.DataSource = k.thuchien(lenh, "KHACHHANG");
                databingding_KH();
            }
        }

        private void đĂNGXUÂTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DN d = new DN();
            d.ShowDialog();
            this.Show();
            Application.Exit();
        }

        private void tHANHTOANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TinhTien t = new TinhTien();
            t.ShowDialog();
            Application.Exit();
            this.Show();
           
        }
       public void them()
        {
            
        }
        private void btn_ThemKH_Click(object sender, EventArgs e)
        {
            if (txt_tenKH.Text.Length == 0 || txt_SDTKH.Text.Length == 0 || txt_DCKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin!");
            }
            else
            {
                string a;
                string ma = " SELECT CONCAT('KH', RIGHT(CONCAT('00', ISNULL(SUBSTRING(max(MAKH), 3, 2), 0) + 1), 2)) from KHACHHANG where MAKH like 'KH%'";
                a = k.LenhTraVe(ma);
                string lenh = "Insert into KHACHHANG values('" + a + "',N'" + txt_tenKH.Text + "','" + txt_SDTKH.Text + "',N'" + txt_DCKH.Text + "',0)";
                k.thuchienlenh(lenh);
                taiKH();
            }

        }

        private void btn_xoaKH_Click(object sender, EventArgs e)
        {
            string lenh = "DELETE KHACHHANG WHERE MAKH='"+txt_Makh.Text+"'";
            k.thuchienlenh(lenh);
            taiKH();
        }

        private void btn_suaKH_Click(object sender, EventArgs e)
        {
            if (txt_tenKH.Text.Length == 0 || txt_SDTKH.Text.Length == 0 || txt_DCKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin!");
            }
            else
            {
                string lenh = "UPDATE KHACHHANG SET TEN=N'" + txt_tenKH.Text + "',SDT='" + txt_SDTKH.Text + "',DIACHI='" + txt_DCKH.Text + "' WHERE MAKH='" + txt_Makh.Text + "'";
                k.thuchienlenh(lenh);
                taiKH();
            }
        }

        private void btn_themMH_Click(object sender, EventArgs e)
        {
            if (txt_TenMh.Text.Length == 0 ||comboBox_DVT.Text.Length == 0 || txt_SL.Text.Length == 0||txt_giaban.Text.Length==0)
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin!");
            }
            else
            {
                string a;
                string ma = " SELECT CONCAT('MMH', RIGHT(CONCAT('00',ISNULL(SUBSTRING(max(MAMH),4,2),0) + 1),2)) from MATHANG where MAMH like 'MHH%'";
                a = k.LenhTraVe(ma);
                string lenh = "Insert into MATHANG values('" + a + "',N'" +txt_TenMh.Text + "','" + comboBox_DVT.Text+ "',"+txt_SL.Text+","+txt_giaban.Text+")";
                k.thuchienlenh(lenh);
                taiHang();
            }
        }

        private void btn_xoaMH_Click(object sender, EventArgs e)
        {
            if (txt_MaMH.Text.Length ==0)
            {
                MessageBox.Show("Bạn phải mã mặt hàng cần xóa!");
            }
            else
            {
              
                string lenh = "DELETE  MATHANG where MAMH='"+txt_MaMH.Text+"'";
                k.thuchienlenh(lenh);
                taiHang();
            }
        }

        private void btn_suaMH_Click(object sender, EventArgs e)
        {
            if (txt_MaMH.Text.Length==0||txt_TenMh.Text.Length == 0 || comboBox_DVT.Text.Length == 0 || txt_SL.Text.Length == 0 || txt_giaban.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin!");
            }
            else
            {
               

                string lenh = "UPDATE  MATHANG SET TENMH=N'" + txt_TenMh.Text + "',DVT='" + comboBox_DVT.Text + "',SLTON=" + txt_SL.Text + ",GIABAN=" + txt_giaban.Text + " where MAMH='"+txt_MaMH.Text+"'";
                k.thuchienlenh(lenh);
                taiHang();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (txt_tenDN.Text.Length == 0 || txt_tenNV.Text.Length == 0 || txt_matKhau.Text.Length == 0 || txt_diaChi.Text.Length == 0 || txt_SDT.Text.Length == 0||txt_CMT.Text.Length==0|| comboBox_GT.Text.Length==0|| comboBox_chucvu.Text.Length==0)
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin!");
            }
            else
            {
                string a;
                string ma = "SELECT CONCAT('NV', RIGHT(CONCAT('00',ISNULL(SUBSTRING(max(MANV),3,2),0) + 1),2)) from NHANVIEN where MANV like 'NV%'";
                a = k.LenhTraVe(ma);
                string lenh = "INSERT into  NHANVIEN VALUES('"+a+"','"+txt_tenDN.Text+"','"+txt_matKhau.Text+"',N'"+txt_tenNV.Text+"',N'"+txt_diaChi.Text+"','"+txt_SDT.Text+"','"+txt_CMT.Text+"','"+comboBox_GT.Text+"','"+dateTimePicker_ngaySinh.Value.ToString("MM/dd/yyyy")+"','"+dateTimePicker_NgayLam.Value.ToString("MM/dd/yyyy")+"',N'"+comboBox_chucvu.Text+"')";
                k.thuchienlenh(lenh);
                taiNhanVien();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (txt_maNV.Text.Length ==0)
            {
                MessageBox.Show("Bạn phải chọn mã nhân viên cần xóa!");
            }
            else
            {

                string lenh = "DELETE NHANVIEN WHERE MANV='"+txt_maNV.Text+"' ";
                k.thuchienlenh(lenh);
                taiNhanVien();
            }
        }
        
    }
}
