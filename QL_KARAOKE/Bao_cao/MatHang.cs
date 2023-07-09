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
    public partial class MatHang : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-74GC5N8\SQLEXPRESS;Initial Catalog=QLKARAOKE;Integrated Security=True");
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        public MatHang()
        {
            InitializeComponent();
        }
        void databingding(DataTable pt)
        {
            txt_ma.DataBindings.Clear();
            txt_ten.DataBindings.Clear();
            txt_dvt.DataBindings.Clear();
            txt_dongia.DataBindings.Clear();
            txt_slTon.DataBindings.Clear();
            txt_ma.DataBindings.Add("Text",pt,"MADV");
            txt_ten.DataBindings.Add("Text", pt, "TENDV");
            txt_dvt.DataBindings.Add("Text", pt, "DVT");
            txt_dongia.DataBindings.Add("Text", pt, "DONGIA");
            txt_slTon.DataBindings.Add("Text", pt, "SLTON");
            


        }
      public  void load_data()
        {
            string h = "Select * from DICHVU ";
            da = new SqlDataAdapter(h, conn);
            da.Fill(ds, "DICHVU");
            dataGridView_DV.DataSource = ds.Tables["DICHVU"];
            
        }
        private void MatHang_Load(object sender, EventArgs e)
        {
            load_data();
            databingding(ds.Tables["DICHVU"]);
           
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string lenh = "INSERT INTO DICHVU VALUES(N'" +txt_ten.Text + "',N'"+txt_dvt.Text+"',"+txt_slTon.Text+","+txt_dongia.Text+")";
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
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string lenh = "DELETE DICHVU WHERE MADV="+txt_ma.Text+" ";
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
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string lenh = "UPDATE DICHVU set TENDV=N'"+txt_ten.Text+"',DVT=N'"+txt_dvt.Text+"',SLTON="+txt_slTon.Text+",DONGIA="+txt_dongia.Text+" WHERE MADV=" + txt_ma.Text + " ";
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
    }
}
