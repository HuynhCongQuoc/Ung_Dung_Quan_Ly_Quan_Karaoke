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
    public partial class TinhTien : Form
    {
        KetNoi ketnoi = new KetNoi();
        public TinhTien()
        {
            InitializeComponent();
        }
        public void taiPhong()
        {
            string lenh = "select * from dbo.Phong_trong()";
            dataGridView_phong.DataSource = ketnoi.thuchien(lenh, "PHONG");
            databingding_Phong();
        }
        public void taiMatHang()
        {
            string lenh = "select * from MATHANG";
            dataGridView_hanghoa.DataSource = ketnoi.thuchien(lenh, "MATHANG");
            databingding_MH();
        }
        public void maPhieu()
        {
            string lenh = "select MAPHIEU from PHIEUTHUE";
         comboBox_phieuThue.DataSource = ketnoi.thuchien(lenh, "PHIEUTHUE");
            comboBox_phieuThue.DisplayMember = "MAPHIEU";
            
        }
        public void databingding_Phong()
        {
            comboBox_maPhong.DataBindings.Clear();
            txt_tenph.DataBindings.Clear();
            txt_tinhTrang.DataBindings.Clear();
            comboBox_maPhong.DataBindings.Add("Text", dataGridView_phong.DataSource, "MAPHONG");
            txt_tenph.DataBindings.Add("Text", dataGridView_phong.DataSource, "TENPH");
            txt_tinhTrang.DataBindings.Add("Text", dataGridView_phong.DataSource, "TINHTRANG");

        }
        public void databingding_MH()
        {
            txt_maDV.DataBindings.Clear();
            txt_tenDV.DataBindings.Clear();
            txt_gia.DataBindings.Clear();
           txt_maDV.DataBindings.Add("Text", dataGridView_hanghoa.DataSource, "MAMH");
           txt_tenDV.DataBindings.Add("Text", dataGridView_hanghoa.DataSource, "TENMH");
           txt_gia.DataBindings.Add("Text", dataGridView_hanghoa.DataSource, "GIABAN");

        }
        public void taiTenKH()
        {
            string lenh = "Select * FROM KHACHHANG";
            comboBox_tenKH.DataSource = ketnoi.thuchien(lenh,"KHACHHANG");
            comboBox_tenKH.DisplayMember = "TEN";
            comboBox_tenKH.ValueMember = "MAKH";
            
        }
        public void taiMaHD()
        {
            string lenh = "SELECT * FROM HOADON";
            comboBox_SoHD.DataSource = ketnoi.thuchien(lenh, "HOADON");
            comboBox_SoHD.DisplayMember = "MAHD";
        }

      public void taiMaPhieuMoi()
        {
            string lenh = "SELECT CONCAT('SOPH', RIGHT(CONCAT('00',ISNULL(SUBSTRING(max(MAPHIEU),5,2),0) + 1),2)) from PHIEUTHUE where MAPHIEU like 'SOPH%'";
            string l = ketnoi.CreateAutoID(lenh);
           textBox_soPhieuthue.Text = l;
        }
        public  void tao_maHD()
        {
            string lenh = "SELECT CONCAT('HD', RIGHT(CONCAT('00',ISNULL(SUBSTRING(max(MAHD),3,2),0) + 1),2)) from HOADON where MAHD like 'HD%'";
            string l = ketnoi.LenhTraVe(lenh);
            txt_tong.Text = l;
        }
        private void TinhTien_Load(object sender, EventArgs e)
        {
            taiPhong();
            taiMatHang();
            maPhieu();
            taiMaPhieuMoi();
            taiTenKH();
            taiMaHD();
            TenNV();




        }

        private void btn_thuePhong_Click(object sender, EventArgs e)
        {
            string nhap = "Insert into PHIEUTHUE values('" + textBox_soPhieuthue.Text + "','" + comboBox_maPhong.Text + "',GETDATE(),getdate(),null)";
            ketnoi.thuchienlenh(nhap);
            maPhieu();
            taiPhong();
            //taiMaPhieuMoi();




        }
        public void taiHD()
        {
            string lenh = "select CHITIETHD.MAMH,MATHANG.TENMH as N'TENHANG',SL,(SL*MATHANG.GIABAN) as N'Giá' from CHITIETHD,MATHANG where CHITIETHD.MAMH=MATHANG.MAMH AND MAHD='"+comboBox_SoHD.Text+"'";
           dataGridView_CTHD.DataSource = ketnoi.thuchien(lenh, "CHITIETHD");
           
        }
        public string loadTienDV()
        {
            string lenh = "select TIENDV from HOADON where  MAHD='" + comboBox_SoHD.Text + "'";
            object l = ketnoi.tiendv(lenh);
            string kq = l.ToString();
            return kq;
        }
        public string loadTienPhong()
        {
            string lenh = "select TIENPHONG from HOADON where  MAHD='" + comboBox_SoHD.Text + "'";
            object l = ketnoi.tiendv(lenh);
            string kq = l.ToString();
            return kq;
        }
        public string loadTong()
        {
            string lenh = "select TONGTIEN from HOADON where  MAHD='" + comboBox_SoHD.Text + "'";
            object l = ketnoi.tiendv(lenh);
            string kq = l.ToString();
            return kq;
        }
        private void btn_themMH_Click(object sender, EventArgs e)
        {
            string lenh = "INSERT INTO CHITIETHD values('" + comboBox_SoHD.Text + "','" + txt_maDV.Text + "'," + numericUpDown2.Value + ",0)";
            ketnoi.thuchienlenh(lenh);
            taiHD();
            txt_TienDV.Text = loadTienDV();
            
        }

        private void button_TaoHD_Click(object sender, EventArgs e)
        {
            string l;
            l = ketnoi.MAHD();
            string nhap = "INSERT INTO HOADON VALUES('"+l+"','"+comboBox_tenKH.SelectedValue.ToString()+"','"+comboBox_phieuThue.Text+"','"+txt_tenNV.Text+"',GETDATE(),0,0,0,0)";
            ketnoi.thuchienlenh(nhap);
            taiMaHD();


        }
        public void updateGio()
        {
            string lenh = "update PHIEUTHUEset GIODI = GETDATE() where MAPHIEU = '"+comboBox_SoHD.Text+"'";
            ketnoi.thuchienlenh(lenh);
        }
        public void updateTienPhong()
        {
            string lenh = "exec UpdateTien '"+comboBox_SoHD.Text+"'";
            ketnoi.thuchienlenh(lenh);
        }
        public void updateTong()
        {
            string lenh = "update HOADON set TONGTIEN=TIENPHONG+TIENDV where MAHD='"+comboBox_SoHD.Text+"'";
            ketnoi.thuchienlenh(lenh);
        }
        public void upDAteHD()
        {
            updateGio();
            updateTienPhong();

            updateTong();

        }
        
        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            upDAteHD();
            txt_tienPh.Text = loadTienPhong();
            txt_tong.Text = loadTong();


        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            InHD m = new InHD();
            m.Message = comboBox_SoHD.Text;
            m.ShowDialog();
            this.Show();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DN dn = new DN();
            dn.ShowDialog();
            this.Show();
        }
       
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        private string _message;
        public void TenNV()
        {
            string h = _message;
            txt_tenNV.Text = h;
            string lenh = "select MANV from NHANVIEN WHERE TENDN='"+h+"'";
            txt_tenNV.Text = ketnoi.LenhTraVe(lenh);
        }

       
    }
}
