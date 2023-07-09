
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bao_cao
{
    public partial class NhanVien : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-74GC5N8\SQLEXPRESS;Initial Catalog=QLKARAOKE;Integrated Security=True");
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        public NhanVien()
        {
            InitializeComponent();
        }
        public void load_data()
        {
            
            string strselect = "select * from NHANVIEN";
            da = new SqlDataAdapter(strselect, conn);

            da.Fill(ds, "NHANVIEN");
            dtgDSNV.DataSource = ds.Tables["NHANVIEN"];
        }
        void databingding(DataTable pt)
        {
            txt_ma.DataBindings.Clear();
            txt_hoten.DataBindings.Clear();
            txt_tenDn.DataBindings.Clear();
            txt_matKhau.DataBindings.Clear();
            txt_DiaChi.DataBindings.Clear();
            txt_sdt.DataBindings.Clear();
            txt_cmnd.DataBindings.Clear();
            dateTimePicker1.DataBindings.Clear();

            txt_ma.DataBindings.Add("Text",pt,"MANV");
            txt_hoten.DataBindings.Add("Text", pt, "HOTEN");
            txt_tenDn.DataBindings.Add("Text", pt, "TENDN");
            txt_matKhau.DataBindings.Add("Text", pt, "MATKHAU");
            txt_DiaChi.DataBindings.Add("Text", pt, "DIACHI");
            txt_sdt.DataBindings.Add("Text", pt, "SDT");
            txt_cmnd.DataBindings.Add("Text", pt, "CMND");
            dateTimePicker1.DataBindings.Add("Text", pt, "NGAYSINH");

        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            load_data();
            databingding(ds.Tables["NHANVIEN"]);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            string sex = (Nam.Checked ? Nam.Text : Nu.Text);
            string lenh = "Insert into NHANVIEN VALUES('"+txt_hoten.Text+"',null,null,null,null,null,null,null)";
            string o = "exec ThemNV N'"+txt_hoten.Text+"','" + dateTimePicker1.Value.ToString("dd/mm/yyyy") + "','"+txt_tenDn.Text+"','"+txt_matKhau.Text+"',N'"+sex+"',N'"+txt_DiaChi.Text+"','"+txt_cmnd.Text+","+txt_sdt.Text+"'";
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand(lenh, conn);
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Thành công");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại");
            }
            
        }
        private void btn_sua_Click(object sender, EventArgs e)

        {
            string sex = (Nam.Checked ? Nam.Text : Nu.Text);
            string lenh = "update NHANVIEN set HOTEN=N'"+txt_hoten.Text+"',NGAYSINH='"+ dateTimePicker1.Value.ToString("dd/mm/yyyy") + "',TENDN='"+txt_tenDn.Text+"',GIOITINH=N'"+sex+"',DIACHI=N'"+txt_DiaChi.Text+"',CMND='"+txt_cmnd+"',SDT='"+txt_sdt.Text+"'where MANV="+txt_ma.Text+"";
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand(lenh, conn);
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Thành công");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại");
            }
           
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string lenh = "DELETE NHANVIEN WHERE MANV="+txt_ma.Text+"";
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand(lenh, conn);
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Thành công");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại");
            }
          
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
