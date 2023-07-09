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
    public partial class DN : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-74GC5N8\SQLEXPRESS;Initial Catalog=QL_KARAOKE;Integrated Security=True");
        DataSet ds = new DataSet();
        //SqlDataAdapter da;
        public static string UserName = "";
        public DN()
        {
            InitializeComponent();
        }

        private void ck_Show_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_Show.Checked)
            {
                txt_matKhau.PasswordChar = (char)0;
            }
            else
            {
                txt_matKhau.PasswordChar = '*';
            }
        }

        private void button_thoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
                Application.Exit();
        }

        private void btn_DN_Click(object sender, EventArgs e)
        {
            
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_AuthoLogin";
                cmd.Parameters.AddWithValue("@UserName", txt_TenDN.Text);
                cmd.Parameters.AddWithValue("@Password", txt_matKhau.Text);
                cmd.Connection = conn;
                UserName = txt_TenDN.Text;
                object kq = cmd.ExecuteScalar();
                int code = Convert.ToInt32(kq);
                
                if (code == 1)
                {
                    MessageBox.Show("Chào mừng bạn đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TinhTien th = new TinhTien();
                    th.Message = txt_TenDN.Text;
                    th.ShowDialog();
                    this.Show();
                }
                else if (code == 0)
                {
                    MessageBox.Show("Chào mừng bạn đăng nhập ADMIN", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Admin ad = new Admin();
                    ad.ShowDialog();
                    this.Show();

                }
                else if (code == 2)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_matKhau.Text = "";
                    txt_TenDN.Text = "";
                    txt_TenDN.Focus();
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_matKhau.Text = "";
                    txt_TenDN.Text = "";
                    txt_TenDN.Focus();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void txt_TenDN_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(ctr, "Vui lòng nhập tên đăng nhập!");
                
            }
            else
                this.errorProvider1.Clear();
        }

        private void txt_matKhau_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(ctr, "Vui lòng mật khẩu!");
            }
            else
                this.errorProvider1.Clear();
        }
       
     
    }
}
